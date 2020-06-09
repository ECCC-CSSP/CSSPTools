﻿using ActionCommandDBServices.Models;
using AngularEnumsGeneratedServices.Models;
using CSSPEnums;
using CultureServices.Resources;
using GenerateCodeBaseServices.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularEnumsGeneratedServices.Services
{
    public partial class AngularEnumsGeneratedService : IAngularEnumsGeneratedService
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

            ActionCommandDBService.ExecutionStatusText.AppendLine($"Reading [{ fiCSSPEnumsDLL.FullName }] ...");

            List<DLLTypeInfo> DLLTypeInfoCSSPEnumsList = new List<DLLTypeInfo>();
            if (GenerateCodeBaseService.FillDLLTypeInfoList(fiCSSPEnumsDLL, DLLTypeInfoCSSPEnumsList))
            {
                ActionCommandDBService.ErrorText.AppendLine($"{ string.Format(CultureServicesRes.CouldNotReadFile_, diOutputGen.FullName) }");
                return false;
            }
            ActionCommandDBService.ExecutionStatusText.AppendLine($"Loaded [{ fiCSSPEnumsDLL.FullName }] ...");

            foreach (DLLTypeInfo dllTypeInfoEnums in DLLTypeInfoCSSPEnumsList)
            {
                //if (dllTypeInfoEnums.Name != "AddressTypeEnum")
                //{
                //    continue;
                //}

                StringBuilder sb = new StringBuilder();

                if (dllTypeInfoEnums.IsEnum)
                {
                    sb.AppendLine(@"/*");
                    sb.AppendLine($@" * Auto generated { AppDomain.CurrentDomain.BaseDirectory }{ AppDomain.CurrentDomain.FriendlyName}.exe");
                    sb.AppendLine(@" *");
                    sb.AppendLine(@" * Do not edit this file.");
                    sb.AppendLine(@" *");
                    sb.AppendLine(@" */");
                    sb.AppendLine(@"");
                    sb.AppendLine(@"import { EnumIDAndText } from 'src/app/models/enumidandtext.models';");
                    sb.AppendLine(@"");

                    sb.AppendLine($@"export enum { dllTypeInfoEnums.Name } {{");

                    List<EnumNameAndNumber> enumNameAndNumberList = new List<EnumNameAndNumber>();

                    foreach (DLLFieldInfo dllFieldInfo in dllTypeInfoEnums.FieldInfoList)
                    {
                        if (dllTypeInfoEnums.IsEnum)
                        {

                            string fName = dllFieldInfo.Name;
                            int IntVal = (int)dllFieldInfo.FieldInfo.GetValue(dllFieldInfo.Name);

                            enumNameAndNumberList.Add(new EnumNameAndNumber() { EnumName = fName, EnumNumber = IntVal });
                        }
                    }

                    foreach (EnumNameAndNumber enumNameAndNumber in enumNameAndNumberList.OrderBy(c => c.EnumNumber))
                    {
                        sb.AppendLine($@"    { enumNameAndNumber.EnumName } = { enumNameAndNumber.EnumNumber },");
                    }

                    sb.AppendLine(@"}");
                    sb.AppendLine(@"");

                    // ---------------------------------
                    // doing {EnumName}_GetOrderedText()
                    // ---------------------------------
                    sb.AppendLine($@"export function { dllTypeInfoEnums.Name }_GetOrderedText(): EnumIDAndText[] {{");
                    sb.AppendLine(@"    let enumTextOrderedList: EnumIDAndText[] = [];");
                    sb.AppendLine(@"    if ($localize.locale === 'fr-CA') {");

                    CultureService.SetCulture("fr-CA");
                    List<EnumIDAndText> enumIDAndTextList = Enums.GetEnumTextOrderedList(dllTypeInfoEnums.Type);
                    foreach (EnumIDAndText enumIDAndText in enumIDAndTextList.OrderBy(c => c.EnumID))
                    {
                        string EnumText = enumIDAndText.EnumText.Replace("'", "\\'");
                        sb.AppendLine($@"        enumTextOrderedList.push({{ EnumID: { enumIDAndText.EnumID }, EnumText: '{ EnumText }' }});");
                    }

                    sb.AppendLine(@"    }");
                    sb.AppendLine(@"    else {");

                    CultureService.SetCulture("en-CA");
                    enumIDAndTextList = Enums.GetEnumTextOrderedList(dllTypeInfoEnums.Type);
                    foreach (EnumIDAndText enumIDAndText in enumIDAndTextList.OrderBy(c => c.EnumID))
                    {
                        string EnumText = enumIDAndText.EnumText.Replace("'", "\\'");
                        sb.AppendLine($@"        enumTextOrderedList.push({{ EnumID: { enumIDAndText.EnumID }, EnumText: '{ EnumText }' }});");
                    }

                    sb.AppendLine(@"    }");
                    sb.AppendLine(@"");
                    sb.AppendLine(@"    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));");
                    sb.AppendLine(@"}");

                    // ---------------------------------
                    // doing {EnumName}_GetIDText(enumID: number)
                    // ---------------------------------
                    sb.AppendLine(@"");
                    sb.AppendLine($@"export function { dllTypeInfoEnums.Name }_GetIDText(enumID: number): string {{");
                    sb.AppendLine(@"    let addressTypeEnunText: string;");
                    sb.AppendLine($@"    { dllTypeInfoEnums.Name }_GetOrderedText().forEach(e => {{");
                    sb.AppendLine($@"        if (e.EnumID == enumID) {{");
                    sb.AppendLine($@"            addressTypeEnunText = e.EnumText;");
                    sb.AppendLine($@"            return false;");
                    sb.AppendLine(@"        }");
                    sb.AppendLine(@"    });");
                    sb.AppendLine(@"");
                    sb.AppendLine(@"    return addressTypeEnunText;");
                    sb.AppendLine(@"}");

                    FileInfo fiOutputGen = new FileInfo(Config.GetValue<string>("EnumNameFile").Replace("{EnumName}", dllTypeInfoEnums.Name.Replace("enum", ".enum")));

                    using (StreamWriter sw2 = fiOutputGen.CreateText())
                    {
                        sw2.Write(sb.ToString());
                        ActionCommandDBService.ExecutionStatusText.AppendLine($"Created [{ fiOutputGen.FullName }]");
                    }

                    fiOutputGen = new FileInfo(Config.GetValue<string>("EnumNameFile").Replace("{EnumName}", dllTypeInfoEnums.Name.Replace("enum", ".enum")));
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
