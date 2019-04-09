using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ITextConvert2Excel
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\syed.mohammad\Documents\GitHub\InterviewPracticeQuestions\ITextConvert2Excel\ITextConvert2Excel\ITextConvert2Excel\TSD_Monthly_Invoice_01012019-01312019 v1.1a.xlsx";
            string outputFilePath = @"C:\Users\syed.mohammad\Documents\GitHub\InterviewPracticeQuestions\ITextConvert2Excel\ITextConvert2Excel\ITextConvert2Excel\TSD_Monthly_Invoice_01012019-01312019 v1.1a.pdf";            
            string newOutFile = @"C:\Users\syed.mohammad\Documents\GitHub\InterviewPracticeQuestions\ITextConvert2Excel\ITextConvert2Excel\ITextConvert2Excel\TSD_Monthly_Invoice_01012019-01312019 v1.1e.pdf";

            GenerateFile(filePath, outputFilePath);
            SelectPages(outputFilePath, "1", newOutFile);
        }

        public static void GenerateFile(string filePath, string outputFilePath)
        {
            SautinSoft.ExcelToPdf xtopdf = new SautinSoft.ExcelToPdf();            
            xtopdf.ConvertFile(filePath, outputFilePath);
        }
        public static void SelectPages(string inputPdf, string pageSelection, string outputPdf)
        {
            using (PdfReader reader = new PdfReader(inputPdf))
            {
                reader.SelectPages(pageSelection);

                using (PdfStamper stamper = new PdfStamper(reader, File.Create(outputPdf)))
                {
                    stamper.Close();
                }
            }

            System.IO.File.Delete(inputPdf);
        }
    }
} 
