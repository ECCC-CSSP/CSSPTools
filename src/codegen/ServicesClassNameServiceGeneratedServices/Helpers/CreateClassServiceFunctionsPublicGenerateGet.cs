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
using System.ComponentModel.DataAnnotations;
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

namespace ServicesClassNameServiceGeneratedServices.Services
{
    public partial class ServicesClassNameServiceGeneratedService : IServicesClassNameServiceGeneratedService
    {
        private async Task<bool> CreateClassServiceFunctionsPublicGenerateGet(DLLTypeInfo dllTypeInfo, List<DLLTypeInfo> DLLTypeInfoCSSPModelsList, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            sb.AppendLine(@"        #region Functions public Generated Get");
            foreach (DLLPropertyInfo dllPropertyInfo in dllTypeInfo.PropertyInfoList)
            {
                if (dllPropertyInfo.PropertyInfo.GetGetMethod().IsVirtual)
                {
                    continue;
                }

                if (dllPropertyInfo.PropertyInfo.Name == "ValidationResults")
                {
                    continue;
                }

                CSSPProp csspProp = new CSSPProp();
                if (!generateCodeBaseService.FillCSSPProp(dllPropertyInfo.PropertyInfo, csspProp, dllTypeInfo.Type))
                {
                    //actionCommandDBService.ErrorText.AppendLine($"{ string.Format(AppRes.ErrorWhileCreatingCode_, csspProp.CSSPError) }");
                    return await Task.FromResult(false);
                }
                if (csspProp.IsKey)
                {
                    List<string> ClassNameList = new List<string>() { TypeName, $"{ TypeName }ExtraA", $"{ TypeName }ExtraB", $"{ TypeName }ExtraC", $"{ TypeName }ExtraD", $"{ TypeName }ExtraE" };
                    foreach (string ClassName in ClassNameList)
                    {
                        DLLTypeInfo currentDLLTypeInfo = null;
                        foreach (DLLTypeInfo dllTypeInfo2 in DLLTypeInfoCSSPModelsList)
                        {
                            if (dllTypeInfo2.Name == ClassName)
                            {
                                currentDLLTypeInfo = dllTypeInfo2;
                            }
                        }

                        if (currentDLLTypeInfo == null)
                        {
                            continue;
                        }

                        if (currentDLLTypeInfo.Name == "AspNetUser" || currentDLLTypeInfo.Name == "AspNetUserExtraA" || currentDLLTypeInfo.Name == "AspNetUserExtraB" || currentDLLTypeInfo.Name == "AspNetUserExtraC" || currentDLLTypeInfo.Name == "AspNetUserExtraD" || currentDLLTypeInfo.Name == "AspNetUserExtraE")
                        {
                            sb.AppendLine($@"        public { currentDLLTypeInfo.Name } Get{ currentDLLTypeInfo.Name }With{ TypeName }ID(string Id,");
                        }
                        else
                        {
                            sb.AppendLine($@"        public { currentDLLTypeInfo.Name } Get{ currentDLLTypeInfo.Name }With{ TypeName }ID(int { TypeName }ID)");
                        }
                        sb.AppendLine(@"        {");
                        if (currentDLLTypeInfo.Name == "AspNetUser")
                        {
                            sb.AppendLine($@"            return (from c in db.{ TypeName }s");
                            sb.AppendLine(@"                    where c.Id == Id");
                            sb.AppendLine(@"                    select c).FirstOrDefault();");
                        }
                        else if (currentDLLTypeInfo.Name.EndsWith("ExtraA") || currentDLLTypeInfo.Name.EndsWith("ExtraB") || currentDLLTypeInfo.Name.EndsWith("ExtraC") || currentDLLTypeInfo.Name.EndsWith("ExtraD") || currentDLLTypeInfo.Name.EndsWith("ExtraE"))
                        {
                            sb.AppendLine($@"            return Fill{ currentDLLTypeInfo.Name }().Where(c => c.{ TypeName }ID == { TypeName }ID).FirstOrDefault();");
                        }
                        else
                        {
                            if (currentDLLTypeInfo.Name.StartsWith("Address"))
                            {
                                sb.AppendLine($@"            return (from c in db.{ TypeName }es");
                            }
                            else
                            {
                                sb.AppendLine($@"            return (from c in db.{ TypeName }s");
                            }
                            sb.AppendLine($@"                    where c.{ TypeName }ID == { TypeName }ID");
                            sb.AppendLine(@"                    select c).FirstOrDefault();");
                        }
                        sb.AppendLine(@"");
                        sb.AppendLine(@"        }");

                        sb.AppendLine($@"        public IQueryable<{ currentDLLTypeInfo.Name }> Get{ currentDLLTypeInfo.Name }List()");
                        sb.AppendLine(@"        {");
                        if (currentDLLTypeInfo.Name.EndsWith("ExtraA") || currentDLLTypeInfo.Name.EndsWith("ExtraB") || currentDLLTypeInfo.Name.EndsWith("ExtraC") || currentDLLTypeInfo.Name.EndsWith("ExtraD") || currentDLLTypeInfo.Name.EndsWith("ExtraE"))
                        {
                            sb.AppendLine($@"            IQueryable<{ currentDLLTypeInfo.Name }> { currentDLLTypeInfo.Name }Query = Fill{ currentDLLTypeInfo.Name }();");
                        }
                        else
                        {
                            if (currentDLLTypeInfo.Name.StartsWith("Address"))
                            {
                                sb.AppendLine($@"            IQueryable<{ currentDLLTypeInfo.Name }> { currentDLLTypeInfo.Name }Query = (from c in db.{ TypeName }es select c);");
                            }
                            else
                            {
                                sb.AppendLine($@"            IQueryable<{ currentDLLTypeInfo.Name }> { currentDLLTypeInfo.Name }Query = (from c in db.{ TypeName }s select c);");
                            }
                        }
                        sb.AppendLine(@"");
                        sb.AppendLine($@"            { currentDLLTypeInfo.Name }Query = EnhanceQueryStatements<{ currentDLLTypeInfo.Name }>({ currentDLLTypeInfo.Name }Query) as IQueryable<{ currentDLLTypeInfo.Name }>;");
                        sb.AppendLine(@"");
                        sb.AppendLine($@"            return { currentDLLTypeInfo.Name }Query;");
                        sb.AppendLine(@"        }");
                    }
                }
            }
            sb.AppendLine(@"        #endregion Functions public Generated Get");
            sb.AppendLine(@"");

            return await Task.FromResult(true);
        }
    }
}
