using CSSPEnums;
using GenerateCodeBaseServices.Models;
using System;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ServicesClassNameServiceGeneratedServices.Services
{
    public partial class ServicesClassNameServiceGeneratedService : IServicesClassNameServiceGeneratedService
    {
        private async Task<bool> CreateValidation_Exist(PropertyInfo prop, CSSPProp csspProp, string TypeName, string TypeNameLower, StringBuilder sb, string DBType)
        {
            string db = "";
            if (DBType == "DB")
            {
                db = "db";
            }
            if (DBType == "DBLocal")
            {
                db = "dbLocal";
            }
            if (DBType == "DBLocalIM")
            {
                db = "dbLocalIM";
            }
            string plurial = "s";
            if (TypeName == "Address")
            {
                plurial = "es";
            }

            if (!string.IsNullOrWhiteSpace(csspProp.ExistTypeName) && !string.IsNullOrWhiteSpace(csspProp.ExistPlurial) && !string.IsNullOrWhiteSpace(csspProp.ExistFieldID))
            {
                if (TypeName == "TVItem" && (csspProp.PropName == "ParentID" || csspProp.PropName == "LastUpdateContactTVItemID"))
                {
                    if (DBType == "DB")
                    {
                        sb.AppendLine(@"            if (tvItem.TVType != TVTypeEnum.Root)");
                        sb.AppendLine(@"            {");
                        sb.AppendLine($@"                { csspProp.ExistTypeName } { csspProp.ExistTypeName }{ csspProp.PropName } = null;");
                        sb.AppendLine($@"                { csspProp.ExistTypeName }{ csspProp.PropName } = (from c in db.{ csspProp.ExistTypeName }{ csspProp.ExistPlurial }.AsNoTracking() where c.{ csspProp.ExistFieldID } == { TypeNameLower }.{ csspProp.PropName } select c).FirstOrDefault();");
                        sb.AppendLine(@"");
                        sb.AppendLine($@"                if ({ csspProp.ExistTypeName }{ csspProp.PropName } == null)");
                        sb.AppendLine(@"                {");
                        sb.AppendLine($@"                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, ""{ csspProp.ExistTypeName }"", ""{ csspProp.PropName }"", { TypeNameLower }.{ csspProp.PropName }.ToString()), new[] {{ nameof({ TypeNameLower }.{ csspProp.PropName }) }});");
                        sb.AppendLine(@"                }");
                        if (csspProp.ExistTypeName == "TVItem")
                        {
                            sb.AppendLine(@"                else");
                            sb.AppendLine(@"                {");
                            sb.AppendLine(@"                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()");
                            sb.AppendLine(@"                    {");
                            foreach (TVTypeEnum tvType in csspProp.AllowableTVTypeList)
                            {
                                sb.AppendLine($@"                        TVTypeEnum.{ tvType },");
                            }
                            sb.AppendLine(@"                    };");
                            sb.AppendLine($@"                    if (!AllowableTVTypes.Contains({ csspProp.ExistTypeName }{ csspProp.PropName }.TVType))");
                            sb.AppendLine(@"                    {");
                            sb.AppendLine($@"                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, ""{ csspProp.PropName }"", ""{ String.Join(",", csspProp.AllowableTVTypeList) }""), new[] {{ nameof({ TypeNameLower }.{ csspProp.PropName }) }});");
                            sb.AppendLine(@"                    }");
                            sb.AppendLine(@"                }");
                        }
                        sb.AppendLine(@"            }");
                        sb.AppendLine(@"");
                    }
                    if (DBType == "DBLocal")
                    {
                        sb.AppendLine(@"            if (tvItem.TVType != TVTypeEnum.Root)");
                        sb.AppendLine(@"            {");
                        sb.AppendLine($@"                { csspProp.ExistTypeName } { csspProp.ExistTypeName }{ csspProp.PropName } = null;");
                        sb.AppendLine($@"                { csspProp.ExistTypeName }{ csspProp.PropName } = (from c in dbLocal.{ csspProp.ExistTypeName }{ csspProp.ExistPlurial }.AsNoTracking() where c.{ csspProp.ExistFieldID } == { TypeNameLower }.{ csspProp.PropName } select c).FirstOrDefault();");
                        sb.AppendLine(@"");
                        sb.AppendLine($@"                if ({ csspProp.ExistTypeName }{ csspProp.PropName } == null)");
                        sb.AppendLine(@"                {");
                        sb.AppendLine($@"                    { csspProp.ExistTypeName }{ csspProp.PropName } = (from c in dbLocalIM.{ csspProp.ExistTypeName }{ csspProp.ExistPlurial }.Local where c.{ csspProp.ExistFieldID } == { TypeNameLower }.{ csspProp.PropName } select c).FirstOrDefault();");
                        sb.AppendLine(@"");           
                        sb.AppendLine($@"                    if ({ csspProp.ExistTypeName }{ csspProp.PropName } == null)");
                        sb.AppendLine(@"                    {");
                        sb.AppendLine($@"                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, ""{ csspProp.ExistTypeName }"", ""{ csspProp.PropName }"", { TypeNameLower }.{ csspProp.PropName }.ToString()), new[] {{ nameof({ TypeNameLower }.{ csspProp.PropName }) }});");
                        sb.AppendLine(@"                    }");
                        if (csspProp.ExistTypeName == "TVItem")
                        {
                            sb.AppendLine(@"                    else");
                            sb.AppendLine(@"                    {");
                            sb.AppendLine(@"                        List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()");
                            sb.AppendLine(@"                        {");
                            foreach (TVTypeEnum tvType in csspProp.AllowableTVTypeList)
                            {
                                sb.AppendLine($@"                            TVTypeEnum.{ tvType },");
                            }
                            sb.AppendLine(@"                        };");
                            sb.AppendLine($@"                        if (!AllowableTVTypes.Contains({ csspProp.ExistTypeName }{ csspProp.PropName }.TVType))");
                            sb.AppendLine(@"                        {");
                            sb.AppendLine($@"                            yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, ""{ csspProp.PropName }"", ""{ String.Join(",", csspProp.AllowableTVTypeList) }""), new[] {{ nameof({ TypeNameLower }.{ csspProp.PropName }) }});");
                            sb.AppendLine(@"                        }");
                            sb.AppendLine(@"                    }");
                        }                                 
                        sb.AppendLine(@"                }");
                        if (csspProp.ExistTypeName == "TVItem")
                        {
                            sb.AppendLine(@"                else");
                            sb.AppendLine(@"                {");
                            sb.AppendLine(@"                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()");
                            sb.AppendLine(@"                    {");
                            foreach (TVTypeEnum tvType in csspProp.AllowableTVTypeList)
                            {
                                sb.AppendLine($@"                        TVTypeEnum.{ tvType },");
                            }
                            sb.AppendLine(@"                    };");
                            sb.AppendLine($@"                    if (!AllowableTVTypes.Contains({ csspProp.ExistTypeName }{ csspProp.PropName }.TVType))");
                            sb.AppendLine(@"                    {");
                            sb.AppendLine($@"                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, ""{ csspProp.PropName }"", ""{ String.Join(",", csspProp.AllowableTVTypeList) }""), new[] {{ nameof({ TypeNameLower }.{ csspProp.PropName }) }});");
                            sb.AppendLine(@"                    }");
                            sb.AppendLine(@"                }");
                        }
                        sb.AppendLine(@"            }");
                        sb.AppendLine(@"");
                    }
                    if (DBType == "DBLocalIM")
                    {
                        sb.AppendLine(@"            if (tvItem.TVType != TVTypeEnum.Root)");
                        sb.AppendLine(@"            {");
                        sb.AppendLine($@"                { csspProp.ExistTypeName } { csspProp.ExistTypeName }{ csspProp.PropName } = null;");
                        sb.AppendLine($@"                { csspProp.ExistTypeName }{ csspProp.PropName } = (from c in dbLocalIM.{ csspProp.ExistTypeName }{ csspProp.ExistPlurial }.Local where c.{ csspProp.ExistFieldID } == { TypeNameLower }.{ csspProp.PropName } select c).FirstOrDefault();");
                        sb.AppendLine(@"");
                        sb.AppendLine($@"                if ({ csspProp.ExistTypeName }{ csspProp.PropName } == null)");
                        sb.AppendLine(@"                {");
                        sb.AppendLine($@"                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, ""{ csspProp.ExistTypeName }"", ""{ csspProp.PropName }"", { TypeNameLower }.{ csspProp.PropName }.ToString()), new[] {{ nameof({ TypeNameLower }.{ csspProp.PropName }) }});");
                        sb.AppendLine(@"                }");
                        if (csspProp.ExistTypeName == "TVItem")
                        {
                            sb.AppendLine(@"                else");
                            sb.AppendLine(@"                {");
                            sb.AppendLine(@"                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()");
                            sb.AppendLine(@"                    {");
                            foreach (TVTypeEnum tvType in csspProp.AllowableTVTypeList)
                            {
                                sb.AppendLine($@"                        TVTypeEnum.{ tvType },");
                            }
                            sb.AppendLine(@"                    };");
                            sb.AppendLine($@"                    if (!AllowableTVTypes.Contains({ csspProp.ExistTypeName }{ csspProp.PropName }.TVType))");
                            sb.AppendLine(@"                    {");
                            sb.AppendLine($@"                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, ""{ csspProp.PropName }"", ""{ String.Join(",", csspProp.AllowableTVTypeList) }""), new[] {{ nameof({ TypeNameLower }.{ csspProp.PropName }) }});");
                            sb.AppendLine(@"                    }");
                            sb.AppendLine(@"                }");
                        }
                        sb.AppendLine(@"            }");
                        sb.AppendLine(@"");
                    }
                }
                else
                {
                    if (csspProp.IsNullable)
                    {
                        if (DBType == "DB")
                        {
                            sb.AppendLine($@"            if ({ TypeNameLower }.{ csspProp.PropName } != null)");
                            sb.AppendLine(@"            {");
                            sb.AppendLine($@"                { csspProp.ExistTypeName } { csspProp.ExistTypeName }{ csspProp.PropName } = null;");
                            sb.AppendLine($@"                { csspProp.ExistTypeName }{ csspProp.PropName } = (from c in db.{ csspProp.ExistTypeName }{ csspProp.ExistPlurial }.AsNoTracking() where c.{ csspProp.ExistFieldID } == { TypeNameLower }.{ csspProp.PropName } select c).FirstOrDefault();");
                            sb.AppendLine(@"");
                            sb.AppendLine($@"                if ({ csspProp.ExistTypeName }{ csspProp.PropName } == null)");
                            sb.AppendLine(@"                {");
                            sb.AppendLine($@"                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, ""{ csspProp.ExistTypeName }"", ""{ csspProp.PropName }"", ({ TypeNameLower }.{ csspProp.PropName } == null ? """" : { TypeNameLower }.{ csspProp.PropName }.ToString())), new[] {{ nameof({ TypeNameLower }.{ csspProp.PropName }) }});");
                            sb.AppendLine(@"                }");
                            if (csspProp.ExistTypeName == "TVItem")
                            {
                                sb.AppendLine(@"                else");
                                sb.AppendLine(@"                {");
                                sb.AppendLine(@"                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()");
                                sb.AppendLine(@"                    {");
                                foreach (TVTypeEnum tvType in csspProp.AllowableTVTypeList)
                                {
                                    sb.AppendLine($@"                        TVTypeEnum.{ tvType },");
                                }
                                sb.AppendLine(@"                    };");
                                sb.AppendLine($@"                    if (!AllowableTVTypes.Contains({ csspProp.ExistTypeName }{ csspProp.PropName }.TVType))");
                                sb.AppendLine(@"                    {");
                                sb.AppendLine($@"                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, ""{ csspProp.PropName }"", ""{ String.Join(",", csspProp.AllowableTVTypeList) }""), new[] {{ nameof({ TypeNameLower }.{ csspProp.PropName }) }});");
                                sb.AppendLine(@"                    }");
                                sb.AppendLine(@"                }");
                            }
                            sb.AppendLine(@"            }");
                            sb.AppendLine(@"");
                        }
                        if (DBType == "DBLocal")
                        {
                            sb.AppendLine($@"            if ({ TypeNameLower }.{ csspProp.PropName } != null)");
                            sb.AppendLine(@"            {");
                            sb.AppendLine($@"                { csspProp.ExistTypeName } { csspProp.ExistTypeName }{ csspProp.PropName } = null;");
                            sb.AppendLine($@"                { csspProp.ExistTypeName }{ csspProp.PropName } = (from c in dbLocal.{ csspProp.ExistTypeName }{ csspProp.ExistPlurial }.AsNoTracking() where c.{ csspProp.ExistFieldID } == { TypeNameLower }.{ csspProp.PropName } select c).FirstOrDefault();");
                            sb.AppendLine(@"");
                            sb.AppendLine($@"                if ({ csspProp.ExistTypeName }{ csspProp.PropName } == null)");
                            sb.AppendLine(@"                {");
                            sb.AppendLine($@"                    if ({ TypeNameLower }.{ csspProp.PropName } != null)");
                            sb.AppendLine(@"                    {");
                            sb.AppendLine($@"                        { csspProp.ExistTypeName }{ csspProp.PropName } = (from c in dbLocalIM.{ csspProp.ExistTypeName }{ csspProp.ExistPlurial }.Local where c.{ csspProp.ExistFieldID } == { TypeNameLower }.{ csspProp.PropName } select c).FirstOrDefault();");
                            sb.AppendLine(@"");            
                            sb.AppendLine($@"                        if ({ csspProp.ExistTypeName }{ csspProp.PropName } == null)");
                            sb.AppendLine(@"                        {");
                            sb.AppendLine($@"                            yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, ""{ csspProp.ExistTypeName }"", ""{ csspProp.PropName }"", ({ TypeNameLower }.{ csspProp.PropName } == null ? """" : { TypeNameLower }.{ csspProp.PropName }.ToString())), new[] {{ nameof({ TypeNameLower }.{ csspProp.PropName }) }});");
                            sb.AppendLine(@"                        }");
                            if (csspProp.ExistTypeName == "TVItem")
                            {
                                sb.AppendLine(@"                        else");
                                sb.AppendLine(@"                        {");
                                sb.AppendLine(@"                            List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()");
                                sb.AppendLine(@"                            {");
                                foreach (TVTypeEnum tvType in csspProp.AllowableTVTypeList)
                                {
                                    sb.AppendLine($@"                                TVTypeEnum.{ tvType },");
                                }
                                sb.AppendLine(@"                            };");
                                sb.AppendLine($@"                            if (!AllowableTVTypes.Contains({ csspProp.ExistTypeName }{ csspProp.PropName }.TVType))");
                                sb.AppendLine(@"                            {");
                                sb.AppendLine($@"                                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, ""{ csspProp.PropName }"", ""{ String.Join(",", csspProp.AllowableTVTypeList) }""), new[] {{ nameof({ TypeNameLower }.{ csspProp.PropName }) }});");
                                sb.AppendLine(@"                            }");
                                sb.AppendLine(@"                        }");
                            }                                
                            sb.AppendLine(@"                    }");
                            sb.AppendLine(@"                }");
                            if (csspProp.ExistTypeName == "TVItem")
                            {
                                sb.AppendLine(@"                else");
                                sb.AppendLine(@"                {");
                                sb.AppendLine(@"                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()");
                                sb.AppendLine(@"                    {");
                                foreach (TVTypeEnum tvType in csspProp.AllowableTVTypeList)
                                {
                                    sb.AppendLine($@"                        TVTypeEnum.{ tvType },");
                                }
                                sb.AppendLine(@"                    };");
                                sb.AppendLine($@"                    if (!AllowableTVTypes.Contains({ csspProp.ExistTypeName }{ csspProp.PropName }.TVType))");
                                sb.AppendLine(@"                    {");
                                sb.AppendLine($@"                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, ""{ csspProp.PropName }"", ""{ String.Join(",", csspProp.AllowableTVTypeList) }""), new[] {{ nameof({ TypeNameLower }.{ csspProp.PropName }) }});");
                                sb.AppendLine(@"                    }");
                                sb.AppendLine(@"                }");
                            }
                            sb.AppendLine(@"            }");
                            sb.AppendLine(@"");
                        }
                        if (DBType == "DBLocalIM")
                        {
                            sb.AppendLine($@"            if ({ TypeNameLower }.{ csspProp.PropName } != null)");
                            sb.AppendLine(@"            {");
                            sb.AppendLine($@"                { csspProp.ExistTypeName } { csspProp.ExistTypeName }{ csspProp.PropName } = null;");
                            sb.AppendLine($@"                { csspProp.ExistTypeName }{ csspProp.PropName } = (from c in dbLocalIM.{ csspProp.ExistTypeName }{ csspProp.ExistPlurial }.Local where c.{ csspProp.ExistFieldID } == { TypeNameLower }.{ csspProp.PropName } select c).FirstOrDefault();");
                            sb.AppendLine(@"");
                            sb.AppendLine($@"                if ({ csspProp.ExistTypeName }{ csspProp.PropName } == null)");
                            sb.AppendLine(@"                {");
                            sb.AppendLine($@"                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, ""{ csspProp.ExistTypeName }"", ""{ csspProp.PropName }"", ({ TypeNameLower }.{ csspProp.PropName } == null ? """" : { TypeNameLower }.{ csspProp.PropName }.ToString())), new[] {{ nameof({ TypeNameLower }.{ csspProp.PropName }) }});");
                            sb.AppendLine(@"                }");
                            if (csspProp.ExistTypeName == "TVItem")
                            {
                                sb.AppendLine(@"                else");
                                sb.AppendLine(@"                {");
                                sb.AppendLine(@"                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()");
                                sb.AppendLine(@"                    {");
                                foreach (TVTypeEnum tvType in csspProp.AllowableTVTypeList)
                                {
                                    sb.AppendLine($@"                        TVTypeEnum.{ tvType },");
                                }
                                sb.AppendLine(@"                    };");
                                sb.AppendLine($@"                    if (!AllowableTVTypes.Contains({ csspProp.ExistTypeName }{ csspProp.PropName }.TVType))");
                                sb.AppendLine(@"                    {");
                                sb.AppendLine($@"                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, ""{ csspProp.PropName }"", ""{ String.Join(",", csspProp.AllowableTVTypeList) }""), new[] {{ nameof({ TypeNameLower }.{ csspProp.PropName }) }});");
                                sb.AppendLine(@"                    }");
                                sb.AppendLine(@"                }");
                            }
                            sb.AppendLine(@"            }");
                            sb.AppendLine(@"");
                        }
                    }
                    else
                    {
                        if (DBType == "DB")
                        {
                            sb.AppendLine($@"            { csspProp.ExistTypeName } { csspProp.ExistTypeName }{ csspProp.PropName } = null;");
                            sb.AppendLine($@"            { csspProp.ExistTypeName }{ csspProp.PropName } = (from c in db.{ csspProp.ExistTypeName }{ csspProp.ExistPlurial }.AsNoTracking() where c.{ csspProp.ExistFieldID } == { TypeNameLower }.{ csspProp.PropName } select c).FirstOrDefault();");
                            sb.AppendLine(@"");
                            sb.AppendLine($@"            if ({ csspProp.ExistTypeName }{ csspProp.PropName } == null)");
                            sb.AppendLine(@"            {");
                            if (TypeName == "Contact" && csspProp.PropName == "Id")
                            {
                                sb.AppendLine($@"                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, ""{ csspProp.ExistTypeName }"", ""{ csspProp.PropName }"", ({ TypeNameLower }.{ csspProp.PropName } == null ? """" : { TypeNameLower }.{ csspProp.PropName }.ToString())), new[] {{ nameof({ TypeNameLower }.{ csspProp.PropName }) }});");
                            }
                            else
                            {
                                sb.AppendLine($@"                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, ""{ csspProp.ExistTypeName }"", ""{ csspProp.PropName }"", { TypeNameLower }.{ csspProp.PropName }.ToString()), new[] {{ nameof({ TypeNameLower }.{ csspProp.PropName }) }});");
                            }
                            sb.AppendLine(@"            }");
                            if (csspProp.ExistTypeName == "TVItem")
                            {
                                sb.AppendLine(@"            else");
                                sb.AppendLine(@"            {");
                                sb.AppendLine(@"                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()");
                                sb.AppendLine(@"                {");
                                foreach (TVTypeEnum tvType in csspProp.AllowableTVTypeList)
                                {
                                    sb.AppendLine($@"                    TVTypeEnum.{ tvType },");
                                }
                                sb.AppendLine(@"                };");
                                sb.AppendLine($@"                if (!AllowableTVTypes.Contains({ csspProp.ExistTypeName }{ csspProp.PropName }.TVType))");
                                sb.AppendLine(@"                {");
                                sb.AppendLine($@"                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, ""{ csspProp.PropName }"", ""{ String.Join(",", csspProp.AllowableTVTypeList) }""), new[] {{ nameof({ TypeNameLower }.{ csspProp.PropName }) }});");
                                sb.AppendLine(@"                }");
                                sb.AppendLine(@"            }");
                            }
                            sb.AppendLine(@"");
                        }
                        if (DBType == "DBLocal")
                        {
                            sb.AppendLine($@"            { csspProp.ExistTypeName } { csspProp.ExistTypeName }{ csspProp.PropName } = null;");
                            sb.AppendLine($@"            { csspProp.ExistTypeName }{ csspProp.PropName } = (from c in dbLocal.{ csspProp.ExistTypeName }{ csspProp.ExistPlurial }.AsNoTracking() where c.{ csspProp.ExistFieldID } == { TypeNameLower }.{ csspProp.PropName } select c).FirstOrDefault();");
                            sb.AppendLine(@"");
                            sb.AppendLine($@"            if ({ csspProp.ExistTypeName }{ csspProp.PropName } == null)");
                            sb.AppendLine(@"            {");
                            sb.AppendLine($@"                { csspProp.ExistTypeName }{ csspProp.PropName } = (from c in dbLocalIM.{ csspProp.ExistTypeName }{ csspProp.ExistPlurial }.Local where c.{ csspProp.ExistFieldID } == { TypeNameLower }.{ csspProp.PropName } select c).FirstOrDefault();");
                            sb.AppendLine(@"");      
                            sb.AppendLine($@"                if ({ csspProp.ExistTypeName }{ csspProp.PropName } == null)");
                            sb.AppendLine(@"                {");
                            if (TypeName == "Contact" && csspProp.PropName == "Id")
                            {
                                sb.AppendLine($@"                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, ""{ csspProp.ExistTypeName }"", ""{ csspProp.PropName }"", ({ TypeNameLower }.{ csspProp.PropName } == null ? """" : { TypeNameLower }.{ csspProp.PropName }.ToString())), new[] {{ nameof({ TypeNameLower }.{ csspProp.PropName }) }});");
                            }
                            else
                            {
                                sb.AppendLine($@"                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, ""{ csspProp.ExistTypeName }"", ""{ csspProp.PropName }"", { TypeNameLower }.{ csspProp.PropName }.ToString()), new[] {{ nameof({ TypeNameLower }.{ csspProp.PropName }) }});");
                            }
                            sb.AppendLine(@"                }");
                            if (csspProp.ExistTypeName == "TVItem")
                            {
                                sb.AppendLine(@"                else");
                                sb.AppendLine(@"                {");
                                sb.AppendLine(@"                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()");
                                sb.AppendLine(@"                    {");
                                foreach (TVTypeEnum tvType in csspProp.AllowableTVTypeList)
                                {
                                    sb.AppendLine($@"                        TVTypeEnum.{ tvType },");
                                }
                                sb.AppendLine(@"                    };");
                                sb.AppendLine($@"                    if (!AllowableTVTypes.Contains({ csspProp.ExistTypeName }{ csspProp.PropName }.TVType))");
                                sb.AppendLine(@"                    {");
                                sb.AppendLine($@"                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, ""{ csspProp.PropName }"", ""{ String.Join(",", csspProp.AllowableTVTypeList) }""), new[] {{ nameof({ TypeNameLower }.{ csspProp.PropName }) }});");
                                sb.AppendLine(@"                    }");
                                sb.AppendLine(@"                }");
                            }
                            sb.AppendLine(@"");
                            sb.AppendLine(@"            }");
                            if (csspProp.ExistTypeName == "TVItem")
                            {
                                sb.AppendLine(@"            else");
                                sb.AppendLine(@"            {");
                                sb.AppendLine(@"                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()");
                                sb.AppendLine(@"                {");
                                foreach (TVTypeEnum tvType in csspProp.AllowableTVTypeList)
                                {
                                    sb.AppendLine($@"                    TVTypeEnum.{ tvType },");
                                }
                                sb.AppendLine(@"                };");
                                sb.AppendLine($@"                if (!AllowableTVTypes.Contains({ csspProp.ExistTypeName }{ csspProp.PropName }.TVType))");
                                sb.AppendLine(@"                {");
                                sb.AppendLine($@"                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, ""{ csspProp.PropName }"", ""{ String.Join(",", csspProp.AllowableTVTypeList) }""), new[] {{ nameof({ TypeNameLower }.{ csspProp.PropName }) }});");
                                sb.AppendLine(@"                }");
                                sb.AppendLine(@"            }");
                            }
                            sb.AppendLine(@"");
                        }
                        if (DBType == "DBLocalIM")
                        {
                            sb.AppendLine($@"            { csspProp.ExistTypeName } { csspProp.ExistTypeName }{ csspProp.PropName } = null;");
                            sb.AppendLine($@"            { csspProp.ExistTypeName }{ csspProp.PropName } = (from c in dbLocalIM.{ csspProp.ExistTypeName }{ csspProp.ExistPlurial }.Local where c.{ csspProp.ExistFieldID } == { TypeNameLower }.{ csspProp.PropName } select c).FirstOrDefault();");
                            sb.AppendLine(@"");
                            sb.AppendLine($@"            if ({ csspProp.ExistTypeName }{ csspProp.PropName } == null)");
                            sb.AppendLine(@"            {");
                            if (TypeName == "Contact" && csspProp.PropName == "Id")
                            {
                                sb.AppendLine($@"                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, ""{ csspProp.ExistTypeName }"", ""{ csspProp.PropName }"", ({ TypeNameLower }.{ csspProp.PropName } == null ? """" : { TypeNameLower }.{ csspProp.PropName }.ToString())), new[] {{ nameof({ TypeNameLower }.{ csspProp.PropName }) }});");
                            }
                            else
                            {
                                sb.AppendLine($@"                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, ""{ csspProp.ExistTypeName }"", ""{ csspProp.PropName }"", { TypeNameLower }.{ csspProp.PropName }.ToString()), new[] {{ nameof({ TypeNameLower }.{ csspProp.PropName }) }});");
                            }
                            sb.AppendLine(@"            }");
                            if (csspProp.ExistTypeName == "TVItem")
                            {
                                sb.AppendLine(@"            else");
                                sb.AppendLine(@"            {");
                                sb.AppendLine(@"                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()");
                                sb.AppendLine(@"                {");
                                foreach (TVTypeEnum tvType in csspProp.AllowableTVTypeList)
                                {
                                    sb.AppendLine($@"                    TVTypeEnum.{ tvType },");
                                }
                                sb.AppendLine(@"                };");
                                sb.AppendLine($@"                if (!AllowableTVTypes.Contains({ csspProp.ExistTypeName }{ csspProp.PropName }.TVType))");
                                sb.AppendLine(@"                {");
                                sb.AppendLine($@"                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, ""{ csspProp.PropName }"", ""{ String.Join(",", csspProp.AllowableTVTypeList) }""), new[] {{ nameof({ TypeNameLower }.{ csspProp.PropName }) }});");
                                sb.AppendLine(@"                }");
                                sb.AppendLine(@"            }");
                            }
                            sb.AppendLine(@"");
                        }
                    }
                }
            }

            return await Task.FromResult(true);
        }
    }
}
