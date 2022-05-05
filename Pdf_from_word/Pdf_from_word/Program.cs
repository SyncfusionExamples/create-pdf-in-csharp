using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using Syncfusion.DocIORenderer;
using Syncfusion.Pdf;
using System;
using System.Collections.Generic;
using System.IO;

namespace Pdf_from_word
{
    class Program
    {
        static void Main(string[] args)
        {
            using (WordDocument document = new WordDocument())
            {
                //Opens the template Word document.
                Stream docStream = File.OpenRead(Path.GetFullPath(@"../../../Template.docx"));
                document.Open(docStream, FormatType.Docx);
                docStream.Dispose();
                //Gets the recipient details as an "IEnumerable" collection of .NET objects.
                List<Recipient> recipients = GetRecipients();
                //Performs the mail merge.
                document.MailMerge.Execute(recipients);

                using (DocIORenderer render = new DocIORenderer())
                {

                    //Converts Word document into PDF document
                    PdfDocument pdfDocument = render.ConvertToPDF(document);

                    //Saves the PDF file
                    FileStream outputStream = new FileStream("output.pdf", FileMode.CreateNew);
                    pdfDocument.Save(outputStream);

                    //Closes the instance of PDF document object
                    pdfDocument.Close(true);
                }
            }
        }

        private static List<Recipient> GetRecipients()
        {
            List<Recipient> recipients = new List<Recipient>();
            //Initializes the recipient details.
            recipients.Add(new Recipient("Nancy", "Davolio", "507 - 20th Ave. E.Apt. 2A", "Seattle", "WA", "98122", "USA"));
            recipients.Add(new Recipient("Andrew", "Fuller", "908 W. Capital Way", "Tacoma", "WA", "98401", "USA"));
            recipients.Add(new Recipient("Janet", "Leverling", "722 Moss Bay Blvd.", "Kirkland", "WA", "98033", "USA"));
            recipients.Add(new Recipient("Margaret", "Peacock", "4110 Old Redmond Rd.", "Redmond", "WA", "98052", "USA"));
            recipients.Add(new Recipient("Steven", "Buchanan", "14 Garrett Hil", "London", "", "SW1 8JR", "UK"));
            return recipients;
        }
    }

    class Recipient
    {
        #region Properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        #endregion

        #region Constructor
        public Recipient(string firstName, string lastName, string address, string city, string state, string zipCode, string country)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            City = city;
            State = state;
            ZipCode = zipCode;
            Country = country;
        }
        #endregion
    }
}
