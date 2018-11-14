<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Bitacora.aspx.cs" Inherits="GoAppFront.Bitacora" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="/Content/Home/bootstrap.min.css"/>
    <link rel="stylesheet" href="/Content/Home/animate.css"/>
    <link rel="stylesheet" href="/Content/Home/style.css"/>
    <title>Bitacora</title>
    <style>
        .table{
            border:solid;
            border-width: thin;
            text-decoration:none;
        }
        .auto-style1 {
            width:auto;
            margin-top: 61px;
            margin-left:auto;
            margin-right:auto;
            padding-left: 100px;

        }
        .auto-style2 {
            margin-top: 47px;
            font-family:Arial;
            font-size:large;
        }
        .auto-style3 {
            margin-top: 0;
        }
    </style>
</head>
<body>
    <header>
		<nav class="navbar navbar-default navbar-fixed-top" role="navigation">
			<div class="navigation">
				<div class="container">	
                    <form runat="server">				
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
                                        Response.Write("<li role ='presentation' ><a href ='Bitacora.aspx'>Bitacora </a></li>");
                                        Response.Write("<li role ='presentation' ><a href ='#services'>Administradores </a></li>");
                                        Response.Write("<li role ='presentation' ><a href ='#contact'>Clientes </a></li>");
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
                  </form>						
				</div>
			</div>	
		</nav>			
	</header>
<%--    <div>
        <table class="table">
              <thead>
                <tr>
                  <th scope="col" class="table">#ID</th>
                  <th scope="col" class="table">Accion</th>
                  <th scope="col" class="table">Descripcion</th>
                  <th scope="col" class="table">Usuario</th>
                </tr>
              </thead>
              <tbody>
                 <tr>
                  <th scope="row">1</th>
                  <td>Mark</td>
                  <td>Otto</td>
                  <td>@mdo</td>
                </tr>
              </tbody>
        </table>
    </div>--%>
    <section>
        <article class="container">
       <%-- <div class="table">--%>
       <%-- </div>--%>
        </article>
    </section>
    <h1 class="auto-style2">Bitácora</h1>
        <div class="auto-style1">
            <asp:DataGrid ID="dgBitacora" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" CssClass="auto-style3"> <%--Width="687px">--%>
                <AlternatingItemStyle BackColor="White" />
                <Columns>
                    <asp:BoundColumn DataField="Id" HeaderText="Bitacora" />
                    <asp:BoundColumn DataField="Accion" HeaderText="Accion" />
                    <asp:BoundColumn DataField="Descripcion" HeaderText="Descripcion" />
                    <asp:BoundColumn DataField="Fecha" HeaderText="Fecha" />
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
