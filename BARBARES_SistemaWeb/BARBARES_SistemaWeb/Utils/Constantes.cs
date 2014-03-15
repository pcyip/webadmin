using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BARBARES_SistemaWeb.Utils
{
    public class Constantes
    {
        #region Consumo Web Service

        public const string PostMethod = "POST";
        public const string GetMethod = "GET";
        public const string ContentType = "application/json";
        public const string GetHash = "ABCD";

        #endregion

        #region URLs Servicios

        //Almacen
        public const string List_Almacen = "http://servicios.apphb.com/Almacen_Services.svc/list_Almacen";
        public const string List_InventarioAlmacen = "http://servicios.apphb.com/Almacen_Services.svc/list_InventarioAlmacen";
        public const string SelectAll_Almacen = "http://servicios.apphb.com/Almacen_Services.svc/selectAll_Almacen";
        public const string Add_Almacen = "http://servicios.apphb.com/Almacen_Services.svc/add_Almacen";
        public const string Search_Almacen = "http://servicios.apphb.com/Almacen_Services.svc/search_Almacen";

        //ComprobantePago
        public const string List_Comprobante = "http://servicios.apphb.com/Comprobante_Services.svc/list_Comprobante";
        public const string Search_Comprobante = "http://servicios.apphb.com/Comprobante_Services.svc/search_Comprobante";
        public const string SelectAll_MedioPago = "http://servicios.apphb.com/Comprobante_Services.svc/selectAll_MedioPago";
        public const string SelectAll_TipoComprobante = "http://servicios.apphb.com/Comprobante_Services.svc/selectAll_TipoComprobante";
      
        //Direccion
        public const string SelectAll_TipoCalle = "http://servicios.apphb.com/Direccion_Services.svc/selectAll_TipoCalle";
        public const string SelectAll_TipoUrb = "http://servicios.apphb.com/Direccion_Services.svc/selectAll_TipoUrb";
        public const string SelectAll_Departamento = "http://servicios.apphb.com/Direccion_Services.svc/selectAll_Departamento";
        public const string SelectAll_Provincia = "http://servicios.apphb.com/Direccion_Services.svc/selectAll_Provincia";
        public const string SelectByDepartamento_Provincia = "http://servicios.apphb.com/Direccion_Services.svc/selectByDepartamento_Provincia";
        public const string SelectAll_Distrito = "http://servicios.apphb.com/Direccion_Services.svc/selectAll_Distrito";
        public const string SelectByProvincia_Distrito = "http://servicios.apphb.com/Direccion_Services.svc/selectByProvincia_Distrito";
        public const string Add_Direccion = "http://servicios.apphb.com/Direccion_Services.svc/add_Direccion";

        //Pedido
        public const string SelectAll_Pedido = "http://servicios.apphb.com/Pedido_Services.svc/selectAll_Pedido";
        public const string List_Pedido = "http://servicios.apphb.com/Pedido_Services.svc/list_Pedido";
        public const string Search_Pedido = "http://servicios.apphb.com/Pedido_Services.svc/search_Pedido";
        public const string SelectAll_EstadoPedido = "http://servicios.apphb.com/Pedido_Services.svc/selectAll_EstadoPedido";
        public const string SelectAll_MotivoCancelacion = "http://servicios.apphb.com/Pedido_Services.svc/selectAll_MotivoCancelacion";

        //Perfil
        public const string SelectAll_Perfil = "http://servicios.apphb.com/Perfil_Services.svc/selectAll_Perfil";
        public const string Search_Perfil = "http://servicios.apphb.com/Perfil_Services.svc/search_Perfil";
        public const string SelectByUsuario_Perfil = "http://servicios.apphb.com/Perfil_Services.svc/selectByUsuario_Perfil";
        public const string SelectById_Perfil = "http://servicios.apphb.com/Perfil_Services.svc/selectById_Perfil";
        public const string Add_Perfil = "http://servicios.apphb.com/Perfil_Services.svc/add_Perfil";
        public const string Add_PerfilXUsuario = "http://servicios.apphb.com/Perfil_Services.svc/add_PerfilXUsuario";

        //Persona
        public const string SelectAll_Persona = "http://servicios.apphb.com/Persona_Services.svc/selectAll_Persona";
        public const string SelectByTipo_Persona = "http://servicios.apphb.com/Persona_Services.svc/selectByTipo_Persona";
        public const string Search_Persona = "http://servicios.apphb.com/Persona_Services.svc/search_Persona";
        public const string Add_Persona = "http://servicios.apphb.com/Persona_Services.svc/add_Persona";
        public const string SelectAll_TipoDocumento = "http://servicios.apphb.com/Persona_Services.svc/selectAll_TipoDocumento";

        //Producto
        public const string SelectAll_Producto = "http://servicios.apphb.com/Producto_Services.svc/selectAll_Producto";
        public const string SelectByTipo_Producto = "http://servicios.apphb.com/Producto_Services.svc/selectByTipo_Producto";
        public const string SelectById_Producto = "http://servicios.apphb.com/Producto_Services.svc/selectById_Producto";
        public const string Search_Producto = "http://servicios.apphb.com/Producto_Services.svc/search_Producto";
        public const string Add_Producto = "http://servicios.apphb.com/Producto_Services.svc/add_Producto";
        public const string SelectAll_UnidadProducto = "http://servicios.apphb.com/Producto_Services.svc/selectAll_UnidadProducto";

        //Promocion
        public const string Add_Promocion = "http://servicios.apphb.com/Promocion_Services.svc/add_Promocion";
        public const string Add_DetallePromocion = "http://servicios.apphb.com/Promocion_Services.svc/add_DetallePromocion";

        //Rol
        public const string SelectAll_Rol = "http://servicios.apphb.com/Rol_Services.svc/selectAll_Rol";
        public const string SelectById_Rol = "http://servicios.apphb.com/Rol_Services.svc/selectById_Rol";
        public const string Add_RolXPerfil = "http://servicios.apphb.com/Rol_Services.svc/add_RolXPerfil";

        //Tienda
        public const string List_Tienda = "http://servicios.apphb.com/Tienda_Services.svc/list_Tienda";
        public const string SelectAll_Tienda = "http://servicios.apphb.com/Tienda_Services.svc/selectAll_Tienda";
        public const string Search_Tienda = "http://servicios.apphb.com/Tienda_Services.svc/search_Tienda";

        //Usuario
        public const string SelectAll_Usuario = "http://servicios.apphb.com/Usuario_Services.svc/selectAll_Usuario";
        public const string Search_Usuario = "http://servicios.apphb.com/Usuario_Services.svc/search_Usuario";
        public const string List_Usuario = "http://servicios.apphb.com/Usuario_Services.svc/list_Usuario";
        public const string List_LogUsuario = "http://servicios.apphb.com/Usuario_Services.svc/list_LogUsuario";
        public const string SelectAll_LogUsuario = "http://servicios.apphb.com/Usuario_Services.svc/selectAll_LogUsuario";
        public const string Search_LogUsuario = "http://servicios.apphb.com/Usuario_Services.svc/search_LogUsuario";
        public const string Login_Usuario = "http://servicios.apphb.com/Usuario_Services.svc/login_Usuario";
        public const string Add_Usuario = "http://servicios.apphb.com/Usuario_Services.svc/add_Usuario";

        //Vehiculo
        public const string List_Vehiculo = "http://servicios.apphb.com/Vehiculo_Services.svc/list_Vehiculo";
        public const string SelectAll_Vehiculo = "http://servicios.apphb.com/Vehiculo_Services.svc/selectAll_Vehiculo";
        public const string List_InventarioVehiculo = "http://servicios.apphb.com/Vehiculo_Services.svc/list_InventarioVehiculo";
        public const string Search_Vehiculo = "http://servicios.apphb.com/Vehiculo_Services.svc/search_Vehiculo";
        public const string Add_Vehiculo = "http://servicios.apphb.com/Vehiculo_Services.svc/add_Vehiculo";
        public const string SelectAll_Marca = "http://servicios.apphb.com/Vehiculo_Services.svc/selectAll_Marca";
        public const string SelectByMarca_Modelo = "http://servicios.apphb.com/Vehiculo_Services.svc/selectByMarca_Modelo";

        #endregion

        #region Flujo BD

        public const string OK = "OK";
        public const string ERROR = "ERROR";
        public const string FALLA = "FALLA";

        #endregion
    }
}