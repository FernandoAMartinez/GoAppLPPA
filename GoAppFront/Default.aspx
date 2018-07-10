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
<%--    <!-- Navbar -->
    <div class="navbar">
        <a href="Default.aspx">Inicio</a>
        <a href="Contact.aspx">Propuesta</a>
        <a href="Contact.aspx">¿Quienes somos?</a>
        <a href="Contact.aspx">Contacto</a>
        <a href="Authentication.aspx">Iniciar Sesión</a>
    </div> 
    <!-- Navbar -->
    <br />--%>

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
                                        // Parte 1 - Bitacora - LLamado al formulario de bitácora
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
    
</body>
</html>