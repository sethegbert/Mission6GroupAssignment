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

        //add task get
        [HttpGet]
        public IActionResult AddTask()
        {
            ViewBag.Categories = quadrantContext.Categories.ToList();

            return View();
        }

        //add task post
        [HttpPost]
        public IActionResult AddTask(Quadrant qd)
        {
            ViewBag.Categories = quadrantContext.Categories.ToList();

            if (ModelState.IsValid)
            {
                quadrantContext.Add(qd);
                quadrantContext.SaveChanges();

                return View(qd);
            }
            else
            {
                ViewBag.Categories = quadrantContext.Categories.ToList();

                return View();
            }
        }

        //edit get
        [HttpGet]
        public IActionResult Edit (int EntryId)
        {
            ViewBag.Categories = quadrantContext.Categories.ToList();

            var EditTask = quadrantContext.Responses.Single(x => x.EntryId == EntryId);

            return View("AddTask", EditTask);
        }

        //edit post
        [HttpPost]
        public IActionResult Edit(Quadrant qd)
        {
            quadrantContext.Update(qd);
            quadrantContext.SaveChanges();

            return RedirectToAction("Index"); //will need to update to view we want 
        }

        //delete get
        [HttpGet]
        public IActionResult Delete (int entryid)
        {
            var DeleteTask = quadrantContext.Responses.Single(x => x.EntryId == entryid);

            return View(DeleteTask);
        }

        //delete post
        [HttpPost]
        public IActionResult Delete (Quadrant qd)
        {
            quadrantContext.Responses.Remove(qd);
            quadrantContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
