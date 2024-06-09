using AutoMapper;
using PrimerParcial.Models.DTOs.Carritos;
using PrimerParcial.Models.DTOs.Categorium;
using PrimerParcial.Models.DTOs.Cliente;
using PrimerParcial.Models.DTOs.DetallePedido;
using PrimerParcial.Models.DTOs.Direccion;
using PrimerParcial.Models.DTOs.Pago;
using PrimerParcial.Models.DTOs.Pedido;
using PrimerParcial.Models.DTOs.Producto;

namespace PrimerParcial.Models.DTOs
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CarritoGetDTO, Models.Carrito>().ReverseMap();
            CreateMap<CarritoInsertDTO, Models.Carrito>().ReverseMap();
            CreateMap<CarritoUpdateDTO, Models.Carrito>().ReverseMap();

            CreateMap<CategoriumGetDTO, Models.Categorium>().ReverseMap();
            CreateMap<CategoriumInsertDTO, Models.Categorium>().ReverseMap();
            CreateMap<CategoriumUpdateDTO, Models.Categorium>().ReverseMap();

            CreateMap<ClienteGetDTO, Models.Cliente>().ReverseMap();
            CreateMap<ClienteInsertDTO, Models.Cliente>().ReverseMap();
            CreateMap<ClienteUpdateDTO, Models.Cliente>().ReverseMap();

            CreateMap<DetallePedidoGetDTO, Models.DetallePedido>().ReverseMap();
            CreateMap<DetallePedidoInsertDTO, Models.DetallePedido>().ReverseMap();
            CreateMap<DetallePedidoUpdateDTO, Models.DetallePedido>().ReverseMap();

            CreateMap<DirreccionGetDTO, Models.Direccion>().ReverseMap();
            CreateMap<DirreccionInsertDTO, Models.Direccion>().ReverseMap();
            CreateMap<DirreccionUpdateDTO, Models.Direccion>().ReverseMap();

            CreateMap<PagoGetDTO, Models.Pago>().ReverseMap();
            CreateMap<PagoInsertDTO, Models.Pago>().ReverseMap();
            CreateMap<PagoUpdateDTO, Models.Pago>().ReverseMap();

            CreateMap<PedidoGetDTO, Models.Pedido>().ReverseMap();
            CreateMap<PedidoInsertDTO, Models.Pedido>().ReverseMap();
            CreateMap<PedidoUpdateDTO, Models.Pedido>().ReverseMap();

            CreateMap<ProductoGetDTO, Models.Producto>().ReverseMap();
            CreateMap<ProductoInsertDTO, Models.Producto>().ReverseMap();
            CreateMap<ProductoUpdateDTO, Models.Producto>().ReverseMap();

        }
    }
}
