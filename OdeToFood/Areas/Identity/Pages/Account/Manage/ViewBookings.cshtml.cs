using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Models;

namespace OdeToFood.Areas.Identity.Pages.Account.Manage
{
    public class ViewBookingsModel : PageModel
    {
        private readonly IReservationData reservationData;
        public List<Reservation> Reservations { get; private set; } = new List<Reservation>();
        public int Number { get; set; } = 1;
        public ViewBookingsModel(IReservationData reservationData)
        {
            this.reservationData = reservationData;
        }
        public void OnGet()
        {
            if(Reservations!=null)
            Reservations = reservationData.GetAllReservationsForUser(HttpContext.User.Identity.Name);
        }
    }
}