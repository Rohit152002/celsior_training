using EventBooking.Context;
using EventBooking.Interface;
using EventBooking.Models;
using Microsoft.EntityFrameworkCore;

namespace EventBooking.Repository
{
    public class EventRepository : IRepository<int, Event>
    {
        private readonly EventContext _context;

        public EventRepository(EventContext context)
        {
            _context = context;
        }
        public async Task<Event> Add(Event entity)
        {

            try
            {
                _context.Events.Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Event> Delete(int key)
        {
            try
            {
                var events = await Get(key);
                if (events != null)
                {
                    _context.Events.Remove(events);
                    await _context.SaveChangesAsync();
                    return events;
                }
                throw new Exception("Delete error");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Event> Get(int key)
        {
            try
            {
                var events = await _context.Events.FirstOrDefaultAsync(c => c.EventId == key);
                return events;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Event>> GetAll()
        {
            try
            {
                var events = await _context.Events.ToListAsync();
                if (events.Count == 0)
                {
                    throw new Exception("There is no user");
                }
                return events;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Event> Update(int key, Event entity)
        {
            try
            {
                var user = await Get(key);
                if (user != null)
                {
                    user.EventName = entity.EventName;
                    user.EventDate = entity.EventDate;

                    await _context.SaveChangesAsync();
                    return user;
                }
                //throw new NotFoundException("Customer for delete");
                throw new Exception("message");
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
