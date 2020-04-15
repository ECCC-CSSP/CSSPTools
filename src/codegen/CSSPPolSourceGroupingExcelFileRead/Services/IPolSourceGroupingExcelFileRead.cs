using CSSPPolSourceGroupingExcelFileRead.Models;
using StatusAndResultsDBService.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPPolSourceGroupingExcelFileRead.Services
{
    public interface IPolSourceGroupingExcelFileRead
    {
        List<GroupChoiceChildLevel> groupChoiceChildLevelList { get; set; }

        Task<bool> ReadExcelSheet(string FullFileName, bool DoCheck, StringBuilder sbError, StringBuilder sbStatus, string command, IStatusAndResultsService statusAndResultsService);
        Task<bool> GetRecursiveForShowAllPaths(string s, List<string> textList, int Level, bool RaiseEvents, StringBuilder sb, StringBuilder sbError, StringBuilder sbStatus, string command, IStatusAndResultsService statusAndResultsService);
        Task SetCulture(CultureInfo Culture);
    }
}
