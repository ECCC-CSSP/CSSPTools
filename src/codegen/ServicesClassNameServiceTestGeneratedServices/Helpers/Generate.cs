﻿using CSSPEnums;
using CSSPModels;
using GenerateCodeBaseServices.Models;
using GenerateCodeBaseServices.Services;
using ActionCommandDBServices.Models;
using ActionCommandDBServices.Services;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ValidateAppSettingsServices.Services;
using ValidateAppSettingsServices.Models;
using CultureServices.Resources;

namespace ServicesClassNameServiceTestGeneratedServices.Services
{
    public partial class ServicesClassNameServiceTestGeneratedService : IServicesClassNameServiceTestGeneratedService
    {
        private async Task<bool> Generate()
        {
            ActionResult<ActionCommand> actionActionCommand = await actionCommandDBService.GetOrCreate();

            if (((ObjectResult)actionActionCommand.Result).StatusCode == 400)
            {
                await actionCommandDBService.ConsoleWriteError("actionCommand == null");
                return await Task.FromResult(false);
            }

            actionCommandDBService.ExecutionStatusText.AppendLine("Generate Starting ...");
            actionCommandDBService.PercentCompleted = 10;
            await actionCommandDBService.Update();

            string CSSPDBConnectionString = configuration.GetValue<string>("CSSPDBConnectionString");
            string TestDBConnectionString = configuration.GetValue<string>("TestDBConnectionString");

            FileInfo fiDLL = new FileInfo(configuration.GetValue<string>("CSSPModels"));

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

                if (generateCodeBaseService.SkipType(type))
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

                sb.AppendLine(@" /* Auto generated from the CSSPCodeWriter.proj by clicking on the [\src\[ClassName]ServiceGenerated.cs] button");
                sb.AppendLine(@" *");
                sb.AppendLine(@" * Do not edit this file.");
                sb.AppendLine(@" *");
                sb.AppendLine(@" */ ");
                sb.AppendLine(@"");
                sb.AppendLine(@"using System;");
                sb.AppendLine(@"using Microsoft.VisualStudio.TestTools.UnitTesting;");
                sb.AppendLine(@"using System.Linq;");
                sb.AppendLine(@"using System.Collections.Generic;");
                sb.AppendLine(@"using CSSPModels;");
                sb.AppendLine(@"using CSSPServices;");
                sb.AppendLine(@"using Microsoft.EntityFrameworkCore.Metadata;");
                sb.AppendLine(@"using System.Reflection;");
                sb.AppendLine(@"using CSSPEnums;");
                sb.AppendLine(@"using System.Security.Principal;");
                sb.AppendLine(@"using System.Globalization;");
                sb.AppendLine(@"using CSSPServices.Resources;");
                sb.AppendLine(@"using CSSPModels.Resources;");
                sb.AppendLine(@"using CSSPEnums.Resources;");
                sb.AppendLine(@"");
                sb.AppendLine(@"namespace CSSPServices.Tests");
                sb.AppendLine(@"{");
                sb.AppendLine(@"    [TestClass]");
                sb.AppendLine($@"    public partial class { TypeName }ServiceTest : TestHelper");
                sb.AppendLine(@"    {");
                sb.AppendLine(@"        #region Variables");
                sb.AppendLine(@"        #endregion Variables");
                sb.AppendLine(@"");
                sb.AppendLine(@"        #region Properties");
                sb.AppendLine($@"        //private { TypeName }Service { TypeNameLower }Service {{ get; set; }}");
                sb.AppendLine(@"        #endregion Properties");
                sb.AppendLine(@"");
                sb.AppendLine(@"        #region Constructors");
                sb.AppendLine($@"        public { TypeName }ServiceTest() : base()");
                sb.AppendLine(@"        {");
                sb.AppendLine($@"            //{ TypeNameLower }Service = new { TypeName }Service(LanguageRequest, dbTestDB, ContactID);");
                sb.AppendLine(@"        }");
                sb.AppendLine(@"        #endregion Constructors");
                sb.AppendLine(@"");
                if (!ClassNotMapped)
                {
                    if (!await GenerateCRUDTestCode(TypeName, TypeNameLower, sb)) return await Task.FromResult(false);

                    if (!await GeneratePropertiesTestCode(TypeName, TypeNameLower, type, sb)) return await Task.FromResult(false);

                    if (!await GenerateGetWithIDTestCode(TypeName, TypeNameLower, types, sb)) return await Task.FromResult(false);

                    if (!await GenerateGetListTestCode(TypeName, TypeNameLower, types, sb)) return await Task.FromResult(false);

                    if (!await GenerateGetListSkipTakeTestCode(TypeName, TypeNameLower, types, sb)) return await Task.FromResult(false);

                    if (!await GenerateGetListSkipTakeAscTestCode(TypeName, TypeNameLower, types, sb)) return await Task.FromResult(false);

                    if (!await GenerateGetListSkipTake2AscTestCode(TypeName, TypeNameLower, type, types, sb)) return await Task.FromResult(false);

                    if (!await GenerateGetListSkipTakeAscWhereTestCode(TypeName, TypeNameLower, types, sb)) return await Task.FromResult(false);

                    if (!await GenerateGetListSkipTakeAsc2WhereTestCode(TypeName, TypeNameLower, types, sb)) return await Task.FromResult(false);

                    if (!await GenerateGetListSkipTakeDescTestCode(TypeName, TypeNameLower, types, sb)) return await Task.FromResult(false);

                    if (!await GenerateGetListSkipTake2DescTestCode(TypeName, TypeNameLower, type, types, sb)) return await Task.FromResult(false);

                    if (!await GenerateGetListSkipTakeDescWhereTestCode(TypeName, TypeNameLower, types, sb)) return await Task.FromResult(false);

                    if (!await GenerateGetListSkipTakeDesc2WhereTestCode(TypeName, TypeNameLower, types, sb)) return await Task.FromResult(false);

                    if (!await GenerateGetList2WhereTestCode(TypeName, TypeNameLower, types, sb)) return await Task.FromResult(false);
                }
                sb.AppendLine(@"        #region Functions private");
                if (!ClassNotMapped)
                {
                    sb.AppendLine($@"        private void Check{ TypeName }Fields(List<{ TypeName }> { TypeNameLower }List)");
                    sb.AppendLine(@"        {");
                    foreach (PropertyInfo prop in type.GetProperties())
                    {
                        CSSPProp csspProp = new CSSPProp();
                        if (!generateCodeBaseService.FillCSSPProp(prop, csspProp, type))
                        {
                            return await Task.FromResult(false);
                        }
                        if (csspProp.PropName == "ValidationResults")
                        {
                            continue;
                        }

                        if (TypeName == "ContactLogin" && (csspProp.PropName == "PasswordHash" || csspProp.PropName == "PasswordSalt"))
                        {
                            continue;
                        }

                        if (TypeName == "ResetPassword" && (csspProp.PropName == "Password" || csspProp.PropName == "ConfirmPassword"))
                        {
                            continue;
                        }

                        if (csspProp.IsNullable)
                        {
                            if (csspProp.PropType == "String")
                            {
                                sb.AppendLine($@"            if (!string.IsNullOrWhiteSpace({ TypeNameLower }List[0].{ csspProp.PropName }))");
                            }
                            else
                            {
                                sb.AppendLine($@"            if ({ TypeNameLower }List[0].{ csspProp.PropName } != null)");
                            }
                            sb.AppendLine(@"            {");
                        }
                        if (csspProp.PropType == "String")
                        {
                            sb.AppendLine($@"            { (csspProp.IsNullable ? "    " : "") }Assert.IsFalse(string.IsNullOrWhiteSpace({ TypeNameLower }List[0].{ csspProp.PropName }));");
                        }
                        else
                        {
                            sb.AppendLine($@"            { (csspProp.IsNullable ? "    " : "") }Assert.IsNotNull({ TypeNameLower }List[0].{ csspProp.PropName });");
                        }
                        if (csspProp.IsNullable)
                        {
                            sb.AppendLine(@"            }");
                        }
                    }
                    sb.AppendLine(@"        }");
                    foreach (string extra in new List<string>() { "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        Type currentType = null;
                        foreach (Type typeDetail in types)
                        {
                            if ($"{ type.Name }{ extra }" == typeDetail.Name)
                            {
                                currentType = typeDetail;
                                break;
                            }
                        }

                        if (currentType == null)
                        {
                            continue;
                        }

                        sb.AppendLine($@"        private void Check{ TypeName }{ extra }Fields(List<{ TypeName }{ extra }> { TypeNameLower }{ extra }List)");
                        sb.AppendLine(@"        {");

                        foreach (PropertyInfo prop in currentType.GetProperties())
                        {
                            CSSPProp csspProp = new CSSPProp();
                            if (!generateCodeBaseService.FillCSSPProp(prop, csspProp, currentType))
                            {
                                return await Task.FromResult(false);
                            }
                            if (csspProp.PropName == "ValidationResults")
                            {
                                continue;
                            }

                            if (TypeName == "ContactLogin" && (csspProp.PropName == "PasswordHash" || csspProp.PropName == "PasswordSalt"))
                            {
                                continue;
                            }

                            if (TypeName == "ResetPassword" && (csspProp.PropName == "Password" || csspProp.PropName == "ConfirmPassword"))
                            {
                                continue;
                            }

                            if (csspProp.IsNullable)
                            {
                                if (csspProp.PropType == "String")
                                {
                                    sb.AppendLine($@"            if (!string.IsNullOrWhiteSpace({ TypeNameLower }{ extra }List[0].{ csspProp.PropName }))");
                                }
                                else
                                {
                                    sb.AppendLine($@"            if ({ TypeNameLower }{ extra }List[0].{ csspProp.PropName } != null)");
                                }
                                sb.AppendLine(@"            {");
                            }
                            if (csspProp.PropType == "String")
                            {
                                sb.AppendLine($@"            { (csspProp.IsNullable ? "    " : "") }Assert.IsFalse(string.IsNullOrWhiteSpace({ TypeNameLower }{ extra }List[0].{ csspProp.PropName }));");
                            }
                            else
                            {
                                sb.AppendLine($@"            { (csspProp.IsNullable ? "    " : "") }Assert.IsNotNull({ TypeNameLower }{ extra }List[0].{ csspProp.PropName });");
                            }
                            if (csspProp.IsNullable)
                            {
                                sb.AppendLine(@"            }");
                            }
                        }
                        sb.AppendLine(@"        }");

                    }
                }
                sb.AppendLine($@"        private { TypeName } GetFilledRandom{ TypeName }(string OmitPropName)");
                sb.AppendLine(@"        {");
                sb.AppendLine($@"            { TypeName } { TypeNameLower } = new { TypeName }();");
                sb.AppendLine(@"");

                foreach (PropertyInfo prop in type.GetProperties())
                {
                    CSSPProp csspProp = new CSSPProp();
                    if (!generateCodeBaseService.FillCSSPProp(prop, csspProp, type))
                    {
                        return await Task.FromResult(false);
                    }

                    if (csspProp.IsKey || prop.GetGetMethod().IsVirtual || prop.Name == "ValidationResults")
                    {
                        continue;
                    }

                    if (!await CreateGetFilledRandomClass(prop, csspProp, TypeName, TypeNameLower, sb)) return await Task.FromResult(false);
                }

                sb.AppendLine(@"");
                sb.AppendLine($@"            return { TypeNameLower };");
                sb.AppendLine(@"        }");
                sb.AppendLine(@"        #endregion Functions private");
                sb.AppendLine(@"    }");
                sb.AppendLine(@"}");

                FileInfo fiOutputGen = new FileInfo(configuration.GetValue<string>("ClassNameFile").Replace("{TypeName}", TypeName));
                using (StreamWriter sw2 = fiOutputGen.CreateText())
                {
                    sw2.Write(sb.ToString());
                }

                actionCommandDBService.ExecutionStatusText.AppendLine($"Created [{ fiOutputGen.FullName }] ...");
            }

            actionCommandDBService.ExecutionStatusText.AppendLine("");
            actionCommandDBService.ExecutionStatusText.AppendLine($"{ CultureServicesRes.Done } ...");
            actionCommandDBService.ExecutionStatusText.AppendLine("");
            actionCommandDBService.ExecutionStatusText.AppendLine("Generate Finished ...");
            actionCommandDBService.PercentCompleted = 100;
            await actionCommandDBService.Update();

            return await Task.FromResult(true);
        }
    }
}
