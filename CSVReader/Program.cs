using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;

namespace CSVReader
{
    internal class Program
    {
        static void Main()
        {
            // variable declaration
            FileInfo fileInfo = new FileInfo(@"C:\Users\keval\source\repos\CSVReader\stocks.xlsx");

            // using - performs automatic garbage collection upon completion of the block it's defined for.
            using (ExcelPackage package = new ExcelPackage(fileInfo))
            {
                // variable declaration: Excel Worksheet, # of Rows used, # of columns used.
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                int rows = worksheet.Dimension.Rows;
                int columns = worksheet.Dimension.Columns;

                // perform calculation
                // iterate through each accessible cell to print the set within each row
                for (int i = 1; i < rows; i++)
                {
                    // Console.WriteLine("Row: " + i);
                    for(int j = 1; j < columns; j++)
                    {
                        // Console.WriteLine("Column: " + j);
                        Console.WriteLine(worksheet.Cells[i, j].Value);
                    }
                    Console.WriteLine("\n");
                }
            }
        }
    }
}
