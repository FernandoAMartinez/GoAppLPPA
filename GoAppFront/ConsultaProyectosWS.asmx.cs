using System.Data;
using NegocioService;
using NegocioService.DTO;
using NegocioService.Helper;
using System.Web.Services;


namespace GoAppFront
{
    /// <summary>
    /// Summary description for ConsultaProyectosWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ConsultaProyectosWS : System.Web.Services.WebService
    {

        [WebMethod]
        public DataTable ConsultaProyectos()
        {
            ProyectoService ProyectoService = new ProyectoService();
            DataTable dt = new DataTable();
            dt.TableName = "Lista Proyectos";
            dt.Columns.Add("Id");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Meta");
            dt.Columns.Add("Recaudado");
            dt.Columns.Add("Cantidad");
            dt.Columns.Add("FechaInicio");
            dt.Columns.Add("FechaFin");
            dt = ProyectoService.ConsultaProyectos();
            return dt;
        }
    }
}
