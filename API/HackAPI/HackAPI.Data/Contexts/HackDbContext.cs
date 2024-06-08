using HackAPI.Entities.Entities;
using HackAPI.Entities.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace HackAPI.Data.Contexts
{
    public class HackDbContext : DbContext
    {
        public DbSet<Production> Productions { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductProductions> ProductProductions { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Transportation> Transportations { get; set; }

        public HackDbContext(DbContextOptions<HackDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region ProductProductions
            modelBuilder.Entity<ProductProductions>()
                .HasKey(pp => new { pp.ProductId, pp.ProductionsId });

            modelBuilder.Entity<ProductProductions>()
                .HasOne(p => p.Product)
                .WithMany(pp => pp.ProductProductions)
                .HasForeignKey(pp => pp.ProductId);

            modelBuilder.Entity<ProductProductions>()
                .HasOne(p => p.Productions)
                .WithMany(pp => pp.ProductProductions)
                .HasForeignKey(pp => pp.ProductionsId);
            #endregion

            #region ProductionTransportation

            modelBuilder.Entity<ProductionTransportation>()
                .HasKey(pt => new { pt.ProductionId, pt.TransportationId });

            modelBuilder.Entity<ProductionTransportation>()
                .HasOne(p => p.Production)
                .WithMany(pt => pt.ProductionTransportations)
                .HasForeignKey(pt => pt.ProductionId);

            modelBuilder.Entity<ProductionTransportation>()
                .HasOne(p => p.Transportation)
                .WithMany(pt => pt.ProductionTransportations)
                .HasForeignKey(pt => pt.TransportationId);

            #endregion


        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<BaseEntity>();
            foreach (var entry in entries)
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Id = Guid.NewGuid();
                        entry.Entity.CreatedAt = DateTime.UtcNow;
                        break;  
                    default:
                        break;
                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }



    }
}
