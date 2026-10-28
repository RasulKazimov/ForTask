using System;
using System.Collections.Generic;
using System.Text;
using AirlineManagement.Application.DTOs;

namespace AirlineManagement.Application.Services;

public interface IFlightService
{
    Task<FlightResponseDto> CreateFlightAsync(CreateFlightDto dto);
    Task<IEnumerable<FlightResponseDto>> GetAllFlightsAsync();
    Task<FlightResponseDto?> GetFlightByIdAsync(int id);
    Task CancelFlightAsync(int flightId);
}