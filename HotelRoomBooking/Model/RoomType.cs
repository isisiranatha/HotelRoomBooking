using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelRoomBooking.Model
{
    [Table("RoomTypes")]
    public class RoomType
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(255)]
        public string RoomTypeName { get; set; }
        public int PricePerDay { get; set; }

    }
}
