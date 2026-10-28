using AutoMapper;
using AirlineManagement.Application.DTOs;
using AirlineManagement.Application.Exceptions;
using AirlineManagement.Domain.Entities;
using AirlineManagement.Domain.Enums;
using AirlineManagement.Persistence.Repositories;

namespace AirlineManagement.Application.Services;

public class AircraftService : IAircraftService
{
    private readonly IRepository<Aircraft> _aircraftRepo;
    private readonly IMapper _mapper;

    public AircraftService(IRepository<Aircraft> aircraftRepo, IMapper mapper)
    {
        _aircraftRepo = aircraftRepo;
        _mapper = mapper;
    }

    public async Task<AircraftResponseDto> CreateAsync(CreateAircraftDto dto)
    {
        if (dto.BusinessClassSeats + dto.EconomyClassSeats > dto.Capacity)
        {
            throw new AircraftCapacityException(dto.Capacity, dto.BusinessClassSeats, dto.EconomyClassSeats);
        }

        var existing = await _aircraftRepo.FindAsync(a => a.RegistrationNumber == dto.RegistrationNumber && !a.IsDeleted);
        if (existing.Any())
        {
            throw new DuplicateEntityException("Təyyarə", "Qeydiyyat Nömrəsi", dto.RegistrationNumber);
        }

        var aircraft = _mapper.Map<Aircraft>(dto);
        aircraft.Status = AircraftStatus.Active;

        await _aircraftRepo.AddAsync(aircraft);
        await _aircraftRepo.SaveChangesAsync();

        return _mapper.Map<AircraftResponseDto>(aircraft);
    }

    public async Task<IEnumerable<AircraftResponseDto>> GetAllAsync()
    {
        var list = await _aircraftRepo.FindAsync(a => !a.IsDeleted);
        return _mapper.Map<IEnumerable<AircraftResponseDto>>(list);
    }

    public async Task<AircraftResponseDto?> GetByIdAsync(int id)
    {
        var aircraft = await _aircraftRepo.GetByIdAsync(id);
        if (aircraft == null || aircraft.IsDeleted)
            throw new EntityNotFoundException("Təyyarə", id);

        return _mapper.Map<AircraftResponseDto>(aircraft);
    }

    public async Task DeleteAsync(int id)
    {
        var aircraft = await _aircraftRepo.GetByIdAsync(id);
        if (aircraft == null || aircraft.IsDeleted)
            throw new EntityNotFoundException("Təyyarə", id);

        aircraft.IsDeleted = true;
        _aircraftRepo.Update(aircraft);
        await _aircraftRepo.SaveChangesAsync();
    }
}