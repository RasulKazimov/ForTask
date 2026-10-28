using System;
using System.Collections.Generic;
using System.Text;
namespace AirlineManagement.Application.DTOs;

public record CreateAirportDto(
    string Name,
    string Code,
    string City,
    string Country
);

public record UpdateAirportDto(
    string Name,
    string City,
    string Country
);

public record AirportResponseDto(
    int Id,
    string Name,
    string Code,
    string City,
    string Country
);