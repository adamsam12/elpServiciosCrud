using CrudNet8MVC.Datos;
using CrudNet8MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CrudNet8MVC.Controllers
{
    public class ContactController : Controller
    {
       private readonly ApplicationDbContext _contexto;

        public ContactController(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public async Task<IActionResult> IndexContacto()
        {
            return View(await _contexto.Contacto.ToListAsync());
        }

        [HttpGet]
        public IActionResult CrearContacto()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearContacto(Contacto contacto)
        {
            if (ModelState.IsValid)
            {

                //Agregar la fecha y hora actual
                contacto.FechaCreacion = DateTime.Now;

                _contexto.Contacto.Add(contacto);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(IndexContacto));
            }

            return View();
        }


        [HttpGet]
        public IActionResult EditContacto(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var contacto = _contexto.Contacto.Find(id);
            if (contacto == null)
            {
                return NotFound();
            }

            return View(contacto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditContacto(Contacto contacto)
        {
            if (ModelState.IsValid)
            {               
                _contexto.Update(contacto);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(IndexContacto));
            }

            return View();
        }

        [HttpGet]
        public IActionResult DetailsContacto(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contacto = _contexto.Contacto.Find(id);
            if (contacto == null)
            {
                return NotFound();
            }

            return View(contacto);
        }

        [HttpGet]
        public IActionResult DeleteContacto(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contacto = _contexto.Contacto.Find(id);
            if (contacto == null)
            {
                return NotFound();
            }

            return View(contacto);
        }

        [HttpPost, ActionName("DeleteContacto")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BorrarContacto(int? id)
        {
            var contacto = await _contexto.Contacto.FindAsync(id);
            if(contacto == null)
            {
                return View();
            }

            //Borrado
            _contexto.Contacto.Remove(contacto);
            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(IndexContacto));            
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
}
