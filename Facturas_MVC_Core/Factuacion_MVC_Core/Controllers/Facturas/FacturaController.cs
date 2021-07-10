using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using Microsoft.Extensions.Configuration;
using Factuacion_MVC_Core.Models.Facturas;
using System.Globalization;
using System.Data;


namespace Factuacion_MVC_Core.Controllers.Facturas
{
   
    public class FacturaController : Controller
    {
        private readonly IConfiguration Connect;

        public FacturaController(IConfiguration configuration)
        {
            Connect = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }

        #region GET_Facturas
        // se obtienen las facturas
        [HttpGet]
        [Route("api/Facturas/getFacturas")]
        [EnableCors("FacturaCors")]
        public JsonResult GetFacturas()
        {
            OracleConnection CnxPaises = new OracleConnection(Connect["ConnectionStrings:Connect"]);

            CnxPaises.Open();
            string consulta = "SELECT IdFactura, NumeroFactura, Fecha, TipodePago, DocumentoCliente, " +
                              "NombreCliente, idProducto, Subtotal, Descuento, IVA, TotalDescuento, " +
                              "TotalImpuesto, Total " +
                              "FROM Facturas ";

            OracleCommand cmd = new OracleCommand(consulta, CnxPaises);
            OracleDataReader reader = cmd.ExecuteReader();

            List<clsFacturas> ListaPaises = new List<clsFacturas>();

            while (reader.Read())
            {
                clsFacturas pais = new clsFacturas
                {
                    IdFactura = Convert.ToInt32(reader["IdFactura"].ToString()),
                    NumeroFactura = Convert.ToInt32(reader["NumeroFactura"].ToString()),
                    Fecha = Convert.ToDateTime(reader["Fecha"].ToString()),
                    TipodePago = reader["TipodePago"].ToString(),
                    DocumentoCliente = reader["DocumentoCliente"].ToString(),
                    NombreCliente = reader["NombreCliente"].ToString(),
                    idProducto = Convert.ToInt32(reader["idProducto"].ToString()),
                    Subtotal = Convert.ToInt32(reader["Subtotal"].ToString()),
                    Descuento = Convert.ToInt32(reader["codigo_pais"].ToString()),
                    IVA = Convert.ToInt32(reader["codigo_pais"].ToString()),
                    TotalDescuento = Convert.ToInt32(reader["codigo_pais"].ToString()),
                    TotalImpuesto = Convert.ToInt32(reader["codigo_pais"].ToString()),
                    Total = Convert.ToInt32(reader["codigo_pais"].ToString()),
                };
                ListaPaises.Add(pais);
            }

            reader.Close();
            CnxPaises.Close();

            return Json(ListaPaises.AsEnumerable());
        }
        #endregion   

        #region GET_Facturas_ID
        // se obtienen las facturas
        [HttpGet]
        [Route("api/Facturas/getFacturasID")]
        [EnableCors("FacturaCors")]
        public JsonResult GetFacturasID(int IdFactura)
        {
            OracleConnection CnxPaises = new OracleConnection(Connect["ConnectionStrings:Connect"]);

            CnxPaises.Open();
            string consulta = "SELECT IdFactura, NumeroFactura, Fecha, TipodePago, DocumentoCliente, " +
                              "NombreCliente, idProducto, Subtotal, Descuento, IVA, TotalDescuento, " +
                              "TotalImpuesto, Total " +
                              " FROM Facturas " +
                              " WHERE IdFactura = :IdFactura";

            OracleCommand cmd = new OracleCommand(consulta, CnxPaises);
            OracleDataReader reader = cmd.ExecuteReader();

            List<clsFacturas> ListaPaises = new List<clsFacturas>();

            while (reader.Read())
            {
                clsFacturas pais = new clsFacturas
                {
                    IdFactura = Convert.ToInt32(reader["IdFactura"].ToString()),
                    NumeroFactura = Convert.ToInt32(reader["NumeroFactura"].ToString()),
                    Fecha = Convert.ToDateTime(reader["Fecha"].ToString()),
                    TipodePago = reader["TipodePago"].ToString(),
                    DocumentoCliente = reader["DocumentoCliente"].ToString(),
                    NombreCliente = reader["NombreCliente"].ToString(),
                    idProducto = Convert.ToInt32(reader["idProducto"].ToString()),
                    Subtotal = Convert.ToInt32(reader["Subtotal"].ToString()),
                    Descuento = Convert.ToInt32(reader["codigo_pais"].ToString()),
                    IVA = Convert.ToInt32(reader["codigo_pais"].ToString()),
                    TotalDescuento = Convert.ToInt32(reader["codigo_pais"].ToString()),
                    TotalImpuesto = Convert.ToInt32(reader["codigo_pais"].ToString()),
                    Total = Convert.ToInt32(reader["codigo_pais"].ToString()),
                };
                ListaPaises.Add(pais);
            }

            reader.Close();
            CnxPaises.Close();

            return Json(ListaPaises.AsEnumerable());
        }
        #endregion   

