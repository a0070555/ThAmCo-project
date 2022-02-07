using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThAmCo.Venues.Data;

namespace ThAmCo.Events.Models
{
    public class EventsContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<Staff> Staff { get; set; }

        public DbSet<GuestBooking> GuestBookings { get; set; }

        public DbSet<Staffing> Staffing { get; set; }

        public EventsContext(DbContextOptions<EventsContext> options) : base(options)
        {
        }

        private readonly IHostEnvironment _hostEnv;

        public EventsContext(DbContextOptions<EventsContext> options,
                       IHostEnvironment env) : base(options)
        {
            _hostEnv = env;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<GuestBooking>()
                .HasKey(a => new { a.CustomerId, a.EventId });

            builder.Entity<Staffing>()
                .HasKey(a => new { a.EventId, a.StaffId });
        }

        public DbSet<ThAmCo.Venues.Data.VenueDto> VenueDto { get; set; }
    }
}



