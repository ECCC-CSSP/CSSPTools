using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Forms;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Reflection;
using System.IO;
using CSSPModels;
using CSSPEnums;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;
using CSSPGenerateCodeBase;

namespace CSSPServicesGenerateCodeHelper
{
    public partial class ServicesCodeWriter
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        // constructor was done in the ServicesGenerateCodeHelper.cs file
        #endregion Constructors

        #region Functions private
        /// <summary>
        ///     <code>
        ///         Write function of class name and Try Save part
        ///     </code>       
        /// </summary>
        /// <param name="dllTypeInfo">Current model type</param>
        /// <param name="types">List of existing model types</param>
        /// <param name="TypeName">Current model type name</param>
        /// <param name="TypeNameLower">Current model type name with first letter lowercase</param>
        /// <param name="sb">StringBuilder holding the text of the file being created</param>
        private void CreateClassServiceFunctionsPrivateRegionTrySave(DLLTypeInfo dllTypeInfo, string TypeName, string TypeNameLower, StringBuilder sb, bool WithDoc)
        {
            sb.AppendLine(@"        #region Functions private Generated TryToSave");

            if (WithDoc) //------------------------------------------------------------------ help
            {
                sb.AppendLine($@"        /// <summary>");
                sb.AppendLine($@"        /// Tries to execute the CSSPDB transaction (add/delete/update) on an [{ TypeName }](CSSPModels.{ TypeName }.html) item");
                sb.AppendLine($@"        /// </summary>");
                sb.AppendLine($@"        /// <param name=""{ TypeNameLower }"">Is the { TypeName } item the client want to add to CSSPDB. What's important here is the { TypeName }ID</param>");
                sb.AppendLine($@"        /// <returns>true if { TypeName } item was updated to CSSPDB, false if an error happened during the DB requested transtaction</returns>");
            }

            sb.AppendLine($@"        private bool TryToSave({ TypeName } { TypeNameLower })");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            try");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                db.SaveChanges();");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"            catch (DbUpdateException ex)");
            sb.AppendLine(@"            {");
            sb.AppendLine($@"                { TypeNameLower }.ValidationResults = new List<ValidationResult>() {{ new ValidationResult(ex.Message + (ex.InnerException != null ? "" Inner: "" + ex.InnerException.Message : """")) }}.AsEnumerable();");
            sb.AppendLine(@"                return false;");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"");
            sb.AppendLine(@"            return true;");
            sb.AppendLine(@"        }");
            sb.AppendLine(@"        #endregion Functions private Generated TryToSave");
            sb.AppendLine(@"");
        }
        /// <summary>
        ///     <code>
        ///         Write function of class name CRUD part
        ///     </code>       
        /// </summary>
        /// <param name="dllTypeInto">Current model type</param>
        /// <param name="TypeName">Current model type name</param>
        /// <param name="TypeNameLower">Current model type name with first letter lowercase</param>
        /// <param name="sb">StringBuilder holding the text of the file being created</param>
        private void CreateClassServiceFunctionsPublicGenerateCRUD(DLLTypeInfo dllTypeInto, string TypeName, string TypeNameLower, StringBuilder sb, bool WithDoc)
        {
            List<string> TypeNameWithPlurial_es = new List<string>() { "Address", };

            string Plurial = "s";
            if (TypeNameWithPlurial_es.Contains(TypeName))
            {
                Plurial = "es";
            }

            sb.AppendLine(@"        #region Functions public Generated CRUD");

            if (WithDoc) //------------------------------------------------------------------ help
            {
                sb.AppendLine($@"        /// <summary>");
                sb.AppendLine($@"        /// Adds an [{ TypeName }](CSSPModels.{ TypeName }.html) item in CSSPDB");
                sb.AppendLine($@"        /// </summary>");
                sb.AppendLine($@"        /// <param name=""{ TypeNameLower }"">Is the { TypeName } item the client want to add to CSSPDB</param>");
                if (TypeName == "Contact")
                {
                    sb.AppendLine($@"        /// <param name=""addContactType"">[AddContactTypeEnum] (CSSPEnums.AddContactTypeEnum.html) use when adding a new contact</param>");
                }
                sb.AppendLine($@"        /// <returns>true if { TypeName } item was added to CSSPDB, false if an error happened during the DB requested transtaction</returns>");
            }

            if (TypeName == "Contact")
            {
                sb.AppendLine($@"        public bool Add({ TypeName } { TypeNameLower }, AddContactTypeEnum addContactType)");
            }
            else
            {
                sb.AppendLine($@"        public bool Add({ TypeName } { TypeNameLower })");
            }
            sb.AppendLine(@"        {");
            if (TypeName == "Contact")
            {
                sb.AppendLine($@"            { TypeNameLower }.ValidationResults = Validate(new ValidationContext({ TypeNameLower }), ActionDBTypeEnum.Create, addContactType);");
            }
            else
            {
                sb.AppendLine($@"            { TypeNameLower }.ValidationResults = Validate(new ValidationContext({ TypeNameLower }), ActionDBTypeEnum.Create);");
            }
            sb.AppendLine($@"            if ({ TypeNameLower }.ValidationResults.Count() > 0) return false;");
            sb.AppendLine(@"");
            sb.AppendLine($@"            db.{ TypeName }{ Plurial }.Add({ TypeNameLower });");
            sb.AppendLine(@"");
            sb.AppendLine($@"            if (!TryToSave({ TypeNameLower })) return false;");
            sb.AppendLine(@"");
            sb.AppendLine(@"            return true;");
            sb.AppendLine(@"        }");

            if (WithDoc) //------------------------------------------------------------------ help
            {
                sb.AppendLine($@"        /// <summary>");
                sb.AppendLine($@"        /// Deletes an [{ TypeName }](CSSPModels.{ TypeName }.html) item in CSSPDB");
                sb.AppendLine($@"        /// </summary>");
                sb.AppendLine($@"        /// <param name=""{ TypeNameLower }"">Is the { TypeName } item the client want to add to CSSPDB. What's important here is the { TypeName }ID</param>");
                sb.AppendLine($@"        /// <returns>true if { TypeName } item was deleted to CSSPDB, false if an error happened during the DB requested transtaction</returns>");
            }

            sb.AppendLine($@"        public bool Delete({ TypeName } { TypeNameLower })");
            sb.AppendLine(@"        {");
            if (TypeName == "Contact")
            {
                sb.AppendLine($@"            { TypeNameLower }.ValidationResults = Validate(new ValidationContext({ TypeNameLower }), ActionDBTypeEnum.Update, AddContactTypeEnum.LoggedIn);");
            }
            else
            {
                sb.AppendLine($@"            { TypeNameLower }.ValidationResults = Validate(new ValidationContext({ TypeNameLower }), ActionDBTypeEnum.Delete);");
            }
            sb.AppendLine($@"            if ({ TypeNameLower }.ValidationResults.Count() > 0) return false;");
            sb.AppendLine(@"");
            sb.AppendLine($@"            db.{ TypeName }{ Plurial }.Remove({ TypeNameLower });");
            sb.AppendLine(@"");
            sb.AppendLine($@"            if (!TryToSave({ TypeNameLower })) return false;");
            sb.AppendLine(@"");
            sb.AppendLine(@"            return true;");
            sb.AppendLine(@"        }");

            if (WithDoc) //------------------------------------------------------------------ help
            {
                sb.AppendLine($@"        /// <summary>");
                sb.AppendLine($@"        /// Updates an [{ TypeName }](CSSPModels.{ TypeName }.html) item in CSSPDB");
                sb.AppendLine($@"        /// </summary>");
                sb.AppendLine($@"        /// <param name=""{ TypeNameLower }"">Is the { TypeName } item the client want to add to CSSPDB. What's important here is the { TypeName }ID</param>");
                sb.AppendLine($@"        /// <returns>true if { TypeName } item was updated to CSSPDB, false if an error happened during the DB requested transtaction</returns>");
            }

            sb.AppendLine($@"        public bool Update({ TypeName } { TypeNameLower })");
            sb.AppendLine(@"        {");
            if (TypeName == "Contact")
            {
                sb.AppendLine($@"            { TypeNameLower }.ValidationResults = Validate(new ValidationContext({ TypeNameLower }), ActionDBTypeEnum.Update, AddContactTypeEnum.LoggedIn);");
            }
            else
            {
                sb.AppendLine($@"            { TypeNameLower }.ValidationResults = Validate(new ValidationContext({ TypeNameLower }), ActionDBTypeEnum.Update);");
            }
            sb.AppendLine($@"            if ({ TypeNameLower }.ValidationResults.Count() > 0) return false;");
            sb.AppendLine(@"");
            sb.AppendLine($@"            db.{ TypeName }{ Plurial }.Update({ TypeNameLower });");
            sb.AppendLine(@"");
            sb.AppendLine($@"            if (!TryToSave({ TypeNameLower })) return false;");
            sb.AppendLine(@"");
            sb.AppendLine(@"            return true;");
            sb.AppendLine(@"        }");
            sb.AppendLine(@"        #endregion Functions public Generated CRUD");
            sb.AppendLine(@"");
        }
        /// <summary>
        ///     <code>
        ///         Write function of class name Get with ID and Get List
        ///     </code>       
        /// </summary>
        /// <param name="dllTypeInfo">Current model type</param>
        /// <param name="TypeName">Current model type name</param>
        /// <param name="TypeNameLower">Current model type name with first letter lowercase</param>
        /// <param name="sb">StringBuilder holding the text of the file being created</param>
        private void CreateClassServiceFunctionsPublicGenerateGet(DLLTypeInfo dllTypeInfo, List<DLLTypeInfo> DLLTypeInfoCSSPModelsList, string TypeName, string TypeNameLower, StringBuilder sb, bool WithDoc)
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
                if (!modelsGenerateCodeHelper.FillCSSPProp(dllPropertyInfo.PropertyInfo, csspProp, dllTypeInfo.Type))
                {
                    CSSPErrorEvent(new CSSPErrorEventArgs($"CSSPError while creating code [{ csspProp.CSSPError }]"));
                    return;
                }
                if (csspProp.IsKey)
                {
                    DLLTypeInfo currentDLLTypeInfo = null;
                    foreach (DLLTypeInfo dllTypeInfo2 in DLLTypeInfoCSSPModelsList)
                    {
                        if (dllTypeInfo2.Name == TypeName)
                        {
                            currentDLLTypeInfo = dllTypeInfo2;
                        }
                    }

                    if (currentDLLTypeInfo == null)
                    {
                        continue;
                    }

                    if (WithDoc) //------------------------------------------------------------------ help
                    {
                        sb.AppendLine(@"        /// <summary>");
                        sb.AppendLine($@"        /// Gets the { currentDLLTypeInfo.Name } model with the { TypeName }ID identifier");
                        sb.AppendLine(@"        /// </summary>");
                        if (currentDLLTypeInfo.Name == "AspNetUser")
                        {
                            sb.AppendLine($@"        /// <param name=""Id"">Is the identifier of [AspNetUsers](CSSPModels.AspNetUser.html) table of CSSPDB</param>");
                        }
                        else
                        {
                            if (currentDLLTypeInfo.Name.StartsWith("Address"))
                            {
                                sb.AppendLine($@"        /// <param name=""{ TypeName }ID"">Is the identifier of [{ TypeName }es](CSSPModels.{ TypeName }.html) table of CSSPDB</param>");
                            }
                            else
                            {
                                sb.AppendLine($@"        /// <param name=""{ TypeName }ID"">Is the identifier of [{ TypeName }s](CSSPModels.{ TypeName }.html) table of CSSPDB</param>");
                            }
                        }

                        sb.AppendLine($@"        /// <returns>[{ currentDLLTypeInfo.Name }](CSSPModels.{ currentDLLTypeInfo.Name }.html) object connected to the CSSPDB</returns>");
                    }

                    if (currentDLLTypeInfo.Name == "AspNetUser")
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

                    if (WithDoc) //------------------------------------------------------------------ help
                    {
                        sb.AppendLine(@"        /// <summary>");
                        sb.AppendLine($@"        /// Gets a list of [{ currentDLLTypeInfo.Name }](CSSPModels.{ currentDLLTypeInfo.Name }.html) satisfying the filters in [Query](CSSPModels.Query.html)");
                        sb.AppendLine(@"        /// </summary>");
                        sb.AppendLine($@"        /// <returns>IQueryable of [{ currentDLLTypeInfo.Name }](CSSPModels.{ currentDLLTypeInfo.Name }.html)</returns>");
                    }

                    sb.AppendLine($@"        public IQueryable<{ currentDLLTypeInfo.Name }> Get{ currentDLLTypeInfo.Name }List()");
                    sb.AppendLine(@"        {");
                    if (currentDLLTypeInfo.Name.StartsWith("Address"))
                    {
                        sb.AppendLine($@"            IQueryable<{ currentDLLTypeInfo.Name }> { currentDLLTypeInfo.Name }Query = (from c in db.{ TypeName }es select c);");
                    }
                    else
                    {
                        sb.AppendLine($@"            IQueryable<{ currentDLLTypeInfo.Name }> { currentDLLTypeInfo.Name }Query = (from c in db.{ TypeName }s select c);");
                    }
                    sb.AppendLine(@"");
                    sb.AppendLine($@"            { currentDLLTypeInfo.Name }Query = EnhanceQueryStatements<{ currentDLLTypeInfo.Name }>({ currentDLLTypeInfo.Name }Query) as IQueryable<{ currentDLLTypeInfo.Name }>;");
                    sb.AppendLine(@"");
                    sb.AppendLine($@"            return { currentDLLTypeInfo.Name }Query;");
                    sb.AppendLine(@"        }");

                }
            }
            sb.AppendLine(@"        #endregion Functions public Generated Get");
            sb.AppendLine(@"");
        }
        /// <summary>
        ///     <code>
        ///         Write code part for the current model property validation after year
        ///     </code>       
        /// </summary>
        /// <param name="prop">PropertyInfo of the current class name and property</param>
        /// <param name="csspProp">Holds CSSPProp information about the current class name and property</param>
        /// <param name="TypeName">Current model type name</param>
        /// <param name="TypeNameLower">Current model type name with first letter lowercase</param>
        /// <param name="sb">StringBuilder holding the text of the file being created</param>
        private void CreateValidation_AfterYear(PropertyInfo prop, CSSPProp csspProp, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            if (csspProp.Year != null)
            {
                if (csspProp.IsNullable == true)
                {
                    sb.AppendLine($@"            if ({ TypeNameLower }.{ csspProp.PropName } != null && ((DateTime){ TypeNameLower }.{ csspProp.PropName }).Year < { csspProp.Year })");
                    sb.AppendLine(@"            {");
                    sb.AppendLine($@"                { TypeNameLower }.HasErrors = true;");
                    sb.AppendLine($@"                yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, ""{ csspProp.PropName }"", ""{ csspProp.Year }""), new[] {{ ""{ csspProp.PropName }"" }});");
                    sb.AppendLine(@"            }");
                    sb.AppendLine(@"");
                }
            }
        }
        /// <summary>
        ///     <code>
        ///         Write code part for the current model property validation bigger
        ///     </code>       
        /// </summary>
        /// <param name="prop">PropertyInfo of the current class name and property</param>
        /// <param name="csspProp">Holds CSSPProp information about the current class name and property</param>
        /// <param name="TypeName">Current model type name</param>
        /// <param name="TypeNameLower">Current model type name with first letter lowercase</param>
        /// <param name="sb">StringBuilder holding the text of the file being created</param>
        private void CreateValidation_Bigger(PropertyInfo prop, CSSPProp csspProp, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            if (!string.IsNullOrWhiteSpace(csspProp.OtherField))
            {
                sb.AppendLine($@"            if ({ TypeNameLower }.{ csspProp.OtherField } > { TypeNameLower }.{ csspProp.PropName })");
                sb.AppendLine(@"            {");
                sb.AppendLine($@"                { TypeNameLower }.HasErrors = true;");
                sb.AppendLine($@"                yield return new ValidationResult(string.Format(CSSPServicesRes._DateIsBiggerThan_, ""{ csspProp.PropName }"", ""{ TypeName }{ csspProp.OtherField }""), new[] {{ ""{ csspProp.PropName }"" }});");
                sb.AppendLine(@"            }");
                sb.AppendLine(@"");
            }
        }
        /// <summary>
        ///     <code>
        ///         Write code part for the current model property validation email
        ///     </code>       
        /// </summary>
        /// <param name="prop">PropertyInfo of the current class name and property</param>
        /// <param name="csspProp">Holds CSSPProp information about the current class name and property</param>
        /// <param name="TypeName">Current model type name</param>
        /// <param name="TypeNameLower">Current model type name with first letter lowercase</param>
        /// <param name="sb">StringBuilder holding the text of the file being created</param>
        private void CreateValidation_Email(PropertyInfo prop, CSSPProp csspProp, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            if (csspProp.dataType == DataType.EmailAddress)
            {
                sb.AppendLine($@"            if (!string.IsNullOrWhiteSpace({ TypeNameLower }.{ prop.Name }))");
                sb.AppendLine(@"            {");
                sb.AppendLine(@"                Regex regex = new Regex(@""^([\w\!\#$\%\&\'*\+\-\/\=\?\^`{\|\}\~]+\.)*[\w\!\#$\%\&\'‌​*\+\-\/\=\?\^`{\|\}\~]+@((((([a-zA-Z0-9]{1}[a-zA-Z0-9\-]{0,62}[a-zA-Z0-9]{1})|[‌​a-zA-Z])\.)+[a-zA-Z]{2,6})|(\d{1,3}\.){3}\d{1,3}(\:\d{1,5})?)$"");");
                sb.AppendLine($@"                if (!regex.IsMatch({ TypeNameLower }.{ prop.Name }))");
                sb.AppendLine(@"                {");
                sb.AppendLine($@"                    { TypeNameLower }.HasErrors = true;");
                sb.AppendLine($@"                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotAValidEmail, ""{ prop.Name }""), new[] {{ ""{ csspProp.PropName }"" }});");
                sb.AppendLine(@"                }");
                sb.AppendLine(@"            }");
                sb.AppendLine(@"");
            }
        }
        /// <summary>
        ///     <code>
        ///         Write code part for the current model property validation enum type
        ///     </code>       
        /// </summary>
        /// <param name="prop">PropertyInfo of the current class name and property</param>
        /// <param name="csspProp">Holds CSSPProp information about the current class name and property</param>
        /// <param name="TypeName">Current model type name</param>
        /// <param name="TypeNameLower">Current model type name with first letter lowercase</param>
        /// <param name="sb">StringBuilder holding the text of the file being created</param>
        private void CreateValidation_EnumType(PropertyInfo prop, CSSPProp csspProp, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            if (csspProp.HasCSSPEnumTypeAttribute)
            {
                if (csspProp.IsNullable)
                {
                    sb.AppendLine($@"            if ({ TypeNameLower }.{ prop.Name } != null)");
                    sb.AppendLine(@"            {");
                    sb.AppendLine($@"                retStr = enums.EnumTypeOK(typeof({ csspProp.PropType }), (int?){ TypeNameLower }.{ prop.Name });");
                    sb.AppendLine($@"                if ({ TypeNameLower }.{ prop.Name } == null || !string.IsNullOrWhiteSpace(retStr))");
                    sb.AppendLine(@"                {");
                    sb.AppendLine($@"                    { TypeNameLower }.HasErrors = true;");
                    sb.AppendLine($@"                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, ""{ prop.Name }""), new[] {{ ""{ csspProp.PropName }"" }});");
                    sb.AppendLine(@"                }");
                    sb.AppendLine(@"            }");
                    sb.AppendLine(@"");
                }
                else
                {
                    sb.AppendLine($@"            retStr = enums.EnumTypeOK(typeof({ csspProp.PropType }), (int?){ TypeNameLower }.{ prop.Name });");
                    sb.AppendLine($@"            if (!string.IsNullOrWhiteSpace(retStr))");
                    sb.AppendLine(@"            {");
                    sb.AppendLine($@"                { TypeNameLower }.HasErrors = true;");
                    sb.AppendLine($@"                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, ""{ prop.Name }""), new[] {{ ""{ csspProp.PropName }"" }});");
                    sb.AppendLine(@"            }");
                    sb.AppendLine(@"");
                }
            }
        }
        /// <summary>
        ///     <code>
        ///         Write code part for the current model property validation length
        ///     </code>       
        /// </summary>
        /// <param name="prop">PropertyInfo of the current class name and property</param>
        /// <param name="csspProp">Holds CSSPProp information about the current class name and property</param>
        /// <param name="TypeName">Current model type name</param>
        /// <param name="TypeNameLower">Current model type name with first letter lowercase</param>
        /// <param name="sb">StringBuilder holding the text of the file being created</param>
        private void CreateValidation_Length(PropertyInfo prop, CSSPProp csspProp, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            if (!csspProp.IsKey)
            {
                switch (csspProp.PropType)
                {
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
                    case "Int16":
                    case "Int32":
                    case "Int64":
                    case "Single":
                    case "Double":
                        {
                            if (csspProp.Min == null && csspProp.Max == null)
                            {
                                if (!csspProp.HasCSSPExistAttribute)
                                {
                                    sb.AppendLine($@"            //{ prop.Name } has no Range Attribute");
                                    sb.AppendLine(@"");
                                }
                            }
                            else if (csspProp.Min != null && csspProp.Max != null)
                            {
                                if (csspProp.Min > csspProp.Max)
                                {
                                    sb.AppendLine($@"            { prop.Name } = MinBiggerMaxPleaseFix,");
                                }
                                else
                                {
                                    if (csspProp.IsNullable)
                                    {
                                        sb.AppendLine($@"            if ({ TypeNameLower }.{ csspProp.PropName } != null)");
                                        sb.AppendLine(@"            {");
                                        sb.AppendLine($@"                if ({ TypeNameLower }.{ csspProp.PropName } < { csspProp.Min.ToString() } || { TypeNameLower }.{ csspProp.PropName } > { csspProp.Max.ToString() })");
                                        sb.AppendLine(@"                {");
                                        sb.AppendLine($@"                    { TypeNameLower }.HasErrors = true;");
                                        sb.AppendLine($@"                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, ""{ csspProp.PropName }"", ""{ csspProp.Min.ToString() }"", ""{ csspProp.Max.ToString() }""), new[] {{ ""{ csspProp.PropName }"" }});");
                                        sb.AppendLine(@"                }");
                                        sb.AppendLine(@"            }");
                                        sb.AppendLine(@"");
                                    }
                                    else
                                    {
                                        sb.AppendLine($@"            if ({ TypeNameLower }.{ csspProp.PropName } < { csspProp.Min.ToString() } || { TypeNameLower }.{ csspProp.PropName } > { csspProp.Max.ToString() })");
                                        sb.AppendLine(@"            {");
                                        sb.AppendLine($@"                { TypeNameLower }.HasErrors = true;");
                                        sb.AppendLine($@"                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, ""{ csspProp.PropName }"", ""{ csspProp.Min.ToString() }"", ""{ csspProp.Max.ToString() }""), new[] {{ ""{ csspProp.PropName }"" }});");
                                        sb.AppendLine(@"            }");
                                        sb.AppendLine(@"");
                                    }
                                }
                            }
                            else if (csspProp.Min != null)
                            {
                                if (csspProp.IsNullable)
                                {
                                    sb.AppendLine($@"            if ({ TypeNameLower }.{ csspProp.PropName } != null)");
                                    sb.AppendLine(@"            {");
                                    sb.AppendLine($@"                if ({ TypeNameLower }.{ csspProp.PropName } < { csspProp.Min.ToString() })");
                                    sb.AppendLine(@"                {");
                                    sb.AppendLine($@"                    { TypeNameLower }.HasErrors = true;");
                                    sb.AppendLine($@"                    yield return new ValidationResult(string.Format(CSSPServicesRes._MinValueIs_, ""{ csspProp.PropName }"", ""{ csspProp.Min.ToString() }""), new[] {{ ""{ csspProp.PropName }"" }});");
                                    sb.AppendLine(@"                }");
                                    sb.AppendLine(@"            }");
                                    sb.AppendLine(@"");
                                }
                                else
                                {
                                    sb.AppendLine($@"            if ({ TypeNameLower }.{ csspProp.PropName } < { csspProp.Min.ToString() })");
                                    sb.AppendLine(@"            {");
                                    sb.AppendLine($@"                { TypeNameLower }.HasErrors = true;");
                                    sb.AppendLine($@"                yield return new ValidationResult(string.Format(CSSPServicesRes._MinValueIs_, ""{ csspProp.PropName }"", ""{ csspProp.Min.ToString() }""), new[] {{ ""{ csspProp.PropName }"" }});");
                                    sb.AppendLine(@"            }");
                                    sb.AppendLine(@"");
                                }

                            }
                            else if (csspProp.Max != null)
                            {
                                if (csspProp.IsNullable)
                                {
                                    sb.AppendLine($@"            if ({ TypeNameLower }.{ csspProp.PropName } != null)");
                                    sb.AppendLine(@"            {");
                                    sb.AppendLine($@"                if ({ TypeNameLower }.{ csspProp.PropName } > { csspProp.Max.ToString() })");
                                    sb.AppendLine(@"                {");
                                    sb.AppendLine($@"                    { TypeNameLower }.HasErrors = true;");
                                    sb.AppendLine($@"                    yield return new ValidationResult(string.Format(CSSPServicesRes._MaxValueIs_, ""{ csspProp.PropName }"", ""{ csspProp.Max.ToString() }""), new[] {{ ""{ csspProp.PropName }"" }});");
                                    sb.AppendLine(@"                }");
                                    sb.AppendLine(@"            }");
                                    sb.AppendLine(@"");
                                }
                                else
                                {
                                    sb.AppendLine($@"            if ({ TypeNameLower }.{ csspProp.PropName } > { csspProp.Max.ToString() })");
                                    sb.AppendLine(@"            {");
                                    sb.AppendLine($@"                { TypeNameLower }.HasErrors = true;");
                                    sb.AppendLine($@"                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxValueIs_, ""{ csspProp.PropName }"", ""{ csspProp.Max.ToString() }""), new[] {{ ""{ csspProp.PropName }"" }});");
                                    sb.AppendLine(@"            }");
                                    sb.AppendLine(@"");
                                }
                            }
                            else
                            {
                                sb.AppendLine($@"                { prop.Name } = CreateValidationNotRequiredLengths_ConditionShouldNotHappenIn_Int,");
                                sb.AppendLine(@"");
                            }
                        }
                        break;
                    case "String":
                        {
                            if (csspProp.Min == null && csspProp.Max == null)
                            {
                                sb.AppendLine($@"            //{ prop.Name } has no StringLength Attribute");
                                sb.AppendLine(@"");
                            }
                            else if (csspProp.Min != null && csspProp.Max != null)
                            {
                                if (csspProp.Min > csspProp.Max)
                                {
                                    sb.AppendLine($@"            { prop.Name } = MinBiggerMaxPleaseFix,");
                                }
                                else
                                {
                                    sb.AppendLine($@"            if (!string.IsNullOrWhiteSpace({ TypeNameLower }.{ prop.Name }) && ({ TypeNameLower }.{ csspProp.PropName }.Length < { csspProp.Min.ToString() } || { TypeNameLower }.{ csspProp.PropName }.Length > { csspProp.Max.ToString() }))");
                                    sb.AppendLine(@"            {");
                                    sb.AppendLine($@"                { TypeNameLower }.HasErrors = true;");
                                    sb.AppendLine($@"                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, ""{ csspProp.PropName }"", ""{ csspProp.Min.ToString() }"", ""{ csspProp.Max.ToString() }""), new[] {{ ""{ csspProp.PropName }"" }});");
                                    sb.AppendLine(@"            }");
                                    sb.AppendLine(@"");
                                }
                            }
                            else if (csspProp.Min != null)
                            {
                                sb.AppendLine($@"            if (!string.IsNullOrWhiteSpace({ TypeNameLower }.{ prop.Name }) && { TypeNameLower }.{ csspProp.PropName }.Length < { csspProp.Min.ToString() })");
                                sb.AppendLine(@"            {");
                                sb.AppendLine($@"                { TypeNameLower }.HasErrors = true;");
                                sb.AppendLine($@"                yield return new ValidationResult(string.Format(CSSPServicesRes._MinLengthIs_, ""{ csspProp.PropName }"", ""{ csspProp.Min.ToString() }""), new[] {{ ""{ csspProp.PropName }"" }});");
                                sb.AppendLine(@"            }");
                                sb.AppendLine(@"");
                            }
                            else if (csspProp.Max != null)
                            {
                                sb.AppendLine($@"            if (!string.IsNullOrWhiteSpace({ TypeNameLower }.{ prop.Name }) && { TypeNameLower }.{ csspProp.PropName }.Length > { csspProp.Max.ToString() })");
                                sb.AppendLine(@"            {");
                                sb.AppendLine($@"                { TypeNameLower }.HasErrors = true;");
                                sb.AppendLine($@"                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, ""{ csspProp.PropName }"", ""{ csspProp.Max.ToString() }""), new[] {{ ""{ csspProp.PropName }"" }});");
                                sb.AppendLine(@"            }");
                                sb.AppendLine(@"");
                            }
                            else
                            {
                                sb.AppendLine($@"            // { prop.Name } has no validation");
                                sb.AppendLine(@"");
                            }
                        }
                        break;
                    default:
                        {
                            if (csspProp.PropName.EndsWith("Web") || csspProp.PropName.EndsWith("Report"))
                            {
                                // nothing yet
                            }
                            else
                            {
                                if (!csspProp.HasCSSPEnumTypeAttribute)
                                {
                                    sb.AppendLine($@"                //CSSPError: Type not implemented [{ csspProp.PropName }] of type [{ csspProp.PropType }]");
                                }
                            }
                        }
                        break;
                }
            }
        }
        /// <summary>
        ///     <code>
        ///         Write code part for the current model property validation not null
        ///     </code>       
        /// </summary>
        /// <param name="prop">PropertyInfo of the current class name and property</param>
        /// <param name="csspProp">Holds CSSPProp information about the current class name and property</param>
        /// <param name="TypeName">Current model type name</param>
        /// <param name="TypeNameLower">Current model type name with first letter lowercase</param>
        /// <param name="sb">StringBuilder holding the text of the file being created</param>
        private void CreateValidation_NotNullable(PropertyInfo prop, CSSPProp csspProp, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            if (!csspProp.IsNullable)
                switch (prop.PropertyType.Name)
                {
                    case "Int16":
                    case "Int32":
                    case "Int64":
                    case "Single":
                    case "Double":
                        {
                            //sb.AppendLine($@"            //{ prop.Name } ({ prop.PropertyType.Name }) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D");
                            //sb.AppendLine(@"");
                        }
                        break;
                    case "Boolean":
                        {
                            if (csspProp.PropName == "HasErrors")
                            {
                                // nothing yet
                            }
                            else
                            {
                                //sb.AppendLine($@"            //{ prop.Name } (bool) is required but no testing needed ");
                                //sb.AppendLine(@"");
                            }
                        }
                        break;
                    case "DateTime":
                    case "DateTimeOffset":
                        {
                            sb.AppendLine($@"            if ({ TypeNameLower }.{ prop.Name }.Year == 1)");
                            sb.AppendLine(@"            {");
                            sb.AppendLine($@"                { TypeNameLower }.HasErrors = true;");
                            sb.AppendLine($@"                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, ""{ prop.Name }""), new[] {{ ""{ csspProp.PropName }"" }});");
                            sb.AppendLine(@"            }");
                            sb.AppendLine(@"            else");
                            sb.AppendLine(@"            {");
                            sb.AppendLine($@"                if ({ TypeNameLower }.{ prop.Name }.Year < { csspProp.Year })");
                            sb.AppendLine(@"                {");
                            sb.AppendLine($@"                { TypeNameLower }.HasErrors = true;");
                            sb.AppendLine($@"                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, ""{ prop.Name }"", ""{ csspProp.Year }""), new[] {{ ""{ csspProp.PropName }"" }});");
                            sb.AppendLine(@"                }");
                            sb.AppendLine(@"            }");
                            sb.AppendLine(@"");
                        }
                        break;
                    case "String":
                        {
                            if (!csspProp.IsKey)
                            {
                                sb.AppendLine($@"            if (string.IsNullOrWhiteSpace({ TypeNameLower }.{ prop.Name }))");
                                sb.AppendLine(@"            {");
                                sb.AppendLine($@"                { TypeNameLower }.HasErrors = true;");
                                sb.AppendLine($@"                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, ""{ prop.Name }""), new[] {{ ""{ csspProp.PropName }"" }});");
                                sb.AppendLine(@"            }");
                                sb.AppendLine(@"");
                            }
                        }
                        break;
                    default:
                        {
                            if (!csspProp.HasCSSPEnumTypeAttribute)
                            {
                                sb.AppendLine($@"                //CSSPError: Type not implemented [{ prop.Name }] of type [{ prop.PropertyType.Name }]");
                                sb.AppendLine(@"");
                            }
                        }
                        break;
                }
        }
        /// <summary>
        ///     <code>
        ///         Write code part for the current model property validation key
        ///     </code>       
        /// </summary>
        /// <param name="prop">PropertyInfo of the current class name and property</param>
        /// <param name="csspProp">Holds CSSPProp information about the current class name and property</param>
        /// <param name="TypeName">Current model type name</param>
        /// <param name="TypeNameLower">Current model type name with first letter lowercase</param>
        /// <param name="sb">StringBuilder holding the text of the file being created</param>
        private void CreateValidation_Key(PropertyInfo prop, CSSPProp csspProp, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            if (prop.CustomAttributes.Where(c => c.AttributeType.Name.StartsWith("KeyAttribute")).Any())
            {
                sb.AppendLine(@"            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)");
                sb.AppendLine(@"            {");
                if (TypeName == "AspNetUser")
                {
                    sb.AppendLine($@"                if ({ TypeNameLower }.{ prop.Name } == """")");
                }
                else
                {
                    sb.AppendLine($@"                if ({ TypeNameLower }.{ prop.Name } == 0)");
                }
                sb.AppendLine(@"                {");
                sb.AppendLine($@"                    { TypeNameLower }.HasErrors = true;");
                sb.AppendLine($@"                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, ""{ prop.Name }""), new[] {{ ""{ csspProp.PropName }"" }});");
                sb.AppendLine(@"                }");
                sb.AppendLine(@"");
                if (TypeName == "AspNetUser")
                {
                    sb.AppendLine($@"                if (!(from c in db.{ TypeName }s select c).Where(c => c.Id == { TypeNameLower }.Id).Any())");
                }
                else
                {
                    if (TypeName == "Address")
                    {
                        sb.AppendLine($@"                if (!(from c in db.{ TypeName }es select c).Where(c => c.{ TypeName }ID == { TypeNameLower }.{ TypeName }ID).Any())");
                    }
                    else
                    {
                        sb.AppendLine($@"                if (!(from c in db.{ TypeName }s select c).Where(c => c.{ TypeName }ID == { TypeNameLower }.{ TypeName }ID).Any())");
                    }
                }
                sb.AppendLine(@"                {");
                sb.AppendLine($@"                    { TypeNameLower }.HasErrors = true;");
                if (TypeName == "AspNetUser")
                {
                    sb.AppendLine($@"                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, ""{ TypeName }"", ""{ TypeName }Id"", ({ TypeNameLower }.Id == null ? """" : { TypeNameLower }.Id.ToString())), new[] {{ ""{ csspProp.PropName }"" }});");
                }
                else
                {
                    sb.AppendLine($@"                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, ""{ TypeName }"", ""{ TypeName }ID"", { TypeNameLower }.{ TypeName }ID.ToString()), new[] {{ ""{ csspProp.PropName }"" }});");
                }
                sb.AppendLine(@"                }");
                sb.AppendLine(@"            }");
                sb.AppendLine(@"");

                if (TypeName == "TVItem")
                {
                    sb.AppendLine(@"            if (tvItem.TVType == TVTypeEnum.Root)");
                    sb.AppendLine(@"            {");
                    if (TypeName == "Address")
                    {
                        sb.AppendLine($@"                if ((from c in db.{ TypeName }es select c).Count() > 0)");
                    }
                    else
                    {
                        sb.AppendLine($@"                if ((from c in db.{ TypeName }s select c).Count() > 0)");
                    }
                    sb.AppendLine(@"                {");
                    sb.AppendLine($@"                    { TypeNameLower }.HasErrors = true;");
                    sb.AppendLine(@"                    yield return new ValidationResult(CSSPServicesRes.TVItemRootShouldBeTheFirstOneAdded, new[] { ""TVItemTVItemID"" });");
                    sb.AppendLine(@"                }");
                    sb.AppendLine(@"            }");
                    sb.AppendLine(@"");
                }

            }
        }
        /// <summary>
        ///     <code>
        ///         Write code part for the current model property validation exist
        ///     </code>       
        /// </summary>
        /// <param name="prop">PropertyInfo of the current class name and property</param>
        /// <param name="csspProp">Holds CSSPProp information about the current class name and property</param>
        /// <param name="TypeName">Current model type name</param>
        /// <param name="TypeNameLower">Current model type name with first letter lowercase</param>
        /// <param name="sb">StringBuilder holding the text of the file being created</param>
        private void CreateValidation_Exist(PropertyInfo prop, CSSPProp csspProp, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            if (!string.IsNullOrWhiteSpace(csspProp.ExistTypeName) && !string.IsNullOrWhiteSpace(csspProp.ExistPlurial) && !string.IsNullOrWhiteSpace(csspProp.ExistFieldID))
            {
                if (TypeName == "TVItem" && (csspProp.PropName == "ParentID" || csspProp.PropName == "LastUpdateContactTVItemID"))
                {
                    sb.AppendLine(@"            if (tvItem.TVType != TVTypeEnum.Root)");
                    sb.AppendLine(@"            {");
                    sb.AppendLine($@"                { csspProp.ExistTypeName } { csspProp.ExistTypeName }{ csspProp.PropName } = (from c in db.{ csspProp.ExistTypeName }{ csspProp.ExistPlurial } where c.{ csspProp.ExistFieldID } == { TypeNameLower }.{ csspProp.PropName } select c).FirstOrDefault();");
                    sb.AppendLine(@"");
                    sb.AppendLine($@"                if ({ csspProp.ExistTypeName }{ csspProp.PropName } == null)");
                    sb.AppendLine(@"                {");
                    sb.AppendLine($@"                    { TypeNameLower }.HasErrors = true;");
                    sb.AppendLine($@"                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, ""{ csspProp.ExistTypeName }"", ""{ csspProp.PropName }"", { TypeNameLower }.{ csspProp.PropName }.ToString()), new[] {{ ""{ csspProp.PropName }"" }});");
                    sb.AppendLine(@"                }");
                    if (csspProp.ExistTypeName == "TVItem")
                    {
                        sb.AppendLine(@"                else");
                        sb.AppendLine(@"                {");
                        sb.AppendLine(@"                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()");
                        sb.AppendLine(@"                    {");
                        foreach (TVTypeEnum tvType in csspProp.AllowableTVTypeList)
                        {
                            sb.AppendLine($@"                        TVTypeEnum.{ tvType.ToString() },");
                        }
                        sb.AppendLine(@"                    };");
                        sb.AppendLine($@"                    if (!AllowableTVTypes.Contains({ csspProp.ExistTypeName }{ csspProp.PropName }.TVType))");
                        sb.AppendLine(@"                    {");
                        sb.AppendLine($@"                        { TypeNameLower }.HasErrors = true;");
                        sb.AppendLine($@"                        yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, ""{ csspProp.PropName }"", ""{ String.Join(",", csspProp.AllowableTVTypeList) }""), new[] {{ ""{ csspProp.PropName }"" }});");
                        sb.AppendLine(@"                    }");
                        sb.AppendLine(@"                }");
                    }
                    sb.AppendLine(@"            }");
                    sb.AppendLine(@"");
                }
                else
                {
                    if (csspProp.IsNullable)
                    {
                        sb.AppendLine($@"            if ({ TypeNameLower }.{ csspProp.PropName } != null)");
                        sb.AppendLine(@"            {");
                        sb.AppendLine($@"                { csspProp.ExistTypeName } { csspProp.ExistTypeName }{ csspProp.PropName } = (from c in db.{ csspProp.ExistTypeName }{ csspProp.ExistPlurial } where c.{ csspProp.ExistFieldID } == { TypeNameLower }.{ csspProp.PropName } select c).FirstOrDefault();");
                        sb.AppendLine(@"");
                        sb.AppendLine($@"                if ({ csspProp.ExistTypeName }{ csspProp.PropName } == null)");
                        sb.AppendLine(@"                {");
                        sb.AppendLine($@"                    { TypeNameLower }.HasErrors = true;");
                        sb.AppendLine($@"                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, ""{ csspProp.ExistTypeName }"", ""{ csspProp.PropName }"", ({ TypeNameLower }.{ csspProp.PropName } == null ? """" : { TypeNameLower }.{ csspProp.PropName }.ToString())), new[] {{ ""{ csspProp.PropName }"" }});");
                        sb.AppendLine(@"                }");
                        if (csspProp.ExistTypeName == "TVItem")
                        {
                            sb.AppendLine(@"                else");
                            sb.AppendLine(@"                {");
                            sb.AppendLine(@"                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()");
                            sb.AppendLine(@"                    {");
                            foreach (TVTypeEnum tvType in csspProp.AllowableTVTypeList)
                            {
                                sb.AppendLine($@"                        TVTypeEnum.{ tvType.ToString() },");
                            }
                            sb.AppendLine(@"                    };");
                            sb.AppendLine($@"                    if (!AllowableTVTypes.Contains({ csspProp.ExistTypeName }{ csspProp.PropName }.TVType))");
                            sb.AppendLine(@"                    {");
                            sb.AppendLine($@"                        { TypeNameLower }.HasErrors = true;");
                            sb.AppendLine($@"                        yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, ""{ csspProp.PropName }"", ""{ String.Join(",", csspProp.AllowableTVTypeList) }""), new[] {{ ""{ csspProp.PropName }"" }});");
                            sb.AppendLine(@"                    }");
                            sb.AppendLine(@"                }");
                        }
                        sb.AppendLine(@"            }");
                        sb.AppendLine(@"");
                    }
                    else
                    {
                        sb.AppendLine($@"            { csspProp.ExistTypeName } { csspProp.ExistTypeName }{ csspProp.PropName } = (from c in db.{ csspProp.ExistTypeName }{ csspProp.ExistPlurial } where c.{ csspProp.ExistFieldID } == { TypeNameLower }.{ csspProp.PropName } select c).FirstOrDefault();");
                        sb.AppendLine(@"");
                        sb.AppendLine($@"            if ({ csspProp.ExistTypeName }{ csspProp.PropName } == null)");
                        sb.AppendLine(@"            {");
                        sb.AppendLine($@"                { TypeNameLower }.HasErrors = true;");
                        if (TypeName == "Contact" && csspProp.PropName == "Id")
                        {
                            sb.AppendLine($@"                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, ""{ csspProp.ExistTypeName }"", ""{ csspProp.PropName }"", ({ TypeNameLower }.{ csspProp.PropName } == null ? """" : { TypeNameLower }.{ csspProp.PropName }.ToString())), new[] {{ ""{ csspProp.PropName }"" }});");
                        }
                        else
                        {
                            sb.AppendLine($@"                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, ""{ csspProp.ExistTypeName }"", ""{ csspProp.PropName }"", { TypeNameLower }.{ csspProp.PropName }.ToString()), new[] {{ ""{ csspProp.PropName }"" }});");
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
                                sb.AppendLine($@"                    TVTypeEnum.{ tvType.ToString() },");
                            }
                            sb.AppendLine(@"                };");
                            sb.AppendLine($@"                if (!AllowableTVTypes.Contains({ csspProp.ExistTypeName }{ csspProp.PropName }.TVType))");
                            sb.AppendLine(@"                {");
                            sb.AppendLine($@"                    { TypeNameLower }.HasErrors = true;");
                            sb.AppendLine($@"                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, ""{ csspProp.PropName }"", ""{ String.Join(",", csspProp.AllowableTVTypeList) }""), new[] {{ ""{ csspProp.PropName }"" }});");
                            sb.AppendLine(@"                }");
                            sb.AppendLine(@"            }");
                        }
                        sb.AppendLine(@"");
                    }
                }
            }
        }
        #endregion Functions private

        #region Functions public
        /// <summary>
        /// Generates:
        ///     C:\CSSPTools\src\dlls\CSSPServices\src\Generated\[ServiceClassName]ServiceGenerated.cs file --- if WithDoc parameter is false
        /// 
        ///     or
        ///     
        ///     C:\CSSPTools\src\dlls\CSSPServices\srcWithDoc\Generated\[ServiceClassName]ServiceGenerated.cs file --- if WithDoc parameter is true
        /// 
        /// Requires:
        ///     C:\CSSPTools\src\dlls\CSSPModels\bin\Debug\netcoreapp3.1\CSSPModels.dll
        ///     
        ///     if WithDoc parameter is true then
        ///     C:\CSSPTools\src\dlls\CSSPEnums\bin\Debug\netcoreapp3.1\CSSPEnums.dll
        ///     C:\CSSPTools\src\dlls\CSSPServices\bin\Debug\netcoreapp3.1\CSSPServices.dll
        ///     C:\CSSPTools\src\web\CSSPWebAPI\bin\Debug\netcoreapp3.1\CSSPWebAPI.dll
        /// </summary>
        public void ClassNameServiceGenerated(bool WithDoc)
        {
            StatusTempEvent(new StatusEventArgs(""));
            ClearPermanentEvent(new StatusEventArgs(""));

            #region Variables and loading DLL properties
            FileInfo fiCSSPEnumsDLL = null;
            FileInfo fiCSSPServicesDLL = null;
            FileInfo fiCSSPWebAPIDLL = null;
            FileInfo fiCSSPModelsDLL = new FileInfo(@"C:\CSSPTools\src\dlls\CSSPModels\bin\Debug\netcoreapp3.1\CSSPModels.dll");

            List<DLLTypeInfo> DLLTypeInfoCSSPEnumsList = new List<DLLTypeInfo>();
            List<DLLTypeInfo> DLLTypeInfoCSSPServicesList = new List<DLLTypeInfo>();
            List<DLLTypeInfo> DLLTypeInfoCSSPWebAPIList = new List<DLLTypeInfo>();

            if (WithDoc)
            {
                fiCSSPEnumsDLL = new FileInfo(@"C:\CSSPTools\src\dlls\CSSPEnums\bin\Debug\netcoreapp3.1\CSSPEnums.dll");
                fiCSSPServicesDLL = new FileInfo(@"C:\CSSPTools\src\dlls\CSSPServices\bin\Debug\netcoreapp3.1\CSSPServices.dll");
                fiCSSPWebAPIDLL = new FileInfo(@"C:\CSSPTools\src\web\CSSPWebAPI\bin\Debug\netcoreapp3.1\CSSPWebAPI.dll");

                if (!fiCSSPEnumsDLL.Exists)
                {
                    CSSPErrorEvent(new CSSPErrorEventArgs($"File does not exist [{ fiCSSPEnumsDLL.FullName }]"));
                    return;
                }

                if (FillDLLTypeInfoList(fiCSSPEnumsDLL, DLLTypeInfoCSSPEnumsList))
                {
                    CSSPErrorEvent(new CSSPErrorEventArgs($"Could not read the file [{ fiCSSPEnumsDLL.FullName }]"));
                    return;
                }

                if (!fiCSSPServicesDLL.Exists)
                {
                    CSSPErrorEvent(new CSSPErrorEventArgs($"File does not exist [{ fiCSSPServicesDLL.FullName }]"));
                    return;
                }

                if (FillDLLTypeInfoList(fiCSSPServicesDLL, DLLTypeInfoCSSPServicesList))
                {
                    CSSPErrorEvent(new CSSPErrorEventArgs($"Could not read the file [{ fiCSSPServicesDLL.FullName }]"));
                    return;
                }

                if (!fiCSSPWebAPIDLL.Exists)
                {
                    CSSPErrorEvent(new CSSPErrorEventArgs($"File does not exist [{ fiCSSPWebAPIDLL.FullName }]"));
                    return;
                }

                if (FillDLLTypeInfoList(fiCSSPWebAPIDLL, DLLTypeInfoCSSPWebAPIList))
                {
                    CSSPErrorEvent(new CSSPErrorEventArgs($"Could not read the file [{ fiCSSPWebAPIDLL.FullName }]"));
                    return;
                }
            }

            if (!fiCSSPModelsDLL.Exists)
            {
                CSSPErrorEvent(new CSSPErrorEventArgs($"File does not exist [{ fiCSSPModelsDLL.FullName }]"));
                return;
            }
            List<DLLTypeInfo> DLLTypeInfoCSSPModelsList = new List<DLLTypeInfo>();
            if (FillDLLTypeInfoList(fiCSSPModelsDLL, DLLTypeInfoCSSPModelsList))
            {
                CSSPErrorEvent(new CSSPErrorEventArgs($"Could not read the file [{ fiCSSPModelsDLL.FullName }]"));
                return;
            }
            #endregion Variables and loading DLL properties

            DLLTypeInfo dllTypeInfoLastUpdate = new DLLTypeInfo();
            DLLTypeInfo dllTypeInfoCSSPError = new DLLTypeInfo();

            foreach (DLLTypeInfo dllTypeInfoModels in DLLTypeInfoCSSPModelsList)
            {
                if (dllTypeInfoModels.Name == "LastUpdate")
                {
                    dllTypeInfoLastUpdate = dllTypeInfoModels;
                }

                if (dllTypeInfoModels.Name == "CSSPError")
                {
                    dllTypeInfoCSSPError = dllTypeInfoModels;
                }
            }

            foreach (DLLTypeInfo dllTypeInfoModels in DLLTypeInfoCSSPModelsList)
            {
                bool NotMappedClass = false;
                StringBuilder sb = new StringBuilder();

                string TypeNameLower = "";

                if (dllTypeInfoModels.Type.Name.StartsWith("MWQM"))
                {
                    TypeNameLower = $"{ dllTypeInfoModels.Type.Name.Substring(0, 4).ToLower() }{ dllTypeInfoModels.Type.Name.Substring(4) }";
                }
                else if (dllTypeInfoModels.Type.Name.StartsWith("TV") || dllTypeInfoModels.Type.Name.StartsWith("VP"))
                {
                    TypeNameLower = $"{ dllTypeInfoModels.Type.Name.Substring(0, 2).ToLower() }{ dllTypeInfoModels.Type.Name.Substring(2) }";
                }
                else
                {
                    TypeNameLower = $"{ dllTypeInfoModels.Type.Name.Substring(0, 1).ToLower() }{ dllTypeInfoModels.Type.Name.Substring(1) }";
                }

                StatusTempEvent(new StatusEventArgs(dllTypeInfoModels.Type.Name));

                if (modelsGenerateCodeHelper.SkipType(dllTypeInfoModels.Type))
                {
                    continue;
                }

                //if (type.Name != "Address")
                //{
                //    continue;
                //}

                StatusTempEvent(new StatusEventArgs(dllTypeInfoModels.Type.Name));
                //Application.DoEvents();

                if (dllTypeInfoModels.HasNotMappedAttribute)
                {
                    NotMappedClass = true;
                }
                else
                {
                    NotMappedClass = false;
                }

                #region Top
                sb.AppendLine(@"/*");
                sb.AppendLine(@" * Auto generated from the CSSPCodeWriter.proj by clicking on the [[ClassName]ServiceGenerated.cs] button");
                sb.AppendLine(@" *");
                sb.AppendLine(@" * Do not edit this file.");
                sb.AppendLine(@" *");
                sb.AppendLine(@" */ ");
                sb.AppendLine(@"");
                sb.AppendLine(@"using CSSPEnums;");
                sb.AppendLine(@"using CSSPModels;");
                sb.AppendLine(@"using CSSPModels.Resources;");
                sb.AppendLine(@"using CSSPServices.Resources;");
                sb.AppendLine(@"using Microsoft.EntityFrameworkCore;");
                sb.AppendLine(@"using System;");
                sb.AppendLine(@"using System.Collections.Generic;");
                sb.AppendLine(@"using System.ComponentModel.DataAnnotations;");
                sb.AppendLine(@"using System.Linq;");
                sb.AppendLine(@"using System.Reflection;");
                sb.AppendLine(@"using System.Security.Principal;");
                sb.AppendLine(@"using System.Text;");
                sb.AppendLine(@"using System.Text.RegularExpressions;");
                sb.AppendLine(@"using System.Threading;");
                sb.AppendLine(@"using System.Threading.Tasks;");
                sb.AppendLine(@"");
                sb.AppendLine(@"namespace CSSPServices");
                sb.AppendLine(@"{");
                #endregion Top

                #region Help of class
                if (WithDoc) //------------------------------------------------------------------ help
                {
                    if (!NotMappedClass)
                    {
                        sb.AppendLine(@"    /// <summary>");
                        sb.AppendLine(@"    /// > [!NOTE]");
                        sb.AppendLine(@"    /// > ");
                        sb.AppendLine($@"    /// > <para>**Used by [CSSPWebAPI.Controllers](CSSPWebAPI.Controllers.html)** : [{ dllTypeInfoModels.Type.Name }Controller](CSSPWebAPI.Controllers.{ dllTypeInfoModels.Type.Name }Controller.html)</para>");
                        sb.AppendLine($@"    /// > <para>**Requires [CSSPModels](CSSPModels.html)** : [CSSPModels.{ dllTypeInfoModels.Type.Name }](CSSPModels.{ dllTypeInfoModels.Type.Name }.html)</para>");

                        string EnumTextLink = "";
                        foreach (DLLPropertyInfo dllPropertyInfo in dllTypeInfoModels.PropertyInfoList)
                        {
                            if (dllPropertyInfo.CSSPProp.HasCSSPEnumTypeAttribute)
                            {
                                EnumTextLink += $"[{ dllPropertyInfo.CSSPProp.PropType }](CSSPEnums.{ dllPropertyInfo.CSSPProp.PropType }.html), ";
                            }
                        }
                        if (!string.IsNullOrWhiteSpace(EnumTextLink))
                        {
                            EnumTextLink = EnumTextLink.Substring(0, EnumTextLink.Length - 2);
                            sb.AppendLine($@"    /// > <para>**Requires [CSSPEnums](CSSPEnums.html)** : { EnumTextLink }</para>");
                        }

                        sb.AppendLine(@"    /// > <para>**Return to [CSSPServices](CSSPServices.html)**</para>");
                        sb.AppendLine(@"    /// </summary>");
                    }
                    else // NotMappedClass
                    {
                        sb.AppendLine(@"    /// <summary>");
                        sb.AppendLine(@"    /// > [!NOTE]");
                        sb.AppendLine(@"    /// > ");
                        sb.AppendLine($@"    /// > <para>**Requires [CSSPModels](CSSPModels.html)** : [CSSPModels.{ dllTypeInfoModels.Type.Name }](CSSPModels.{ dllTypeInfoModels.Type.Name }.html)</para>");

                        string EnumTextLink = "";
                        foreach (DLLPropertyInfo dllPropertyInfo in dllTypeInfoModels.PropertyInfoList)
                        {
                            if (dllPropertyInfo.CSSPProp.HasCSSPEnumTypeAttribute)
                            {
                                EnumTextLink += $"[{ dllPropertyInfo.CSSPProp.PropType }](CSSPEnums.{ dllPropertyInfo.CSSPProp.PropType }.html), ";
                            }
                        }
                        if (!string.IsNullOrWhiteSpace(EnumTextLink))
                        {
                            EnumTextLink = EnumTextLink.Substring(0, EnumTextLink.Length - 2);
                            sb.AppendLine($@"    /// > <para>**Requires [CSSPEnums](CSSPEnums.html)** : { EnumTextLink }</para>");
                        }

                        sb.AppendLine(@"    /// > <para>**Return to [CSSPServices](CSSPServices.html)**</para>");
                        sb.AppendLine(@"    /// </summary>");
                    }
                } //------------------------------------------------------------------ help
                #endregion Help of class

                sb.AppendLine($@"    public partial class { dllTypeInfoModels.Type.Name }Service : BaseService");
                sb.AppendLine(@"    {");
                sb.AppendLine(@"        #region Variables");
                sb.AppendLine(@"        #endregion Variables");
                sb.AppendLine(@"");
                sb.AppendLine(@"        #region Properties");
                sb.AppendLine(@"        #endregion Properties");
                sb.AppendLine(@"");
                sb.AppendLine(@"        #region Constructors");
                if (WithDoc) //------------------------------------------------------------------ help
                {
                    string Plurial = "s";
                    if (dllTypeInfoModels.Type.Name == "Address")
                    {
                        Plurial = "es";
                    }

                    sb.AppendLine(@"        /// <summary>");
                    sb.AppendLine($@"        /// CSSPDB { dllTypeInfoModels.Type.Name }{ Plurial } table service constructor");
                    sb.AppendLine(@"        /// </summary>");
                    sb.AppendLine($@"        /// <param name=""query"">[Query](CSSPModels.Query.html) object for filtering of service functions</param>");
                    sb.AppendLine($@"        /// <param name=""db"">[CSSPDBContext](CSSPModels.CSSPDBContext.html) referencing the CSSP database context</param>");
                    sb.AppendLine($@"        /// <param name=""ContactID"">Representing the contact identifier of the person connecting to the service</param>");
                }
                sb.AppendLine($@"        public { dllTypeInfoModels.Type.Name }Service(Query query, CSSPDBContext db, int ContactID)");
                sb.AppendLine(@"            : base(query, db, ContactID)");
                sb.AppendLine(@"        {");
                sb.AppendLine(@"        }");
                sb.AppendLine(@"        #endregion Constructors");
                sb.AppendLine(@"");
                sb.AppendLine(@"        #region Validation");
                if (WithDoc) //------------------------------------------------------------------ help
                {
                    sb.AppendLine(@"        /// <summary>");
                    sb.AppendLine($@"        /// Validate function for all { dllTypeInfoModels.Type.Name }Service commands");
                    sb.AppendLine(@"        /// </summary>");
                    sb.AppendLine(@"        /// <param name=""validationContext"">System.ComponentModel.DataAnnotations.ValidationContext (Describes the context in which a validation check is performed.)</param>");
                    sb.AppendLine(@"        /// <param name=""actionDBType"">[ActionDBTypeEnum] (CSSPEnums.ActionDBTypeEnum.html) action type to validate</param>");
                    if (dllTypeInfoModels.Type.Name == "Contact")
                    {
                        sb.AppendLine(@"        /// <param name=""addContactType"">[AddContactTypeEnum] (CSSPEnums.AddContactTypeEnum.html) use when adding a new contact</param>");
                    }
                    sb.AppendLine(@"        /// <returns>IEnumerable of ValidationResult (Where ValidationResult is a container for the results of a validation request.)</returns>");
                }
                if (dllTypeInfoModels.Type.Name == "Contact")
                {
                    sb.AppendLine(@"        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType, AddContactTypeEnum addContactType)");
                }
                else
                {
                    sb.AppendLine(@"        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)");
                }
                sb.AppendLine(@"        {");
                sb.AppendLine(@"            string retStr = """";");
                sb.AppendLine(@"            Enums enums = new Enums(LanguageRequest);");
                sb.AppendLine($@"            { dllTypeInfoModels.Type.Name } { TypeNameLower } = validationContext.ObjectInstance as { dllTypeInfoModels.Type.Name };");
                sb.AppendLine($@"            { TypeNameLower }.HasErrors = false;");
                sb.AppendLine(@"");

                foreach (PropertyInfo prop in dllTypeInfoModels.Type.GetProperties())
                {
                    if (prop.GetGetMethod().IsVirtual)
                    {
                        continue;
                    }

                    if (prop.Name == "ValidationResults")
                    {
                        continue;
                    }

                    CSSPProp csspProp = new CSSPProp();
                    if (!modelsGenerateCodeHelper.FillCSSPProp(prop, csspProp, dllTypeInfoModels.Type))
                    {
                        CSSPErrorEvent(new CSSPErrorEventArgs($"CSSPError while creating code [{ csspProp.CSSPError }]"));
                        return;
                    }

                    if (!NotMappedClass)
                    {
                        CreateValidation_Key(prop, csspProp, dllTypeInfoModels.Type.Name, TypeNameLower, sb);
                    }

                    CreateValidation_NotNullable(prop, csspProp, dllTypeInfoModels.Type.Name, TypeNameLower, sb);
                    CreateValidation_Length(prop, csspProp, dllTypeInfoModels.Type.Name, TypeNameLower, sb);
                    CreateValidation_Email(prop, csspProp, dllTypeInfoModels.Type.Name, TypeNameLower, sb);
                    CreateValidation_AfterYear(prop, csspProp, dllTypeInfoModels.Type.Name, TypeNameLower, sb);
                    CreateValidation_Bigger(prop, csspProp, dllTypeInfoModels.Type.Name, TypeNameLower, sb);
                    CreateValidation_Exist(prop, csspProp, dllTypeInfoModels.Type.Name, TypeNameLower, sb);
                    CreateValidation_EnumType(prop, csspProp, dllTypeInfoModels.Type.Name, TypeNameLower, sb);
                }

                sb.AppendLine(@"            retStr = """"; // added to stop compiling CSSPError");
                sb.AppendLine(@"            if (retStr != """") // will never be true");
                sb.AppendLine(@"            {");
                sb.AppendLine($@"                { TypeNameLower }.HasErrors = true;");
                sb.AppendLine(@"                yield return new ValidationResult(""AAA"", new[] { ""AAA"" });");
                sb.AppendLine(@"            }");
                sb.AppendLine(@"");
                sb.AppendLine(@"        }");

                sb.AppendLine(@"        #endregion Validation");
                sb.AppendLine(@"");

                if (!NotMappedClass)
                {
                    CreateClassServiceFunctionsPublicGenerateGet(dllTypeInfoModels, DLLTypeInfoCSSPModelsList, dllTypeInfoModels.Type.Name, TypeNameLower, sb, WithDoc);
                    CreateClassServiceFunctionsPublicGenerateCRUD(dllTypeInfoModels, dllTypeInfoModels.Type.Name, TypeNameLower, sb, WithDoc);
                    CreateClassServiceFunctionsPrivateRegionTrySave(dllTypeInfoModels, dllTypeInfoModels.Type.Name, TypeNameLower, sb, WithDoc);
                }

                sb.AppendLine(@"    }");
                sb.AppendLine(@"}");

                FileInfo fiOutputGen = null;
                if (WithDoc)
                {
                    fiOutputGen = new FileInfo($@"C:\CSSPTools\src\dlls\CSSPServices\srcWithDoc\Generated\{ dllTypeInfoModels.Type.Name }ServiceGenerated.cs");
                }
                else
                {
                    fiOutputGen = new FileInfo($@"C:\CSSPTools\src\dlls\CSSPServices\src\Generated\{ dllTypeInfoModels.Type.Name }ServiceGenerated.cs");
                }

                using (StreamWriter sw2 = fiOutputGen.CreateText())
                {
                    sw2.Write(sb.ToString());
                }

                StatusPermanentEvent(new StatusEventArgs($"Created [{ fiOutputGen.FullName }] ..."));

            }
            StatusPermanentEvent(new StatusEventArgs(""));
            StatusPermanentEvent(new StatusEventArgs("Done ..."));
            StatusTempEvent(new StatusEventArgs("Done ..."));
        }
        #endregion Functions public
    }
}
