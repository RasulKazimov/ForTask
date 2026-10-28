using System;
using System.Collections.Generic;
using System.Text;
using AirlineManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirlineManagement.Persistence.Configurations;

public class PassengerConfiguration : IEntityTypeConfiguration<Passenger>
{
    public void Configure(EntityTypeBuilder<Passenger> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.FullName).IsRequired().HasMaxLength(150);
        builder.Property(p => p.PassportNumber).IsRequired().HasMaxLength(30);
        builder.HasIndex(p => p.PassportNumber).IsUnique();
        builder.Property(p => p.Email).IsRequired().HasMaxLength(100);
        builder.Property(p => p.PhoneNumber).HasMaxLength(30);
    }
}