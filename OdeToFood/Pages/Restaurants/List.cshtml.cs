using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }

        public string Message { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }
        public ILogger<ListModel> Logger { get; }
        private readonly IConfiguration config;
        private readonly IRestaurantData restaurant;
        public ListModel(IConfiguration config,  IRestaurantData restaurant, ILogger<ListModel> logger)
        {
            this.config = config;
            this.restaurant = restaurant;
            Logger = logger;
        }
        public void OnGet()
        {
            Logger.LogInformation("Executing ListModel");
            Restaurants = restaurant.GetRestaurantsByName(SearchTerm);
        }
    }
}