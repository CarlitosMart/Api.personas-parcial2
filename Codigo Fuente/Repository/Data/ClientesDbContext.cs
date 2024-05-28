using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Repository.Models.BD;

namespace Repository.Data
{
    public partial class ClientesDbContext : DbContext
    {
        public ClientesDbContext()
        {
        }

        public ClientesDbContext(DbContextOptions<ClientesDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Factura> Facturas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=PC-ETER\\SQLEXPRESS; Database=OPTATIVO_V; Trusted_Connection=True; trustservercertificate=True;MultipleActiveResultSets=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Cliente");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Celular)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Documento)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdBanco)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Id_banco");

                entity.Property(e => e.Mail)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.ToTable("Factura");

                entity.Property(e => e.FechaHora)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Fecha_hora");

                entity.Property(e => e.IdCliente).HasColumnName("Id_cliente");

                entity.Property(e => e.NroFactura)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nro_factura");

                entity.Property(e => e.Sucursal)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Total)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TotalIva)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Total_iva");

                entity.Property(e => e.TotalIva10)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Total_iva10");

                entity.Property(e => e.TotalIva5)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Total_iva5");

                entity.Property(e => e.TotalLetras)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Total_letras");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Factura_Cliente");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
