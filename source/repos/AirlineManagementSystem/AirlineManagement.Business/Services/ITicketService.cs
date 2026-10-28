using System;
using System.Collections.Generic;
using System.Text;
using AirlineManagement.Application.DTOs;

namespace AirlineManagement.Application.Services;

public interface ITicketService
{
    Task<IEnumerable<TicketResponseDto>> GetAllAsync();
    Task<IEnumerable<TicketResponseDto>> GetTicketsByReservationIdAsync(int reservationId);
    Task CancelTicketAsync(int ticketId);
}
