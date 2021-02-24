using GenerateCodeBaseServices.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GenerateCompareDBFieldsAndCSSPDBModelsProp
{
    partial class Startup
    {
        public async Task<bool> Generate()
        {

            string CSSPDB = Configuration.GetValue<string>("CSSPDB");

            if (CSSPDB == null)
            {
                Console.WriteLine("CSSPDB == null");
                return await Task.FromResult(false);
            }

            Console.WriteLine("Generate Starting ...");
           
            if (!await FillPublicList()) return await Task.FromResult(false);

            List<Table> tableCSSPWebList = new List<Table>();
            List<TypeProp> typePropList = new List<TypeProp>();

            // loading what currently exist in the DB
            if (!await LoadDBInfo(tableCSSPWebList, CSSPDB)) return await Task.FromResult(false);

            // Loading what exist in the compiled CSSPDBModels.dll
            if (!await LoadCSSPDBModelsDLLInfo(typePropList)) return await Task.FromResult(false);

            // Compare DB and Compiled CSSPDBModels.DLL
            if (!await CompareDBAndCSSPDBModelsDLL(tableCSSPWebList, typePropList)) return await Task.FromResult(false);

            Console.WriteLine("");
            Console.WriteLine($"Done ...");
            Console.WriteLine("");
            Console.WriteLine("Generate Finished ...");

            return await Task.FromResult(true);
        }
    }
}
