using System;
using System.Collections.Generic;
using System.Text;
using AirlineManagement.Domain.Enums;

namespace AirlineManagement.Application.DTOs;

public record BookTicketDto(
    int ReservationId,
    string SeatNumber,
    ClassType ClassType
);

public record CancelTicketDto(
    string Reason
);

public record TicketResponseDto(
    int Id,
    int ReservationId,
    string FlightNumber,
    string SeatNumber,
    ClassType ClassType,
    decimal BasePrice,
    decimal FinalPrice,
    TicketStatus Status
);