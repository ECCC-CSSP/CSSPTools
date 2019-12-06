using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Linq;

namespace ConsoleAppTestingOpenXML
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ReadXL();
        }

        public static SharedStringItem GetSharedStringItemById(WorkbookPart workbookPart, int id)
        {
            return workbookPart.SharedStringTablePart.SharedStringTable.Elements<SharedStringItem>().ElementAt(id);
        }

        private static Cell GetCell(Worksheet worksheet, string columnName, uint rowIndex)
        {
            Row row = GetRow(worksheet, rowIndex);

            if (row == null)
                return null;

            return row.Elements<Cell>().Where(c => string.Compare
                      (c.CellReference.Value, columnName +
                      rowIndex, true) == 0).First();
        }

        // Given a worksheet and a row index, return the row.
        private static Row GetRow(Worksheet worksheet, uint rowIndex)
        {
            return worksheet.GetFirstChild<SheetData>().
                  Elements<Row>().Where(r => r.RowIndex == rowIndex).First();
        }

        public static void ReadXL()
        {
            using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Open($@"C:\CSSPTools\src\assets\Book1.xlsx", false))
            {
                var sheets = spreadsheetDocument.WorkbookPart.Workbook.Descendants<Sheet>();

                foreach (Sheet sheet in sheets)
                {
                    WorkbookPart workbookPart = spreadsheetDocument.WorkbookPart;
                    WorksheetPart worksheetPart = (WorksheetPart)spreadsheetDocument.WorkbookPart.GetPartById(sheet.Id);
                    Worksheet worksheet = worksheetPart.Worksheet;

                    for (int i = 1; i < 4; i++)
                    {
                        Cell cell = GetCell(worksheet, "A", (uint)i);

                        string cellValue = string.Empty;

                        if (cell.DataType != null)
                        {
                            if (cell.DataType == CellValues.SharedString)
                            {
                                int id = -1;

                                if (Int32.TryParse(cell.InnerText, out id))
                                {
                                    SharedStringItem item = GetSharedStringItemById(workbookPart, id);

                                    if (item.Text != null)
                                    {
                                        cellValue = item.Text.Text;
                                    }
                                    else if (item.InnerText != null)
                                    {
                                        cellValue = item.InnerText;
                                    }
                                    else if (item.InnerXml != null)
                                    {
                                        cellValue = item.InnerXml;
                                    }
                                }
                                Console.WriteLine(cellValue);
                            }
                        }
                        else
                        {
                            Console.WriteLine(cell.CellValue.Text);
                        }

                    }
                }
            }

        }
    }
}
