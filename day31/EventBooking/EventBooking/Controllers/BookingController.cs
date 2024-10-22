using EventBooking.Interface;
using EventBooking.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IEventService _eventService;
        private readonly IUserService _userService;
        public BookingController(IBookService bookService,IEventService eventService,IUserService userService)
        {
            _bookService=bookService;
            _eventService = eventService;
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> PostBooking(BookingDTO bookingDTO)
        {
            try
            {
                var booking = await _bookService.CreateNewBooking(bookingDTO);
                return Ok(booking);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetBooking()
        {
            try
            {
                var bookings= await _bookService.GetAllBooking();
                var events = await _eventService.GetAllEventList();
                var users= await _userService.GetAllUser();

                var bookingDetails = (from b in bookings
                                      join e in events on b.EventId equals e.EventId
                                      join u in users on b.UserId equals u.UserId
                                      select new
                                      {
                                          BookingId = b.BookingId,
                                          EventName = e.EventName,
                                          UserName = u.UserName
                                      });
                return Ok(bookingDetails);
            }catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,ex.Message);
            }
        }
    }
}
