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
    public partial class Bitacora : System.Web.UI.Page
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

            List<BitacoraDTO> bitacoras = BitacoraService.GetAll();
            dgBitacora.DataSource = bitacoras;
            dgBitacora.DataBind();
        }


    }
}