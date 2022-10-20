using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace ConvertXmlToCsvApp
{
    public class Validation
    {
        public Boolean checkIfCSVIntervalDataValid(string data)
        {
            int row100count = 0;
            int row200count = 0;
            int row300count = 0;
            int row900count = 0;

            if(string.IsNullOrEmpty(data))
            {
                Console.WriteLine("Error: Data provided for validation is empty");
            }

            var csvRowIds = Regex.Matches(data, @"(?<=\n)\d+").ToList();

            if (csvRowIds.First().Value != "100")
            {
                Console.WriteLine("Error: 100 row should be the first row");
                return false;
            }

            if (csvRowIds.Last().Value != "900")
            {
                Console.WriteLine("Error: 900 row should be the first row");
                return false;
            }

            foreach (var rowId in csvRowIds)
            {
                switch (rowId.Value)
                {
                    case "100":
                    {
                        row100count++;
                        if (row100count > 1)
                        {
                            Console.WriteLine("Error: 100 rows should only appear once inside the CSVIntervalData element");
                            return false;
                        }
                        break;
                    }

                    case "200":
                    {
                        row200count++;
                        if (row200count < row100count)
                        {
                            Console.WriteLine("Error: 200 rows can only be after the header");
                            return false;
                        }
                        break;
                    }

                    case "300":
                    {
                        row300count++;
                        if (row300count < row100count)
                        {
                            Console.WriteLine("Error: 300 rows can only be after the header");
                            return false;
                        }

                        if (row200count == 0)
                        {
                            Console.WriteLine("Error: 300 rows must follow a 200 row");
                            return false;
                        }

                        if (row300count < row200count)
                        {
                            Console.WriteLine("Error: 200 row must be followed by at least 1 300 row");
                            return false;
                        }
                        break;
                    }

                    case "900":
                    {
                        row900count++;
                        if (row900count > 1)
                        {
                            Console.WriteLine("Error: 900 row should only appear once inside the CSVIntervalData element");
                            return false;
                        }
                        break;
                    }

                    default:
                        Console.WriteLine("Error: Valid rows within the CSVIntervalData element can only start with 100, 200, 300, 900");
                        return false;
                }
            }

            if (row100count < 1 || row200count < 1 || row300count < 1 || row900count < 1)
            {
                Console.WriteLine("Error: The CSVIntervalData element should contain at least 1 row for each of 100, 200, 300,900");
                return false;
            }

            return true;
        }
    }
}
