using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using viacinema.Data;
using viacinema.ViewModels;

namespace viacinema.Controllers
{
    [Route("MoreInfo")]
    public class MoreInfoController : Controller
    {
        public DataContext context;

        public MoreInfoController(DataContext _context)
        {
            this.context = _context;
        }

        [Route("{id}")]
        public IActionResult MoreInfo(int id)
        {
            int id_ = int.Parse(this.RouteData.Values["id"].ToString());
            var movie = context.Movies
                .Single(m => m.Id == id);
            var screenings = context.Screenings
                .Where(s => s.MovieId == movie.Id)
                .OrderByDescending(s => s.StartTime)
                .ToList();

            return View(new MoreInfoViewModel(movie, screenings));
        }
    }
}
