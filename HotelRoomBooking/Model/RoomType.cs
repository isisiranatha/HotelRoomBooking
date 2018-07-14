﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelRoomBooking.Model
{
    public class RoomType
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string RoomTypeName { get; set; }
        public int PricePerDay { get; set; }

    }
}
