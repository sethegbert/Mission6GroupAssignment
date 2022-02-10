using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission6GroupAssignment.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission6GroupAssignment.Controllers
{
    public class HomeController : Controller
    {

        private QuadrantContext quadrantContext { get; set; }
        public HomeController(QuadrantContext someName)
        {
            quadrantContext = someName;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult NewForm()  //new form
        {
            ViewBag.Categories = quadrantContext.Categories.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult NewForm(Quadrant qd) //new form
        {
            if (ModelState.IsValid)
            {
                quadrantContext.Add(qd);
                quadrantContext.SaveChanges();

                return View("Confirmation", qd);
            }
            else
            {
                ViewBag.Categories = quadrantContext.Categories.ToList();

                return View(qd);
            }
        }

        [HttpGet]
        public IActionResult Edit(int entryid)
        {
            ViewBag.Categories = quadrantContext.Categories.ToList();

            var EditTask = quadrantContext.Responses.Single(x => x.EntryId == entryid);

            return View("NewForm", EditTask);
        }

        [HttpPost]
        public IActionResult Edit(Quadrant qd)
        {
            quadrantContext.Update(qd);
            quadrantContext.SaveChanges();

            return RedirectToAction("Quadrants");
        }

        //delete get
        [HttpGet]
        public IActionResult Delete(int EntryId)
        {
            var task = quadrantContext.Responses.Single(x => x.EntryId == EntryId);

            return View(task);
        }

        //delete post
        [HttpPost]
        public IActionResult Delete(Quadrant qd)
        {
            quadrantContext.Responses.Remove(qd);
            quadrantContext.SaveChanges();

            return RedirectToAction("Quadrants");
        }

        public IActionResult Quadrants()
        {
            var tasks = quadrantContext.Responses
                .Include(x => x.Category)
                .OrderBy(x => x.DueDate)
                .Where(x => x.Completed == false)
                .ToList();
            return View(tasks);
        }
    }
}
