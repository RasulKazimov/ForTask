using AirlineManagement.Domain.Common;

namespace AirlineManagement.Domain.Entities;

public class Passenger : AuditEntity
{
    public string FullName { get; set; } = string.Empty;
    public string PassportNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}