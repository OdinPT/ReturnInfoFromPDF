using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;


namespace ReturnDataFromPDF
{
    class Program
    {

        public static string ReadDATAFromPDF(string fileName, string path)
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
            MakeTempFile(sb, path);
            return sb.ToString();
        }

        //make file with all data from pdf file 
        public static void MakeTempFile(StringBuilder s, string path)
        {
            using StreamWriter sw = File.CreateText(path);
            sw.WriteLine(s.ToString());

        }

        public static void FirstLines(string path)
        {
            List<Pessoa> pessoas;

            string[] lines = System.IO.File.ReadAllLines(path);

            string word = lines[0];

            int x = word.IndexOf(" ") + 1;
            string str = word.Substring(x);
            int z = str.IndexOf(" ") + 1;
            string nome = str.Substring(z);

            pessoas = new List<Pessoa>();

            Pessoa emp3 = new Pessoa(nome, lines[2], lines[4]);
            pessoas.Add(emp3);

            Console.WriteLine(emp3.ToString());
            
        }

        public static void Main(string[] args)
        {
            //directory scan file and pdf to read
            string target = @"C:\Users\OdinPT\Desktop\";

            List<Pessoa> pessoas;

            //directory file with  all data
            String path = @"..\..\..\temp.txt";

            //string file = @"joana.pdf";
            string file = @"lv.pdf";
            
            ReadDATAFromPDF(target + file, path);
            FirstLines(path);

            //delete file with all pdf data
            //File.Delete(path);

        }
    }
}
