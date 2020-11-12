﻿using GenerateCodeBaseServices.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GenerateAngularCSSPHelperModels
{
    public partial class Startup
    {
        private void CreatePreference()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(@"/*");
            sb.AppendLine($@" * Auto generated from { AppDomain.CurrentDomain.BaseDirectory }{ AppDomain.CurrentDomain.FriendlyName}.exe");
            sb.AppendLine(@" *");
            sb.AppendLine(@" * Do not edit this file.");
            sb.AppendLine(@" *");
            sb.AppendLine(@" */");
            sb.AppendLine(@"");

            sb.AppendLine(@"export class Preference {");
            sb.AppendLine(@"    PreferenceID?: number;");
            sb.AppendLine(@"    VariableName: string;");
            sb.AppendLine(@"    VariableValue: string;");
            sb.AppendLine(@"}");


            FileInfo fiOutputGen = new FileInfo(Config.GetValue<string>("OutputDir") + "Preference.model.ts");
            using (StreamWriter sw2 = fiOutputGen.CreateText())
            {
                sw2.Write(sb.ToString());
                Console.WriteLine($"Created { fiOutputGen.FullName }");
            }
        }
    }
}
