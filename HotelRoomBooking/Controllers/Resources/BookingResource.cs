using HotelRoomBooking.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelRoomBooking.Controllers.Resources
{
    public class BookingResource
    {
       
        public int ID { get; set; }
        public int GuestID { get; set; }
        public Guest Guest { get; set; }
        public int RoomTypeID { get; set; }
        public RoomType RoomType { get; set; }
        public Nullable<DateTime> StartDate { get; set; }
        public Nullable<DateTime> EndDate { get; set; }
        public ICollection<GuestResource> Guests { get; set; }
    }
}
