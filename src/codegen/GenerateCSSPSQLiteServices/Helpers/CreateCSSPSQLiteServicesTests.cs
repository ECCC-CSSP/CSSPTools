﻿using CSSPCultureServices.Resources;
using GenerateCodeBaseHelper;
using GenerateCodeBaseServices.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GenerateCSSPSQLiteServices
{
    public partial class Startup
    {
        private async Task<bool> CreateCSSPSQLiteServicesTests(FileInfo fiDLL)
        {
            List<string> ModelListCSSPDBTableList = new List<string>();
            List<string> ListCSSPDBTableList = new List<string>();
            if (!await FillCSSPDBTableList(ListCSSPDBTableList)) return false;

            var importAssembly = Assembly.LoadFile(fiDLL.FullName);
            Type[] types = importAssembly.GetTypes();
            foreach (Type type in types)
            {
                bool ClassNotMapped = false;
                string TypeName = type.Name;

                string plurial = "s";
                if (TypeName == "Address")
                {
                    plurial = "es";
                }

                if (GenerateCodeBase.SkipType(type))
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

                if (!ClassNotMapped)
                {
                    ModelListCSSPDBTableList.Add(TypeName + plurial);
                }
            }

            bool ErrorExist = false;
            foreach (string CSSPDBTableName in ListCSSPDBTableList)
            {
                if (!ModelListCSSPDBTableList.Contains(CSSPDBTableName))
                {
                    Console.WriteLine($"Model does not contain [{ CSSPDBTableName }]. Might have to delete it from the ListCSSPDBTableList in the FillCSSPDBTableList.cs code file");
                }
            }

            foreach (string ModelCSSPDBTableName in ModelListCSSPDBTableList)
            {
                if (!ListCSSPDBTableList.Contains(ModelCSSPDBTableName))
                {
                    Console.WriteLine($"Model does not contain [{ ModelCSSPDBTableName  }]. Might have to add it to the ListCSSPDBTableList in the FillCSSPDBTableList.cs code file");
                }
            }

            if (ErrorExist)
            {
                return await Task.FromResult(false);
            }

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($@"/* Auto generated from { AppDomain.CurrentDomain.BaseDirectory }{ AppDomain.CurrentDomain.FriendlyName}.exe");
            sb.AppendLine(@" *");
            sb.AppendLine(@" * Do not edit this file.");
            sb.AppendLine(@" *");
            sb.AppendLine(@" */");
            sb.AppendLine(@"");
            sb.AppendLine(@"using CSSPSQLiteServices;");
            sb.AppendLine(@"using System;");
            sb.AppendLine(@"using System.Collections.Generic;");
            sb.AppendLine(@"using System.Text;");
            sb.AppendLine(@"using Xunit;");
            sb.AppendLine(@"");
            sb.AppendLine(@"namespace CSSPSQLiteServices.Tests");
            sb.AppendLine(@"{");
            sb.AppendLine(@"    public class CSSPSQLiteServicesTests");
            sb.AppendLine(@"    {");
            sb.AppendLine(@"        [Fact]");
            sb.AppendLine(@"        public void CreateSQLiteCSSPDBLocal_Good_Test()");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            SQLiteCreateCSSPDBLocal sqliteCreateCSSPDBLocal = new SQLiteCreateCSSPDBLocal();");
            sb.AppendLine(@"");
            sb.AppendLine(@"            bool retBool = sqliteCreateCSSPDBLocal.CreateSQLiteCSSPDBLocal();");
            sb.AppendLine(@"            Assert.True(retBool);");
            sb.AppendLine(@"        }");
            sb.AppendLine(@"");
            sb.AppendLine(@"    }");
            sb.AppendLine(@"}");


            FileInfo fiOutputGen = new FileInfo(Config.GetValue<string>("CreateTableBuilderTests"));

            using (StreamWriter sw = fiOutputGen.CreateText())
            {
                sw.Write(sb.ToString());
            }

            Console.WriteLine($"{ string.Format(CSSPCultureServicesRes.Created_, fiOutputGen.FullName) }");

            return await Task.FromResult(true);
        }
    }
}