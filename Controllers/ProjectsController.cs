using Microsoft.AspNetCore.Mvc;
using COMP2139_ICE.Models;
using COMP2139_ICE.Data;
using System.Linq;

namespace COMP2139_ICE.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProjectsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var projects = _context.Projects.ToList();
            return View(projects);
        }

        public IActionResult Details(int? id)
        {
            if (id == null) return NotFound();
            var project = _context.Projects.FirstOrDefault(p => p.ProjectId == id);
            if (project == null) return NotFound();
            return View(project);
        }

        public IActionResult Create()
        {
            return View();
        }

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

        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();
            var project = _context.Projects.FirstOrDefault(p => p.ProjectId == id);
            if (project == null) return NotFound();
            return View(project);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Project project)
        {
            if (id != project.ProjectId) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Projects.Update(project);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(project);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            var project = _context.Projects.FirstOrDefault(p => p.ProjectId == id);
            if (project == null) return NotFound();
            return View(project);
        }

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
