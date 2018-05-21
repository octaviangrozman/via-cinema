﻿/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
        static HttpClient client = new HttpClient();

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

            return View(new PaymentViewModel(context, screeningId, seatNo, seat.Price));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Pay(Payment payment)
        {
            bool isCardNumberValid = await ValidateCreditCardAsync(payment.CardNumber);
            if (!isCardNumberValid) ModelState.AddModelError("CardNumber", "Card number is invalid");

            if (!ModelState.IsValid || !isCardNumberValid)
            {
                return View("Index", new PaymentViewModel(context, payment.ScreeningId, payment.SeatNo, payment.Amount));
            }

            context.Payments.Add(payment);
            Screening screening = context.Screenings.SingleOrDefault(s => s.Id == payment.ScreeningId);
            Seat seatInDb = null;
            if (screening != null)
            {
                seatInDb = context.Seats.SingleOrDefault(s => s.SeatNo == payment.SeatNo && s.RoomNo == screening.RoomNo);
            }
            if (seatInDb != null)
            {
                seatInDb.Occupied = true;
            }
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost, NonAction]
        public async Task<bool> ValidateCreditCardAsync(string creditCardNumber)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("http://localhost:60894/api/creditcard/validate", new { creditCardNumber });
            response.EnsureSuccessStatusCode();

            bool isValid = await response.Content.ReadAsAsync<bool>();
            return isValid;
        }
    }
}*/