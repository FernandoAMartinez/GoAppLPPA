<%@ Page Title="Sign In - GoApp" Language="C#"  AutoEventWireup="true" CodeBehind="Authentication.aspx.cs" Inherits="GoAppFront.Authentication" %>

<!DOCTYPE HTML>
<!DOCTYPE html>
<html>
<head>
    <title></title>
    <style type="text/css">
                .auto-style1 {
            height: 140px;
            margin-top: 34px;
        }
        /* The navigation bar */
                 .navbar {
                    overflow: hidden;
                    background-color: #333;
                    position: fixed; /* Set the navbar to fixed position */
                    top: 0; /* Position the navbar at the top of the page */
                    width: 100%; /* Full width */
                }
        
        /* Links inside the navbar */
                .navbar a {
                    float: left;
                    display: block;
                    color: #f2f2f2;
                    text-align: center;
                    padding: 14px 16px;
                    text-decoration: none;
                }
        
        /* Change background on mouse-over */
                .navbar a:hover {
                    background: #ddd;
                    color: black;
                }
        
        /* Main content */
                .main {
                    margin-top: 30px; /* Add a top margin to avoid content overlay */
                }
        .auto-style2 {
            height: 140px;
            margin-top: 34px;
            width: 405px;
        }
    </style>
</head>
<body>
    <!-- Navbar -->
    <div class="navbar">
        <a href="Default.aspx">Inicio</a>
        <a href="Contact.aspx">Propuesta</a>
        <a href="Contact.aspx">¿Quienes somos?</a>
        <a href="Contact.aspx">Contacto</a>
        <a href="Authentication.aspx">Iniciar Sesión</a>
    </div> 
    <!-- Navbar -->
    <br />
    <form id="form1" runat="server">
        <div class="auto-style2">
            <br />
            <!-- User -->
            <asp:Label ID="Label1" runat="server" Text="Usuario: ">Usuario: </asp:Label> <asp:TextBox ID="tbUser" runat="server" Width="142px"></asp:TextBox>
            <br />
            <!-- Password -->
            <asp:Label ID="Label2" runat="server" Text="Contraseña: ">Contraseña: </asp:Label> <asp:TextBox ID="tbPassword" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            <!-- Execute -->
            <asp:Button ID="Button1" runat="server" Text="Iniciar Sesión" OnClick="Button1_Click" />
        </div>
        
    </form>
</body>
</html>


<%--<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your application description page.</h3>
    <p>Use this area to provide additional information.</p>
</asp:Content>--%>
