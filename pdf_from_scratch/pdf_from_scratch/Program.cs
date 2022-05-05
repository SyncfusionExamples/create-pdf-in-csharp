using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System;
using System.IO;

namespace pdf_from_scratch
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a new PDF document.
            using (PdfDocument document = new PdfDocument())
            {
                // Set the page size.
                document.PageSettings.Size = PdfPageSize.A4;

                //Add a page to the document.
                PdfPage page = document.Pages.Add();

                //Create PDF graphics for the page.
                PdfGraphics graphics = page.Graphics;

                //create the PDF font.
                PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);

                //Draw the text.
                graphics.DrawString("Hello World!!!", font, PdfBrushes.Black, new Syncfusion.Drawing.PointF(0, 0));

                //Creating the stream object
                FileStream stream = new FileStream("output.pdf", FileMode.Create);

                //Save the document into stream
                document.Save(stream);

                stream.Close();

                //Close the document.
                document.Close(true);
            }
        }
    }
}
