using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BARBARES_SistemaWeb.Models
{
    public class Almacen
    {
        public int IdAlmacen { get; set; }
        public string Descripcion { get; set; }
        public int Capacidad { get; set; }
        public double Area { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime UltimaModificacion { get; set; }
        public bool Activo { get; set; }
        public int IdTienda { get; set; }
        public int IdDireccion { get; set; }
    }
}