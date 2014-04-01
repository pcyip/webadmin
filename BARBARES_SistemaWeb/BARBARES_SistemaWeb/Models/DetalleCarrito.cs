using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BARBARES_SistemaWeb.Models
{
    public class DetalleCarrito
    {
        public int IdCarrito { get; set; }
        public int IdDetalleCarrito { get; set; }
        public double Cantidad { get; set; }
        public double Subtotal { get; set; }
        public int IdProducto { get; set; }
        public int IdPromocion { get; set; }
    }
}