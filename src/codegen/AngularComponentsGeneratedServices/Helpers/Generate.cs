using ActionCommandDBServices.Models;
using ConfigServices.Services;
using CSSPModels;
using CSSPCultureServices.Resources;
using GenerateCodeBaseServices.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace AngularComponentsGeneratedServices.Services
{
    public partial class AngularComponentsGeneratedService : ConfigService, IAngularComponentsGeneratedService
    {
        private async Task<bool> Generate()
        {
            ActionResult<ActionCommand> actionActionCommand = await ActionCommandDBService.Get();

            if (((ObjectResult)actionActionCommand.Result).StatusCode == 400)
            {
                await ActionCommandDBService.ConsoleWriteError("actionCommand == null");
                return false;
            }

            ActionCommandDBService.ExecutionStatusText.AppendLine("Generate Starting ...");
            ActionCommandDBService.PercentCompleted = 10;
            await ActionCommandDBService.Update();

            FileInfo fiCSSPEnumsDLL = new FileInfo(Config.GetValue<string>("CSSPEnums"));
            FileInfo fiCSSPModelsDLL = new FileInfo(Config.GetValue<string>("CSSPModels"));

            ActionCommandDBService.ExecutionStatusText.AppendLine($"Reading [{ fiCSSPEnumsDLL.FullName }] ...");
            List<DLLTypeInfo> DLLTypeInfoCSSPEnumsList = new List<DLLTypeInfo>();
            if (GenerateCodeBaseService.FillDLLTypeInfoList(fiCSSPEnumsDLL, DLLTypeInfoCSSPEnumsList))
            {
                ActionCommandDBService.ErrorText.AppendLine($"{ string.Format(CSSPCultureServicesRes.CouldNotReadFile_, fiCSSPEnumsDLL.FullName) }");
                return false;
            }
            ActionCommandDBService.ExecutionStatusText.AppendLine($"Loaded [{ fiCSSPEnumsDLL.FullName }] ...");


            ActionCommandDBService.ExecutionStatusText.AppendLine($"Reading [{ fiCSSPModelsDLL.FullName }] ...");
            List<DLLTypeInfo> DLLTypeInfoCSSPModelsList = new List<DLLTypeInfo>();
            if (GenerateCodeBaseService.FillDLLTypeInfoList(fiCSSPModelsDLL, DLLTypeInfoCSSPModelsList))
            {
                ActionCommandDBService.ErrorText.AppendLine($"{ string.Format(CSSPCultureServicesRes.CouldNotReadFile_, fiCSSPModelsDLL.FullName) }");
                return false;
            }
            ActionCommandDBService.ExecutionStatusText.AppendLine($"Loaded [{ fiCSSPModelsDLL.FullName }] ...");

            int max = 3333;
            int count = 0;
            foreach (DLLTypeInfo dllTypeInfoModels in DLLTypeInfoCSSPModelsList)
            {
                if (GenerateCodeBaseService.SkipType(dllTypeInfoModels.Type))
                {
                    continue;
                }

                if (!dllTypeInfoModels.HasNotMappedAttribute)
                {
                    count += 1;
                    if (count > max) break;

                    CreateRoutingModuleFile(dllTypeInfoModels, DLLTypeInfoCSSPModelsList);
                    CreateComponentCSSFile(dllTypeInfoModels, DLLTypeInfoCSSPModelsList);
                    CreateComponentEditCSSFile(dllTypeInfoModels, DLLTypeInfoCSSPModelsList);
                    CreateComponentHTMLFile(dllTypeInfoModels, DLLTypeInfoCSSPModelsList);
                    CreateComponentEditHTMLFile(dllTypeInfoModels, DLLTypeInfoCSSPModelsList);
                    CreateComponentSpecFile(dllTypeInfoModels, DLLTypeInfoCSSPModelsList);
                    CreateComponentFile(dllTypeInfoModels, DLLTypeInfoCSSPModelsList);
                    CreateComponentEditFile(dllTypeInfoModels, DLLTypeInfoCSSPModelsList);
                    CreateLocalesFile(dllTypeInfoModels, DLLTypeInfoCSSPModelsList);
                    CreateModelsFile(dllTypeInfoModels, DLLTypeInfoCSSPModelsList);
                    CreateModuleFile(dllTypeInfoModels, DLLTypeInfoCSSPModelsList);
                    CreateServiceSpecFile(dllTypeInfoModels, DLLTypeInfoCSSPModelsList);
                    CreateServiceFile(dllTypeInfoModels, DLLTypeInfoCSSPModelsList);
                    CreateIndexFile(dllTypeInfoModels, DLLTypeInfoCSSPModelsList);
                    //CreateTypeFile(dllTypeInfoModels, DLLTypeInfoCSSPModelsList);
                }
            }

            CreateHomeRoutingModuleFile(max, DLLTypeInfoCSSPModelsList);
            CreateHomeComponentHTMLFile(max, DLLTypeInfoCSSPModelsList);

            ActionCommandDBService.ExecutionStatusText.AppendLine("");
            ActionCommandDBService.ExecutionStatusText.AppendLine($"{ CSSPCultureServicesRes.Done } ...");
            ActionCommandDBService.ExecutionStatusText.AppendLine("");
            ActionCommandDBService.ExecutionStatusText.AppendLine("Generate Finished ...");
            ActionCommandDBService.PercentCompleted = 100;
            await ActionCommandDBService.Update();

            return true;
        }
    }
}
