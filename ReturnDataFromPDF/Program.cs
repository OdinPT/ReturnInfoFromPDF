using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.IO;
using System.Text;

namespace ReturnDataFromPDF
{
    class Program
    {
        
        public static string GetTextFromAllPages(String pdfPath)
        {
            PdfReader reader = new PdfReader(pdfPath);

            StringWriter output = new StringWriter();

            for (int i = 1; i <= reader.NumberOfPages; i++)
                output.WriteLine(PdfTextExtractor.GetTextFromPage(reader, i, new LocationTextExtractionStrategy()));
          ;
            return output.ToString();
        }

        public static string ReadtextwithinPDF(string fileName)
        {
            StringBuilder sb = new StringBuilder();
            if (File.Exists(fileName))
            {
                PdfReader reader = new PdfReader(fileName);
                Rectangle rect = new Rectangle(0, 0, 415, 745);

                RenderFilter[] filter = { new RegionTextRenderFilter(rect) };
                ITextExtractionStrategy strategy;

                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    strategy = new FilteredTextRenderListener(new LocationTextExtractionStrategy(), filter);
                    sb.AppendLine(PdfTextExtractor.GetTextFromPage(reader, i, strategy));
                }
            }

            string path = @"C:\Users\OdinPT\Desktop\hereIAm.txt";
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(sb.ToString());
                   
                }
            }

            return sb.ToString();
        }

//função que apaga as primeiras 15 strings


        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //directory scan file
            string target = @"C:\Users\OdinPT\Desktop\";
            //file name 
            string file = @"lv.pdf";

            //string file = @"cv_eng.pdf";
            string teste = @"teste.txt";


            Console.WriteLine(ReadtextwithinPDF(target + file));

        }
    }
}
