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

namespace ServicesClassNameServiceTestGeneratedServices.Services
{
    public partial class ServicesClassNameServiceTestGeneratedService : IServicesClassNameServiceTestGeneratedService
    {
        private async Task<bool> CreateClass_Required_Properties_Testing(CSSPProp csspProp, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            if (csspProp.IsVirtual || csspProp.IsKey || csspProp.PropName == "ValidationResults")
            {
                return await Task.FromResult(true);
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
                            sb.AppendLine($@"                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, ""{ csspProp.PropName }""), { TypeNameLower }.ValidationResults.FirstOrDefault().ErrorMessage);");
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
                                sb.AppendLine($@"                    Assert.AreEqual(false, { TypeNameLower }Service.Add({ TypeNameLower }, AddContactTypeEnum.LoggedIn));");
                            }
                            else
                            {
                                sb.AppendLine($@"                    Assert.AreEqual(false, { TypeNameLower }Service.Add({ TypeNameLower }));");
                            }
                            if (TypeName == "Contact" && csspProp.PropName == "Id")
                            {
                                sb.AppendLine($@"                    Assert.AreEqual(2, { TypeNameLower }.ValidationResults.Count());");
                            }
                            else
                            {
                                sb.AppendLine($@"                    Assert.AreEqual(1, { TypeNameLower }.ValidationResults.Count());");
                            }
                            sb.AppendLine($@"                    Assert.IsTrue({ TypeNameLower }.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, ""{ csspProp.PropName }"")).Any());");
                            sb.AppendLine($@"                    Assert.AreEqual(null, { TypeNameLower }.{ csspProp.PropName });");
                            sb.AppendLine($@"                    Assert.AreEqual(count, { TypeNameLower }Service.Get{ TypeName }List().Count());");
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
                                sb.AppendLine($@"                    Assert.IsNull({ TypeNameLower }.{ TypeName }{ EndText });");
                                sb.AppendLine(@"");
                                sb.AppendLine($@"                    { TypeNameLower } = null;");
                                sb.AppendLine($@"                    { TypeNameLower } = GetFilledRandom{ TypeName }("""");");
                                sb.AppendLine($@"                    { TypeNameLower }.{ TypeName }{ EndText } = new { TypeName }{ EndText }();");
                                sb.AppendLine($@"                    Assert.IsNotNull({ TypeNameLower }.{ TypeName }{ EndText });");
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

            return await Task.FromResult(true);
        }
    }
}
