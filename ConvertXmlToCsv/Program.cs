using System;

namespace ConvertXmlToCsvApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConvertXmlToCsv converter = new ConvertXmlToCsv();
            Validation validator = new Validation();

            string inputXmlFilePath = @"../../../inputXMLfile/testfile.xml";
            string outputCSVFilePath = @"../../../outputCSVFile";

            string CSVIntervalData = converter.getCSVIntervalDataFromXml(inputXmlFilePath);

            if (!String.IsNullOrEmpty(CSVIntervalData) && validator.checkIfCSVIntervalDataValid(CSVIntervalData))
            {
                converter.writeDataToCsv(CSVIntervalData, outputCSVFilePath);
                Console.WriteLine("Converted successfully. Please check generated CSV files in outputCSVFile folder of your current project.");
            }
            else
            {
                Console.WriteLine("Converted failed. Please check Error info");
            }
        }            
    }
}
