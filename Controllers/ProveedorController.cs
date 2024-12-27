using System.Diagnostics;
using CrudNet8MVC.Datos;
using CrudNet8MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudNet8MVC.Controllers;

public class ProveedorController : Controller
{
    //para acceder a la base de datos
    private readonly ApplicationDbContext db;

    //constructor que recibe la base de datos
    public ProveedorController(ApplicationDbContext db)
    {
        this.db = db;
    }
    
    
 //para mostrar todos los elementos
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        //retonar la vista con la lista de proveedores
        return View(await db.Proveedor.ToListAsync());
    }
    
    [HttpGet]
    public  IActionResult Create()
    {
        //retonar la vista para crear un nuevo proveedor
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken] //Proteccion contra ataques
    public async Task<IActionResult> Create(Proveedor proveedor)
    {
        if (ModelState.IsValid)
        {
            db.Proveedor.Add(proveedor);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    
        return View(proveedor);
}

    [HttpGet]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Editar(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
//buscar el proveedor por id
        var proveedor = await db.Proveedor.FindAsync(id);
        if (proveedor == null)
        {
            return NotFound();
            //si el local no existe, retornar
        }

        return View(proveedor);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Editar(Proveedor proveedor)
    {
        if (ModelState.IsValid)
        {
            db.Proveedor.Update(proveedor);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return View(proveedor);
    }
    [HttpGet]
    public async Task<IActionResult> Detalles(int? id)
    {
        if (id == null)
        {
            return NotFound();
            // si el id es nulo, retornar un error 404
        }
        
        // buscar el local por id
        var proveedor = await db.Proveedor.FindAsync(id);
        if (proveedor == null)
        {
            return NotFound();
            // si el local no existe, retornar un error 404
        }
        
        return View();
    } 
    [HttpGet]
    public async Task<IActionResult> Borrar(int? id)
    {
        if (id == null)
        {
            return NotFound();
            // si el id es nulo, retornar un error 404
        }
        
        // buscar el proveedor por id
        var proveedor = await db.Proveedor.FindAsync(id);
        if (proveedor == null)
        {
            return NotFound();
            // si el local no existe, retornar un error 404
        }
        
        return View(proveedor);
    } 
[HttpPost,ActionName("Borrar")]
    [ValidateAntiForgeryToken] // protección contra ataques CSRF
    
    public async Task<IActionResult> BorrarProveedor(int? id)
    {
        // buscar el local por id
        var proveedor = await db.Proveedor.FindAsync(id);
        if (proveedor == null)
        {
            return View();
        }
        // eliminar el local de la base de datos
        db.Proveedor.Remove(proveedor);
        await db.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
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