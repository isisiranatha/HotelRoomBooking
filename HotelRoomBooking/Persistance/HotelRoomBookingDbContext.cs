using HotelRoomBooking.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelRoomBooking.Persistance
{
    public class HotelRoomBookingDbContext : DbContext
    {
        public HotelRoomBookingDbContext(DbContextOptions<HotelRoomBookingDbContext> options)
            :base(options)
        {

        }

        public DbSet<Booking> Booking { get; set; }
    }
}
