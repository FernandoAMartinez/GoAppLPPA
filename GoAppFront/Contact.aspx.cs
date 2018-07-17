using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoAppFront
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Parte 2 - Creacion de lista de Bitacora
            DataTable tabla = (DataTable)Session["dtErrores"];
            dgErrores.DataSource = tabla;
            // Parte 8 - Llenar Data Gridview
            dgErrores.DataBind();
        }
    }
}