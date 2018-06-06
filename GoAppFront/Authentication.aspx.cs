using System;
using System.Web.UI;
using NegocioService;
using NegocioService.DTO;

namespace GoAppFront
{
    public partial class Authentication : Page
    {
        private UsuarioService _usuarioService;

        public UsuarioService UsuarioService {
            get {
                if (_usuarioService == null)
                    _usuarioService = new UsuarioService();

                return _usuarioService;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //iniciarSesión(sender, e);
            string User = txtUserName.Text;
            string Password = txtPassword.Text;
            UsuarioDTO usuario = UsuarioService.GetByLogin(User, Password);
            if (usuario != null)
            {
                if (!usuario.IsBlocked && usuario.Tries < 3)
                {
                    Session["Usuario"] = usuario;
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    //Esta Bloqueado.
                    txtError.Text = "El Usuario esta Bloqueado";
                }
            }
            else {
                //Usuario o Contraseña Incorrectos o No Existen.
                txtError.Text = "El Usuario o Contraseña son Incorrectos";
            }

        }

        private void ClearForm()
        {
            txtUserName.Text = "";
            txtPassword.Text = "";
        }
    }
}