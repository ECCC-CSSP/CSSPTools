using GenerateCodeBaseHelper;
using GenerateCodeBaseServices.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateCompareDBFieldsAndCSSPDBModelsProp
{
    partial class Startup
    {
        private async Task<bool> CompareDBAndCSSPDBModelsDLL(List<Table> tableList, List<TypeProp> typePropList)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Comparing DB Fields name that does not exist in the CSSPDBModels.DLL");
            sb.AppendLine("");
            foreach (Table table in tableList.OrderBy(c => c.TableName))
            {
                if (table.TableName.StartsWith("AspNet") || table.TableName.StartsWith("sys") || table.TableName.StartsWith("DeviceCodes") || table.TableName.StartsWith("PersistedGrants"))
                {
                    continue;
                }

                TypeProp typePropExist = (from c in typePropList
                                          let t = c.type.Name + c.Plurial
                                          where t == table.TableName
                                          select c).FirstOrDefault();

                if (typePropExist == null)
                {
                    sb.AppendLine($"{ table.TableName } ---------------- object does not exist for table");
                    sb.AppendLine("\r\n");
                }
                foreach (Col col in table.colList)
                {
                    TypeProp typeProp = (from c in typePropList
                                         where (c.type.Name + c.Plurial) == table.TableName
                                         select c).FirstOrDefault();

                    if (typeProp != null)
                    {
                        // ---------------------------------------
                        // Check if field name exist
                        // ---------------------------------------
                        CSSPProp csspProp = (from c in typeProp.csspPropList
                                             where c.PropName == col.FieldName
                                             select c).FirstOrDefault();

                        if (csspProp == null)
                        {
                            sb.AppendLine($"{ table.TableName }\t{ col.FieldName }\t---------------- does not exist");
                            continue;
                        }

                        if (csspProp.IsNullable != col.AllowNull)
                        {
                            string NullOrNot = (col.AllowNull ? "Nullable" : "Not Nullable");
                            sb.AppendLine($"{ table.TableName }\t{ col.FieldName }\t---------------- should be { NullOrNot }");
                            continue;
                        }

                        // ---------------------------------------
                        // Check if field types correspond and proper Attributes
                        // ---------------------------------------
                        switch (col.DataType)
                        {
                            case "bit":
                                {
                                    if (csspProp.PropType != "Boolean")
                                    {
                                        sb.AppendLine($"{ table.TableName }\t{ col.FieldName }\t---------------- wrong type It is [{ csspProp.PropType }] should be [Boolean]");
                                    }
                                }
                                break;
                            case "bigint":
                                {
                                    if (csspProp.PropType != "Int64")
                                    {
                                        sb.AppendLine($"{ table.TableName }\t{ col.FieldName }\t---------------- wrong type It is [{ csspProp.PropType }] should be [Int64]");
                                    }

                                    if (csspProp.HasCSSPExistAttribute)
                                    {
                                        if (csspProp.HasCSSPRangeAttribute)
                                        {
                                            sb.AppendLine($"{ table.TableName }\t{ col.FieldName }\t---------------- should NOT have a Range Attribute");
                                        }
                                    }
                                    else
                                    {
                                        if (!csspProp.HasCSSPRangeAttribute)
                                        {
                                            sb.AppendLine($"{ table.TableName }\t{ col.FieldName }\t---------------- should have a Range Attribute");
                                        }
                                    }
                                }
                                break;
                            case "int":
                                {
                                    if (csspProp.PropType != "Int32")
                                    {
                                        if ($"{ col.FieldName }Enum" != csspProp.PropType)
                                        {
                                            TableFieldEnumException tableFieldEnumException = TableFieldEnumExceptionList.Where(c => c.TableName == table.TableName && c.FieldName == col.FieldName).FirstOrDefault();
                                            if (tableFieldEnumException == null)
                                            {
                                                sb.AppendLine($"{ table.TableName }\t{ col.FieldName }\t---------------- wrong type It is [{ csspProp.PropType }] should be [Int32]");
                                                sb.AppendLine("\r\n");
                                                sb.AppendLine("You might need to add this enumeration type within the FillPublicList() within the ModelsGenerateCodeHelper.cs\r\n");
                                                sb.AppendLine("Suggestion line to add:\r\n");
                                                sb.AppendLine($@"new TableFieldEnumException() {{ TableName = ""{ table.TableName }"", FieldName = ""{ col.FieldName }"", EnumText = ""{ csspProp.PropType }"" }},\r\n");
                                            }
                                            else
                                            {
                                                if (tableFieldEnumException.EnumText != csspProp.PropType)
                                                {
                                                    sb.AppendLine($"{ table.TableName }\t{ col.FieldName }\t---------------- wrong type It is [{ csspProp.PropType }] should be [Int32]");
                                                }

                                                if (!csspProp.HasCSSPEnumTypeAttribute)
                                                {
                                                    sb.AppendLine($"{ table.TableName }\t{ col.FieldName }\t---------------- should have a CSSPEnumType Attribute");
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (!csspProp.HasCSSPEnumTypeAttribute)
                                            {
                                                sb.AppendLine($"{ table.TableName }\t{ col.FieldName }\t---------------- should have a CSSPEnumType Attribute");
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (!csspProp.IsKey)
                                        {
                                            if (csspProp.HasCSSPExistAttribute)
                                            {
                                                if (csspProp.HasCSSPRangeAttribute)
                                                {
                                                    sb.AppendLine($"{ table.TableName }\t{ col.FieldName }\t---------------- should NOT have a Range Attribute");
                                                }
                                            }
                                            else
                                            {
                                                if (!csspProp.HasCSSPRangeAttribute)
                                                {
                                                    sb.AppendLine($"{ table.TableName }\t{ col.FieldName }\t---------------- should have a Range Attribute");
                                                }
                                            }

                                            if (csspProp.PropName.EndsWith("ID"))
                                            {
                                                TableFieldIDException tableFieldIDException = TableFieldIDExceptionList.Where(c => c.TableName == table.TableName && c.FieldName == col.FieldName).FirstOrDefault();
                                                if (tableFieldIDException == null)
                                                {
                                                    if (!csspProp.HasCSSPExistAttribute)
                                                    {
                                                        sb.AppendLine($"{ table.TableName }\t{ col.FieldName }\t---------------- should have a CSSPExist Attribute");
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                break;
                            case "datetime":
                                {
                                    if (csspProp.PropType != "DateTime")
                                    {
                                        sb.AppendLine($"{ table.TableName }\t{ col.FieldName }\t---------------- wrong type It is [{ csspProp.PropType }] should be [DateTime]");
                                    }

                                    if (!csspProp.HasCSSPAfterAttribute)
                                    {
                                        sb.AppendLine($"{ table.TableName }\t{ col.FieldName }\t---------------- should have a CSSPAfter Attribute");
                                    }

                                    if (csspProp.PropName.ToUpper().StartsWith("END"))
                                    {
                                        if (!csspProp.HasCSSPBiggerAttribute)
                                        {
                                            sb.AppendLine($"{ table.TableName }\t{ col.FieldName }\t---------------- should have a CSSPBigger Attribute");
                                        }
                                    }
                                }
                                break;
                            case "text":
                                {
                                    if (csspProp.PropType != "String")
                                    {
                                        sb.AppendLine($"{ table.TableName }\t{ col.FieldName }\t---------------- wrong type It is [{ csspProp.PropType }] should be [String]");
                                    }
                                }
                                break;
                            case "nchar":
                            case "nvarchar":
                                {
                                    if (csspProp.PropType != "String")
                                    {
                                        sb.AppendLine($"{ table.TableName }\t{ col.FieldName }\t---------------- wrong type It is [{ csspProp.PropType }] should be [String]");
                                    }

                                    if (!csspProp.HasCSSPMaxLengthAttribute)
                                    {
                                        sb.AppendLine($"{ table.TableName }\t{ col.FieldName }\t---------------- should have a CSSPMaxLength Attribute");
                                    }

                                    TableFieldEmail tableFieldEmail = TableFieldEmailList.Where(c => c.TableName == table.TableName && c.FieldName == col.FieldName).FirstOrDefault();
                                    if (tableFieldEmail != null)
                                    {
                                        if (csspProp.dataType != DataType.EmailAddress)
                                        {
                                            sb.AppendLine($"{ table.TableName }\t{ col.FieldName }\t---------------- should have a DataType Attribute set to email");
                                        }
                                    }
                                }
                                break;
                            case "float":
                                {
                                    if (csspProp.PropType != "Double")
                                    {
                                        sb.AppendLine($"{ table.TableName }\t{ col.FieldName }\t---------------- wrong type It is [{ csspProp.PropType }] should be [Double]");
                                    }

                                    if (!csspProp.HasCSSPRangeAttribute)
                                    {
                                        sb.AppendLine($"{ table.TableName }\t{ col.FieldName }\t---------------- should have a Range Attribute");
                                    }
                                }
                                break;
                            case "varbinary":
                                {
                                    // don't know what to check yet
                                }
                                break;
                            default:
                                {
                                    sb.AppendLine($"{ table.TableName }\t{ col.FieldName }\t---------------- not implemented [{ col.DataType }]");
                                }
                                break;
                        }

                    }
                }
            }

            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("Comparing CSSPDBModels.DLL properties that does not exist in DB");
            sb.AppendLine("");
            foreach (TypeProp typeProp in typePropList.OrderBy(c => c.type.Name))
            {
                if (typeProp.type.CustomAttributes.Where(c => c.AttributeType.FullName.Contains("NotMappedAttribute")).Any())
                {
                    continue;
                }

                foreach (CSSPProp csspProp in typeProp.csspPropList)
                {
                    if (csspProp.IsVirtual)
                    {
                        continue;
                    }

                    if (csspProp.PropName == "ValidationResults")
                    {
                        continue;
                    }

                    if (csspProp.HasNotMappedAttribute)
                    {
                        continue;
                    }

                    if (GenerateCodeBase.SkipType(typeProp.type))
                    {
                        continue;
                    }

                    string tableName = $"{ typeProp.type.Name }{ typeProp.Plurial }";
                    Table table = (from c in tableList
                                   where c.TableName == tableName
                                   select c).FirstOrDefault();

                    if (table == null)
                    {
                        sb.AppendLine($"{ typeProp.type.Name }\t{ csspProp.PropName }\t---------------- does not exist");
                        continue;
                    }

                    Col col = (from c in table.colList
                               where c.FieldName == csspProp.PropName
                               select c).FirstOrDefault();

                    if (col == null)
                    {
                        sb.AppendLine($"{ typeProp.type.Name }\t{ csspProp.PropName }\t---------------- does not exist");
                    }
                }
            }

            Console.WriteLine(sb.ToString());
            //StatusPermanentEvent(new StatusEventArgs(sb.ToString()));

            return await Task.FromResult(true);
        }
    }
}
