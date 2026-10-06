using Microsoft.AspNetCore.Mvc;
using COMP2139_ICE.Models;
using COMP2139_ICE.Data;
using System.Linq;

namespace COMP2139_ICE.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly ApplicationDbContext _context;

        // Injeção de Dependência do Contexto da Base de Dados
        public ProjectsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Projects/
        public IActionResult Index()
        {
            var projects = _context.Projects.ToList();
            return View(projects);
        }

        // GET: /Projects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Projects/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Project project)
        {
            if (ModelState.IsValid)
            {
                _context.Projects.Add(project);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(project);
        }

        // GET: /Projects/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null) return NotFound();
            
            var project = _context.Projects.FirstOrDefault(p => p.ProjectId == id);
            if (project == null) return NotFound();

            return View(project);
        }
    }
}
