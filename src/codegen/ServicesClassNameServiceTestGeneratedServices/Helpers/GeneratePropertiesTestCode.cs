using CSSPEnums;
using CSSPModels;
using GenerateCodeBaseServices.Models;
using GenerateCodeBaseServices.Services;
using ActionCommandDBServices.Models;
using ActionCommandDBServices.Services;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ValidateAppSettingsServices.Services;
using ValidateAppSettingsServices.Models;
using System.Reflection.Metadata.Ecma335;

namespace ServicesClassNameServiceTestGeneratedServices.Services
{
    public partial class ServicesClassNameServiceTestGeneratedService : IServicesClassNameServiceTestGeneratedService
    {
        private async Task<bool> GeneratePropertiesTestCode(string TypeName, string TypeNameLower, Type type, StringBuilder sb)
        {
            sb.AppendLine(@"        #region Tests Generated Properties");
            sb.AppendLine(@"        [TestMethod]");
            sb.AppendLine($@"        public void { TypeName }_Properties_Test()");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            foreach (CultureInfo culture in AllowableCulture)");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                ChangeCulture(culture);");
            sb.AppendLine(@"");
            sb.AppendLine(@"                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))");
            sb.AppendLine(@"                {");
            sb.AppendLine($@"                    { TypeName }Service { TypeNameLower }Service = new { TypeName }Service(new Query() {{ Lang = culture.TwoLetterISOLanguageName }}, dbTestDB, ContactID);");
            sb.AppendLine(@"");
            sb.AppendLine(@"                    int count = 0;");
            sb.AppendLine(@"                    if (count == 1)");
            sb.AppendLine(@"                    {");
            sb.AppendLine(@"                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]");
            sb.AppendLine(@"                    }");
            sb.AppendLine(@"");
            sb.AppendLine($@"                    count = { TypeNameLower }Service.Get{ TypeName }List().Count();");
            sb.AppendLine(@"");
            sb.AppendLine($@"                    { TypeName } { TypeNameLower } = GetFilledRandom{ TypeName }("""");");
            sb.AppendLine(@"");

            sb.AppendLine(@"                    // -------------------------------");
            sb.AppendLine(@"                    // -------------------------------");
            sb.AppendLine(@"                    // Properties testing");
            sb.AppendLine(@"                    // -------------------------------");
            sb.AppendLine(@"                    // -------------------------------");
            sb.AppendLine(@"");

            foreach (PropertyInfo prop in type.GetProperties())
            {
                CSSPProp csspProp = new CSSPProp();
                if (!generateCodeBaseService.FillCSSPProp(prop, csspProp, type))
                {
                    return await Task.FromResult(false);
                }

                sb.AppendLine(@"");
                sb.AppendLine(@"                    // -----------------------------------");
                if (csspProp.IsKey)
                {
                    sb.AppendLine(@"                    // [Key]");
                }
                if (csspProp.IsNullable)
                {
                    sb.AppendLine(@"                    // Is Nullable");
                }
                else
                {
                    sb.AppendLine(@"                    // Is NOT Nullable");
                }
                if (csspProp.IsVirtual)
                {
                    sb.AppendLine(@"                    // [IsVirtual]");
                }
                if (csspProp.HasCompareAttribute)
                {
                    sb.AppendLine($@"                    // [Compare(OtherField = { csspProp.OtherField })]");
                }
                if (csspProp.HasCSSPAfterAttribute)
                {
                    sb.AppendLine($@"                    // [CSSPAfter(Year = { csspProp.Year })]");
                }
                if (csspProp.HasCSSPAllowNullAttribute)
                {
                    sb.AppendLine(@"                    // [CSSPAllowNull]");
                }
                if (csspProp.HasCSSPBiggerAttribute)
                {
                    sb.AppendLine($@"                    // [CSSPBigger(OtherField = { csspProp.OtherField })]");
                }
                if (csspProp.HasCSSPEnumTypeAttribute)
                {
                    sb.AppendLine(@"                    // [CSSPEnumType]");
                }
                if (csspProp.HasCSSPExistAttribute)
                {
                    sb.AppendLine($@"                    // [CSSPExist(ExistTypeName = ""{ csspProp.ExistTypeName }"", ExistPlurial = ""{ csspProp.ExistPlurial }"", ExistFieldID = ""{ csspProp.ExistFieldID }"", AllowableTVtypeList = { String.Join(",", csspProp.AllowableTVTypeList) })]");
                }
                if (csspProp.HasCSSPFillAttribute)
                {
                    string FillNeedLanguage = (csspProp.FillNeedLanguage ? "true" : "false");
                    string FillIsList = (csspProp.FillIsList ? "true" : "false");
                    sb.AppendLine($@"                    // [CSSPFill(FillTypeName = ""{ csspProp.FillTypeName }"", FillPlurial = ""{ csspProp.FillPlurial }"", FillFieldID = ""{ csspProp.FillFieldID }"", FillEqualField = ""{ csspProp.FillEqualField }"", FillReturnField = ""{ csspProp.FillReturnField }"", FillNeedLanguage = { FillNeedLanguage }, FillIsList = { FillIsList })]");
                }
                if (csspProp.HasDataTypeAttribute)
                {
                    sb.AppendLine($@"                    // [DataType(DataType.{ csspProp.dataType.ToString() })]");
                }
                if (csspProp.HasNotMappedAttribute)
                {
                    sb.AppendLine(@"                    // [NotMapped]");
                }
                if (csspProp.HasRangeAttribute)
                {
                    sb.AppendLine($@"                    // [Range({ csspProp.Min }, { (csspProp.Max == null ? "-1" : csspProp.Max.ToString()) })]");
                }
                if (csspProp.HasStringLengthAttribute)
                {
                    string MinText = (csspProp.Min == null ? ")" : $", MinimumLength = { csspProp.Min.ToString() }");
                    sb.AppendLine($@"                    // [StringLength({ csspProp.Max }{ MinText })]");
                }
                sb.AppendLine($@"                    // { TypeNameLower }.{ csspProp.PropName }   ({ csspProp.PropType })");
                sb.AppendLine(@"                    // -----------------------------------");
                sb.AppendLine(@"");

                if (csspProp.IsVirtual || csspProp.PropName == "ValidationResults")
                {
                    sb.AppendLine(@"                    // No testing requied");
                    continue;
                }
                if (csspProp.PropName == "HasErrors")
                {
                    sb.AppendLine(@"                    // No testing requied");
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

            sb.AppendLine(@"                }");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"        }");

            sb.AppendLine(@"        #endregion Tests Generated Properties");
            sb.AppendLine(@"");


            return await Task.FromResult(true);
        }
    }
}
