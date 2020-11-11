using GenerateCodeBaseServices.Models;
using System.Text;
using System.Threading.Tasks;

namespace DBModelsCompareServices.Services
{
    public partial class DBModelsCompareService : IDBModelsCompareService
    {
        private async Task<bool> WriteAttributes(DLLTypeInfo dllTypeInfoModels, DLLPropertyInfo dllPropertyInfo, StringBuilder sb)
        {
            if (dllPropertyInfo.CSSPProp.IsKey)
            {
                sb.AppendLine(@"        [Key]");
            }
            if (dllPropertyInfo.CSSPProp.HasNotMappedAttribute)
            {
                sb.AppendLine(@"        [NotMapped]");
            }
            if (dllPropertyInfo.CSSPProp.HasCSSPExistAttribute)
            {
                string AllowableTVTypeListText = "";
                foreach (CSSPEnums.TVTypeEnum tvType in dllPropertyInfo.CSSPProp.AllowableTVTypeList)
                {
                    AllowableTVTypeListText += $"{ (int)tvType },";
                }

                if (!string.IsNullOrWhiteSpace(AllowableTVTypeListText))
                {
                    AllowableTVTypeListText = AllowableTVTypeListText.Substring(0, AllowableTVTypeListText.Length - 1);
                }
                string AllowableTVTypeListEmptyOrNot = !string.IsNullOrWhiteSpace(AllowableTVTypeListText) ? $@", AllowableTVTypeList = ""{ AllowableTVTypeListText }""" : "";
                sb.AppendLine($@"        [CSSPExist(ExistTypeName = ""{ dllPropertyInfo.CSSPProp.ExistTypeName }"", ExistPlurial = ""{ dllPropertyInfo.CSSPProp.ExistPlurial }"", ExistFieldID = ""{ dllPropertyInfo.CSSPProp.ExistFieldID }""{ AllowableTVTypeListEmptyOrNot })]");
            }
            if (dllPropertyInfo.CSSPProp.HasCSSPMaxLengthAttribute)
            {
                sb.AppendLine($@"        [CSSPMaxLength({ dllPropertyInfo.CSSPProp.Max })]");
            }
            if (dllPropertyInfo.CSSPProp.HasCSSPMinLengthAttribute)
            {
                sb.AppendLine($@"        [CSSPMinLength({ dllPropertyInfo.CSSPProp.Min })]");
            }
            if (dllPropertyInfo.CSSPProp.HasCSSPEnumTypeAttribute)
            {
                sb.AppendLine(@"        [CSSPEnumType]");
            }
            if (dllPropertyInfo.CSSPProp.HasCSSPAfterAttribute)
            {
                sb.AppendLine($@"        [CSSPAfter(Year = { dllPropertyInfo.CSSPProp.Year })]");
            }
            if (dllPropertyInfo.CSSPProp.HasCSSPBiggerAttribute)
            {
                sb.AppendLine($@"        [CSSPBigger(OtherField = ""{ dllPropertyInfo.CSSPProp.OtherField }"")]");
            }
            if (dllPropertyInfo.CSSPProp.HasCSSPFillAttribute)
            {
                string FillNeedLanguage = dllPropertyInfo.CSSPProp.FillNeedLanguage ? "true" : "false";
                string FillIsList = dllPropertyInfo.CSSPProp.FillIsList ? "true" : "false";
                sb.AppendLine($@"        [CSSPFill(FillTypeName = ""{ dllPropertyInfo.CSSPProp.FillTypeName }"", FillPlurial = ""{ dllPropertyInfo.CSSPProp.FillPlurial }"", FillFieldID = ""{ dllPropertyInfo.CSSPProp.FillFieldID }"", FillEqualField = ""{ dllPropertyInfo.CSSPProp.FillEqualField }"", FillReturnField = ""{ dllPropertyInfo.CSSPProp.FillReturnField }"", FillNeedLanguage = { FillNeedLanguage }, FillIsList = { FillIsList })]");
            }
            if (dllPropertyInfo.CSSPProp.HasCSSPEnumTypeTextAttribute)
            {
                sb.AppendLine($@"        [CSSPEnumTypeText(EnumTypeName = ""{ dllPropertyInfo.CSSPProp.EnumTypeName }"", EnumType = ""{ dllPropertyInfo.CSSPProp.EnumType }"")]");
            }
            if (dllPropertyInfo.CSSPProp.HasDataTypeAttribute)
            {
                sb.AppendLine(@"        [DataType(DataType.EmailAddress)]");
            }
            if (dllPropertyInfo.CSSPProp.HasCSSPCompareAttribute)
            {
                sb.AppendLine($@"        [CSSPCompare(""{ dllPropertyInfo.CSSPProp.Compare }"")]");
            }
            if (dllPropertyInfo.CSSPProp.HasCSSPRangeAttribute)
            {
                string MinText = "";
                string MaxText = "";
                if (dllPropertyInfo.CSSPProp.Min != null)
                {
                    if (dllPropertyInfo.CSSPProp.PropType == "Int16" || dllPropertyInfo.CSSPProp.PropType == "Int32" || dllPropertyInfo.CSSPProp.PropType == "Int64")
                    {
                        MinText = ((int)dllPropertyInfo.CSSPProp.Min).ToString("F0");
                    }
                    else if (dllPropertyInfo.CSSPProp.PropType == "Single")
                    {
                        MinText = $"{ ((float)dllPropertyInfo.CSSPProp.Min).ToString("F1") }f";
                    }
                    else if (dllPropertyInfo.CSSPProp.PropType == "Double")
                    {
                        MinText = $"{ ((double)dllPropertyInfo.CSSPProp.Min).ToString("F1") }D";
                    }
                }
                else
                {
                    if (dllPropertyInfo.CSSPProp.PropType == "Int16" || dllPropertyInfo.CSSPProp.PropType == "Int32" || dllPropertyInfo.CSSPProp.PropType == "Int64")
                    {
                        MinText = "-1";
                    }
                    else if (dllPropertyInfo.CSSPProp.PropType == "Single")
                    {
                        MinText = "-1.0f";
                    }
                    else if (dllPropertyInfo.CSSPProp.PropType == "Double")
                    {
                        MinText = "-1.0D";
                    }
                }
                if (dllPropertyInfo.CSSPProp.Max != null)
                {
                    if (dllPropertyInfo.CSSPProp.PropType == "Int16" || dllPropertyInfo.CSSPProp.PropType == "Int32" || dllPropertyInfo.CSSPProp.PropType == "Int64")
                    {
                        MaxText = ((int)dllPropertyInfo.CSSPProp.Max).ToString("F0");
                    }
                    else if (dllPropertyInfo.CSSPProp.PropType == "Single")
                    {
                        MaxText = $"{ ((float)dllPropertyInfo.CSSPProp.Max).ToString("F1") }f";
                    }
                    else if (dllPropertyInfo.CSSPProp.PropType == "Double")
                    {
                        MaxText = $"{ ((double)dllPropertyInfo.CSSPProp.Max).ToString("F1") }D";
                    }
                }
                else
                {
                    if (dllPropertyInfo.CSSPProp.PropType == "Int16" || dllPropertyInfo.CSSPProp.PropType == "Int32" || dllPropertyInfo.CSSPProp.PropType == "Int64")
                    {
                        MaxText = "-1";
                    }
                    else if (dllPropertyInfo.CSSPProp.PropType == "Single")
                    {
                        MaxText = "-1.0f";
                    }
                    else if (dllPropertyInfo.CSSPProp.PropType == "Double")
                    {
                        MaxText = "-1.0D";
                    }
                }
                sb.AppendLine($@"        [CSSPRange({ MinText }, { MaxText })]");
            }
            if (dllPropertyInfo.CSSPProp.HasCSSPEnumTypeAttribute && dllPropertyInfo.CSSPProp.IsNullable)
            {
                sb.AppendLine(@"        [CSSPAllowNull]");
            }
            else if (dllPropertyInfo.CSSPProp.PropType == "String" && dllPropertyInfo.CSSPProp.IsNullable)
            {
                sb.AppendLine(@"        [CSSPAllowNull]");
            }
            else if (dllPropertyInfo.CSSPProp.PropType == "TVItemLanguage" && dllPropertyInfo.CSSPProp.IsNullable)
            {
                sb.AppendLine(@"        [CSSPAllowNull]");
            }
            else if (dllPropertyInfo.CSSPProp.PropType.EndsWith("Web") && dllPropertyInfo.CSSPProp.IsNullable)
            {
                sb.AppendLine(@"        [CSSPAllowNull]");
            }
            else if (dllPropertyInfo.CSSPProp.PropType.EndsWith("Report") && dllPropertyInfo.CSSPProp.IsNullable)
            {
                sb.AppendLine(@"        [CSSPAllowNull]");
            }
            else if (dllTypeInfoModels.HasNotMappedAttribute && dllPropertyInfo.CSSPProp.IsNullable)
            {
                sb.AppendLine(@"        [CSSPAllowNull]");
            }
            else if (dllTypeInfoModels.Type.Name == "Contact" && (dllPropertyInfo.PropertyInfo.Name == "PasswordHash" || dllPropertyInfo.PropertyInfo.Name == "PasswordSalt"))
            {
                sb.AppendLine(@"        [CSSPAllowNull]");
            }

            return await Task.FromResult(true);
        }
    }
}
