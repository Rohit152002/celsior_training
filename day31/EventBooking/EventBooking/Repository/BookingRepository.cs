using EventBooking.Context;
using EventBooking.Interface;
using EventBooking.Models;
using Microsoft.EntityFrameworkCore;

namespace EventBooking.Repository
{
    public class BookingRepository:IRepository<int,Booking>
    {
        private readonly EventContext _context;

        public BookingRepository(EventContext context)
        {
            _context = context;
        }

        public async Task<Booking> Add(Booking entity)
        {
            try
            {
                _context.Bookings.Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Booking> Delete(int key)
        {
            try
            {
                var booked = await Get(key);
                if (booked != null)
                {
                    _context.Bookings.Remove(booked);
                    await _context.SaveChangesAsync();
                    return booked;
                }
                throw new Exception("Delete error");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Booking> Get(int key)
        {
            try
            {
                var user = await _context.Bookings.FirstOrDefaultAsync(c => c.BookingId == key);
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Booking>> GetAll()
        {
            try
            {
                var bookings = await _context.Bookings.ToListAsync();
                if (bookings.Count == 0)
                {
                    throw new Exception("There is no user");
                }
                return bookings;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async  Task<Booking> Update(int key, Booking entity)
        {
            var booked = await Get(key);
            if (booked != null)
            {
                return booked;
            }
            //throw new NotFoundException("Customer for delete");
            throw new Exception("message");
        }
    }
}
