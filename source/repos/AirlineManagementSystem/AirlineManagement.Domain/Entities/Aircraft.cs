using AirlineManagement.Domain.Common;
using AirlineManagement.Domain.Enums;

namespace AirlineManagement.Domain.Entities;

public class Aircraft : AuditEntity
{
    public string Model { get; set; } = string.Empty;
    public string RegistrationNumber { get; set; } = string.Empty;
    public int Capacity { get; set; }
    public int BusinessClassSeats { get; set; }
    public int EconomyClassSeats { get; set; }
    public AircraftStatus Status { get; set; }
    public virtual ICollection<Flight> Flights { get; set; } = new List<Flight>();
}