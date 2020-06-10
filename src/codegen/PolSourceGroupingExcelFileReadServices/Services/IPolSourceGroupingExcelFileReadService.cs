using PolSourceGroupingExcelFileReadServices.Models;
using ActionCommandDBServices.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolSourceGroupingExcelFileReadServices.Services
{
    public interface IPolSourceGroupingExcelFileReadService
    {
        List<GroupChoiceChildLevel> GroupChoiceChildLevelList { get; set; }

        Task<bool> ReadExcelSheet(string FullFileName, bool DoCheck);
    }
}
