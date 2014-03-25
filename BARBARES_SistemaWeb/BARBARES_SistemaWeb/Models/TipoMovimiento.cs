using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BARBARES_SistemaWeb.Models
{
    public class TipoMovimiento
    {
        public int IdTipoMovimiento { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime UltimaModificacion { get; set; }
    }
}