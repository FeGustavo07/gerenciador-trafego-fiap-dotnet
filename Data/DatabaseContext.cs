using fiap.gerenciador_trafego.Models;
using Microsoft.EntityFrameworkCore;

namespace fiap.gerenciador_trafego.Data;

public class DatabaseContext : DbContext
{
    public virtual DbSet<ClimaModel> Clima { get; set; }
    public virtual DbSet<AcidenteModel> Acidente { get; set; }
    public virtual DbSet<RotaModel> Rota { get; set; }
    public virtual DbSet<SensorTrafegoModel> SensorTrafego { get; set; }
    public virtual DbSet<SemaforoModel> Semaforo { get; set; }
    public virtual DbSet<UsuarioModel> Usuario { get; set; }
    
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
        
        // Configurações de Semáforo
        modelBuilder.Entity<SemaforoModel>(entity =>
        {
            entity.ToTable("t_gti_semaforo");
            entity.HasKey(e => e.IdSemaforo).HasName("pk_t_gti_semaforo");
            entity.Property(e => e.IdSemaforo).ValueGeneratedOnAdd();
            entity.Property(e => e.DsEstado).HasDefaultValue("vermelho");
        });

        // Configurações de Acidente
        modelBuilder.Entity<AcidenteModel>(entity =>
        {
            entity.ToTable("t_gti_reg_acidente");
            entity.HasKey(e => e.IdRegAcidente).HasName("pk_t_gti_reg_acidente");
            entity.Property(e => e.IdRegAcidente).ValueGeneratedOnAdd();
        });

        // Configurações de Rota
        modelBuilder.Entity<RotaModel>(entity =>
        {
            entity.ToTable("t_gti_rota");
            entity.HasKey(e => e.IdRota).HasName("pk_t_gti_rota");
            entity.Property(e => e.DsStatus).HasDefaultValue("ABERTA");
        });

        // Configurações de Sensor de Tráfego
        modelBuilder.Entity<SensorTrafegoModel>(entity =>
        {
            entity.ToTable("t_gti_sensor_trafego");
            entity.HasKey(e => e.IdSensor).HasName("pk_t_gti_sensor_trafego");
            entity.Property(e => e.IdSensor).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<UsuarioModel>(entity =>
        {
            entity.ToTable("t_usuario");
            entity.HasKey(e => e.UserID).HasName("pk_t_usuario");
            entity.Property(e => e.UserID).ValueGeneratedOnAdd();
            entity.Property(e => e.Username).IsRequired().HasMaxLength(255);
            entity.Property(e => e.Password).IsRequired().HasMaxLength(255);
            entity.Property(e => e.Role).IsRequired().HasMaxLength(50);
        });
    }
}