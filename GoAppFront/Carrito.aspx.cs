using System;
using NegocioService;
using NegocioService.DTO;
using System.Data;

namespace GoAppFront
{
    public partial class Carrito : System.Web.UI.Page
    {
        private ProyectoService _proyectoService;

        public ProyectoService ProyectoService
        {
            get
            {
                if (_proyectoService == null)
                    _proyectoService = new ProyectoService();
                return _proyectoService;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ServiceConsultaProyectos.ConsultaProyectosWSSoapClient servicio = new ServiceConsultaProyectos.ConsultaProyectosWSSoapClient();
            //List<ProyectoDTO> proyectos = new List<ProyectoDTO>();
            //foreach (GridViewRow row in servicio.ConsultaProyectos())
            //{
            //
            //}
            DataTable dt = new DataTable();
            dt.TableName = "Lista Proyectos";
            //dt = servicio.ConsultaProyectos();
            dt = ProyectoService.ConsultaProyectos();
            //DataSet ds = new DataSet();
            //ds.Tables.Add(dt);
            dgProyecyos.DataSource = dt;
            dgProyecyos.DataBind();
        }
    }
}