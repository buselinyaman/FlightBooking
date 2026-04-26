using AutoMapper;
using FlightBooking.DTOs.FlightDTOs;
using FlightBooking.DTOs.BookingDTOs;
using FlightBooking.Entities;

namespace FlightBooking.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Flight, CreateFlightDTO>().ReverseMap();
            CreateMap<Flight, GetFlightByIdDTO>().ReverseMap();
            CreateMap<Flight, UpdateFlightDTO>().ReverseMap();
            CreateMap<Flight, ResultFlightDTO>().ReverseMap();
            CreateMap<Booking, CreateBookingDTO>().ReverseMap();
        }
    }
}
