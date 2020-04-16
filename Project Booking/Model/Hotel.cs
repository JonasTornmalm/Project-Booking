using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Booking.Model
{
    public class Hotel
    {
        [Key]
        public string Id { get; set; }
        public string HotelName { get; set; }
        public string City { get; set; }
        public string HotelInfo { get; set; }
        public int NumberOfRooms { get; set; }
        public string HotelPictureBig { get; set; }
        public string HotelPictureSmallOne { get; set; }
        public string HotelPictureSmallTwo { get; set; }
        public string HotelPictureSmallThree { get; set; }
        public string HotelStars { get; set; }
        public double RoomPrice { get; set; }

    }
}
