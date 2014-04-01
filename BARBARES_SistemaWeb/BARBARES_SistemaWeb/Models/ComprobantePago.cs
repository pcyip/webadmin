using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BARBARES_SistemaWeb.Models
{
    public class ComprobantePago
    {
        public int IdComprobantePago { get; set; }
        public int NumeroComprobante { get; set; }
        public DateTime FechaCreacion { get; set; }
        public double Total { get; set; }
        public int TransaccionPOS { get; set; }
        public int IdTipoComprobante { get; set; }
        public int IdMoneda { get; set; }
        public int IdPedido { get; set; }
        public int IdPersona { get; set; }
    }
}