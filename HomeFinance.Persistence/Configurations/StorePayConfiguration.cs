using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HomeFinance.Domain.Entities;

namespace HomeFinance.Persistence.Configurations
{
    public class StorePayConfiguration : IEntityTypeConfiguration<StorePay>
    {
        public void Configure(EntityTypeBuilder<StorePay> builder)
        {
            builder.HasKey(p => p.Id);               // .ValueGeneratedNever(); //not for key

            builder.Property(p => p.CardId).IsRequired();

            builder.Property(p => p.StoreId).IsRequired();

            builder.Property(p => p.PayDate).HasColumnType("date");

            builder.Property(p => p.Amount)
                .IsRequired()
                .HasColumnType("money")
                .HasDefaultValueSql("((0))");

            builder.Property(p => p.Note).HasMaxLength(45);

            //builder.Property(p => p.Active).HasDefaultValue(true);
            builder.Property(c => c.Active).HasDefaultValueSql("1");

            builder.HasOne(c => c.Card)
                .WithMany(p => p.StorePays)
                .HasForeignKey(p => p.CardId)
                .HasConstraintName("FK_StorePays_Cards");

            builder.HasOne(s => s.Store)
                .WithMany(p => p.StorePays)
                .HasForeignKey(p => p.StoreId)
                .HasConstraintName("FK_StorePays_Stores");

            builder.HasOne(c => c.Closing)
                .WithMany(p => p.StorePays)
                .HasForeignKey(p => p.ClosingId)
                .HasConstraintName("FK_StorePays_Closings");
        }
    }
}
