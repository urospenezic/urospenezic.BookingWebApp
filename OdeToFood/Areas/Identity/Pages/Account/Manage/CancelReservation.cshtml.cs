using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Models;

namespace OdeToFood.Areas.Identity.Pages.Account.Manage
{
    public class CancelReservationModel : PageModel
    {
        private readonly IReservationData reservationData;
        public Reservation Reservation { get; set; }

        public CancelReservationModel(IReservationData reservationData)
        {
            this.reservationData = reservationData;
        }
        public IActionResult OnGet(int reservationId)
        {
            Reservation = reservationData.GetReservation(reservationId);
            if (Reservation == null)
                return RedirectToPage("./Index");
            return Page();
        }
        public IActionResult OnPost(int reservationId)
        {
            var reservation= reservationData.Cancel(reservationId);
            reservationData.Commit();
            return RedirectToPage("./Index");
        }
    }
}