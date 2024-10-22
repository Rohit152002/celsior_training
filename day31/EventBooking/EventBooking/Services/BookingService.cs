using AutoMapper;
using EventBooking.Interface;
using EventBooking.Models;
using EventBooking.Models.DTO;

namespace EventBooking.Services
{
    public class BookingService:IBookService
    {
        private readonly IRepository<int,Booking> _bookingRepository;
        private readonly IMapper _mapper;
        public BookingService(IRepository<int,Booking> bookingRepository,IMapper mapper)
        {
            _bookingRepository = bookingRepository;
            _mapper = mapper;
        }
        public async Task<Booking> CreateNewBooking(BookingDTO bookingDTO)
        {
            try
            {

            Booking booking= _mapper.Map<Booking>(bookingDTO);
            var books = await _bookingRepository.Add(booking);
            return books;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Booking>> GetAllBooking()
        {
            try
            {
                var bookings = await _bookingRepository.GetAll();
                return bookings;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

       
    }
}
