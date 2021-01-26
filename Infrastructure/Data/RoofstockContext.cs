using Microsoft.EntityFrameworkCore;
using Core.Entities;
using System.Reflection;
using System.Linq;

namespace Infrastructure.Data
{
    public class RoofstockContext : DbContext
    {
        public RoofstockContext(DbContextOptions<RoofstockContext> options) : base(options)
        {
            
        }

        public DbSet<RealProperty> Properties { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            if (Database.ProviderName == "Microsoft.EntityFrameworkCore.Sqlite")
            {
                foreach (var entityType in modelBuilder.Model.GetEntityTypes())
                {
                    var properties = entityType.ClrType.GetProperties().Where(p => p.PropertyType == typeof(decimal));

                    foreach (var property in properties)
                    {
                        modelBuilder.Entity(entityType.Name).Property(property.Name).HasConversion<double>();
                    }
                }
            }
        }
    }
}