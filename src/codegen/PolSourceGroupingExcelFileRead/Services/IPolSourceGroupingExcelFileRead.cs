using PolSourceGroupingExcelFileRead.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolSourceGroupingExcelFileRead.Services
{
    public interface IPolSourceGroupingExcelFileRead
    {
        Task<bool> ReadExcelSheet(string FullFileName, bool DoCheck, StringBuilder sbError, StringBuilder sbStatus);
        Task<bool> GetRecursiveForShowAllPaths(string s, List<string> textList, int Level, bool RaiseEvents, StringBuilder sb);
        Task SetCulture(CultureInfo Culture);
    }
}
