using System;
using System.Collections.Generic;
using System.Text;
using AirlineManagement.Domain.Enums;

namespace AirlineManagement.Application.DTOs;

public record CreateAircraftDto(
    string Model,
    string RegistrationNumber,
    int Capacity,
    int BusinessClassSeats,
    int EconomyClassSeats
);

public record UpdateAircraftDto(
    string Model,
    int Capacity,
    int BusinessClassSeats,
    int EconomyClassSeats,
    AircraftStatus Status
);

public record AircraftResponseDto(
    int Id,
    string Model,
    string RegistrationNumber,
    int Capacity,
    int BusinessClassSeats,
    int EconomyClassSeats,
    AircraftStatus Status
);