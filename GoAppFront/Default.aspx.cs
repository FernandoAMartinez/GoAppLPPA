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
            dgProyectos.DataSource = dt;
            dgProyectos.DataBind();
        }

        //Inicio Modificación - FernandoAMartinez
        protected void AddToCart_Click(object sender, EventArgs e)
        {
            //modificado
            List<ContribucionDTO> carrito = (List<ContribucionDTO>)Session["Carrito"];
            //Inicio Modificación - FernandoAMartinez
            if ((List<ContribucionDTO>)Session["Carrito"] == null)
            {
                //Get the button that raised the event
                LinkButton btn = (LinkButton)sender;

                //Get the row that contains this button
                DataGridItem gvr = (DataGridItem)btn.NamingContainer;
                //List<ContribucionDTO> carrito = new List<ContribucionDTO>();
                carrito = new List<ContribucionDTO>();
                ContribucionDTO contribucion = new ContribucionDTO();
                //Inicio Modificación - FernandoAMartinez
                //contribucion.IdProy = Int32.Parse(gvr.Cells[0].Text);
                contribucion.Proyecto = ProyectoService.GetById(Int32.Parse(gvr.Cells[0].Text));
                //Fin Modificación - FernandoAMartinez
                contribucion.IdVenta = 0;
                contribucion.Cantidad = 1;
                contribucion.Importe = 250;
                carrito.Add(contribucion);
                Session["Carrito"] = carrito;
            }
            else
            {
                LinkButton btn = (LinkButton)sender;
                DataGridItem gvr = (DataGridItem)btn.NamingContainer;
                ContribucionDTO contribucion = new ContribucionDTO();
                //Inicio Modificación - FernandoAMartinez
                //contribucion.IdProy = Int32.Parse(gvr.Cells[0].Text);
                contribucion.Proyecto = ProyectoService.GetById(Int32.Parse(gvr.Cells[0].Text));
                //Fin Modificación - FernandoAMartinez                
                contribucion.IdVenta = 0;
                contribucion.Cantidad = 1;
                contribucion.Importe = 250;
                carrito.Add(contribucion);
                Session["Carrito"] = carrito;
            }
            //Fin Modificación - FernandoAMartinez


            //TODO: AÑADIR AL CARRITO EL PROYECTO SELECCIONADO
            /*(List<ContribucionDTO>)Session["Carrito"]
             * 
             * 
             */
        }
        //Fin Modificación - FernandoAMartinez

    }
}
 
 