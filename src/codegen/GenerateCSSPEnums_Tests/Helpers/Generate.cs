﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GenerateCSSPEnums_Tests
{
    public partial class Startup
    {
        public async Task<bool> Generate()
        {
            Console.WriteLine("Generate Starting ...");

            StringBuilder sb = new StringBuilder();
            FileInfo fiDLL = new FileInfo(Configuration.GetValue<string>("CSSPEnums"));
            FileInfo fi = new FileInfo(Configuration.GetValue<string>("EnumsTestGenerated"));

            sb.AppendLine(@"/*");
            sb.AppendLine($@" * Auto generated from { AppDomain.CurrentDomain.BaseDirectory }{ AppDomain.CurrentDomain.FriendlyName}.exe");
            sb.AppendLine(@" *");
            sb.AppendLine(@" * Do not edit this file.");
            sb.AppendLine(@" *");
            sb.AppendLine(@" */");
            sb.AppendLine(@"using CSSPCultureServices.Resources;");
            sb.AppendLine(@"using System;");
            sb.AppendLine(@"using System.Collections.Generic;");
            sb.AppendLine(@"using System.Linq;");
            sb.AppendLine(@"using System.Threading.Tasks;");
            sb.AppendLine(@"using Xunit;");
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

                    sb.AppendLine(@"        [Theory]");
                    sb.AppendLine(@"        [InlineData(""en-CA"")]");
                    sb.AppendLine(@"        [InlineData(""fr-CA"")]");
                    sb.AppendLine($@"        public async Task GetResValueForTypeAndID_ForEnum_{ enumName }_Test(string culture)");
                    sb.AppendLine(@"        {");
                    sb.AppendLine(@"            Assert.True(await Setup(culture));");
                    sb.AppendLine(@"");
                    sb.AppendLine($@"            string retStr = enums.GetResValueForTypeAndID(typeof({ enumName }), -100);");
                    sb.AppendLine(@"            Assert.Equal(CSSPCultureEnumsRes.Empty, retStr);");
                    sb.AppendLine(@"");
                    sb.AppendLine($@"            retStr = enums.GetResValueForTypeAndID(typeof({ enumName }), 10000000);");
                    sb.AppendLine(@"            Assert.Equal(CSSPCultureEnumsRes.Empty, retStr);");
                    sb.AppendLine(@"");
                    sb.AppendLine($@"            retStr = enums.GetResValueForTypeAndID(typeof({ enumName }), null);");
                    sb.AppendLine(@"            Assert.Equal(CSSPCultureEnumsRes.Empty, retStr);");
                    sb.AppendLine(@"");
                    sb.AppendLine($@"            retStr = enums.GetResValueForTypeAndID(typeof(string), null);");
                    sb.AppendLine(@"            Assert.Equal(CSSPCultureEnumsRes.Empty, retStr);");
                    sb.AppendLine(@"");
                    sb.AppendLine($@"            foreach (int i in Enum.GetValues(typeof({ enumName })))");
                    sb.AppendLine(@"            {");
                    sb.AppendLine($@"                retStr = enums.GetResValueForTypeAndID(typeof({ enumName }), i);");
                    sb.AppendLine(@"");
                    sb.AppendLine($@"                switch (({ enumName })i)");
                    sb.AppendLine(@"                {");
                    foreach (FieldInfo fieldInfo in type.GetFields())
                    {
                        if (fieldInfo.FieldType.GetTypeInfo().BaseType == typeof(System.Enum))
                        {
                            string fName = fieldInfo.Name;
                            sb.AppendLine($@"                    case { enumName }.{ fName }:");
                            if (fName == "CSSPError")
                            {
                                sb.AppendLine(@"                        Assert.Equal(CSSPCultureEnumsRes.Empty, retStr);");
                                sb.AppendLine(@"                        break;");
                            }
                            else
                            {
                                sb.AppendLine($@"                        Assert.Equal(CSSPCultureEnumsRes.{ enumName }{ fName }, retStr);");
                                sb.AppendLine(@"                        break;");
                            }
                        }
                    }
                    //sb.AppendLine(@"                    default:");
                    //sb.AppendLine(@"                        Assert.Equal(CSSPCultureEnumsRes.Empty, retStr);");
                    //sb.AppendLine(@"                        break;");
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
            sb.AppendLine(@"        [Theory]");
            sb.AppendLine(@"        [InlineData(""en-CA"")]");
            sb.AppendLine(@"        [InlineData(""fr-CA"")]");
            sb.AppendLine(@"        public async Task Enums_EnumTypeListOK_Test(string culture)");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            Assert.True(await Setup(culture));");
            sb.AppendLine(@"");
            sb.AppendLine(@"            List<int?> intList = new List<int?>() { (int)PolSourceObsInfoEnum.AgriculturalSourceCrop, (int)PolSourceObsInfoEnum.AgricultureSourcePasture };");
            sb.AppendLine(@"            Assert.Equal((int)PolSourceObsInfoEnum.AgriculturalSourceCrop, intList[0]);");
            sb.AppendLine(@"            Assert.Equal((int)PolSourceObsInfoEnum.AgricultureSourcePasture, intList[1]);");
            sb.AppendLine(@"            string retStr = enums.EnumTypeListOK(typeof(PolSourceObsInfoEnum), intList);");
            sb.AppendLine(@"            Assert.Equal("""", retStr);");
            sb.AppendLine(@"");
            sb.AppendLine(@"            intList.Add(1000000);");
            sb.AppendLine(@"            retStr = enums.EnumTypeListOK(typeof(PolSourceObsInfoEnum), intList);");
            sb.AppendLine(@"            Assert.Equal(string.Format(CSSPCultureEnumsRes._IsRequired, ""PolSourceObsInfoEnum""), retStr);");
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

                    sb.AppendLine(@"        [Theory]");
                    sb.AppendLine(@"        [InlineData(""en-CA"")]");
                    sb.AppendLine(@"        [InlineData(""fr-CA"")]");
                    sb.AppendLine($@"        public async Task Enums_{ enumName.Substring(0, enumName.Length - 4) }OK_Test(string culture)");
                    sb.AppendLine(@"        {");
                    sb.AppendLine(@"            Assert.True(await Setup(culture));");
                    sb.AppendLine(@"");
                    sb.AppendLine($@"            string retStr = enums.EnumTypeOK(typeof({ enumName }), null);");
                    sb.AppendLine(@"            Assert.Equal("""", retStr);");
                    sb.AppendLine(@"");
                    sb.AppendLine($@"            retStr = enums.EnumTypeOK(typeof({ enumName }), -100);");
                    sb.AppendLine($@"            Assert.Equal(string.Format(CSSPCultureEnumsRes._IsRequired, ""{ enumName }""), retStr);");
                    sb.AppendLine(@"");
                    sb.AppendLine($@"            retStr = enums.EnumTypeOK(typeof({ enumName }), 10000000);");
                    sb.AppendLine($@"            Assert.Equal(string.Format(CSSPCultureEnumsRes._IsRequired, ""{ enumName }""), retStr);");
                    sb.AppendLine(@"");
                    sb.AppendLine($@"            foreach (int i in Enum.GetValues(typeof({ enumName })))");
                    sb.AppendLine(@"            {");
                    sb.AppendLine($@"                retStr = enums.EnumTypeOK(typeof({ enumName }), i);");
                    sb.AppendLine(@"");
                    sb.AppendLine($@"                switch (({ enumName })i)");
                    sb.AppendLine(@"                {");
                    foreach (FieldInfo fieldInfo in type.GetFields())
                    {
                        if (fieldInfo.FieldType.GetTypeInfo().BaseType == typeof(System.Enum))
                        {
                            string fName = fieldInfo.Name;
                            sb.AppendLine($@"                     case { enumName }.{ fName }:");
                        }
                    }
                    sb.AppendLine(@"                        Assert.Equal("""", retStr);");
                    sb.AppendLine(@"                        break;");
                    sb.AppendLine(@"                    default:");
                    sb.AppendLine($@"                        Assert.Equal(string.Format(CSSPCultureEnumsRes._IsRequired, ""{ enumName }""), retStr);");
                    sb.AppendLine(@"                        break;");
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

                    sb.AppendLine(@"        [Theory]");
                    sb.AppendLine(@"        [InlineData(""en-CA"")]");
                    sb.AppendLine(@"        [InlineData(""fr-CA"")]");
                    sb.AppendLine($@"        public async Task Enums_{ enumName }TextOrdered_Test(string culture)");
                    sb.AppendLine(@"        {");
                    sb.AppendLine(@"            Assert.True(await Setup(culture));");
                    sb.AppendLine(@"");
                    sb.AppendLine(@"            List<EnumIDAndText> enumTextOrderedList = new List<EnumIDAndText>();");
                    sb.AppendLine($@"            foreach (int i in Enum.GetValues(typeof({ enumName })))");
                    sb.AppendLine(@"            {");
                    sb.AppendLine($@"                enumTextOrderedList.Add(new EnumIDAndText() {{ EnumID = i, EnumText = enums.GetResValueForTypeAndID(typeof({ enumName }), i) }});");
                    sb.AppendLine(@"            }");
                    sb.AppendLine(@"            enumTextOrderedList = enumTextOrderedList.OrderBy(c => c.EnumText).ToList();");
                    sb.AppendLine(@"");
                    sb.AppendLine($@"            List<EnumIDAndText> enumTextOrderedList2 = enums.GetEnumTextOrderedList(typeof({ enumName }));");
                    sb.AppendLine(@"            Assert.Equal(enumTextOrderedList.Count, enumTextOrderedList2.Count);");
                    sb.AppendLine(@"");
                    sb.AppendLine(@"            EnumIDAndText enumTextOrdered = new EnumIDAndText();");
                    sb.AppendLine(@"            Assert.NotNull(enumTextOrdered);");
                    sb.AppendLine(@"");
                    sb.AppendLine(@"            for (int i = 0, count = enumTextOrderedList.Count; i < count; i++)");
                    sb.AppendLine(@"            {");
                    sb.AppendLine(@"                Assert.Equal(enumTextOrderedList[i].EnumText, enumTextOrderedList2[i].EnumText);");
                    sb.AppendLine(@"                Assert.Equal(enumTextOrderedList[i].EnumID, enumTextOrderedList2[i].EnumID);");
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

            Console.WriteLine($"Created [{ fi.FullName }] ...");
            Console.WriteLine($"Done ...");
            Console.WriteLine("");
            Console.WriteLine("Generate Finished ...");


            return true;
        }
    }
}
