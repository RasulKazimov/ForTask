using AirlineManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirlineManagement.Domain.Entities;

public class FlightPriceRule
{
    public int Id { get; set; }
    public int FlightId { get; set; }
    public Flight Flight { get; set; } = null!;

    public ClassType ClassType { get; set; }
    public decimal BasePrice { get; set; }
    public int AvailableSeatLimit { get; set; }
    public decimal DiscountPercentage { get; set; }
}
