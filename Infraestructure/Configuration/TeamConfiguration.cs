
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Configuration;
public class TeamConfiguration : IEntityTypeConfiguration<Team>
{
  public void Configure(EntityTypeBuilder<Team> builder)
  {
    builder.HasKey(e => e.Id).HasName("PRIMARY");

    builder.ToTable("team");

    builder.HasIndex(e => e.Name, "idx_team_name").IsUnique();

    builder.Property(e => e.Name)
        .HasMaxLength(50)
        .HasColumnName("name");

    builder
    .HasMany(p => p.Drivers)
    .WithMany(p => p.Teams)
    .UsingEntity<Teamdriver>(
      j => j
        .HasOne(pt => pt.Driver)
        .WithMany(t => t.Teamdrivers)
        .HasForeignKey(pt => pt.IdDriver),
      j => j
        .HasOne(pt => pt.Team)
        .WithMany(t => t.Teamdrivers)
        .HasForeignKey(pt => pt.Idteam),
      j =>
        {
          j.HasKey(t => new { t.IdDriver, t.Idteam });
          j.ToTable("teamdriver");
        });
  }
}
