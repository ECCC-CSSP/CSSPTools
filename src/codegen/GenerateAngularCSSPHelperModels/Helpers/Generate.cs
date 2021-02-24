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

            DirectoryInfo diOutputGen = new DirectoryInfo(Config.GetValue<string>("OutputDir"));
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

            FileInfo fiCSSPEnumsDLL = new FileInfo(Config.GetValue<string>("CSSPEnums"));
            FileInfo fiCSSPHelperModelsDLL = new FileInfo(Config.GetValue<string>("CSSPHelperModels"));


            Console.WriteLine($"Reading [{ fiCSSPEnumsDLL.FullName }] ...");
            List<DLLTypeInfo> DLLTypeInfoCSSPEnumsList = new List<DLLTypeInfo>();
            if (GenerateCodeBase.FillDLLTypeInfoList(fiCSSPEnumsDLL, DLLTypeInfoCSSPEnumsList))
            {
                Console.WriteLine($"Could not read file { diOutputGen.FullName }");
                return false;
            }
            Console.WriteLine($"Loaded [{ fiCSSPEnumsDLL.FullName }] ...");


            Console.WriteLine($"Reading [{ fiCSSPHelperModelsDLL.FullName }] ...");
            List<DLLTypeInfo> DLLTypeInfoCSSPHelperModelsList = new List<DLLTypeInfo>();
            if (GenerateCodeBase.FillDLLTypeInfoList(fiCSSPHelperModelsDLL, DLLTypeInfoCSSPHelperModelsList))
            {
                Console.WriteLine($"Could not read file { diOutputGen.FullName }");
                return false;
            }
            Console.WriteLine($"Loaded [{ fiCSSPHelperModelsDLL.FullName }] ...");

            foreach (DLLTypeInfo dllTypeInfoModels in DLLTypeInfoCSSPHelperModelsList)
            {
                if (dllTypeInfoModels.Name != "LastUpdate" && GenerateCodeBase.SkipType(dllTypeInfoModels.Type))
                {
                    continue;
                }

                //if (dllTypeInfoModels.Name != "WebProvince")
                //{
                //    continue;
                //}

                CreateTypeFile(dllTypeInfoModels, DLLTypeInfoCSSPHelperModelsList);
            }

            CreateEnumIDAndText();
            CreatePreference();
            CreateCSSPFile();

            Console.WriteLine("");
            Console.WriteLine($"Done ...");
            Console.WriteLine("");
            Console.WriteLine("Generate Finished ...");

            return await Task.FromResult(true);
        }
    }
}
