﻿using ActionCommandDBServices.Models;
using CultureServices.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
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
                    sb.AppendLine(@"using CSSPEnums;");
                    sb.AppendLine(@"using CSSPModels;");
                    sb.AppendLine(@"using CSSPServices;");
                    sb.AppendLine(@"using CSSPWebAPI.Controllers;");
                    sb.AppendLine(@"using LoggedInServices.Services;");
                    sb.AppendLine(@"using Microsoft.AspNetCore.Mvc;");
                    sb.AppendLine(@"using Microsoft.EntityFrameworkCore;");
                    sb.AppendLine(@"using Microsoft.Extensions.Configuration;");
                    sb.AppendLine(@"using Microsoft.Extensions.DependencyInjection;");
                    sb.AppendLine(@"using System;");
                    sb.AppendLine(@"using System.Collections.Generic;");
                    sb.AppendLine(@"using System.Globalization;");
                    sb.AppendLine(@"using System.IO;");
                    sb.AppendLine(@"using System.Linq;");
                    sb.AppendLine(@"using System.Threading.Tasks;");
                    sb.AppendLine(@"using System.Transactions;");
                    sb.AppendLine(@"using UserServices.Models;");
                    sb.AppendLine(@"using Xunit;");
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
                    sb.AppendLine(@"        private CSSPDBContext db { get; set; }");
                    sb.AppendLine(@"        private ILoggedInService loggedInService { get; set; }");
                    sb.AppendLine($@"        private I{ TypeName }Service { TypeNameLower }Service {{ get; set; }}");
                    sb.AppendLine($@"        private I{ TypeName }Controller { TypeNameLower }Controller {{ get; set; }}");
                    sb.AppendLine(@"        #endregion Properties");
                    sb.AppendLine(@"");
                    sb.AppendLine(@"        #region Constructors");
                    sb.AppendLine($@"        public { TypeName }ControllerTest()");
                    sb.AppendLine(@"        {");
                    sb.AppendLine(@"        }");
                    sb.AppendLine(@"        #endregion Constructors");
                    sb.AppendLine(@"");
                    sb.AppendLine(@"        #region Functions public");

                    if (!await GenerateControllersContructorGoodTest(TypeName, TypeNameLower, sb)) return await Task.FromResult(false);
                    if (!await GenerateControllersCRUDGoodTest(TypeName, TypeNameLower, sb)) return await Task.FromResult(false);
                    sb.AppendLine(@"        #endregion Functions public");

                    sb.AppendLine(@"");
                    sb.AppendLine(@"        #region Functions private");
                    if (!await GenerateControllerSetupPrivateTest(TypeName, TypeNameLower, sb)) return await Task.FromResult(false);
                    sb.AppendLine(@"        #endregion Functions private");

                    sb.AppendLine(@"    }");
                    sb.AppendLine(@"}");

                    FileInfo fiOutputGen = new FileInfo(Config.GetValue<string>("TypeNameFile").Replace("{TypeName}", TypeName));
                    using (StreamWriter sw2 = fiOutputGen.CreateText())
                    {
                        sw2.Write(sb.ToString());
                    }

                    fiOutputGen = new FileInfo(Config.GetValue<string>("TypeNameFile").Replace("{TypeName}", TypeName));
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

                    ActionCommandDBService.ExecutionStatusText.AppendLine($"{ string.Format(CultureServicesRes.Created_, fiOutputGen.FullName) }");
                }
            }

            ActionCommandDBService.ExecutionStatusText.AppendLine("");
            ActionCommandDBService.ExecutionStatusText.AppendLine($"{ CultureServicesRes.Done } ...");
            ActionCommandDBService.ExecutionStatusText.AppendLine("");
            ActionCommandDBService.ExecutionStatusText.AppendLine("Generate Finished ...");
            ActionCommandDBService.PercentCompleted = 100;
            await ActionCommandDBService.Update();


            return await Task.FromResult(true);
        }
    }
}
