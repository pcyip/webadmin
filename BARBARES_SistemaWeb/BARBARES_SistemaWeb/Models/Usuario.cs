using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BARBARES_SistemaWeb.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime UltimaModificacion { get; set; }
        public bool Activo { get; set; }
        public int IdContrasena { get; set; }
        public int IdTienda { get; set; }
    }
}