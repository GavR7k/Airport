using Airport.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Infrastructure.Configurations
{
    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Number)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(x => x.CompanyName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.ArrivalAirport)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.DepartureTime)
                .IsRequired();

            builder.Property(x => x.ArrivalTime)
               .IsRequired();

            builder.Property(x => x.FlightStatus)
                .IsRequired();

            builder.HasOne(g => g.Gate)
                .WithMany(f => f.Flights)
                .HasForeignKey(f => f.GateId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(t => t.Tickets)
                .WithOne(t => t.Flight)
                .HasForeignKey(t => t.FlightId);
        }
    }
}
