using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;
using OdeToFood.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace OdeToFood.Models
{
    public class SqlReservationData : IReservationData
    {
        private readonly ApplicationDbContext context;

        public SqlReservationData(ApplicationDbContext context)
        {
            this.context = context;
        }
        public Reservation Add(Reservation reservation, int restaurantId)
        {
            var data = context.Restaurants.Include(b => b.Reservations).FirstOrDefault(r => r.Id == restaurantId);
            data.Reservations.Add(reservation);
            return reservation;
        }

        public Reservation Cancel(int reservationId)
        {
            var reservation = GetReservation(reservationId);
            if (reservation != null)
                context.Reservations.Remove(reservation);
            return reservation;
        }

        public int Commit()
        {
           return context.SaveChanges();
        }

        public List<Reservation> GetAllReservationsForUser(string email)
        {
            return context.Reservations.Where(r => r.Name == email).ToList();
        }

        public Reservation GetReservation(int reservationId)
        {
            return context.Reservations.Find(reservationId);
        }
    }
}
