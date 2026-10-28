using AirlineManagement.Application.DTOs;

namespace AirlineManagement.Application.Services;

public interface IPassengerService
{
    Task<PassengerResponseDto> CreateAsync(CreatePassengerDto dto);
    Task<IEnumerable<PassengerResponseDto>> GetAllAsync();
    Task<PassengerResponseDto?> GetByIdAsync(int id);
    Task DeleteAsync(int id); 
}