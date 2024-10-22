using AutoMapper;
using EventBooking.Interface;
using EventBooking.Models;
using EventBooking.Models.DTO;
using EventBooking.Repository;

namespace EventBooking.Services
{
    public class EventServices:IEventService
    {
        private readonly IRepository<int,Event> _repository;
        private readonly IMapper _mapper;

        public EventServices(IRepository<int,Event> repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Event>> GetAllEventList()
        {
            try
            {
                var events = await _repository.GetAll();
                return events;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Event> CreateNewEvent(EventDTO n_event)
        {
            try
            {
                var eventData= _mapper.Map<Event>(n_event);
                var newEvent = await _repository.Add(eventData);
                return newEvent;
            }
        catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
