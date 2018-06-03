<%@ Page Title="Sign In - GoApp" Language="C#"  AutoEventWireup="true" CodeBehind="Authentication.aspx.cs" Inherits="GoAppFront.Authentication" %>

<!DOCTYPE HTML>
<!DOCTYPE html>
<html>
<head>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 140px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            <!-- User -->
            <asp:Label ID="Label1" runat="server" Text="Usuario: ">Usuario: </asp:Label> <asp:TextBox ID="tbUser" runat="server" Width="142px"></asp:TextBox>
            <br />
            <!-- Password -->
            <asp:Label ID="Label2" runat="server" Text="Contraseña: ">Contraseña: </asp:Label> <asp:TextBox ID="tbPassword" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            <!-- Execute -->
            <asp:Button ID="Button1" runat="server" Text="Iniciar Sesión" />
        </div>
    </form>
</body>
</html>


<%--<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your application description page.</h3>
    <p>Use this area to provide additional information.</p>
</asp:Content>--%>
