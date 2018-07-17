using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoAppFront
{
    public partial class AltaProyecto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

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

    }

        protected void btnPublicar_OnClick(Object sender, EventArgs e)
        {
            string desc = txtDescripcion.Text;
            double importe = txtImporte.Text;
            string fecha = txtFecha.Text;

            ProyectoDTO dto = new ProyectoDTO() { Descripcion = desc, importe = importe, FechaInicio = fecha };
            int ret = ProyectoService.SaveorUpdate(dto);

            if (ret > 0)
            {
                txtError.Text = "El proyecto se publico correctamente";
            }
            else
            {
                txtError.Text = "Hubo un error al publicar el proyecto";
            }
        }
    }
