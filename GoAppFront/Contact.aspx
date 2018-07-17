<%@ Page Title="Bitacoras" Language="C#" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="GoAppFront.Contact" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registros Erroneos</title>

</head>
<body class="body">
    
    <form action="/" method="post" id="formErrores">
        <asp:DataGrid ID="dgErrores" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingItemStyle BackColor="White" />
                <Columns>
                    <asp:BoundColumn DataField="Columna 1" HeaderText="Columna 1" />
                    <asp:BoundColumn DataField="Columna 2" HeaderText="Columna 2" />
                    <asp:BoundColumn DataField="Columna 3" HeaderText="Columna 3" />
                    <asp:BoundColumn DataField="Columna 4" HeaderText="Columna 4" />
                    <asp:BoundColumn DataField="Columna 5" HeaderText="Columna 5" />
                    <asp:BoundColumn DataField="Columna 6" HeaderText="Columna 6" />
                    <asp:BoundColumn DataField="Columna 7" HeaderText="Columna 7" />
<%--                    <asp:BoundColumn DataField="Usuario.UserName" HeaderText="ID Usuario" />--%>
                </Columns>
                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <ItemStyle BackColor="#FFFBD6" ForeColor="#333333" />
                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
<%--                <SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />--%>
            </asp:DataGrid>

    </form>
    

</body>
</html>
