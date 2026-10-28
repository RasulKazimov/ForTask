using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using AirlineManagement.Application.DTOs;
using AirlineManagement.Domain.Entities;
using AirlineManagement.Domain.Enums;
using AirlineManagement.Persistence.Context;
using AirlineManagement.Persistence.Repositories;

namespace AirlineManagement.Application.Services;

public class ReservationService : IReservationService
{
    private readonly IRepository<Reservation> _reservationRepo;
    private readonly IRepository<Flight> _flightRepo;
    private readonly IRepository<Passenger> _passengerRepo;
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public ReservationService(
        IRepository<Reservation> reservationRepo,
        IRepository<Flight> flightRepo,
        IRepository<Passenger> passengerRepo,
        AppDbContext context,
        IMapper mapper)
    {
        _reservationRepo = reservationRepo;
        _flightRepo = flightRepo;
        _passengerRepo = passengerRepo;
        _context = context;
        _mapper = mapper;
    }

    public async Task<ReservationResponseDto> CreateReservationAsync(CreateReservationDto dto)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var flight = await _flightRepo.GetByIdAsync(dto.FlightId);
            if (flight == null || flight.Status == FlightStatus.Cancelled)
                throw new InvalidOperationException("Ləğv edilmiş və ya mövcud olmayan uçuş üçün rezervasiya yaradıla bilməz.");

            var passenger = await _passengerRepo.GetByIdAsync(dto.PassengerId);
            if (passenger == null)
                throw new InvalidOperationException("Sərnişin tapılmadı.");

            var reservation = new Reservation
            {
                PassengerId = dto.PassengerId,
                FlightId = dto.FlightId,
                ReservationCode = Guid.NewGuid().ToString()[..8].ToUpper(),
                ReservationDate = DateTime.UtcNow,
                Status = ReservationStatus.Pending,
                TotalPrice = 0
            };

            foreach (var ticketDto in dto.Tickets)
            {
                var basePrice = ticketDto.ClassType == ClassType.Business ? 300m : 100m;
                var ticket = new Ticket
                {
                    SeatNumber = ticketDto.SeatNumber,
                    ClassType = ticketDto.ClassType,
                    BasePrice = basePrice,
                    FinalPrice = basePrice, // Hesablama qaydalarına əsasən artırıla bilər
                    Status = TicketStatus.Active
                };
                reservation.Tickets.Add(ticket);
                reservation.TotalPrice += ticket.FinalPrice;
            }

            await _reservationRepo.AddAsync(reservation);
            await _reservationRepo.SaveChangesAsync();

            await transaction.CommitAsync();
            return _mapper.Map<ReservationResponseDto>(reservation);
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    public async Task CancelReservationAsync(int id, string reason)
    {
        var reservation = await _reservationRepo.GetByIdAsync(id);
        if (reservation == null) throw new KeyNotFoundException("Rezervasiya tapılmadı.");

        reservation.Status = ReservationStatus.Cancelled;
        _reservationRepo.Update(reservation);
        await _reservationRepo.SaveChangesAsync();
    }

    public async Task<IEnumerable<ReservationSummaryDto>> GetAllReservationsAsync()
    {
        var reservations = await _reservationRepo.GetAllAsync();
        return _mapper.Map<IEnumerable<ReservationSummaryDto>>(reservations);
    }
}