using CSSPEnums;
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
    public class GenerateCodeBase
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
        public virtual void CSSPErrorEvent(CSSPErrorEventArgs e)
        {
            CSSPErrorHandler?.Invoke(this, e);
        }
        public event EventHandler<CSSPErrorEventArgs> CSSPErrorHandler;
        public virtual void StatusTempEvent(StatusEventArgs e)
        {
            StatusTempHandler?.Invoke(this, e);
        }
        public event EventHandler<StatusEventArgs> StatusTempHandler;
        public virtual void StatusPermanentEvent(StatusEventArgs e)
        {
            StatusPermanentHandler?.Invoke(this, e);
        }
        public event EventHandler<StatusEventArgs> StatusPermanentHandler;
        public virtual void StatusPermanent2Event(StatusEventArgs e)
        {
            StatusPermanent2Handler?.Invoke(this, e);
        }
        public event EventHandler<StatusEventArgs> StatusPermanent2Handler;
        public virtual void ClearPermanentEvent(StatusEventArgs e)
        {
            ClearPermanentHandler?.Invoke(this, e);
        }
        public event EventHandler<StatusEventArgs> ClearPermanentHandler;
        public virtual void ClearPermanent2Event(StatusEventArgs e)
        {
            ClearPermanent2Handler?.Invoke(this, e);
        }
        public event EventHandler<StatusEventArgs> ClearPermanent2Handler;
        #endregion Events

        #region Functions public
        public bool FillCSSPProp(PropertyInfo propInfo, CSSPProp csspProp, Type type)
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
        public bool FillDLLTypeInfoList(FileInfo fiDLL, List<DLLTypeInfo> DLLTypeInfoList)
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
                        StatusTempEvent(new StatusEventArgs($"Reading type file [{ fiDLL.Name }] [{ type.Name }] [{ propertyInfo.Name }]"));
                    }

                    DLLPropertyInfo dllPropertyInfo = new DLLPropertyInfo();
                    dllPropertyInfo.PropertyInfo = propertyInfo;

                    CSSPProp csspProp = new CSSPProp();
                    if (!FillCSSPProp(propertyInfo, csspProp, type))
                    {
                        CSSPErrorEvent(new CSSPErrorEventArgs("CSSPError while filling CSSPProp"));
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
                        StatusTempEvent(new StatusEventArgs($"Reading type file [{ fiDLL.Name }] [{ type.Name }] [{ methodInfo.Name }]"));
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
        public bool SkipType(Type type)
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

        #region Sub Classes
        public class CSSPErrorEventArgs : EventArgs
        {
            public CSSPErrorEventArgs(string CSSPError)
            {
                this.CSSPError = CSSPError;
            }

            public string CSSPError { get; set; }
        }
        public class StatusEventArgs : EventArgs
        {
            public StatusEventArgs(string Status)
            {
                this.Status = Status;
            }

            public string Status { get; set; }
        }
        public class EnumsFiles
        {
            public EnumsFiles()
            {
                CSSPEnumsDLL = "";
                BaseDir = "";
                EnumsGenerated = "";
                EnumsTestGenerated = "";
            }

            public string CSSPEnumsDLL { get; set; }
            public string BaseDir { get; set; }
            public string EnumsGenerated { get; set; }
            public string EnumsTestGenerated { get; set; }
        }
        public class DLLTypeInfo
        {
            public DLLTypeInfo()
            {
                FieldInfoList = new List<DLLFieldInfo>();
                PropertyInfoList = new List<DLLPropertyInfo>();
                MethodInfoList = new List<DLLMethodInfo>();
            }

            public Type Type { get; set; }
            public string Name { get; set; }
            public bool IsEnum { get; set; }
            public bool IsPublic { get; set; }
            public bool HasNotMappedAttribute { get; set; }
            public List<DLLFieldInfo> FieldInfoList { get; set; }
            public List<DLLPropertyInfo> PropertyInfoList { get; set; }
            public List<DLLMethodInfo> MethodInfoList { get; set; }
        }
        public class DLLFieldInfo
        {
            public DLLFieldInfo()
            {

            }

            public FieldInfo FieldInfo { get; set; }
            public string Name { get; set; }
        }
        public class DLLPropertyInfo
        {
            public DLLPropertyInfo()
            {

            }

            public PropertyInfo PropertyInfo { get; set; }
            public CSSPProp CSSPProp { get; set; }
            //public string Name { get; set; }
            //public Type PropertyType { get; set; }
            //public string PropertyTypeName { get; set; }
        }
        public class DLLMethodInfo
        {
            public DLLMethodInfo()
            {
                ParameterInfoList = new List<DLLParameterInfo>();
            }

            public MethodInfo MethodInfo { get; set; }
            public string Name { get; set; }
            public Type DeclaringType { get; set; }
            public string DeclaringTypeName { get; set; }
            public List<DLLParameterInfo> ParameterInfoList { get; set; }
        }
        public class DLLParameterInfo
        {
            public DLLParameterInfo()
            {

            }

            public ParameterInfo ParameterInfo { get; set; }
            public string Name { get; set; }
        }
        public class TypeProp
        {
            public TypeProp()
            {
                csspPropList = new List<CSSPProp>();
            }

            public Type type { get; set; }
            public string Plurial { get; set; }
            public List<CSSPProp> csspPropList { get; set; }
        }
        public class Table
        {
            public Table()
            {
                colList = new List<Col>();
            }
            public string TableName { get; set; }

            public List<Col> colList { get; set; }
            public int ordinalToDelete { get; set; }
        }
        public class Col
        {
            public string FieldName { get; set; }
            public bool AllowNull { get; set; }
            public string DataType { get; set; }
            public int StringLength { get; set; }
        }
        public class TableFieldEnumException
        {
            public string TableName { get; set; }
            public string FieldName { get; set; }
            public string EnumText { get; set; }
        }
        public class TableFieldEmail
        {
            public string TableName { get; set; }
            public string FieldName { get; set; }
        }
        public class TableFieldIDException
        {
            public string TableName { get; set; }
            public string FieldName { get; set; }
        }
        public class CSSPProp
        {
            public CSSPProp()
            {
                CSSPError = "";
                PropName = "";
                PropType = "";
                IsNullable = false;
                IsKey = false;
                Min = null;
                Max = null;
                OtherField = "";
                Year = null;
                Compare = "";
                ExistTypeName = "";
                ExistPlurial = "";
                ExistFieldID = "";
                dataType = DataType.Custom;
                IsVirtual = false;
                HasNotMappedAttribute = false;
                HasCSSPAfterAttribute = false;
                HasCSSPAllowNullAttribute = false;
                HasCSSPBiggerAttribute = false;
                HasCSSPEnumTypeAttribute = false;
                HasCSSPExistAttribute = false;
                HasCSSPFillAttribute = false;
                HasStringLengthAttribute = false;
                HasRangeAttribute = false;
                HasCompareAttribute = false;
                HasDataTypeAttribute = false;
                AllowableTVTypeList = new List<TVTypeEnum>();
                IsCollection = false;
                IsList = false;
                IsIQueryable = false;
                FillTypeName = "";
                FillPlurial = "";
                FillFieldID = "";
                FillEqualField = "";
                FillReturnField = "";
                HasCSSPEnumTypeTextAttribute = false;
                EnumTypeName = "";
                EnumType = "";
                FillNeedLanguage = false;
                FillIsList = false;
                HasCSSPDescriptionENAttribute = false;
                HasCSSPDescriptionFRAttribute = false;
                HasCSSPDisplayENAttribute = false;
                HasCSSPDisplayFRAttribute = false;
                DescriptionEN = "";
                DescriptionFR = "";
                DisplayEN = "";
                DisplayFR = "";
            }
            public string CSSPError { get; set; }
            public string PropName { get; set; }
            public string PropType { get; set; }
            public bool IsNullable { get; set; }
            public bool IsKey { get; set; }
            public double? Min { get; set; }
            public double? Max { get; set; }
            public string OtherField { get; set; }
            public int? Year { get; set; }
            public string Compare { get; set; }
            public string ExistTypeName { get; set; }
            public string ExistPlurial { get; set; }
            public string ExistFieldID { get; set; }
            public DataType dataType { get; set; }
            public bool IsVirtual { get; set; }
            public bool HasNotMappedAttribute { get; set; }
            public bool HasCSSPAfterAttribute { get; set; }
            public bool HasCSSPAllowNullAttribute { get; set; }
            public bool HasCSSPBiggerAttribute { get; set; }
            public bool HasCSSPEnumTypeAttribute { get; set; }
            public bool HasCSSPExistAttribute { get; set; }
            public bool HasCSSPFillAttribute { get; set; }
            public bool HasStringLengthAttribute { get; set; }
            public bool HasRangeAttribute { get; set; }
            public bool HasCompareAttribute { get; set; }
            public bool HasDataTypeAttribute { get; set; }
            public List<TVTypeEnum> AllowableTVTypeList { get; set; }
            public bool IsCollection { get; set; }
            public bool IsList { get; set; }
            public bool IsIQueryable { get; set; }
            public string FillTypeName { get; set; }
            public string FillPlurial { get; set; }
            public string FillFieldID { get; set; }
            public string FillEqualField { get; set; }
            public string FillReturnField { get; set; }
            public bool HasCSSPEnumTypeTextAttribute { get; set; }
            public string EnumTypeName { get; set; }
            public string EnumType { get; set; }
            public bool FillNeedLanguage { get; set; }
            public bool FillIsList { get; set; }
            public bool HasCSSPDescriptionENAttribute { get; set; }
            public bool HasCSSPDescriptionFRAttribute { get; set; }
            public bool HasCSSPDisplayENAttribute { get; set; }
            public bool HasCSSPDisplayFRAttribute { get; set; }
            public string DescriptionEN { get; set; }
            public string DescriptionFR { get; set; }
            public string DisplayEN { get; set; }
            public string DisplayFR { get; set; }
        }

        #endregion Sub Classes
    }
}