﻿using ActionCommandDBServices.Models;
using CultureServices.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIClassNameControllerGeneratedServices.Services
{
    public partial class WebAPIClassNameControllerGeneratedService : IWebAPIClassNameControllerGeneratedService
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
                    if (TypeName == "Contact")
                    {
                        sb.AppendLine(@"using CSSPEnums;");
                    }
                    sb.AppendLine(@"using CSSPModels;");
                    sb.AppendLine(@"using CSSPServices;");
                    sb.AppendLine(@"using LoggedInServices.Services;");
                    sb.AppendLine(@"using Microsoft.AspNetCore.Authorization;");
                    sb.AppendLine(@"using Microsoft.AspNetCore.Mvc;");
                    sb.AppendLine(@"using System.Collections.Generic;");
                    sb.AppendLine(@"using System.Threading.Tasks;");
                    sb.AppendLine(@"");
                    sb.AppendLine(@"namespace CSSPWebAPI.Controllers");
                    sb.AppendLine(@"{");
                    sb.AppendLine($@"    public partial interface I{ TypeName }Controller");
                    sb.AppendLine(@"    {");
                    sb.AppendLine($@"        Task<ActionResult<List<{ TypeName }>>> Get();");
                    sb.AppendLine($@"        Task<ActionResult<{ TypeName }>> Get(int { TypeName }ID);");
                    sb.AppendLine($@"        Task<ActionResult<{ TypeName }>> Post({ TypeName } { TypeNameLower });");
                    sb.AppendLine($@"        Task<ActionResult<{ TypeName }>> Put({ TypeName } { TypeNameLower });");
                    sb.AppendLine($@"        Task<ActionResult<{ TypeName }>> Delete({ TypeName } { TypeNameLower });");
                    sb.AppendLine(@"    }");
                    sb.AppendLine(@"");
                    sb.AppendLine(@"    [Route(""api/{culture}/[controller]"")]");
                    sb.AppendLine(@"    [ApiController]");
                    sb.AppendLine(@"    [Authorize]");
                    sb.AppendLine($@"    public partial class { TypeName }Controller : ControllerBase, I{ TypeName }Controller");
                    sb.AppendLine(@"    {");
                    sb.AppendLine(@"        #region Variables");
                    sb.AppendLine(@"        #endregion Variables");
                    sb.AppendLine(@"");
                    sb.AppendLine(@"        #region Properties");
                    sb.AppendLine($@"        private I{ TypeName }Service { TypeNameLower }Service {{ get; }}");
                    sb.AppendLine(@"        private CSSPDBContext db { get; }");
                    sb.AppendLine(@"        private ILoggedInService loggedInService { get; }");
                    sb.AppendLine(@"        #endregion Properties");
                    sb.AppendLine(@"");
                    sb.AppendLine(@"        #region Constructors");
                    sb.AppendLine($@"        public { TypeName }Controller(I{ TypeName }Service { TypeNameLower }Service, CSSPDBContext db, ILoggedInService loggedInService)");
                    sb.AppendLine(@"        {");
                    sb.AppendLine($@"            this.{ TypeNameLower }Service = { TypeNameLower }Service;");
                    sb.AppendLine(@"            this.db = db;");
                    sb.AppendLine(@"            this.loggedInService = loggedInService;");
                    sb.AppendLine(@"        }");
                    sb.AppendLine(@"        #endregion Constructors");
                    sb.AppendLine(@"");
                    sb.AppendLine(@"        #region Functions public");

                    sb.AppendLine(@"        [HttpGet]");
                    sb.AppendLine($@"        public async Task<ActionResult<List<{ TypeName }>>> Get()");
                    sb.AppendLine(@"        {");
                    sb.AppendLine($@"            return await { TypeNameLower }Service.Get{ TypeName }List();");
                    sb.AppendLine(@"        }");

                    sb.AppendLine($@"        [HttpGet(""{{{ TypeName }ID}}"")]");
                    sb.AppendLine($@"        public async Task<ActionResult<{ TypeName }>> Get(int { TypeName }ID)");
                    sb.AppendLine(@"        {");
                    sb.AppendLine($@"            return await { TypeNameLower }Service.Get{ TypeName }With{ TypeName }ID({ TypeName }ID);");
                    sb.AppendLine(@"        }");

                    sb.AppendLine(@"        [HttpPost]");
                    sb.AppendLine($@"        public async Task<ActionResult<{ TypeName }>> Post({ TypeName } { TypeNameLower })");
                    sb.AppendLine(@"        {");
                    if (TypeName == "Contact")
                    {
                        sb.AppendLine($@"            return await { TypeNameLower }Service.Add({ TypeNameLower }, AddContactTypeEnum.Register);");
                    }
                    else
                    {
                        sb.AppendLine($@"            return await { TypeNameLower }Service.Add({ TypeNameLower });");
                    }
                    sb.AppendLine(@"        }");

                    sb.AppendLine(@"        [HttpPut]");
                    sb.AppendLine($@"        public async Task<ActionResult<{ TypeName }>> Put({ TypeName } { TypeNameLower })");
                    sb.AppendLine(@"        {");
                    sb.AppendLine($@"            return await { TypeNameLower }Service.Update({ TypeNameLower });");
                    sb.AppendLine(@"        }");

                    sb.AppendLine(@"        [HttpDelete]");
                    sb.AppendLine($@"        public async Task<ActionResult<{ TypeName }>> Delete({ TypeName } { TypeNameLower })");
                    sb.AppendLine(@"        {");
                    sb.AppendLine($@"            return await { TypeNameLower }Service.Delete({ TypeNameLower });");
                    sb.AppendLine(@"        }");

                    sb.AppendLine(@"        #endregion Functions public");
                    sb.AppendLine(@"");
                    sb.AppendLine(@"        #region Functions private");
                    sb.AppendLine(@"        #endregion Functions private");
                    sb.AppendLine(@"    }");
                    sb.AppendLine(@"}");

                    FileInfo fiOutputGen = null;
                    fiOutputGen = new FileInfo(Config.GetValue<string>("TypeNameFile").Replace("{TypeName}", TypeName));

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
