<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AltaProyecto.aspx.cs" Inherits="GoAppFront.AltaProyecto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
                <asp:Label runat="server" ID="lblDescripcion" Text="Descripcion "></asp:Label>
                <asp:TextBox runat="server" ID="txtDescripcion"></asp:TextBox>
        </div>
        <p>
            <asp:Label runat="server" ID="lblImporte" Text="Importe pretendido "></asp:Label>
            <asp:TextBox runat="server" ID="TxtImporte"></asp:TextBox>
            </p>

        <p>
            <asp:Label runat="server" ID="lblFecha" Text="Fecha de publicacion "></asp:Label>
            <asp:TextBox runat="server" ID="txtFecha"></asp:TextBox>
            </p>

        <p>
            <asp:Button runat="server" ID="btnPublicar" Text="Publicar" OnClick="btnPublicar_Onclick"/>
        </p>
    </form>

</body>
</html>
