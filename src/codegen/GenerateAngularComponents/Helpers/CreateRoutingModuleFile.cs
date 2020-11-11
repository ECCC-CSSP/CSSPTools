﻿using GenerateCodeBaseServices.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GenerateAngularComponents
{
    public partial class Startup
    {
        private void CreateRoutingModuleFile(DLLTypeInfo dllTypeInfoModels, List<DLLTypeInfo> DLLTypeInfoCSSPDBModelsList)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(@"/*");
            sb.AppendLine($@" * Auto generated from { AppDomain.CurrentDomain.BaseDirectory }{ AppDomain.CurrentDomain.FriendlyName}.exe");
            sb.AppendLine(@" *");
            sb.AppendLine(@" * Do not edit this file.");
            sb.AppendLine(@" *");
            sb.AppendLine(@" */");
            sb.AppendLine(@"");

            sb.AppendLine(@"import { NgModule } from '@angular/core';");
            sb.AppendLine(@"import { Routes, RouterModule } from '@angular/router';");
            sb.AppendLine($@"import {{ { dllTypeInfoModels.Name }Component }} from './{ dllTypeInfoModels.Name.ToLower() }.component';");
            sb.AppendLine(@"import { AuthGuard } from '../../../guards';");
            sb.AppendLine(@"");
            sb.AppendLine(@"const routes: Routes = [");
            sb.AppendLine($@"  {{ path: '', component: { dllTypeInfoModels.Name }Component, canActivate: [AuthGuard]  }}");
            sb.AppendLine(@"];");
            sb.AppendLine(@"");
            sb.AppendLine(@"@NgModule({");
            sb.AppendLine(@"  imports: [RouterModule.forChild(routes)],");
            sb.AppendLine(@"  exports: [RouterModule]");
            sb.AppendLine(@"})");
            sb.AppendLine($@"export class { dllTypeInfoModels.Name }RoutingModule {{ }}");

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
                    Console.WriteLine(ErrorText);
                    return;
                }
            }

            FileInfo fiOutputGen = new FileInfo(Config.GetValue<string>("RoutingModuleFileName").Replace("{TypeNameLower}", dllTypeInfoModels.Name.ToLower()).Replace("{TypeNameLower}", dllTypeInfoModels.Name.ToLower()));
            using (StreamWriter sw2 = fiOutputGen.CreateText())
            {
                sw2.Write(sb.ToString());
                Console.WriteLine($"Created { fiOutputGen.FullName }");
            }
        }
    }
}
