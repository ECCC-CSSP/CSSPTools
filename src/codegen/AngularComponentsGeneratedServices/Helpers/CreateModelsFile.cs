﻿using ConfigServices.Services;
using CultureServices.Resources;
using GenerateCodeBaseServices.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AngularComponentsGeneratedServices.Services
{
    public partial class AngularComponentsGeneratedService : ConfigService, IAngularComponentsGeneratedService
    {
        private void CreateModelsFile(DLLTypeInfo dllTypeInfoModels, List<DLLTypeInfo> DLLTypeInfoCSSPModelsList)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(@"/*");
            sb.AppendLine($@" * Auto generated from { AppDomain.CurrentDomain.BaseDirectory }{ AppDomain.CurrentDomain.FriendlyName}.exe");
            sb.AppendLine(@" *");
            sb.AppendLine(@" * Do not edit this file.");
            sb.AppendLine(@" *");
            sb.AppendLine(@" */");
            sb.AppendLine(@"");

            sb.AppendLine($@"export interface { dllTypeInfoModels.Name }TextModel {{");
            sb.AppendLine(@"    Title?: string");
            sb.AppendLine(@"}");

            DirectoryInfo di = new DirectoryInfo(Config.GetValue<string>("OutputDir").Replace("{TypeNameLower}", dllTypeInfoModels.Name.ToLower()));
            if (!di.Exists)
            {
                try
                {
                    di.Create();
                }
                catch (Exception ex)
                {
                    string ErrorText = ex.Message + ex.InnerException != null ? ex.InnerException.Message : "";
                    ActionCommandDBService.ErrorText.AppendLine(ErrorText);
                    return;
                }
            }

            FileInfo fiOutputGen = new FileInfo(Config.GetValue<string>("ModelsFileName").Replace("{TypeNameLower}", dllTypeInfoModels.Name.ToLower()).Replace("{TypeNameLower}", dllTypeInfoModels.Name.ToLower()));
            using (StreamWriter sw2 = fiOutputGen.CreateText())
            {
                sw2.Write(sb.ToString());
                ActionCommandDBService.ExecutionStatusText.AppendLine($"{ string.Format(CultureServicesRes.Created_, fiOutputGen.FullName) }");
            }

            fiOutputGen = new FileInfo(Config.GetValue<string>("ModelsFileName").Replace("{TypeNameLower}", dllTypeInfoModels.Name.ToLower()).Replace("{TypeNameLower}", dllTypeInfoModels.Name.ToLower()));
            if (fiOutputGen.Exists)
            {
                string fileLine = "Last Write Time [" + fiOutputGen.LastWriteTime.ToString("yyyy MMMM dd HH:mm:ss") + "] " + fiOutputGen.FullName;
                ActionCommandDBService.FilesStatusText.AppendLine(fileLine);
            }
            else
            {
                string fileLine = "Not Created" + fiOutputGen.FullName;
                ActionCommandDBService.FilesStatusText.AppendLine(fileLine);
            }

        }
    }
}
