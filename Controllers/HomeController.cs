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

        public IActionResult Quadrants()
        {
            var tasks = quadrantContext.Responses.Include(x => x.Category).ToList();
            return View(tasks);
        }
    }
}
