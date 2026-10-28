using AirlineManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirlineManagement.Domain.Entities;

public class Ticket
{
    public int Id { get; set; }
    public int ReservationId { get; set; }
    public Reservation Reservation { get; set; } = null!;

    public string SeatNumber { get; set; } = string.Empty;
    public ClassType ClassType { get; set; }
    public decimal BasePrice { get; set; }
    public decimal FinalPrice { get; set; }
    public TicketStatus Status { get; set; }
}
