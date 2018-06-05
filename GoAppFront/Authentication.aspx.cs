using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace GoAppFront
{
    public partial class Authentication : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //iniciarSesión(sender, e);
            string User = tbUser.Text;
            string Password = tbPassword.Text;
            Usuario US = new Usuario(User, Password);
            if (US.LoginValidate(US.UserName, US.Password) == -1)
            {
                Session["Usuario"] = US;
                Response.Redirect("Default.aspx");
            }

        }

        private void iniciarSesión(object sender, EventArgs e)
        {
            string User = tbUser.Text;
            string Password = tbPassword.Text;

            try
            {

                Usuario US = new Usuario(User, Password);
                string Username = US.UserName;

                if (US.Exists(US.UserName) == 0)
                {
                    string message = "Usuario incorrecto.";
                    Response.Write("<script> language='JaveScript'> alert('"+message+"')</script>");
                    //#region Bitacora
                    //clsBitacora BIT = new clsBitacora();
                    //BIT.InsertBitacora(BIT.Next(), message, 1, "E", "L", US.UserName, Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")), Convert.ToDateTime(DateTime.Now.ToString("HH:mm:ss")));
                    //#endregion
                    //#region MessageHandler
                    //Controller.Handlers.clsMessage c_Message = new Controller.Handlers.clsMessage();
                    //c_Message.MessageHandler(message, "E", "L");
                    //#endregion
                    ClearForm();
                    tbUser.Focus();
                }
                else if (US.IsBlocked == "X")
                {
                    string message = "Su usuario se encuentra bloqueado. \nContacte a su administrador.";
                    Response.Write("<script> language='JaveScript'> alert('" + message + "')</script>");

                    //#region Bitacora
                    //clsBitacora BIT = new clsBitacora();
                    //BIT.InsertBitacora(BIT.Next(), message, 2, "E", "L", US.UserName, Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")), Convert.ToDateTime(DateTime.Now.ToString("HH:mm:ss")));
                    //#endregion
                    //#region MessageHandler
                    //Controller.Handlers.clsMessage c_Message = new Controller.Handlers.clsMessage();
                    //c_Message.MessageHandler(message, "E", "L");
                    //#endregion
                    ClearForm();
                    tbUser.Focus();
                }
                else if (US.Logued == "X")
                {
                    string message = "El usuario ya se encuentra logeado.";
                    Response.Write("<script> language='JaveScript'> alert('" + message + "')</script>");
                    //#region Bitacora
                    //clsBitacora BIT = new clsBitacora();
                    //BIT.InsertBitacora(BIT.Next(), message, 3, "E", "L", US.UserName, Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")), Convert.ToDateTime(DateTime.Now.ToString("HH:mm:ss")));
                    //#endregion
                    //#region MessageHandler
                    //Controller.Handlers.clsMessage c_Message = new Controller.Handlers.clsMessage();
                    //c_Message.MessageHandler(message, "E", "L");
                    //#endregion
                    ClearForm();
                    tbUser.Focus();
                }
                else if ((US.LoginValidate(US.UserName, US.Password)) == -1)
                {
                    string message = "Bienvenido " + US.UserName + "!";
                    US.LogInLogOut("X", US.UserName);
                    Response.Write("<script> language='JaveScript'> alert('" + message + "')</script>");
                    //#region Bitacora
                    //clsBitacora BIT = new clsBitacora();
                    //BIT.InsertBitacora(BIT.Next(), message, 1, "I", "L", US.UserName, Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")), Convert.ToDateTime(DateTime.Now.ToString("HH:mm:ss")));
                    //#endregion
                    //#region MessageHandler
                    //Controller.Handlers.clsMessage c_Message = new Controller.Handlers.clsMessage();
                    //c_Message.MessageHandler(message, "I", "L");
                    //#endregion
                    US.ResetTries(US.UserName);
                }
                else
                {
                    string message = "Credenciales Inválidas!";
                    Response.Write("<script> language='JaveScript'> alert('" + message + "')</script>");
                    //#region Bitacora 
                    //clsBitacora BIT = new clsBitacora();
                    //BIT.InsertBitacora(BIT.Next(), message, 3, "E", "L", US.UserName, Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")), Convert.ToDateTime(DateTime.Now.ToString("HH:mm:ss")));
                    //#endregion
                    //#region MessageHandler
                    //Controller.Handlers.clsMessage c_Message = new Controller.Handlers.clsMessage();
                    //c_Message.MessageHandler(message, "E", "L");
                    //#endregion
                    ClearForm();
                    tbUser.Focus();
                }
            }
            catch (Exception ex)
            {
                string message = ex.ToString();
                Response.Write("<script> language='JaveScript'> alert('" + message + "')</script>");
                //#region Bitacora
                //clsBitacora BIT = new clsBitacora();
                //BIT.InsertBitacora(BIT.Next(), message, 3, "E", "L", User, Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")), Convert.ToDateTime(DateTime.Now.ToString("HH:mm:ss")));
                //#endregion
                //#region MessageHandler
                //Controller.Handlers.clsMessage c_Message = new Controller.Handlers.clsMessage();
                //c_Message.MessageHandler(message, "E", "L");
                //#endregion
                throw;
            }
        }


        private void ClearForm()
        {
            tbUser.Text = "";
            tbPassword.Text = "";
        }
    }
}