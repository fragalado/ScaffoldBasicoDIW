using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ScaffoldingDIW.Models;

public partial class GestorBibliotecaPersonalContext : DbContext
{
    public GestorBibliotecaPersonalContext()
    {
    }

    public GestorBibliotecaPersonalContext(DbContextOptions<GestorBibliotecaPersonalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<GbpAlmCatLibro> GbpAlmCatLibros { get; set; }

    public virtual DbSet<Prueba> Pruebas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Name=ConnectionStrings:Connection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GbpAlmCatLibro>(entity =>
        {
            entity.HasKey(e => e.IdLibro).HasName("gbp_alm_cat_libros_pkey");

            entity.ToTable("gbp_alm_cat_libros", "gbp_almacen");

            entity.Property(e => e.IdLibro)
                .HasDefaultValueSql("nextval('gbp_alm_cat_libros_id_libro_seq'::regclass)")
                .HasColumnName("id_libro");
            entity.Property(e => e.Autor)
                .HasColumnType("character varying")
                .HasColumnName("autor");
            entity.Property(e => e.Edicion).HasColumnName("edicion");
            entity.Property(e => e.Isbn)
                .HasColumnType("character varying")
                .HasColumnName("isbn");
            entity.Property(e => e.Titulo)
                .HasColumnType("character varying")
                .HasColumnName("titulo");
        });

        modelBuilder.Entity<Prueba>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("prueba_pkey");

            entity.ToTable("prueba", "gbp_almacen");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('prueba_id_seq'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.Apellidos)
                .HasColumnType("character varying")
                .HasColumnName("apellidos");
            entity.Property(e => e.EsProgramador).HasColumnName("esProgramador");
            entity.Property(e => e.Nombre)
                .HasColumnType("character varying")
                .HasColumnName("nombre");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
