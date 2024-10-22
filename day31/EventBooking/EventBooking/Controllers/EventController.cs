using EventBooking.Interface;
using EventBooking.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;
      private readonly IUserService _userService;

        public EventController(IEventService eventService, IUserService userService)
        {
            _eventService = eventService;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEvents()
        {
            try
            {
                var events = await _eventService.GetAllEventList();
                return Ok(events);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
        [HttpGet]
        [Route("/eventName")]
        public async Task<IActionResult> getEventNames()
        {
            try
            {
                var events = await _eventService.GetAllEventList();
                //linq query to fetch to only event names
                var eventsnames = (from enames in events
                                   select enames.EventName).ToList();
                return Ok(eventsnames);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
        [HttpGet]
        [Route("/getEventWithUser")]
        public async Task<IActionResult> getEventWithUser()
        {
            try
            {
                var events = await _eventService.GetAllEventList();
                var employees = await _userService.GetAllUser();
                //select UserName, EventName, Email from Users cross join Events

                //linq query to fetch to cross join 
                var details = from u in employees
                              from e in events
                              select new
                              {
                                  UserName = u.UserName,
                                  EventName = e.EventName,
                                  Email = u.Email
                              };

                return Ok(details);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> CreateEvent(EventDTO eventDTO)
        {
            try
            {

                var user = await _eventService.CreateNewEvent(eventDTO);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
