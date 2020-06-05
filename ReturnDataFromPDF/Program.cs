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

        //gera ficheiro com todo o texto do pdf
        public static void MakeTempFile(StringBuilder s, string path)
        {
            // Create a file to write to.
            using StreamWriter sw = File.CreateText(path);

            sw.WriteLine(s.ToString());
            
        }

        public static void FirstLines(string path, string end)
        {
            List<Pessoa> pessoas;

            string[] lines = System.IO.File.ReadAllLines(path);
            using StreamWriter sw = File.CreateText(end);

            string word = lines[0];

            // retira as 2 palavras antes do nome
            int x = word.IndexOf(" ") + 1;
            string str = word.Substring(x);
            int z = str.IndexOf(" ") + 1;
            string nome = str.Substring(z);

            // escreve o nome no ficheiro
            sw.WriteLine(nome);

            // add  values to class pessoa
            pessoas   = new List<Pessoa>();
            Pessoa emp3 = new Pessoa(nome, lines[2], lines[4]);
            pessoas.Add(emp3);
            
        }

        //Só nome, email e numero do telemóvel
        public static void Main(string[] args)
        {

            List<Pessoa> pessoas;

            //Console.WriteLine("Hello World!");

            //directory scan file and pdf to read
            string target = @"C:\Users\OdinPT\Desktop\";
            string file = @"joana.pdf";
            //string file = @"cv_eng.pdf";


            //directory file with  all data
            String path = @"..\..\..\temp.txt";

            //directory file with  name. number and email from cv
            String end = @"..\..\..\DataFromPDF.txt";

            //read from pdf and write in txt temp file
            ReadDATAFromPDF(target + file, path);
            

            FirstLines(path, end);

            //File.Delete(path);

            //pessoas = new List<Pessoa>();

            //for (int i = 2; i <= 4; i++)
            //{
            //    Console.WriteLine("\n\n");
            //    Pessoa emp3 = new Pessoa(" Joã XX ", "1111111111", "1222222");
            //    //pessoas.Add(emp3);

            //    Console.WriteLine(emp3.ToString());


            //}


        }
    }
}

