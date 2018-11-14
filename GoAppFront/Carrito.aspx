<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="GoAppFront.Carrito" %>
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
    </style>
</head>
<body>
    <header>
        <form runat="server">	
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
		    						<% if (((int)Session["Perfil"]) == 1)
                                        {
                                            Response.Write("<li role='presentation'><a href='Default.aspx' class='active'>Inicio</a></li>");
                                            // Parte 1 - Bitacora - LLamado al formulario de bitácora
                                            Response.Write("<li role ='presentation' ><a href ='Bitacora.aspx'>Bitacora </a></li>");
                                            Response.Write("<li role ='presentation' ><a href ='#services'>Administradores </a></li>");
                                            Response.Write("<li role ='presentation' ><a href ='Backup.aspx'>Backup</a></li>");
                                            Response.Write("<li role ='presentation' ><a href ='Contact.aspx'>Registros Erroneos</a></li>");

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
        </form>
	</header>
    <div>
        <%
            //foreach (Proj in (Proyecto)Session["Proyectos"])
            //{
            //    Response.Write("<tr><td>" + Proj.Id + "-" + Proj.Description + " by $" + Proj.Price + "</td></tr>");
            //}
            
        %>
    </div>
        <h1 class="auto-style2">Proyectos Disponibles</h1>
        <div class="auto-style1">
            <asp:DataGrid ID="dgProyecyos" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" CssClass="auto-style3"> <%--Width="687px">--%>
                <AlternatingItemStyle BackColor="White" />
                <Columns>
                    <asp:BoundColumn DataField="Id" HeaderText="Id" />
                    <asp:BoundColumn DataField="Nombre" HeaderText="Proyecto" />
                    <asp:BoundColumn DataField="Meta" HeaderText="Meta a Recaudar" />
                    <asp:BoundColumn DataField="Recuadado" HeaderText="Recaudado" />
                    <asp:BoundColumn DataField="Cantidad" HeaderText="Contribuciones" />
                    <asp:BoundColumn DataField="FechaInicio" HeaderText="Inicio de Proyecto" />
                    <asp:BoundColumn DataField="FechaFin" HeaderText="Fin de Proyecto" />
<%--                    <asp:BoundColumn DataField="Usuario.UserName" HeaderText="ID Usuario" />--%>
                </Columns>
                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <ItemStyle BackColor="#FFFBD6" ForeColor="#333333" />
                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
<%--                <SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />--%>
            </asp:DataGrid>
        </div>

</body>
</html>