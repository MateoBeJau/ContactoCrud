using CrudNet7MVC.Datos;
using CrudNet7MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CrudNet7MVC.Controllers
{
    public class InicioController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InicioController(ApplicationDbContext contexto)
        {
            _context = contexto;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Contacto.ToListAsync());
        }

        public IActionResult Crear()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken] //Seguirdad prevenir ataques kks
        public async Task<IActionResult> Crear(Contacto contacto)
        {
            if (ModelState.IsValid) //valida el contacto si un atribuo es malo devuelve la vista
            {
                _context.Contacto.Add(contacto);
                await _context.SaveChangesAsync(); // guarda el contacto
                return RedirectToAction(nameof(Index)); // si ta todo ok, me redireciona al inde
            }

            return View();
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if(id == null)
                return NotFound();

            var contacto = _context.Contacto.Find(id);
            if (contacto == null)
            {
                return NotFound();
            }
            return View(contacto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Contacto contacto)
        {
            if (ModelState.IsValid) //valida el contacto si un atribuo es malo devuelve la vista
            {
                _context.Update(contacto);
                await _context.SaveChangesAsync(); // guarda el contacto
                return RedirectToAction(nameof(Index)); // si ta todo ok, me redireciona al inde
            }

            return View();
        }


        [HttpGet]
        public IActionResult Detalle(int? id)
        {
            if (id == null)
                return NotFound();

            var contacto = _context.Contacto.Find(id);
            if (contacto == null)
            {
                return NotFound();
            }
            return View(contacto);
        }

        [HttpGet]
        public IActionResult Borrar(int? id)
        {
            if (id == null)
                return NotFound();

            var contacto = _context.Contacto.Find(id);
            if (contacto == null)
            {
                return NotFound();
            }
            return View(contacto);
        }
        [HttpPost, ActionName("Borrar")] // El action name es por si el nombre de un metodo se repite tano el metodo como el parametro
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BorrarContacto(int? id)
        {
            var contacto = await _context.Contacto.FindAsync(id);
            if (contacto == null)
            {
                return View();
            }
           //Borrado
           _context.Contacto.Remove(contacto);
            await _context.SaveChangesAsync(); //Guarda el borrado 
            return RedirectToAction(nameof(Index)); //ME REDIRECIONA AL INDEX
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