using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GenerateEnumsPolSourceInfoRelatedFiles
{
    public partial class Startup
    {
        public async Task<bool> Generate()
        {
            Console.WriteLine("Generate Starting ...");

            Console.WriteLine($"Reading Excel document and checking");

            FileInfo fiExcel = new FileInfo(Configuration.GetValue<string>("ExcelFileName"));

            if (!await polSourceGroupingExcelFileReadService.ReadExcelSheet(fiExcel.FullName, false))
            {
                return await Task.FromResult(false);
            }

            if (polSourceGroupingExcelFileReadService.GroupChoiceChildLevelList.Count() == 0)
            {
                string ErrorText = $"Error _GroupChoiceChildLevelList is equal to 0";
                Console.WriteLine($"{ ErrorText }");

                return await Task.FromResult(false);
            }

            Console.WriteLine($"Reading Excel document and checking Done ...");

            if (!await Generate_FillPolSourceObsInfoChildService()) await Task.FromResult(false);
            if (!await Generate_EnumsPolSourceInfo()) await Task.FromResult(false);
            if (!await Generate_PolSourceObsInfoEnum()) await Task.FromResult(false);
            if (!await Generate_EnumsPolSourceObsInfoEnumTest()) await Task.FromResult(false);
            if (!await Generate_PolSourceInfoEnumGeneratedRes_resx()) await Task.FromResult(false);
            if (!await Generate_PolSourceInfoEnumGeneratedResFR_resx()) await Task.FromResult(false);

            Console.WriteLine($"Done ...");
            Console.WriteLine("");
            Console.WriteLine("Generate Finished ...");

            return await Task.FromResult(true);
        }
    }
}
