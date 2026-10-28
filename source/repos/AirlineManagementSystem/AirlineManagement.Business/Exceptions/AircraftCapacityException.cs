using System;
using System.Collections.Generic;
using System.Text;
namespace AirlineManagement.Application.Exceptions;

public class AircraftCapacityException : BusinessException
{
    public AircraftCapacityException(int totalCapacity, int businessSeats, int economySeats)
        : base($"Tutum xətası! Biznes ({businessSeats}) və Ekonom ({economySeats}) yerlərinin cəmi ({businessSeats + economySeats}), ümumi tutumdan ({totalCapacity}) böyük ola bilməz!")
    { }
}