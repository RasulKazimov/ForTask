using AirlineManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AirlineManagement.Persistence.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Aircraft> Aircrafts { get; set; }
    public DbSet<Airport> Airports { get; set; }
    public DbSet<Passenger> Passengers { get; set; }
    public DbSet<Flight> Flights { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<FlightPriceRule> FlightPriceRules { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}