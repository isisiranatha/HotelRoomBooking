using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelRoomBooking.Model
{
    public class Guest
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(255)]
        public string SurName { get; set; }
        [Required]
        [StringLength(255)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Field can't be empty")]
        [StringLength(255)]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        [EmailAddress]
        public string Email { get; set; }
       
    }
}
