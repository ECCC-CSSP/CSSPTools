using ActionCommandDBServices.Models;
using ConfigServices.Services;
using CultureServices.Resources;
using GenerateCodeBaseServices.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace AngularModelsGeneratedServices.Services
{
    public partial class AngularModelsGeneratedService : ConfigService, IAngularModelsGeneratedService
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

            DirectoryInfo diOutputGen = new DirectoryInfo(Config.GetValue<string>("OutputDir"));
            if (!diOutputGen.Exists)
            {
                try
                {
                    diOutputGen.Create();
                }
                catch (Exception)
                {
                    ActionCommandDBService.ErrorText.AppendLine($"{ string.Format(CultureServicesRes.CouldNotCreateDirectory_, diOutputGen.FullName) }");
                    return false;
                }
            }

            FileInfo fiCSSPEnumsDLL = new FileInfo(Config.GetValue<string>("CSSPEnums"));
            FileInfo fiCSSPModelsDLL = new FileInfo(Config.GetValue<string>("CSSPModels"));


            ActionCommandDBService.ExecutionStatusText.AppendLine($"Reading [{ fiCSSPEnumsDLL.FullName }] ...");
            List<DLLTypeInfo> DLLTypeInfoCSSPEnumsList = new List<DLLTypeInfo>();
            if (GenerateCodeBaseService.FillDLLTypeInfoList(fiCSSPEnumsDLL, DLLTypeInfoCSSPEnumsList))
            {
                ActionCommandDBService.ErrorText.AppendLine($"{ string.Format(CultureServicesRes.CouldNotReadFile_, diOutputGen.FullName) }");
                return false;
            }
            ActionCommandDBService.ExecutionStatusText.AppendLine($"Loaded [{ fiCSSPEnumsDLL.FullName }] ...");


            ActionCommandDBService.ExecutionStatusText.AppendLine($"Reading [{ fiCSSPModelsDLL.FullName }] ...");
            List<DLLTypeInfo> DLLTypeInfoCSSPModelsList = new List<DLLTypeInfo>();
            if (GenerateCodeBaseService.FillDLLTypeInfoList(fiCSSPModelsDLL, DLLTypeInfoCSSPModelsList))
            {
                ActionCommandDBService.ErrorText.AppendLine($"{ string.Format(CultureServicesRes.CouldNotReadFile_, diOutputGen.FullName) }");
                return false;
            }
            ActionCommandDBService.ExecutionStatusText.AppendLine($"Loaded [{ fiCSSPModelsDLL.FullName }] ...");

            List<string> removeClass = new List<string>()
            {
                "CSSPAfterAttribute", "CSSPAllowNullAttribute", "CSSPBiggerAttribute", "CSSPDBContext", "CSSPDescriptionENAttribute",
                "CSSPDescriptionFRAttribute", "CSSPDisplayENAttribute", "CSSPDisplayFRAttribute", "CSSPEnumTypeAttribute",
                "CSSPEnumTypeTextAttribute", "CSSPExistAttribute", "CSSPFillAttribute", "CSSPModelsRes", "TestDBContext",
            };
            foreach (DLLTypeInfo dllTypeInfoModels in DLLTypeInfoCSSPModelsList)
            {
                if (!removeClass.Contains(dllTypeInfoModels.Name))
                {
                    CreateTypeFile(dllTypeInfoModels, DLLTypeInfoCSSPModelsList);
                }
            }

            ActionCommandDBService.ExecutionStatusText.AppendLine("");
            ActionCommandDBService.ExecutionStatusText.AppendLine($"{ CultureServicesRes.Done } ...");
            ActionCommandDBService.ExecutionStatusText.AppendLine("");
            ActionCommandDBService.ExecutionStatusText.AppendLine("Generate Finished ...");
            ActionCommandDBService.PercentCompleted = 100;
            await ActionCommandDBService.Update();

            return true;
        }
    }
}
