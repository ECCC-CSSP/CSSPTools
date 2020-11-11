﻿using CSSPHelperModels;
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
        private async Task<bool> GenerateGetFilledRandomClassnameTestCode(Type type, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            StringBuilder sbInMemory = new StringBuilder();

            sb.AppendLine($@"        private { TypeName } GetFilledRandom{ TypeName }(string OmitPropName)");
            sb.AppendLine(@"        {");
            sb.AppendLine($@"            { TypeName } { TypeNameLower } = new { TypeName }();");
            sb.AppendLine(@"");
            foreach (PropertyInfo prop in type.GetProperties())
            {
                CSSPProp csspProp = new CSSPProp();
                if (!GenerateCodeBase.FillCSSPProp(prop, csspProp, type))
                {
                    return await Task.FromResult(false);
                }

                if (TypeName == "AspNetUser" && prop.Name == "Id")
                {
                    if (!await CreateGetFilledRandomClass(prop, csspProp, TypeName, TypeNameLower, sb, sbInMemory)) return await Task.FromResult(false);
                }
                else
                {
                    if (csspProp.IsKey || prop.GetGetMethod().IsVirtual || prop.Name == "ValidationResults")
                    {
                        continue;
                    }

                    if (!await CreateGetFilledRandomClass(prop, csspProp, TypeName, TypeNameLower, sb, sbInMemory)) return await Task.FromResult(false);
                }
            }

            sb.AppendLine(@"");
            sb.AppendLine(sbInMemory.ToString());
            sb.AppendLine(@"");
            sb.AppendLine($@"            return { TypeNameLower };");
            sb.AppendLine(@"        }");
            return await Task.FromResult(true);
        }
    }
}
