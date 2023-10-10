using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace tarjetacredito.Models;

public partial class TcreditosContext : DbContext
{
    public TcreditosContext()
    {
    }

    public TcreditosContext(DbContextOptions<TcreditosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Movimiento> Movimientos { get; set; }

    public virtual DbSet<Tarjeta> Tarjetas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Activo).HasColumnName("activo");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(64)
                .HasColumnName("apellidos");
            entity.Property(e => e.Nombres)
                .HasMaxLength(64)
                .HasColumnName("nombres");
        });

        modelBuilder.Entity<Movimiento>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .HasColumnName("descripcion");
            entity.Property(e => e.FTransaccion)
                .HasColumnType("datetime")
                .HasColumnName("fTransaccion");
            entity.Property(e => e.IdTarjeta).HasColumnName("idTarjeta");
            entity.Property(e => e.Monto).HasColumnType("decimal(12, 2)");

            entity.HasOne(d => d.IdTarjetaNavigation).WithMany(p => p.Movimientos)
                .HasForeignKey(d => d.IdTarjeta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Movimientos_tarjetas");
        });

        modelBuilder.Entity<Tarjeta>(entity =>
        {
            entity.ToTable("tarjetas");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Activa).HasColumnName("activa");
            entity.Property(e => e.Disponible)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("disponible");
            entity.Property(e => e.FVencimiento)
                .HasMaxLength(64)
                .HasColumnName("fVencimiento");
            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.Limite)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("limite");
            entity.Property(e => e.NTarjeta)
                .HasMaxLength(64)
                .HasColumnName("nTarjeta");
            entity.Property(e => e.Nombre)
                .HasMaxLength(64)
                .HasColumnName("nombre");
            entity.Property(e => e.PContado)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("pContado");
            entity.Property(e => e.PMinimo)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("pMinimo");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Tarjeta)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tarjetas_Clientes");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

}
