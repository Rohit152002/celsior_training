using Microsoft.EntityFrameworkCore;
using Oct122024.Models;

namespace Oct122024.Context
{
    public class EventContext:DbContext
    {
        public EventContext(DbContextOptions<EventContext> options) : base(options) { }
        public DbSet<Event> Events { get; set; }
        public DbSet<User> Users { get; set; }
        //public DbSet<Bookings> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id)
                .HasName("PK_User");

            //modelBuilder.Entity<Bookings>()
            //    .HasOne(b => b.User)
            //    .WithMany(u => u.Bookings)
            //    .HasForeignKey(b => b.UserId)
            //    .HasConstraintName("FK_USER_BOOKINGS");

            //modelBuilder.Entity<Bookings>()
            //    .HasOne(b=>b.Event


            modelBuilder.Entity<Event>()
                .HasKey(e => e.Id)
                .HasName("PK_Event_Key");

        }
    }
}
