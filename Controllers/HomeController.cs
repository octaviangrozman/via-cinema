using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using via_cinema.Models;
using viacinema.Data;

namespace via_cinema.Controllers
{
    public class HomeController : Controller
    {
        public DataContext context;

        public HomeController(DataContext _context)
        {
            context = _context;
        }

        public IActionResult Index()
        {
            var movies = context.Movies
                .OrderByDescending(c => c.ReleaseDate)
                .ToList();

            return View(movies);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
