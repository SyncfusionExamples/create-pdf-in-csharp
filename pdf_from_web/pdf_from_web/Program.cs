using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;
using System;
using System.IO;

namespace pdf_from_web
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initialize HTML to PDF converter with Blink rendering engine
            HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter(HtmlRenderingEngine.Blink);

            BlinkConverterSettings blinkConverterSettings = new BlinkConverterSettings();
            blinkConverterSettings.ViewPortSize = new Syncfusion.Drawing.Size(1440, 0);
         
            //Assign Blink converter settings to HTML converter
            htmlConverter.ConverterSettings = blinkConverterSettings;

            //Convert URL to PDF
            PdfDocument document = htmlConverter.Convert("https://www.syncfusion.com");

            FileStream fileStream = new FileStream("Sample.pdf", FileMode.CreateNew, FileAccess.ReadWrite);

            //Save and close the PDF document 
            document.Save(fileStream);
            document.Close(true);
        }
    }
}
