using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CSSPEnums;
using System.Net;
using System.Globalization;

namespace CSSPEnumsGenerateCodeHelper
{
    public partial class EnumsCodeWriter
    {
        /// <summary>
        /// Generates: 
        ///     C:\CSSPTools\src\dlls\CSSPEnums\Generated\EnumsWithDocGenerated.cs file
        ///     C:\CSSPTools\src\dlls\CSSPEnums\Generated\PolSourceObsInfoEnumWithDocGenerated.cs file
        /// 
        /// Requires: 
        ///     C:\CSSPTools\src\dlls\CSSPEnums\bin\Debug\netcoreapp3.1\CSSPEnums.dll
        ///     C:\CSSPTools\src\dlls\CSSPModels\bin\Debug\netcoreapp3.1\CSSPModels.dll
        ///     C:\CSSPTools\src\dlls\CSSPServices\bin\Debug\netcoreapp3.1\CSSPServices.dll
        /// </summary>
        public void Generate_EnumsAndPolSourceInfoEnumsWithDoc()
        {
            StatusTempEvent(new StatusEventArgs(""));
            ClearPermanentEvent(new StatusEventArgs("Starting ..."));
            StatusPermanentEvent(new StatusEventArgs(""));

            Enums enumsEn = new Enums();
            enumsEn.SetResourcesCulture(new CultureInfo("en-CA"));

            Enums enumsFr = new Enums();
            enumsFr.SetResourcesCulture(new CultureInfo("fr-CA"));

            StringBuilder sb = new StringBuilder();
            StringBuilder sbPol = new StringBuilder();

            FileInfo fiCSSPEnumsDLL = new FileInfo(@"C:\CSSPTools\src\dlls\CSSPEnums\bin\Debug\netcoreapp3.1\CSSPEnums.dll");
            FileInfo fiCSSPModelsDLL = new FileInfo(@"C:\CSSPTools\src\dlls\CSSPModels\bin\Debug\netcoreapp3.1\CSSPModels.dll");
            FileInfo fiCSSPServicesDLL = new FileInfo(@"C:\CSSPTools\src\dlls\CSSPServices\bin\Debug\netcoreapp3.1\CSSPServices.dll");
            FileInfo fiCSSPWebAPIDLL = new FileInfo(@"C:\CSSPTools\src\web\CSSPWebAPI\bin\Debug\netcoreapp3.1\CSSPWebAPI.dll");
            FileInfo fi = new FileInfo(@"C:\CSSPTools\src\dlls\CSSPEnums\Generated\EnumsWithDocGenerated.cs");
            FileInfo fiPol = new FileInfo(@"C:\CSSPTools\src\dlls\CSSPEnums\Generated\PolSourceObsInfoEnumWithDocGenerated.cs");

            if (!fiCSSPEnumsDLL.Exists)
            {
                CSSPErrorEvent(new CSSPErrorEventArgs($"File does not exist [{ fiCSSPEnumsDLL.FullName }]"));
                return;
            }

            StatusPermanentEvent(new StatusEventArgs($"Reading [{ fiCSSPEnumsDLL.FullName }] ..."));
            List<DLLTypeInfo> DLLTypeInfoCSSPEnumsList = new List<DLLTypeInfo>();
            if (FillDLLTypeInfoList(fiCSSPEnumsDLL, DLLTypeInfoCSSPEnumsList))
            {
                CSSPErrorEvent(new CSSPErrorEventArgs($"Could not read the file [{ fiCSSPEnumsDLL.FullName }]"));
                return;
            }
            StatusPermanentEvent(new StatusEventArgs($"Loaded [{ fiCSSPEnumsDLL.FullName }] ..."));

            if (!fiCSSPModelsDLL.Exists)
            {
                CSSPErrorEvent(new CSSPErrorEventArgs($"File does not exist [{ fiCSSPModelsDLL.FullName }]"));
                return;
            }
            StatusPermanentEvent(new StatusEventArgs($"Reading [{ fiCSSPModelsDLL.FullName }] ..."));
            List<DLLTypeInfo> DLLTypeInfoCSSPModelsList = new List<DLLTypeInfo>();
            if (FillDLLTypeInfoList(fiCSSPModelsDLL, DLLTypeInfoCSSPModelsList))
            {
                CSSPErrorEvent(new CSSPErrorEventArgs($"Could not read the file [{ fiCSSPModelsDLL.FullName }]"));
                return;
            }
            StatusPermanentEvent(new StatusEventArgs($"Loaded [{ fiCSSPModelsDLL.FullName }] ..."));

            if (!fiCSSPServicesDLL.Exists)
            {
                CSSPErrorEvent(new CSSPErrorEventArgs($"File does not exist [{ fiCSSPServicesDLL.FullName }]"));
                return;
            }
            StatusPermanentEvent(new StatusEventArgs($"Reading [{ fiCSSPServicesDLL.FullName }] ..."));
            List<DLLTypeInfo> DLLTypeInfoCSSPServicesList = new List<DLLTypeInfo>();
            if (FillDLLTypeInfoList(fiCSSPServicesDLL, DLLTypeInfoCSSPServicesList))
            {
                CSSPErrorEvent(new CSSPErrorEventArgs($"Could not read the file [{ fiCSSPServicesDLL.FullName }]"));
                return;
            }
            StatusPermanentEvent(new StatusEventArgs($"Loaded [{ fiCSSPServicesDLL.FullName }] ..."));

            if (!fiCSSPWebAPIDLL.Exists)
            {
                CSSPErrorEvent(new CSSPErrorEventArgs($"File does not exist [{ fiCSSPWebAPIDLL.FullName }]"));
                return;
            }
            StatusPermanentEvent(new StatusEventArgs($"Reading [{ fiCSSPWebAPIDLL.FullName }] ..."));
            List<DLLTypeInfo> DLLTypeInfoCSSPWebAPIList = new List<DLLTypeInfo>();
            if (FillDLLTypeInfoList(fiCSSPWebAPIDLL, DLLTypeInfoCSSPWebAPIList))
            {
                CSSPErrorEvent(new CSSPErrorEventArgs($"Could not read the file [{ fiCSSPWebAPIDLL.FullName }]"));
                return;
            }
            StatusPermanentEvent(new StatusEventArgs($"Loaded [{ fiCSSPWebAPIDLL.FullName }] ..."));

            #region Top part Enums.cs
            sb.AppendLine(@"/*");
            sb.AppendLine(@" * Auto generated from the CSSPCodeWriter.proj by clicking on the [EnumsWithDocGenerated.cs - PolSourceObsInfoEnumWithDocGenerated.cs] button");
            sb.AppendLine(@" *");
            sb.AppendLine(@" * Do not edit this file.");
            sb.AppendLine(@" *");
            sb.AppendLine(@" * In order to change this file you should change Enums.cs manually and Include it in the project.");
            sb.AppendLine(@" * You will also need to Exclude this file before recompiling.");
            sb.AppendLine(@" * Once compiled with changes, you will have to run the CSSPEnumsGenerateCode.proj");
            sb.AppendLine(@" * and click on the 'EnumsWithDocGenerated.cs - PolSourceObsInfoEnumWithDocGenerated.cs' button to regenerate this file.");
            sb.AppendLine(@" * You can then re-include this file to the project while excluding Enums.cs");
            sb.AppendLine(@" * ");
            sb.AppendLine(@" */");
            sb.AppendLine(@"using CSSPEnum.Resources;");
            sb.AppendLine(@"using CSSPEnum.Resources.Generated;");
            sb.AppendLine(@"using System.Globalization;");
            sb.AppendLine(@"using System.Threading;");
            sb.AppendLine(@"using System.Threading.Tasks;");
            sb.AppendLine(@"");
            sb.AppendLine(@"namespace CSSPEnums");
            sb.AppendLine(@"{");
            sb.AppendLine(@"    /// <summary>");
            sb.AppendLine(@"    /// > [!NOTE]");
            sb.AppendLine(@"    /// > <para>Interface used with Enums</para>");
            sb.AppendLine(@"    /// </summary>");
            sb.AppendLine(@"    #region Interfaces");
            sb.AppendLine(@"    public interface IEnums");
            sb.AppendLine(@"    {");
            sb.AppendLine(@"        // will be generated in Generated\IEnumsGenerated.cs");
            sb.AppendLine(@"    }");
            sb.AppendLine(@"    #endregion Interfaces");
            sb.AppendLine(@"");
            sb.AppendLine(@"    /// <summary>");
            sb.AppendLine(@"    /// > [!NOTE]");
            sb.AppendLine(@"    /// > <para>Class holding all Enum used in CSSP applications and methods used to get text associated with the Enum in both languages [LanguageEnum.en, LanguageEnum.fr]</para>");
            sb.AppendLine(@"    /// > <para>**Used by** : [CSSPModels](CSSPModels.html), [CSSPServices](CSSPServices.html)</para>");
            sb.AppendLine(@"    /// > <para>**Return to [CSSPEnums](CSSPEnums.html)**</para>");
            sb.AppendLine(@"    /// </summary>");
            sb.AppendLine(@"    public partial class Enums : IEnums");
            sb.AppendLine(@"    {");
            sb.AppendLine(@"        #region Variables");
            sb.AppendLine(@"        #endregion Variables");
            sb.AppendLine(@"");
            sb.AppendLine(@"        #region Properties");
            sb.AppendLine(@"        #endregion Properties");
            sb.AppendLine(@"");
            sb.AppendLine(@"        #region Constructors");
            sb.AppendLine(@"        /// <summary>");
            sb.AppendLine(@"        /// > [!NOTE]");
            sb.AppendLine(@"        /// > <para>**When using LanguageEnum.en**</para>");
            sb.AppendLine(@"        /// > <code>");
            sb.AppendLine(@"        /// >   <para> CurrentCulture = new CultureInfo(""en-CA"");</para>");
            sb.AppendLine(@"        /// >   <para> CurrentUICulture = new CultureInfo(""en-CA"");</para>");
            sb.AppendLine(@"        /// > </code>");
            sb.AppendLine(@"        /// > <para>**When using LanguageEnum.fr**</para>");
            sb.AppendLine(@"        /// > <code>");
            sb.AppendLine(@"        /// >   <para> CurrentCulture = new CultureInfo(""fr-CA"");</para>");
            sb.AppendLine(@"        /// >   <para> CurrentUICulture = new CultureInfo(""fr-CA"");</para>");
            sb.AppendLine(@"        /// > </code>");
            sb.AppendLine(@"        /// </summary>");
            sb.AppendLine(@"        /// <param name=""LanguageRequest"">The language to use when getting the text of the enumerations</param>");
            sb.AppendLine(@"        /// <example>");
            sb.AppendLine(@"        ///     <code>");
            sb.AppendLine(@"        ///         Enums enums = new Enums(LanguageEnum.en)");
            sb.AppendLine(@"        ///     </code>");
            sb.AppendLine(@"        ///     or");
            sb.AppendLine(@"        ///     <code>");
            sb.AppendLine(@"        ///         Enums enums = new Enums(LanguageEnum.fr)</c>");
            sb.AppendLine(@"        ///     </code>");
            sb.AppendLine(@"        /// </example>");
            sb.AppendLine(@"        public Enums()");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"        }");
            sb.AppendLine(@"        #endregion Construtors");
            sb.AppendLine(@"");
            sb.AppendLine(@"        #region Functions public");
            sb.AppendLine(@"        #endregion Functions public");
            sb.AppendLine(@"    }");
            #endregion Top part Enums.cs

