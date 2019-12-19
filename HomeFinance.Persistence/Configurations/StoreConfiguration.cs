using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HomeFinance.Domain.Entities;

namespace HomeFinance.Persistence.Configurations
{
    public class StoreConfiguration : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.StoreName).IsRequired().HasMaxLength(30);

            builder.Property(s => s.Active).HasDefaultValueSql("1");
        }
    }
}
