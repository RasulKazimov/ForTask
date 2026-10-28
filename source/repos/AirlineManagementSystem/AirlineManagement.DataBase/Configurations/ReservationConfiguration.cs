using System;
using System.Collections.Generic;
using System.Text;
using AirlineManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirlineManagement.Persistence.Configurations;

public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {
        builder.HasKey(r => r.Id);
        builder.Property(r => r.ReservationCode).IsRequired().HasMaxLength(20);
        builder.HasIndex(r => r.ReservationCode).IsUnique();
        builder.Property(r => r.TotalPrice).HasPrecision(18, 2);

        builder.HasOne(r => r.Passenger)
               .WithMany(p => p.Reservations)
               .HasForeignKey(r => r.PassengerId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(r => r.Flight)
               .WithMany(f => f.Reservations)
               .HasForeignKey(r => r.FlightId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}