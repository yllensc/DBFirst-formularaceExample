using System.Reflection;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Entities;

public partial class DbFirstContext : DbContext
{

    public DbFirstContext(DbContextOptions<DbFirstContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Driver> Drivers { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    public virtual DbSet<Teamdriver> Teamdrivers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
