using NegocioService;
using NegocioService.DTO;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoAppFront
{
    public partial class _Default : Page
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
            if (Session["Usuario"] == null)
                Response.Redirect("Authentication.aspx");

            Session["Perfil"] = ((UsuarioDTO)Session["Usuario"]).Perfil.Id;
            Session["PerfilDesc"] = ((UsuarioDTO)Session["Usuario"]).Perfil.Descripcion;

            ServiceConsultaProyectos.ConsultaProyectosWSSoapClient servicio = new ServiceConsultaProyectos.ConsultaProyectosWSSoapClient();
            DataTable dt = new DataTable();
            dt.TableName = "Lista Proyectos";
            dt = ProyectoService.ConsultaProyectos();
            dgProyecyos.DataSource = dt;
            dgProyecyos.DataBind();
        }

    }
}