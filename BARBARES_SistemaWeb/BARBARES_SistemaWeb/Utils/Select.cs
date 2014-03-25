﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BARBARES_SistemaWeb.Utils
{
    public class Select
    {
        public class Almacen
        {
            public int IdAlmacen { get; set; }
            public string Descripcion { get; set; }
            public int Capacidad { get; set; }
            public DateTime Fecha { get; set; }
            public string Departamento { get; set; }
            public string Provincia { get; set; }
            public string Distrito { get; set; }
            public string Tienda { get; set; }
        }

        public class Combo
        {
            public int id { get; set; }
            public string value { get; set; }
        }

        public class ComprobantePago
        {
            public int IdComprobante { get; set; }
            public int Numero { get; set; }
            public string Cliente { get; set; }
            public string Moneda { get; set; }
            public double Total { get; set; }
            public DateTime Fecha { get; set; }
            public string Tipo { get; set; }
            public string Documento { get; set; }
        }

        public class InventarioAlmacen
        {
            public int IdProducto { get; set; }
            public string Nombre { get; set; }
            public string Descripcion { get; set; }
            public string Tipo { get; set; }
            public DateTime FechaVencimiento { get; set; }
            public string Unidad { get; set; }
            public int Presentacion { get; set; }
            public double Precio { get; set; }
            public bool Activo { get; set; }
            public string Almacen { get; set; }
            public int Stock { get; set; }
        }

        public class InventarioVehiculo
        {
            public int IdProducto { get; set; }
            public string Nombre { get; set; }
            public string Descripcion { get; set; }
            public string Tipo { get; set; }
            public DateTime FechaVencimiento { get; set; }
            public string Unidad { get; set; }
            public int Presentacion { get; set; }
            public double Precio { get; set; }
            public bool Activo { get; set; }
            public string Vehiculo { get; set; }
            public int Stock { get; set; }
        }

        public class LogUsuario
        {
            public int IdLogUsuario { get; set; }
            public string Usuario { get; set; }
            public string Accion { get; set; }
            public string Clase { get; set; }
            public DateTime Fecha { get; set; }
        }

        public class Pedido
        {
            public int IdPedido { get; set; }
            public string Cliente { get; set; }
            public string Estado { get; set; }
            public double Total { get; set; }
            public DateTime Fecha { get; set; }
            public string Tienda { get; set; }
            public string Almacen { get; set; }
            public string Motivo { get; set; }
            public string Medio { get; set; }
            public string Documento { get; set; }
        }

        public class Persona
        {
            public int IdPersona { get; set; }
            public string Nombres { get; set; }
            public string ApellidoPaterno { get; set; }
            public string ApellidoMaterno { get; set; }
            public int Celular { get; set; }
            public string Email { get; set; }
            public string TipoDocumento { get; set; }
            public int NumeroDocumento { get; set; }
            public char Sexo { get; set; }
            public bool Activo { get; set; }
            public string Usuario { get; set; }
        }

        public class Tienda
        {
            public int IdTienda { get; set; }
            public string Nombre { get; set; }
            public DateTime Fecha { get; set; }
            public string Departamento { get; set; }
            public string Provincia { get; set; }
            public string Distrito { get; set; }
            public bool Activo { get; set; }
        }

        public class Usuario
        {
            public int IdUsuario { get; set; }
            public string Nombre { get; set; }
            public DateTime Fecha { get; set; }
            public string Perfil { get; set; }
            public string Tienda { get; set; }
            public bool Activo { get; set; }
        }

        public class Vehiculo
        {
            public int IdVehiculo { get; set; }
            public string Placa { get; set; }
            public string Descripcion { get; set; }
            public int Capacidad { get; set; }
            public DateTime Fecha { get; set; }
            public string Marca { get; set; }
            public string Modelo { get; set; }
            public bool Activo { get; set; }
            public string Tienda { get; set; }
        }
    }
}