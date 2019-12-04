using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;
using OdeToFood.Models;

namespace OdeToFood.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly ApplicationDbContext db;
        public SqlRestaurantData(ApplicationDbContext db)
        {
            this.db = db;
        }
        public Restaurant Add(Restaurant newRestaurant)
        {
            db.Add(newRestaurant);
            return newRestaurant;
        }

        public int Commit()
        {
          return db.SaveChanges();
        }

        public Restaurant Delete(int id)
        {
            var restaurant = Get(id);
            if (restaurant != null)
                db.Restaurants.Remove(restaurant);
            return restaurant;
        }

        public Restaurant Get(int Id)
        {
            return db.Restaurants.Find(Id);
        }

        public int GetCountOfRestaurants()
        {
            return db.Restaurants.Count();
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            var query = from r in db.Restaurants
                        where r.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby r.Name
                        select r;
            return query;
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var entity = db.Update(updatedRestaurant);
            return updatedRestaurant;
        }
        public List<Reservation> GetReservations(int restaurantId)
        {
            return Get(restaurantId).Reservations.ToList();
        }
    }
}
