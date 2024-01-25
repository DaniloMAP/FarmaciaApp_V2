namespace FarmaciaApp_V2.Models;
using Microsoft.AspNetCore.Mvc;

public class ReacoesAdversasController : Controller
{
    private readonly ApplicationDBContext _context;

    public ReacoesAdversasController(ApplicationDBContext context)
    {
        _context = context;
    }

    // Ação para exibir a lista de Reações Adversas
    public IActionResult Index()
    {
        var reacoes = _context.ReacoesAdversas.ToList();
        return View(reacoes);
    }

    // Ação para adicionar uma nova Reação Adversa
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(ReacaoAdversa reacao)
    {
        if (ModelState.IsValid)
        {
            _context.ReacoesAdversas.Add(reacao);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(reacao);
    }

    // Ação para editar uma Reação Adversa existente
    public IActionResult Edit(int id)
    {
        var reacao = _context.ReacoesAdversas.Find(id);
        return View(reacao);
    }

    [HttpPost]
    public IActionResult Edit(ReacaoAdversa reacao)
    {
        if (ModelState.IsValid)
        {
            _context.Update(reacao);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(reacao);
    }

    // Ação para excluir uma Reação Adversa existente
    public IActionResult Delete(int id)
    {
        var reacao = _context.ReacoesAdversas.Find(id);
        _context.ReacoesAdversas.Remove(reacao);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}
