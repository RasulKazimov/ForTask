using System;
using System.Collections.Generic;
using System.Text;
using AirlineManagement.Domain.Enums;

namespace AirlineManagement.Application.DTOs;

public record CreateFlightDto(
    string FlightNumber,
    int AircraftId,
    int DepartureAirportId,
    int ArrivalAirportId,
    DateTime DepartureTime,
    DateTime ArrivalTime
);

public record UpdateFlightDto(
    int AircraftId,
    int DepartureAirportId,
    int ArrivalAirportId,
    DateTime DepartureTime,
    DateTime ArrivalTime
);

public record FlightResponseDto(
    int Id,
    string FlightNumber,
    string AircraftModel,
    string DepartureAirport,
    string ArrivalAirport,
    DateTime DepartureTime,
    DateTime ArrivalTime,
    FlightStatus Status
);

public record FlightSearchDto(
    string DepartureAirportCode,
    string ArrivalAirportCode,
    DateTime DepartureDate,
    decimal? MinPrice,
    decimal? MaxPrice,
    ClassType? ClassType
);

public record AvailableFlightResponseDto(
    int FlightId,
    string FlightNumber,
    string DepartureAirport,
    string ArrivalAirport,
    DateTime DepartureTime,
    DateTime ArrivalTime,
    int AvailableEconomySeats,
    int AvailableBusinessSeats,
    decimal MinimumPrice
);