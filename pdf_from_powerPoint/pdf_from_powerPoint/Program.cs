using Syncfusion.Pdf;
using Syncfusion.Presentation;
using Syncfusion.PresentationRenderer;
using System.IO;

namespace pdf_from_powerPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            //Load the PowerPoint presentation into stream.
            using (FileStream fileStreamInput = new FileStream(@"../../../InputTemplate.pptx", FileMode.Open, FileAccess.Read))
            {
                //Open the existing PowerPoint presentation with loaded stream.
                using (IPresentation pptxDoc = Presentation.Open(fileStreamInput))
                {
                    //Create the MemoryStream to save the converted PDF.
                    using (MemoryStream pdfStream = new MemoryStream())
                    {
                        //Convert the PowerPoint document to PDF document.
                        using (PdfDocument pdfDocument = PresentationToPdfConverter.Convert(pptxDoc))
                        {
                            //Save the converted PDF document to MemoryStream.
                            pdfDocument.Save(pdfStream);
                            pdfStream.Position = 0;
                        }
                        //Create the output PDF file stream
                        using (FileStream fileStreamOutput = File.Create("Output.pdf"))
                        {
                            //Copy the converted PDF stream into created output PDF stream
                            pdfStream.CopyTo(fileStreamOutput);
                        }
                    }
                }
            }
        }
    }
}
