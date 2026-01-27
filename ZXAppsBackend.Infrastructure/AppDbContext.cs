using Microsoft.EntityFrameworkCore;
using ZXAppsBackend.Domain.Entities;

namespace ZXAppsBackend.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<TmOperator> Operators { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TmOperator>(entity =>
        {
            entity.ToTable("tm_operator"); // PostgreSQL table name

            entity.HasKey(e => e.OperatorPk).HasName("pk_operator");

            entity.Property(e => e.OperatorPk).HasColumnName("operator_pk");
            entity.Property(e => e.NoOperator).HasColumnName("nooperator");
            entity.Property(e => e.NIP).HasColumnName("nip");
            entity.Property(e => e.Nama).HasColumnName("nama");
            entity.Property(e => e.StatusFk).HasColumnName("status_fk");
        });
    }
}
