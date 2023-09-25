using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace sistema_unidades.Models;

public partial class ClienteBdContext : DbContext
{
    public ClienteBdContext()
    {
    }

    public ClienteBdContext(DbContextOptions<ClienteBdContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Periodo> Periodos { get; set; }

    public virtual DbSet<Tipo> Tipos { get; set; }

    public virtual DbSet<Unidad> Unidads { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured) 
        {
            //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            //        => optionsBuilder.UseSqlServer("Server=DESKTOP-AQT87V9\\SQLEXPRESS; Database=cliente_bd; Trusted_Connection=True; TrustServerCertificate=True; Encrypt=False;");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.ToTable("cliente");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono).HasColumnName("telefono");
        });

        modelBuilder.Entity<Periodo>(entity =>
        {
            entity.ToTable("periodo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Mes)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("mes");
        });

        modelBuilder.Entity<Tipo>(entity =>
        {
            entity.ToTable("tipo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Tipo1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tipo");
        });

        modelBuilder.Entity<Unidad>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_registro");

            entity.ToTable("unidad");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Fecha)
                .HasColumnType("date")
                .HasColumnName("fecha");
            entity.Property(e => e.Folio).HasColumnName("folio");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.IdPeriodo).HasColumnName("id_periodo");
            entity.Property(e => e.IdTipo).HasColumnName("id_tipo");
            entity.Property(e => e.NSerie)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("n_serie");
            entity.Property(e => e.Placa)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("placa");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Unidads)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_registro_cliente");

            entity.HasOne(d => d.IdPeriodoNavigation).WithMany(p => p.Unidads)
                .HasForeignKey(d => d.IdPeriodo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_unidad_periodo");

            entity.HasOne(d => d.IdTipoNavigation).WithMany(p => p.Unidads)
                .HasForeignKey(d => d.IdTipo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_unidad_tipo");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
