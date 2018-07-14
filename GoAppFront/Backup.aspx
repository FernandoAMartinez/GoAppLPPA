<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Backup.aspx.cs" Inherits="GoAppFront.Backup" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
   <link rel="stylesheet" href="/Content/Home/bootstrap.min.css"/>
    <link rel="stylesheet" href="/Content/Home/animate.css"/>
    <link rel="stylesheet" href="/Content/Home/style.css"/>
    <link rel='stylesheet prefetch' href='http://netdna.bootstrapcdn.com/bootstrap/3.0.2/css/bootstrap.min.css'/>


    <title> Backup</title>

    <style>
        .backup{
            padding-top: 50px;
        }
    </style>
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
    <form runat="server">
        <header>
        <nav class="navbar navbar-default navbar-fixed-top" role="navigation">
            <div class="navigation">
                <div class="container">
                    <%--<form runat="server">--%>
                    <%--<asp:Content runat="server" ContentPlaceHolderID="navbar">--%>
                        <div class="navbar-header">
                            <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target=".navbar-collapse.collapse">
                                <span class="sr-only">Toggle navigation</span>
                                <span class="icon-bar"></span>
                                <span class="icon-bar"></span>
                                <span class="icon-bar"></span>
                            </button>
                            <div class="navbar-brand">
                                <a href="Default.aspx">
                                    <h1><% Response.Write((string)Session["PerfilDesc"]); %></h1>
                                </a>
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
                                        }
                                        else if (((int)Session["Perfil"]) == 2)
                                        {
                                            Response.Write("<li role='presentation'><a href='Default.aspx' class='active'>Inicio</a></li>");
                                            Response.Write("<li role ='presentation' ><a href ='Bitacora.aspx'>Bitacora </a></li>");
                                            Response.Write("<li role ='presentation' ><a href ='Backup.aspx'>Backup</a></li>");
                                            // Agregado Backup Restore
                                            Response.Write("<li role = 'presentation'><a href='Backup.aspx'> Backup </a></li>");
                                            Response.Write("<li role = 'presentation'><a href='Restore.aspx'> Restore </a></li>");
                                        }
                                        else
                                        {
                                            Response.Write("<li role='presentation'><a href='Default.aspx' class='active'>Home</a></li>");
                                            Response.Write("<li role ='presentation' ><a href ='#about'>Sobre Nosotros </a></li>");
                                            Response.Write("<li role ='presentation' ><a href ='#services'>Servicios </a></li>");
                                            Response.Write("<li role ='presentation' ><a href ='#contact'>Contacto</a></li>");
                                        }
                                    %>
                                    <li><a href="LogOut.aspx">Cerrar Sesion</a></li>
                                </ul>
                            </div>
                        </div>
                    <%--</form>--%>
                    <%--</asp:Content>--%>
                </div>
            </div>
        </nav>
    </header>
        <section class="backup">
            <article class="wrapper">
                <div class="backup">
                    <br />
                    <asp:Label runat="server" Text="Destino de Backup" ID="lblEstado"></asp:Label>
<%--                    <asp:TextBox runat="server" ID="tbPath" CssClass="form-control"></asp:TextBox>--%>
                    <asp:Button runat="server" Text="..." OnClick="Search_Click" class="btn btn-lg btn-primary btn-block"/>
                    <br />
                    <asp:Button runat="server" Text="Ejecutar Backup" OnClick="Backup_Click" class="btn btn-lg btn-primary btn-block"/>
                </div>
            </article>
        </section>
    </form>
</body>
</html>