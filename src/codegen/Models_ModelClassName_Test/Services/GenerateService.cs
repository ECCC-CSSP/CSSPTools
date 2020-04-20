﻿using Models_ModelClassName_Test.Resources;
using Microsoft.Extensions.Configuration;
using StatusAndResultsDBService.Models;
using StatusAndResultsDBService.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CSSPGenerateCodeBase;
using CSSPGenerateCodeBase.Models;

namespace Models_ModelClassName_Test.Services
{
    public class GenerateService : IGenerateService
    {
        #region Variables
        private readonly IConfigurationRoot _configuration;
        private readonly IStatusAndResultsService _statusAndResultsService;
        private readonly IGenerateCodeBase _generateCodeBase;
        #endregion Variables

        #region Constructors
        public GenerateService(IConfigurationRoot configuration, IStatusAndResultsService statusAndResultsService, IGenerateCodeBase generateCodeBase)
        {
            _configuration = configuration;
            _statusAndResultsService = statusAndResultsService;
            _generateCodeBase = generateCodeBase;
        }
        #endregion Constructors

        #region Functions public
        public async Task Start()
        {
            string Command = _configuration.GetValue<string>("Command");

            StringBuilder sbError = new StringBuilder();
            StringBuilder sbStatus = new StringBuilder();
            StatusAndResults statusAndResults = new StatusAndResults();

            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            string dbFileNamePartial = _configuration.GetValue<string>("DBFileName");

            FileInfo fiDB = new FileInfo(dbFileNamePartial.Replace("{AppDataPath}", appDataPath));

            sbStatus.AppendLine($"{ AppRes.Starting }...");

            statusAndResults = await _statusAndResultsService.Get(Command);

            if (statusAndResults == null)
            {
                statusAndResults = await _statusAndResultsService.Create(Command);
                if (statusAndResults == null)
                {
                    return;
                }

                statusAndResults = await _statusAndResultsService.Get(Command);

                if (statusAndResults == null)
                {
                    return;
                }
            }

            FileInfo fiDLL = new FileInfo(_configuration.GetValue<string>("CSSPModels"));

            var importAssembly = Assembly.LoadFile(fiDLL.FullName);
            Type[] types = importAssembly.GetTypes();
            foreach (Type type in types)
            {
                bool ClassNotMapped = false;
                StringBuilder sb = new StringBuilder();

                sbStatus.AppendLine(type.Name);

                if (await _generateCodeBase.SkipType(type))
                {
                    continue;
                }

                //if (type.Name != "CSSPWQInputParam")
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

                sb.AppendLine(@"/*");
                sb.AppendLine(@" * Auto generated from the CSSPCodeWriter.proj by clicking on the [[ModelClassName]TestGenerated.cs] button");
                sb.AppendLine(@" *");
                sb.AppendLine(@" * Do not edit this file.");
                sb.AppendLine(@" *");
                sb.AppendLine(@" */ ");
                sb.AppendLine(@"using System;");
                sb.AppendLine(@"using System.Text;");
                sb.AppendLine(@"using Xunit;");
                sb.AppendLine(@"using System.Linq;");
                sb.AppendLine(@"using System.Globalization;");
                sb.AppendLine(@"using System.Transactions;");
                sb.AppendLine(@"using System.Collections.Generic;");
                sb.AppendLine(@"using CSSPModels.Resources;");
                sb.AppendLine(@"using Microsoft.EntityFrameworkCore.Metadata;");
                sb.AppendLine(@"using System.Reflection;");
                sb.AppendLine(@"using CSSPEnums;");
                sb.AppendLine(@"using System.ComponentModel.DataAnnotations;");
                sb.AppendLine(@"");
                sb.AppendLine(@"namespace CSSPModels.Tests");
                sb.AppendLine(@"{");
                sb.AppendLine($@"    public partial class { type.Name }Test");
                sb.AppendLine(@"    {");
                sb.AppendLine(@"        #region Variables");
                sb.AppendLine(@"        #endregion Variables");
                sb.AppendLine(@"");
                sb.AppendLine(@"        #region Properties");
                sb.AppendLine($@"        private { type.Name } { type.Name.Substring(0, 1).ToLower() }{ type.Name.Substring(1) } {{ get; set; }}");
                sb.AppendLine(@"        #endregion Properties");
                sb.AppendLine(@"");
                sb.AppendLine(@"        #region Constructors");
                sb.AppendLine($@"        public { type.Name }Test()");
                sb.AppendLine(@"        {");
                sb.AppendLine($@"            { type.Name.Substring(0, 1).ToLower() }{ type.Name.Substring(1) } = new { type.Name }();");
                sb.AppendLine(@"        }");
                sb.AppendLine(@"        #endregion Constructors");
                sb.AppendLine(@"");
                sb.AppendLine(@"        #region Tests Functions public");

                Type currentType = null;
                foreach (Type TempType in types)
                {
                    if (TempType.Name == type.Name)
                    {
                        currentType = TempType;
                    }
                }

                if (currentType == null)
                {
                    continue;
                }

                sb.AppendLine(@"        [Fact]");
                sb.AppendLine($@"        public void { currentType.Name }_Properties_Test()");
                sb.AppendLine(@"        {");

                StringBuilder sbVar = new StringBuilder();
                StringBuilder sbPropNotMapped = new StringBuilder();

                foreach (PropertyInfo prop in currentType.GetProperties().ToList())
                {
                    if (!ClassNotMapped)
                    {
                        if (!prop.GetGetMethod().IsVirtual && !prop.Name.Contains("ValidationResults"))
                        {
                            if (prop.CustomAttributes.Where(c => c.AttributeType.Name.Contains("NotMappedAttribute")).Any())
                            {
                                sbPropNotMapped.Append($@"""{ prop.Name }"", ");
                            }
                            else
                            {
                                sbVar.Append($@"""{ prop.Name }"", ");
                            }
                        }
                    }
                    else
                    {
                        if (!prop.Name.Contains("ValidationResults"))
                        {
                            sbVar.Append($@"""{ prop.Name }"", ");
                        }
                    }
                }

                sb.AppendLine($@"            List<string> propNameList = new List<string>() {{ { sbVar.ToString() } }}.OrderBy(c => c).ToList();");
                sb.AppendLine($@"            List<string> propNameNotMappedList = new List<string>() {{ { sbPropNotMapped.ToString() } }}.OrderBy(c => c).ToList();");
                sb.AppendLine(@"");
                if (!ClassNotMapped)
                {
                    sb.AppendLine(@"            int index = 0;");
                    sb.AppendLine($@"            foreach (PropertyInfo propertyInfo in typeof({ currentType.Name }).GetProperties().OrderBy(c => c.Name))");
                    sb.AppendLine(@"            {");
                    sb.AppendLine(@"                if (!propertyInfo.GetGetMethod().IsVirtual");
                    sb.AppendLine(@"                    && propertyInfo.Name != ""ValidationResults""");
                    sb.AppendLine(@"                    && !propertyInfo.CustomAttributes.Where(c => c.AttributeType.Name.Contains(""NotMappedAttribute"")).Any())");
                    sb.AppendLine(@"                {");
                    sb.AppendLine(@"                    Assert.Equal(propNameList[index], propertyInfo.Name);");
                    sb.AppendLine(@"                    index += 1;");
                    sb.AppendLine(@"                }");
                    sb.AppendLine(@"            }");
                    sb.AppendLine(@"");
                    sb.AppendLine(@"            Assert.Equal(propNameList.Count, index);");
                    sb.AppendLine(@"");
                    sb.AppendLine(@"            index = 0;");
                    sb.AppendLine($@"            foreach (PropertyInfo propertyInfo in typeof({ currentType.Name }).GetProperties().Where(c => c.Name != ""ValidationResults"").OrderBy(c => c.Name).ToList())");
                    sb.AppendLine(@"            {");
                    sb.AppendLine(@"                foreach (CustomAttributeData customAttributeData in propertyInfo.CustomAttributes)");
                    sb.AppendLine(@"                {");
                    sb.AppendLine(@"                    if (customAttributeData.AttributeType.Name == ""NotMappedAttribute"")");
                    sb.AppendLine(@"                    {");
                    sb.AppendLine(@"                        Assert.Equal(propertyInfo.Name, propNameNotMappedList[index]);");
                    sb.AppendLine(@"                        index += 1;");
                    sb.AppendLine(@"                    }");
                    sb.AppendLine(@"                }");
                    sb.AppendLine(@"            }");
                    sb.AppendLine(@"");
                    sb.AppendLine(@"            Assert.Equal(propNameNotMappedList.Count, index);");
                    sb.AppendLine(@"");

                }
                else
                {
                    sb.AppendLine(@"            int index = 0;");
                    sb.AppendLine($@"            foreach (PropertyInfo propertyInfo in typeof({ currentType.Name }).GetProperties().Where(c => c.Name != ""ValidationResults"").OrderBy(c => c.Name).ToList())");
                    sb.AppendLine(@"            {");
                    sb.AppendLine(@"                Assert.Equal(propertyInfo.Name, propNameList[index]);");
                    sb.AppendLine(@"                index += 1;");
                    sb.AppendLine(@"            }");
                    sb.AppendLine(@"");
                    sb.AppendLine(@"            Assert.Equal(propNameList.Count, index);");
                }
                sb.AppendLine(@"        }");

                if (!ClassNotMapped)
                {
                    sb.AppendLine(@"        [Fact]");
                    sb.AppendLine($@"        public void { currentType.Name }_Navigation_Test()");
                    sb.AppendLine(@"        {");

                    StringBuilder sbVar2 = new StringBuilder();
                    StringBuilder sbCollection = new StringBuilder();

                    foreach (PropertyInfo propertyInfo in currentType.GetProperties())
                    {
                        if (propertyInfo.GetGetMethod().IsVirtual)
                        {
                            if (propertyInfo.GetGetMethod().ReturnType.Name.StartsWith("ICollection"))
                            {
                                sbCollection.Append($@"""{ propertyInfo.Name }"", ");
                            }
                            else
                            {
                                sbVar2.Append($@"""{ propertyInfo.Name }"", ");
                            }
                        }
                    }

                    sb.AppendLine($@"            List<string> foreignNameList = new List<string>() {{ { sbVar2.ToString() } }}.OrderBy(c => c).ToList();");
                    sb.AppendLine($@"            List<string> foreignNameCollectionList = new List<string>() {{ { sbCollection.ToString() } }}.OrderBy(c => c).ToList();");
                    sb.AppendLine(@"");
                    sb.AppendLine(@"            int index = 0;");
                    sb.AppendLine($@"            foreach (PropertyInfo propertyInfo in typeof({ currentType.Name }).GetProperties())");
                    sb.AppendLine(@"            {");
                    sb.AppendLine(@"                if (propertyInfo.GetGetMethod().IsVirtual && !propertyInfo.GetGetMethod().ReturnType.Name.StartsWith(""ICollection""))");
                    sb.AppendLine(@"                {");
                    sb.AppendLine(@"                    bool foreignNameExist = foreignNameList.Contains(propertyInfo.Name);");
                    sb.AppendLine(@"                    Assert.True(foreignNameExist);");
                    sb.AppendLine(@"                    index += 1;");
                    sb.AppendLine(@"                }");
                    sb.AppendLine(@"            }");
                    sb.AppendLine(@"");
                    sb.AppendLine(@"            Assert.Equal(foreignNameList.Count, index);");
                    sb.AppendLine(@"");
                    sb.AppendLine(@"            index = 0;");
                    sb.AppendLine($@"            foreach (PropertyInfo propertyInfo in typeof({ currentType.Name }).GetProperties().Where(c => c.Name != ""ValidationResults"").OrderBy(c => c.Name).ToList())");
                    sb.AppendLine(@"            {");
                    sb.AppendLine(@"                if (propertyInfo.GetGetMethod().ReturnType.Name.StartsWith(""ICollection""))");
                    sb.AppendLine(@"                {");
                    sb.AppendLine(@"                    bool foreignNameCollectionExist = foreignNameCollectionList.Contains(propertyInfo.Name);");
                    sb.AppendLine(@"                    Assert.True(foreignNameCollectionExist);");
                    sb.AppendLine(@"                    index += 1;");
                    sb.AppendLine(@"                }");
                    sb.AppendLine(@"            }");
                    sb.AppendLine(@"");
                    sb.AppendLine(@"            Assert.Equal(foreignNameCollectionList.Count, index);");
                    sb.AppendLine(@"");
                    sb.AppendLine(@"        }");

                }

                sb.AppendLine(@"        [Fact]");
                sb.AppendLine($@"        public void { currentType.Name }_Has_ValidationResults_Test()");
                sb.AppendLine(@"        {");
                sb.AppendLine($@"             Assert.True(typeof({ currentType.Name }).GetProperties().Where(c => c.Name == ""ValidationResults"").Any());");
                sb.AppendLine(@"        }");

                sb.AppendLine(@"        [Fact]");
                sb.AppendLine($@"        public void { currentType.Name }_Every_Property_Has_Get_Set_Test()");
                sb.AppendLine(@"        {");

                int count = 0;

                // doing properties which are not virtual nor contains 'ValidationResults'
                foreach (PropertyInfo prop in currentType.GetProperties())
                {
                    count += 1;
                    if (!prop.GetGetMethod().IsVirtual && !prop.Name.Contains("ValidationResults"))
                    {
                        CSSPProp csspProp = new CSSPProp();
                        if (! await _generateCodeBase.FillCSSPProp(prop, csspProp, currentType))
                        {
                            sbError.AppendLine($"{ String.Format(AppRes.ErrorWhileCreatingCode_, csspProp.CSSPError) }");
                            await _statusAndResultsService.Update(Command, sbError.ToString(), sbStatus.ToString(), 0);

                            return;
                        }
                        switch (csspProp.PropType)
                        {
                            case "Boolean":
                                {
                                    if (csspProp.IsList || csspProp.IsIQueryable)
                                    {
                                        sb.AppendLine($@"               List<bool> val{ count.ToString() } = new List<bool>() {{ true, false }};");
                                    }
                                    else
                                    {
                                        sb.AppendLine($@"               bool val{ count.ToString() } = true;");
                                    }
                                }
                                break;
                            case "DateTime":
                            case "DateTimeOffset":
                                {
                                    if (csspProp.IsList || csspProp.IsIQueryable)
                                    {
                                        sb.AppendLine($@"               List<DateTime> val{ count.ToString() } = new List<DateTime>() {{ new DateTime(2011, 3, 5), new DateTime(2015, 3, 2, 4, 5, 6) }};");
                                    }
                                    else
                                    {
                                        sb.AppendLine($@"               DateTime val{ count.ToString() } = new DateTime(2010, 3, 4);");
                                    }
                                }
                                break;
                            case "Int16":
                            case "Int32":
                            case "Int64":
                                {
                                    if (csspProp.IsList || csspProp.IsIQueryable)
                                    {
                                        sb.AppendLine($@"               List<int> val{ count.ToString() } = new List<int>() {{ 34, 45, 56 }};");
                                    }
                                    else
                                    {
                                        sb.AppendLine($@"               int val{ count.ToString() } = 45;");
                                    }
                                }
                                break;
                            case "Single":
                                {
                                    if (csspProp.IsList || csspProp.IsIQueryable)
                                    {
                                        sb.AppendLine($@"               List<float> val{ count.ToString() } = new List<float>() {{ 34.4f, 45.3f, 56.6f }};");
                                    }
                                    else
                                    {
                                        sb.AppendLine($@"               float val{ count.ToString() } = 56.0f;");
                                    }
                                }
                                break;
                            case "Double":
                                {
                                    if (csspProp.IsList || csspProp.IsIQueryable)
                                    {
                                        sb.AppendLine($@"               List<double> val{ count.ToString() } = new List<double>() {{ 33.2D, 66.4D, 56.4D }};");
                                    }
                                    else
                                    {
                                        sb.AppendLine($@"               double val{ count.ToString() } = 87.9D;");
                                    }
                                }
                                break;
                            case "String":
                                {
                                    if (csspProp.IsList || csspProp.IsIQueryable)
                                    {
                                        sb.AppendLine($@"               List<string> val{ count.ToString() } = new List<string>() {{ ""testing"", ""Bonjour Allo"" }};");
                                    }
                                    else
                                    {
                                        sb.AppendLine($@"               string val{ count.ToString() } = ""Some text"";");
                                    }
                                }
                                break;
                            case "Byte[]":
                                {
                                    if (csspProp.IsList || csspProp.IsIQueryable)
                                    {
                                        sb.AppendLine($@"               List<byte[]> val{ count.ToString() } = new List<byte[]>() {{ Encoding.ASCII.GetBytes(new string(' ', 100)), Encoding.ASCII.GetBytes(new string(' ', 100)) }};");
                                    }
                                    else
                                    {
                                        sb.AppendLine($@"               byte[] val{ count.ToString() } = new byte[5];");
                                    }
                                }
                                break;
                            case "Type":
                                {
                                    if (csspProp.IsList || csspProp.IsIQueryable)
                                    {
                                        sb.AppendLine($@"               List<Type> val{ count.ToString() } = List<Type>() {{ typeof(Address), typeof(TVItem) }};");
                                    }
                                    else
                                    {
                                        sb.AppendLine($@"               Type val{ count.ToString() } = typeof({ currentType.Name });");
                                    }
                                }
                                break;
                            default:
                                {
                                    if (csspProp.HasCSSPEnumTypeAttribute)
                                    {
                                        if (csspProp.IsList || csspProp.IsIQueryable)
                                        {
                                            sb.AppendLine($@"               List<{ csspProp.PropType }> val{ count.ToString() } = new List<{ csspProp.PropType }>() {{ new { csspProp.PropType }(), new { csspProp.PropType }() }};");
                                        }
                                        else
                                        {
                                            sb.AppendLine($@"               { csspProp.PropType } val{ count.ToString() } = ({ csspProp.PropType })3;");
                                        }
                                    }
                                    else
                                    {
                                        if (csspProp.IsList || csspProp.IsIQueryable)
                                        {
                                            sb.AppendLine($@"               List<{ csspProp.PropType }> val{ count.ToString() } = new List<{ csspProp.PropType }>() {{ new { csspProp.PropType }(), new { csspProp.PropType }() }};");
                                        }
                                        else
                                        {
                                            sb.AppendLine($@"               { csspProp.PropType } val{ count.ToString() } = new { csspProp.PropType }();");
                                        }
                                    }
                                }
                                break;
                        }

                        if (csspProp.IsIQueryable)
                        {
                            sb.AppendLine($@"               { currentType.Name.Substring(0, 1).ToLower() }{ currentType.Name.Substring(1) }.{ prop.Name } = val{ count.ToString() } as IQueryable<{ csspProp.PropType }>;");
                        }
                        else
                        {
                            sb.AppendLine($@"               { currentType.Name.Substring(0, 1).ToLower() }{ currentType.Name.Substring(1) }.{ prop.Name } = val{ count.ToString() };");
                        }

                        sb.AppendLine($@"               Assert.Equal(val{ count.ToString() }, { currentType.Name.Substring(0, 1).ToLower() }{ currentType.Name.Substring(1) }.{ prop.Name });");
                    }
                }

                // doing properties which are virtual
                foreach (PropertyInfo prop in currentType.GetProperties())
                {
                    count += 1;
                    if (prop.GetGetMethod().IsVirtual)
                    {
                        CSSPProp csspProp = new CSSPProp();
                        if (!await _generateCodeBase.FillCSSPProp(prop, csspProp, currentType))
                        {
                            sbError.AppendLine($"{ String.Format(AppRes.ErrorWhileCreatingCode_, csspProp.CSSPError) }");
                            await _statusAndResultsService.Update(Command, sbError.ToString(), sbStatus.ToString(), 0);

                            return;
                        }
                        if (csspProp.IsCollection)
                        {
                            sb.AppendLine($@"               ICollection<{ csspProp.PropType }> val{ count.ToString() } = new List<{ csspProp.PropType }>();");
                        }
                        else if (csspProp.IsList || csspProp.IsIQueryable)
                        {
                            sb.AppendLine($@"               List<{ csspProp.PropType }> val{ count.ToString() } = new List<{ csspProp.PropType }>();");
                        }
                        else
                        {
                            sb.AppendLine($@"               { csspProp.PropType } val{ count.ToString() } = new { csspProp.PropType }();");
                        }
                        sb.AppendLine($@"               { currentType.Name.Substring(0, 1).ToLower() }{ currentType.Name.Substring(1) }.{ prop.Name } = val{ count.ToString() };");
                        sb.AppendLine($@"               Assert.Equal(val{ count.ToString() }, { currentType.Name.Substring(0, 1).ToLower() }{ currentType.Name.Substring(1) }.{ prop.Name });");
                    }
                }

                // doing properties which contains 'ValidationResults'
                foreach (PropertyInfo prop in currentType.GetProperties())
                {
                    count += 1;
                    if (prop.Name.Contains("ValidationResults"))
                    {
                        CSSPProp csspProp = new CSSPProp();
                        if (!await _generateCodeBase.FillCSSPProp(prop, csspProp, currentType))
                        {
                            sbError.AppendLine($"{ String.Format(AppRes.ErrorWhileCreatingCode_, csspProp.CSSPError) }");
                            await _statusAndResultsService.Update(Command, sbError.ToString(), sbStatus.ToString(), 0);

                            return;
                        }
                        sb.AppendLine($@"               IEnumerable<ValidationResult> val{ count.ToString() } = new List<ValidationResult>() {{ new ValidationResult(""First CSSPError Message"") }}.AsEnumerable();");
                        sb.AppendLine($@"               { currentType.Name.Substring(0, 1).ToLower() }{ currentType.Name.Substring(1) }.{ prop.Name } = val{ count.ToString() };");
                        sb.AppendLine($@"               Assert.Equal(val{ count.ToString() }, { currentType.Name.Substring(0, 1).ToLower() }{ currentType.Name.Substring(1) }.{ prop.Name });");
                    }
                }
                sb.AppendLine(@"        }");


                sb.AppendLine(@"        #endregion Tests Functions public");
                sb.AppendLine(@"    }");
                sb.AppendLine(@"}");

                string fileCreatedName = _configuration.GetValue<string>("ModelTestGenerated");

                FileInfo fiOutput = new FileInfo(fileCreatedName.Replace("{TypeName}", type.Name));

                using (StreamWriter sw = fiOutput.CreateText())
                {
                    sw.Write(sb.ToString());
                }

                sbStatus.AppendLine($"{ String.Format(AppRes.Created_, fiOutput.FullName) }");
                await _statusAndResultsService.Update(Command, sbError.ToString(), sbStatus.ToString(), 0);
            }

            sbStatus.AppendLine($"{ AppRes.Done } ...");
            await _statusAndResultsService.Update(Command, sbError.ToString(), sbStatus.ToString(), 100);

            Console.WriteLine(sbError.ToString());
            Console.WriteLine(sbStatus.ToString());

            return;
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}