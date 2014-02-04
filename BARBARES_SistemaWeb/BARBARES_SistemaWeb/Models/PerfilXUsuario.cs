using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BARBARES_SistemaWeb.Models
{
    public class PerfilXUsuario
    {
        public int IdPerfilXUsuario { get; set; }
        public DateTime FechaAsignacion { get; set; }
        public int IdUsuario { get; set; }
        public int IdPerfil { get; set; }
    }
}