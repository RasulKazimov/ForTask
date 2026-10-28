using AirlineManagement.Domain.Common;
using AirlineManagement.Domain.Enums;

namespace AirlineManagement.Domain.Entities;

public class Flight : AuditEntity
{
    public string FlightNumber { get; set; } = string.Empty;

    public int AircraftId { get; set; }
    public virtual Aircraft Aircraft { get; set; } = null!;

    public int DepartureAirportId { get; set; }
    public virtual Airport DepartureAirport { get; set; } = null!;

    public int ArrivalAirportId { get; set; }
    public virtual Airport ArrivalAirport { get; set; } = null!;

    public DateTime DepartureTime { get; set; }
    public DateTime ArrivalTime { get; set; }
    public FlightStatus Status { get; set; }

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    public virtual ICollection<FlightPriceRule> PriceRules { get; set; } = new List<FlightPriceRule>();
}