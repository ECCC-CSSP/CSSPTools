﻿using ActionCommandDBServices.Models;
using CSSPCultureServices.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIClassNameControllerTestGeneratedServices.Services
{
    public partial class WebAPIClassNameControllerTestGeneratedService : IWebAPIClassNameControllerTestGeneratedService
    {
        private async Task<bool> Generate()
        {
            ActionResult<ActionCommand> actionActionCommand = await ActionCommandDBService.Get();

            if (((ObjectResult)actionActionCommand.Result).StatusCode == 400)
            {
                await ActionCommandDBService.ConsoleWriteError("actionCommand == null");
                return await Task.FromResult(false);
            }

            ActionCommandDBService.ExecutionStatusText.AppendLine("Generate Starting ...");
            ActionCommandDBService.PercentCompleted = 10;
            await ActionCommandDBService.Update();

            FileInfo fiDLL = new FileInfo(Config.GetValue<string>("CSSPModels"));

            var importAssembly = Assembly.LoadFile(fiDLL.FullName);
            Type[] types = importAssembly.GetTypes();
            
            foreach (string WebApiType in new List<string>() { "", "Local" })
            {
                foreach (Type type in types)
                {
                    bool ClassNotMapped = false;
                    StringBuilder sb = new StringBuilder();
                    string TypeName = type.Name;

                    string TypeNameLower = "";

                    if (type.Name.StartsWith("MWQM"))
                    {
                        TypeNameLower = $"{ type.Name.Substring(0, 4).ToLower() }{ type.Name.Substring(4) }";
                    }
                    else if (type.Name.StartsWith("TV") || type.Name.StartsWith("VP"))
                    {
                        TypeNameLower = $"{ type.Name.Substring(0, 2).ToLower() }{ type.Name.Substring(2) }";
                    }
                    else
                    {
                        TypeNameLower = $"{ type.Name.Substring(0, 1).ToLower() }{ type.Name.Substring(1) }";
                    }

                    if (GenerateCodeBaseService.SkipType(type))
                    {
                        continue;
                    }

                    //if (type.Name != "Address")
                    //{
                    //    continue;
                    //}

                    foreach (CustomAttributeData customAttributeData in type.CustomAttributes)
                    {
                        if (customAttributeData.AttributeType.Name == "NotMappedAttribute")
                        {
                            ClassNotMapped = true;
                            break;
                        }
                    }

                    if (!ClassNotMapped)
                    {
                        sb.AppendLine($@"/* Auto generated from { AppDomain.CurrentDomain.BaseDirectory }{ AppDomain.CurrentDomain.FriendlyName}.exe");
                        sb.AppendLine(@" *");
                        sb.AppendLine(@" * Do not edit this file.");
                        sb.AppendLine(@" *");
                        sb.AppendLine(@" */");
                        sb.AppendLine(@"");
                        sb.AppendLine(@"using CSSPEnums;");
                        sb.AppendLine(@"using CSSPModels;");
                        if (WebApiType == "")
                        {
                            sb.AppendLine(@"using CSSPDBServices;");
                        }
                        if (WebApiType == "Local")
                        {
                            sb.AppendLine(@"using CSSPDBLocalServices;");
                        }
                        sb.AppendLine(@"using CSSPWebAPIs.Controllers;");
                        sb.AppendLine(@"using CSSPCultureServices.Services;");
                        sb.AppendLine(@"using Microsoft.AspNetCore.Mvc;");
                        sb.AppendLine(@"using Microsoft.EntityFrameworkCore;");
                        sb.AppendLine(@"using Microsoft.Extensions.Configuration;");
                        sb.AppendLine(@"using Microsoft.Extensions.DependencyInjection;");
                        sb.AppendLine(@"using System;");
                        sb.AppendLine(@"using System.Collections.Generic;");
                        sb.AppendLine(@"using System.Globalization;");
                        sb.AppendLine(@"using System.IO;");
                        sb.AppendLine(@"using System.Linq;");
                        sb.AppendLine(@"using System.Net.Http;");
                        sb.AppendLine(@"using System.Net.Http.Headers;");
                        sb.AppendLine(@"using System.Text.Json;");
                        sb.AppendLine(@"using System.Threading.Tasks;");
                        sb.AppendLine(@"using System.Transactions;");
                        sb.AppendLine(@"using Xunit;");
                        if (WebApiType == "")
                        {
                            sb.AppendLine(@"using LoggedInServices;");
                        }
                        if (WebApiType == "Local")
                        {
                            sb.AppendLine(@"using LocalServices;");
                        }
                        sb.AppendLine(@"");
                        sb.AppendLine(@"namespace CSSPWebAPIs.Tests.Controllers");
                        sb.AppendLine(@"{");
                        sb.AppendLine($@"    public partial class { TypeName }ControllerTest");
                        sb.AppendLine(@"    {");
                        sb.AppendLine(@"        #region Variables");
                        sb.AppendLine(@"        #endregion Variables");
                        sb.AppendLine(@"");
                        sb.AppendLine(@"        #region Properties");
                        sb.AppendLine(@"        private IConfiguration Config { get; set; }");
                        sb.AppendLine(@"        private IServiceProvider Provider { get; set; }");
                        sb.AppendLine(@"        private IServiceCollection Services { get; set; }");
                        sb.AppendLine(@"        private ICSSPCultureService CSSPCultureService { get; set; }");
                        if (WebApiType == "")
                        {
                            sb.AppendLine(@"        private ILoggedInService LoggedInService { get; set; }");
                            sb.AppendLine($@"        private I{ TypeName }DBService { TypeName }DBService {{ get; set; }}");
                            sb.AppendLine(@"        private Contact contact { get; set; }");
                            sb.AppendLine(@"        private string CSSPAzureUrl { get; set; }");
                        }
                        if (WebApiType == "Local")
                        {
                            sb.AppendLine(@"        private ILocalService LocalService { get; set; }");
                            sb.AppendLine($@"        private I{ TypeName }DBLocalService { TypeName }DBLocalService {{ get; set; }}");
                            sb.AppendLine(@"        private string CSSPAzureUrl { get; set; }");
                            sb.AppendLine(@"        private string LocalUrl { get; set; }");
                        }
                        sb.AppendLine($@"        private I{ TypeName }Controller { TypeName }Controller {{ get; set; }}");
                        if (TypeName == "Contact")
                        {
                            sb.AppendLine(@"        private Contact contact2 { get; set; }");
                        }
                        else
                        {
                        }
                        sb.AppendLine(@"        #endregion Properties");
                        sb.AppendLine(@"");
                        sb.AppendLine(@"        #region Constructors");
                        sb.AppendLine($@"        public { TypeName }ControllerTest()");
                        sb.AppendLine(@"        {");
                        sb.AppendLine(@"        }");
                        sb.AppendLine(@"        #endregion Constructors");
                        sb.AppendLine(@"");
                        sb.AppendLine(@"        #region Functions public");

                        if (!await GenerateControllersContructorGoodTest(TypeName, TypeNameLower, sb, WebApiType)) return await Task.FromResult(false);
                        if (TypeName == "AspNetUser")
                        {

                        }
                        else
                        {
                            if (!await GenerateControllersCRUDGoodTest(TypeName, TypeNameLower, sb, WebApiType)) return await Task.FromResult(false);
                        }
                        sb.AppendLine(@"        #endregion Functions public");

                        sb.AppendLine(@"");
                        sb.AppendLine(@"        #region Functions private");
                        if (!await GenerateControllerSetupPrivateTest(TypeName, TypeNameLower, sb, WebApiType)) return await Task.FromResult(false);
                        sb.AppendLine(@"        #endregion Functions private");

                        sb.AppendLine(@"    }");
                        sb.AppendLine(@"}");

                        string fileName = "TypeNameFile";
                        if (WebApiType == "Local")
                        {
                            fileName = "TypeNameFileLocal";
                        }

                        FileInfo fiOutputGen = new FileInfo(Config.GetValue<string>(fileName).Replace("{TypeName}", TypeName));
                        using (StreamWriter sw2 = fiOutputGen.CreateText())
                        {
                            sw2.Write(sb.ToString());
                        }

                        fiOutputGen = new FileInfo(Config.GetValue<string>(fileName).Replace("{TypeName}", TypeName));
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

                        ActionCommandDBService.ExecutionStatusText.AppendLine($"{ string.Format(CSSPCultureServicesRes.Created_, fiOutputGen.FullName) }");
                    }
                }
            }

            ActionCommandDBService.ExecutionStatusText.AppendLine("");
            ActionCommandDBService.ExecutionStatusText.AppendLine($"{ CSSPCultureServicesRes.Done } ...");
            ActionCommandDBService.ExecutionStatusText.AppendLine("");
            ActionCommandDBService.ExecutionStatusText.AppendLine("Generate Finished ...");
            ActionCommandDBService.PercentCompleted = 100;
            await ActionCommandDBService.Update();


            return await Task.FromResult(true);
        }
    }
}
