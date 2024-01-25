using FarmaciaApp_V2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

public class MedicamentosController : Controller
{
    private readonly ApplicationDBContext _context;

    public MedicamentosController(ApplicationDBContext context)
    {
        _context = context;
    }

    // Ação para exibir a lista de Medicamentos
    public IActionResult Index()
    {
        var medicamentos = _context.Medicamentos.Include(m => m.Fabricante).ToList();
        return View(medicamentos);
    }

    // Ação para adicionar um novo Medicamento
    public IActionResult Create()
    {
        ViewBag.Fabricantes = new SelectList(_context.Fabricantes, "Id", "Nome");
        return View();
    }

    [HttpPost]
    public IActionResult Create(Medicamento medicamento)
    {
        // Não há validações no lado do servidor neste exemplo
        // As validações devem ser tratadas no lado do cliente (frontend)
        
        ViewBag.Fabricantes = new SelectList(_context.Fabricantes, "Id", "Nome", medicamento.FabricanteId);
        return View(medicamento);
    }

    // Ação para editar um Medicamento existente
    public IActionResult Edit(int id)
    {
        var medicamento = _context.Medicamentos.Find(id);

        if (medicamento == null)
        {
            return NotFound();
        }

        ViewBag.Fabricantes = new SelectList(_context.Fabricantes, "Id", "Nome", medicamento.FabricanteId);
        return View(medicamento);
    }

    [HttpPost]
    public IActionResult Edit(Medicamento medicamento)
    {
        // Não há validações no lado do servidor neste exemplo
        // As validações devem ser tratadas no lado do cliente (frontend)
        
        ViewBag.Fabricantes = new SelectList(_context.Fabricantes, "Id", "Nome", medicamento.FabricanteId);
        return View(medicamento);
    }

    // Ação para excluir um Medicamento existente
    public IActionResult Delete(int id)
    {
        var medicamento = _context.Medicamentos.Find(id);

        if (medicamento == null)
        {
            return NotFound();
        }

        _context.Medicamentos.Remove(medicamento);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    
}
