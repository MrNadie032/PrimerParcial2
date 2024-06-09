using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PrimerParcial.Models;

public partial class ComercioContext : DbContext
{
    public ComercioContext()
    {
    }

    public ComercioContext(DbContextOptions<ComercioContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Carrito> Carritos { get; set; }
    public virtual DbSet<Categorium> Categoria { get; set; }
    public virtual DbSet<Cliente> Clientes { get; set; }
    public virtual DbSet<DetallePedido> DetallePedidos { get; set; }
    public virtual DbSet<Direccion> Direccions { get; set; }
    public virtual DbSet<Pago> Pagos { get; set; }
    public virtual DbSet<Pedido> Pedidos { get; set; }
    public virtual DbSet<Producto> Productos { get; set; }
    public virtual DbSet<ProductoCategoria> ProductoCategorias { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=EMMANUELG\\SQLEXPRESS01;Database=Comercio;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Carrito>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Carrito__3214EC27C4840FA9");

            entity.ToTable("Carrito");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Actualizado).HasColumnType("datetime");
            entity.Property(e => e.ClienteId).HasColumnName("cliente_id");
            entity.Property(e => e.Creado).HasColumnType("datetime");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Carritos)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("FK__Carrito__cliente__5AEE82B9");
        });

        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Categori__3214EC27B8F407DB");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cliente__3214EC27C4097D7D");

            entity.ToTable("Cliente");

            entity.HasIndex(e => e.Email, "UQ__Cliente__A9D1053401AC34E8").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Contrasena).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.Nombre).HasMaxLength(150);
            entity.Property(e => e.Telefono).HasMaxLength(20);
        });

        modelBuilder.Entity<DetallePedido>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DetalleP__3214EC275BD29DE7");

            entity.ToTable("DetallePedido");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.PedidoId).HasColumnName("Pedido_Id");
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ProductoId).HasColumnName("Producto_ID");

            entity.HasOne(d => d.Pedido).WithMany(p => p.DetallePedidos)
                .HasForeignKey(d => d.PedidoId)
                .HasConstraintName("FK__DetallePe__Pedid__571DF1D5");

            entity.HasOne(d => d.Producto).WithMany(p => p.DetallePedidos)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("FK__DetallePe__Produ__5812160E");
        });

        modelBuilder.Entity<Direccion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Direccio__3213E83F51ADA4E7");

            entity.ToTable("Direccion");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Calle).HasMaxLength(255);
            entity.Property(e => e.Ciudad).HasMaxLength(100);
            entity.Property(e => e.ClienteId).HasColumnName("Cliente_id");
            entity.Property(e => e.CodigoPostal)
                .HasMaxLength(5)
                .HasColumnName("Codigo_Postal");
            entity.Property(e => e.Estado).HasMaxLength(100);
            entity.Property(e => e.Pais)
                .HasMaxLength(100)
                .HasColumnName("pais");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Direccions)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("FK__Direccion__Clien__5DCAEF64");
        });

        modelBuilder.Entity<Pago>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Pago__3214EC27A443426A");

            entity.ToTable("Pago");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Estatus).HasMaxLength(50);
            entity.Property(e => e.FechaPago)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_pago");
            entity.Property(e => e.Metodo).HasMaxLength(50);
            entity.Property(e => e.Monto).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PedidoId).HasColumnName("Pedido_id");

            entity.HasOne(d => d.Pedido).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.PedidoId)
                .HasConstraintName("FK__Pago__Pedido_id__60A75C0F");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Pedido__3214EC272D21AECB");

            entity.ToTable("Pedido");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ClienteId).HasColumnName("Cliente_id");
            entity.Property(e => e.Estado).HasMaxLength(50);
            entity.Property(e => e.FechaPedido)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Pedido");
            entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("FK__Pedido__Cliente___5441852A");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Producto__3214EC27DF61792D");

            entity.ToTable("Producto");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.Nombre).HasMaxLength(255);
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Stock).HasColumnName("Stock");

            entity.HasMany(d => d.Categoria).WithMany(p => p.Productos)
                .UsingEntity<ProductoCategoria>(
                    j => j
                        .HasOne(pt => pt.Categoria)
                        .WithMany(t => t.ProductoCategorias)
                        .HasForeignKey(pt => pt.CategoriaId),
                    j => j
                        .HasOne(pt => pt.Producto)
                        .WithMany(p => p.ProductoCategorias)
                        .HasForeignKey(pt => pt.ProductoId),
                    j =>
                    {
                        j.HasKey(t => new { t.ProductoId, t.CategoriaId });
                        j.ToTable("ProductoCategoria");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

