using System;
using NegocioService;
using NegocioService.DTO;
using NegocioService.Helper;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace GoAppFront
{
    public partial class AltaProyecto : System.Web.UI.Page
    {
        private BitacoraService _bitacoraService;

        public BitacoraService BitacoraService
        {
            get
            {
                if (_bitacoraService == null)
                    _bitacoraService = new BitacoraService();

                return _bitacoraService;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AltaProyecto_Click(object sender, EventArgs e)
        {
            ServiceReference2.AltaProyectoWSSoapClient service = new ServiceReference2.AltaProyectoWSSoapClient();
            int res = service.Proyecto_InsertOrUpdate(new ServiceReference2.ProyectoDTO()
            {
                Nombre = tbNombre.Text,
                Meta = Convert.ToDouble(tbMeta.Text),
                FechaInicio = Convert.ToDateTime(tbInico.Text),
                FechaFin = Convert.ToDateTime(tbFin.Text)
            });

            if(res == 1)
            {
                MessageBox.Show("Proyecto dado de alta correctamente");
                BitacoraService.Insert(new BitacoraDTO()
                {
                    Accion = "ALTAPROY",
                    Descripcion = "Se dio de alta el proyecto " + tbNombre.Text,
                    Fecha = DateTime.Now,
                    Usuario = (UsuarioDTO)Session["Usuario"]
                });

            }
            else if (res == -1)
            {
                Response.Write("<script language='javascript/text'>alert('Error de base de datos')</script>");
            }
        }
    }
}