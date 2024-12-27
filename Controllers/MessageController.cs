using System.Diagnostics;
using CrudNet8MVC.Datos;
using CrudNet8MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CrudNet8MVC.Controllers;

public class MessageController:Controller
{
    private readonly ApplicationDbContext _contexto;
    
    public MessageController(ApplicationDbContext contexto)
    {
        _contexto = contexto;
    }
    
    [HttpGet]
    public async Task<IActionResult> IndexMessaje()
    {
        return View(await _contexto.Message.ToListAsync());
    }
    
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Message message)
    {
        if (ModelState.IsValid)
        {
            message.Date = DateTime.Now;
            _contexto.Message.Add(message);
            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(IndexMessaje));
        }
        return View();
    }
    
    [HttpGet]
    public IActionResult Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var message = _contexto.Message.Find(id);
        if (message == null)
        {
            return NotFound();
        }
        return View(message);
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Message message)
    {
        if (ModelState.IsValid)
        {
            _contexto.Message.Update(message);
            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(IndexMessaje));
        }
        return View(message);
    }
    
    [HttpGet]
    public IActionResult Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var message = _contexto.Message.Find(id);
        if (message == null)
        {
            return NotFound();
        }
        return View(message);
    }
    
    [HttpGet]
    public IActionResult Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var message = _contexto.Message.Find(id);
        if (message == null)
        {
            return NotFound();
        }
        return View(message);
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        var message = await _contexto.Message.FindAsync(id);
        _contexto.Message.Remove(message);
        await _contexto.SaveChangesAsync();
        return RedirectToAction(nameof(IndexMessaje));
    }
    
    
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
 
}