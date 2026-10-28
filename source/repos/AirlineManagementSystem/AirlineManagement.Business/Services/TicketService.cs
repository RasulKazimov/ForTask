using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using AirlineManagement.Application.DTOs;
using AirlineManagement.Domain.Entities;
using AirlineManagement.Domain.Enums;
using AirlineManagement.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AirlineManagement.Application.Services;

public class TicketService : ITicketService
{
    private readonly IRepository<Ticket> _ticketRepo;
    private readonly IMapper _mapper;

    public TicketService(IRepository<Ticket> ticketRepo, IMapper mapper)
    {
        _ticketRepo = ticketRepo;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TicketResponseDto>> GetAllAsync()
    {
        var tickets = await _ticketRepo.Query()
            .Include(t => t.Reservation)
                .ThenInclude(r => r.Flight)
            .ToListAsync();

        return _mapper.Map<IEnumerable<TicketResponseDto>>(tickets);
    }

    public async Task<IEnumerable<TicketResponseDto>> GetTicketsByReservationIdAsync(int reservationId)
    {
        var tickets = await _ticketRepo.Query()
            .Where(t => t.ReservationId == reservationId)
            .Include(t => t.Reservation)
                .ThenInclude(r => r.Flight)
            .ToListAsync();

        return _mapper.Map<IEnumerable<TicketResponseDto>>(tickets);
    }

    public async Task CancelTicketAsync(int ticketId)
    {
        var ticket = await _ticketRepo.GetByIdAsync(ticketId);
        if (ticket == null) throw new KeyNotFoundException("Bilet tapılmadı.");

        ticket.Status = TicketStatus.Cancelled;
        _ticketRepo.Update(ticket);
        await _ticketRepo.SaveChangesAsync();
    }
}
