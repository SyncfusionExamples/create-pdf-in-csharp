using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System;
using System.IO;

namespace pdf_from_images
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new instance of PdfDocument class.
            using (PdfDocument document = new PdfDocument())
            {

                // Add a new page to the newly created document.
                PdfPage page = document.Pages.Add();

                PdfStandardFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 12, PdfFontStyle.Bold);

                PdfGraphics g = page.Graphics;

                g.DrawString("JPEG Image", font, PdfBrushes.Blue, new Syncfusion.Drawing.PointF(0, 40));

                //Load JPEG image to stream.
                FileStream jpgImageStream = new FileStream("../../../jpeg_image.jpg", FileMode.Open);

                //Load the JPEG image
                PdfImage jpgImage = new PdfBitmap(jpgImageStream);

                //Draw the JPEG image
                g.DrawImage(jpgImage, new Syncfusion.Drawing.RectangleF(0, 70, 515, 215));

                g.DrawString("PNG Image", font, PdfBrushes.Blue, new Syncfusion.Drawing.PointF(0, 355));

                //Load PNG image to stream.
                FileStream pngImageStream = new FileStream("../../../png_image.png", FileMode.Open);

                //Load the PNG image
                PdfImage pngImage = new PdfBitmap(pngImageStream);

                g.DrawImage(pngImage, new Syncfusion.Drawing.RectangleF(0, 365, 199, 300));

                FileStream fileStream = new FileStream("Sample.pdf", FileMode.CreateNew, FileAccess.ReadWrite);

                //Save and close the PDF document 
                document.Save(fileStream);

                document.Close(true);
            }
        }
    }
}
