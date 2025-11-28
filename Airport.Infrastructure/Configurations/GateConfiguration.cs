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
    public class GateConfiguration : IEntityTypeConfiguration<Gate>
    {
        public void Configure(EntityTypeBuilder<Gate> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Number)
                 .IsRequired()
                 .HasMaxLength(30);

            builder.Property(x => x.Terminal)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(x => x.Status)
                .IsRequired();

            builder.HasMany(g => g.Flights)
                .WithOne(f => f.Gate)
                .HasForeignKey(f => f.GateId)
                .OnDelete(DeleteBehavior.SetNull);

        }
    }

}
