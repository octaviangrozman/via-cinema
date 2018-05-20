using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using viacinema.Data;
using viacinema.Models;
using viacinema.ViewModels;

namespace via_cinema.Controllers
{
    [Route("payment")]
    public class PaymentController : Controller
    {
        public DataContext context;

        public PaymentController(DataContext _context)
        {
            context = _context;
        }

        public IActionResult Index()
        {
            int.TryParse(Request.Query["screening"], out int screeningId);
            int.TryParse(Request.Query["seat"], out int seatNo);

            if (screeningId == 0 || seatNo == 0) throw new ArgumentNullException("screening or seat  are null");

            Screening screening = context.Screenings.SingleOrDefault(s => s.Id == screeningId);
            Seat seat = context.Seats.SingleOrDefault(s => s.SeatNo == seatNo && s.RoomNo == screening.RoomNo);

            if (screening == null || seat == null) throw new NullReferenceException("screening or seat are not in database");

            return View(new PaymentViewModel(screeningId, seatNo, seat.Price));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Pay(Payment payment)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", new PaymentViewModel(payment.ScreeningId, payment.SeatNo, payment.Amount));
            }

            context.Payments.Add(payment);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}