using System;
using System.Collections.Generic;
using System.Text;
using AirlineManagement.Domain.Enums;

namespace AirlineManagement.Application.DTOs;

public record CreateFlightPriceRuleDto(
    int FlightId,
    ClassType ClassType,
    decimal BasePrice,
    int AvailableSeatLimit,
    decimal DiscountPercentage
);

public record UpdateFlightPriceRuleDto(
    decimal BasePrice,
    int AvailableSeatLimit,
    decimal DiscountPercentage
);

public record FlightPriceRuleResponseDto(
    int Id,
    int FlightId,
    ClassType ClassType,
    decimal BasePrice,
    int AvailableSeatLimit,
    decimal DiscountPercentage
);