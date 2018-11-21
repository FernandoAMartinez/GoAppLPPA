using System;
using NegocioService;
using NegocioService.DTO;
using NegocioService.Helper;
using System.Data;
using System.Xml;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GoAppFront
{
    public partial class Carrito : System.Web.UI.Page
    {
        private ProyectoService _proyectoService;

        public ProyectoService ProyectoService
        {
            get
            {
                if (_proyectoService == null)
                    _proyectoService = new ProyectoService();
                return _proyectoService;
            }
        }

        private VentaService _ventaService;

        public VentaService VentaService
        {
            get
            {
                if (_ventaService == null)
                    _ventaService = new VentaService();

                return _ventaService;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["Perfil"] = ((UsuarioDTO)Session["Usuario"]).Perfil.Id;
            //Session["PerfilDesc"] = ((UsuarioDTO)Session["Usuario"]).Perfil.Descripcion;
            List<ContribucionDTO> contribuciones = (List<ContribucionDTO>)Session["Carrito"];
            dgCarrito.DataSource = contribuciones;
            dgCarrito.DataBind();

            /*
            ServiceConsultaProyectos.ConsultaProyectosWSSoapClient servicio = new ServiceConsultaProyectos.ConsultaProyectosWSSoapClient();
            //List<ProyectoDTO> proyectos = new List<ProyectoDTO>();
            //foreach (GridViewRow row in servicio.ConsultaProyectos())
            //{
            //
            //}
            DataTable dt = new DataTable();
            dt.TableName = "Lista Proyectos";
            //dt = servicio.ConsultaProyectos();
            dt = ProyectoService.ConsultaProyectos();
            //DataSet ds = new DataSet();
            //ds.Tables.Add(dt);
            dgProyecyos.DataSource = dt;
            dgProyecyos.DataBind();*/
        }

        protected void Enviar_Click(object sender, EventArgs e)
        {
            VentaDTO venta = new VentaDTO();
            venta.Contribuciones = (List<ContribucionDTO>)Session["Carrito"];
            venta.Id = VentaService.GetNextId("VentaProyecto");
            //Inicio Modificación - FernandoAMartinez
            foreach (ContribucionDTO dto in venta.Contribuciones)
                dto.IdVenta = venta.Id;
            //Fin Modificación - FernandoAMartinez            
            venta.Fecha = DateTime.Now;
            venta.UsuarioId = ((UsuarioDTO)Session["Usuario"]).Id;
            VentaService.SaveOrUpdate(venta);
            MessageBox.Show("Venta " + venta.Id.ToString() + " efectuada.\nGracias.", "Venta Efectuada");
            
            //Rutina para serializar en XML los datos de la transacción
            //escribirXML(sender, e);

            //Se inicializa el carrito y se vuelve a la página de inicio
            Session["Carrito"] = null;
            Response.Redirect("Default.aspx");
        }

        protected void escribirXML(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            UsuarioService UsuarioService = new UsuarioService();
            UsuarioDTO userLocal = (UsuarioDTO)Session["Usuario"];

            //Inicio Modificación - FernandoAMartinez
            ////TarjetaDTO tarjeta = UsuarioService.GetCardInformation(userLocal);
            ////string file = tarjeta.cardnumber + "_" + userLocal.UserName + ".xml";
            //Fin Modificación - FernandoAMartinez

            ////doc.Load(Server.MapPath(file));
            XmlElement Venta = doc.CreateElement("Venta");
            //Nodo tarjetas
            XmlElement Tarjeta = doc.CreateElement("Tarjeta");
            XmlElement Numero = doc.CreateElement("Numero", "");
            XmlElement Desde = doc.CreateElement("Desde", "");
            XmlElement Hasta = doc.CreateElement("Hasta", "");
            XmlElement Importe = doc.CreateElement("Importe", "");
            //Nodo Usuario
            XmlElement Usuario = doc.CreateElement("Usuario");
            XmlElement Nombre = doc.CreateElement("Nombre", "");
            //NombreLibro.InnerText = NombreTxt.Text;
            //Autor.InnerText = AutorTxt.Text;
            //Editorial.InnerText = EditorialTxt.Text;
            //Precio.InnerText = PrecioTxt.Text;
            Venta.AppendChild(Tarjeta);
            Tarjeta.AppendChild(Numero);
            Tarjeta.AppendChild(Desde);
            Tarjeta.AppendChild(Hasta);
            Tarjeta.AppendChild(Importe);
            Venta.AppendChild(Usuario);
            Usuario.AppendChild(Nombre);

            doc.DocumentElement.AppendChild(Venta);
            ////doc.Save(Server.MapPath(file));
        }

    }
}