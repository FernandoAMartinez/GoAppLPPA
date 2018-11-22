<%@Page Language="C#" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="GoAppFront.Carrito" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
 
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Shopping Cart</title>
    <link href="Styles/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="/Content/Home/bootstrap.min.css"/>
    <link rel="stylesheet" href="/Content/Home/animate.css"/>
    <link rel="stylesheet" href="/Content/Home/style.css"/>
    <style>
        .auto-style2 {
            margin-top: 47px;
            font-family:Arial;
            font-size:large;
        }
        .fuente {
            color: black;
        }
    </style>
    <script type="text/C#">
        <%--        <%
        if (!IsPostBack)
        {
            lblTotal.Text = (Int32.Parse(tbCantidad.Text) * Int32.Parse(tbImporte.Text)).ToString(); 
        }
        %>--%>
    </script>
</head>
<body>
    <form runat="server">	
        <header>
		    <nav class="navbar navbar-default navbar-fixed-top" role="navigation">
		    	<div class="navigation">
		    		<div class="container">	
                        			
		    			<div class="navbar-header">
		    				<button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target=".navbar-collapse.collapse">
		    					<span class="sr-only">Toggle navigation</span>
		    					<span class="icon-bar"></span>
		    					<span class="icon-bar"></span>
		    					<span class="icon-bar"></span>
		    				</button>
		    				<div class="navbar-brand">
		    					<a href="Default.aspx"><h1><% Response.Write((string)Session["PerfilDesc"]); %></h1></a>
		    				</div>
		    			</div>

		    			<div class="navbar-collapse collapse">							
		    				<div class="menu">
		    					<ul class="nav nav-tabs" role="tablist">
		    						<%  //Inicio Modificación - FernandoAMartinez
                                        int cantCarro = 0;
                                        if (((List<NegocioService.DTO.ContribucionDTO>)Session["Carrito"]) == null)
                                            cantCarro = 0;
                                        else
                                            cantCarro = ((List<NegocioService.DTO.ContribucionDTO>)Session["Carrito"]).Count;
                                        //Fin Modificación - FernandoAMartinez

                                        if (((int)Session["Perfil"]) == 1)
                                        {
                                            Response.Write("<li role='presentation'><a href='Default.aspx' class='active'>Inicio</a></li>");
                                            // Parte 1 - Bitacora - LLamado al formulario de bitácora
                                            Response.Write("<li role ='presentation' ><a href ='Bitacora.aspx'>Bitacora </a></li>");
                                            //Response.Write("<li role ='presentation' ><a href ='#services'>Administradores </a></li>");
                                            Response.Write("<li role ='presentation' ><a href ='Backup.aspx'>Backup</a></li>");
                                            //Response.Write("<li role ='presentation' ><a href ='Contact.aspx'>Registros Erroneos</a></li>");
                                            Response.Write("<li role='presentation'><a href='AltaProtecto.aspx'>Alta Proyectos</a></li>");
                                            Response.Write("<li role='presentation'><a href='Carrito.aspx'>Carrito (" + cantCarro.ToString() +")</a></li>");

                                        }
                                        else if (((int)Session["Perfil"]) == 2)
                                        {
                                            Response.Write("<li role='presentation'><a href='Default.aspx' class='active'>Inicio</a></li>");
                                            Response.Write("<li role ='presentation' ><a href ='Bitacora.aspx'>Bitacora </a></li>");
                                            Response.Write("<li role ='presentation' ><a href ='#contact'>Clientes </a></li>");
                                            // Agregado Backup Restore
                                            Response.Write("<li role = 'presentation'><a href='Backup.aspx'> Backup </a></li>");
                                            Response.Write("<li role = 'presentation'><a href='Restore.aspx'> Restore </a></li>");
                                        }
                                        else {
                                            Response.Write("<li role='presentation'><a href='Default.aspx' class='active'>Home</a></li>");
                                            Response.Write("<li role ='presentation' ><a href ='#about'>Sobre Nosotros </a></li>");
                                            Response.Write("<li role ='presentation' ><a href ='#services'>Servicios </a></li>");
                                            Response.Write("<li role ='presentation' ><a href ='#contact'>Contacto</a></li>");
                                        }
                                    %>		
                                   <li><a href ="LogOut.aspx">Cerrar Sesion</a></li>	
		    					</ul>
		    				</div>
		    			</div>
		    		</div>
		    	</div>	
		    </nav>			
        <%--</form>--%>
	</header>
    <div>

    </div>
        <br /><br /><br />
        <h1 class="auto-style2 fuente">Carrito de Compras</h1>
        <div class="auto-style1">
        <%-- Carrito de compras --%>
        <%-- Bajar a XML la transacción contra la tabla de tarjetas de Crédito --%>
            <asp:GridView ID="dgCarrito" 
                          AutoGenerateColumns="false"
                          runat="server" 
                          CellPadding="4" 
                          ForeColor="#333333" 
                          GridLines="Vertical" 
                          Width="338px"
                          CssClass="table table-striped table-bordered">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <Columns>
                <asp:BoundField DataField="IdVenta" HeaderText="Venta" />
<%--                <asp:BoundField DataField="IdProy" HeaderText="Proyecto" />--%>
                <%-- Modificación FernandoAMartinez --%>
                <asp:BoundField DataField="Proyecto.Id" HeaderText="IdProyecto" />
                <asp:BoundField DataField="Proyecto.Nombre" HeaderText="Nombre" />
                <%-- Modificación FernandoAMartinez --%>
                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                <asp:BoundField DataField="Importe" HeaderText="Importe" />
            </Columns>
            </asp:GridView>
        
        </div>

    <p></p>
    <asp:Button Text="Enviar" runat="server" OnClick="Enviar_Click"  CssClass="fuente"/>
    </form>
   </body>
</html>