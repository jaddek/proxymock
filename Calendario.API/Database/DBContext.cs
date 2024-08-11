using Calendario.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Calendario.API.Database;


public class DBContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Project> Projects { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Project>().ToTable("projects");
    }
}