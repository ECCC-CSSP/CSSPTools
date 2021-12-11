using GenerateCodeBaseHelper;
using GenerateCodeBaseServices.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace GenerateAngularCSSPHelperModels
{
    public partial class Startup
    {
        public async Task<bool> Generate()
        {
            Console.WriteLine("Generate Starting ...");

            DirectoryInfo diOutputGen = new DirectoryInfo(Configuration.GetValue<string>("OutputDir"));
            if (!diOutputGen.Exists)
            {
                try
                {
                    diOutputGen.Create();
                }
                catch (Exception)
                {
                    Console.WriteLine($"Could not create directory { diOutputGen.FullName }");
                    return false;
                }
            }

            FileInfo fiCSSPEnumsDLL = new FileInfo(Configuration["CSSPEnums"]);
            FileInfo fiCSSPDBModelsDLL = new FileInfo(Configuration["CSSPDBModels"]);
            FileInfo fiCSSPModelsDLL = new FileInfo(Configuration["CSSPModels"]);


            Console.WriteLine($"Reading [{ fiCSSPEnumsDLL.FullName }] ...");
            List<DLLTypeInfo> DLLTypeInfoCSSPEnumsList = new List<DLLTypeInfo>();
            if (GenerateCodeBase.FillDLLTypeInfoList(fiCSSPEnumsDLL, DLLTypeInfoCSSPEnumsList))
            {
                Console.WriteLine($"Could not read file { diOutputGen.FullName }");
                return false;
            }
            Console.WriteLine($"Loaded [{ fiCSSPEnumsDLL.FullName }] ...");


            Console.WriteLine($"Reading [{ fiCSSPModelsDLL.FullName }] ...");
            List<DLLTypeInfo> DLLTypeInfoCSSPModelsList = new List<DLLTypeInfo>();
            if (GenerateCodeBase.FillDLLTypeInfoList(fiCSSPModelsDLL, DLLTypeInfoCSSPModelsList))
            {
                Console.WriteLine($"Could not read file { diOutputGen.FullName }");
                return false;
            }
            Console.WriteLine($"Loaded [{ fiCSSPModelsDLL.FullName }] ...");

            List<DLLTypeInfo> DLLTypeInfoCSSPDBModelsList = new List<DLLTypeInfo>();
            if (GenerateCodeBase.FillDLLTypeInfoList(fiCSSPDBModelsDLL, DLLTypeInfoCSSPDBModelsList))
            {
                Console.WriteLine($"Could not read file { diOutputGen.FullName }");
                return false;
            }
            Console.WriteLine($"Loaded [{ fiCSSPDBModelsDLL.FullName }] ...");

            foreach (DLLTypeInfo dllTypeInfoModels in DLLTypeInfoCSSPModelsList)
            {
                if (dllTypeInfoModels.Name != "LastUpdate" && GenerateCodeBase.SkipType(dllTypeInfoModels.Type))
                {
                    continue;
                }

                //if (dllTypeInfoModels.Name != "WebProvince")
                //{
                //    continue;
                //}

                CreateTypeFile(dllTypeInfoModels, DLLTypeInfoCSSPModelsList, DLLTypeInfoCSSPDBModelsList);
            }

            CreateEnumIDAndText();

            Console.WriteLine("");
            Console.WriteLine($"Done ...");
            Console.WriteLine("");
            Console.WriteLine("Generate Finished ...");

            return await Task.FromResult(true);
        }
    }
}
