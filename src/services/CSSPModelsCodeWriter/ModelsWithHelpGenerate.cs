using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Forms;
using CSSPGenerateCodeBase;
using CSSPEnums;

namespace CSSPModelsGenerateCodeHelper
{
    public partial class ModelsCodeWriter
    {
        #region Functions public
        /// <summary>
        /// Generates:
        ///     C:\CSSPTools\src\dlls\CSSPModels\srcWithDoc\[ModelClassName]Generated.cs file
        ///     if the WithDoc parameter is true
        ///     
        ///     if the WithDoc parameter is false then
        ///     it will not generate but only compare the existing code file with what would be generated
        ///     C:\CSSPTools\src\dlls\CSSPModels\src\[ModelClassName].cs file
        /// 
        /// Requires:
        ///     C:\CSSPTools\src\dlls\CSSPModels\bin\Debug\netcoreapp3.1\CSSPModels.dll
        ///     
        ///     if WithDoc parameter is true then
        ///     C:\CSSPTools\src\dlls\CSSPEnums\bin\Debug\netcoreapp3.1\CSSPEnums.dll
        ///     C:\CSSPTools\src\dlls\CSSPServices\bin\Debug\netcoreapp3.1\CSSPServices.dll
        /// </summary>
        /// <param name="WithDoc">True to create the Models. False just compares what would be generated with the original one</param>
        public void ModelsCompareOrModelsGeneratedWithDoc(bool WithDoc)
        {
            StatusTempEvent(new StatusEventArgs(""));
            ClearPermanentEvent(new StatusEventArgs(""));
            ClearPermanent2Event(new StatusEventArgs(""));
            List<string> UseQuestionMarkList = new List<string>() { "bool", "int", "long", "DateTime", "double", "float", "byte[]", "Type" };

            List<string> PropertiesToSkipList = new List<string>() { "ValidationResults", "HasErrors", "LastUpdateDate_UTC", "LastUpdateContactTVItemID" };
            #region Variables and loading DLL properties
            FileInfo fiCSSPEnumsDLL = null;
            //FileInfo fiCSSPServicesDLL = null;
            //FileInfo fiCSSPWebAPIDLL = null;
            FileInfo fiCSSPModelsDLL = new FileInfo(@"C:\CSSPTools\src\dlls\CSSPModels\bin\Debug\netcoreapp3.1\CSSPModels.dll");

            List<DLLTypeInfo> DLLTypeInfoCSSPEnumsList = new List<DLLTypeInfo>();
            //List<DLLTypeInfo> DLLTypeInfoCSSPServicesList = new List<DLLTypeInfo>();
            //List<DLLTypeInfo> DLLTypeInfoCSSPWebAPIList = new List<DLLTypeInfo>();

            if (WithDoc)
            {
                fiCSSPEnumsDLL = new FileInfo(@"C:\CSSPTools\src\dlls\CSSPEnums\bin\Debug\netcoreapp3.1\CSSPEnums.dll");
                //fiCSSPServicesDLL = new FileInfo(@"C:\CSSPTools\src\dlls\CSSPServices\bin\Debug\netcoreapp3.1\CSSPServices.dll");
                //fiCSSPWebAPIDLL = new FileInfo(@"C:\CSSPTools\src\web\CSSPWebAPI\bin\Debug\netcoreapp3.1\CSSPWebAPI.dll");

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

                //if (!fiCSSPServicesDLL.Exists)
                //{
                //    CSSPErrorEvent(new CSSPErrorEventArgs($"File does not exist [{ fiCSSPServicesDLL.FullName }]"));
                //    return;
                //}

                //if (FillDLLTypeInfoList(fiCSSPServicesDLL, DLLTypeInfoCSSPServicesList))
                //{
                //    CSSPErrorEvent(new CSSPErrorEventArgs($"Could not read the file [{ fiCSSPServicesDLL.FullName }]"));
                //    return;
                //}

                //if (!fiCSSPWebAPIDLL.Exists)
                //{
                //    CSSPErrorEvent(new CSSPErrorEventArgs($"File does not exist [{ fiCSSPWebAPIDLL.FullName }]"));
                //    return;
                //}

                //if (FillDLLTypeInfoList(fiCSSPWebAPIDLL, DLLTypeInfoCSSPWebAPIList))
                //{
                //    CSSPErrorEvent(new CSSPErrorEventArgs($"Could not read the file [{ fiCSSPWebAPIDLL.FullName }]"));
                //    return;
                //}
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
                StringBuilder sb = new StringBuilder();
                bool PleaseStop = false;
                bool NotMappedClass = false;

                if (SkipType(dllTypeInfoModels.Type))
                {
                    continue;
                }

                //if (dllTypeInfoModels.Type.Name != "Address")
                //{
                //    continue;
                //}

                StatusTempEvent(new StatusEventArgs(dllTypeInfoModels.Type.Name));
                //Application.DoEvents();

                #region Show type file in richTextBoxStatus
                FileInfo fiCodeFile = new FileInfo($@"C:\CSSPTools\src\dlls\CSSPModels\src\{ dllTypeInfoModels.Type.Name }.cs");

                if (!fiCodeFile.Exists)
                {
                    NotMappedClass = true;
                    fiCodeFile = new FileInfo($@"C:\CSSPTools\src\dlls\CSSPModels\src\_{ dllTypeInfoModels.Type.Name }.cs");
                    if (!fiCodeFile.Exists)
                    {
                        CSSPErrorEvent(new CSSPErrorEventArgs($"Could not find file for [{ dllTypeInfoModels.Type.Name }]"));
                        return;
                    }
                }

                StreamReader sr = fiCodeFile.OpenText();
                string OriginalCodeFile = sr.ReadToEnd();
                sr.Close();

                //Application.DoEvents();
                #endregion Show type file in richTextBoxStatus


                #region Top part
                if (WithDoc) //------------------------------------------------------------------ help
                {
                    sb.AppendLine(@"/*");
                    sb.AppendLine(@" * Auto generated from the CSSPCodeWriter.proj by clicking on the [\srcWithDoc\[ModelClassName]Generated.cs] button");
                    sb.AppendLine(@" *");
                    sb.AppendLine(@" * Do not edit this file.");
                    sb.AppendLine(@" *");
                    sb.AppendLine(@" */ ");
                } //------------------------------------------------------------------ help
                else
                {
                    sb.AppendLine(@"/*");
                    sb.AppendLine(@" * Manually edited");
                    sb.AppendLine(@" * ");
                    sb.AppendLine(@" */");
                }
                sb.AppendLine(@"using CSSPEnums;");
                sb.AppendLine(@"using System;");
                sb.AppendLine(@"using System.Collections.Generic;");
                sb.AppendLine(@"using System.ComponentModel.DataAnnotations;");
                sb.AppendLine(@"using System.ComponentModel.DataAnnotations.Schema;");
                sb.AppendLine(@"using System.Linq;");
                sb.AppendLine(@"");
                sb.AppendLine(@"namespace CSSPModels");
                sb.AppendLine(@"{");
                #endregion Top part

                #region Help of class
                if (WithDoc) //------------------------------------------------------------------ help
                {
                    if (!NotMappedClass)
                    {
                        sb.AppendLine(@"    /// <summary>");
                        sb.AppendLine(@"    /// > [!NOTE]");
                        sb.AppendLine(@"    /// > ");
                        string PropInDB = "";
                        string PropNotInDB = "";
                        foreach (DLLPropertyInfo dllPropertyInfo in dllTypeInfoModels.PropertyInfoList)
                        {
                            if (dllPropertyInfo.CSSPProp.HasNotMappedAttribute || dllTypeInfoModels.HasNotMappedAttribute)
                            {
                                if (dllTypeInfoLastUpdate.PropertyInfoList.Where(c => c.CSSPProp.PropName == dllPropertyInfo.CSSPProp.PropName).Any())
                                {
                                    if (dllTypeInfoCSSPError.PropertyInfoList.Where(c => c.CSSPProp.PropName == dllPropertyInfo.CSSPProp.PropName).Any())
                                    {
                                        PropNotInDB += $"[CSSPError.{ dllPropertyInfo.CSSPProp.PropName }](CSSPModels.CSSPError.html#CSSPModels_CSSPError_{ dllPropertyInfo.CSSPProp.PropName }), ";
                                    }
                                    else
                                    {
                                        PropNotInDB += $"[LastUpdate.{ dllPropertyInfo.CSSPProp.PropName }](CSSPModels.LastUpdate.html#CSSPModels_LastUpdate_{ dllPropertyInfo.CSSPProp.PropName }), ";
                                    }
                                }
                                else
                                {
                                    PropNotInDB += $"[{ dllPropertyInfo.CSSPProp.PropName }](CSSPModels.{ dllTypeInfoModels.Name }.html#CSSPModels_{ dllTypeInfoModels.Name }_{ dllPropertyInfo.CSSPProp.PropName }), ";
                                }
                            }
                            else
                            {
                                if (dllTypeInfoLastUpdate.PropertyInfoList.Where(c => c.CSSPProp.PropName == dllPropertyInfo.CSSPProp.PropName).Any())
                                {
                                    PropInDB += $"[LastUpdate.{ dllPropertyInfo.CSSPProp.PropName }](CSSPModels.LastUpdate.html#CSSPModels_LastUpdate_{ dllPropertyInfo.CSSPProp.PropName }), ";
                                }
                                else
                                {
                                    PropInDB += $"[{ dllPropertyInfo.CSSPProp.PropName }](CSSPModels.{ dllTypeInfoModels.Name }.html#CSSPModels_{ dllTypeInfoModels.Name }_{ dllPropertyInfo.CSSPProp.PropName }), ";
                                }
                            }
                        }

                        if (!string.IsNullOrWhiteSpace(PropInDB))
                        {
                            sb.AppendLine($@"    /// > <para>**DB properties for table { dllTypeInfoModels.Name }{ (dllTypeInfoModels.Name == "Address" ? "es" : "s") }** : { PropInDB.Substring(0, PropInDB.Length - 2) }</para>");
                        }
                        else
                        {
                            sb.AppendLine(@"    /// > <para>**No DB properties** :</para>");
                        }
                        if (!string.IsNullOrWhiteSpace(PropNotInDB))
                        {
                            sb.AppendLine($@"    /// > <para>**Other properties** : { PropNotInDB.Substring(0, PropNotInDB.Length - 2) }</para>");
                        }
                        sb.AppendLine(@"    /// > ");
                        sb.AppendLine($@"    /// > <para>**Used by [CSSPServices](CSSPServices.html)** : [{ dllTypeInfoModels.Type.Name }Service](CSSPServices.{ dllTypeInfoModels.Type.Name }Service.html)</para>");
                        sb.AppendLine($@"    /// > <para>**Used by [CSSPWebAPI.Controllers](CSSPWebAPI.Controllers.html)** : [{ dllTypeInfoModels.Type.Name }Controller](CSSPWebAPI.Controllers.{ dllTypeInfoModels.Type.Name }Controller.html)</para>");
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
                        sb.AppendLine($@"    /// > <para>**Inherits [LastUpdate](CSSPModels.LastUpdate.html)**</para>");
                        sb.AppendLine(@"    /// > <para>**Return to [CSSPModels](CSSPModels.html)**</para>");
                        sb.AppendLine(@"    /// </summary>");
                    }
                    else // NotMappedClass
                    {
                        sb.AppendLine(@"    /// <summary>");
                        sb.AppendLine(@"    /// > [!NOTE]");
                        sb.AppendLine(@"    /// > ");
                        string PropNotInDB = "";
                        foreach (DLLPropertyInfo dllPropertyInfo in dllTypeInfoModels.PropertyInfoList)
                        {
                            if (dllTypeInfoCSSPError.PropertyInfoList.Where(c => c.CSSPProp.PropName == dllPropertyInfo.CSSPProp.PropName).Any())
                            {
                                PropNotInDB += $"[CSSPError.{ dllPropertyInfo.CSSPProp.PropName }](CSSPModels.CSSPError.html#CSSPModels_CSSPError_{ dllPropertyInfo.CSSPProp.PropName }), ";
                            }
                            else
                            {
                                PropNotInDB += $"[{ dllPropertyInfo.CSSPProp.PropName }](CSSPModels.{ dllTypeInfoModels.Name }.html#CSSPModels_{ dllTypeInfoModels.Name }_{ dllPropertyInfo.CSSPProp.PropName }), ";
                            }
                        }

                        sb.AppendLine(@"    /// > <para>**No DB properties** :</para>");

                        if (!string.IsNullOrWhiteSpace(PropNotInDB))
                        {
                            sb.AppendLine($@"    /// > <para>**Other properties** : { PropNotInDB.Substring(0, PropNotInDB.Length - 2) }</para>");
                        }
                        sb.AppendLine(@"    /// > ");
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
                        sb.AppendLine($@"    /// > <para>**Inherits [CSSPError](CSSPModels.CSSPError.html)**</para>");
                        sb.AppendLine(@"    /// > <para>**Return to [CSSPModels](CSSPModels.html)**</para>");
                        sb.AppendLine(@"    /// </summary>");
                    }
                } //------------------------------------------------------------------ help
                #endregion Help of class

                #region doing type
                if (NotMappedClass)
                {
                    sb.AppendLine(@"    [NotMapped]");
                    sb.AppendLine($@"    public partial class { dllTypeInfoModels.Type.Name } : CSSPError");
                }
                else
                {
                    if (dllTypeInfoModels.Type.Name == "AspNetUser")
                    {
                        sb.AppendLine($@"    public partial class { dllTypeInfoModels.Type.Name } : CSSPError");
                    }
                    else
                    {
                        sb.AppendLine($@"    public partial class { dllTypeInfoModels.Type.Name } : LastUpdate");
                    }
                }
                sb.AppendLine(@"    {");
                sb.AppendLine(@"        #region Properties in DB");
                if (!NotMappedClass)
                {
                    foreach (DLLPropertyInfo dllPropertyInfo in dllTypeInfoModels.PropertyInfoList)
                    {
                        if (dllPropertyInfo.CSSPProp.HasNotMappedAttribute || PropertiesToSkipList.Contains(dllPropertyInfo.CSSPProp.PropName))
                        {
                            continue;
                        }

                        if (WithDoc) //------------------------------------------------------------------ help
                        {
                            StringBuilder sbCustomAttribute = new StringBuilder();
                            GetCustomAttribute(dllTypeInfoModels, dllPropertyInfo, sbCustomAttribute);

                            if (sbCustomAttribute.Length > 0)
                            {
                                sb.AppendLine(@"        /// <summary>");
                                sb.AppendLine(@"        /// > [!NOTE]");
                                if (!string.IsNullOrWhiteSpace(sbCustomAttribute.ToString()))
                                {
                                    sb.AppendLine(@"        /// > <para>**Other custom attributes**</para>");
                                    sb.Append(sbCustomAttribute.ToString());
                                }
                                sb.AppendLine(@"        /// </summary>");
                            }

                            StringBuilder sbReturns = new StringBuilder();
                            GetReturns(dllTypeInfoModels, dllPropertyInfo, sbReturns);

                            if (sbReturns.Length > 0)
                            {
                                sb.Append(sbReturns.ToString());
                            }
                        }

                        if (!WriteAttributes(dllTypeInfoModels, dllPropertyInfo, sb))
                        {
                            return;
                        }
                        string PropTypeText = GetTypeText(dllPropertyInfo.CSSPProp.PropType);
                        if (string.IsNullOrWhiteSpace(PropTypeText))
                        {
                            StatusPermanent2Event(new StatusEventArgs($"{ dllPropertyInfo.CSSPProp.PropType } is not implemented"));
                            return;
                        }

                        if (dllTypeInfoModels.Type.Name == "Contact" && (dllPropertyInfo.PropertyInfo.Name == "PasswordHash" || dllPropertyInfo.PropertyInfo.Name == "PasswordSalt"))
                        {
                            sb.AppendLine($@"        public byte[] { dllPropertyInfo.CSSPProp.PropName } {{ get; set; }}");
                        }
                        else
                        {
                            string PropText = (dllPropertyInfo.CSSPProp.IsList ? PropTypeText.Replace(PropTypeText, $"List<{ PropTypeText }>") : (dllPropertyInfo.CSSPProp.IsIQueryable ? PropTypeText.Replace(PropTypeText, $"IQueryable<{ PropTypeText }>") : PropTypeText));
                            string IsNullable = (dllPropertyInfo.CSSPProp.IsNullable ? (UseQuestionMarkList.Contains(PropTypeText) || PropTypeText.EndsWith("Enum") ? "?" : "") : "");
                            sb.AppendLine($@"        public { PropText }{ IsNullable } { dllPropertyInfo.CSSPProp.PropName } {{ get; set; }}");
                        }

                    }
                }
                sb.AppendLine(@"        #endregion Properties in DB");
                sb.AppendLine(@"");
                if (NotMappedClass)
                {
                    sb.AppendLine(@"        #region Properties not in DB");

                    foreach (DLLPropertyInfo dllPropertyInfo in dllTypeInfoModels.PropertyInfoList)
                    {
                        if (dllPropertyInfo.CSSPProp.HasNotMappedAttribute || PropertiesToSkipList.Contains(dllPropertyInfo.CSSPProp.PropName))
                        {
                            continue;
                        }

                        if (WithDoc) //------------------------------------------------------------------ help
                        {
                            StringBuilder sbCustomAttribute = new StringBuilder();
                            GetCustomAttribute(dllTypeInfoModels, dllPropertyInfo, sbCustomAttribute);

                            if (sbCustomAttribute.Length > 0)
                            {
                                sb.AppendLine(@"        /// <summary>");
                                sb.AppendLine(@"        /// > [!NOTE]");
                                if (!string.IsNullOrWhiteSpace(sbCustomAttribute.ToString()))
                                {
                                    sb.AppendLine(@"        /// > <para>**Other custom attributes**</para>");
                                    sb.Append(sbCustomAttribute.ToString());
                                }
                                sb.AppendLine(@"        /// </summary>");
                            }

                            StringBuilder sbReturns = new StringBuilder();
                            GetReturns(dllTypeInfoModels, dllPropertyInfo, sbReturns);

                            if (sbReturns.Length > 0)
                            {
                                sb.Append(sbReturns.ToString());
                            }
                        }

                        if (!WriteAttributes(dllTypeInfoModels, dllPropertyInfo, sb))
                        {
                            return;
                        }
                        string PropTypeText = GetTypeText(dllPropertyInfo.CSSPProp.PropType);
                        if (string.IsNullOrWhiteSpace(PropTypeText))
                        {
                            StatusPermanent2Event(new StatusEventArgs($"{ dllPropertyInfo.CSSPProp.PropType } is not implemented"));
                            return;
                        }

                        if (dllTypeInfoModels.Type.Name == "Contact" && (dllPropertyInfo.PropertyInfo.Name == "PasswordHash" || dllPropertyInfo.PropertyInfo.Name == "PasswordSalt"))
                        {
                            sb.AppendLine($@"        public byte[] { dllPropertyInfo.CSSPProp.PropName } {{ get; set; }}");
                        }
                        else
                        {
                            string PropText = (dllPropertyInfo.CSSPProp.IsList ? PropTypeText.Replace(PropTypeText, $"List<{ PropTypeText }>") : (dllPropertyInfo.CSSPProp.IsIQueryable ? PropTypeText.Replace(PropTypeText, $"IQueryable<{ PropTypeText }>") : PropTypeText));
                            string IsNullable = (dllPropertyInfo.CSSPProp.IsNullable ? (UseQuestionMarkList.Contains(PropTypeText) || PropTypeText.EndsWith("Enum") ? "?" : "") : "");
                            sb.AppendLine($@"        public { PropText }{ IsNullable } { dllPropertyInfo.CSSPProp.PropName } {{ get; set; }}");
                        }
                    }
                    sb.AppendLine(@"        #endregion Properties not in DB");
                    sb.AppendLine(@"");
                }
                sb.AppendLine(@"        #region Constructors");
                if (dllTypeInfoModels.Type.Name == "AspNetUser")
                {
                    sb.AppendLine($@"        public { dllTypeInfoModels.Type.Name }()");
                }
                else
                {
                    sb.AppendLine($@"        public { dllTypeInfoModels.Type.Name }() : base()");
                }
                sb.AppendLine(@"        {");
                if (dllTypeInfoModels.Type.Name == "VPFull")
                {
                    sb.AppendLine(@"            VPAmbientList = new List<VPAmbient>();");
                    sb.AppendLine(@"            VPResultList = new List<VPResult>();");
                }
                if (dllTypeInfoModels.Type.Name == "TVLocation")
                {
                    sb.AppendLine(@"            MapObjList = new List<MapObj>();");
                }
                if (dllTypeInfoModels.Type.Name == "TVItemInfrastructureTypeTVItemLink")
                {
                    sb.AppendLine(@"            TVItemLinkList = new List<TVItemLink>();");
                }
                if (dllTypeInfoModels.Type.Name == "TVItemSubsectorAndMWQMSite")
                {
                    sb.AppendLine(@"            TVItemMWQMSiteList = new List<TVItem>();");
                }
                if (dllTypeInfoModels.Type.Name == "SearchTagAndTerms")
                {
                    sb.AppendLine(@"            SearchTermList = new List<string>();");
                }
                if (dllTypeInfoModels.Type.Name == "OtherFilesToUpload")
                {
                    sb.AppendLine(@"            TVFileList = new List<TVFile>();");
                }
                if (dllTypeInfoModels.Type.Name == "Node")
                {
                    sb.AppendLine(@"            ElementList = new List<Element>();");
                    sb.AppendLine(@"            ConnectNodeList = new List<Node>();");
                }
                if (dllTypeInfoModels.Type.Name == "MapObj")
                {
                    sb.AppendLine(@"            CoordList = new List<Coord>();");
                }
                if (dllTypeInfoModels.Type.Name == "LabSheetA1Sheet")
                {
                    sb.AppendLine(@"            LabSheetA1MeasurementList = new List<LabSheetA1Measurement>();");
                }
                if (dllTypeInfoModels.Type.Name == "Element")
                {
                    sb.AppendLine(@"            NodeList = new List<Node>();");
                }
                if (dllTypeInfoModels.Type.Name == "DataPathOfTide")
                {
                    sb.AppendLine(@"            Text = """";");
                    sb.AppendLine(@"            WebTideDataSet = null;");
                }
                if (dllTypeInfoModels.Type.Name == "CSSPWQInputParam")
                {
                    sb.AppendLine(@"            sidList = new List<string>();");
                    sb.AppendLine(@"            MWQMSiteList = new List<string>();");
                    sb.AppendLine(@"            MWQMSiteTVItemIDList = new List<int>();");
                    sb.AppendLine(@"            DailyDuplicateMWQMSiteList = new List<string>();");
                    sb.AppendLine(@"            DailyDuplicateMWQMSiteTVItemIDList = new List<int>();");
                    sb.AppendLine(@"            InfrastructureList = new List<string>();");
                    sb.AppendLine(@"            InfrastructureTVItemIDList = new List<int>();");
                }
                if (dllTypeInfoModels.Type.Name == "ContourPolygon")
                {
                    sb.AppendLine(@"            ContourNodeList = new List<Node>();");
                }
                if (dllTypeInfoModels.Type.Name == "Query")
                {
                    sb.AppendLine(@"            Language = LanguageEnum.en;");
                    sb.AppendLine(@"            Lang = ""en"";");
                    sb.AppendLine(@"            Skip = 0;");
                    sb.AppendLine(@"            Take = 200;");
                    sb.AppendLine(@"            Asc = """";");
                    sb.AppendLine(@"            Desc = """";");
                    sb.AppendLine(@"            Where = """";");
                    sb.AppendLine(@"            AscList = new List<string>();");
                    sb.AppendLine(@"            DescList = new List<string>();");
                    sb.AppendLine(@"            WhereInfoList = new List<WhereInfo>();");
                }

                sb.AppendLine(@"        }");
                sb.AppendLine(@"        #endregion Constructors");

                sb.AppendLine(@"    }");

                List<PropertyInfo> BaseTypePropInfoList = dllTypeInfoModels.Type.GetProperties().ToList();
                if (!NotMappedClass)
                {
                    foreach (DLLTypeInfo dllTypeInfoModelsX in DLLTypeInfoCSSPModelsList)
                    {
                        if (dllTypeInfoModelsX.Type.Name == $"{ dllTypeInfoModels.Type.Name }")
                        {
                            if (WithDoc) // ----------------------------------------------------------------- help
                            {
                                sb.AppendLine(@"    /// <summary>");
                                sb.AppendLine(@"    /// > [!NOTE]");
                                sb.AppendLine(@"    /// > ");

                                string PropNotInDB = "";
                                foreach (DLLPropertyInfo dllPropertyInfo in dllTypeInfoModelsX.PropertyInfoList)
                                {
                                    if ((from c in BaseTypePropInfoList
                                         where c.Name == dllPropertyInfo.PropertyInfo.Name
                                         select c).Any())
                                    {
                                        continue;
                                    }

                                    PropNotInDB += $"[{ dllPropertyInfo.CSSPProp.PropName }](CSSPModels.{ dllTypeInfoModels.Name }.html#CSSPModels_{ dllTypeInfoModels.Name }_{ dllPropertyInfo.CSSPProp.PropName }), ";
                                }

                                sb.AppendLine(@"    /// > <para>**No DB properties** :</para>");

                                if (!string.IsNullOrWhiteSpace(PropNotInDB))
                                {
                                    sb.AppendLine($@"    /// > <para>**Other properties** : { PropNotInDB.Substring(0, PropNotInDB.Length - 2) }</para>");
                                }
                                sb.AppendLine(@"    /// > ");
                                sb.AppendLine($@"    /// > <para>**Used by [CSSPServices](CSSPServices.html)** : [{ dllTypeInfoModels.Type.Name }Service](CSSPServices.{ dllTypeInfoModels.Type.Name }Service.html)</para>");
                                sb.AppendLine($@"    /// > <para>**Used by [CSSPWebAPI.Controllers](CSSPWebAPI.Controllers.html)** : [{ dllTypeInfoModels.Type.Name }Controller](CSSPWebAPI.Controllers.{ dllTypeInfoModels.Type.Name }Controller.html)</para>");
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

                                sb.AppendLine(@"    /// > <para>**Return to [CSSPModels](CSSPModels.html)**</para>");
                                sb.AppendLine(@"    /// </summary>");
                            }
                        }
                        BaseTypePropInfoList = dllTypeInfoModelsX.Type.GetProperties().ToList();
                    }
                }
                #endregion doing type

                sb.AppendLine(@"}");

                #region Comparing existing document with created document
                if (!WithDoc) //------------------------------------------------------------------ help
                {
                    List<string> OriginalLineList = new List<string>();
                    StringReader StrReadOriginal = new StringReader(OriginalCodeFile);

                    string line = "empty";
                    while (true)
                    {
                        line = StrReadOriginal.ReadLine();

                        if (line == null)
                        {
                            break;
                        }

                        OriginalLineList.Add(line);
                    }
                    StrReadOriginal.Close();

                    List<string> NewLineList = new List<string>();
                    StringReader StrReadNew = new StringReader(sb.ToString());

                    line = "empty";
                    while (true)
                    {
                        line = StrReadNew.ReadLine();

                        if (line == null)
                        {
                            break;
                        }

                        NewLineList.Add(line);
                    }
                    StrReadNew.Close();

                    int NewLineListCount = NewLineList.Count;
                    if (OriginalLineList.Count > NewLineList.Count)
                    {
                        for (int i = NewLineListCount; i < OriginalLineList.Count; i++)
                        {
                            NewLineList.Add("\r\n");
                        }
                    }

                    StringBuilder sbAllLines = new StringBuilder();
                    for (int i = 0; i < OriginalLineList.Count; i++)
                    {
                        sbAllLines.Append($"{ NewLineList[i] }\r\n");
                        if (OriginalLineList[i] != NewLineList[i])
                        {
                            PleaseStop = true;
                            ClearPermanentEvent(new StatusEventArgs(""));
                            ClearPermanent2Event(new StatusEventArgs(""));
                            StatusPermanentEvent(new StatusEventArgs(OriginalCodeFile));
                            StatusPermanent2Event(new StatusEventArgs(sbAllLines.ToString()));
                            StatusPermanent2Event(new StatusEventArgs($"|||||||||||||||||||| line [{ (i + 1).ToString() }]"));
                            //Application.DoEvents();
                            return;
                        }
                        //StatusPermanent2Event(new StatusEventArgs(NewLineList[i]));
                        //Application.DoEvents();
                    }

                    if (PleaseStop)
                    {
                        break;
                    }
                } //------------------------------------------------------------------ help
                #endregion Comparing existing document with created document

                if (WithDoc)
                {
                    FileInfo fiNew = new FileInfo($@"C:\CSSPTools\src\dlls\CSSPModels\srcWithDoc\{ dllTypeInfoModels.Type.Name }Generated.cs");
                    using (StreamWriter sw = fiNew.CreateText())
                    {
                        sw.Write(sb.ToString());
                    }
                    StatusTempEvent(new StatusEventArgs("$Created [{ fiNew.FullName }] ..."));
                    StatusPermanentEvent(new StatusEventArgs($"Created [{ fiNew.FullName }] ..."));

                }
                else
                {
                    StatusPermanentEvent(new StatusEventArgs($"{ dllTypeInfoModels.Type.Name } compared ok"));
                }
            }

            StatusTempEvent(new StatusEventArgs("Done ..."));
            StatusPermanentEvent(new StatusEventArgs(""));
            StatusPermanentEvent(new StatusEventArgs("Done ..."));
            StatusPermanentEvent(new StatusEventArgs(""));
            StatusPermanentEvent(new StatusEventArgs("In order to compile the CSSPModels project with documentation"));
            StatusPermanentEvent(new StatusEventArgs("You need to [EXCLUDE] the directory [src] and [INCLUDE] the directory [srcWithDoc] from the CSSPModels project"));
        }
        /// <summary>
        ///     Will get the custom attribute for the particular model class (type) and property
        /// </summary>
        /// <param name="dllTypeInfoModels">Model class type information</param>
        /// <param name="dllPropertyInfo">Property of model information</param>
        /// <param name="sbCustomAttribute">Custom attribute name</param>
        private void GetCustomAttribute(DLLTypeInfo dllTypeInfoModels, DLLPropertyInfo dllPropertyInfo, StringBuilder sbCustomAttribute)
        {
            if (dllPropertyInfo.CSSPProp.HasCSSPExistAttribute)
            {
                string AllowableTVTypeListText = "";
                foreach (CSSPEnums.TVTypeEnum tvType in dllPropertyInfo.CSSPProp.AllowableTVTypeList)
                {
                    AllowableTVTypeListText += $"{ ((int)tvType).ToString() },";
                }

                if (!string.IsNullOrWhiteSpace(AllowableTVTypeListText))
                {
                    AllowableTVTypeListText = AllowableTVTypeListText.Substring(0, AllowableTVTypeListText.Length - 1);
                }

                if (!string.IsNullOrWhiteSpace(AllowableTVTypeListText))
                {
                    StringBuilder sbAllowableTVType = new StringBuilder();
                    foreach (TVTypeEnum tvType in dllPropertyInfo.CSSPProp.AllowableTVTypeList)
                    {
                        sbAllowableTVType.Append($"{ ((int)tvType).ToString() } == { tvType.ToString() }, ");
                    }

                    sbCustomAttribute.AppendLine(@"        /// > <para>**AllowableTVTypeList is of type [CSSPEnums.TVTypeEnum](CSSPEnums.TVTypeEnum.html)**</para>");
                    sbCustomAttribute.AppendLine($@"        /// > <para>{ sbAllowableTVType.Remove(sbAllowableTVType.Length - 2, 2).ToString() }</para>");
                }
                string AllowableTVTypeListTextEmptyOrNot = (!string.IsNullOrWhiteSpace(AllowableTVTypeListText) ? $@", AllowableTVTypeList = ""{ AllowableTVTypeListText }""" : "");
                sbCustomAttribute.AppendLine($@"        /// > <para>[[CSSPExist](CSSPModels.CSSPExistAttribute.html)(ExistTypeName = ""{ dllPropertyInfo.CSSPProp.ExistTypeName }"", ExistPlurial = ""{ dllPropertyInfo.CSSPProp.ExistPlurial }"", ExistFieldID = ""{ dllPropertyInfo.CSSPProp.ExistFieldID }""{ AllowableTVTypeListTextEmptyOrNot })]</para>");

            }
            if (dllPropertyInfo.CSSPProp.HasCSSPEnumTypeAttribute)
            {
                sbCustomAttribute.AppendLine(@"        /// > <para>[[CSSPEnumType](CSSPModels.CSSPEnumTypeAttribute.html)]</para>");
            }
            if (dllPropertyInfo.CSSPProp.HasCSSPAfterAttribute)
            {
                sbCustomAttribute.AppendLine($@"        /// > <para>[[CSSPAfter](CSSPModels.CSSPAfterAttribute.html)(Year = { dllPropertyInfo.CSSPProp.Year })]</para>");
            }
            if (dllPropertyInfo.CSSPProp.HasCSSPBiggerAttribute)
            {
                sbCustomAttribute.AppendLine($@"        /// > <para>[[CSSPBigger](CSSPModels.CSSPBiggerAttribute.html)(OtherField = ""{ dllPropertyInfo.CSSPProp.OtherField }"")]</para>");
            }
            if (dllPropertyInfo.CSSPProp.HasCSSPFillAttribute)
            {
                string FillNeedLanguage = (dllPropertyInfo.CSSPProp.FillNeedLanguage ? "true" : "false");
                string FillIsList = (dllPropertyInfo.CSSPProp.FillIsList ? "true" : "false");
                sbCustomAttribute.AppendLine($@"        /// > <para>[[CSSPFill](CSSPModels.CSSPFillAttribute.html)(FillTypeName = ""{ dllPropertyInfo.CSSPProp.FillTypeName }"", FillPlurial = ""{ dllPropertyInfo.CSSPProp.FillPlurial }"", FillFieldID = ""{ dllPropertyInfo.CSSPProp.FillFieldID }"", FillEqualField = ""{ dllPropertyInfo.CSSPProp.FillEqualField }"", FillReturnField = ""{ dllPropertyInfo.CSSPProp.FillReturnField }"", FillNeedLanguage = { FillNeedLanguage }, FillIsList = { FillIsList })]</para>");
            }
            if (dllPropertyInfo.CSSPProp.HasCSSPEnumTypeTextAttribute)
            {
                sbCustomAttribute.AppendLine($@"        /// > <para>[[CSSPEnumTypeText](CSSPModels.CSSPEnumTypeTextAttribute.html)(EnumTypeName = ""{ dllPropertyInfo.CSSPProp.EnumTypeName }"", EnumType = ""{ dllPropertyInfo.CSSPProp.EnumType }"")]</para>");
            }
            if (dllPropertyInfo.CSSPProp.HasCSSPDisplayENAttribute)
            {
                sbCustomAttribute.AppendLine($@"        /// > <para>[[CSSPDisplayEN](CSSPModels.CSSPDisplayEN.html)(DisplayEN = ""{ dllPropertyInfo.CSSPProp.DisplayEN }"")]</para>");
            }
            if (dllPropertyInfo.CSSPProp.HasCSSPDisplayFRAttribute)
            {
                sbCustomAttribute.AppendLine($@"        /// > <para>[[CSSPDisplayFR](CSSPModels.CSSPDisplayFR.html)(DisplayFR = ""{ dllPropertyInfo.CSSPProp.DisplayFR }"")]</para>");
            }
            if (dllPropertyInfo.CSSPProp.HasCSSPDescriptionENAttribute)
            {
                sbCustomAttribute.AppendLine($@"        /// > <para>[[CSSPDescriptionEN](CSSPModels.CSSPDescriptionEN.html)(DescriptionEN = ""{ dllPropertyInfo.CSSPProp.DescriptionEN }"")]</para>");
            }
            if (dllPropertyInfo.CSSPProp.HasCSSPDescriptionFRAttribute)
            {
                sbCustomAttribute.AppendLine($@"        /// > <para>[[CSSPDescriptionFR](CSSPModels.CSSPDescriptionFR.html)(DescriptionFR = ""{ dllPropertyInfo.CSSPProp.DescriptionFR }"")]</para>");
            }
            if (dllPropertyInfo.CSSPProp.HasCSSPEnumTypeAttribute && dllPropertyInfo.CSSPProp.IsNullable)
            {
                sbCustomAttribute.AppendLine(@"        /// > <para>[[CSSPAllowNull](CSSPModels.CSSPAllowNullAttribute.html)]</para>");
            }
            else if (dllPropertyInfo.CSSPProp.PropType == "String" && dllPropertyInfo.CSSPProp.IsNullable)
            {
                sbCustomAttribute.AppendLine(@"        /// > <para>[[CSSPAllowNull](CSSPModels.CSSPAllowNullAttribute.html)]</para>");
            }
            else if (dllTypeInfoModels.HasNotMappedAttribute && dllPropertyInfo.CSSPProp.IsNullable)
            {
                sbCustomAttribute.AppendLine(@"        /// > <para>[[CSSPAllowNull](CSSPModels.CSSPAllowNullAttribute.html)]</para>");
            }
        }
        /// <summary>
        ///     Will get provide some extra information for the particular model class (type) and property
        /// </summary>
        /// <param name="dllTypeInfoModels">Model class type information</param>
        /// <param name="dllPropertyInfo">Property of model information</param>
        /// <param name="sbReturns">String Builder of the extra information</param>
        private void GetReturns(DLLTypeInfo dllTypeInfoModels, DLLPropertyInfo dllPropertyInfo, StringBuilder sbReturns)
        {
            if (dllPropertyInfo.CSSPProp.HasCSSPDisplayENAttribute
                || dllPropertyInfo.CSSPProp.HasCSSPDisplayFRAttribute
                || dllPropertyInfo.CSSPProp.HasCSSPDescriptionENAttribute
                || dllPropertyInfo.CSSPProp.HasCSSPDescriptionFRAttribute)
            {
                sbReturns.AppendLine($@"        /// <returns>");
                if (dllPropertyInfo.CSSPProp.HasCSSPDisplayENAttribute)
                {
                    sbReturns.AppendLine($@"        /// ");
                    sbReturns.AppendLine($@"        /// **Display (en)** --- { dllPropertyInfo.CSSPProp.DisplayEN }");
                }
                if (dllPropertyInfo.CSSPProp.HasCSSPDisplayFRAttribute)
                {
                    sbReturns.AppendLine($@"        /// ");
                    sbReturns.AppendLine($@"        /// **Display (fr)** --- { dllPropertyInfo.CSSPProp.DisplayFR }");
                }
                if (dllPropertyInfo.CSSPProp.HasCSSPDescriptionENAttribute)
                {
                    sbReturns.AppendLine($@"        /// ");
                    sbReturns.AppendLine($@"        /// **Description (en)** --- { dllPropertyInfo.CSSPProp.DescriptionEN }");
                }
                if (dllPropertyInfo.CSSPProp.HasCSSPDescriptionFRAttribute)
                {
                    sbReturns.AppendLine($@"        /// ");
                    sbReturns.AppendLine($@"        /// **Description (fr)** --- { dllPropertyInfo.CSSPProp.DescriptionFR }");
                }
                sbReturns.AppendLine($@"        /// </returns>");
            }
        }
        /// <summary>
        ///     Gets the code for defining certain property types
        /// </summary>
        /// <param name="propTypeName">Property type name</param>
        /// <returns>Returns the text to use to define the property</returns>
        private string GetTypeText(string propTypeName)
        {
            switch (propTypeName)
            {
                case "Type":
                    return "Type";
                case "Boolean":
                    return "bool";
                case "Byte[]":
                    return "byte[]";
                case "DateTime":
                    return "DateTime";
                case "Double":
                    return "double";
                case "Single":
                    return "float";
                case "Int16":
                    return "int";
                case "Int32":
                    return "int";
                case "Int64":
                    return "long";
                case "String":
                    return "string";
                default:
                    return propTypeName;
            }
        }
        /// <summary>
        ///     Write the attribute at the top of the property
        /// </summary>
        /// <param name="dllTypeInfoModels">Model class type information</param>
        /// <param name="dllPropertyInfo">Property of model information</param>
        /// <param name="sb">StringBuider of the document being generated</param>
        /// <returns>Will return false if an CSSPError occured during the writing of the attribute otherwise true</returns>
        private bool WriteAttributes(DLLTypeInfo dllTypeInfoModels, DLLPropertyInfo dllPropertyInfo, StringBuilder sb)
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
                    AllowableTVTypeListText += $"{ ((int)tvType).ToString() },";
                }

