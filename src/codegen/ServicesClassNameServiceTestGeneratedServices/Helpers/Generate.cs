﻿using ActionCommandDBServices.Models;
using CultureServices.Resources;
using GenerateCodeBaseServices.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ServicesClassNameServiceTestGeneratedServices.Services
{
    public partial class ServicesClassNameServiceTestGeneratedService : IServicesClassNameServiceTestGeneratedService
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

            string CSSPDB2 = Config.GetValue<string>("CSSPDB2");
            string TestDB = Config.GetValue<string>("TestDB");

            FileInfo fiDLL = new FileInfo(Config.GetValue<string>("CSSPModels"));

            var importAssembly = Assembly.LoadFile(fiDLL.FullName);
            List<Type> types = importAssembly.GetTypes().ToList();
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

                foreach (CustomAttributeData customAttributeData in type.CustomAttributes)
                {
                    if (customAttributeData.AttributeType.Name == "NotMappedAttribute")
                    {
                        ClassNotMapped = true;
                        break;
                    }
                }

                //if (TypeName != "Address")
                //{
                //    continue;
                //}

                sb.AppendLine($@"/* Auto generated from { AppDomain.CurrentDomain.BaseDirectory }{ AppDomain.CurrentDomain.FriendlyName}.exe");
                sb.AppendLine(@" *");
                sb.AppendLine(@" * Do not edit this file.");
                sb.AppendLine(@" *");
                sb.AppendLine(@" */ ");
                sb.AppendLine(@"");
                sb.AppendLine(@"using CSSPEnums;");
                sb.AppendLine(@"using CSSPModels;");
                sb.AppendLine(@"using CultureServices.Services;");
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
                sb.AppendLine(@"using Xunit;");
                sb.AppendLine(@"");
                sb.AppendLine(@"namespace CSSPServices.Tests");
                sb.AppendLine(@"{");
                sb.AppendLine(@"    [Collection(""Sequential"")]");
                sb.AppendLine($@"    public partial class { TypeName }ServiceTest : TestHelper");
                sb.AppendLine(@"    {");
                sb.AppendLine(@"        #region Variables");
                sb.AppendLine(@"        #endregion Variables");
                sb.AppendLine(@"");
                sb.AppendLine(@"        #region Properties");
                if (!ClassNotMapped)
                {
                    sb.AppendLine(@"        private IConfiguration Config { get; set; }");
                    sb.AppendLine(@"        private IServiceProvider Provider { get; set; }");
                    sb.AppendLine(@"        private IServiceCollection Services { get; set; }");
                    sb.AppendLine(@"        private ICultureService CultureService { get; set; }");
                    sb.AppendLine(@"        private ILoggedInService LoggedInService { get; set; }");
                    if (TypeName == "Contact")
                    {
                        sb.AppendLine(@"        private IAspNetUserService AspNetUserService { get; set; }");
                    }
                    else
                    {
                    }
                    sb.AppendLine($@"        private I{ TypeName }Service { TypeName }Service {{ get; set; }}");
                    sb.AppendLine(@"        private CSSPDBContext db { get; set; }");
                    sb.AppendLine(@"        private CSSPDBLocalContext dbLocal { get; set; }");
                    sb.AppendLine(@"        private InMemoryDBContext dbIM { get; set; }");
                    sb.AppendLine($@"        private { TypeName } { TypeNameLower } {{ get; set; }}");
                }
                sb.AppendLine(@"        #endregion Properties");
                sb.AppendLine(@"");
                sb.AppendLine(@"        #region Constructors");
                sb.AppendLine($@"        public { TypeName }ServiceTest() : base()");
                sb.AppendLine(@"        {");
                sb.AppendLine(@"");
                sb.AppendLine(@"        }");
                sb.AppendLine(@"        #endregion Constructors");
                sb.AppendLine(@"");
                if (!ClassNotMapped)
                {
                    try
                    {
                        if (!await GenerateCRUDTestCode(TypeName, TypeNameLower, sb)) return await Task.FromResult(false);

                    }
                    catch (Exception ex)
                    {

                        throw;
                    }

                    //if (!await GeneratePropertiesTestCode(TypeName, TypeNameLower, type, sb)) return await Task.FromResult(false);

                    //if (!await GenerateGetWithIDTestCode(TypeName, TypeNameLower, types, sb)) return await Task.FromResult(false);

                    //if (!await GenerateGetListTestCode(TypeName, TypeNameLower, types, sb)) return await Task.FromResult(false);

                    //if (!await GenerateGetListSkipTakeTestCode(TypeName, TypeNameLower, types, sb)) return await Task.FromResult(false);

                    //if (!await GenerateGetListSkipTakeAscTestCode(TypeName, TypeNameLower, types, sb)) return await Task.FromResult(false);

                    //if (!await GenerateGetListSkipTake2AscTestCode(TypeName, TypeNameLower, type, types, sb)) return await Task.FromResult(false);

                    //if (!await GenerateGetListSkipTakeAscWhereTestCode(TypeName, TypeNameLower, types, sb)) return await Task.FromResult(false);

                    //if (!await GenerateGetListSkipTakeAsc2WhereTestCode(TypeName, TypeNameLower, types, sb)) return await Task.FromResult(false);

                    //if (!await GenerateGetListSkipTakeDescTestCode(TypeName, TypeNameLower, types, sb)) return await Task.FromResult(false);

                    //if (!await GenerateGetListSkipTake2DescTestCode(TypeName, TypeNameLower, type, types, sb)) return await Task.FromResult(false);

                    //if (!await GenerateGetListSkipTakeDescWhereTestCode(TypeName, TypeNameLower, types, sb)) return await Task.FromResult(false);

                    //if (!await GenerateGetListSkipTakeDesc2WhereTestCode(TypeName, TypeNameLower, types, sb)) return await Task.FromResult(false);

                    //if (!await GenerateGetList2WhereTestCode(TypeName, TypeNameLower, types, sb)) return await Task.FromResult(false);
                }
                sb.AppendLine(@"        #region Functions private");
                if (!ClassNotMapped)
                {
                    if (!await GenerateDoCRUDTest(TypeName, TypeNameLower, sb)) return await Task.FromResult(false);
                    if (!await GenerateSetupTestCode(TypeName, TypeNameLower, sb)) return await Task.FromResult(false);
                    //if (!await GenerateCheckClassNameFieldsTestCode(type, types, TypeName, TypeNameLower, sb)) return await Task.FromResult(false);
                    if (!await GenerateGetFilledRandomClassnameTestCode(type, TypeName, TypeNameLower, sb)) return await Task.FromResult(false);
                }

                sb.AppendLine(@"        #endregion Functions private");
                sb.AppendLine(@"    }");
                sb.AppendLine(@"}");

                FileInfo fiOutputGen = new FileInfo(Config.GetValue<string>("ClassNameFile").Replace("{TypeName}", TypeName));
                using (StreamWriter sw2 = fiOutputGen.CreateText())
                {
                    sw2.Write(sb.ToString());
                }

                fiOutputGen = new FileInfo(Config.GetValue<string>("ClassNameFile").Replace("{TypeName}", TypeName));
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

                ActionCommandDBService.ExecutionStatusText.AppendLine($"Created [{ fiOutputGen.FullName }] ...");
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
