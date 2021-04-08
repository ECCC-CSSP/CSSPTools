using GenerateCodeBaseHelper;
using GenerateCodeBaseServices.Models;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GenerateCSSPHelperServices_Tests
{
    public partial class Startup
    {
        private async Task<bool> GeneratePropertiesTestCode(string TypeName, string TypeNameLower, Type type, StringBuilder sb)
        {
            sb.AppendLine(@"        #region Tests Generated Properties");
            sb.AppendLine(@"        [Theory]");
            sb.AppendLine(@"        [InlineData(""en-CA"")]");
            sb.AppendLine(@"        //[InlineData(""fr-CA"")]");
            sb.AppendLine($@"        public async Task { TypeName }_Properties_Test(string culture)");
            sb.AppendLine(@"        {");
            //sb.AppendLine(@"            List<ValidationResult> ValidationResultList = new List<ValidationResult>();");
            //sb.AppendLine(@"            IEnumerable<ValidationResult> validationResults;");
            sb.AppendLine(@"            Assert.True(await Setup(culture));");
            sb.AppendLine(@"");
            sb.AppendLine($@"            { TypeName } { TypeNameLower } = GetFilledRandom{ TypeName }("""");");
            sb.AppendLine(@"");

            foreach (PropertyInfo prop in type.GetProperties())
            {
                CSSPProp csspProp = new CSSPProp();
                if (!GenerateCodeBase.FillCSSPProp(prop, csspProp, type))
                {
                    return await Task.FromResult(false);
                }

                sb.AppendLine(@"");
                sb.AppendLine(@"            // -----------------------------------");
                if (csspProp.IsKey)
                {
                    sb.AppendLine(@"            // [Key]");
                }
                if (csspProp.IsNullable)
                {
                    sb.AppendLine(@"            // Is Nullable");
                }
                else
                {
                    sb.AppendLine(@"            // Is NOT Nullable");
                }
                if (csspProp.IsVirtual)
                {
                    sb.AppendLine(@"            // [IsVirtual]");
                }
                if (csspProp.HasCSSPCompareAttribute)
                {
                    sb.AppendLine($@"            // [CSSPCompare(OtherField = { csspProp.OtherField })]");
                }
                if (csspProp.HasCSSPAfterAttribute)
                {
                    sb.AppendLine($@"            // [CSSPAfter(Year = { csspProp.Year })]");
                }
                if (csspProp.HasCSSPAllowNullAttribute)
                {
                    sb.AppendLine(@"            // [CSSPAllowNull]");
                }
                if (csspProp.HasCSSPBiggerAttribute)
                {
                    sb.AppendLine($@"            // [CSSPBigger(OtherField = { csspProp.OtherField })]");
                }
                if (csspProp.HasCSSPEnumTypeAttribute)
                {
                    sb.AppendLine(@"            // [CSSPEnumType]");
                }
                if (csspProp.HasCSSPExistAttribute)
                {
                    sb.AppendLine($@"            // [CSSPExist(ExistTypeName = ""{ csspProp.ExistTypeName }"", ExistPlurial = ""{ csspProp.ExistPlurial }"", ExistFieldID = ""{ csspProp.ExistFieldID }"", AllowableTVtypeList = { String.Join(",", csspProp.AllowableTVTypeList) })]");
                }
                if (csspProp.HasCSSPFillAttribute)
                {
                    string FillNeedLanguage = (csspProp.FillNeedLanguage ? "true" : "false");
                    string FillIsList = (csspProp.FillIsList ? "true" : "false");
                    sb.AppendLine($@"            // [CSSPFill(FillTypeName = ""{ csspProp.FillTypeName }"", FillPlurial = ""{ csspProp.FillPlurial }"", FillFieldID = ""{ csspProp.FillFieldID }"", FillEqualField = ""{ csspProp.FillEqualField }"", FillReturnField = ""{ csspProp.FillReturnField }"", FillNeedLanguage = { FillNeedLanguage }, FillIsList = { FillIsList })]");
                }
                if (csspProp.HasDataTypeAttribute)
                {
                    sb.AppendLine($@"            // [DataType(DataType.{ csspProp.dataType.ToString() })]");
                }
                if (csspProp.HasNotMappedAttribute)
                {
                    sb.AppendLine(@"            // [NotMapped]");
                }
                if (csspProp.HasCSSPRangeAttribute)
                {
                    sb.AppendLine($@"            // [CSSPRange({ csspProp.Min }, { (csspProp.Max == null ? "-1" : csspProp.Max.ToString()) })]");
                }
                if (csspProp.HasCSSPMaxLengthAttribute)
                {
                    sb.AppendLine($@"            // [CSSPMaxLength({ csspProp.Max })]");
                }
                if (csspProp.HasCSSPMinLengthAttribute)
                {
                    sb.AppendLine($@"            // [CSSPMinLength({ csspProp.Min })]");
                }
                sb.AppendLine($@"            // { TypeNameLower }.{ csspProp.PropName }   ({ csspProp.PropType })");
                sb.AppendLine(@"            // -----------------------------------");
                sb.AppendLine(@"");

                if (csspProp.IsVirtual || csspProp.PropName == "ValidationResults")
                {
                    sb.AppendLine(@"            // No testing requied");
                    continue;
                }
                if (csspProp.IsKey)
                {
                    if (!await CreateClass_Key_Testing(csspProp, TypeName, TypeNameLower, sb)) return await Task.FromResult(false);
                }

                if (!await CreateClass_CSSPExist_Testing(csspProp, TypeName, TypeNameLower, sb)) return await Task.FromResult(false);
                if (!await CreateClass_CSSPEnumType_Testing(csspProp, TypeName, TypeNameLower, sb)) return await Task.FromResult(false);
                if (!await CreateClass_Required_Properties_Testing(csspProp, TypeName, TypeNameLower, sb)) return await Task.FromResult(false);
                if (!await CreateClass_CSSPAfter_Testing(csspProp, TypeName, TypeNameLower, sb)) return await Task.FromResult(false);
                if (!await CreateClass_Min_And_Max_Properties_Testing(csspProp, TypeName, TypeNameLower, sb)) return await Task.FromResult(false);
            }

            sb.AppendLine(@"        }");

            sb.AppendLine(@"        #endregion Tests Generated Properties");
            sb.AppendLine(@"");


            return await Task.FromResult(true);
        }
    }
}
