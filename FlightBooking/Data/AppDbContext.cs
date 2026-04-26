using FlightBooking.Entities;
using Microsoft.EntityFrameworkCore;

namespace FlightBooking.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Flight> Flights { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Booking>(booking =>
            {
                booking.HasKey(b => b.BookingID);

                booking.OwnsMany(b => b.Passengers, passenger =>
                {
                    passenger.ToTable("BookingPassengers");

                    passenger.WithOwner().HasForeignKey("BookingID");

                    passenger.Property<int>("Id");
                    passenger.HasKey("Id");

                    passenger.Property(p => p.Name).IsRequired();
                    passenger.Property(p => p.Surname).IsRequired();
                    passenger.Property(p => p.BirthDate).IsRequired();
                    passenger.Property(p => p.Gender).IsRequired();
                    passenger.Property(p => p.PassengerType).IsRequired();
                });
            });
        }
    }
}

