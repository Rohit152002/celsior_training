using AutoMapper;
using EventBooking.Models;
using EventBooking.Models.DTO;

namespace EventBooking.Mapper
{
    public class BookingProfile:Profile
    {
        public BookingProfile()
        {
            CreateMap<Booking, BookingDTO>();
            CreateMap<BookingDTO, Booking>();
        }
    }
}
