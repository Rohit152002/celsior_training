using EventBooking.Models;
using EventBooking.Models.DTO;

namespace EventBooking.Interface
{
    public interface IBookService
    {
        public Task<Booking> CreateNewBooking(BookingDTO bookingDTO);
        public Task<IEnumerable<Booking>> GetAllBooking();


    }
}
