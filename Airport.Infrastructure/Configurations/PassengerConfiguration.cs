using Airport.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Airport.Infrastructure.Configurations
{
    public class PassengerConfiguration : IEntityTypeConfiguration<Passenger>
    {
        public void Configure(EntityTypeBuilder<Passenger> builder)
        {

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                 .IsRequired()
                 .HasMaxLength(50);

            builder.Property(x => x.PassportNumber)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasMany(p => p.Tickets)
                .WithOne(t => t.Passenger)
                .HasForeignKey(t => t.PassengerId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }

}
