using CSSPCultureServices.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GenerateCSSPSQLiteServices
{
    public partial class Startup
    {
        public async Task<bool> Generate()
        {
            Console.WriteLine("Generate Starting ...");

            StringBuilder sb = new StringBuilder();

            FileInfo fiDLL = new FileInfo(Configuration.GetValue<string>("CSSPDBModels"));

            if (!fiDLL.Exists)
            {
                Console.WriteLine($"Could not find file [{ fiDLL.FullName }]");
                return await Task.FromResult(false);
            }

            if (! await CheckAllModelExist(fiDLL)) await Task.FromResult(false);
            if (!await CreateFillListTableToDelete(fiDLL)) await Task.FromResult(false);
            if (!await CreateTableBuilder(fiDLL)) await Task.FromResult(false);
            
            Console.WriteLine("");
            Console.WriteLine($"{ CSSPCultureServicesRes.Done } ...");
            Console.WriteLine("");
            Console.WriteLine("Generate Finished ...");

            return await Task.FromResult(true);
        }
    }
}
