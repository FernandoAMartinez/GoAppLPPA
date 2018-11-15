<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AltaProyecto.aspx.cs" Inherits="GoAppFront.AltaProyecto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Alta de Proyectos</title>
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
        .contents-under {
          padding-top: 50px;
        }

        .fuente {
            color: black;
        }
    </style>
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
		    						<% if (((int)Session["Perfil"]) == 1)
                                        {
                                            Response.Write("<li role='presentation'><a href='Default.aspx' class='active'>Inicio</a></li>");
                                            // Parte 1 - Bitacora - LLamado al formulario de bitácora
                                            Response.Write("<li role ='presentation' ><a href ='Bitacora.aspx'>Bitacora </a></li>");
                                            Response.Write("<li role ='presentation' ><a href ='#services'>Administradores </a></li>");
                                            Response.Write("<li role ='presentation' ><a href ='Backup.aspx'>Backup</a></li>");
                                            Response.Write("<li role ='presentation' ><a href ='Contact.aspx'>Registros Erroneos</a></li>");
                                            Response.Write("<li role='presentation'><a href='AltaProtecto.aspx'>Alta Proyectos</a></li>");
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
        
	</header>
        <section>
            <div class="contents-under fuente">
                <br /><br /><br /><br /><br /><br />
                <asp:Label Text="Nombre Proyecto" runat="server" /> &nbsp; <asp:TextBox ID="tbNombre" runat="server" /><br />
                <asp:Label Text="Meta a Recaudar" runat="server" /> &nbsp; <asp:TextBox ID="tbMeta" runat="server" /><br />
                <asp:Label Text="Inicio del Proyecto" runat="server" /> &nbsp; <asp:TextBox ID="tbInico" runat="server" /><br />
                <asp:Label Text="Fin del Proyecto" runat="server" /> &nbsp; <asp:TextBox ID="tbFin" runat="server" /><br />
                <asp:Button Text="Enviar" runat="server" OnClick="AltaProyecto_Click" /><br />
            </div>
        </section>
    </form>
</body>
</html>
