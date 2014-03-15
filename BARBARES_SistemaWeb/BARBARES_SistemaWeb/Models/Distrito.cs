using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BARBARES_SistemaWeb.Models
{
    public class Distrito
    {
        public int IdDistrito { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime UltimaModificacion { get; set; }
        public int IdProvincia { get; set; }
        public int IdDepartamento { get; set; }
    }
}