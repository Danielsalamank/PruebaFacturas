using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FacturacionWeb
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
                createtable();


        }

        public void createtable()
        {
            string datos = string.Empty;
            string metodo = string.Empty;
            string URL = string.Empty;

            datos = "";
            metodo = "GET";
            URL = "http://localhost:15796/api/Facturas/getFacturas";

            string jsonString = LeerRestApi(datos, metodo, URL);


            DataTable dataTable = JsonConvert.DeserializeObject<DataTable>(jsonString);

            //Binding GridView to dataTable object   
            grdJSON2Grid2.DataSource = dataTable;
            grdJSON2Grid2.DataBind();

        }


        public static string LeerRestApi(string datos, string metodo, string URL)
        {
            string json = string.Empty;

            var url = URL;
            byte[] data = UTF8Encoding.UTF8.GetBytes(datos);

            try
            {
                HttpWebRequest peticion;
                peticion = WebRequest.Create(url) as HttpWebRequest;
                peticion.Method = metodo;
                peticion.ContentLength = data.Length;
                peticion.ContentType = "application/json; charset=utf-8";
                peticion.Proxy = new WebProxy() { UseDefaultCredentials = true };

                Stream Servicio = peticion.GetRequestStream();
                Servicio.Write(data, 0, data.Length);
                Servicio.Close();


                HttpWebResponse respuesta = peticion.GetResponse() as HttpWebResponse;
                StreamReader lectura = new StreamReader(respuesta.GetResponseStream(), Encoding.Default);
                json = lectura.ReadToEnd();
            }
            catch (Exception ex)
            {
                json = ex.Message;
            }

            return json;
        }
    }
}