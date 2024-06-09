using Microsoft.EntityFrameworkCore;
using PrimerParcial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1;
[TestFixture]
public class ComercioContextTests
{
    private ComercioContext _context;

    [SetUp]
    public void Setup()
    {
        var options = new DbContextOptionsBuilder<ComercioContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        _context = new ComercioContext(options);
    }

    [Test]
    public void CanAddCliente()
    {
        // Arrange
        var cliente = new Cliente
        {
            Nombre = "Juan Perez",
            Email = "juan.perez@example.com",
            Contrasena = "password123",
            Telefono = "555-5555"
        };

        // Act
        _context.Clientes.Add(cliente);
        _context.SaveChanges();

        // Assert
        var clienteFromDb = _context.Clientes.FirstOrDefault(c => c.Email == "juan.perez@example.com");
        Assert.NotNull(clienteFromDb);
        Assert.AreEqual("Juan Perez", clienteFromDb.Nombre);
    }

    [Test]
    public void CanAddProductoAndCategoria()
    {
        // Arrange
        var producto = new Producto
        {
            Nombre = "Camiseta",
            Descripcion = "Camiseta de algodón",
            Precio = 15.99M,
            Stock = 100
        };

        var categoria = new Categorium
        {
            Nombre = "Ropa"
        };

        _context.Productos.Add(producto);
        _context.Categoria.Add(categoria);
        _context.SaveChanges();

        var productoCategoria = new ProductoCategoria
        {
            ProductoId = producto.Id,
            CategoriaId = categoria.Id
        };

        // Act
        _context.ProductoCategorias.Add(productoCategoria);
        _context.SaveChanges();

        // Assert
        var productoFromDb = _context.Productos
            .Include(p => p.ProductoCategorias)
            .ThenInclude(pc => pc.Categoria)
            .FirstOrDefault(p => p.Nombre == "Camiseta");

        Assert.NotNull(productoFromDb);
        Assert.AreEqual(1, productoFromDb.ProductoCategorias.Count);
        Assert.AreEqual("Ropa", productoFromDb.ProductoCategorias.First().Categoria.Nombre);
    }

    [Test]
    public void CanAddPedidoWithDetallePedido()
    {
        // Arrange
        var cliente = new Cliente
        {
            Nombre = "Maria Lopez",
            Email = "maria.lopez@example.com",
            Contrasena = "password123",
            Telefono = "555-5555"
        };

        var producto = new Producto
        {
            Nombre = "Pantalones",
            Descripcion = "Pantalones de mezclilla",
            Precio = 29.99M,
            Stock = 50
        };

        _context.Clientes.Add(cliente);
        _context.Productos.Add(producto);
        _context.SaveChanges();

        var pedido = new Pedido
        {
            ClienteId = cliente.Id,
            FechaPedido = DateTime.Now,
            Estado = "Pendiente",
            Total = 59.98M
        };

        var detallePedido = new DetallePedido
        {
            PedidoId = pedido.Id,
            ProductoId = producto.Id,
            Precio = 29.99M,
            Cantidad = 2
        };

        // Act
        _context.Pedidos.Add(pedido);
        _context.DetallePedidos.Add(detallePedido);
        _context.SaveChanges();

        // Assert
        var pedidoFromDb = _context.Pedidos
            .Include(p => p.DetallePedidos)
            .ThenInclude(dp => dp.Producto)
            .FirstOrDefault(p => p.Cliente.Email == "maria.lopez@example.com");

        Assert.NotNull(pedidoFromDb);
        Assert.AreEqual(1, pedidoFromDb.DetallePedidos.Count);
        Assert.AreEqual("Pantalones", pedidoFromDb.DetallePedidos.First().Producto.Nombre);
        Assert.AreEqual(2, pedidoFromDb.DetallePedidos.First().Cantidad);
    }

    [TearDown]
    public void TearDown()
    {
        _context.Database.EnsureDeleted();
        _context.Dispose();
    }
}