            #region Top part PolSourceObsInfoEnumGenerated.cs
            sbPol.AppendLine(@"/*");
            sbPol.AppendLine(@" * Auto generated from the CSSPEnumsGenerateCode.proj by clicking on the [Generate all code files] button");
            sbPol.AppendLine(@" * ");
            sbPol.AppendLine(@" * Do not edit this file.");
            sbPol.AppendLine(@" * ");
            sbPol.AppendLine(@" * In order to change this file you will need to change ");
            sbPol.AppendLine(@" * the 'PolSourceGrouping.xlsm' which is potentially located on the desktop.");
            sbPol.AppendLine(@" * You then need to regenerate the 'PolSourceObsInfoEnumGenerated.cs' file ");
            sbPol.AppendLine(@" * using the 'PolSourceGroupingGenerateCode.proj'");
            sbPol.AppendLine(@" * You then need to include the 'PolSourceObsInfoEnumGenerated.cs' file in the project ");
            sbPol.AppendLine(@" * while exluding the 'PolSourceObsInfoEnumWithDocGenerated.cs' and recompile");
            sbPol.AppendLine(@" * Once compiled with changes, you will have to run the CSSPEnumsGenerateCode.proj (F5) ");
            sbPol.AppendLine(@" * and click on the 'Generate EnumsWithDoc.cs' button to regenerate this file.");
            sbPol.AppendLine(@" * You can then re-include this file to the project while excluding PolSourceObsInfoEnumGenerated.cs");
            sbPol.AppendLine(@" * ");
            sbPol.AppendLine(@" */");
            sbPol.AppendLine(@"");
            sbPol.AppendLine(@"namespace CSSPEnums");
            sbPol.AppendLine(@"{");
            #endregion Top part PolSourceObsInfoEnumGenerated.cs

