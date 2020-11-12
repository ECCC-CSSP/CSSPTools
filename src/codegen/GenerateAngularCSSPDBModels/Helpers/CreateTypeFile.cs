﻿using GenerateCodeBaseServices.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GenerateAngularCSSPDBModels
{
    public partial class Startup
    {
        private void CreateTypeFile(DLLTypeInfo dllTypeInfoModels, List<DLLTypeInfo> DLLTypeInfoCSSPDBModelsList)
        {
            StringBuilder sb = new StringBuilder();
            List<string> fileNameUsedList = new List<string>();
            List<string> removeTypeList = new List<string>()
            {
                "Int32", "Int16", "Int64", "Single", "Float", "Double", "String", "DateTime", "Boolean"
            };
            List<string> PropToSkip = new List<string>();

            sb.AppendLine(@"/*");
            sb.AppendLine($@" * Auto generated from { AppDomain.CurrentDomain.BaseDirectory }{ AppDomain.CurrentDomain.FriendlyName}.exe");
            sb.AppendLine(@" *");
            sb.AppendLine(@" * Do not edit this file.");
            sb.AppendLine(@" *");
            sb.AppendLine(@" */");
            sb.AppendLine(@"");

            if (!dllTypeInfoModels.HasNotMappedAttribute)
            {
                if (!(dllTypeInfoModels.Name == "LastUpdate"))
                {
                    sb.AppendLine($"import {{ LastUpdate }} from 'src/app/models/generated/db/LastUpdate.model';");
                }
            }

            foreach (DLLPropertyInfo dllPropertyInfo in dllTypeInfoModels.PropertyInfoList.OrderBy(c => c.CSSPProp.PropName))
            {
                string fileName = dllPropertyInfo.CSSPProp.PropType;
                if (dllPropertyInfo.CSSPProp.HasCSSPEnumTypeAttribute)
                {
                    fileName = fileName.Replace("enum", ".enum");
                    if (!fileNameUsedList.Contains(fileName))
                    {
                        fileNameUsedList.Add(fileName);
                        if (PropToSkip.Contains(dllPropertyInfo.CSSPProp.PropName))
                        {
                            continue;
                        }
                        sb.AppendLine($"import {{ { dllPropertyInfo.CSSPProp.PropType } }} from 'src/app/enums/generated/{ fileName }';");
                    }
                }

                if (!fileNameUsedList.Contains(fileName))
                {
                    if (!removeTypeList.Contains(dllPropertyInfo.CSSPProp.PropType))
                    {
                        fileNameUsedList.Add(fileName);
                        if (PropToSkip.Contains(dllPropertyInfo.CSSPProp.PropName))
                        {
                            continue;
                        }
                        //if (dllPropertyInfo.CSSPProp.IsList)
                        //{
                        //    sb.AppendLine($"import {{ { dllPropertyInfo.CSSPProp.PropType } }} from './{ fileName }.model';");
                        //}
                        //else
                        //{
                            sb.AppendLine($"import {{ { dllPropertyInfo.CSSPProp.PropType } }} from 'src/app/models/db/{ fileName }.model';");
                        //}
                    }
                }
            }
            sb.AppendLine(@"");

            string MappedText = "";
            if (dllTypeInfoModels.HasNotMappedAttribute)
            {
                // nothing for now
            }
            else
            {
                if (dllTypeInfoModels.Type.Name == "LastUpdate")
                {
                    // nothing for now
                }
                else
                {
                    MappedText = " extends LastUpdate";
                }
            }
            sb.AppendLine($@"export class { dllTypeInfoModels.Name }{ MappedText } {{");

            foreach (DLLPropertyInfo dllPropertyInfo in dllTypeInfoModels.PropertyInfoList.OrderBy(c => c.CSSPProp.PropName))
            {
                if (PropToSkip.Contains(dllPropertyInfo.CSSPProp.PropName))
                {
                    continue;
                }

                string IsNull = "";
                if (dllPropertyInfo.CSSPProp.IsNullable)
                {
                    IsNull = "?";
                }

                string typeText = "";
                switch (dllPropertyInfo.CSSPProp.PropType)
                {
                    case "Int32":
                    case "Int16":
                    case "Int64":
                    case "Single":
                    case "Float":
                    case "Double":
                        {
                            typeText = "number";
                        }
                        break;
                    case "String":
                        {
                            typeText = "string";
                            IsNull = "";
                        }
                        break;
                    case "DateTime":
                        {
                            typeText = "Date";
                        }
                        break;
                    case "Boolean":
                        {
                            typeText = "boolean";
                        }
                        break;
                    default:
                        {
                            typeText = dllPropertyInfo.CSSPProp.PropType;
                        }
                        break;
                }
                if (dllPropertyInfo.CSSPProp.IsList)
                {
                    sb.AppendLine($@"    { dllPropertyInfo.CSSPProp.PropName }{ IsNull }: { typeText }[];");
                }
                else
                {
                    sb.AppendLine($@"    { dllPropertyInfo.CSSPProp.PropName }{ IsNull }: { typeText };");
                }
            }

            sb.AppendLine(@"}");

            FileInfo fiOutputGen = new FileInfo(Config.GetValue<string>("ModelFileName").Replace("{TypeName}", dllTypeInfoModels.Name));
            using (StreamWriter sw2 = fiOutputGen.CreateText())
            {
                sw2.Write(sb.ToString());
                Console.WriteLine($"Created { fiOutputGen.FullName }");
            }
        }
    }
}
