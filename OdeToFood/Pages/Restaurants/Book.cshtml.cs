using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;
using OdeToFood.Models;

namespace OdeToFood.Pages.Restaurants
{
    public class BookModel : PageModel
    {
        private readonly IRestaurantData restaurants;
        private readonly IReservationData reservations;

        public Restaurant Restaurant { get; set; }
        [BindProperty]
        public Reservation Reservation { get; set; }
        

        public BookModel(IRestaurantData restaurants, IReservationData reservations)
        {
            this.restaurants = restaurants;
            this.reservations = reservations;
        }
        public IActionResult OnGet(int restaurantId)
        {
            Reservation = new Reservation();
            Restaurant = restaurants.Get(restaurantId);
            if (Restaurant == null || Reservation==null)
                return RedirectToPage("./NotFound");
            return Page();
        }
        public IActionResult OnPost(int restaurantId)
        {
            //book here 
            if (!ModelState.IsValid)
                return Page();
            if (Reservation != null)
            {
                reservations.Add(Reservation, restaurantId);
                reservations.Commit();
            }
            return RedirectToPage("./List");
        }
    }
}