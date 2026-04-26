using FlightBooking.DTOs.BookingDTOs;
using FlightBooking.Services.BookingServices;
using FlightBooking.Services.FlightServices;
using Microsoft.AspNetCore.Mvc;

namespace FlightBooking.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BookingController : Controller
    {
        private readonly IFlightService _flightService;
        private readonly IBookingService _bookingService;
        public BookingController(IFlightService flightService, IBookingService bookingService)
        {
            _flightService = flightService;
            _bookingService = bookingService;
            
        }

        [HttpGet]
        public async Task<IActionResult> CreateBooking(int id)
        {
            var value = await _flightService.GetFlightByIdAsync(id);
            ViewBag.FlightNumber = value.FlightNumber;            
            ViewBag.AirlineCode = value.AirlineCode;
            ViewBag.DepartureAirportCode = value.DepartureAirportCode;
            ViewBag.DepartureAirportName = value.DepartureAirportName;
            ViewBag.ArrivalAirportCode = value.ArrivalAirportCode;
            ViewBag.ArrivalAirportName = value.ArrivalAirportName;
            ViewBag.DepartureTime = value.DepartureTime;
            ViewBag.ArrivalTime = value.ArrivalTime;
            ViewBag.Status = value.Status;
            ViewBag.FlightID = id;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking(int id, CreateBookingDTO createBookingDTO)
        {
            createBookingDTO.FlightID = id;

            await _bookingService.CreateBookingAsync(createBookingDTO);
            return RedirectToAction("Index", "Booking", new { area = "Admin" });
        }

        public IActionResult BookingList()
        {
            return View();
        }
    }
}
