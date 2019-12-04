using OdeToFood.Core;
using OdeToFood.Models;
using System.Collections.Generic;
using System.Text;
namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        int GetCountOfRestaurants();
        Restaurant Delete(int id);
        Restaurant Add(Restaurant newRestaurant);
        int Commit();
        Restaurant Update(Restaurant updatedRestaurant);
        Restaurant Get(int Id);
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        List<Reservation> GetReservations(int restaurantId);
    }
}
