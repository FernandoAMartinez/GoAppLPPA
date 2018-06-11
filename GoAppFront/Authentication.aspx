<%@ Page Title="Sign In - GoApp" Language="C#"  AutoEventWireup="true" CodeBehind="Authentication.aspx.cs" Inherits="GoAppFront.Authentication" %>

<!DOCTYPE HTML>
<!DOCTYPE html>
<html>
<head>
    <title>Login</title>
    <link rel='stylesheet prefetch' href='http://netdna.bootstrapcdn.com/bootstrap/3.0.2/css/bootstrap.min.css'>

      <link rel="stylesheet" href="/Content/style.css">
</head>
<body>
  
    <div class="wrapper">
        <form runat="server" class="form-signin" method="post" >       
            <h2 class="form-signin-heading">Inicio de Sesión</h2>
            <asp:TextBox runat="server"  CssClass="form-control" ID="txtUserName" ></asp:TextBox>
            <asp:TextBox runat="server" TextMode="Password" CssClass="form-control" ID="txtPassword" ></asp:TextBox>
            <div class="alert alert-danger" role="alert"><asp:Label ID="txtError" runat="server">Ingrese usuario y Contraseña</asp:Label></div>
            <asp:Button class="btn btn-lg btn-primary btn-block" runat="server" ID="btnLogin" Text="Login" OnClick="btnLogin_Click"/>   
        </form>
    </div>
  
</body>
</html>

