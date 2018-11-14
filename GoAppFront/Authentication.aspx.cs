using System;
using System.Web.UI;
using NegocioService;
using NegocioService.DTO;
using System.Data;
using System.Windows.Forms;
using System.Text;

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
            //if(txtError.Text == null || string.IsNullOrWhiteSpace(txtError.Text))
                
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            SeguridadService SecServ = new SeguridadService();
            DataTable Tablas = new DataTable();
            Tablas = SecServ.TraerTablas();

            for (int i = 0; i < Tablas.Rows.Count; i++)
            {
                DataTable tabla = SecServ.ValidarDigitos(i);
                Session["dtErrores"] = tabla;
                Session.Add("Tabla " + Tablas.Rows[i]["Tabla"], tabla);
                if (tabla != null)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (DataRow row in tabla.Rows)
                    {
                        sb.AppendLine("Error en la tabla " + Tablas.Rows[i]["Tabla"] + " registro " + row[0] + ".");
                        //MessageBox.Show("Error en la fila: " + row[0] + "", "Tabla: " + Tablas.Rows[i]["Tabla"]);
                    }
                    MessageBox.Show(sb.ToString(), "Errores de integridad");
                }
                else if (i == Tablas.Rows.Count)
                {
                    goto SkipLogin;
                }
                else
                {
                    continue;
                }                    
            }
            string User = txtUserName.Text;
            string Password = txtPassword.Text;

            UsuarioDTO usuario = UsuarioService.GetByLogin(User, Password);
            if (usuario != null)
            {

                if (usuario.IsBlocked == false && usuario.Tries > 0)
                {
                    Session["Usuario"] = usuario;
                    BitacoraService.Insert(new BitacoraDTO() { Accion = "LOGIN", Descripcion ="Se logueo al sistema el usuario " + usuario.UserName,
                    Fecha = DateTime.Now, Usuario = usuario});
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    txtError.Text = "El Usuario esta Bloqueado";
                }
            }
            else {
                txtError.Text = "El Usuario o Contraseña son Incorrectos";
            }
            SkipLogin:
                txtError.Text = "Hubo errores de integridad.";
                
        }

        private void ClearForm()
        {
            txtUserName.Text = "";
            txtPassword.Text = "";
        }

   
    }
}