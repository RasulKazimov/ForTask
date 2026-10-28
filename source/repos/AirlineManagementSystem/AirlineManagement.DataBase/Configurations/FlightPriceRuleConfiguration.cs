using System;
using System.Collections.Generic;
using System.Text;
using AirlineManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirlineManagement.Persistence.Configurations;

public class FlightPriceRuleConfiguration : IEntityTypeConfiguration<FlightPriceRule>
{
    public void Configure(EntityTypeBuilder<FlightPriceRule> builder)
    {
        builder.HasKey(fpr => fpr.Id);
        builder.Property(fpr => fpr.BasePrice).HasPrecision(18, 2);
        builder.Property(fpr => fpr.DiscountPercentage).HasPrecision(5, 2);

        builder.HasOne(fpr => fpr.Flight)
               .WithMany(f => f.PriceRules)
               .HasForeignKey(fpr => fpr.FlightId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}