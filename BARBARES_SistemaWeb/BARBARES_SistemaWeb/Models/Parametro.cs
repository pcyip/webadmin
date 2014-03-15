using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BARBARES_SistemaWeb.Models
{
    public class Parametro
    {
        public int IdParametro { get; set; }
        public string CodigoPadre { get; set; }
        public string Codigo { get; set; }
        public string Valor { get; set; }
        public int ValorNum { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }
    }
}