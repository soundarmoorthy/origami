using IronXL;
using System.IO;
using System.Data;
using System.Linq;

namespace Origami
{
    public static class DMAResultsWriter
    {
        public static void WriteExcel(DataTable table, string targetFile)
        {
            WorkBook workBook = new WorkBook(ExcelFileFormat.XLSX);
            var sheet = workBook.CreateWorkSheet("CompatilityIssues");
            var columns = table.Columns;
            for (int i = 1; i <= columns.Count; i++)
            {
                sheet.SetCellValue(1, i, columns[i - 1].ColumnName);
            }

            var ind = 2;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                var cols = table.Rows[i].ItemArray;
                for (int j = 0; j < cols.Count(); j++)
                {
                    sheet.SetCellValue(ind, j + 1, cols[j]);
                }
                ind++;
            }

            var stream = workBook.ToStream();
            stream.WriteTo(File.OpenWrite(targetFile));
        }
    }
}
