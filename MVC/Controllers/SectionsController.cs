#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccess.Contexts;
using DataAccess.Entities;
using Business.Services;
using Business.Models;

//Generated from Custom Template.
namespace MVC.Controllers
{
    public class SectionsController : Controller
    {
        // TODO: Add service injections here
        private readonly ISectionService _sectionService;

        public SectionsController(ISectionService sectionService)
        {
            _sectionService = sectionService;
        }

        // GET: Sections
        public IActionResult Index()
        {
            List<SectionModel> sectionList = _sectionService.Query().ToList();
            return View(sectionList);
        }

        // GET: Sections/Details/5
        public IActionResult Details(int id)
        {
            SectionModel section = _sectionService.Query().SingleOrDefault(s => s.Id == id); ; // TODO: Add get item service logic here
            if (section == null)
            {
                return NotFound();
            }
            return View(section);
        }

        // GET: Sections/Create
        public IActionResult Create()
        {
            // TODO: Add get related items service logic here to set ViewData if necessary
            return View();
        }

        // POST: Sections/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SectionModel section)
        {
            if (ModelState.IsValid)
            {
                var result = _sectionService.Add(section);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", result.Message);
            }
            return View(section);
        }


        // GET: Sections/Edit/5
        public IActionResult Edit(int id)
        {
            SectionModel section = _sectionService.Query().SingleOrDefault(s => s.Id == id);
            if (section == null)
            {
                return NotFound();
            }
            return View(section);
        }

        // POST: Sections/Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(SectionModel section)
        {
            if (ModelState.IsValid)
            {
                var result = _sectionService.Update(section);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Details), new { id = section.Id });
                }
                ModelState.AddModelError("", result.Message);
            }
            return View(section);
        }

        // GET: Sections/Delete/5
        public IActionResult Delete(int id)
        {
            SectionModel section = _sectionService.Query().SingleOrDefault(s => s.Id == id);
            if (section == null)
            {
                return NotFound();
            }
            return View(section);
        }

        // POST: Sections/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var result = _sectionService.Delete(id);
            TempData["Message"] = result.Message;
            return RedirectToAction(nameof(Index));
        }

    }
}
