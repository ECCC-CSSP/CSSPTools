using CSSPEnums;
using GenerateCodeBaseServices.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace GenerateCodeBaseHelper
{
    public static partial class GenerateCodeBase
    {
        public static bool FillCSSPProp(PropertyInfo propInfo, CSSPProp csspProp, Type type)
        {
            csspProp.PropName = propInfo.Name;

            csspProp.IsNullable = propInfo.CustomAttributes.Where(c => c.AttributeType.Name == "CSSPAllowNullAttribute").Any();

            if (propInfo.PropertyType.FullName.StartsWith("System.Nullable"))
            {
                csspProp.IsNullable = true;

                string typeTxt = propInfo.PropertyType.FullName;
                typeTxt = typeTxt.Substring(typeTxt.IndexOf("[[") + 2);
                typeTxt = typeTxt.Substring(typeTxt.IndexOf(".") + 1);
                typeTxt = typeTxt.Substring(0, typeTxt.IndexOf(","));

                csspProp.PropType = typeTxt;
            }
            else if (propInfo.PropertyType.FullName.StartsWith("System.Collections.Generic.ICollection"))
            {
                csspProp.IsCollection = true;

                string typeTxt = propInfo.PropertyType.FullName;
                typeTxt = typeTxt.Substring(typeTxt.IndexOf("[") + 2);
                typeTxt = typeTxt.Substring(typeTxt.IndexOf(".") + 1);
                typeTxt = typeTxt.Substring(0, typeTxt.IndexOf(","));

                csspProp.PropType = typeTxt;
            }
            else if (propInfo.PropertyType.FullName.StartsWith("System.Collections.Generic.List"))
            {
                csspProp.IsList = true;

                string typeTxt = propInfo.PropertyType.FullName;
                typeTxt = typeTxt.Substring(typeTxt.IndexOf("[") + 2);
                typeTxt = typeTxt.Substring(typeTxt.IndexOf(".") + 1);
                typeTxt = typeTxt.Substring(0, typeTxt.IndexOf(","));

                csspProp.PropType = typeTxt;
            }
            else if (propInfo.PropertyType.FullName.StartsWith("System.Linq.IQueryable"))
            {
                csspProp.IsIQueryable = true;

                string typeTxt = propInfo.PropertyType.FullName;
                typeTxt = typeTxt.Substring(typeTxt.IndexOf("[") + 2);
                typeTxt = typeTxt.Substring(typeTxt.IndexOf(".") + 1);
                typeTxt = typeTxt.Substring(0, typeTxt.IndexOf(","));

                csspProp.PropType = typeTxt;
            }
            else
            {
                csspProp.PropType = propInfo.PropertyType.Name.ToString();
            }

            csspProp.IsKey = propInfo.CustomAttributes.Where(c => c.AttributeType.Name == "KeyAttribute").Any();

            if (propInfo.CustomAttributes.Where(c => c.AttributeType.Name == "DataTypeAttribute").Any())
            {
                csspProp.HasDataTypeAttribute = true;

                CustomAttributeData customAttributeData = propInfo.CustomAttributes.Where(c => c.AttributeType.Name == "DataTypeAttribute").First();
                DataType dataType = (DataType)customAttributeData.ConstructorArguments[0].Value;
                switch (dataType)
                {
                    case DataType.Custom:
                    case DataType.DateTime:
                    case DataType.Date:
                    case DataType.Time:
                    case DataType.Duration:
                    case DataType.PhoneNumber:
                    case DataType.Currency:
                    case DataType.Text:
                    case DataType.Html:
                    case DataType.MultilineText:
                        {
                            Console.WriteLine($"DataType [{ dataType.ToString() }] Not Implemented Yet");
                            return false;
                        }
                    case DataType.EmailAddress:
                        {
                            csspProp.dataType = (DataType)customAttributeData.ConstructorArguments[0].Value;
                            csspProp.HasDataTypeAttribute = true;
                        }
                        break;
                    case DataType.Password:
                    case DataType.Url:
                    case DataType.ImageUrl:
                    case DataType.CreditCard:
                    case DataType.PostalCode:
                    case DataType.Upload:
                        {
                            Console.WriteLine($"DataType [{ dataType.ToString() }] Not Implemented Yet");
                            return false;
                        }
                    default:
                        break;
                }
            }

            if (propInfo.CustomAttributes.Where(c => c.AttributeType.Name == "CSSPMaxLengthAttribute").Any())
            {
                csspProp.HasCSSPMaxLengthAttribute = true;

                if (propInfo.PropertyType != typeof(String))
                {
                    Console.WriteLine($"Class [{ type.FullName }] { propInfo.Name } Should not contain the string length attribute. String length attribute can only be set for system.string");
                    return false;
                }
                CustomAttributeData customAttributeData = propInfo.CustomAttributes.Where(c => c.AttributeType.Name == "CSSPMaxLengthAttribute").First();
                csspProp.Max = (int)customAttributeData.ConstructorArguments.ToArray()[0].Value;
            }

            if (propInfo.CustomAttributes.Where(c => c.AttributeType.Name == "CSSPMinLengthAttribute").Any())
            {
                csspProp.HasCSSPMinLengthAttribute = true;

                if (propInfo.PropertyType != typeof(String))
                {
                    Console.WriteLine($"Class [{ type.FullName }] { propInfo.Name } Should not contain the string length attribute. String length attribute can only be set for system.string");
                    return false;
                }
                CustomAttributeData customAttributeData = propInfo.CustomAttributes.Where(c => c.AttributeType.Name == "CSSPMinLengthAttribute").First();
                csspProp.Min = (int)customAttributeData.ConstructorArguments.ToArray()[0].Value;
            }

            if (propInfo.CustomAttributes.Where(c => c.AttributeType.Name == "CSSPRangeAttribute").Any())
            {
                csspProp.HasCSSPRangeAttribute = true;

                CustomAttributeData customAttributeData = propInfo.CustomAttributes.Where(c => c.AttributeType.Name == "CSSPRangeAttribute").First();
                if (csspProp.PropType == "Int16" || csspProp.PropType == "Int32" || csspProp.PropType == "Int64")
                {
                    csspProp.Min = (int)customAttributeData.ConstructorArguments.ToArray()[0].Value;
                    csspProp.Max = (int)customAttributeData.ConstructorArguments.ToArray()[1].Value;

                    if (csspProp.Min > csspProp.Max && csspProp.Max == -1)
                    {
                        csspProp.Max = null;
                    }
                }
                else if (csspProp.PropType == "Single" || csspProp.PropType == "Double")
                {
                    csspProp.Min = (double)customAttributeData.ConstructorArguments.ToArray()[0].Value;
                    csspProp.Max = (double)customAttributeData.ConstructorArguments.ToArray()[1].Value;

                    if (csspProp.Min > csspProp.Max && csspProp.Max == -1)
                    {
                        csspProp.Max = null;
                    }
                }
                else
                {
                    Console.WriteLine($"Type [{ type.FullName }] Property [{ csspProp.PropName }] of type [{ csspProp.PropType }] should not use range attribute. only types Int, Single, Double can use range attribute");
                    return false;
                }
            }

            if (propInfo.CustomAttributes.Where(c => c.AttributeType.Name == "CSSPCompareAttribute").Any())
            {
                csspProp.HasCSSPCompareAttribute = true;

                CustomAttributeData customAttributeData = propInfo.CustomAttributes.Where(c => c.AttributeType.Name == "CSSPCompareAttribute").First();
                csspProp.Compare = (string)customAttributeData.ConstructorArguments.ToArray()[0].Value;
            }

            if (propInfo.CustomAttributes.Where(c => c.AttributeType.Name == "CSSPBiggerAttribute").Any())
            {
                csspProp.HasCSSPBiggerAttribute = true;

                CustomAttributeData customAttributeData = propInfo.CustomAttributes.Where(c => c.AttributeType.Name == "CSSPBiggerAttribute").First();
                for (int i = 0, count = customAttributeData.NamedArguments.ToArray().Count(); i < count; i++)
                {
                    if (customAttributeData.NamedArguments.ToArray()[i].MemberName == "OtherField")
                    {
                        csspProp.OtherField = (string)customAttributeData.NamedArguments.ToArray()[i].TypedValue.Value;
                    }
                }
            }

            if (propInfo.CustomAttributes.Where(c => c.AttributeType.Name == "CSSPAfterAttribute").Any())
            {
                csspProp.HasCSSPAfterAttribute = true;

                if (csspProp.PropType != "DateTime")
                {
                    Console.WriteLine($"Property [{ csspProp.PropName }] of type [{ csspProp.PropType }] CSSPAfter attribute should only be used for DateTime type ");
                    return false;
                }
                CustomAttributeData customAttributeData = propInfo.CustomAttributes.Where(c => c.AttributeType.Name == "CSSPAfterAttribute").First();
                for (int i = 0, count = customAttributeData.NamedArguments.ToArray().Count(); i < count; i++)
                {
                    if (customAttributeData.NamedArguments.ToArray()[i].MemberName == "Year")
                    {
                        csspProp.Year = (int)customAttributeData.NamedArguments.ToArray()[i].TypedValue.Value;
                    }
                }
            }

            if (propInfo.CustomAttributes.Where(c => c.AttributeType.Name == "CSSPExistAttribute").Any())
            {
                csspProp.HasCSSPExistAttribute = true;
                CustomAttributeData customAttributeData = propInfo.CustomAttributes.Where(c => c.AttributeType.Name == "CSSPExistAttribute").First();
                for (int i = 0, count = customAttributeData.NamedArguments.ToArray().Count(); i < count; i++)
                {
                    switch (customAttributeData.NamedArguments.ToArray()[i].MemberName)
                    {
                        case "ExistTypeName":
                            {
                                csspProp.ExistTypeName = (string)customAttributeData.NamedArguments.ToArray()[i].TypedValue.Value;
                            }
                            break;
                        case "ExistPlurial":
                            {
                                csspProp.ExistPlurial = (string)customAttributeData.NamedArguments.ToArray()[i].TypedValue.Value;
                            }
                            break;
                        case "ExistFieldID":
                            {
                                csspProp.ExistFieldID = (string)customAttributeData.NamedArguments.ToArray()[i].TypedValue.Value;
                            }
                            break;
                        case "AllowableTVTypeList":
                            {
                                csspProp.AllowableTVTypeList = new List<TVTypeEnum>();

                                string tvTypes = (string)customAttributeData.NamedArguments.ToArray()[i].TypedValue.Value;
                                foreach (string TVType in tvTypes.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList())
                                {
                                    csspProp.AllowableTVTypeList.Add((TVTypeEnum)int.Parse(TVType));
                                }
                            }
                            break;
                        default:
                            Console.WriteLine($"Property [{ csspProp.PropName }] of type [{ csspProp.PropType }] --- Member name  { customAttributeData.NamedArguments.ToArray()[i].MemberName } does not exist for CSSPExistAttribute");
                            return false;
                    }
                }
            }

            if (propInfo.CustomAttributes.Where(c => c.AttributeType.Name == "CSSPFillAttribute").Any())
            {
                csspProp.HasCSSPFillAttribute = true;
                CustomAttributeData customAttributeData = propInfo.CustomAttributes.Where(c => c.AttributeType.Name == "CSSPFillAttribute").First();
                for (int i = 0, count = customAttributeData.NamedArguments.ToArray().Count(); i < count; i++)
                {
                    switch (customAttributeData.NamedArguments.ToArray()[i].MemberName)
                    {
                        case "FillTypeName":
                            {
                                csspProp.FillTypeName = (string)customAttributeData.NamedArguments.ToArray()[i].TypedValue.Value;
                            }
                            break;
                        case "FillPlurial":
                            {
                                csspProp.FillPlurial = (string)customAttributeData.NamedArguments.ToArray()[i].TypedValue.Value;
                            }
                            break;
                        case "FillFieldID":
                            {
                                csspProp.FillFieldID = (string)customAttributeData.NamedArguments.ToArray()[i].TypedValue.Value;
                            }
                            break;
                        case "FillEqualField":
                            {
                                csspProp.FillEqualField = (string)customAttributeData.NamedArguments.ToArray()[i].TypedValue.Value;
                            }
                            break;
                        case "FillReturnField":
                            {
                                csspProp.FillReturnField = (string)customAttributeData.NamedArguments.ToArray()[i].TypedValue.Value;
                            }
                            break;
                        case "FillNeedLanguage":
                            {
                                csspProp.FillNeedLanguage = (bool)customAttributeData.NamedArguments.ToArray()[i].TypedValue.Value;
                            }
                            break;
                        case "FillIsList":
                            {
                                csspProp.FillIsList = (bool)customAttributeData.NamedArguments.ToArray()[i].TypedValue.Value;
                            }
                            break;
                        default:
                            Console.WriteLine($"Property [{ csspProp.PropName }] of type [{ csspProp.PropType }] --- Member name  { customAttributeData.NamedArguments.ToArray()[i].MemberName } does not exist for CSSPFillAttribute");
                            return false;
                    }
                }
            }

            if (propInfo.CustomAttributes.Where(c => c.AttributeType.Name == "CSSPForeignKeyAttribute").Any())
            {
                csspProp.HasCSSPForeignKeyAttribute = true;
                CustomAttributeData customAttributeData = propInfo.CustomAttributes.Where(c => c.AttributeType.Name == "CSSPForeignKeyAttribute").First();
                for (int i = 0, count = customAttributeData.NamedArguments.ToArray().Count(); i < count; i++)
                {
                    switch (customAttributeData.NamedArguments.ToArray()[i].MemberName)
                    {
                        case "TableName":
                            {
                                csspProp.TableName = (string)customAttributeData.NamedArguments.ToArray()[i].TypedValue.Value;
                            }
                            break;
                        case "FieldName":
                            {
                                csspProp.FieldName = (string)customAttributeData.NamedArguments.ToArray()[i].TypedValue.Value;
                            }
                            break;
                        default:
                            Console.WriteLine($"Property [{ csspProp.PropName }] of type [{ csspProp.PropType }] --- Member name  { customAttributeData.NamedArguments.ToArray()[i].MemberName } does not exist for CSSPFillAttribute");
                            return false;
                    }
                }
            }

            if (propInfo.CustomAttributes.Where(c => c.AttributeType.Name == "CSSPEnumTypeTextAttribute").Any())
            {
                csspProp.HasCSSPEnumTypeTextAttribute = true;
                CustomAttributeData customAttributeData = propInfo.CustomAttributes.Where(c => c.AttributeType.Name == "CSSPEnumTypeTextAttribute").First();
                for (int i = 0, count = customAttributeData.NamedArguments.ToArray().Count(); i < count; i++)
                {
                    switch (customAttributeData.NamedArguments.ToArray()[i].MemberName)
                    {
                        case "EnumTypeName":
                            {
                                csspProp.EnumTypeName = (string)customAttributeData.NamedArguments.ToArray()[i].TypedValue.Value;
                            }
                            break;
                        case "EnumType":
                            {
                                csspProp.EnumType = (string)customAttributeData.NamedArguments.ToArray()[i].TypedValue.Value;
                            }
                            break;
                        default:
                            Console.WriteLine($"Property [{ csspProp.PropName }] of type [{ csspProp.PropType }] --- Member name  { customAttributeData.NamedArguments.ToArray()[i].MemberName } does not exist for CSSPEnumTypeTextAttribute");
                            return false;
                    }
                }
            }

            csspProp.IsVirtual = propInfo.GetGetMethod().IsVirtual;

            csspProp.HasCSSPEnumTypeAttribute = propInfo.CustomAttributes.Where(c => c.AttributeType.Name.StartsWith("CSSPEnumTypeAttribute")).Any();
            csspProp.HasNotMappedAttribute = propInfo.CustomAttributes.Where(c => c.AttributeType.Name == "NotMappedAttribute").Any();

            return true;
        }
    }
}
