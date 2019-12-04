using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; }
        [Required]
        public DateTime StartTime { get; set; } = DateTime.Today;
        [Required]
        public DateTime EndTIme { get; set; } = DateTime.Today;
    }
}
