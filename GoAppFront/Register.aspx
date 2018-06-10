<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="GoAppFront.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <link rel='stylesheet prefetch' href='http://netdna.bootstrapcdn.com/bootstrap/3.0.2/css/bootstrap.min.css'>

      <link rel="stylesheet" href="/Content/style.css">
    <title>Registrarse</title>
</head>
<body>
   <div class="wrapper">
    <form runat="server" class="form-signin">       
      <h2 class="form-signin-heading">Registrarse</h2>
        <asp:TextBox runat="server"  CssClass="form-control" ID="txtUserName" ></asp:TextBox>
        <asp:TextBox runat="server" TextMode="Password" CssClass="form-control" ID="txtPassword" ></asp:TextBox>
        <div class="alert alert-danger" role="alert"><asp:Label ID="txtError" runat="server"></asp:Label></div>
        <asp:Button class="btn btn-lg btn-primary btn-block" runat="server" ID="btnRegistrarse" Text="Registrarse" OnClick="btnRegistrarse_Click"/>   
    </form>
  </div>
</body>
</html>
