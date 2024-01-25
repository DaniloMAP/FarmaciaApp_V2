using FarmaciaApp_V2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

public class MedicamentosController : Controller
{
    private readonly ApplicationDBContext _context;

    public MedicamentosController(ApplicationDBContext context)
    {
        _context = context;
    }

    // Ação para exibir a lista de Medicamentos
    public async Task<IActionResult> Index()
    {
        var medicamentos = await _context.Medicamentos.Include(m => m.Fabricante).ToListAsync();
        return View(medicamentos);
    }

    // Ação para exibir detalhes de um Medicamento
    public async Task<IActionResult> Details(int? id)
{
    if (id == null)
    {
        return NotFound();
    }

    var medicamento = await _context.Medicamentos
        .Include(m => m.Fabricante)
        .Include(m => m.MedicamentoReacoesAdversas)
            .ThenInclude(mra => mra.ReacaoAdversa)
        .FirstOrDefaultAsync(m => m.Id == id);

    if (medicamento == null)
    {
        return NotFound();
    }

    return View(medicamento);
}


    // Ação para adicionar um novo Medicamento (GET)
    public IActionResult Create()
    {
        ViewBag.Fabricantes = new SelectList(_context.Fabricantes, "Id", "Nome");
        ViewBag.TodasReacoesAdversas = _context.ReacoesAdversas.ToList();
        return View();
    }

    // Ação para adicionar um novo Medicamento (POST)
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Medicamento medicamento)
    {
        medicamento.DataValidade = medicamento.DataValidade.ToUniversalTime();

        _context.Add(medicamento);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    // Ação para editar um Medicamento existente (GET)
    public async Task<IActionResult> Edit(int id)
    {
        var medicamento = await _context.Medicamentos
            .Include(m => m.MedicamentoReacoesAdversas)
                .ThenInclude(mra => mra.ReacaoAdversa)
            .FirstOrDefaultAsync(m => m.Id == id);

        if (medicamento == null)
        {
            return NotFound();
        }

        ViewBag.Fabricantes = new SelectList(_context.Fabricantes, "Id", "Nome", medicamento.FabricanteId);
        ViewBag.TodasReacoesAdversas = _context.ReacoesAdversas.ToList();
        return View(medicamento);
    }

    // Ação para editar um Medicamento existente (POST)
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Medicamento medicamento)
    {
        if (id != medicamento.Id)
        {
            return NotFound();
        }

        medicamento.DataValidade = medicamento.DataValidade.ToUniversalTime();

        var existingMedicamento = await _context.Medicamentos
            .Include(m => m.MedicamentoReacoesAdversas)
            .FirstOrDefaultAsync(m => m.Id == id);

        if (existingMedicamento == null)
        {
            return NotFound();
        }

        existingMedicamento.Nome = medicamento.Nome;
        existingMedicamento.FabricanteId = medicamento.FabricanteId;
        existingMedicamento.DataValidade = medicamento.DataValidade;

        try
        {
            _context.Update(existingMedicamento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!MedicamentoExists(medicamento.Id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        ViewBag.Fabricantes = new SelectList(_context.Fabricantes, "Id", "Nome", medicamento.FabricanteId);
        ViewBag.TodasReacoesAdversas = _context.ReacoesAdversas.ToList();
        return View(medicamento);
    }

    // Ação para excluir um Medicamento existente (GET)
    public async Task<IActionResult> Delete(int id)
    {
        var medicamento = await _context.Medicamentos.FindAsync(id);

        if (medicamento == null)
        {
            return NotFound();
        }

        return View(medicamento);
    }

    // Ação para excluir um Medicamento existente (POST)
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var medicamento = await _context.Medicamentos.FindAsync(id);

        if (medicamento == null)
        {
            return NotFound();
        }

        _context.Medicamentos.Remove(medicamento);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool MedicamentoExists(int id)
    {
        return _context.Medicamentos.Any(e => e.Id == id);
    }
}
