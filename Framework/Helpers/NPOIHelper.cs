using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Helpers
{
    public class NPOIHelper //static method Read Excl that takes in actual file path
    {
        public static List<string> ReadExcel(string filePath)  //static method Read Excl that takes in actual file path
        {
            //Declare list of strings to contain my content
            List<string> rowList = new List<string>();
            ISheet sheet;
            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                stream.Position = 0;
                XSSFWorkbook xssfWorkbook = new XSSFWorkbook(stream);
                sheet = xssfWorkbook.GetSheetAt(0);
                IRow headerRow = sheet.GetRow(0);
                int cellCount = headerRow.LastCellNum;

                for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
                    {
                    IRow row = sheet.GetRow(i);
                    if (row == null) continue;
                    if (row.Cells.All(d => d.CellType == CellType.Blank)) continue;
                    for (int j = row.FirstCellNum; j < cellCount; j++)
                    {
                        if (row.GetCell(j) !=null)
                        {
                            if(!string.IsNullOrEmpty(row.GetCell(j).ToString()) && !string.IsNullOrWhiteSpace(row.GetCell(j).ToString()))
                            {
                                rowList.Add(row.GetCell(j).ToString());
                            }
                        }
                    }
                }
            }
            return rowList;
        }
        public static string ReadExcel(string filePath, int rowCell, int columnCell)
        {
            string content = null;
            List<string> rowList = new List<string>();
            ISheet sheet;
            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                stream.Position = 0;
                XSSFWorkbook xssfWorkbook = new XSSFWorkbook(stream);
                sheet = xssfWorkbook.GetSheetAt(0);
                IRow headerRow = sheet.GetRow(0);
                int cellCount = headerRow.LastCellNum;
                IRow row = sheet.GetRow(rowCell);
                content = row.GetCell(columnCell).ToString();
            }
            return content;

        }

    }
}
