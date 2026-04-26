using FlightBooking.Context;
using FlightBooking.DTOs.BookingDTOs;
using FlightBooking.Entities;
using Microsoft.EntityFrameworkCore;

namespace FlightBooking.Services.BookingServices
{
    public class BookingService : IBookingService
    {
        private readonly AppDbContext _context;

        public BookingService(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateBookingAsync(CreateBookingDTO dto)
        {
            var flight = await _context.Flights.FirstOrDefaultAsync(x => x.FlightID == dto.FlightID);

            //if (flight == null)
            //    throw new Exception("Uçuş bulunamadı.");

            var passengerCount = dto.Passengers.Count;

            //if (flight.AvailableSeats < passengerCount)
            //    throw new Exception("Yeterli koltuk yok.");

            var passengers = dto.Passengers.Select(x => new Passenger
            {
                Name = x.Name,
                Surname = x.Surname,
                BirthDate = DateTime.SpecifyKind(x.BirthDate, DateTimeKind.Utc),
                Gender = x.Gender,
                PassengerType = x.PassengerType
            }).ToList();

            //var totalPrice = passengerCount * flight.BasePrice;

            var booking = new Booking
            {
                FlightID = dto.FlightID,
                Passengers = passengers,

                ContactName = dto.ContactName,
                ContactEmail = dto.ContactEmail,
                ContactPhone = dto.ContactPhone,

                //TotalPrice = totalPrice,
                BookingDate = DateTime.UtcNow,
                Status = "Confirmed"
            };

            await _context.Bookings.AddAsync(booking);

            //flight.AvailableSeats -= passengerCount;

            await _context.SaveChangesAsync();
        }
    }
}