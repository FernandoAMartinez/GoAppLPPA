<%@ Page Title="Bitacoras" Language="C#" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="GoAppFront.Contact" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bitácoras</title>
    <style type="text/css">
        /* The navigation bar */
             .navbar {
                overflow: hidden;
                background-color: #333;
                position: fixed; /* Set the navbar to fixed position */
                top: 0; /* Position the navbar at the top of the page */
                width: 100%; /* Full width */
                height: 35px;
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
            .main
        
            /* Body */
            .body{
                background-color: gainsboro;
            }
    </style>
</head>
<body class="body">
      <!-- Navbar -->
    <div class="navbar">
        <a href="Default.aspx">Inicio</a>
        <a href="Contact.aspx">Propuesta</a>
        <a href="Contact.aspx">¿Quienes somos?</a>
        <a href="Contact.aspx">Contacto</a>
    </div> 
    <!-- Navbar -->
    

</body>
</html>
