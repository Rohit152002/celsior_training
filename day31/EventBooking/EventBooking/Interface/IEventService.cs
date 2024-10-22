﻿using EventBooking.Models;
using EventBooking.Models.DTO;

namespace EventBooking.Interface
{
    public interface IEventService
    {
        public  Task<IEnumerable<Event>> GetAllEventList();
        public Task<Event> CreateNewEvent(EventDTO n_event);

    }
}
