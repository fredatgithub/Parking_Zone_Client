﻿using ParkingZoneApp.ViewModels.ReservationVMs;
using System.ComponentModel.DataAnnotations;

namespace ParkingZoneApp.Models
{
    public class Reservation
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public int Duration { get; set; }

        [Required]
        public int ParkingSlotId { get; set; }

        [Required]
        public virtual ParkingSlot ParkingSlot { get; set; }

        [Required]
        public string VehicleNumber { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public virtual ApplicationUser User { get; set; }
    }
}