                if (!string.IsNullOrWhiteSpace(AllowableTVTypeListText))
                {
                    AllowableTVTypeListText = AllowableTVTypeListText.Substring(0, AllowableTVTypeListText.Length - 1);
                }
                string AllowableTVTypeListEmptyOrNot = (!string.IsNullOrWhiteSpace(AllowableTVTypeListText) ? $@", AllowableTVTypeList = ""{ AllowableTVTypeListText }""" : "");
                sb.AppendLine($@"        [CSSPExist(ExistTypeName = ""{ dllPropertyInfo.CSSPProp.ExistTypeName }"", ExistPlurial = ""{ dllPropertyInfo.CSSPProp.ExistPlurial }"", ExistFieldID = ""{ dllPropertyInfo.CSSPProp.ExistFieldID }""{ AllowableTVTypeListEmptyOrNot })]");
            }
            if (dllPropertyInfo.CSSPProp.HasStringLengthAttribute)
            {
                string MinText = (dllPropertyInfo.CSSPProp.Min != null ? $", MinimumLength = { dllPropertyInfo.CSSPProp.Min.ToString() }" : "");
                sb.AppendLine($@"        [StringLength({ dllPropertyInfo.CSSPProp.Max }{ MinText })]");
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
                string FillNeedLanguage = (dllPropertyInfo.CSSPProp.FillNeedLanguage ? "true" : "false");
                string FillIsList = (dllPropertyInfo.CSSPProp.FillIsList ? "true" : "false");
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
            if (dllPropertyInfo.CSSPProp.HasCompareAttribute)
            {
                sb.AppendLine($@"        [Compare(""{ dllPropertyInfo.CSSPProp.Compare }"")]");
            }
            if (dllPropertyInfo.CSSPProp.HasRangeAttribute)
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
                sb.AppendLine($@"        [Range({ MinText }, { MaxText })]");
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
            if (dllPropertyInfo.CSSPProp.HasCSSPDisplayENAttribute)
            {
                sb.AppendLine($@"        [CSSPDisplayEN(DisplayEN = ""{ dllPropertyInfo.CSSPProp.DisplayEN }"")]");
            }
            if (dllPropertyInfo.CSSPProp.HasCSSPDisplayFRAttribute)
            {
                sb.AppendLine($@"        [CSSPDisplayFR(DisplayFR = ""{ dllPropertyInfo.CSSPProp.DisplayFR }"")]");
            }
            if (dllPropertyInfo.CSSPProp.HasCSSPDescriptionENAttribute)
            {
                sb.AppendLine($@"        [CSSPDescriptionEN(DescriptionEN = @""{ dllPropertyInfo.CSSPProp.DescriptionEN.Replace("\"", "\"\"") }"")]");
            }
            if (dllPropertyInfo.CSSPProp.HasCSSPDescriptionFRAttribute)
            {
                sb.AppendLine($@"        [CSSPDescriptionFR(DescriptionFR = @""{ dllPropertyInfo.CSSPProp.DescriptionFR.Replace("\"", "\"\"") }"")]");
            }

            return true;
        }
        #endregion Functions public
    }
}
