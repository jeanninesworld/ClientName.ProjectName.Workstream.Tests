﻿using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Helpers
{
    public class ExcelDataHelper
    {
        public static IEnumerable<object> ReadExcel(string filePath, string sheet)
        {

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage package = new ExcelPackage (new FileInfo(filePath)))
        {
            ExcelWorksheet worksheet = package.Workbook.Worksheets[sheet];
            //get the first worksheet in workbook

            int rowCount = worksheet.Dimension.End.Row;
            int colCount = worksheet.Dimension.End.Column;
            for(int row = 2; row <=rowCount; row++)
            {
                for(int col = 1; col <= colCount; col++)
                {
                    yield return new object[]
                    {
                        worksheet.Cells[row,col].Value?.ToString().Trim()
                    };
                }
            }

        }
        }
        public static string ReadExcel(string filePath, string sheet, int row, int column)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage package = new ExcelPackage(new FileInfo(filePath)))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[sheet];
                //get the first worksheet in workbook
                return worksheet.Cells[row, column].Value?.ToString().Trim();
            }
        }
    }
}
