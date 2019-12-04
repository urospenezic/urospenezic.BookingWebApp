using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Models
{
    public interface IReservationData
    {
        Reservation Add(Reservation reservation, int restaurantId);
        Reservation Cancel(int reservationId);
        Reservation GetReservation(int reservationId);
        int Commit();
        List<Reservation> GetAllReservationsForUser(string email);
    }
}
