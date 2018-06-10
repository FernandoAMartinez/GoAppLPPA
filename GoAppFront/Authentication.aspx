<%@ Page Title="Sign In - GoApp" Language="C#"  AutoEventWireup="true" CodeBehind="Authentication.aspx.cs" Inherits="GoAppFront.Authentication" %>

<!DOCTYPE HTML>
<!DOCTYPE html>
<html>
<head>
    <title></title>
    <style type="text/css">
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
            height: 206px;
            margin-top: 34px;
            width: 405px;
        }

        .button {
            background-color: #008cec; /* Green */
            border: none;
            color: white;
            padding: 15px 32px;
            text-align: center;
            text-decoration: none;
            display: inline-block;
            font-size: 16px;
        }
        .input[type=text] {
            width: 100%;
            padding: 12px 20px;
            margin: 8px 0;
            box-sizing: border-box;
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
            <h1>Inicio de Sesión</h1>
            <!-- User -->
            <asp:Label ID="Label1" runat="server" Text="Usuario: " Height="19px" Width="83px"></asp:Label> <asp:TextBox ID="tbUser" runat="server" CssClass="input" Width="142px"></asp:TextBox>
            <br />
            <br />
            <!-- Password -->
            <asp:Label ID="Label2" runat="server" Text="Contraseña: ">Contraseña: </asp:Label> <asp:TextBox ID="tbPassword" runat="server" CssClass="input" TextMode="Password" Height="32px" Width="184px"></asp:TextBox>
            <br />
            <br />
            <!-- Execute -->
            <asp:Button ID="Button1" runat="server" Text="Iniciar Sesión" CssClass="button" OnClick="Button1_Click" />

        </div>
        
    </form>
</body>
</html>


<%--<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your application description page.</h3>
    <p>Use this area to provide additional information.</p>
</asp:Content>--%>
