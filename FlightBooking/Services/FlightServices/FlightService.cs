using AutoMapper;
using FlightBooking.Context;
using FlightBooking.DTOs.FlightDTOs;
using FlightBooking.Entities;
using Microsoft.EntityFrameworkCore;

namespace FlightBooking.Services.FlightServices
{
    public class FlightService : IFlightService
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;
        public FlightService(IMapper mapper, AppDbContext context) 
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task CreateFlightAsync(CreateFlightDTO createFlightDTO)
        {
            var value = _mapper.Map<Flight>(createFlightDTO);
            await _context.Flights.AddAsync(value);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFlightAsync(int id)
        {
            var value = await _context.Flights.FindAsync(id);
            if (value != null)
            {
                _context.Flights.Remove(value);
                await _context.SaveChangesAsync(); ;
            }
        }

        public async Task<List<ResultFlightDTO>> GetAllFlightsAsync()
        {
            var value = await _context.Flights.ToListAsync();
            return _mapper.Map<List<ResultFlightDTO>>(value);  
        }

        public async Task<GetFlightByIdDTO> GetFlightByIdAsync(int id)
        {
            var value = await _context.Flights.FindAsync(id);
            return _mapper.Map<GetFlightByIdDTO>(value);
        }

        public async Task UpdateFlightAsync(UpdateFlightDTO updateFlightDTO)
        {
            var value = await _context.Flights.FindAsync(updateFlightDTO);
            if(value != null)
            {
                _mapper.Map(updateFlightDTO, value);
                await _context.SaveChangesAsync();
            }
        }
    }
}
