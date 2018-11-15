using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NegocioService;
using NegocioService.DTO;
using System.Web.Services;

namespace GoAppFront
{
    /// <summary>
    /// Summary description for AltaProyectoWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class AltaProyectoWS : System.Web.Services.WebService
    {

        [WebMethod]
        public int Proyecto_InsertOrUpdate(ProyectoDTO dto)
        {
            ProyectoService service = new ProyectoService();
            return service.SaveOrUpdate(dto);
        }
    }
}
