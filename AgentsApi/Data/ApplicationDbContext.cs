using AgentsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AgentsApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasKey(c => c.Id); 

                // Configure Car properties
                entity.Property(c => c.EngineCapacityInCc)
                      .HasColumnType("decimal(18, 2)"); 

                entity.OwnsOne(c => c.DealerContactInformation, dci =>
                {
                    dci.OwnsOne(dc => dc.Address);

                    
                    dci.Property(dc => dc.Latitude)
                        .HasColumnType("decimal(9, 6)"); 

                    dci.Property(dc => dc.Longitude)
                        .HasColumnType("decimal(9, 6)"); 
                });
            });
        }
    }
}
