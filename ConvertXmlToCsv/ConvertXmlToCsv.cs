using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace ConvertXmlToCsvApp
{
    public class ConvertXmlToCsv
    {
        private static readonly XNamespace ase = "urn:aseXML:r32";

        public string getCSVIntervalDataFromXml(string xmlFilePath)
        {
            try
            {
                var xmlDoc = XDocument.Load(xmlFilePath);
                var dataElement
                    = xmlDoc.Element(ase + "aseXML").Element("Transactions").Element("Transaction").Element("MeterDataNotification").Element("CSVIntervalData");

                if (dataElement != null)
                {
                    //remove blank space for each line 
                    return string.Join("\n", dataElement.Value.Split("\n").Select(s => s.Trim(' ', '\t')));
                }
                else
                {
                    Console.WriteLine("Error: Cannot find CSVIntervalData element in XML file");
                    return null;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error: Exception happened when reading XML file. " + ex.Message);
            }
            return null;
        }

        public void writeDataToCsv(string CSVIntervalData, string outputCSVFilePath)
        { 
            string row100 = "";
            string row900 = "";

            if(string.IsNullOrEmpty(CSVIntervalData))
            {
                Console.WriteLine("Error: Cannot find CSVIntervalData");
                return;
            }

            // extract row 100 from CSVIntervalData
            var m = Regex.Match(CSVIntervalData, @"(\n100.+)\n");
            if (m.Success)
            {
                row100 = m.Groups[1].Value;
                row100 = Regex.Replace(row100, @"\t|\n|\r", "");
                CSVIntervalData = Regex.Replace(CSVIntervalData, @"(\n100.+)", string.Empty);
            }
            else
            {
                Console.WriteLine("Error: Cannot find row 100");
                return;
            }

            // extract row 900 from CSVIntervalData
            var m2 = Regex.Match(CSVIntervalData, @"(\n900.*)");
            if (m2.Success)
            {
                row900 = m2.Groups[1].Value;
                CSVIntervalData = Regex.Replace(CSVIntervalData, @"(\n900.*)", string.Empty);
                CSVIntervalData = CSVIntervalData.TrimEnd();
            }
            else
            {
                Console.WriteLine("Error: Can not find row 900");
                return;
            }

            // split 200 blocks into List from CSVIntervalData
            var csvBlock = Regex.Split(CSVIntervalData, @"(?=\n200)").Where(s => s != String.Empty).ToList();

            // write data to csv files
            if (csvBlock.Count > 0)
            {
                try
                {
                    StringBuilder sb = new StringBuilder();

                    for (int i = 0; i < csvBlock.Count; i++)
                    {
                        sb.Clear();
                        sb.Append(row100);
                        sb.Append(csvBlock[i]);
                        sb.Append(row900);

                        var csvFileName = Regex.Match(csvBlock[i], @"(?<=,)\w+(?=,)");

                        string path = System.IO.Path.Combine(outputCSVFilePath, csvFileName + ".csv");

                        using (var sw = new StreamWriter(path))
                        {
                            sw.WriteLine(sb);
                            sw.Close();
                        }
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Error: Exception happened when generating CSV files. " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Error: Cannot find row 200 blocks");
                return;
            }
        }


    }
}
