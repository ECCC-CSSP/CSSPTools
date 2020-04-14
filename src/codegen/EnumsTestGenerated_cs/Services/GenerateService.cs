﻿using EnumsTestGenerated_cs.Resources;
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

namespace EnumsTestGenerated_cs.Services
{
    public class GenerateService : IGenerateService
    {
        #region Variables
        #endregion Variables

        #region Constructors
        public GenerateService()
        {
        }
        #endregion Constructors

        #region Functions public
        public async Task Start(IConfigurationRoot configuration, IStatusAndResultsService statusAndResultsService)
        {
            string Command = configuration.GetValue<string>("Command");

            StringBuilder sbError = new StringBuilder();
            StringBuilder sbStatus = new StringBuilder();
            StatusAndResults statusAndResults = new StatusAndResults();

            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            string dbFileNamePartial = configuration.GetValue<string>("DBFileName");

            FileInfo fiDB = new FileInfo(dbFileNamePartial.Replace("{AppDataPath}", appDataPath));

            sbStatus.AppendLine($"{ AppRes.Starting }...");

            statusAndResults = await statusAndResultsService.Get(Command);
             
            if (statusAndResults == null)
            {
                statusAndResults = await statusAndResultsService.Create(Command);
                if (statusAndResults == null)
                {
                    return;
                }

                statusAndResults = await statusAndResultsService.Get(Command);

                if (statusAndResults == null)
                {
                    return;
                }
            }

            StringBuilder sb = new StringBuilder();
            FileInfo fiDLL = new FileInfo(configuration.GetValue<string>("CSSPEnums"));
            FileInfo fi = new FileInfo(configuration.GetValue<string>("EnumsTestGenerated"));

            sb.AppendLine(@"/*");
            sb.AppendLine(@" * Auto generated from the CSSPCodeWriter.proj by clicking on the [EnumsTestGenerate.cs] button");
            sb.AppendLine(@" *");
            sb.AppendLine(@" * Do not edit this file.");
            sb.AppendLine(@" *");
            sb.AppendLine(@" */ ");
            sb.AppendLine(@"using System;");
            sb.AppendLine(@"using Xunit;");
            sb.AppendLine(@"using System.Collections.Generic;");
            sb.AppendLine(@"using System.Globalization;");
            sb.AppendLine(@"using CSSPEnums.Resources;");
            sb.AppendLine(@"using System.Linq;");
            sb.AppendLine(@"");
            sb.AppendLine(@"namespace CSSPEnums.Tests");
            sb.AppendLine(@"{");
            sb.AppendLine(@"    public partial class EnumsTest");
            sb.AppendLine(@"    {");
            sb.AppendLine(@"");

            // Doing Testing Methods GetEnumText public
            sb.AppendLine(@"        #region Testing Method GetResValueForTypeAndID for each Enum value name");
            var importAssembly = Assembly.LoadFile(fiDLL.FullName);
            Type[] types = importAssembly.GetTypes();
            foreach (Type type in types)
            {
                if (type.GetTypeInfo().BaseType == typeof(System.Enum))
                {
                    string enumName = type.Name;
                    if (enumName == "PolSourceObsInfoEnum")
                        continue;

                    sb.AppendLine(@"        [Fact]");
                    sb.AppendLine($@"        public void GetResValueForTypeAndID_ForEnum_{ enumName }_Test()");
                    sb.AppendLine(@"        {");
                    sb.AppendLine(@"            foreach (CultureInfo culture in new List<CultureInfo>() { new CultureInfo(""en-CA""), new CultureInfo(""fr-CA"") })");
                    sb.AppendLine(@"            {");
                    sb.AppendLine(@"                SetupTest(culture);");
                    sb.AppendLine(@"");
                    sb.AppendLine($@"                string retStr = enums.GetResValueForTypeAndID(typeof({ enumName }), -100);");
                    sb.AppendLine(@"                Assert.Equal(CSSPEnumsRes.Empty, retStr);");
                    sb.AppendLine(@"");
                    sb.AppendLine($@"                retStr = enums.GetResValueForTypeAndID(typeof({ enumName }), 10000000);");
                    sb.AppendLine(@"                Assert.Equal(CSSPEnumsRes.Empty, retStr);");
                    sb.AppendLine(@"");
                    sb.AppendLine($@"                retStr = enums.GetResValueForTypeAndID(typeof({ enumName }), null);");
                    sb.AppendLine(@"                Assert.Equal(CSSPEnumsRes.Empty, retStr);");
                    sb.AppendLine(@"");
                    sb.AppendLine($@"                foreach (int i in Enum.GetValues(typeof({ enumName })))");
                    sb.AppendLine(@"                {");
                    sb.AppendLine($@"                    retStr = enums.GetResValueForTypeAndID(typeof({ enumName }), i);");
                    sb.AppendLine(@"        ");
                    sb.AppendLine($@"                    switch (({ enumName })i)");
                    sb.AppendLine(@"                    {");
                    foreach (FieldInfo fieldInfo in type.GetFields())
                    {
                        if (fieldInfo.FieldType.GetTypeInfo().BaseType == typeof(System.Enum))
                        {
                            string fName = fieldInfo.Name;
                            sb.AppendLine($@"                        case { enumName }.{ fName }:");
                            if (fName == "CSSPError")
                            {
                                sb.AppendLine(@"                            Assert.Equal(CSSPEnumsRes.Empty, retStr);");
                                sb.AppendLine(@"                            break;");
                            }
                            else
                            {
                                sb.AppendLine($@"                            Assert.Equal(CSSPEnumsRes.{ enumName }{ fName }, retStr);");
                                sb.AppendLine(@"                            break;");
                            }
                        }
                    }
                    sb.AppendLine(@"                        default:");
                    sb.AppendLine(@"                            Assert.Equal(CSSPEnumsRes.Empty, retStr);");
                    sb.AppendLine(@"                            break;");
                    sb.AppendLine(@"                    }");
                    sb.AppendLine(@"                }");
                    sb.AppendLine(@"            }");
                    sb.AppendLine(@"        }");

                }
            }
            sb.AppendLine(@"");
            sb.AppendLine(@"        #endregion Testing Method GetResValueForTypeAndID for each Enum value name");
            sb.AppendLine(@"");


            // Doing Testing Methods Check OK public
            sb.AppendLine(@"        #region Testing Method EnumTypeListOK");
            sb.AppendLine(@"        [Fact]");
            sb.AppendLine(@"        public void Enums_EnumTypeListOK_Test()");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            foreach (CultureInfo culture in new List<CultureInfo>() { new CultureInfo(""en-CA""), new CultureInfo(""fr-CA"") })");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                SetupTest(culture);");
            sb.AppendLine(@"");
            sb.AppendLine(@"                List<int?> intList = new List<int?>() { (int)PolSourceObsInfoEnum.AgriculturalSourceCrop, (int)PolSourceObsInfoEnum.AgricultureSourcePasture };");
            sb.AppendLine(@"                Assert.Equal((int)PolSourceObsInfoEnum.AgriculturalSourceCrop, intList[0]);");
            sb.AppendLine(@"                Assert.Equal((int)PolSourceObsInfoEnum.AgricultureSourcePasture, intList[1]);");
            sb.AppendLine(@"                string retStr = enums.EnumTypeListOK(typeof(PolSourceObsInfoEnum), intList);");
            sb.AppendLine(@"                Assert.Equal("""", retStr);");
            sb.AppendLine(@"");
            sb.AppendLine(@"                intList.Add(1000000);");
            sb.AppendLine(@"                retStr = enums.EnumTypeListOK(typeof(PolSourceObsInfoEnum), intList);");
            sb.AppendLine(@"                Assert.Equal(string.Format(CSSPEnumsRes._IsRequired, ""PolSourceObsInfoEnum""), retStr);");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"        }");
            sb.AppendLine(@"");
            sb.AppendLine(@"        #endregion Testing Method EnumTypeListOK");
            sb.AppendLine(@"");

            sb.AppendLine(@"        #region Testing Method EnumTypeOK for each Enum value name");
            importAssembly = Assembly.LoadFile(fiDLL.FullName);
            types = importAssembly.GetTypes();
            foreach (Type type in types)
            {
                if (type.GetTypeInfo().BaseType == typeof(System.Enum))
                {
                    string enumName = type.Name;

                    sb.AppendLine(@"        [Fact]");
                    sb.AppendLine($@"        public void Enums_{ enumName.Substring(0, enumName.Length - 4) }OK_Test()");
                    sb.AppendLine(@"        {");
                    sb.AppendLine(@"            foreach (CultureInfo culture in new List<CultureInfo>() { new CultureInfo(""en-CA""), new CultureInfo(""fr-CA"") })");
                    sb.AppendLine(@"            {");
                    sb.AppendLine(@"                SetupTest(culture);");
                    sb.AppendLine(@"");
                    sb.AppendLine($@"                string retStr = enums.EnumTypeOK(typeof({ enumName }), null);");
                    sb.AppendLine(@"                Assert.Equal("""", retStr);");
                    sb.AppendLine(@"");
                    sb.AppendLine($@"                retStr = enums.EnumTypeOK(typeof({ enumName }), -100);");
                    sb.AppendLine($@"                Assert.Equal(string.Format(CSSPEnumsRes._IsRequired, ""{ enumName }""), retStr);");
                    sb.AppendLine(@"");
                    sb.AppendLine($@"                retStr = enums.EnumTypeOK(typeof({ enumName }), 10000000);");
                    sb.AppendLine($@"                Assert.Equal(string.Format(CSSPEnumsRes._IsRequired, ""{ enumName }""), retStr);");
                    sb.AppendLine(@"");
                    sb.AppendLine($@"                foreach (int i in Enum.GetValues(typeof({ enumName })))");
                    sb.AppendLine(@"                {");
                    sb.AppendLine($@"                    retStr = enums.EnumTypeOK(typeof({ enumName }), i);");
                    sb.AppendLine(@"");
                    sb.AppendLine($@"                    switch (({ enumName })i)");
                    sb.AppendLine(@"                    {");
                    foreach (FieldInfo fieldInfo in type.GetFields())
                    {
                        if (fieldInfo.FieldType.GetTypeInfo().BaseType == typeof(System.Enum))
                        {
                            string fName = fieldInfo.Name;
                            sb.AppendLine($@"                        case { enumName }.{ fName }:");
                        }
                    }
                    sb.AppendLine(@"                            Assert.Equal("""", retStr);");
                    sb.AppendLine(@"                            break;");
                    sb.AppendLine(@"                        default:");
                    sb.AppendLine($@"                            Assert.Equal(string.Format(CSSPEnumsRes._IsRequired, ""{ enumName }""), retStr);");
                    sb.AppendLine(@"                            break;");
                    sb.AppendLine(@"                    }");
                    sb.AppendLine(@"                }");
                    sb.AppendLine(@"            }");
                    sb.AppendLine(@"        }");

                }
            }
            sb.AppendLine(@"");
            sb.AppendLine(@"        #endregion Testing Method EnumTypeOK for each Enum value name");
            sb.AppendLine(@"");


            // Doing Testing Methods TextOrdered public
            sb.AppendLine(@"        #region Testing Method GetEnumTextOrderedList for each Enum value name");
            importAssembly = Assembly.LoadFile(fiDLL.FullName);
            types = importAssembly.GetTypes();
            foreach (Type type in types)
            {
                if (type.GetTypeInfo().BaseType == typeof(System.Enum))
                {
                    string enumName = type.Name;

                    sb.AppendLine(@"        [Fact]");
                    sb.AppendLine($@"        public void Enums_{ enumName }TextOrdered_Test()");
                    sb.AppendLine(@"        {");
                    sb.AppendLine(@"            foreach (CultureInfo culture in new List<CultureInfo>() { new CultureInfo(""en-CA""), new CultureInfo(""fr-CA"") })");
                    sb.AppendLine(@"            {");
                    sb.AppendLine(@"                SetupTest(culture);");
                    sb.AppendLine(@"");
                    sb.AppendLine(@"                List<EnumIDAndText> enumTextOrderedList = new List<EnumIDAndText>();");
                    sb.AppendLine($@"                foreach (int i in Enum.GetValues(typeof({ enumName })))");
                    sb.AppendLine(@"                {");
                    sb.AppendLine($@"                    enumTextOrderedList.Add(new EnumIDAndText() {{ EnumID = i, EnumText = enums.GetResValueForTypeAndID(typeof({ enumName }), i) }});");
                    sb.AppendLine(@"                }");
                    sb.AppendLine(@"                enumTextOrderedList = enumTextOrderedList.OrderBy(c => c.EnumText).ToList();");
                    sb.AppendLine(@"");
                    sb.AppendLine($@"                List<EnumIDAndText> enumTextOrderedList2 = enums.GetEnumTextOrderedList(typeof({ enumName }));");
                    sb.AppendLine(@"                Assert.Equal(enumTextOrderedList.Count, enumTextOrderedList2.Count);");
                    sb.AppendLine(@"");
                    sb.AppendLine(@"                EnumIDAndText enumTextOrdered = new EnumIDAndText();");
                    sb.AppendLine(@"                Assert.NotNull(enumTextOrdered);");
                    sb.AppendLine(@"");
                    sb.AppendLine(@"                for (int i = 0, count = enumTextOrderedList.Count; i < count; i++)");
                    sb.AppendLine(@"                {");
                    sb.AppendLine(@"                    Assert.Equal(enumTextOrderedList[i].EnumText, enumTextOrderedList2[i].EnumText);");
                    sb.AppendLine(@"                    Assert.Equal(enumTextOrderedList[i].EnumID, enumTextOrderedList2[i].EnumID);");
                    sb.AppendLine(@"                }");
                    sb.AppendLine(@"            }");
                    sb.AppendLine(@"        }");
                }
            }
            sb.AppendLine(@"");
            sb.AppendLine(@"        #endregion Testing Method GetEnumTextOrderedList for each Enum value name");

            sb.AppendLine(@"    }");
            sb.AppendLine(@"}");

            using (StreamWriter sw = fi.CreateText())
            {
                sw.Write(sb.ToString());
            }

            sbStatus.AppendLine($"{ AppRes.Created } [{ fi.FullName }] ...");
            sbStatus.AppendLine($"{ AppRes.Done } ...");
            await statusAndResultsService.Update(Command, sbError.ToString(), sbStatus.ToString(), 100);

            Console.WriteLine(sbError.ToString());
            Console.WriteLine(sbStatus.ToString());

            return;
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}