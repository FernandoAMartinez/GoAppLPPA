<%@ Page Title="Página de Inicio" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GoAppFront._Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head><title>Inicio de GoApp</title>
    <style type="text/css">
        .auto-style1 {
            width: 527px;
        }
        .auto-style2{
            width: 50px;
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
    </style>
</head>
<body>
    <!-- Menú de Usuario -->
    <div class="navbar">
        <table>
            <tr>
                <td class="auto-style2">
                    <a href="Default.aspx">Inicio</a>
                </td>
                <td class="auto-style2">
                    <a href="Contact.aspx">Contacto</a>
                </td>
            </tr>
        </table>
    </div> 
    <!-- Menú de Usuario -->
    <br />
    
</body>
</html>