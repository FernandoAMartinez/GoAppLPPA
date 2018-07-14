using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using NegocioService;
using NegocioService.Helper;
using NegocioService.DTO;
using System.Configuration;

namespace GoAppFront
{
    public partial class Backup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Backup_Click(object sender, EventArgs e)
        {
            int ret = 0;
            //string path = "N'" + @tbPath.Text + "'";
            //        string path = tbPath.Text;
            string path = "'" + ConfigurationManager.AppSettings["BackupDir"] + "'";
            SeguridadService Sec = new SeguridadService();
            try
            {
                ret = Sec.PerformBackup(path);
                if (ret == 0)
                {
                    UsuarioDTO user = (UsuarioDTO)Session["Usuario"];
                    BitacoraService service = new BitacoraService();
                    service.Insert(new BitacoraDTO()
                    {
                        Accion = "BACKUP",
                        Descripcion = "El usuario " + user.UserName + " ejecutó el backup en "+ path +"",
                        Fecha = DateTime.Now,
                        Usuario = user
                    });
                    lblEstado.Text = "Backup Efectuado";
                }
                else
                {
                    UsuarioDTO user = (UsuarioDTO)Session["Usuario"];
                    BitacoraService service = new BitacoraService();
                    service.Insert(new BitacoraDTO()
                    {
                        Accion = "BACKUP",
                        Descripcion = "El backup de " + user.UserName + " no se ejecutó correctamente",
                        Fecha = DateTime.Now,
                        Usuario = user
                    });
                    lblEstado.Text = "Backup no efectuado";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            //nothing
        }
    }
}