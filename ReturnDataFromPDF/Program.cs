using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.IO;

namespace ReturnDataFromPDF
{
    class Program
    {

        public static string GetTextFromAllPages(String pdfPath)
        {
            PdfReader reader = new PdfReader(pdfPath);

            StringWriter output = new StringWriter();

            for (int i = 1; i <= reader.NumberOfPages; i++)
                output.WriteLine(PdfTextExtractor.GetTextFromPage(reader, i, new SimpleTextExtractionStrategy()));

            return output.ToString();
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
   

            //directory scan file
            string target = @"C:\Users\OdinPT\Desktop\";
            //string target = @" ";
            //file name
            string file = @"lv.pdf";
            string teste = @"comandos.txt";


            FileStream fileStream = new FileStream(target + file, FileMode.Open);
            using (StreamReader reader = new StreamReader(fileStream))
            {
                string line = reader.ReadLine();
                Console.WriteLine(line.ToString());
            }


            Console.WriteLine(GetTextFromAllPages(target + file));

        }
    }
}
