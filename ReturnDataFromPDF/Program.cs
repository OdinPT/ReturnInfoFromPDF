using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;

namespace ReturnDataFromPDF
{
    class Program
    {

       public static string ReadDATAFromPDF(string fileName)
        {
            StringBuilder sb = new StringBuilder();
            if (File.Exists(fileName))
            {
                PdfReader reader = new PdfReader(fileName);
                Rectangle rect = new Rectangle(0, 0, 415, 775);

                RenderFilter[] filter = { new RegionTextRenderFilter(rect) };
                ITextExtractionStrategy strategy;

                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    strategy = new FilteredTextRenderListener(new LocationTextExtractionStrategy(), filter);
                    sb.AppendLine(PdfTextExtractor.GetTextFromPage(reader, i, strategy));
                }
            }
            MakeFile(sb);

            return sb.ToString();
        }

        public static void MakeFile(StringBuilder s)
        {
            String path = @"..\..\..\temp.txt";
            // Create a file to write to.
            using StreamWriter sw = File.CreateText(path);
            sw.WriteLine(s.ToString());
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //directory scan file
            string target = @"C:\Users\OdinPT\Desktop\";

            string file = @"lv.pdf";
            //string file = @"cv_eng.pdf";
            

            //print in terminal and make txt file
            Console.WriteLine(ReadDATAFromPDF(target + file));

            // está a imprimire e a salvar toda a infoirmação do cv no txt 

            String path = @"..\..\..\temp.txt";
            string[] lines = System.IO.File.ReadAllLines(path);

            Console.WriteLine(lines.Length + "\n");


            for (int i = 0; i <=4; i++)
            {
                Console.WriteLine(lines[i]);
            }


        }
    }
}
//Só nome, email e numero do telemóvel