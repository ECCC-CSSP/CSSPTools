using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using Microsoft.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Forms;
using CSSPModels;

namespace CSSPModelsGenerateCodeHelper
{
    public partial class ModelsCodeWriter
    {
        #region Functions public
        /// <summary>
        /// Generates:
        ///     C:\CSSPTools\src\dlls\CSSPModels\Resources\CSSPModelsRes.resx file
        ///     C:\CSSPTools\src\dlls\CSSPModels\Resources\CSSPModelsRes.fr.resx file
        /// 
        /// Requires:
        ///     C:\CSSPTools\src\dlls\CSSPModels\bin\Debug\netcoreapp3.1\CSSPModels.dll
        ///     
        /// </summary>
        /// <param name="CSSPDBConnectionString">Contains the connection string of the CSSPDB</param>
        public void CompareDBFieldsAndCSSPModelsDLLProperties(string CSSPDBConnectionString)
        {
            StatusTempEvent(new StatusEventArgs(""));
            ClearPermanentEvent(new StatusEventArgs(""));

            List<Table> tableCSSPWebList = new List<Table>();
            List<TypeProp> typePropList = new List<TypeProp>();

            // loading what currently exist in the DB
            if (!LoadDBInfo(tableCSSPWebList, CSSPDBConnectionString))
            {
                return;
            }

            // Loading what exist in the compiled CSSPModels.dll
            if (!LoadCSSPModelsDLLInfo(typePropList))
            {
                return;
            }

            // Compare DB and Compiled CSSPModels.DLL
            if (!CompareDBAndCSSPModelsDLL(tableCSSPWebList, typePropList))
            {
                return;
            }

            StatusTempEvent(new StatusEventArgs("Done ..."));
            StatusPermanentEvent(new StatusEventArgs(""));
            StatusPermanentEvent(new StatusEventArgs("Done ..."));
            StatusPermanentEvent(new StatusEventArgs(""));

        }
        #endregion Functions public

