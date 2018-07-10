using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace GoAppFront
{
    public partial class Backup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Backup_Click(object sender, EventArgs e)
        {
            NegocioService.Helper.Seguridad.GetInstance.PerformBackup(this.tbPath.Text);
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            //nothing
        }
    }
}