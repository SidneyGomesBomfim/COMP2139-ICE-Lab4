using Microsoft.AspNetCore.Mvc;
using COMP2139_ICE.Models;
using System.Collections.Generic;

namespace COMP2139_ICE.Controllers
{
    public class ProjectsController : Controller
    {
        // Lista estática para simular banco de dados neste Lab
        private static List<Project> _projects = new List<Project>();

        // GET: /Projects/
        public IActionResult Index()
        {
            return View(_projects);
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
                project.ProjectId = _projects.Count + 1;
                _projects.Add(project);
                return RedirectToAction(nameof(Index));
            }
            return View(project);
        }

        // GET: /Projects/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null) return NotFound();
            
            var project = _projects.Find(p => p.ProjectId == id);
            if (project == null) return NotFound();

            return View(project);
        }
    }
}