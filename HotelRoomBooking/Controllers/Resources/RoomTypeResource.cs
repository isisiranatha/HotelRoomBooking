using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelRoomBooking.Controllers.Resources
{
    public class RoomTypeResource
    {
        public int ID { get; set; }
        public string RoomTypeName { get; set; }
        public int PricePerDay { get; set; }
    }
}
