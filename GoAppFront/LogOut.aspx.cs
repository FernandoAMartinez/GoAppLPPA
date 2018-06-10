using NegocioService;
using NegocioService.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoAppFront
{
    public partial class LogOut : System.Web.UI.Page
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
            UsuarioDTO user = (UsuarioDTO)Session["Usuario"];
            Session["Usuario"] = null;
            BitacoraService.Insert(new BitacoraDTO()
            {
                Accion = "LOGOUT",
                Descripcion = "El usuario " + user.UserName + " salio del sistema.",
                Fecha = DateTime.Now,
                Usuario = user
            });

            Response.Redirect("Authentication.aspx");
        }
    }
}