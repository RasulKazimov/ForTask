using AirlineManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace AirlineManagement.Domain.Entities;

public class Reservation
{
    public int Id { get; set; }
    public string ReservationCode { get; set; } = string.Empty;
    public int PassengerId { get; set; }
    public Passenger Passenger { get; set; } = null!;

    public int FlightId { get; set; }
    public Flight Flight { get; set; } = null!;

    public DateTime ReservationDate { get; set; }
    public decimal TotalPrice { get; set; }
    public ReservationStatus Status { get; set; }

    public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}