        #region POST_Insertar_Facturas
        // se obtienen los Tipos de Documentos
        [HttpPost]
        [Route("api/Facturas/RegistroFactura")]
        [EnableCors("FacturaCors")]
        public JsonResult RegistroFacturas([FromBody] clsFacturas Factura)
        {
            //Se asigna la Fecha y Hora Actual  
            string dateTime = DateTime.Now.ToString();
            string createddate = Convert.ToDateTime(dateTime).ToString("yyyy-MM-dd hh:mm:ss");
            DateTime FechaActual = DateTime.ParseExact(createddate, "yyyy-MM-dd hh:mm:ss", CultureInfo.InvariantCulture);

            OracleConnection CnxUsuarios = new OracleConnection(Connect["ConnectionStrings:Connect"]);

            using OracleCommand cmd = new OracleCommand
            {
                Connection = CnxUsuarios,
                CommandType = CommandType.Text,
                CommandText = @"INSERT INTO Facturas(IdFactura, NumeroFactura, Fecha, TipodePago, DocumentoCliente, NombreCliente, idProducto, Subtotal, Descuento, IVA, TotalDescuento, TotalImpuesto, Total) 
                                VALUES (:IdFactura, :NumeroFactura, :Fecha, :TipodePago, :DocumentoCliente, :NombreCliente, :idProducto, :Subtotal, :Descuento, :IVA, :TotalDescuento, :TotalImpuesto, :Total)"
            };

            cmd.Parameters.Add(new OracleParameter("IdFactura", Factura.IdFactura));
            cmd.Parameters.Add(new OracleParameter("NumeroFactura", Factura.NumeroFactura));
            cmd.Parameters.Add(new OracleParameter("Fecha", FechaActual));
            cmd.Parameters.Add(new OracleParameter("TipodePago", Factura.TipodePago));
            cmd.Parameters.Add(new OracleParameter("DocumentoCliente", Factura.DocumentoCliente));
            cmd.Parameters.Add(new OracleParameter("NombreCliente", Factura.NombreCliente));
            cmd.Parameters.Add(new OracleParameter("idProducto", Factura.idProducto));
            cmd.Parameters.Add(new OracleParameter("Subtotal", Factura.Subtotal));
            cmd.Parameters.Add(new OracleParameter("Descuento", Factura.Descuento));
            cmd.Parameters.Add(new OracleParameter("IVA", Factura.IVA));
            cmd.Parameters.Add(new OracleParameter("TotalDescuento", Factura.TotalDescuento));
            cmd.Parameters.Add(new OracleParameter("TotalImpuesto", Factura.TotalImpuesto));
            cmd.Parameters.Add(new OracleParameter("Total", Factura.Total));

            try
            {
                CnxUsuarios.Open();
                cmd.ExecuteNonQuery();
                List<Respuesta> Listarespuesta = new List<Respuesta>();
                Respuesta respuesta = new Respuesta
                {
                    Error = "No",
                    Mensaje = "Usuario Creado exitosamente"
                };
                Listarespuesta.Add(respuesta);

                return Json(Listarespuesta.AsEnumerable());
            }
            catch (OracleException e)
            {
                List<Respuesta> Listarespuesta = new List<Respuesta>();
                Respuesta respuesta = new Respuesta
                {
                    Error = "Si",
                    Mensaje = e.Message.ToString()
                };
                Listarespuesta.Add(respuesta);

                return Json(Listarespuesta.AsEnumerable());
            }
        }
        #endregion
    }
}
