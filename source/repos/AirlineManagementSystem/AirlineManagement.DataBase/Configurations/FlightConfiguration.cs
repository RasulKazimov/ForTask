using System;
using System.Collections.Generic;
using System.Text;
using AirlineManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirlineManagement.Persistence.Configurations;

public class FlightConfiguration : IEntityTypeConfiguration<Flight>
{
    public void Configure(EntityTypeBuilder<Flight> builder)
    {
        builder.HasKey(f => f.Id);
        builder.Property(f => f.FlightNumber).IsRequired().HasMaxLength(20);
        builder.HasIndex(f => f.FlightNumber).IsUnique();

        builder.HasOne(f => f.Aircraft)
               .WithMany(a => a.Flights)
               .HasForeignKey(f => f.AircraftId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(f => f.DepartureAirport)
               .WithMany(a => a.DepartureFlights)
               .HasForeignKey(f => f.DepartureAirportId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(f => f.ArrivalAirport)
               .WithMany(a => a.ArrivalFlights)
               .HasForeignKey(f => f.ArrivalAirportId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
