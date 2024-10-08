using Microsoft.EntityFrameworkCore;
using Proxymock.API.Entities;
using Endpoint = Proxymock.API.Entities.Endpoint;

namespace Proxymock.API.Database;

public class DBContext(DbContextOptions options) : DbContext(options)
{
    public virtual DbSet<Project> Projects { get; init; }
    public virtual DbSet<Endpoint> Endpoints { get; init; }
    public virtual DbSet<Schema> Schemas { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BaseEntity>()
            .Property(e => e.CreatedOn)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        modelBuilder.Entity<BaseEntity>()
            .Property(e => e.UpdatedOn)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");
    }


    public override int SaveChanges()
    {
        var entries = ChangeTracker.Entries()
            .Where(e => e.Entity is BaseEntity &&
                        (e.State == EntityState.Added || e.State == EntityState.Modified));

        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                ((BaseEntity)entry.Entity).CreatedOn = DateTime.UtcNow;
            }

            ((BaseEntity)entry.Entity).UpdatedOn = DateTime.UtcNow;
        }

        return base.SaveChanges();
    }
}