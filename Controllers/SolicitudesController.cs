using Microsoft.AspNetCore.Mvc;
using evaluacion20262.Data;
using evaluacion20262.Models;

namespace evaluacion20262.Controllers
{
    public class SolicitudesController : Controller
    {
        private readonly AppDbContext _context;

        public SolicitudesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Solicitudes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Solicitudes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SolicitudServicio solicitud)
        {
            if (ModelState.IsValid)
            {
                _context.Solicitudes.Add(solicitud);
                _context.SaveChanges();
                TempData["Mensaje"] = "Solicitud registrada con éxito.";
                return RedirectToAction("Index");
            }
            return View(solicitud);
        }

    // GET: Solicitudes/Index
        public IActionResult Index()
        {
            var lista = _context.Solicitudes.OrderByDescending(s => s.FechaRegistro).ToList();
            return View(lista);
        }
    }
}