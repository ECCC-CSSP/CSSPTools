using CSSPEnums;
using CSSPGenerateCodeBase.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSSPGenerateCodeBase
{
    public partial class GenerateCodeBase : IGenerateCodeBase
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public GenerateCodeBase()
        {

        }
        #endregion Constructors

        #region Events
        #endregion Events

        #region Functions public
        public async Task<bool> FillCSSPProp(PropertyInfo propInfo, CSSPProp csspProp, Type type)
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
                DataType dataType = ((DataType)customAttributeData.ConstructorArguments[0].Value);
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
                            csspProp.CSSPError = $"DataType [{ dataType.ToString() }] is not implemented yet.";
                            return false;
                        }
                    case DataType.EmailAddress:
                        {
                            csspProp.dataType = ((DataType)customAttributeData.ConstructorArguments[0].Value);
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
                            csspProp.CSSPError = $"DataType [{ dataType.ToString() }] is not implemented yet.";
                            return false;
                        }
                    default:
                        break;
                }
            }

            if (propInfo.CustomAttributes.Where(c => c.AttributeType.Name == "StringLengthAttribute").Any())
            {
                csspProp.HasStringLengthAttribute = true;

                if (propInfo.PropertyType != typeof(System.String))
                {
                    csspProp.CSSPError = $"Class [{ type.FullName }] { propInfo.Name } should not contain the StringLength Attribute. StringLength Attribute can only be set for System.String";
                    return false;
                }
                CustomAttributeData customAttributeData = propInfo.CustomAttributes.Where(c => c.AttributeType.Name == "StringLengthAttribute").First();
                csspProp.Max = ((int)customAttributeData.ConstructorArguments.ToArray()[0].Value);
                if (customAttributeData.NamedArguments.ToArray().Count() > 0)
                {
                    for (int i = 0, count = customAttributeData.NamedArguments.ToArray().Count(); i < count; i++)
                    {
                        if (customAttributeData.NamedArguments.ToArray()[i].MemberName == "MinimumLength")
                        {
                            csspProp.Min = ((int)customAttributeData.NamedArguments.ToArray()[i].TypedValue.Value);
                        }
                    }
                }
            }

            if (propInfo.CustomAttributes.Where(c => c.AttributeType.Name == "RangeAttribute").Any())
            {
                csspProp.HasRangeAttribute = true;

                CustomAttributeData customAttributeData = propInfo.CustomAttributes.Where(c => c.AttributeType.Name == "RangeAttribute").First();
                if (csspProp.PropType == "Int16" || csspProp.PropType == "Int32" || csspProp.PropType == "Int64")
                {
                    csspProp.Min = ((int)customAttributeData.ConstructorArguments.ToArray()[0].Value);
                    csspProp.Max = ((int)customAttributeData.ConstructorArguments.ToArray()[1].Value);

                    if (csspProp.Min > csspProp.Max && csspProp.Max == -1)
                    {
                        csspProp.Max = null;
                    }
                }
                else if (csspProp.PropType == "Single" || csspProp.PropType == "Double")
                {
                    csspProp.Min = ((double)customAttributeData.ConstructorArguments.ToArray()[0].Value);
                    csspProp.Max = ((double)customAttributeData.ConstructorArguments.ToArray()[1].Value);

                    if (csspProp.Min > csspProp.Max && csspProp.Max == -1)
                    {
                        csspProp.Max = null;
                    }
                }
                else
                {
                    csspProp.CSSPError = $"Type [{ type.FullName }] Property [{ csspProp.PropName }] of type [{ csspProp.PropType }] should not use RangeAttribute. Only types [Int,Single,Double] can use RangeAttributre";
                    return false;
                }
            }

            if (propInfo.CustomAttributes.Where(c => c.AttributeType.Name == "CompareAttribute").Any())
            {
                csspProp.HasCompareAttribute = true;

                CustomAttributeData customAttributeData = propInfo.CustomAttributes.Where(c => c.AttributeType.Name == "CompareAttribute").First();
                csspProp.Compare = ((string)customAttributeData.ConstructorArguments.ToArray()[0].Value);
            }

            if (propInfo.CustomAttributes.Where(c => c.AttributeType.Name == "CSSPBiggerAttribute").Any())
            {
                csspProp.HasCSSPBiggerAttribute = true;

                CustomAttributeData customAttributeData = propInfo.CustomAttributes.Where(c => c.AttributeType.Name == "CSSPBiggerAttribute").First();
                for (int i = 0, count = customAttributeData.NamedArguments.ToArray().Count(); i < count; i++)
                {
                    if (customAttributeData.NamedArguments.ToArray()[i].MemberName == "OtherField")
                    {
                        csspProp.OtherField = ((string)customAttributeData.NamedArguments.ToArray()[i].TypedValue.Value);
                    }
                }
            }

            if (propInfo.CustomAttributes.Where(c => c.AttributeType.Name == "CSSPAfterAttribute").Any())
            {
                csspProp.HasCSSPAfterAttribute = true;

                if (csspProp.PropType != "DateTime")
                {
                    csspProp.CSSPError = $"Property [{ csspProp.PropName }] of type [{ csspProp.PropType }] CSSPAfterAttribute should only be user for DateTime Type";
                    return false;
                }
                CustomAttributeData customAttributeData = propInfo.CustomAttributes.Where(c => c.AttributeType.Name == "CSSPAfterAttribute").First();
                for (int i = 0, count = customAttributeData.NamedArguments.ToArray().Count(); i < count; i++)
                {
                    if (customAttributeData.NamedArguments.ToArray()[i].MemberName == "Year")
                    {
                        csspProp.Year = ((int)customAttributeData.NamedArguments.ToArray()[i].TypedValue.Value);
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
                                csspProp.ExistTypeName = ((string)customAttributeData.NamedArguments.ToArray()[i].TypedValue.Value);
                            }
                            break;
                        case "ExistPlurial":
                            {
                                csspProp.ExistPlurial = ((string)customAttributeData.NamedArguments.ToArray()[i].TypedValue.Value);
                            }
                            break;
                        case "ExistFieldID":
                            {
                                csspProp.ExistFieldID = ((string)customAttributeData.NamedArguments.ToArray()[i].TypedValue.Value);
                            }
                            break;
                        case "AllowableTVTypeList":
                            {
                                csspProp.AllowableTVTypeList = new List<TVTypeEnum>();

                                string tvTypes = (string)customAttributeData.NamedArguments.ToArray()[i].TypedValue.Value;
                                foreach (string TVType in tvTypes.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList())
                                {
                                    csspProp.AllowableTVTypeList.Add(((TVTypeEnum)int.Parse(TVType)));
                                }
                            }
                            break;
                        default:
                            csspProp.CSSPError = $"Property [{ csspProp.PropName }] of type [{ csspProp.PropType }] --- member name { customAttributeData.NamedArguments.ToArray()[i].MemberName } does not exist for CSSPExistAttribute";
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
                                csspProp.FillTypeName = ((string)customAttributeData.NamedArguments.ToArray()[i].TypedValue.Value);
                            }
                            break;
                        case "FillPlurial":
                            {
                                csspProp.FillPlurial = ((string)customAttributeData.NamedArguments.ToArray()[i].TypedValue.Value);
                            }
                            break;
                        case "FillFieldID":
                            {
                                csspProp.FillFieldID = ((string)customAttributeData.NamedArguments.ToArray()[i].TypedValue.Value);
                            }
                            break;
                        case "FillEqualField":
                            {
                                csspProp.FillEqualField = ((string)customAttributeData.NamedArguments.ToArray()[i].TypedValue.Value);
                            }
                            break;
                        case "FillReturnField":
                            {
                                csspProp.FillReturnField = ((string)customAttributeData.NamedArguments.ToArray()[i].TypedValue.Value);
                            }
                            break;
                        case "FillNeedLanguage":
                            {
                                csspProp.FillNeedLanguage = ((bool)customAttributeData.NamedArguments.ToArray()[i].TypedValue.Value);
                            }
                            break;
                        case "FillIsList":
                            {
                                csspProp.FillIsList = ((bool)customAttributeData.NamedArguments.ToArray()[i].TypedValue.Value);
                            }
                            break;
                        default:
                            csspProp.CSSPError = $"Property [{ csspProp.PropName }] of type [{ csspProp.PropType }] --- member name { customAttributeData.NamedArguments.ToArray()[i].MemberName } does not exist for CSSPExistAttribute";
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
                                csspProp.EnumTypeName = ((string)customAttributeData.NamedArguments.ToArray()[i].TypedValue.Value);
                            }
                            break;
                        case "EnumType":
                            {
                                csspProp.EnumType = ((string)customAttributeData.NamedArguments.ToArray()[i].TypedValue.Value);
                            }
                            break;
                        default:
                            csspProp.CSSPError = $"Property [{ csspProp.PropName }] of type [{ csspProp.PropType }] --- member name { customAttributeData.NamedArguments.ToArray()[i].MemberName } does not exist for CSSPExistAttribute";
                            return false;
                    }
                }
            }

            csspProp.IsVirtual = propInfo.GetGetMethod().IsVirtual;

            csspProp.HasCSSPEnumTypeAttribute = propInfo.CustomAttributes.Where(c => c.AttributeType.Name.StartsWith("CSSPEnumTypeAttribute")).Any();
            csspProp.HasNotMappedAttribute = propInfo.CustomAttributes.Where(c => c.AttributeType.Name == "NotMappedAttribute").Any();


            if (propInfo.CustomAttributes.Where(c => c.AttributeType.Name == "CSSPDescriptionENAttribute").Any())
            {
                csspProp.HasCSSPDescriptionENAttribute = true;
                CustomAttributeData customAttributeData = propInfo.CustomAttributes.Where(c => c.AttributeType.Name == "CSSPDescriptionENAttribute").First();
                for (int i = 0, count = customAttributeData.NamedArguments.ToArray().Count(); i < count; i++)
                {
                    switch (customAttributeData.NamedArguments.ToArray()[i].MemberName)
                    {
                        case "DescriptionEN":
                            {
                                csspProp.DescriptionEN = ((string)customAttributeData.NamedArguments.ToArray()[i].TypedValue.Value);
                            }
                            break;
                        default:
                            csspProp.CSSPError = $"Property [{ csspProp.PropName }] of type [{ csspProp.PropType }] --- member name { customAttributeData.NamedArguments.ToArray()[i].MemberName } does not exist for CSSPExistAttribute";
                            return false;
                    }
                }
            }

            if (propInfo.CustomAttributes.Where(c => c.AttributeType.Name == "CSSPDescriptionFRAttribute").Any())
            {
                csspProp.HasCSSPDescriptionFRAttribute = true;
                CustomAttributeData customAttributeData = propInfo.CustomAttributes.Where(c => c.AttributeType.Name == "CSSPDescriptionFRAttribute").First();
                for (int i = 0, count = customAttributeData.NamedArguments.ToArray().Count(); i < count; i++)
                {
                    switch (customAttributeData.NamedArguments.ToArray()[i].MemberName)
                    {
                        case "DescriptionFR":
                            {
                                csspProp.DescriptionFR = ((string)customAttributeData.NamedArguments.ToArray()[i].TypedValue.Value);
                            }
                            break;
                        default:
                            csspProp.CSSPError = $"Property [{ csspProp.PropName }] of type [{ csspProp.PropType }] --- member name { customAttributeData.NamedArguments.ToArray()[i].MemberName } does not exist for CSSPExistAttribute";
                            return false;
                    }
                }
            }

            if (propInfo.CustomAttributes.Where(c => c.AttributeType.Name == "CSSPDisplayENAttribute").Any())
            {
                csspProp.HasCSSPDisplayENAttribute = true;
                CustomAttributeData customAttributeData = propInfo.CustomAttributes.Where(c => c.AttributeType.Name == "CSSPDisplayENAttribute").First();
                for (int i = 0, count = customAttributeData.NamedArguments.ToArray().Count(); i < count; i++)
                {
                    switch (customAttributeData.NamedArguments.ToArray()[i].MemberName)
                    {
                        case "DisplayEN":
                            {
                                csspProp.DisplayEN = ((string)customAttributeData.NamedArguments.ToArray()[i].TypedValue.Value);
                            }
                            break;
                        default:
                            csspProp.CSSPError = $"Property [{ csspProp.PropName }] of type [{ csspProp.PropType }] --- member name { customAttributeData.NamedArguments.ToArray()[i].MemberName } does not exist for CSSPExistAttribute";
                            return false;
                    }
                }
            }

            if (propInfo.CustomAttributes.Where(c => c.AttributeType.Name == "CSSPDisplayFRAttribute").Any())
            {
                csspProp.HasCSSPDisplayFRAttribute = true;
                CustomAttributeData customAttributeData = propInfo.CustomAttributes.Where(c => c.AttributeType.Name == "CSSPDisplayFRAttribute").First();
                for (int i = 0, count = customAttributeData.NamedArguments.ToArray().Count(); i < count; i++)
                {
                    switch (customAttributeData.NamedArguments.ToArray()[i].MemberName)
                    {
                        case "DisplayFR":
                            {
                                csspProp.DisplayFR = ((string)customAttributeData.NamedArguments.ToArray()[i].TypedValue.Value);
                            }
                            break;
                        default:
                            csspProp.CSSPError = $"Property [{ csspProp.PropName }] of type [{ csspProp.PropType }] --- member name { customAttributeData.NamedArguments.ToArray()[i].MemberName } does not exist for CSSPExistAttribute";
                            return false;
                    }
                }
            }

            return true;
        }
        public async Task<bool> FillDLLTypeInfoList(FileInfo fiDLL, List<DLLTypeInfo> DLLTypeInfoList)
        {
            var importAssembly = Assembly.LoadFile(fiDLL.FullName);
            List<Type> typeList = importAssembly.GetTypes().ToList();

            int count = 0;
            foreach (Type type in typeList)
            {
                if (type.Name.StartsWith("<") || type.FullName.StartsWith("CSSPWebAPI.Models"))
                {
                    continue;
                }

                DLLTypeInfo dllTypeInfo = new DLLTypeInfo();
                dllTypeInfo.Type = type;
                dllTypeInfo.Name = type.Name;
                dllTypeInfo.IsEnum = false;
                if (type.GetTypeInfo().BaseType == typeof(System.Enum))
                {
                    dllTypeInfo.IsEnum = true;
                }

                dllTypeInfo.HasNotMappedAttribute = type.CustomAttributes.Where(c => c.AttributeType.Name == "NotMappedAttribute").Any();

                foreach (FieldInfo fieldInfo in type.GetFields())
                {
                    if (!fieldInfo.FieldType.Name.EndsWith("Enum"))
                    {
                        continue;
                    }

                    DLLFieldInfo dllFieldInfo = new DLLFieldInfo();
                    dllFieldInfo.FieldInfo = fieldInfo;
                    dllFieldInfo.Name = fieldInfo.Name;

                    dllTypeInfo.FieldInfoList.Add(dllFieldInfo);
                }

                foreach (PropertyInfo propertyInfo in type.GetProperties())
                {
                    bool CanReadPropertyType = false;
                    try
                    {
                        var PropertyType = propertyInfo.PropertyType;
                        CanReadPropertyType = true;
                    }
                    catch (Exception)
                    {
                        // not used
                    }
                    if (!CanReadPropertyType)
                    {
                        continue;
                    }
                    if (propertyInfo.PropertyType.Name.StartsWith("<"))
                    {
                        continue;
                    }

                    count += 1;
                    if (count % 200 == 0)
                    {
                        ////////////////////////StatusTempEvent(new StatusEventArgs($"Reading type file [{ fiDLL.Name }] [{ type.Name }] [{ propertyInfo.Name }]"));
                    }

                    DLLPropertyInfo dllPropertyInfo = new DLLPropertyInfo();
                    dllPropertyInfo.PropertyInfo = propertyInfo;

                    CSSPProp csspProp = new CSSPProp();
                    if (! await FillCSSPProp(propertyInfo, csspProp, type))
                    {
                        //////////////CSSPErrorEvent(new CSSPErrorEventArgs("CSSPError while filling CSSPProp"));
                        return false;
                    }
                    dllPropertyInfo.CSSPProp = csspProp;

                    dllTypeInfo.PropertyInfoList.Add(dllPropertyInfo);
                }

                foreach (MethodInfo methodInfo in type.GetMethods())
                {
                    if (methodInfo.Name.StartsWith("<"))
                    {
                        continue;
                    }

                    count += 1;
                    if (count % 200 == 0)
                    {
                        ////////////////////////StatusTempEvent(new StatusEventArgs($"Reading type file [{ fiDLL.Name }] [{ type.Name }] [{ methodInfo.Name }]"));
                    }

                    if (methodInfo.DeclaringType.FullName.StartsWith("CSSP"))
                    {
                        DLLMethodInfo dllMethodInfo = new DLLMethodInfo();
                        dllMethodInfo.MethodInfo = methodInfo;
                        dllMethodInfo.Name = methodInfo.Name;
                        dllMethodInfo.DeclaringType = methodInfo.DeclaringType;

                        string DeclaringTypeName = methodInfo.DeclaringType.FullName;
                        if (DeclaringTypeName.StartsWith("System.Nullable"))
                        {
                            DeclaringTypeName = DeclaringTypeName.Substring(DeclaringTypeName.IndexOf("[[") + 2);
                            DeclaringTypeName = DeclaringTypeName.Substring(DeclaringTypeName.IndexOf(".") + 1);
                            DeclaringTypeName = DeclaringTypeName.Substring(0, DeclaringTypeName.IndexOf(","));
                        }

                        dllMethodInfo.DeclaringTypeName = DeclaringTypeName;

                        try
                        {
                            foreach (ParameterInfo parameterInfo in methodInfo.GetParameters())
                            {
                                DLLParameterInfo dllParameterInfo = new DLLParameterInfo();
                                dllParameterInfo.ParameterInfo = parameterInfo;
                                dllParameterInfo.Name = parameterInfo.Name;

                                dllMethodInfo.ParameterInfoList.Add(dllParameterInfo);
                            }

                        }
                        catch (Exception)
                        {
                            // nothing
                        }

                        dllTypeInfo.MethodInfoList.Add(dllMethodInfo);
                    }
                }

                DLLTypeInfoList.Add(dllTypeInfo);
            }


            return false;
        }
        public async Task<bool> SkipType(Type type)
        {
            if (type.Name.StartsWith("<")
                || type.Name.StartsWith("CSSPModelsRes")
                || type.Name.StartsWith("Application")
                || type.Name.StartsWith("CSSPDBContext")
                || type.Name.StartsWith("CSSPAfter")
                || type.Name.StartsWith("CSSPAllowNull")
                || type.Name.StartsWith("CSSPBigger")
                || type.Name.StartsWith("CSSPEnumType")
                || type.Name.StartsWith("CSSPExist")
                || type.Name.StartsWith("CSSPFill")
                || type.Name.StartsWith("CSSPEnumTypeText")
                || type.Name.StartsWith("CSSPDescriptionENAttribute")
                || type.Name.StartsWith("CSSPDescriptionFRAttribute")
                || type.Name.StartsWith("CSSPDisplayENAttribute")
                || type.Name.StartsWith("CSSPDisplayFRAttribute")
                || type.Name == "CSSPError"
                || type.Name == "LastUpdate"
                || type.Name == "CSSPModelsRes"
                || type.Name == "AspNetUser")
            {
                return true;
            }

            return false;
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private

    }
}