            int EnumsCount = 0;
            sb.AppendLine(@"    #region Enum");
            foreach (DLLTypeInfo dllTypeInfoEnums in DLLTypeInfoCSSPEnumsList)
            {
                StringBuilder sbType = new StringBuilder();

                if (dllTypeInfoEnums.IsEnum)
                {
                    StringBuilder sbModels = new StringBuilder();
                    StringBuilder sbServices = new StringBuilder();
                    StringBuilder sbWebAPI = new StringBuilder();

                    foreach (DLLTypeInfo dllTypeInfoModels in DLLTypeInfoCSSPModelsList)
                    {
                        EnumsCount += 1;
                        if (EnumsCount % 100 == 0)
                        {
                            StatusTempEvent(new StatusEventArgs($"Doing [{ dllTypeInfoEnums.Name }] [{ dllTypeInfoModels.Name }]"));
                        }
                        foreach (DLLPropertyInfo dllPropertyInfo in dllTypeInfoModels.PropertyInfoList)
                        {
                            if (dllPropertyInfo.CSSPProp.PropType == dllTypeInfoEnums.Type.Name)
                            {
                                string TypeNameModels = dllTypeInfoModels.Name;
                                sbModels.Append($@"[{ dllTypeInfoModels.Name }] (CSSPModels.{ dllTypeInfoModels.Name }.html#CSSPModels_{ dllTypeInfoModels.Name }_{ dllPropertyInfo.CSSPProp.PropName }), ");
                                if (!dllTypeInfoModels.Name.Contains("Extra"))
                                {
                                    sbServices.Append($@"[{ dllTypeInfoModels.Name }Service] (CSSPServices.{ dllTypeInfoModels.Name }Service.html), ");
                                    sbWebAPI.Append($@"[{ dllTypeInfoModels.Name }Controller] (CSSPWebAPI.Controllers.{ dllTypeInfoModels.Name }Controller.html), ");
                                }
                            }
                        }
                    }

                    sbType.AppendLine(@"    /// <summary>");
                    sbType.AppendLine(@"    /// > [!NOTE]");
                    sbType.AppendLine(@"    /// > ");
                    if (sbModels.ToString().Length > 0)
                    {
                        sbModels = sbModels.Remove(sbModels.Length - 2, 2);
                        sbServices = sbServices.Remove(sbServices.Length - 2, 2);
                        sbWebAPI = sbWebAPI.Remove(sbServices.Length - 2, 2);

                        sbType.AppendLine($@"    /// > <para>**Used by [CSSPModels](CSSPModels.html)** : { sbModels.ToString() }</para>");
                        sbType.AppendLine($@"    /// > <para>**Used by [CSSPServices](CSSPServices.html)** : { sbServices.ToString() }</para>");
                        sbType.AppendLine($@"    /// > <para>**Used by [CSSPWebAPI.Controllers](CSSPWebAPI.Controllers.html)** : { sbWebAPI.ToString() }</para>");
                    }

                    sbType.AppendLine(@"    /// > <para>**Return to [CSSPEnums](CSSPEnums.html)**</para>");
                    sbType.AppendLine(@"    /// </summary>");
                    sbType.AppendLine(@"    /// <remarks>");
                    sbType.AppendLine(@"    /// <code>");
                    sbType.AppendLine($@"    ///     public enum { dllTypeInfoEnums.Type.Name }");
                    sbType.AppendLine(@"    ///     {");
                    foreach (DLLFieldInfo dllFieldInfo in dllTypeInfoEnums.FieldInfoList)
                    {
                        if (dllTypeInfoEnums.IsEnum)
                        {
                            string fName = dllFieldInfo.Name;
                            sbType.AppendLine($@"    ///         { fName } = { ((int)dllFieldInfo.FieldInfo.GetValue(fName)).ToString() },");
                        }
                    }
                    sbType.AppendLine(@"    ///     }");
                    sbType.AppendLine(@"    /// </code>");

                    sbType.AppendLine(@"    /// </remarks>");
                    sbType.AppendLine($@"    public enum { dllTypeInfoEnums.Type.Name }");
                    sbType.AppendLine(@"    {");
                    foreach (DLLFieldInfo dllFieldInfo in dllTypeInfoEnums.FieldInfoList)
                    {
                        if (dllTypeInfoEnums.IsEnum)
                        {
                            string fName = dllFieldInfo.Name;
                            int IntVal = (int)dllFieldInfo.FieldInfo.GetValue(dllFieldInfo.Name);

                            sbType.AppendLine(@"        /// <summary>");
                            sbType.AppendLine($@"        /// { IntVal.ToString() } -- en [{ enumsEn.GetResValueForTypeAndID(dllTypeInfoEnums.Type, IntVal) }] ---- fr [{ enumsFr.GetResValueForTypeAndID(dllTypeInfoEnums.Type, IntVal) }]");
                            sbType.AppendLine(@"        /// </summary>");
                            sbType.AppendLine($@"        { fName } = { IntVal.ToString() },");
                        }
                    }
                    sbType.AppendLine(@"    }");
                }

                if (dllTypeInfoEnums.Name == "PolSourceObsInfoEnum")
                {
                    sbPol.Append(sbType);
                    sbPol.AppendLine(@"}");
                }
                else
                {
                    sb.Append(sbType);
                }

            }
            sb.AppendLine(@"    #endregion Enum");
            sb.AppendLine(@"");
            sb.AppendLine(@"    #region Models");
            sb.AppendLine(@"    /// <summary>");
            sb.AppendLine(@"    /// > [!NOTE]");
            sb.AppendLine(@"    /// > Class representing the Enumeration ID and Text in allowable languages LanguageEnum.en, LanguageEnum.fr");
            sb.AppendLine(@"    /// </summary>");
            sb.AppendLine(@"    public class EnumIDAndText");
            sb.AppendLine(@"    {");
            sb.AppendLine(@"        /// <summary>");
            sb.AppendLine(@"        /// Enumeration ID");
            sb.AppendLine(@"        /// </summary>");
            sb.AppendLine(@"        /// <param name=""EnumID"">The ID of the Enumeration</param>");
            sb.AppendLine(@"        public int EnumID { get; set; }");
            sb.AppendLine(@"        /// <summary>");
            sb.AppendLine(@"        /// Enumeration Text in allowable languages [LanguageEnum.en, LanguageEnum.fr]");
            sb.AppendLine(@"        /// </summary>");
            sb.AppendLine(@"        /// <param name=""EnumText"">The text associated with the Enumeration ID</param>");
            sb.AppendLine(@"        public string EnumText { get; set; }");
            sb.AppendLine(@"    }");
            sb.AppendLine(@"    #region Models");
            sb.AppendLine(@"");
            sb.AppendLine(@"}");

