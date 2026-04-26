namespace FlightBooking.Entities
{
    public class Booking
    {
        public int BookingID { get; set; }

        public int FlightID { get; set; }
        public Flight Flight { get; set; }

        public List<Passenger> Passengers { get; set; } = new();

        public string ContactName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }

        public decimal TotalPrice { get; set; }
        public DateTime BookingDate { get; set; }

        public string Status { get; set; }
    }
}
 