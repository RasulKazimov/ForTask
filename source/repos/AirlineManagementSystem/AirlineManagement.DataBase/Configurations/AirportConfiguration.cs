using System;
using System.Collections.Generic;
using System.Text;
using AirlineManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirlineManagement.Persistence.Configurations;

public class AirportConfiguration : IEntityTypeConfiguration<Airport>
{
    public void Configure(EntityTypeBuilder<Airport> builder)
    {
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Name).IsRequired().HasMaxLength(150);
        builder.Property(a => a.Code).IsRequired().HasMaxLength(10);
        builder.HasIndex(a => a.Code).IsUnique();
        builder.Property(a => a.City).IsRequired().HasMaxLength(100);
        builder.Property(a => a.Country).IsRequired().HasMaxLength(100);
    }
}