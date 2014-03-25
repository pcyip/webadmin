using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BARBARES_SistemaWeb.Models
{
    public class UnidadProducto
    {
        public int IdUnidadProducto { get; set; }
        public string Unidad { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime UltimaModificacion { get; set; }
        public bool Activo { get; set; }
    }
}