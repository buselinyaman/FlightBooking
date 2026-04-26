using FlightBooking.DTOs.FlightDTOs;

namespace FlightBooking.Services.FlightServices
{
    public interface IFlightService
    {
        Task<List<ResultFlightDTO>> GetAllFlightsAsync();
        Task<GetFlightByIdDTO> GetFlightByIdAsync(int id);
        Task CreateFlightAsync(CreateFlightDTO createFlightDTO);
        Task DeleteFlightAsync(int id);
        Task UpdateFlightAsync(UpdateFlightDTO updateFlightDTO);
    }
}
