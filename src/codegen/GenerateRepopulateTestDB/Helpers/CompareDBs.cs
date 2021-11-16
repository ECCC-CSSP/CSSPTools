//using GenerateCodeBaseServices.Models;
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace GenerateRepopulateTestDB
//{
//    public partial class Startup
//    {
//        private async Task<bool> CompareDBs(List<Table> tableCSSPDBList, List<Table> tableTestDBList)
//        {
//            StringBuilder sb = new StringBuilder();

//            foreach (Table tableCSSP in tableCSSPDBList)
//            {
//                //Console.WriteLine($"{ tableCSSP.TableName }");

//                if (tableCSSP.TableName == "sysdiagrams") continue;

//                Table tableTest = (from c in tableTestDBList
//                                   where c.TableName == tableCSSP.TableName
//                                   select c).FirstOrDefault();

//                if (tableTest == null)
//                {
//                    sb.AppendLine($"{ tableCSSP.TableName } does not exist in TestDB");
//                    continue;
//                }

//                foreach (Col col in tableCSSP.colList)
//                {
//                    //Console.WriteLine($"{ tableCSSP.TableName }    { col.FieldName }");

//                    Col colTest = (from c in tableTest.colList
//                                   where c.FieldName == col.FieldName
//                                   select c).FirstOrDefault();

//                    if (colTest == null)
//                    {
//                        sb.AppendLine($"{ tableCSSP.TableName }\t{ col.FieldName } does not exist in TestDB");
//                    }

//                    if (col.AllowNull != colTest.AllowNull)
//                    {
//                        sb.AppendLine($"{ tableCSSP.TableName }\t{ col.FieldName } Allow Null does not match in TestDB");
//                    }

//                    if (col.DataType != colTest.DataType)
//                    {
//                        sb.AppendLine($"{ tableCSSP.TableName }\t{ col.FieldName } Data Type does not match in TestDB");
//                    }

//                    if (col.StringLength != colTest.StringLength)
//                    {
//                        sb.AppendLine($"{ tableCSSP.TableName }\t{ col.FieldName } String Length does not match in TestDB");
//                    }
//                }
//            }

//            if (sb.ToString().Length > 0)
//            {
//                Console.WriteLine($"{ sb.ToString() }");
//                return await Task.FromResult(false);
//            }

//            return await Task.FromResult(true);
//        }
//    }
//}
