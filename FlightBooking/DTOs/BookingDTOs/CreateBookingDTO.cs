using FlightBooking.DTOs.PassengerDTOs;

namespace FlightBooking.DTOs.BookingDTOs
{
    public class CreateBookingDTO
    {
        public int FlightID { get; set; }
        public List<CreatePassengerDTO> Passengers { get; set; } = new();
        public string ContactName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        public string PnrNumber { get; set; }
    }
}
