using AutoMapper;
using AirlineManagement.Application.DTOs;
using AirlineManagement.Application.Exceptions;
using AirlineManagement.Domain.Entities;
using AirlineManagement.Domain.Enums;
using AirlineManagement.Persistence.Repositories;

namespace AirlineManagement.Application.Services;

public class FlightService : IFlightService
{
    private readonly IRepository<Flight> _flightRepo;
    private readonly IRepository<Aircraft> _aircraftRepo;
    private readonly IMapper _mapper;

    public FlightService(IRepository<Flight> flightRepo, IRepository<Aircraft> aircraftRepo, IMapper mapper)
    {
        _flightRepo = flightRepo;
        _aircraftRepo = aircraftRepo;
        _mapper = mapper;
    }

    public async Task<FlightResponseDto> CreateFlightAsync(CreateFlightDto dto)
    {
        if (dto.DepartureAirportId == dto.ArrivalAirportId)
        {
            throw new InvalidFlightRouteException();
        }

        if (dto.ArrivalTime <= dto.DepartureTime)
        {
            throw new BusinessException("Eniş vaxtı qalxış vaxtından sonra olmalıdır!");
        }

        var aircraft = await _aircraftRepo.GetByIdAsync(dto.AircraftId);
        if (aircraft == null)
        {
            throw new EntityNotFoundException("Təyyarə", dto.AircraftId);
        }

        var flight = _mapper.Map<Flight>(dto);
        flight.Status = FlightStatus.Scheduled;

        await _flightRepo.AddAsync(flight);
        await _flightRepo.SaveChangesAsync();

        return _mapper.Map<FlightResponseDto>(flight);
    }

    public async Task<IEnumerable<FlightResponseDto>> GetAllFlightsAsync()
    {
        var flights = await _flightRepo.GetAllAsync();
        return _mapper.Map<IEnumerable<FlightResponseDto>>(flights);
    }

    public async Task<FlightResponseDto?> GetFlightByIdAsync(int id)
    {
        var flight = await _flightRepo.GetByIdAsync(id);
        if (flight == null) throw new EntityNotFoundException("Uçuş", id);

        return _mapper.Map<FlightResponseDto>(flight);
    }

    public async Task CancelFlightAsync(int flightId)
    {
        var flight = await _flightRepo.GetByIdAsync(flightId);
        if (flight == null) throw new EntityNotFoundException("Uçuş", flightId);

        flight.Status = FlightStatus.Cancelled;
        _flightRepo.Update(flight);
        await _flightRepo.SaveChangesAsync();
    }
}