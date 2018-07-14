using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelRoomBooking.Model
{
    public class Booking
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Guest")]
        public int GuestID { get; set; }
        public Guest Guest { get; set; }
        [ForeignKey("RoomType")]
        public int RoomTypeID { get; set; }
        public RoomType RoomType { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Start date)")]       
        public Nullable<DateTime> StartDate { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "End date)")]
        public Nullable<DateTime> EndDate { get; set; }
        public ICollection<Guest> Guests { get; set; }
        

    }
}
