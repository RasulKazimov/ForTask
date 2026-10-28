using AirlineManagement.Domain.Common;

namespace AirlineManagement.Domain.Entities;

public class Airport : AuditEntity
{
    public string Name { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public virtual ICollection<Flight> DepartureFlights { get; set; } = new List<Flight>();
    public virtual ICollection<Flight> ArrivalFlights { get; set; } = new List<Flight>();
}