using GenerateCodeBaseHelper;
using GenerateCodeBaseServices.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace GenerateAngularCSSPWebModels
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

            FileInfo fiCSSPEnumsDLL = new FileInfo(Configuration.GetValue<string>("CSSPEnums"));
            FileInfo fiCSSPWebModelsDLL = new FileInfo(Configuration.GetValue<string>("CSSPWebModels"));


            Console.WriteLine($"Reading [{ fiCSSPEnumsDLL.FullName }] ...");
            List<DLLTypeInfo> DLLTypeInfoCSSPEnumsList = new List<DLLTypeInfo>();
            if (GenerateCodeBase.FillDLLTypeInfoList(fiCSSPEnumsDLL, DLLTypeInfoCSSPEnumsList))
            {
                Console.WriteLine($"Could not read file { diOutputGen.FullName }");
                return false;
            }
            Console.WriteLine($"Loaded [{ fiCSSPEnumsDLL.FullName }] ...");


            Console.WriteLine($"Reading [{ fiCSSPWebModelsDLL.FullName }] ...");
            List<DLLTypeInfo> DLLTypeInfoCSSPWebModelsList = new List<DLLTypeInfo>();
            if (GenerateCodeBase.FillDLLTypeInfoList(fiCSSPWebModelsDLL, DLLTypeInfoCSSPWebModelsList))
            {
                Console.WriteLine($"Could not read file { diOutputGen.FullName }");
                return false;
            }
            Console.WriteLine($"Loaded [{ fiCSSPWebModelsDLL.FullName }] ...");

            foreach (DLLTypeInfo dllTypeInfoModels in DLLTypeInfoCSSPWebModelsList)
            {
                if (dllTypeInfoModels.Name != "LastUpdate" && GenerateCodeBase.SkipType(dllTypeInfoModels.Type))
                {
                    continue;
                }

                //if (!dllTypeInfoModels.Name.StartsWith("Web"))
                //{
                //    continue;
                //}

                //if (dllTypeInfoModels.Name != "WebProvince")
                //{
                //    continue;
                //}

                CreateTypeFile(dllTypeInfoModels, DLLTypeInfoCSSPWebModelsList);
            }


            Console.WriteLine("");
            Console.WriteLine($"Done ...");
            Console.WriteLine("");
            Console.WriteLine("Generate Finished ...");

            return await Task.FromResult(true);
        }
    }
}
