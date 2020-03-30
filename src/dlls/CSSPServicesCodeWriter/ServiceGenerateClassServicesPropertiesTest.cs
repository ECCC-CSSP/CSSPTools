using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Forms;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using CSSPModels;
using CSSPEnums;
using CSSPServices;
using CSSPGenerateCodeBase;

namespace CSSPServicesGenerateCodeHelper
{
    public partial class ServicesCodeWriter
    {
        /// <summary>
        ///     <code>
        ///         Write code part for the current model property to test after  
        ///     </code>       
        /// </summary>
        /// <param name="csspProp">Holds CSSPProp information about the current class name and property</param>
        /// <param name="TypeName">Current model type name</param>
        /// <param name="TypeNameLower">Current model type name with first letter lowercase</param>
        /// <param name="sb">StringBuilder holding the text of the file being created</param>
        private void CreateClass_CSSPAfter_Testing(CSSPProp csspProp, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            if (csspProp.IsVirtual || csspProp.IsKey || csspProp.PropName == "ValidationResults")
            {
                return;
            }

            switch (csspProp.PropType)
            {
                case "Int16":
                case "Int32":
                case "Int64":
                case "Boolean":
                case "Single":
                case "String":
                    break;
                case "DateTime":
                case "DateTimeOffset":
                    {
                        if (csspProp.HasCSSPAfterAttribute)
                        {
                            sb.AppendLine($@"                    { TypeNameLower } = null;");
                            sb.AppendLine($@"                    { TypeNameLower } = GetFilledRandom{ TypeName }("""");");
                            sb.AppendLine($@"                    { TypeNameLower }.{ csspProp.PropName } = new DateTime({ ((int)csspProp.Year - 1).ToString() }, 1, 1);");
                            if (TypeName == "Contact")
                            {
                                sb.AppendLine($@"                    { TypeNameLower }Service.Add({ TypeNameLower }, AddContactTypeEnum.LoggedIn);");
                            }
                            else
                            {
                                sb.AppendLine($@"                    { TypeNameLower }Service.Add({ TypeNameLower });");
                            }
                            sb.AppendLine($@"                    Assert.Equal(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, ""{ csspProp.PropName }"", ""{ csspProp.Year }""), { TypeNameLower }.ValidationResults.FirstOrDefault().ErrorMessage);");

                        }
                    }
                    break;
                default:
                    {
                        if (csspProp.HasCSSPEnumTypeAttribute)
                        {
                            // nothing for now
                        }
                        else
                        {
                            if (csspProp.PropName.EndsWith("Web") || csspProp.PropName.EndsWith("Report"))
                            {
                                // nothing yet
                            }
                            else
                            {
                                sb.AppendLine($@"                    //CSSPError: Type not implemented [{ csspProp.PropName }]");
                                sb.AppendLine(@"");
                            }
                        }
                    }
                    break;
            }
        }
        /// <summary>
        ///     <code>
        ///         Write code part for the current model property to test enum type  
        ///     </code>       
        /// </summary>
        /// <param name="csspProp">Holds CSSPProp information about the current class name and property</param>
        /// <param name="TypeName">Current model type name</param>
        /// <param name="TypeNameLower">Current model type name with first letter lowercase</param>
        /// <param name="sb">StringBuilder holding the text of the file being created</param>
        private void CreateClass_CSSPEnumType_Testing(CSSPProp csspProp, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            if (csspProp.IsVirtual || csspProp.IsKey || csspProp.PropName == "ValidationResults")
            {
                return;
            }

            if (csspProp.PropType.EndsWith("Enum"))
            {
                if (csspProp.HasCSSPEnumTypeAttribute)
                {
                    sb.AppendLine($@"                    { TypeNameLower } = null;");
                    sb.AppendLine($@"                    { TypeNameLower } = GetFilledRandom{ TypeName }("""");");
                    sb.AppendLine($@"                    { TypeNameLower }.{ csspProp.PropName } = ({ csspProp.PropType })1000000;");
                    if (TypeName == "Contact")
                    {
                        sb.AppendLine($@"                    { TypeNameLower }Service.Add({ TypeNameLower }, AddContactTypeEnum.LoggedIn);");
                    }
                    else
                    {
                        sb.AppendLine($@"                    { TypeNameLower }Service.Add({ TypeNameLower });");
                    }
                    sb.AppendLine($@"                    Assert.Equal(string.Format(CSSPServicesRes._IsRequired, ""{ csspProp.PropName }""), { TypeNameLower }.ValidationResults.FirstOrDefault().ErrorMessage);");
                    sb.AppendLine(@"");
                }
            }
        }
        /// <summary>
        ///     <code>
        ///         Write code part for the current model property to test exist 
        ///     </code>       
        /// </summary>
        /// <param name="csspProp">Holds CSSPProp information about the current class name and property</param>
        /// <param name="TypeName">Current model type name</param>
        /// <param name="TypeNameLower">Current model type name with first letter lowercase</param>
        /// <param name="sb">StringBuilder holding the text of the file being created</param>
        private void CreateClass_CSSPExist_Testing(CSSPProp csspProp, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            if (csspProp.IsVirtual || csspProp.IsKey || csspProp.PropName == "ValidationResults")
            {
                return;
            }

            switch (csspProp.PropType)
            {
                case "Int16":
                case "Int32":
                case "Int64":
                case "Boolean":
                case "Single":
                    {
                        if (csspProp.IsKey)
                        {
                            break;
                        }

                        if (csspProp.HasCSSPExistAttribute)
                        {
                            sb.AppendLine($@"                    { TypeNameLower } = null;");
                            sb.AppendLine($@"                    { TypeNameLower } = GetFilledRandom{ TypeName }("""");");
                            sb.AppendLine($@"                    { TypeNameLower }.{ csspProp.PropName } = 0;");
                            if (TypeName == "Contact")
                            {
                                sb.AppendLine($@"                    { TypeNameLower }Service.Add({ TypeNameLower }, AddContactTypeEnum.LoggedIn);");
                            }
                            else
                            {
                                sb.AppendLine($@"                    { TypeNameLower }Service.Add({ TypeNameLower });");
                            }
                            sb.AppendLine($@"                    Assert.Equal(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, ""{ csspProp.ExistTypeName }"", ""{ csspProp.PropName }"", { TypeNameLower }.{ csspProp.PropName }.ToString()), { TypeNameLower }.ValidationResults.FirstOrDefault().ErrorMessage);");
                            sb.AppendLine(@"");

                            if (csspProp.ExistTypeName == "TVItem")
                            {
                                int TVItemIDNotGoodType = 0;
                                TVItem tvItem = null;
                                tvItem = (from c in dbTestDB.TVItems
                                          where !csspProp.AllowableTVTypeList.Contains(c.TVType)
                                          select c).FirstOrDefault();

                                if (tvItem != null)
                                {
                                    TVItemIDNotGoodType = tvItem.TVItemID;
                                }

                                sb.AppendLine($@"                    { TypeNameLower } = null;");
                                sb.AppendLine($@"                    { TypeNameLower } = GetFilledRandom{ TypeName }("""");");
                                sb.AppendLine($@"                    { TypeNameLower }.{ csspProp.PropName } = { TVItemIDNotGoodType };");
                                if (TypeName == "Contact")
                                {
                                    sb.AppendLine($@"                    { TypeNameLower }Service.Add({ TypeNameLower }, AddContactTypeEnum.LoggedIn);");
                                }
                                else
                                {
                                    sb.AppendLine($@"                    { TypeNameLower }Service.Add({ TypeNameLower });");
                                }
                                sb.AppendLine($@"                    Assert.Equal(string.Format(CSSPServicesRes._IsNotOfType_, ""{ csspProp.PropName }"", ""{ String.Join(",", csspProp.AllowableTVTypeList) }""), { TypeNameLower }.ValidationResults.FirstOrDefault().ErrorMessage);");
                                sb.AppendLine(@"");
                            }
                        }
                    }
                    break;
                default:
                    {
                    }
                    break;
            }
        }
        /// <summary>
        ///     <code>
        ///         Write code part for the current model property to test min and max  
        ///     </code>       
        /// </summary>
        /// <param name="csspProp">Holds CSSPProp information about the current class name and property</param>
        /// <param name="TypeName">Current model type name</param>
        /// <param name="TypeNameLower">Current model type name with first letter lowercase</param>
        /// <param name="sb">StringBuilder holding the text of the file being created</param>
        private void CreateClass_Min_And_Max_Properties_Testing(CSSPProp csspProp, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            if (csspProp.IsVirtual || csspProp.IsKey || csspProp.PropName == "ValidationResults")
            {
                return;
            }

            switch (csspProp.PropType)
            {

                case "Int16":
                case "Int32":
                case "Int64":
                case "Single":
                case "Double":
                    {
                        //string propTypeTxt = "Int";
                        string numbExt = "";
                        if (csspProp.PropType == "Single")
                        {
                            //  propTypeTxt = "Float";
                            numbExt = ".0f";
                        }
                        else if (csspProp.PropType == "Double")
                        {
                            //propTypeTxt = "Double";
                            numbExt = ".0D";
                        }

                        if (csspProp.Min != null)
                        {
                            sb.AppendLine($@"                    { TypeNameLower } = null;");
                            sb.AppendLine($@"                    { TypeNameLower } = GetFilledRandom{ TypeName }("""");");
                            sb.AppendLine($@"                    { TypeNameLower }.{ csspProp.PropName } = { (csspProp.Min - 1).ToString() }{ numbExt };");
                            if (TypeName == "Contact")
                            {
                                sb.AppendLine($@"                    Assert.False({ TypeNameLower }Service.Add({ TypeNameLower }, AddContactTypeEnum.First));");
                            }
                            else
                            {
                                sb.AppendLine($@"                    Assert.False({ TypeNameLower }Service.Add({ TypeNameLower }));");
                            }
                            if (csspProp.Max != null)
                            {
                                sb.AppendLine($@"                    Assert.Equal(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, ""{ csspProp.PropName }"", ""{ csspProp.Min.ToString() }"", ""{ csspProp.Max.ToString() }""), { TypeNameLower }.ValidationResults.FirstOrDefault().ErrorMessage);");
                            }
                            else
                            {
                                sb.AppendLine($@"                    Assert.Equal(string.Format(CSSPServicesRes._MinValueIs_, ""{ csspProp.PropName }"", ""{ csspProp.Min.ToString() }""), { TypeNameLower }.ValidationResults.FirstOrDefault().ErrorMessage);");
                            }
                            sb.AppendLine($@"                    Assert.Equal(count, (int){ TypeNameLower }Service.Get{ TypeName }List().Count());");
                        }
                        if (csspProp.Max != null)
                        {
                            sb.AppendLine($@"                    { TypeNameLower } = null;");
                            sb.AppendLine($@"                    { TypeNameLower } = GetFilledRandom{ TypeName }("""");");

                            sb.AppendLine($@"                    { TypeNameLower }.{ csspProp.PropName } = { (csspProp.Max + 1).ToString() }{ numbExt };");
                            if (TypeName == "Contact")
                            {
                                sb.AppendLine($@"                    Assert.False({ TypeNameLower }Service.Add({ TypeNameLower }, AddContactTypeEnum.First));");
                            }
                            else
                            {
                                sb.AppendLine($@"                    Assert.False({ TypeNameLower }Service.Add({ TypeNameLower }));");
                            }
                            if (csspProp.Min != null)
                            {
                                sb.AppendLine($@"                    Assert.Equal(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, ""{ csspProp.PropName }"", ""{ csspProp.Min.ToString() }"", ""{ csspProp.Max.ToString() }""), { TypeNameLower }.ValidationResults.FirstOrDefault().ErrorMessage);");
                            }
                            else
                            {
                                sb.AppendLine($@"                    Assert.Equal(string.Format(CSSPServicesRes._MaxValueIs_, ""{ csspProp.PropName }"", ""{ csspProp.Max.ToString() }""), { TypeNameLower }.ValidationResults.FirstOrDefault().ErrorMessage);");
                            }
                            sb.AppendLine($@"                    Assert.Equal(count, (int){ TypeNameLower }Service.Get{ TypeName }List().Count());");
                        }
                    }
                    break;
                case "Boolean":
                    {
                        // nothing
                    }
                    break;
                case "DateTime":
                case "DateTimeOffset":
                    {
                        // nothing
                    }
                    break;
                case "String":
                    {
                        if (csspProp.Min != null)
                        {
                            sb.AppendLine($@"                    { TypeNameLower } = null;");
                            sb.AppendLine($@"                    { TypeNameLower } = GetFilledRandom{ TypeName }("""");");

                            if (csspProp.Min - 1 > 0)
                            {
                                sb.AppendLine($@"                    { TypeNameLower }.{ csspProp.PropName } = GetRandomString("""", { (csspProp.Min - 1).ToString() });");
                                if (TypeName == "Contact")
                                {
                                    sb.AppendLine($@"                    Assert.False({ TypeNameLower }Service.Add({ TypeNameLower }, AddContactTypeEnum.First));");
                                }
                                else
                                {
                                    sb.AppendLine($@"                    Assert.False({ TypeNameLower }Service.Add({ TypeNameLower }));");
                                }
                                if (csspProp.Max != null)
                                {
                                    sb.AppendLine($@"                    Assert.Equal(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, ""{ csspProp.PropName }"", ""{ csspProp.Min.ToString() }"", ""{ csspProp.Max.ToString() }""), { TypeNameLower }.ValidationResults.FirstOrDefault().ErrorMessage);");
                                }
                                else
                                {
                                    sb.AppendLine($@"                    Assert.Equal(string.Format(CSSPServicesRes._MinLengthIs_, ""{ csspProp.PropName }"", ""{ csspProp.Min.ToString() }""), { TypeNameLower }.ValidationResults.FirstOrDefault().ErrorMessage);");
                                }
                                sb.AppendLine($@"                    Assert.Equal(count, (int){ TypeNameLower }Service.Get{ TypeName }List().Count());");
                            }
                        }
                        if (csspProp.Max > 0)
                        {
                            sb.AppendLine($@"                    { TypeNameLower } = null;");
                            sb.AppendLine($@"                    { TypeNameLower } = GetFilledRandom{ TypeName }("""");");

                            sb.AppendLine($@"                    { TypeNameLower }.{ csspProp.PropName } = GetRandomString("""", { (csspProp.Max + 1).ToString() });");
                            if (TypeName == "Contact")
                            {
                                sb.AppendLine($@"                    Assert.False({ TypeNameLower }Service.Add({ TypeNameLower }, AddContactTypeEnum.First));");
                            }
                            else
                            {
                                sb.AppendLine($@"                    Assert.False({ TypeNameLower }Service.Add({ TypeNameLower }));");
                            }
                            if (csspProp.Min != null)
                            {
                                sb.AppendLine($@"                    Assert.Equal(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, ""{ csspProp.PropName }"", ""{ csspProp.Min.ToString() }"", ""{ csspProp.Max.ToString() }""), { TypeNameLower }.ValidationResults.FirstOrDefault().ErrorMessage);");
                            }
                            else
                            {
                                sb.AppendLine($@"                    Assert.Equal(string.Format(CSSPServicesRes._MaxLengthIs_, ""{ csspProp.PropName }"", ""{ csspProp.Max.ToString() }""), { TypeNameLower }.ValidationResults.FirstOrDefault().ErrorMessage);");
                            }
                            sb.AppendLine($@"                    Assert.Equal(count, (int){ TypeNameLower }Service.Get{ TypeName }List().Count());");
                        }
                    }
                    break;
                default:
                    {
                    }
                    break;
            }
        }
        /// <summary>
        ///     <code>
        ///         Write code part for the current model property to test required  
        ///     </code>       
        /// </summary>
        /// <param name="csspProp">Holds CSSPProp information about the current class name and property</param>
        /// <param name="TypeName">Current model type name</param>
        /// <param name="TypeNameLower">Current model type name with first letter lowercase</param>
        /// <param name="sb">StringBuilder holding the text of the file being created</param>
        private void CreateClass_Required_Properties_Testing(CSSPProp csspProp, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            if (csspProp.IsVirtual || csspProp.IsKey || csspProp.PropName == "ValidationResults")
            {
                return;
            }

            switch (csspProp.PropType)
            {
                case "Int16":
                case "Int32":
                case "Int64":
                case "Boolean":
                case "Single":
                    break;
                case "DateTime":
                case "DateTimeOffset":
                    {
                        if (!csspProp.IsNullable)
                        {
                            sb.AppendLine($@"                    { TypeNameLower } = null;");
                            sb.AppendLine($@"                    { TypeNameLower } = GetFilledRandom{ TypeName }("""");");
                            sb.AppendLine($@"                    { TypeNameLower }.{ csspProp.PropName } = new DateTime();");
                            if (TypeName == "Contact")
                            {
                                sb.AppendLine($@"                    { TypeNameLower }Service.Add({ TypeNameLower }, AddContactTypeEnum.LoggedIn);");
                            }
                            else
                            {
                                sb.AppendLine($@"                    { TypeNameLower }Service.Add({ TypeNameLower });");
                            }
                            sb.AppendLine($@"                    Assert.Equal(string.Format(CSSPServicesRes._IsRequired, ""{ csspProp.PropName }""), { TypeNameLower }.ValidationResults.FirstOrDefault().ErrorMessage);");
                        }
                    }
                    break;
                case "String":
                    {
                        if (!csspProp.IsNullable)
                        {
                            sb.AppendLine($@"                    { TypeNameLower } = null;");
                            sb.AppendLine($@"                    { TypeNameLower } = GetFilledRandom{ TypeName }(""{ csspProp.PropName }"");");
                            if (TypeName == "Contact")
                            {
                                sb.AppendLine($@"                    Assert.False({ TypeNameLower }Service.Add({ TypeNameLower }, AddContactTypeEnum.LoggedIn));");
                            }
                            else
                            {
                                sb.AppendLine($@"                    Assert.False({ TypeNameLower }Service.Add({ TypeNameLower }));");
                            }
                            if (TypeName == "Contact" && csspProp.PropName == "Id")
                            {
                                sb.AppendLine($@"                    Assert.Equal(2, (int){ TypeNameLower }.ValidationResults.Count());");
                            }
                            else
                            {
                                sb.AppendLine($@"                    Assert.Equal(1, (int){ TypeNameLower }.ValidationResults.Count());");
                            }
                            sb.AppendLine($@"                    Assert.True({ TypeNameLower }.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, ""{ csspProp.PropName }"")).Any());");
                            sb.AppendLine($@"                    Assert.Null({ TypeNameLower }.{ csspProp.PropName });");
                            sb.AppendLine($@"                    Assert.Equal(count, (int){ TypeNameLower }Service.Get{ TypeName }List().Count());");
                            sb.AppendLine(@"");
                        }
                    }
                    break;
                default:
                    {
                        if (csspProp.HasCSSPEnumTypeAttribute)
                        {
                            // nothing for now
                        }
                        else
                        {
                            if (csspProp.PropName.EndsWith("Web") || csspProp.PropName.EndsWith("Report"))
                            {
                                string EndText = csspProp.PropName.EndsWith("Web") ? "Web" : "Report";

                                sb.AppendLine($@"                    { TypeNameLower } = null;");
                                sb.AppendLine($@"                    { TypeNameLower } = GetFilledRandom{ TypeName }("""");");
                                sb.AppendLine($@"                    { TypeNameLower }.{ TypeName }{ EndText } = null;");
                                sb.AppendLine($@"                    Assert.Null({ TypeNameLower }.{ TypeName }{ EndText });");
                                sb.AppendLine(@"");
                                sb.AppendLine($@"                    { TypeNameLower } = null;");
                                sb.AppendLine($@"                    { TypeNameLower } = GetFilledRandom{ TypeName }("""");");
                                sb.AppendLine($@"                    { TypeNameLower }.{ TypeName }{ EndText } = new { TypeName }{ EndText }();");
                                sb.AppendLine($@"                    Assert.NotNull({ TypeNameLower }.{ TypeName }{ EndText });");
                            }
                            else if (csspProp.PropName.EndsWith("Report"))
                            {
                            }
                            else
                            {
                                sb.AppendLine($@"                    //CSSPError: Type not implemented [{ csspProp.PropName }]");
                                sb.AppendLine(@"");
                            }
                        }
                    }
                    break;
            }
        }
        /// <summary>
        ///     <code>
        ///         Write code part for the current model properties to test
        ///     </code>
        /// </summary>
        /// <param name="TypeName">Current model type name</param>
        /// <param name="TypeNameLower">Current model type name with first letter lowercase</param>
        /// <param name="type">Class type</param>
        /// <param name="sb">StringBuilder holding the text of the file being created</param>
        private void GeneratePropertiesTestCode(string TypeName, string TypeNameLower, Type type, StringBuilder sb)
        {
            sb.AppendLine(@"        #region Tests Generated Properties");
            sb.AppendLine(@"        [Fact]");
            sb.AppendLine($@"        public void { TypeName }_Properties_Test()");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            foreach (CultureInfo culture in AllowableCulture)");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                ChangeCulture(culture);");
            sb.AppendLine(@"");
            sb.AppendLine(@"                using (CSSPDBContext dbTestDB = new CSSPDBContext())");
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
                if (!modelsGenerateCodeHelper.FillCSSPProp(prop, csspProp, type))
                {
                    return;
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
                    CreateClass_Key_Testing(csspProp, TypeName, TypeNameLower, sb);
                }

                CreateClass_CSSPExist_Testing(csspProp, TypeName, TypeNameLower, sb);
                CreateClass_CSSPEnumType_Testing(csspProp, TypeName, TypeNameLower, sb);
                CreateClass_Required_Properties_Testing(csspProp, TypeName, TypeNameLower, sb);
                CreateClass_CSSPAfter_Testing(csspProp, TypeName, TypeNameLower, sb);
                CreateClass_Min_And_Max_Properties_Testing(csspProp, TypeName, TypeNameLower, sb);
            }

            sb.AppendLine(@"                }");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"        }");

            sb.AppendLine(@"        #endregion Tests Generated Properties");
            sb.AppendLine(@"");
        }
    }
}
