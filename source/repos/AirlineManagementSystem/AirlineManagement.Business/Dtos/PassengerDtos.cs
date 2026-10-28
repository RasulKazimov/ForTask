using System;
using System.Collections.Generic;
using System.Text;
namespace AirlineManagement.Application.DTOs;

public record CreatePassengerDto(
    string FullName,
    string PassportNumber,
    string Email,
    string PhoneNumber,
    DateTime DateOfBirth
);

public record UpdatePassengerDto(
    string FullName,
    string Email,
    string PhoneNumber,
    DateTime DateOfBirth
);

public record PassengerResponseDto(
    int Id,
    string FullName,
    string PassportNumber,
    string Email,
    string PhoneNumber,
    DateTime DateOfBirth
);
