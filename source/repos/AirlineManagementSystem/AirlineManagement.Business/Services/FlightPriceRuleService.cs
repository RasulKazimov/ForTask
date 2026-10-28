using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using AirlineManagement.Application.DTOs;
using AirlineManagement.Domain.Entities;
using AirlineManagement.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AirlineManagement.Application.Services;

public class FlightPriceRuleService : IFlightPriceRuleService
{
    private readonly IRepository<FlightPriceRule> _priceRuleRepo;
    private readonly IMapper _mapper;

    public FlightPriceRuleService(IRepository<FlightPriceRule> priceRuleRepo, IMapper mapper)
    {
        _priceRuleRepo = priceRuleRepo;
        _mapper = mapper;
    }

    public async Task<FlightPriceRuleResponseDto> CreateAsync(CreateFlightPriceRuleDto dto)
    {
        var rule = _mapper.Map<FlightPriceRule>(dto);
        await _priceRuleRepo.AddAsync(rule);
        await _priceRuleRepo.SaveChangesAsync();

        return _mapper.Map<FlightPriceRuleResponseDto>(rule);
    }

    public async Task<IEnumerable<FlightPriceRuleResponseDto>> GetRulesByFlightIdAsync(int flightId)
    {
        var rules = await _priceRuleRepo.Query()
            .Where(r => r.FlightId == flightId)
            .ToListAsync();

        return _mapper.Map<IEnumerable<FlightPriceRuleResponseDto>>(rules);
    }

    public async Task<IEnumerable<FlightPriceRuleResponseDto>> GetAllAsync()
    {
        var rules = await _priceRuleRepo.GetAllAsync();
        return _mapper.Map<IEnumerable<FlightPriceRuleResponseDto>>(rules);
    }
}
