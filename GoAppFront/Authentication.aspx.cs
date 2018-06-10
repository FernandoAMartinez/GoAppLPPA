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
            iniciarSesión(sender, e);
        }

        private void iniciarSesión(object sender, EventArgs e)
        {
            string User = tbUser.Text;
            string Password = tbPassword.Text;

            try
            {

                clsUser US = new clsUser(User, Password);
                string Username = US.Usu;

                if (US.Exists(US.Usu) == 0)
                {
                    string message = "Usuario incorrecto.";
                    Response.Write("<script> language='JaveScript'> alert('"+message+"')</script>");
                    //#region Bitacora
                    //clsBitacora BIT = new clsBitacora();
                    //BIT.InsertBitacora(BIT.Next(), message, 1, "E", "L", US.Usu, Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")), Convert.ToDateTime(DateTime.Now.ToString("HH:mm:ss")));
                    //#endregion
                    //#region MessageHandler
                    //Controller.Handlers.clsMessage c_Message = new Controller.Handlers.clsMessage();
                    //c_Message.MessageHandler(message, "E", "L");
                    //#endregion
                    ClearForm();
                    tbUser.Focus();
                }
                else if (US.Blocked == "X")
                {
                    string message = "Su usuario se encuentra bloqueado. \nContacte a su administrador.";
                    Response.Write("<script> language='JaveScript'> alert('" + message + "')</script>");

                    //#region Bitacora
                    //clsBitacora BIT = new clsBitacora();
                    //BIT.InsertBitacora(BIT.Next(), message, 2, "E", "L", US.Usu, Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")), Convert.ToDateTime(DateTime.Now.ToString("HH:mm:ss")));
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
                    //BIT.InsertBitacora(BIT.Next(), message, 3, "E", "L", US.Usu, Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")), Convert.ToDateTime(DateTime.Now.ToString("HH:mm:ss")));
                    //#endregion
                    //#region MessageHandler
                    //Controller.Handlers.clsMessage c_Message = new Controller.Handlers.clsMessage();
                    //c_Message.MessageHandler(message, "E", "L");
                    //#endregion
                    ClearForm();
                    tbUser.Focus();
                }
                else if ((US.LoginValidate(US.Usu, US.Pass)) == -1)
                {
                    string message = "Bienvenido " + US.Usu + "!";
                    US.LogInLogOut("X", US.Usu);
                    Response.Write("<script> language='JaveScript'> alert('" + message + "')</script>");
                    //#region Bitacora
                    //clsBitacora BIT = new clsBitacora();
                    //BIT.InsertBitacora(BIT.Next(), message, 1, "I", "L", US.Usu, Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")), Convert.ToDateTime(DateTime.Now.ToString("HH:mm:ss")));
                    //#endregion
                    //#region MessageHandler
                    //Controller.Handlers.clsMessage c_Message = new Controller.Handlers.clsMessage();
                    //c_Message.MessageHandler(message, "I", "L");
                    //#endregion
                    US.ResetTries(US.Usu);
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    string message = "Credenciales Inválidas!";
                    Response.Write("<script> language='JaveScript'> alert('" + message + "')</script>");
                    //#region Bitacora 
                    //clsBitacora BIT = new clsBitacora();
                    //BIT.InsertBitacora(BIT.Next(), message, 3, "E", "L", US.Usu, Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")), Convert.ToDateTime(DateTime.Now.ToString("HH:mm:ss")));
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