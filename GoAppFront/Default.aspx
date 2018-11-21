<%@ Page Title="Inicio" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GoAppFront._Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
   <link rel="stylesheet" href="/Content/Home/bootstrap.min.css"/>
    <link rel="stylesheet" href="/Content/Home/animate.css"/>
    <link rel="stylesheet" href="/Content/Home/style.css"/>
    <title>Inicio</title>
</head>
<body>
    <form runat="server">
    <header>
		<nav class="navbar navbar-default navbar-fixed-top" role="navigation">
			<div class="navigation">
				<div class="container">	
                    <%--<form runat="server">--%>				
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

                                    if (((int)Session["Perfil"]) == 1) //Web Master
                                    {
                                        Response.Write("<li role='presentation'><a href='Default.aspx' class='active'>Inicio</a></li>");
                                        Response.Write("<li role ='presentation' ><a href ='Bitacora.aspx'>Bitacora </a></li>");
                                        //Response.Write("<li role ='presentation' ><a href ='#services'>Administradores </a></li>");
                                        Response.Write("<li role ='presentation' ><a href ='Backup.aspx'>Backup & Restore</a></li>");
                                        //Response.Write("<li role ='presentation' ><a href ='Contact.aspx'>Registros Erroneos</a></li>");
                                        Response.Write("<li role='presentation'><a href='AltaProyecto.aspx'>Alta Proyectos</a></li>");
                                        Response.Write("<li role='presentation'><a href='Carrito.aspx'>Carrito (" + cantCarro.ToString() +")</a></li>");

                                    }
                                    else if (((int)Session["Perfil"]) == 2) //Administrador
                                    {
                                        Response.Write("<li role='presentation'><a href='Default.aspx' class='active'>Inicio</a></li>");
                                        Response.Write("<li role ='presentation' ><a href ='Bitacora.aspx'>Bitacora </a></li>");
                                        //Response.Write("<li role ='presentation' ><a href ='#contact'>Clientes </a></li>");
                                        Response.Write("<li role = 'presentation'><a href='Backup.aspx'> Backup & Restore</a></li>");
                                    }
                                    else //Usuario Normal
                                    {
                                        Response.Write("<li role='presentation'><a href='Default.aspx' class='active'>Inicio</a></li>");
                                        Response.Write("<li role ='presentation' ><a href ='#about'>Sobre Nosotros </a></li>");
                                        Response.Write("<li role ='presentation' ><a href ='#services'>Servicios </a></li>");
                                        Response.Write("<li role ='presentation' ><a href ='#contact'>Contacto</a></li>");
                                        Response.Write("<li role='presentation'><a href='AltaProyecto.aspx'>Alta Proyectos</a></li>");
                                        Response.Write("<li role='presentation'><a href='Carrito.aspx'>Carrito (" + cantCarro.ToString() +")</a></li>");

                                    }
                                %>		
                               <li><a href ="LogOut.aspx">Cerrar Sesion</a></li>	
							</ul>
						</div>
					</div>
                  <%--</form>--%>						
				</div>
			</div>	
		</nav>			
	</header>
    <section>
        <h1 class="auto-style2">Proyectos Disponibles</h1>
        <div class="auto-style1">
            <br /><br />
            <asp:DataGrid ID="dgProyectos" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" CssClass="auto-style3"> <%--Width="687px">--%>
                <AlternatingItemStyle BackColor="White" />
                <Columns>
                    <asp:BoundColumn DataField="Id" HeaderText="Id" />
                    <asp:BoundColumn DataField="Nombre" HeaderText="Proyecto" />
                    <asp:BoundColumn DataField="Meta" HeaderText="Meta a Recaudar" />
                    <asp:BoundColumn DataField="Recaudado" HeaderText="Recaudado" />
                    <asp:BoundColumn DataField="Cantidad" HeaderText="Contribuciones" />
                    <asp:BoundColumn DataField="FechaInicio" HeaderText="Inicio de Proyecto" />
                    <asp:BoundColumn DataField="FechaFin" HeaderText="Fin de Proyecto" />
                    <asp:TemplateColumn>
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="AddToCart" OnClick="AddToCart_Click">Add to Cart</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                </Columns>
                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <ItemStyle BackColor="#FFFBD6" ForeColor="#333333" />
                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            </asp:DataGrid>
        </div>

    </section>
        </form>
</body>
</html>