            using (StreamWriter sw = fi.CreateText())
            {
                sw.Write(sb.ToString());
            }
            StatusTempEvent(new StatusEventArgs($"Created [{ fi.FullName }] ..."));
            StatusPermanentEvent(new StatusEventArgs($"Created [{ fi.FullName }] ..."));

            using (StreamWriter sw = fiPol.CreateText())
            {
                sw.Write(sbPol.ToString());
            }
            StatusTempEvent(new StatusEventArgs($"Created [{ fiPol.FullName }] ..."));
            StatusPermanentEvent(new StatusEventArgs($"Created [{ fiPol.FullName }] ..."));

            StatusPermanentEvent(new StatusEventArgs("Done ..."));
            StatusPermanentEvent(new StatusEventArgs(""));
            StatusPermanentEvent(new StatusEventArgs("In order to compile the CSSPEnums project with documentation"));
            StatusPermanentEvent(new StatusEventArgs("You need to [EXCLUDE] Enums.cs and PolSourceObsInfoEnumGenerated.cs from the CSSPEnums project"));
            StatusPermanentEvent(new StatusEventArgs("and [INCLUDE] EnumsWithHelp.cs and PolSourceObsInfoEnumWithDocGenerated.cs from the CSSPEnums project"));
            StatusPermanentEvent(new StatusEventArgs(""));
            StatusTempEvent(new StatusEventArgs("Done ..."));
            StatusPermanentEvent(new StatusEventArgs("Done ..."));
        }
    }
}
