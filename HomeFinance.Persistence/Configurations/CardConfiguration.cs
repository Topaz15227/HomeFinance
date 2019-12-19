using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HomeFinance.Domain.Entities;

namespace HomeFinance.Persistence.Configurations
{
    public class CardConfiguration : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.CardName).IsRequired().HasMaxLength(15);

            builder.Property(c => c.CardDescription).IsRequired().HasMaxLength(25);
            builder.Property(c => c.CardNumber).IsRequired().HasMaxLength(20);
            builder.Property(c => c.ClosingName).IsRequired().HasMaxLength(3);
            builder.Property(c => c.Active).HasDefaultValueSql("1");
        }
    }
}
