using System;
using System.Collections.Generic;
using System.Text;
using AirlineManagement.Application.DTOs;

namespace AirlineManagement.Application.Services;

public interface IFlightPriceRuleService
{
    Task<FlightPriceRuleResponseDto> CreateAsync(CreateFlightPriceRuleDto dto);
    Task<IEnumerable<FlightPriceRuleResponseDto>> GetRulesByFlightIdAsync(int flightId);
    Task<IEnumerable<FlightPriceRuleResponseDto>> GetAllAsync();
}