using Microsoft.EntityFrameworkCore;
using Core.Entities;

namespace Infrastructure.Data
{
    public class RoofstockContext : DbContext
    {
        public RoofstockContext(DbContextOptions<RoofstockContext> options) : base(options)
        {
            
        }

        public DbSet<RealProperty> Properties { get; set; }
    }
}