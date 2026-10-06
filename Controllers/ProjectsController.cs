using Microsoft.AspNetCore.Mvc;
using COMP2139_ICE.Models;
using COMP2139_ICE.Data;
using System.Linq;
using System;

namespace COMP2139_ICE.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly ApplicationDbContext _context;

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

        // GET: /Projects/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null) return NotFound();
            var project = _context.Projects.FirstOrDefault(p => p.ProjectId == id);
            if (project == null) return NotFound();
            return View(project);
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
                // Converter datas para UTC (obrigatório para PostgreSQL timestamp with time zone)
                project.StartDate = DateTime.SpecifyKind(project.StartDate, DateTimeKind.Utc);
                project.EndDate = DateTime.SpecifyKind(project.EndDate, DateTimeKind.Utc);

                _context.Projects.Add(project);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(project);
        }

        // GET: /Projects/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();
            var project = _context.Projects.FirstOrDefault(p => p.ProjectId == id);
            if (project == null) return NotFound();
            return View(project);
        }

        // POST: /Projects/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Project project)
        {
            if (id != project.ProjectId) return NotFound();

            if (ModelState.IsValid)
            {
                // Converter datas para UTC (obrigatório para PostgreSQL timestamp with time zone)
                project.StartDate = DateTime.SpecifyKind(project.StartDate, DateTimeKind.Utc);
                project.EndDate = DateTime.SpecifyKind(project.EndDate, DateTimeKind.Utc);

                _context.Projects.Update(project);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(project);
        }

        // GET: /Projects/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            var project = _context.Projects.FirstOrDefault(p => p.ProjectId == id);
            if (project == null) return NotFound();
            return View(project);
        }

        // POST: /Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var project = _context.Projects.Find(id);
            if (project == null) return NotFound();

            _context.Projects.Remove(project);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}