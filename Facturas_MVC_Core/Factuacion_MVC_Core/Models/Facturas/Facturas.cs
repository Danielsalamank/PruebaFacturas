using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Factuacion_MVC_Core.Models.Facturas
{
    public class clsFacturas
    {
        public int IdFactura { get; set; }
        public int NumeroFactura { get; set; }
        public DateTime? Fecha { get; set; }
        public string TipodePago { get; set; }
        public string DocumentoCliente { get; set; }
        public string NombreCliente { get; set; }
        public int idProducto { get; set; }
        public float Subtotal { get; set; }
        public int Descuento { get; set; }
        public int IVA { get; set; }
        public float TotalDescuento { get; set; }
        public float TotalImpuesto { get; set; }
        public float Total { get; set; }
    }

    public class Respuesta
    {
        public string Error { get; set; }
        public string Mensaje { get; set; }
    }
}
