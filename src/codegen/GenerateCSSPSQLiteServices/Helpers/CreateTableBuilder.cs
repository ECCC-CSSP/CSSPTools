﻿using CSSPCultureServices.Resources;
using GenerateCodeBaseHelper;
using GenerateCodeBaseServices.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GenerateCSSPSQLiteServices
{
    public partial class Startup
    {
        private async Task<bool> CreateTableBuilder(FileInfo fiDLL)
        {
            List<string> ListCSSPDBTableList = new List<string>();
            if (!await FillCSSPDBTableList(ListCSSPDBTableList)) return false;

            List<Table> tableCSSPDBList = new List<Table>();
            string CSSPDB2 = Config.GetValue<string>("CSSPDB2");
            if (!await LoadDBInfo(tableCSSPDBList, CSSPDB2)) return await Task.FromResult(false);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($@"/* Auto generated from { AppDomain.CurrentDomain.BaseDirectory }{ AppDomain.CurrentDomain.FriendlyName}.exe");
            sb.AppendLine(@" *");
            sb.AppendLine(@" * Do not edit this file.");
            sb.AppendLine(@" *");
            sb.AppendLine(@" */");
            sb.AppendLine(@"");
            sb.AppendLine(@"using Microsoft.Data.Sqlite;");
            sb.AppendLine(@"using Microsoft.EntityFrameworkCore;");
            sb.AppendLine(@"using System.Threading.Tasks;");
            sb.AppendLine(@"");
            sb.AppendLine(@"namespace CSSPSQLiteServices");
            sb.AppendLine(@"{");
            sb.AppendLine(@"    public partial class CSSPSQLiteService : ICSSPSQLiteService");
            sb.AppendLine(@"    {");
            sb.AppendLine(@"        private async Task<bool> CreateTableBuilder(string tableName, bool DoSearch)");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            string CreateTable = """";");
            sb.AppendLine(@"            switch (tableName)");
            sb.AppendLine(@"            {");

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

                if (!ListCSSPDBTableList.Contains(TypeName + plurial)) continue;

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
                    if (TypeName == "TVItem" || TypeName == "TVItemLanguage")
                    {
                        sb.AppendLine($@"                case ""{ TypeName + plurial }"":");
                        sb.AppendLine($@"                    CreateTable = ""CREATE TABLE { TypeName + plurial } ("" +");

                        int countProp2 = 0;
                        int TotCountProp2 = type.GetProperties().Count();

                        List<string> ForeignKeyStrList2 = new List<string>();
                        foreach (PropertyInfo prop in type.GetProperties())
                        {
                            countProp2 += 1;

                            CSSPProp csspProp = new CSSPProp();
                            if (!GenerateCodeBase.FillCSSPProp(prop, csspProp, type))
                            {
                                //Console.WriteLine($"{ string.Format(AppRes.ErrorWhileCreatingCode_, csspProp.CSSPError) }");
                                return await Task.FromResult(false);
                            }

                            string TempStr = "";
                            string Unique = "";
                            string NotNull = "";
                            string FieldType = "";
                            string CollateNoCase = "";

                            if (csspProp.IsKey)
                            {
                                Unique = " UNIQUE";
                            }

                            if (!csspProp.IsNullable)
                            {
                                NotNull = " NOT NULL";
                            }

                            switch (csspProp.PropType)
                            {
                                case "Boolean":
                                case "Int16":
                                case "Int32":
                                case "Int64":
                                    {
                                        FieldType = "INTEGER";
                                    }
                                    break;
                                case "Single":
                                case "Double":
                                    {
                                        FieldType = "REAL";
                                    }
                                    break;
                                case "DateTime":
                                case "DateTimeOffset":
                                case "String":
                                    {
                                        FieldType = "TEXT";
                                        //CollateNoCase = "COLLATE NOCASE";
                                    }
                                    break;
                                case "Byte[]":
                                    {
                                        FieldType = "BLOB";
                                    }
                                    break;
                                default:
                                    {
                                        if (csspProp.HasCSSPEnumTypeAttribute)
                                        {
                                            FieldType = "INTEGER";
                                        }
                                        else
                                        {
                                            TempStr = $@"   ERROR ";
                                        }
                                    }
                                    break;
                            }

                            TempStr = $@"                    ""{ csspProp.PropName } { FieldType } { NotNull } { Unique } { CollateNoCase }, "" +";

                            if (csspProp.HasCSSPForeignKeyAttribute)
                            {
                                //ForeignKeyStrList.Add($@"                    @""FOREIGN KEY(""""{ csspProp.PropName }"""") REFERENCES """"{ csspProp.TableName }"""" (""""{ csspProp.FieldName }""""), "" +");
                            }

                            if (countProp2 == TotCountProp2)
                            {
                                if (ForeignKeyStrList2.Count > 0)
                                {
                                    sb.AppendLine(TempStr);
                                    int CountForeignKey = 0;
                                    int TotForeignKey = ForeignKeyStrList2.Count();
                                    foreach (string s in ForeignKeyStrList2)
                                    {
                                        CountForeignKey += 1;
                                        if (CountForeignKey == TotForeignKey)
                                        {
                                            sb.AppendLine(s.Substring(0, s.Length - 5) + ")\";");
                                        }
                                        else
                                        {
                                            sb.AppendLine(s);
                                        }
                                    }
                                }
                                else
                                {
                                    sb.AppendLine(TempStr.Substring(0, TempStr.Length - 5) + ")\";");
                                }
                            }
                            else
                            {
                                sb.AppendLine(TempStr);
                            }

                        }
                        sb.AppendLine($@"                    break;");

                    }

                    sb.AppendLine($@"                case ""Local{ TypeName + plurial }"":");
                    sb.AppendLine($@"                    CreateTable = ""CREATE TABLE Local{ TypeName + plurial } ("" +");
                    sb.AppendLine($@"                    ""LocalDBCommand INTEGER NOT NULL, "" +");

                    int countProp = 0;
                    int TotCountProp = type.GetProperties().Count();

                    List<string> ForeignKeyStrList = new List<string>();
                    foreach (PropertyInfo prop in type.GetProperties())
                    {
                        countProp += 1;

                        CSSPProp csspProp = new CSSPProp();
                        if (!GenerateCodeBase.FillCSSPProp(prop, csspProp, type))
                        {
                            //Console.WriteLine($"{ string.Format(AppRes.ErrorWhileCreatingCode_, csspProp.CSSPError) }");
                            return await Task.FromResult(false);
                        }

                        string TempStr = "";
                        string Unique = "";
                        string NotNull = "";
                        string FieldType = "";
                        string CollateNoCase = "";

                        if (csspProp.IsKey)
                        {
                            Unique = " UNIQUE";
                        }

                        if (!csspProp.IsNullable)
                        {
                            NotNull = " NOT NULL";
                        }

                        switch (csspProp.PropType)
                        {
                            case "Boolean":
                            case "Int16":
                            case "Int32":
                            case "Int64":
                                {
                                    FieldType = "INTEGER";
                                }
                                break;
                            case "Single":
                            case "Double":
                                {
                                    FieldType = "REAL";
                                }
                                break;
                            case "DateTime":
                            case "DateTimeOffset":
                            case "String":
                                {
                                    FieldType = "TEXT";
                                    //CollateNoCase = "COLLATE NOCASE";
                                }
                                break;
                            case "Byte[]":
                                {
                                    FieldType = "BLOB";
                                }
                                break;
                            default:
                                {
                                    if (csspProp.HasCSSPEnumTypeAttribute)
                                    {
                                        FieldType = "INTEGER";
                                    }
                                    else
                                    {
                                        TempStr = $@"   ERROR ";
                                    }
                                }
                                break;
                        }

                        TempStr = $@"                    ""{ csspProp.PropName } { FieldType } { NotNull } { Unique } { CollateNoCase }, "" +";

                        if (csspProp.HasCSSPForeignKeyAttribute)
                        {
                            //ForeignKeyStrList.Add($@"                    @""FOREIGN KEY(""""{ csspProp.PropName }"""") REFERENCES """"{ csspProp.TableName }"""" (""""{ csspProp.FieldName }""""), "" +");
                        }

                        if (countProp == TotCountProp)
                        {
                            if (ForeignKeyStrList.Count > 0)
                            {
                                sb.AppendLine(TempStr);
                                int CountForeignKey = 0;
                                int TotForeignKey = ForeignKeyStrList.Count();
                                foreach (string s in ForeignKeyStrList)
                                {
                                    CountForeignKey += 1;
                                    if (CountForeignKey == TotForeignKey)
                                    {
                                        sb.AppendLine(s.Substring(0, s.Length - 5) + ")\";");
                                    }
                                    else
                                    {
                                        sb.AppendLine(s);
                                    }
                                }
                            }
                            else
                            {
                                sb.AppendLine(TempStr.Substring(0, TempStr.Length - 5) + ")\";");
                            }
                        }
                        else
                        {
                            sb.AppendLine(TempStr);
                        }

                    }
                    sb.AppendLine($@"                    break;");
                }
            }


            sb.AppendLine(@"                default:");
            sb.AppendLine(@"                    break;");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"");
            sb.AppendLine(@"            if (DoSearch)");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                using (var command = dbSearch.Database.GetDbConnection().CreateCommand())");
            sb.AppendLine(@"                {");
            sb.AppendLine(@"                    command.CommandText = CreateTable;");
            sb.AppendLine(@"                    dbSearch.Database.OpenConnection();");
            sb.AppendLine(@"                    command.ExecuteNonQuery();");
            sb.AppendLine(@"                }");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"            else");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                using (var command = dbLocal.Database.GetDbConnection().CreateCommand())");
            sb.AppendLine(@"                {");
            sb.AppendLine(@"                    command.CommandText = CreateTable;");
            sb.AppendLine(@"                    dbLocal.Database.OpenConnection();");
            sb.AppendLine(@"                    command.ExecuteNonQuery();");
            sb.AppendLine(@"                }");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"");
            sb.AppendLine(@"            return await Task.FromResult(true);");
            sb.AppendLine(@"        }");
            sb.AppendLine(@"    }");
            sb.AppendLine(@"}");

            FileInfo fiOutputGen = new FileInfo(Config.GetValue<string>("CreateTableBuilder"));

            using (StreamWriter sw = fiOutputGen.CreateText())
            {
                sw.Write(sb.ToString());
            }

            Console.WriteLine($"{ string.Format(CSSPCultureServicesRes.Created_, fiOutputGen.FullName) }");

            return await Task.FromResult(true);
        }
    }
}
