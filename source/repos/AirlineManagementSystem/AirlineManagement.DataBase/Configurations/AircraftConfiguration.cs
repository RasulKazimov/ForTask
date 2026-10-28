using System;
using System.Collections.Generic;
using System.Text;
using AirlineManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirlineManagement.Persistence.Configurations;

public class AircraftConfiguration : IEntityTypeConfiguration<Aircraft>
{
    public void Configure(EntityTypeBuilder<Aircraft> builder)
    {
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Model).IsRequired().HasMaxLength(100);
        builder.Property(a => a.RegistrationNumber).IsRequired().HasMaxLength(50);
        builder.HasIndex(a => a.RegistrationNumber).IsUnique();
        builder.Property(a => a.Capacity).IsRequired();
    }
}