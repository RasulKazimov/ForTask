using AutoMapper;
using AirlineManagement.Application.DTOs;
using AirlineManagement.Application.Exceptions;
using AirlineManagement.Domain.Entities;
using AirlineManagement.Persistence.Repositories;

namespace AirlineManagement.Application.Services;

public class PassengerService : IPassengerService
{
    private readonly IRepository<Passenger> _passengerRepo;
    private readonly IMapper _mapper;

    public PassengerService(IRepository<Passenger> passengerRepo, IMapper mapper)
    {
        _passengerRepo = passengerRepo;
        _mapper = mapper;
    }

    public async Task<PassengerResponseDto> CreateAsync(CreatePassengerDto dto)
    {
        var passenger = _mapper.Map<Passenger>(dto);
        await _passengerRepo.AddAsync(passenger);
        await _passengerRepo.SaveChangesAsync();
        return _mapper.Map<PassengerResponseDto>(passenger);
    }

    public async Task<IEnumerable<PassengerResponseDto>> GetAllAsync()
    {
        var list = await _passengerRepo.GetAllAsync();
        return _mapper.Map<IEnumerable<PassengerResponseDto>>(list);
    }

    public async Task<PassengerResponseDto?> GetByIdAsync(int id)
    {
        var passenger = await _passengerRepo.GetByIdAsync(id);
        if (passenger == null) throw new EntityNotFoundException("Sərnişin", id);
        return _mapper.Map<PassengerResponseDto>(passenger);
    }

    public async Task DeleteAsync(int id)
    {
        var passenger = await _passengerRepo.GetByIdAsync(id);
        if (passenger == null) throw new EntityNotFoundException("Sərnişin", id);

        passenger.IsDeleted = true;
        _passengerRepo.Update(passenger);
        await _passengerRepo.SaveChangesAsync();
    }
}