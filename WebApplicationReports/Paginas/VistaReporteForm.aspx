<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VistaReporteForm.aspx.cs" Inherits="WebApplicationReports.Paginas.VistaReporteForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
       <title>Generar Reporte en PDF</title>
    <style>
        /* Estilo general para la página */
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 0;
        }

        /* Contenedor principal */
        #form1 {
            max-width: 800px;
            margin: 30px auto;
            padding: 20px;
            background-color: #ffffff;
            border-radius: 8px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
        }

        /* Título principal */
        h1 {
            text-align: center;
            color: #1a73e8;
            font-size: 24px;
            margin-bottom: 20px;
        }

        /* Contenedor del reporte */
        .report-container {
            border: 2px solid #1a73e8; /* Borde azul brillante */
            padding: 20px;
            margin-bottom: 30px;
            border-radius: 8px;
            background-color: #ffffff;
        }

        .report-container h2 {
            color: #1a73e8;
            font-size: 22px;
            text-align: center;
            margin-bottom: 20px;
        }

        /* Estilo para el GridView */
        .gridview {
            width: 100%;
            border-collapse: collapse;
            margin-bottom: 20px;
        }

        .gridview th, .gridview td {
            padding: 12px;
            text-align: left;
            border: 1px solid #ddd;
        }

        .gridview th {
            background-color: #00796b; /* Color de fondo verde oscuro */
            color: white;
        }

        .gridview td {
            background-color: #f1f1f1; /* Fondo gris claro */
            color: #333333; /* Texto gris oscuro */
        }

        .gridview tr:hover {
            background-color: #e1e1e1; /* Fondo gris al pasar el mouse */
        }

        /* Contenedor para el botón */
        .button-container {
            text-align: center;
            margin-top: 20px;
        }

        /* Botón de generar PDF */
        .btn {
            background-color: #1a73e8;
            color: white;
            padding: 10px 20px;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            font-size: 16px;
            width: 100%;
            max-width: 200px; /* Limita el tamaño máximo del botón */
        }

        .btn:hover {
            background-color: #155b9e;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <!-- Contenedor de reporte -->
        <div class="report-container">
            <h2>Generador de Reportes en PDF</h2>
            
            <!-- GridView de personas -->
            <asp:GridView ID="gvData" runat="server" AutoGenerateColumns="False" CssClass="gridview">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Edad" HeaderText="Edad" />
                </Columns>
            </asp:GridView>
        </div>

        <!-- Contenedor para el botón -->
        <div class="button-container">
            <!-- Botón para generar PDF -->
            <asp:Button ID="btnGeneratePDF" runat="server" Text="Generar PDF" OnClick="btnGeneratePDF_Click" CssClass="btn" />
        </div>
    </form>
</body>
</html>
