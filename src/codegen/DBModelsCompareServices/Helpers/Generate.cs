using ActionCommandDBServices.Models;
using CSSPCultureServices.Resources;
using GenerateCodeBaseServices.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DBModelsCompareServices.Services
{
    public partial class DBModelsCompareService : IDBModelsCompareService
    {
        private async Task<bool> Generate()
        {
            ActionResult<ActionCommand> actionActionCommand = await ActionCommandDBService.Get();

            if (((ObjectResult)actionActionCommand.Result).StatusCode == 400)
            {
                await ActionCommandDBService.ConsoleWriteError("actionCommand == null");
                return await Task.FromResult(false);
            }

            ActionCommandDBService.ExecutionStatusText.AppendLine("Generate Starting ...");
            ActionCommandDBService.PercentCompleted = 10;
            await ActionCommandDBService.Update();

            List<string> UseQuestionMarkList = new List<string>() { "bool", "int", "long", "DateTime", "double", "float", "byte[]", "Type" };

            List<string> PropertiesToSkipList = new List<string>() { "ValidationResults", "LastUpdateDate_UTC", "LastUpdateContactTVItemID" };
            #region Variables and loading DLL properties
            FileInfo fiCSSPDBModelsDLL = new FileInfo(Config.GetValue<string>("CSSPDBModels"));

            List<DLLTypeInfo> DLLTypeInfoCSSPEnumsList = new List<DLLTypeInfo>();

            List<DLLTypeInfo> DLLTypeInfoCSSPDBModelsList = new List<DLLTypeInfo>();
            if (GenerateCodeBaseService.FillDLLTypeInfoList(fiCSSPDBModelsDLL, DLLTypeInfoCSSPDBModelsList))
            {
                ActionCommandDBService.ErrorText.AppendLine($"{ string.Format(CSSPCultureServicesRes.CouldNotReadFile_, fiCSSPDBModelsDLL.FullName) }");
                return await Task.FromResult(false);
            }
            #endregion Variables and loading DLL properties

            DLLTypeInfo dllTypeInfoLastUpdate = new DLLTypeInfo();
            DLLTypeInfo dllTypeInfoCSSPError = new DLLTypeInfo();

            foreach (DLLTypeInfo dllTypeInfoModels in DLLTypeInfoCSSPDBModelsList)
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

            foreach (DLLTypeInfo dllTypeInfoModels in DLLTypeInfoCSSPDBModelsList)
            {
                StringBuilder sb = new StringBuilder();
                bool NotMappedClass = false;

                if (GenerateCodeBaseService.SkipType(dllTypeInfoModels.Type))
                {
                    continue;
                }

                if (dllTypeInfoModels.Type.Name.StartsWith("Web"))
                {
                    continue;
                }

                //if (dllTypeInfoModels.Type.Name != "WebAllTVItem")
                //{
                //    continue;
                //}

                #region Show type file in richTextBoxStatus
                FileInfo fiCodeFile = new FileInfo(Config.GetValue<string>("CodeFile").Replace("{TypeName}", dllTypeInfoModels.Type.Name));

                if (!fiCodeFile.Exists)
                {
                    NotMappedClass = true;
                    fiCodeFile = new FileInfo(Config.GetValue<string>("CodeFileNotMapped").Replace("{TypeName}", dllTypeInfoModels.Type.Name));
                    if (!fiCodeFile.Exists)
                    {
                        ActionCommandDBService.ErrorText.AppendLine($"{ string.Format(CSSPCultureServicesRes.CouldNotFindFile_, dllTypeInfoModels.Type.Name) }");
                        return await Task.FromResult(false);
                    }
                }

                StreamReader sr = fiCodeFile.OpenText();
                string OriginalCodeFile = sr.ReadToEnd();
                sr.Close();

                //Application.DoEvents();
                #endregion Show type file in richTextBoxStatus


                #region Top part
                sb.AppendLine(@"/*");
                sb.AppendLine(@" * Manually edited");
                sb.AppendLine(@" * ");
                sb.AppendLine(@" */");
                sb.AppendLine(@"using CSSPEnums;");
                sb.AppendLine(@"using System;");
                sb.AppendLine(@"using System.Collections.Generic;");
                sb.AppendLine(@"using System.ComponentModel.DataAnnotations;");
                sb.AppendLine(@"using System.ComponentModel.DataAnnotations.Schema;");
                sb.AppendLine(@"using System.Linq;");
                sb.AppendLine(@"");
                sb.AppendLine(@"namespace CSSPDBModels");
                sb.AppendLine(@"{");
                #endregion Top part

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

                        if (!await WriteAttributes(dllTypeInfoModels, dllPropertyInfo, sb)) return await Task.FromResult(false);

                        string PropTypeText = GetTypeText(dllPropertyInfo.CSSPProp.PropType);
                        if (string.IsNullOrWhiteSpace(PropTypeText))
                        {
                            ActionCommandDBService.ErrorText.AppendLine($"{ dllPropertyInfo.CSSPProp.PropType } { CSSPCultureServicesRes.IsNotImplemented }");
                            return await Task.FromResult(false);
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

                        if (!await WriteAttributes(dllTypeInfoModels, dllPropertyInfo, sb)) return await Task.FromResult(false);

                        string PropTypeText = GetTypeText(dllPropertyInfo.CSSPProp.PropType);
                        if (string.IsNullOrWhiteSpace(PropTypeText))
                        {
                            ActionCommandDBService.ErrorText.AppendLine($"{ dllPropertyInfo.CSSPProp.PropType } { CSSPCultureServicesRes.IsNotImplemented }");
                            return await Task.FromResult(false);
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
                    foreach (DLLTypeInfo dllTypeInfoModelsX in DLLTypeInfoCSSPDBModelsList)
                    {
                        if (dllTypeInfoModelsX.Type.Name == $"{ dllTypeInfoModels.Type.Name }")
                        {
                        }
                        BaseTypePropInfoList = dllTypeInfoModelsX.Type.GetProperties().ToList();
                    }
                }
                #endregion doing type

                sb.AppendLine(@"}");

                #region Comparing existing document with created document
                #endregion Comparing existing document with created document

                ActionCommandDBService.ExecutionStatusText.AppendLine($"{ dllTypeInfoModels.Type.Name } { CSSPCultureServicesRes.ComparedOK } ...");
            }

            ActionCommandDBService.ExecutionStatusText.AppendLine("");
            ActionCommandDBService.ExecutionStatusText.AppendLine($"{ CSSPCultureServicesRes.Done } ...");
            ActionCommandDBService.ExecutionStatusText.AppendLine("");
            ActionCommandDBService.ExecutionStatusText.AppendLine("Generate Finished ...");
            ActionCommandDBService.PercentCompleted = 100;
            await ActionCommandDBService.Update();

            return await Task.FromResult(true);
        }
    }
}
