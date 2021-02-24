using CSSPCultureServices.Resources;
using GenerateCodeBaseHelper;
using GenerateCodeBaseServices.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace GenerateAngularComponents
{
    public partial class Startup
    {
        public async Task<bool> Generate()
        {
            Console.WriteLine("Generate Starting ...");

            FileInfo fiCSSPEnumsDLL = new FileInfo(Configuration.GetValue<string>("CSSPEnums"));
            FileInfo fiCSSPDBModelsDLL = new FileInfo(Configuration.GetValue<string>("CSSPDBModels"));

            Console.WriteLine($"Reading [{ fiCSSPEnumsDLL.FullName }] ...");
            List<DLLTypeInfo> DLLTypeInfoCSSPEnumsList = new List<DLLTypeInfo>();
            if (GenerateCodeBase.FillDLLTypeInfoList(fiCSSPEnumsDLL, DLLTypeInfoCSSPEnumsList))
            {
                Console.WriteLine($"{ string.Format(CSSPCultureServicesRes.CouldNotReadFile_, fiCSSPEnumsDLL.FullName) }");
                return false;
            }
            Console.WriteLine($"Loaded [{ fiCSSPEnumsDLL.FullName }] ...");


            Console.WriteLine($"Reading [{ fiCSSPDBModelsDLL.FullName }] ...");
            List<DLLTypeInfo> DLLTypeInfoCSSPDBModelsList = new List<DLLTypeInfo>();
            if (GenerateCodeBase.FillDLLTypeInfoList(fiCSSPDBModelsDLL, DLLTypeInfoCSSPDBModelsList))
            {
                Console.WriteLine($"{ string.Format(CSSPCultureServicesRes.CouldNotReadFile_, fiCSSPDBModelsDLL.FullName) }");
                return false;
            }
            Console.WriteLine($"Loaded [{ fiCSSPDBModelsDLL.FullName }] ...");

            int max = 3333;
            int count = 0;
            foreach (DLLTypeInfo dllTypeInfoModels in DLLTypeInfoCSSPDBModelsList)
            {
                if (GenerateCodeBase.SkipType(dllTypeInfoModels.Type))
                {
                    continue;
                }

                if (!dllTypeInfoModels.HasNotMappedAttribute)
                {
                    count += 1;
                    if (count > max) break;

                    CreateRoutingModuleFile(dllTypeInfoModels, DLLTypeInfoCSSPDBModelsList);
                    CreateComponentCSSFile(dllTypeInfoModels, DLLTypeInfoCSSPDBModelsList);
                    CreateComponentEditCSSFile(dllTypeInfoModels, DLLTypeInfoCSSPDBModelsList);
                    CreateComponentHTMLFile(dllTypeInfoModels, DLLTypeInfoCSSPDBModelsList);
                    CreateComponentEditHTMLFile(dllTypeInfoModels, DLLTypeInfoCSSPDBModelsList);
                    CreateComponentSpecFile(dllTypeInfoModels, DLLTypeInfoCSSPDBModelsList);
                    CreateComponentFile(dllTypeInfoModels, DLLTypeInfoCSSPDBModelsList);
                    CreateComponentEditFile(dllTypeInfoModels, DLLTypeInfoCSSPDBModelsList);
                    CreateLocalesFile(dllTypeInfoModels, DLLTypeInfoCSSPDBModelsList);
                    CreateModelsFile(dllTypeInfoModels, DLLTypeInfoCSSPDBModelsList);
                    CreateModuleFile(dllTypeInfoModels, DLLTypeInfoCSSPDBModelsList);
                    CreateServiceSpecFile(dllTypeInfoModels, DLLTypeInfoCSSPDBModelsList);
                    CreateServiceFile(dllTypeInfoModels, DLLTypeInfoCSSPDBModelsList);
                    CreateIndexFile(dllTypeInfoModels, DLLTypeInfoCSSPDBModelsList);
                    //CreateTypeFile(dllTypeInfoModels, DLLTypeInfoCSSPDBModelsList);
                }
            }

            CreateHomeRoutingModuleFile(max, DLLTypeInfoCSSPDBModelsList);
            CreateHomeComponentHTMLFile(max, DLLTypeInfoCSSPDBModelsList);

            Console.WriteLine("");
            Console.WriteLine($"{ CSSPCultureServicesRes.Done } ...");
            Console.WriteLine("");
            Console.WriteLine("Generate Finished ...");

            return await Task.FromResult(true);
        }
    }
}
