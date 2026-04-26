using FlightBooking.DTOs.FlightDTOs;
using FlightBooking.Services.FlightServices;
using Microsoft.AspNetCore.Mvc;

namespace FlightBooking.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FlightsController : Controller
    {
        private readonly IFlightService _flightService;

        public FlightsController(IFlightService flightService)
        {
            _flightService = flightService;

        }
        public async Task<IActionResult> FlightList()
        {
            var value = await _flightService.GetAllFlightsAsync();
            return View(value);
        }

        [HttpGet]
        public IActionResult CreateFlight()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFlight(CreateFlightDTO createFlightDTO)
        {
            createFlightDTO.DepartureTime = DateTime.SpecifyKind(createFlightDTO.DepartureTime, DateTimeKind.Local).ToUniversalTime();
            createFlightDTO.ArrivalTime = DateTime.SpecifyKind(createFlightDTO.ArrivalTime, DateTimeKind.Local).ToUniversalTime();
            await _flightService.CreateFlightAsync(createFlightDTO);
            return RedirectToAction("FlightList");
        }

        public async Task<IActionResult> FlightDetail(int id) 
        {
            return View();
        
        }

    }
}
