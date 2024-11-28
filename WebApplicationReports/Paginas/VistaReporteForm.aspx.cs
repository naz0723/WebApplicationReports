using iText.Kernel.Colors;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplicationReports.Clases;

namespace WebApplicationReports.Paginas
{
    public partial class VistaReporteForm : System.Web.UI.Page
    {
        // Clase para representar los datos del JSON
        public Persona persona = new Persona();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Simulación de datos JSON
                var data = new List<Persona>
                {
                    new Persona { ID = 1, Nombre = "Karla Brenes", Edad = 20 },
                    new Persona { ID = 2, Nombre = "Joshua Andrey", Edad = 30 },
                    new Persona { ID = 3, Nombre = "Johel Perez", Edad = 50 },
                    new Persona { ID = 4, Nombre = "Daniela Rojas", Edad = 27 }
                };

                gvData.DataSource = data;
                gvData.DataBind();
            }
        }

        protected void btnGeneratePDF_Click(object sender, EventArgs e)
        {
            // Simulación de datos JSON
            var data = new List<Persona>
        {
            new Persona { ID = 1, Nombre = "Karla Brenes", Edad = 20 },
            new Persona { ID = 2, Nombre = "Joshua Andrey", Edad = 30 },
            new Persona { ID = 3, Nombre = "Johel Perez", Edad = 50 },
            new Persona { ID = 4, Nombre = "Daniela Rojas", Edad = 27 }
        };

            // Ordenar los datos
            var listaOrdenada = data.OrderBy(a => a.ID).ToList();

            // Ruta de la carpeta Reportes
            string folderPath = Server.MapPath("~/Reportes");

            // Verificar si la carpeta existe, si no, crearla
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            // Ruta completa del archivo PDF
            string filePath = Path.Combine(folderPath, "Reporte.pdf");

            // Crear el archivo PDF
            using (var writer = new PdfWriter(filePath))
            {
                using (var pdf = new PdfDocument(writer))
                {
                    var document = new Document(pdf);

                    // Título
                    var titulo = new Paragraph("Reporte de Personas")
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetFontSize(18)
                        .SetFontColor(ColorConstants.WHITE)
                        .SetBackgroundColor(new DeviceRgb(26, 115, 232)) // #1a73e8
                        .SetPadding(10);
                    document.Add(titulo);

                    // Crear la tabla (con 3 columnas)
                    var table = new iText.Layout.Element.Table(3).UseAllAvailableWidth();

                    // Encabezados con estilo
                    table.AddHeaderCell(new Cell().Add(new Paragraph("ID"))
                        .SetBackgroundColor(new DeviceRgb(0, 121, 107)) // #00796b
                        .SetFontColor(ColorConstants.WHITE)
                        .SetTextAlignment(TextAlignment.CENTER));
                    table.AddHeaderCell(new Cell().Add(new Paragraph("Nombre"))
                        .SetBackgroundColor(new DeviceRgb(0, 121, 107)) // #00796b
                        .SetFontColor(ColorConstants.WHITE)
                        .SetTextAlignment(TextAlignment.CENTER));
                    table.AddHeaderCell(new Cell().Add(new Paragraph("Edad"))
                        .SetBackgroundColor(new DeviceRgb(0, 121, 107)) // #00796b
                        .SetFontColor(ColorConstants.WHITE)
                        .SetTextAlignment(TextAlignment.CENTER));

                    // Agregar datos con estilos
                    foreach (var persona in listaOrdenada)
                    {
                        table.AddCell(new Cell().Add(new Paragraph(persona.ID.ToString()))
                            .SetBackgroundColor(new DeviceRgb(241, 241, 241)) // #f1f1f1
                            .SetFontColor(new DeviceRgb(51, 51, 51))); // #333333

                        table.AddCell(new Cell().Add(new Paragraph(persona.Nombre))
                            .SetBackgroundColor(new DeviceRgb(241, 241, 241)) // #f1f1f1
                            .SetFontColor(new DeviceRgb(51, 51, 51))); // #333333

                        table.AddCell(new Cell().Add(new Paragraph(persona.Edad.ToString()))
                            .SetBackgroundColor(new DeviceRgb(241, 241, 241)) // #f1f1f1
                            .SetFontColor(new DeviceRgb(51, 51, 51))); // #333333
                    }

                    // Agregar la tabla al documento
                    document.Add(table);
                }
            }

            // Descargar el archivo PDF
            Response.ContentType = "application/pdf";
            Response.AppendHeader("Content-Disposition", "attachment; filename=Reporte.pdf");
            Response.TransmitFile(filePath);
            Response.End();
        }
    }
}