        #region Functions private
        /// <summary>
        ///     Compares the fields in the DB and the ones compiled in CSSPModels DLL
        /// </summary>
        /// <param name="tableList">List of Table information from the DB</param>
        /// <param name="typePropList">List of property information from the compiled CSSPModels DLL</param>
        /// <returns>True if all fields from DB compares with property fields from the compiled CSSPModels DLL</returns>
        private bool CompareDBAndCSSPModelsDLL(List<Table> tableList, List<TypeProp> typePropList)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Comparing DB Fields name that does not exist in the CSSPModels.DLL");
            sb.AppendLine("");
            foreach (Table table in tableList.OrderBy(c => c.TableName))
            {
                if (table.TableName.StartsWith("AspNet") || table.TableName.StartsWith("sys"))
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
                    StatusTempEvent(new StatusEventArgs($"{ table.TableName } --- { col.FieldName}"));
                    //Application.DoEvents();

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
                                        if (csspProp.HasRangeAttribute)
                                        {
                                            sb.AppendLine($"{ table.TableName }\t{ col.FieldName }\t---------------- should NOT have a Range Attribute");
                                        }
                                    }
                                    else
                                    {
                                        if (!csspProp.HasRangeAttribute)
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
                                                if (csspProp.HasRangeAttribute)
                                                {
                                                    sb.AppendLine($"{ table.TableName }\t{ col.FieldName }\t---------------- should NOT have a Range Attribute");
                                                }
                                            }
                                            else
                                            {
                                                if (!csspProp.HasRangeAttribute)
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

                                    if (!csspProp.HasStringLengthAttribute)
                                    {
                                        sb.AppendLine($"{ table.TableName }\t{ col.FieldName }\t---------------- should have a StringLength Attribute");
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

                                    if (!csspProp.HasRangeAttribute)
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
            sb.AppendLine("Comparing CSSPModels.DLL properties that does not exist in DB");
            sb.AppendLine("");
            foreach (TypeProp typeProp in typePropList.OrderBy(c => c.type.Name))
            {
                if (typeProp.type.CustomAttributes.Where(c => c.AttributeType.FullName.Contains("NotMappedAttribute")).Any())
                {
                    continue;
                }

                foreach (CSSPProp csspProp in typeProp.csspPropList)
                {
                    StatusTempEvent(new StatusEventArgs($"{ typeProp.type.Name } --- { csspProp.PropName }"));
                    //Application.DoEvents();

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

                    if (SkipType(typeProp.type))
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

            StatusPermanentEvent(new StatusEventArgs(sb.ToString()));

            return true;
        }
        /// <summary>
        ///     Load all properties found in CSSPModels Dll in typePropList
        /// </summary>
        /// <param name="typePropList">Holds all properties from the compiled CSSPModels DLL</param>
        /// <returns>True if all properties where gathered without CSSPErrors</returns>
        private bool LoadCSSPModelsDLLInfo(List<TypeProp> typePropList)
        {

            FileInfo fiDLL = new FileInfo(@"C:\CSSPTools\src\dlls\CSSPModels\bin\Debug\netcoreapp3.1\CSSPModels.dll");

            if (!fiDLL.Exists)
            {
                CSSPErrorEvent(new CSSPErrorEventArgs($"{ fiDLL.FullName } does not exist"));
                return false;
            }

            try
            {
                var importAssembly = Assembly.LoadFile(fiDLL.FullName);
                Type[] types = importAssembly.GetTypes();

                foreach (Type type in types)
                {
                    TypeProp typeProp = new TypeProp();
                    typeProp.type = type;
                    typeProp.Plurial = "s";
                    if (type.Name == "Address")
                    {
                        typeProp.Plurial = "es";
                    }

                    //if (type.Name == "AddressWeb")
                    //{
                    //    int seflij = 34;
                    //}
                    if (SkipType(type))
                    {
                        continue;
                    }

                    foreach (PropertyInfo propertyInfo in type.GetProperties())
                    {
                        if (propertyInfo.GetGetMethod().IsVirtual)
                        {
                            continue;
                        }

                        if (propertyInfo.Name == "ValidationResults")
                        {
                            continue;
                        }

                        CSSPProp csspProp = new CSSPProp();
                        if (!FillCSSPProp(propertyInfo, csspProp, type))
                        {
                            CSSPErrorEvent(new CSSPErrorEventArgs($"CSSPError while creating code [{ csspProp.CSSPError }]"));
                            return false;
                        }

                        typeProp.csspPropList.Add(csspProp);
                    }


                    typePropList.Add(typeProp);
                }
            }
            catch (Exception ex)
            {
                CSSPErrorEvent(new CSSPErrorEventArgs(ex.Message));
                return false;
            }

            return true;
        }
        /// <summary>
        ///     Load all DB table information in tableList
        /// </summary>
        /// <param name="tableList">Holds all Table information from DB with connection string ConnectionString</param>
        /// <param name="ConnectionString">Contains the connection string of the CSSPDB</param>
        /// <returns></returns>
        private bool LoadDBInfo(List<Table> tableList, string ConnectionString)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(ConnectionString))
                {
                    cnn.Open();
                    DataTable tblList = cnn.GetSchema("Tables");
                    DataTable clmList = cnn.GetSchema("Columns");

                    foreach (DataRow tbl in tblList.Rows)
                    {
                        Table table = new Table();
                        table.TableName = tbl.ItemArray[2].ToString();
                        tableList.Add(table);

                        foreach (DataRow dr in clmList.Rows)
                        {
                            if (dr[2].ToString() == table.TableName)
                            {
                                Col col = new Col();
                                col.FieldName = dr[3].ToString();
                                col.AllowNull = (dr[6].ToString() == "NO" ? false : true);
                                col.DataType = dr[7].ToString();
                                col.StringLength = (string.IsNullOrWhiteSpace(dr[8].ToString()) ? 0 : int.Parse(dr[8].ToString()));

                                table.colList.Add(col);
                            }
                        }
                    }

                    cnn.Close();
                }
            }
            catch (Exception ex)
            {
                CSSPErrorEvent(new CSSPErrorEventArgs(ex.Message));
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}
