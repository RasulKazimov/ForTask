using System;
using System.Collections.Generic;
using System.Text;
namespace AirlineManagement.Application.Exceptions;

public class InvalidFlightRouteException : BusinessException
{
    public InvalidFlightRouteException()
        : base("Qalxış və Eniş hava limanları eyni ola bilməz!")
    { }
}