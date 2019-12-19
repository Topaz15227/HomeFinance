using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HomeFinance.Domain.Entities;

namespace HomeFinance.Persistence.Configurations
{
    public class ClosingConfiguration : IEntityTypeConfiguration<Closing>
    {
        public void Configure(EntityTypeBuilder<Closing> builder)
        {
            builder.HasKey(l => l.Id);

            builder.Property(l => l.ClosingName).IsRequired().HasMaxLength(15);

            builder.Property(l => l.CardId).IsRequired();

            builder.Property(l => l.ClosingDate).HasColumnType("date");

            builder.Property(p => p.ClosingAmount)
                .IsRequired()
                .HasColumnType("money")
                .HasDefaultValueSql("((0))");

            builder.HasOne(c => c.Card)
            .WithMany(l => l.Closings)
            .HasForeignKey(l => l.CardId)
            .HasConstraintName("FK_Closings_Cards");
        }
    }
}