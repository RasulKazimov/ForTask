using AirlineManagement.Application.DTOs;

namespace AirlineManagement.Application.Services;

public interface IAircraftService
{
    Task<AircraftResponseDto> CreateAsync(CreateAircraftDto dto);
    Task<IEnumerable<AircraftResponseDto>> GetAllAsync();
    Task<AircraftResponseDto?> GetByIdAsync(int id);
    Task DeleteAsync(int id); 
}