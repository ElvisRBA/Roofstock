using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    // This configuration guide the migration to create the rules for the RealProperty table
    public class RealPropertyConfigutation : IEntityTypeConfiguration<RealProperty>
    {
        public void Configure(EntityTypeBuilder<RealProperty> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Address).IsRequired().HasMaxLength(256);
            builder.Property(p => p.YearBuilt).IsRequired();
            builder.Property(p => p.ListPrice).HasColumnType("decimal(18,2)");
            builder.Property(p => p.MonthlyRent).HasColumnType("decimal(18,2)");
        }
    }
}