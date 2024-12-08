using fiap.gerenciador_trafego.Models;
using Microsoft.EntityFrameworkCore;

namespace fiap.gerenciador_trafego.Data;

public class DatabaseContext : DbContext
{
    public virtual DbSet<ClimaModel> Clima { get; set; }

    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ClimaModel>(entity =>
        {
            entity.ToTable("t_gti_clima");
            entity.HasKey(e => e.IdClima).HasName("pk_t_gti_clima");
            entity.Property(e => e.IdClima).HasColumnName("id_clima").ValueGeneratedOnAdd();
            entity.Property(e => e.DsCondicao).HasMaxLength(150);
            entity.Property(e => e.NrTemperatura).HasColumnType("number(10,2)");
            entity.Property(e => e.NrUmidade).IsRequired();
            entity.Property(e => e.DtRegistro).HasColumnType("date").IsRequired();
        });
    }
}