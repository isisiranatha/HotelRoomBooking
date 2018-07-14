using AutoMapper;
using HotelRoomBooking.Controllers.Resources;
using HotelRoomBooking.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelRoomBooking.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Booking, BookingResource>();
            CreateMap<Guest, GuestResource>();
            CreateMap<RoomType, RoomTypeResource>();           
        }
    }
}
