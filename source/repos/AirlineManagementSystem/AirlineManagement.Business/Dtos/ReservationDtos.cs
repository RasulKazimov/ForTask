using System;
using System.Collections.Generic;
using System.Text;
using AirlineManagement.Domain.Enums;

namespace AirlineManagement.Application.DTOs;

public record ReservationTicketRequestDto(
    string SeatNumber,
    ClassType ClassType
);

public record CreateReservationDto(
    int PassengerId,
    int FlightId,
    List<ReservationTicketRequestDto> Tickets
);

public record CancelReservationDto(
    string Reason
);

public record ReservationResponseDto(
    int Id,
    string ReservationCode,
    string PassengerName,
    string FlightNumber,
    DateTime ReservationDate,
    decimal TotalPrice,
    ReservationStatus Status,
    List<TicketResponseDto> Tickets
);

public record ReservationSummaryDto(
    int Id,
    string ReservationCode,
    string PassengerName,
    string FlightNumber,
    decimal TotalPrice,
    ReservationStatus Status,
    DateTime ReservationDate
);