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
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Number)
                   .IsRequired()
                   .HasMaxLength(20);

            builder.Property(t => t.Status)
                   .IsRequired();

            builder.Property(t => t.Price)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

            builder.HasOne(t => t.Flight)
                   .WithMany(f => f.Tickets)
                   .HasForeignKey(t => t.FlightId)
                   .OnDelete(DeleteBehavior.Cascade);
           
           
            builder.HasOne(t => t.Passenger)
                   .WithMany(p => p.Tickets)
                   .HasForeignKey(t => t.PassengerId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
