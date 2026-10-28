using AutoMapper;
using AirlineManagement.Application.DTOs;
using AirlineManagement.Application.Exceptions;
using AirlineManagement.Domain.Entities;
using AirlineManagement.Persistence.Repositories;

namespace AirlineManagement.Application.Services;

public class AirportService : IAirportService
{
    private readonly IRepository<Airport> _airportRepo;
    private readonly IMapper _mapper;

    public AirportService(IRepository<Airport> airportRepo, IMapper mapper)
    {
        _airportRepo = airportRepo;
        _mapper = mapper;
    }

    public async Task<AirportResponseDto> CreateAsync(CreateAirportDto dto)
    {
        var airport = _mapper.Map<Airport>(dto);
        await _airportRepo.AddAsync(airport);
        await _airportRepo.SaveChangesAsync();
        return _mapper.Map<AirportResponseDto>(airport);
    }

    public async Task<IEnumerable<AirportResponseDto>> GetAllAsync()
    {
        var list = await _airportRepo.GetAllAsync();
        return _mapper.Map<IEnumerable<AirportResponseDto>>(list);
    }

    public async Task<AirportResponseDto?> GetByIdAsync(int id)
    {
        var airport = await _airportRepo.GetByIdAsync(id);
        if (airport == null) throw new EntityNotFoundException("Hava Limanı", id);
        return _mapper.Map<AirportResponseDto>(airport);
    }

    public async Task DeleteAsync(int id)
    {
        var airport = await _airportRepo.GetByIdAsync(id);
        if (airport == null) throw new EntityNotFoundException("Hava Limanı", id);

        airport.IsDeleted = true;
        _airportRepo.Update(airport);
        await _airportRepo.SaveChangesAsync();
    }
}