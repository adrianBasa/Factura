using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factura
{
    public class Factura1
    {
        public void CreateInvoice(Dictionary<string, string> staticValues, Dictionary<string, string> details, Customer customerData)
        {


            PdfDocument document = new PdfDocument();
            document.Info.Author = "Rolf Baxter";
            document.Info.Keywords = "PdfSharp, Examples, C#";

            PdfPage page = document.AddPage();
            page.Size = PageSize.A4;

            // Obtain an XGraphics object to render to
            XGraphics gfx = XGraphics.FromPdfPage(page);

            // Create a font
            double fontHeight =8 ;
            XFont font = new XFont("Times New Roman", fontHeight);
            XFont font2 = new XFont("Times New Roman", fontHeight, XFontStyle.BoldItalic);
           


            // Get the centre of the page
            double y = 0;
            int lineCount = 0;
            double linePadding = 0;

            // Create a rectangle to draw the text in and draw in it
            var newLine = DrawLine("Golubei Adrian PFA", fontHeight, page.Width, y, font2, lineCount, gfx);
            lineCount = newLine.Item1;
            y = newLine.Item2;

           


            foreach (var item in staticValues)
            {
                newLine = DrawLine(item.Key, fontHeight, page.Width, y, font, lineCount, gfx); 
                newLine = DrawLine(item.Value, fontHeight, page.Width, y, font2, lineCount, gfx, Convert.ToInt32(item.Key.Length * 4.32));             
                lineCount = newLine.Item1;
                 y = newLine.Item2;
              
            }
         

            double topY = y - (lineCount * fontHeight) - linePadding;

            // Draw a line below the text
            gfx.DrawLine(XPens.Black, 0, y, page.Width, y + linePadding);

            // Draw a line above the text
          //  gfx.DrawLine(XPens.Black, 0, topY, page.Width, topY);
            y += fontHeight;
            var InvoiceTextLine = DrawLine("INVOICE", fontHeight, page.Width, y, font2, lineCount, gfx);
            lineCount = InvoiceTextLine.Item1;
            y = InvoiceTextLine.Item2;

            foreach (var item in details)
            {
                newLine = DrawLine(item.Key, fontHeight, page.Width, y, font, lineCount, gfx);
                newLine = DrawLine(item.Value, fontHeight, page.Width, y, font2, lineCount, gfx, Convert.ToInt32(item.Key.Length * 3.80));
                lineCount = newLine.Item1;
                y = newLine.Item2;

            }

            // buyer details 
            y += fontHeight;
            var BuyerLine = DrawLine("BUYER", fontHeight, page.Width,  InvoiceTextLine.Item2 - 10, font2, lineCount, gfx, Convert.ToInt32(400));
           lineCount = InvoiceTextLine.Item1;
            y = InvoiceTextLine.Item2;

            var buyerName = DrawLine(customerData.CompanyName, fontHeight, page.Width, y, font, lineCount, gfx, Convert.ToInt32(400));
            lineCount = buyerName.Item1;
            y = buyerName.Item2;

            var buyerAdres = DrawLine("ADRESS", fontHeight, page.Width, y, font2, lineCount, gfx, Convert.ToInt32(400));
            lineCount = buyerAdres.Item1;
            y = buyerAdres.Item2;

            var buyerAdres1 = DrawLine(customerData.Address, fontHeight, page.Width, y, font, lineCount, gfx, Convert.ToInt32(400));
            var buyercomma = DrawLine(",", fontHeight, page.Width, y, font, lineCount, gfx, Convert.ToInt32(449));
            var buyerAdres2 = DrawLine(customerData.City, fontHeight, page.Width, y, font, lineCount, gfx, Convert.ToInt32(452));
            lineCount = buyerAdres2.Item1;
            y = buyerAdres2.Item2;

            var buyerAdres3 = DrawLine(customerData.ZipCode, fontHeight, page.Width, y, font, lineCount, gfx, Convert.ToInt32(400));
            lineCount = buyerAdres3.Item1;
            y = buyerAdres3.Item2;
          
            var buyerVat = DrawLine("VAT Number", fontHeight, page.Width, y, font2, lineCount, gfx, Convert.ToInt32(400));
            lineCount = buyerVat.Item1;
            y = buyerVat.Item2;

            var buyerVatNumber = DrawLine(customerData.VAT, fontHeight, page.Width, y , font, lineCount, gfx, Convert.ToInt32(400));
            lineCount = buyerVatNumber.Item1;
            y = buyerVatNumber.Item2;

            gfx.DrawLine(XPens.Black, 0, y, page.Width, y + linePadding);




            //create table



            // Save and show the document
            document.Save("TestDocument.pdf");
            Process.Start("TestDocument.pdf");
        }

        public Tuple<int, double> DrawLine(string text, double fontHeight, XUnit pageWidth, double y, XFont font, int lineCount, XGraphics gfx, int x = 0)
        {
            XRect rect = new XRect(x, y, pageWidth, fontHeight);
            gfx.DrawString(text, font, XBrushes.Black, rect, XStringFormats.TopLeft);
            
            lineCount++;
            y += fontHeight;
            return Tuple.Create(lineCount, y);
        }
    }
}
