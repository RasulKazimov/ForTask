using System;
using System.Collections.Generic;
using System.Text;
using AirlineManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirlineManagement.Persistence.Configurations;

public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(t => t.SeatNumber).IsRequired().HasMaxLength(10);
        builder.Property(t => t.BasePrice).HasPrecision(18, 2);
        builder.Property(t => t.FinalPrice).HasPrecision(18, 2);

        builder.HasOne(t => t.Reservation)
               .WithMany(r => r.Tickets)
               .HasForeignKey(t => t.ReservationId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex("ReservationId", "SeatNumber")
               .IsUnique()
               .HasFilter("[Status] <> 3");
    }
}