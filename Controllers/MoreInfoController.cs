﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using viacinema.Data;
using viacinema.Models;
using viacinema.ViewModels;

namespace viacinema.Controllers
{
    [Route("moreinfo")]
    public class MoreInfoController : Controller
    {
        public DataContext context;

        public MoreInfoController(DataContext _context)
        {
            this.context = _context;
        }

        [Route("{id}")]
        public IActionResult Index(int id)
        {
            var movie = context.Movies
                .Single(m => m.Id == id);
            var screenings = context.Screenings
                .Where(s => s.MovieId == id)
                .OrderByDescending(s => s.StartTime)
                .ToList();

            List<SeatScreening> seatScreenings = new List<SeatScreening>();
            foreach (var screening in screenings)
            {
                seatScreenings.AddRange(context.SeatScreeningMediator.Where(s => s.ScreeningId == screening.Id).ToList());
            }

            return View(new MoreInfoViewModel(movie, screenings, seatScreenings));
        }
    }
}
