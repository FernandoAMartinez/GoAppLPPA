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
    public partial class Register : System.Web.UI.Page
    {

        private UsuarioService _usuarioService;

        public UsuarioService UsuarioService
        {
            get
            {
                if (_usuarioService == null)
                    _usuarioService = new UsuarioService();

                return _usuarioService;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            string User = txtUserName.Text;
            string Password = txtPassword.Text;
            UsuarioDTO dto = new UsuarioDTO() { UserName = User, Password = Password, IsBlocked = false, Tries = 0, Perfil = new PerfilDTO() { Id = 3 } };
            int ret = UsuarioService.SaveOrUpdate(dto);
            if (ret > 0)
            {
                txtError.Text = "El Usuario se creo correctamente";
            }
            else
            {
                txtError.Text = "Hubo un error al crear el usuario";
            }
        }
    }
}