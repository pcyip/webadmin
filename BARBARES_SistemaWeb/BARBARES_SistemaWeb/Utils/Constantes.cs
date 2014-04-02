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

        #endregion

        #region Utils

        public const string GetHash = "ABCD";
        public const string LOG_CREAR = "Crear";
        public const string LOG_MODIFICAR = "Modificar";
        public const string LOG_BUSCAR = "Buscar";
        public const string LOG_ACTIVAR = "Activar";
        public const string LOG_DESACTIVAR = "Desactivar";
        public const string LOG_LISTAR = "Listar";
        public const string LOG_LOGIN = "Login";
        public const string LOG_LOGOUT = "Logout";
        public const string ENTORNO_SERVICIOS = "Servicios";
        public const string ENTORNO_SISTEMA = "Sistema";
        public const string ENTORNO_PAGWEB = "PáginaWeb";
        public const string ENTORNO_ANDROID = "Android";
        public const string ENTORNO_IOS = "iOS";
        public const string URL_IMAGENES_BARABARES = "Images/barabares_img/";

        #endregion

        #region URLs Servicios

        //Almacen
        public const string List_Almacen = "http://servicios.apphb.com/Almacen_Services.svc/list_Almacen";
        public const string List_InventarioAlmacen = "http://servicios.apphb.com/Almacen_Services.svc/list_InventarioAlmacen";
        public const string Search_InventarioAlmacen = "http://servicios.apphb.com/Almacen_Services.svc/search_InventarioAlmacen";
        public const string SelectAll_Almacen = "http://servicios.apphb.com/Almacen_Services.svc/selectAll_Almacen";
        public const string Add_Almacen = "http://servicios.apphb.com/Almacen_Services.svc/add_Almacen";
        public const string Search_Almacen = "http://servicios.apphb.com/Almacen_Services.svc/search_Almacen";
        public const string Combo_Almacen = "http://servicios.apphb.com/Almacen_Services.svc/combo_Almacen";

        //Carrito
        public const string SelectAll_Carrito = "http://servicios.apphb.com/Carrito_Services.svc/selectAll_Carrito";
        public const string Add_Carrito = "http://servicios.apphb.com/Carrito_Services.svc/add_Carrito";
        public const string SelectAll_DetalleCarrito = "http://servicios.apphb.com/Carrito_Services.svc/selectAll_DetalleCarrito";
        public const string Add_DetalleCarrito = "http://servicios.apphb.com/Carrito_Services.svc/add_DetalleCarrito";

        //ComprobantePago
        public const string List_Comprobante = "http://servicios.apphb.com/Comprobante_Services.svc/list_Comprobante";
        public const string Search_Comprobante = "http://servicios.apphb.com/Comprobante_Services.svc/search_Comprobante";
        public const string SelectAll_MedioPago = "http://servicios.apphb.com/Comprobante_Services.svc/selectAll_MedioPago";
        public const string Combo_MedioPago = "http://servicios.apphb.com/Comprobante_Services.svc/combo_MedioPago";
        public const string Add_MedioPago = "http://servicios.apphb.com/Comprobante_Services.svc/add_MedioPago";
        public const string SelectAll_TipoComprobante = "http://servicios.apphb.com/Comprobante_Services.svc/selectAll_TipoComprobante";
        public const string Combo_TipoComprobante = "http://servicios.apphb.com/Comprobante_Services.svc/combo_TipoComprobante";
        public const string Add_TipoComprobante = "http://servicios.apphb.com/Comprobante_Services.svc/add_TipoComprobante";
        public const string SelectAll_Comprobante = "http://servicios.apphb.com/Comprobante_Services.svc/selectAll_Comprobante";
        public const string Add_Comprobante = "http://servicios.apphb.com/Comprobante_Services.svc/Add_Comprobante";
        public const string SelectAll_DetalleComprobante = "http://servicios.apphb.com/Comprobante_Services.svc/selectAll_DetalleComprobante";
        public const string Add_DetalleComprobante = "http://servicios.apphb.com/Comprobante_Services.svc/add_DetalleComprobante";
        public const string SelectAll_TipoTarjeta = "http://servicios.apphb.com/Comprobante_Services.svc/selectAll_TipoTarjeta";
        public const string Add_TipoTarjeta = "http://servicios.apphb.com/Comprobante_Services.svc/add_TipoTarjeta";

        //Contraseña
        public const string SelectAll_Contrasena = "http://servicios.apphb.com/Contrasena_Services.svc/selectAll_Contrasena";
        public const string Add_Contrasena = "http://servicios.apphb.com/Contrasena_Services.svc/add_Contrasena";

        //Direccion
        public const string SelectAll_TipoCalle = "http://servicios.apphb.com/Direccion_Services.svc/selectAll_TipoCalle";
        public const string SelectAll_TipoUrb = "http://servicios.apphb.com/Direccion_Services.svc/selectAll_TipoUrb";
        public const string Combo_TipoCalle = "http://servicios.apphb.com/Direccion_Services.svc/combo_TipoCalle";
        public const string Combo_TipoUrb = "http://servicios.apphb.com/Direccion_Services.svc/combo_TipoUrb";
        public const string SelectAll_Departamento = "http://servicios.apphb.com/Direccion_Services.svc/selectAll_Departamento";
        public const string SelectAll_Provincia = "http://servicios.apphb.com/Direccion_Services.svc/selectAll_Provincia";
        public const string SelectByDepartamento_Provincia = "http://servicios.apphb.com/Direccion_Services.svc/selectByDepartamento_Provincia";
        public const string SelectAll_Distrito = "http://servicios.apphb.com/Direccion_Services.svc/selectAll_Distrito";
        public const string SelectByProvincia_Distrito = "http://servicios.apphb.com/Direccion_Services.svc/selectByProvincia_Distrito";
        public const string Add_Direccion = "http://servicios.apphb.com/Direccion_Services.svc/add_Direccion";
        public const string SelectAll_Direccion = "http://servicios.apphb.com/Direccion_Services.svc/selectAll_Direccion";
        public const string Add_Departamento = "http://servicios.apphb.com/Direccion_Services.svc/add_Departamento";
        public const string Add_Provincia = "http://servicios.apphb.com/Direccion_Services.svc/add_Provincia";
        public const string Add_Distrito = "http://servicios.apphb.com/Direccion_Services.svc/add_Distrito";
        public const string Add_TipoCalle = "http://servicios.apphb.com/Direccion_Services.svc/add_TipoCalle";
        public const string Add_TipoUrb = "http://servicios.apphb.com/Direccion_Services.svc/add_TipoUrb";

        //Moneda
        public const string SelectAll_Moneda = "http://servicios.apphb.com/Moneda_Services.svc/selectAll_Moneda";
        public const string Combo_Moneda = "http://servicios.apphb.com/Moneda_Services.svc/combo_Moneda";
        public const string Add_Moneda = "http://servicios.apphb.com/Moneda_Services.svc/add_Moneda";

        //Movimiento
        public const string SelectAll_Movimiento = "http://servicios.apphb.com/Movimiento_Services.svc/selectAll_Movimiento";
        public const string List_Movimiento = "http://servicios.apphb.com/Movimiento_Services.svc/list_Movimiento";
        public const string Search_Movimiento = "http://servicios.apphb.com/Movimiento_Services.svc/search_Movimiento";
        public const string Add_Movimiento = "http://servicios.apphb.com/Movimiento_Services.svc/add_Movimiento";
        public const string SelectAll_DetalleMovimiento = "http://servicios.apphb.com/Movimiento_Services.svc/selectAll_DetalleMovimiento";
        public const string Add_DetalleMovimiento = "http://servicios.apphb.com/Movimiento_Services.svc/add_DetalleMovimiento";
        public const string SelectAll_TipoMovimiento = "http://servicios.apphb.com/Movimiento_Services.svc/selectAll_TipoMovimiento";
        public const string Combo_TipoMovimiento = "http://servicios.apphb.com/Movimiento_Services.svc/combo_TipoMovimiento";
        public const string Add_TipoMovimiento = "http://servicios.apphb.com/Movimiento_Services.svc/add_TipoMovimiento";

        //Parametro
        public const string SelectAll_Parametro = "http://servicios.apphb.com/Parametro_Services.svc/selectAll_Parametro";
        public const string SelectByPadre_Parametro = "http://servicios.apphb.com/Parametro_Services.svc/selectByPadre_Parametro";
        public const string Add_Parametro = "http://servicios.apphb.com/Parametro_Services.svc/add_Parametro";
        public const string SelectAll_ParametrosSeguridad = "http://servicios.apphb.com/Parametro_Services.svc/selectAll_ParametrosSeguridad";
        public const string Add_ParametrosSeguridad = "http://servicios.apphb.com/Parametro_Services.svc/add_ParametrosSeguridad";

        //Pedido
        public const string SelectAll_Pedido = "http://servicios.apphb.com/Pedido_Services.svc/selectAll_Pedido";
        public const string List_Pedido = "http://servicios.apphb.com/Pedido_Services.svc/list_Pedido";
        public const string Search_Pedido = "http://servicios.apphb.com/Pedido_Services.svc/search_Pedido";
        public const string SelectAll_EstadoPedido = "http://servicios.apphb.com/Pedido_Services.svc/selectAll_EstadoPedido";
        public const string Combo_EstadoPedido = "http://servicios.apphb.com/Pedido_Services.svc/combo_EstadoPedido";
        public const string SelectAll_MotivoCancelacion = "http://servicios.apphb.com/Pedido_Services.svc/selectAll_MotivoCancelacion";
        public const string Combo_MotivoCancelacion = "http://servicios.apphb.com/Pedido_Services.svc/combo_MotivoCancelacion";
        public const string SelectAll_DetallePedido = "http://servicios.apphb.com/Pedido_Services.svc/selectAll_DetallePedido";
        public const string Add_Pedido = "http://servicios.apphb.com/Pedido_Services.svc/add_Pedido";
        public const string Add_EstadoPedido = "http://servicios.apphb.com/Pedido_Services.svc/add_EstadoPedido";
        public const string Add_MotivoCancelacion = "http://servicios.apphb.com/Pedido_Services.svc/add_MotivoCancelacion";
        public const string Add_DetallePedido = "http://servicios.apphb.com/Pedido_Services.svc/add_DetallePedido";

        //Perfil
        public const string SelectAll_Perfil = "http://servicios.apphb.com/Perfil_Services.svc/selectAll_Perfil";
        public const string Search_Perfil = "http://servicios.apphb.com/Perfil_Services.svc/search_Perfil";
        public const string SelectByUsuario_Perfil = "http://servicios.apphb.com/Perfil_Services.svc/selectByUsuario_Perfil";
        public const string SelectByUsuario_Sistema_Perfil = "http://servicios.apphb.com/Perfil_Services.svc/selectByUsuario_Sistema_Perfil";
        public const string SelectById_Perfil = "http://servicios.apphb.com/Perfil_Services.svc/selectById_Perfil";
        public const string Add_Perfil = "http://servicios.apphb.com/Perfil_Services.svc/add_Perfil";
        public const string Add_PerfilXUsuario = "http://servicios.apphb.com/Perfil_Services.svc/add_PerfilXUsuario";
        public const string SelectAll_PerfilXUsuario = "http://servicios.apphb.com/Perfil_Services.svc/selectAll_PerfilXUsuario";

        //Persona
        public const string SelectAll_Persona = "http://servicios.apphb.com/Persona_Services.svc/selectAll_Persona";
        public const string SelectByTipo_Persona = "http://servicios.apphb.com/Persona_Services.svc/selectByTipo_Persona";
        public const string Search_Persona = "http://servicios.apphb.com/Persona_Services.svc/search_Persona";
        public const string Add_Persona = "http://servicios.apphb.com/Persona_Services.svc/add_Persona";
        public const string SelectAll_TipoDocumento = "http://servicios.apphb.com/Persona_Services.svc/selectAll_TipoDocumento";
        public const string Combo_TipoDocumento = "http://servicios.apphb.com/Persona_Services.svc/combo_TipoDocumento";
        public const string Add_TipoDocumento = "http://servicios.apphb.com/Persona_Services.svc/add_TipoDocumento";
        public const string SelectAll_TipoPersona = "http://servicios.apphb.com/Persona_Services.svc/selectAll_TipoPersona";
        public const string Add_TipoPersona = "http://servicios.apphb.com/Persona_Services.svc/add_TipoPersona";

        //Producto
        public const string SelectAll_Producto = "http://servicios.apphb.com/Producto_Services.svc/selectAll_Producto";
        public const string SelectByTipo_Producto = "http://servicios.apphb.com/Producto_Services.svc/selectByTipo_Producto";
        public const string SelectById_Producto = "http://servicios.apphb.com/Producto_Services.svc/selectById_Producto";
        public const string Search_Producto = "http://servicios.apphb.com/Producto_Services.svc/search_Producto";
        public const string Add_Producto = "http://servicios.apphb.com/Producto_Services.svc/add_Producto";
        public const string SelectAll_UnidadProducto = "http://servicios.apphb.com/Producto_Services.svc/selectAll_UnidadProducto";
        public const string Combo_UnidadProducto = "http://servicios.apphb.com/Producto_Services.svc/combo_UnidadProducto";
        public const string SelectAll_TipoProducto = "http://servicios.apphb.com/Producto_Services.svc/selectAll_TipoProducto";
        public const string Add_UnidadProducto = "http://servicios.apphb.com/Producto_Services.svc/add_UnidadProducto";
        public const string Add_TipoProducto = "http://servicios.apphb.com/Producto_Services.svc/add_TipoProducto";
        public const string SelectAll_ProductoXAlmacen = "http://servicios.apphb.com/Producto_Services.svc/selectAll_ProductoXAlmacen";
        public const string SelectAll_ProductoXVehiculo = "http://servicios.apphb.com/Producto_Services.svc/selectAll_ProductoXVehiculo";
        public const string Add_ProductoXAlmacen = "http://servicios.apphb.com/Producto_Services.svc/add_ProductoXAlmacen";
        public const string Add_ProductoXVehiculo = "http://servicios.apphb.com/Producto_Services.svc/add_ProductoXVehiculo";

        //Promocion
        public const string Add_Promocion = "http://servicios.apphb.com/Promocion_Services.svc/add_Promocion";
        public const string Add_DetallePromocion = "http://servicios.apphb.com/Promocion_Services.svc/add_DetallePromocion";
        public const string SelectAll_Promocion = "http://servicios.apphb.com/Promocion_Services.svc/selectAll_Promocion";
        public const string Semana_Promocion = "http://servicios.apphb.com/Promocion_Services.svc/semana_Promocion";
        public const string Search_Promocion = "http://servicios.apphb.com/Promocion_Services.svc/search_Promocion";
        public const string SelectAll_DetallePromocion = "http://servicios.apphb.com/Promocion_Services.svc/selectAll_DetallePromocion";
        public const string List_web_Promocion = "http://servicios.apphb.com/Promocion_Services.svc/list_web_Promocion";

        //Rol
        public const string SelectAll_Rol = "http://servicios.apphb.com/Rol_Services.svc/selectAll_Rol";
        public const string SelectById_Rol = "http://servicios.apphb.com/Rol_Services.svc/selectById_Rol";
        public const string SelectAll_RolXPerfil = "http://servicios.apphb.com/Rol_Services.svc/selectAll_RolXPerfil";
        public const string Add_RolXPerfil = "http://servicios.apphb.com/Rol_Services.svc/add_RolXPerfil";
        public const string Add_Rol = "http://servicios.apphb.com/Rol_Services.svc/add_Rol";

        //Tienda
        public const string List_Tienda = "http://servicios.apphb.com/Tienda_Services.svc/list_Tienda";
        public const string SelectAll_Tienda = "http://servicios.apphb.com/Tienda_Services.svc/selectAll_Tienda";
        public const string Combo_Tienda = "http://servicios.apphb.com/Tienda_Services.svc/combo_Tienda";
        public const string Search_Tienda = "http://servicios.apphb.com/Tienda_Services.svc/search_Tienda";
        public const string Add_Tienda = "http://servicios.apphb.com/Tienda_Services.svc/add_Tienda";

        //Usuario
        public const string SelectAll_Usuario = "http://servicios.apphb.com/Usuario_Services.svc/selectAll_Usuario";
        public const string Combo_Usuario = "http://servicios.apphb.com/Usuario_Services.svc/combo_Usuario";
        public const string Search_Usuario = "http://servicios.apphb.com/Usuario_Services.svc/search_Usuario";
        public const string List_Usuario = "http://servicios.apphb.com/Usuario_Services.svc/list_Usuario";
        public const string List_LogUsuario = "http://servicios.apphb.com/Usuario_Services.svc/list_LogUsuario";
        public const string SelectAll_LogUsuario = "http://servicios.apphb.com/Usuario_Services.svc/selectAll_LogUsuario";
        public const string Search_LogUsuario = "http://servicios.apphb.com/Usuario_Services.svc/search_LogUsuario";
        public const string Login_Usuario = "http://servicios.apphb.com/Usuario_Services.svc/login_Usuario";
        public const string Logout_Usuario = "http://servicios.apphb.com/Usuario_Services.svc/logout_Usuario";
        public const string Add_Usuario = "http://servicios.apphb.com/Usuario_Services.svc/add_Usuario";
        public const string Add_LogUsuario = "http://servicios.apphb.com/Usuario_Services.svc/add_LogUsuario";
        public const string Add_LogBarabares = "http://servicios.apphb.com/Usuario_Services.svc/add_LogBarabares";

        //Vehiculo
        public const string List_Vehiculo = "http://servicios.apphb.com/Vehiculo_Services.svc/list_Vehiculo";
        public const string SelectAll_Vehiculo = "http://servicios.apphb.com/Vehiculo_Services.svc/selectAll_Vehiculo";
        public const string Combo_Vehiculo = "http://servicios.apphb.com/Vehiculo_Services.svc/combo_Vehiculo";
        public const string List_InventarioVehiculo = "http://servicios.apphb.com/Vehiculo_Services.svc/list_InventarioVehiculo";
        public const string Search_InventarioVehiculo = "http://servicios.apphb.com/Vehiculo_Services.svc/search_InventarioVehiculo";
        public const string Search_Vehiculo = "http://servicios.apphb.com/Vehiculo_Services.svc/search_Vehiculo";
        public const string Add_Vehiculo = "http://servicios.apphb.com/Vehiculo_Services.svc/add_Vehiculo";
        public const string SelectAll_Marca = "http://servicios.apphb.com/Vehiculo_Services.svc/selectAll_Marca";
        public const string SelectByMarca_Modelo = "http://servicios.apphb.com/Vehiculo_Services.svc/selectByMarca_Modelo";
        public const string Combo_Marca = "http://servicios.apphb.com/Vehiculo_Services.svc/combo_Marca";
        public const string Combo_Modelo = "http://servicios.apphb.com/Vehiculo_Services.svc/combo_Modelo";

        #endregion

        #region Flujo BD

        public const string OK = "OK";
        public const string ERROR = "ERROR";
        public const string FALLA = "FALLA";

        #endregion

    }
}