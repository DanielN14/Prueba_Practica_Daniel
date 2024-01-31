using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using UserRegistryApp.Models;

namespace UserRegistryApp.DataAccess;

public partial class UserRegistryAppContext : DbContext
{
    public UserRegistryAppContext()
    {
    }

    public UserRegistryAppContext(DbContextOptions<UserRegistryAppContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TestHabilidadesBlanda> TestHabilidadesBlandas { get; set; }

    public virtual DbSet<TestHabilidadesBlandasXusuario> TestHabilidadesBlandasXusuarios { get; set; }

    public virtual DbSet<TestRole> TestRoles { get; set; }

    public virtual DbSet<TestTelefono> TestTelefonos { get; set; }

    public virtual DbSet<TestUsuario> TestUsuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:UserRegistryApp");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TestHabilidadesBlanda>(entity =>
        {
            entity.HasKey(e => e.IdHabilidadBlanda);

            entity.ToTable("test_HabilidadesBlandas");

            entity.Property(e => e.NombreHabilidadBlanda)
                .HasMaxLength(40)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TestHabilidadesBlandasXusuario>(entity =>
        {
            entity.HasKey(e => new { e.IdHabilidadBlanda, e.IdUsuario });

            entity.ToTable("test_HabilidadesBlandasXUsuario");

            entity.HasOne(d => d.IdHabilidadBlandaNavigation).WithMany(p => p.TestHabilidadesBlandasXusuarios)
                .HasForeignKey(d => d.IdHabilidadBlanda)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__test_Habi__IdHab__59063A47");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.TestHabilidadesBlandasXusuarios)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__test_Habi__IdUsu__59FA5E80");
        });

        modelBuilder.Entity<TestRole>(entity =>
        {
            entity.HasKey(e => e.IdRolUsuario);

            entity.ToTable("test_Roles");

            entity.Property(e => e.NombreRol)
                .HasMaxLength(40)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TestTelefono>(entity =>
        {
            entity.HasKey(e => new { e.IdTelefono, e.IdUsuario });

            entity.ToTable("test_Telefonos");

            entity.Property(e => e.IdTelefono).ValueGeneratedOnAdd();
            entity.Property(e => e.NumeroTelefono)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.TestTelefonos)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__test_Tele__IdUsu__5812160E");
        });

        modelBuilder.Entity<TestUsuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK_test_Users");

            entity.ToTable("test_Usuarios");

            entity.HasIndex(e => e.Identificacion, "UQ__test_Usu__D6F931E5406BA597").IsUnique();

            entity.Property(e => e.Clave)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Identificacion)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PrimerApellido)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.SegundoApellido)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.TipoIdentificacion)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.HasOne(d => d.IdRolUsuarioNavigation).WithMany(p => p.TestUsuarios)
                .HasForeignKey(d => d.IdRolUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__test_Usua__IdRol__571DF1D5");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
