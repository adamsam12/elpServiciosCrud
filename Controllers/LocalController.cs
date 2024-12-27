using System.Diagnostics;
using CrudNet8MVC.Datos;
using CrudNet8MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudNet8MVC.Controllers;

public class LocalController:Controller
{
    // para acceder a la base de datos
    private readonly ApplicationDbContext db;
    
    // constructor que recibe la base de datos
    public LocalController(ApplicationDbContext db)
    {
        this.db = db;
    }

    [HttpGet]
    public async Task<IActionResult> IndexLocal()
    {
        // retornar la vista con la lista de locales
        return View(await db.Local.ToListAsync());
    }
    
    [HttpGet]
    
    public IActionResult CrearLocal()
    {
        // retornar la vista para crear un nuevo local
        return View();
    }


    [HttpPost]
    [ValidateAntiForgeryToken] // protección contra ataques CSRF
    public async Task<IActionResult> CrearLocal(Local local)
    {
        if (!ModelState.IsValid) return View();
        local.FechaCreacion = DateTime.Now;
        // si el modelo es válido, agregar el local a la base de datos
        db.Local.Add(local);
        await db.SaveChangesAsync();
        return RedirectToAction(nameof(IndexLocal));

    }


    [HttpGet]
    [ValidateAntiForgeryToken] // protección contra ataques CSRF
    public async Task<IActionResult> EditarLocal(int? id)
    {
        if (id == null)
        {
            return NotFound(); 
            // si el id es nulo, retornar un error 404
        }
        
        // buscar el local por id
        var local = await db.Local.FindAsync(id);
        if (local == null)
        {
            return NotFound();
            // si el local no existe, retornar un error 404
        }
        
        return View(local);
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken] // protección contra ataques CSRF
    public async Task<IActionResult> EditarLocal(Local local)
    {
        if (!ModelState.IsValid) return View(local);
        // si el modelo es válido, actualizar el local en la base de datos
        db.Local.Update(local);
        await db.SaveChangesAsync();
        return RedirectToAction(nameof(IndexLocal));
    }
    
    [HttpGet]
    public async Task<IActionResult> DetallesLocal(int? id)
    {
        if (id == null)
        {
            return NotFound();
            // si el id es nulo, retornar un error 404
        }
        
        // buscar el local por id
        var local = await db.Local.FindAsync(id);
        if (local == null)
        {
            return NotFound();
            // si el local no existe, retornar un error 404
        }
        
        return View(local);
    }
    
    [HttpGet]
    // esto es solo para mostrar la vista de confirmación
    public async Task<IActionResult> BorrarLocal(int? id)
    {
        if (id == null)
        {
            return NotFound();
            // si el id es nulo, retornar un error 404
        }
        
        // buscar el local por id
        var local = await db.Local.FindAsync(id);
        if (local == null)
        {
            return NotFound();
            // si el local no existe, retornar un error 404
        }
        
        return View(local);
    }
    
    [HttpPost,ActionName("Borrar")]
    [ValidateAntiForgeryToken] // protección contra ataques CSRF
    
    // este método se llama Borrar porque el método anterior se llama BorrarLocal
    public async Task<IActionResult> Borrar(int? id)
    {
        // buscar el local por id
        var local = await db.Local.FindAsync(id);
        if (local == null)
        {
            return View();
        }
        // eliminar el local de la base de datos
        db.Local.Remove(local);
        await db.SaveChangesAsync();
        return RedirectToAction(nameof(IndexLocal));
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