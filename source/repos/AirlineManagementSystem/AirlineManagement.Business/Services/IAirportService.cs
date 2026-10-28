using System;
using System.Collections.Generic;
using System.Text;
using AirlineManagement.Application.DTOs;

namespace AirlineManagement.Application.Services;

public interface IAirportService
{
    Task<AirportResponseDto> CreateAsync(CreateAirportDto dto);
    Task<IEnumerable<AirportResponseDto>> GetAllAsync();
    Task<AirportResponseDto?> GetByIdAsync(int id);
    Task DeleteAsync(int id); 
}