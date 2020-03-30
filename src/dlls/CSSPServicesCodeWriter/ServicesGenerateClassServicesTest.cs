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
        #region Variables
        int CharlesLeBlancTVItemID = 2; // TVItemID for Charles LeBlanc
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        // constructor was done in the ServicesGenerateCodeHelper.cs file
        #endregion Constructors

        #region Functions private
        /// <summary>
        ///     <code>
        ///         Write code part for the current model property to test CRUD
        ///     </code>       
        /// </summary>
        /// <param name="TypeName">Current model type name</param>
        /// <param name="TypeNameLower">Current model type name with first letter lowercase</param>
        /// <param name="sb">StringBuilder holding the text of the file being created</param>
        private void CreateClass_CRUD_Testing(string TypeName, string TypeNameLower, StringBuilder sb)
        {
            sb.AppendLine($@"                    count = { TypeNameLower }Service.Get{ TypeName }List().Count();");
            sb.AppendLine(@"");
            if (TypeName == "Address")
            {
                sb.AppendLine($@"                    Assert.Equal(count, (from c in dbTestDB.{ TypeName }es select c).Count());");
            }
            else
            {
                sb.AppendLine($@"                    Assert.Equal(count, (from c in dbTestDB.{ TypeName }s select c).Count());");
            }
            sb.AppendLine(@"");
            if (TypeName == "Contact")
            {
                sb.AppendLine($@"                    { TypeNameLower }Service.Add({ TypeNameLower }, AddContactTypeEnum.LoggedIn);");
            }
            else
            {
                sb.AppendLine($@"                    { TypeNameLower }Service.Add({ TypeNameLower });");
            }
            sb.AppendLine($@"                    if ({ TypeNameLower }.HasErrors)");
            sb.AppendLine(@"                    {");
            sb.AppendLine($@"                        Assert.Equal("""", { TypeNameLower }.ValidationResults.FirstOrDefault().ErrorMessage);");
            sb.AppendLine(@"                    }");
            sb.AppendLine($@"                    Assert.True({ TypeNameLower }Service.Get{ TypeName }List().Where(c => c == { TypeNameLower }).Any());");
            sb.AppendLine($@"                    { TypeNameLower }Service.Update({ TypeNameLower });");
            sb.AppendLine($@"                    if ({ TypeNameLower }.HasErrors)");
            sb.AppendLine(@"                    {");
            sb.AppendLine($@"                        Assert.Equal("""", { TypeNameLower }.ValidationResults.FirstOrDefault().ErrorMessage);");
            sb.AppendLine(@"                    }");
            sb.AppendLine($@"                    Assert.Equal(count + 1, { TypeNameLower }Service.Get{ TypeName }List().Count());");
            sb.AppendLine($@"                    { TypeNameLower }Service.Delete({ TypeNameLower });");
            sb.AppendLine($@"                    if ({ TypeNameLower }.HasErrors)");
            sb.AppendLine(@"                    {");
            sb.AppendLine($@"                        Assert.Equal("""", { TypeNameLower }.ValidationResults.FirstOrDefault().ErrorMessage);");
            sb.AppendLine(@"                    }");
            sb.AppendLine($@"                    Assert.Equal(count, { TypeNameLower }Service.Get{ TypeName }List().Count());");
        }
        /// <summary>
        ///     <code>
        ///         Write code part for the current model property to test key
        ///     </code>       
        /// </summary>
        /// <param name="csspProp">Holds CSSPProp information about the current class name and property</param>
        /// <param name="TypeName">Current model type name</param>
        /// <param name="TypeNameLower">Current model type name with first letter lowercase</param>
        /// <param name="sb">StringBuilder holding the text of the file being created</param>
        private void CreateClass_Key_Testing(CSSPProp csspProp, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            sb.AppendLine($@"                    { TypeNameLower } = null;");
            sb.AppendLine($@"                    { TypeNameLower } = GetFilledRandom{ TypeName }("""");");
            sb.AppendLine($@"                    { TypeNameLower }.{ csspProp.PropName } = 0;");
            sb.AppendLine($@"                    { TypeNameLower }Service.Update({ TypeNameLower });");
            sb.AppendLine($@"                    Assert.Equal(string.Format(CSSPServicesRes._IsRequired, ""{ csspProp.PropName }""), { TypeNameLower }.ValidationResults.FirstOrDefault().ErrorMessage);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                    { TypeNameLower } = null;");
            sb.AppendLine($@"                    { TypeNameLower } = GetFilledRandom{ TypeName }("""");");
            sb.AppendLine($@"                    { TypeNameLower }.{ csspProp.PropName } = 10000000;");
            sb.AppendLine($@"                    { TypeNameLower }Service.Update({ TypeNameLower });");
            sb.AppendLine($@"                    Assert.Equal(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, ""{ TypeName }"", ""{ csspProp.PropName }"", { TypeNameLower }.{ csspProp.PropName }.ToString()), { TypeNameLower }.ValidationResults.FirstOrDefault().ErrorMessage);");
            sb.AppendLine(@"");
        }
        /// <summary>
        ///     <code>
        ///         Write code part for the current model property random filling function  
        ///     </code>       
        /// </summary>
        /// <param name="prop">PropertyInfo of the current class name and property</param>
        /// <param name="csspProp">Holds CSSPProp information about the current class name and property</param>
        /// <param name="TypeName">Current model type name</param>
        /// <param name="TypeNameLower">Current model type name with first letter lowercase</param>
        /// <param name="sb">StringBuilder holding the text of the file being created</param>
        private void CreateGetFilledRandomClass(PropertyInfo prop, CSSPProp csspProp, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            switch (csspProp.PropType)
            {
                case "Int16":
                case "Int32":
                case "Int64":
                case "Single":
                case "Double":
                    {
                        string propTypeTxt = "Int";
                        string numbExt = "";
                        if (csspProp.PropType == "Single")
                        {
                            propTypeTxt = "Float";
                            numbExt = ".0f";
                        }
                        else if (csspProp.PropType == "Double")
                        {
                            propTypeTxt = "Double";
                            numbExt = ".0D";
                        }

                        if (csspProp.IsKey)
                        {
                            //sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { prop.Name };");
                        }
                        else
                        {
                            if (csspProp.PropName == "LastUpdateContactTVItemID")
                            {
                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = 2;");
                            }
                            else if (csspProp.HasCSSPExistAttribute)
                            {
                                switch (csspProp.ExistTypeName)
                                {
                                    case "AppTask":
                                        {
                                            AppTaskService appTaskService = new AppTaskService(new Query(), dbTestDB, CharlesLeBlancTVItemID);
                                            AppTask appTask = appTaskService.GetAppTaskList().FirstOrDefault();
                                            if (appTask == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { appTask.AppTaskID };");
                                            }
                                        }
                                        break;
                                    case "BoxModel":
                                        {
                                            BoxModelService boxModelService = new BoxModelService(new Query(), dbTestDB, CharlesLeBlancTVItemID);
                                            BoxModel boxModel = boxModelService.GetBoxModelList().FirstOrDefault();
                                            if (boxModel == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { boxModel.BoxModelID };");
                                            }
                                        }
                                        break;
                                    case "ClimateSite":
                                        {
                                            ClimateSiteService climateSiteService = new ClimateSiteService(new Query(), dbTestDB, CharlesLeBlancTVItemID);
                                            ClimateSite climateSite = climateSiteService.GetClimateSiteList().FirstOrDefault();
                                            if (climateSite == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { climateSite.ClimateSiteID };");
                                            }
                                        }
                                        break;
                                    case "Contact":
                                        {
                                            ContactService contactService = new ContactService(new Query(), dbTestDB, CharlesLeBlancTVItemID);
                                            Contact contact = contactService.GetContactList().FirstOrDefault();
                                            if (contact == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { contact.ContactID };");
                                            }
                                        }
                                        break;
                                    case "DrogueRun":
                                        {
                                            DrogueRunService DrogueRunService = new DrogueRunService(new Query(), dbTestDB, CharlesLeBlancTVItemID);
                                            DrogueRun DrogueRun = DrogueRunService.GetDrogueRunList().FirstOrDefault();
                                            if (DrogueRun == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { DrogueRun.DrogueRunID };");
                                            }
                                        }
                                        break;
                                    case "EmailDistributionList":
                                        {
                                            EmailDistributionListService emailDistributionListService = new EmailDistributionListService(new Query(), dbTestDB, CharlesLeBlancTVItemID);
                                            EmailDistributionList emailDistributionList = emailDistributionListService.GetEmailDistributionListList().FirstOrDefault();
                                            if (emailDistributionList == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { emailDistributionList.EmailDistributionListID };");
                                            }
                                        }
                                        break;
                                    case "EmailDistributionListContact":
                                        {
                                            EmailDistributionListContactService emailDistributionListContactService = new EmailDistributionListContactService(new Query(), dbTestDB, CharlesLeBlancTVItemID);
                                            EmailDistributionListContact emailDistributionListContact = emailDistributionListContactService.GetEmailDistributionListContactList().FirstOrDefault();
                                            if (emailDistributionListContact == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { emailDistributionListContact.EmailDistributionListContactID };");
                                            }
                                        }
                                        break;
                                    case "HydrometricSite":
                                        {
                                            HydrometricSiteService hydrometricSiteService = new HydrometricSiteService(new Query(), dbTestDB, CharlesLeBlancTVItemID);
                                            HydrometricSite hydrometricSite = hydrometricSiteService.GetHydrometricSiteList().FirstOrDefault();
                                            if (hydrometricSite == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { hydrometricSite.HydrometricSiteID };");
                                            }
                                        }
                                        break;
                                    case "Infrastructure":
                                        {
                                            InfrastructureService infrastructureService = new InfrastructureService(new Query(), dbTestDB, CharlesLeBlancTVItemID);
                                            Infrastructure infrastructure = infrastructureService.GetInfrastructureList().FirstOrDefault();
                                            if (infrastructure == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { infrastructure.InfrastructureID };");
                                            }
                                        }
                                        break;
                                    case "LabSheet":
                                        {
                                            LabSheetService labSheetService = new LabSheetService(new Query(), dbTestDB, CharlesLeBlancTVItemID);
                                            LabSheet labSheet = labSheetService.GetLabSheetList().FirstOrDefault();
                                            if (labSheet == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { labSheet.LabSheetID };");
                                            }
                                        }
                                        break;
                                    case "LabSheetDetail":
                                        {
                                            LabSheetDetailService labSheetDetailService = new LabSheetDetailService(new Query(), dbTestDB, CharlesLeBlancTVItemID);
                                            LabSheetDetail labSheetDetail = labSheetDetailService.GetLabSheetDetailList().FirstOrDefault();
                                            if (labSheetDetail == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { labSheetDetail.LabSheetDetailID };");
                                            }
                                        }
                                        break;
                                    case "MapInfo":
                                        {
                                            MapInfoService mapInfoService = new MapInfoService(new Query(), dbTestDB, CharlesLeBlancTVItemID);
                                            MapInfo mapInfo = mapInfoService.GetMapInfoList().FirstOrDefault();
                                            if (mapInfo == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { mapInfo.MapInfoID };");
                                            }
                                        }
                                        break;
                                    case "MikeSource":
                                        {
                                            MikeSourceService mikeSourceService = new MikeSourceService(new Query(), dbTestDB, CharlesLeBlancTVItemID);
                                            MikeSource mikeSource = mikeSourceService.GetMikeSourceList().FirstOrDefault();
                                            if (mikeSource == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { mikeSource.MikeSourceID };");
                                            }
                                        }
                                        break;
                                    case "MWQMAnalysisReportParameter":
                                        {
                                            MWQMAnalysisReportParameterService mwqmAnalysisReportParameterService = new MWQMAnalysisReportParameterService(new Query(), dbTestDB, CharlesLeBlancTVItemID);
                                            MWQMAnalysisReportParameter mwqmAnalysisReportParameter = mwqmAnalysisReportParameterService.GetMWQMAnalysisReportParameterList().FirstOrDefault();
                                            if (mwqmAnalysisReportParameter == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { mwqmAnalysisReportParameter.MWQMAnalysisReportParameterID };");
                                            }
                                        }
                                        break;
                                    case "MWQMRun":
                                        {
                                            MWQMRunService mwqmRunService = new MWQMRunService(new Query(), dbTestDB, CharlesLeBlancTVItemID);
                                            MWQMRun mwqmRun = mwqmRunService.GetMWQMRunList().FirstOrDefault();
                                            if (mwqmRun == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { mwqmRun.MWQMRunID };");
                                            }
                                        }
                                        break;
                                    case "MWQMSample":
                                        {
                                            MWQMSampleService mwqmSampleService = new MWQMSampleService(new Query(), dbTestDB, CharlesLeBlancTVItemID);
                                            MWQMSample mwqmSample = mwqmSampleService.GetMWQMSampleList().FirstOrDefault();
                                            if (mwqmSample == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { mwqmSample.MWQMSampleID };");
                                            }
                                        }
                                        break;
                                    case "MWQMSubsector":
                                        {
                                            MWQMSubsectorService mwqmSubsectorService = new MWQMSubsectorService(new Query(), dbTestDB, CharlesLeBlancTVItemID);
                                            MWQMSubsector mwqmSubsector = mwqmSubsectorService.GetMWQMSubsectorList().FirstOrDefault();
                                            if (mwqmSubsector == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { mwqmSubsector.MWQMSubsectorID };");
                                            }
                                        }
                                        break;
                                    case "PolSourceObservation":
                                        {
                                            PolSourceObservationService polSourceObservationService = new PolSourceObservationService(new Query(), dbTestDB, CharlesLeBlancTVItemID);
                                            PolSourceObservation polSourceObservation = polSourceObservationService.GetPolSourceObservationList().FirstOrDefault();
                                            if (polSourceObservation == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { polSourceObservation.PolSourceObservationID };");
                                            }
                                        }
                                        break;
                                    case "PolSourceSite":
                                        {
                                            PolSourceSiteService polSourceSiteService = new PolSourceSiteService(new Query(), dbTestDB, CharlesLeBlancTVItemID);
                                            PolSourceSite polSourceSite = polSourceSiteService.GetPolSourceSiteList().FirstOrDefault();
                                            if (polSourceSite == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { polSourceSite.PolSourceSiteID };");
                                            }
                                        }
                                        break;
                                    case "PolSourceSiteEffect":
                                        {
                                            PolSourceSiteEffectService polSourceSiteEffectService = new PolSourceSiteEffectService(new Query(), dbTestDB, CharlesLeBlancTVItemID);
                                            PolSourceSiteEffect polSourceSiteEffect = polSourceSiteEffectService.GetPolSourceSiteEffectList().FirstOrDefault();
                                            if (polSourceSiteEffect == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { polSourceSiteEffect.PolSourceSiteEffectID };");
                                            }
                                        }
                                        break;
                                    case "PolSourceSiteEffectTerm":
                                        {
                                            PolSourceSiteEffectTermService polSourceSiteEffectTermService = new PolSourceSiteEffectTermService(new Query(), dbTestDB, CharlesLeBlancTVItemID);
                                            PolSourceSiteEffectTerm polSourceSiteEffectTerm = polSourceSiteEffectTermService.GetPolSourceSiteEffectTermList().FirstOrDefault();
                                            if (polSourceSiteEffectTerm == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { polSourceSiteEffectTerm.PolSourceSiteEffectTermID };");
                                            }
                                        }
                                        break;
                                    case "RatingCurve":
                                        {
                                            RatingCurveService ratingCurveService = new RatingCurveService(new Query(), dbTestDB, CharlesLeBlancTVItemID);
                                            RatingCurve ratingCurve = ratingCurveService.GetRatingCurveList().FirstOrDefault();
                                            if (ratingCurve == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { ratingCurve.RatingCurveID };");
                                            }
                                        }
                                        break;
                                    case "ReportSection":
                                        {
                                            ReportSectionService ReportSectionService = new ReportSectionService(new Query(), dbTestDB, CharlesLeBlancTVItemID);
                                            ReportSection ReportSection = ReportSectionService.GetReportSectionList().FirstOrDefault();
                                            if (ReportSection == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { ReportSection.ReportSectionID };");
                                            }
                                        }
                                        break;
                                    case "ReportType":
                                        {
                                            ReportTypeService reportTypeService = new ReportTypeService(new Query(), dbTestDB, CharlesLeBlancTVItemID);
                                            ReportType reportType = reportTypeService.GetReportTypeList().FirstOrDefault();
                                            if (reportType == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { reportType.ReportTypeID };");
                                            }
                                        }
                                        break;
                                    case "SamplingPlanSubsector":
                                        {
                                            SamplingPlanSubsectorService samplingPlanSubsectorService = new SamplingPlanSubsectorService(new Query(), dbTestDB, CharlesLeBlancTVItemID);
                                            SamplingPlanSubsector samplingPlanSubsector = samplingPlanSubsectorService.GetSamplingPlanSubsectorList().FirstOrDefault();
                                            if (samplingPlanSubsector == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { samplingPlanSubsector.SamplingPlanSubsectorID };");
                                            }
                                        }
                                        break;
                                    case "SamplingPlan":
                                        {
                                            SamplingPlanService samplingPlanService = new SamplingPlanService(new Query(), dbTestDB, CharlesLeBlancTVItemID);
                                            SamplingPlan samplingPlan = samplingPlanService.GetSamplingPlanList().FirstOrDefault();
                                            if (samplingPlan == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { samplingPlan.SamplingPlanID };");
                                            }
                                        }
                                        break;
                                    case "Spill":
                                        {
                                            SpillService spillService = new SpillService(new Query(), dbTestDB, CharlesLeBlancTVItemID);
                                            Spill spill = spillService.GetSpillList().FirstOrDefault();
                                            if (spill == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { spill.SpillID };");
                                            }
                                        }
                                        break;
                                    case "TVFile":
                                        {
                                            TVFileService tvFileService = new TVFileService(new Query(), dbTestDB, CharlesLeBlancTVItemID);
                                            TVFile tvFile = tvFileService.GetTVFileList().FirstOrDefault();
                                            if (tvFile == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { tvFile.TVFileID };");
                                            }
                                        }
                                        break;
                                    case "VPScenario":
                                        {
                                            VPScenarioService vpScenarioService = new VPScenarioService(new Query(), dbTestDB, CharlesLeBlancTVItemID);
                                            VPScenario vpScenario = vpScenarioService.GetVPScenarioList().FirstOrDefault();
                                            if (vpScenario == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { vpScenario.VPScenarioID };");
                                            }
                                        }
                                        break;
                                    case "TVItem":
                                        {
                                            if (TypeName == "MikeScenario" && csspProp.PropName == "ParentMikeScenarioID")
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = null;");
                                            }
                                            else
                                            {
                                                TVItemService tvItemService = new TVItemService(new Query(), dbTestDB, CharlesLeBlancTVItemID);
                                                if (csspProp.AllowableTVTypeList.Count == 0)
                                                {
                                                    sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                                }
                                                else
                                                {
                                                    TVItem tvItem = tvItemService.GetTVItemList().Where(c => c.TVType == csspProp.AllowableTVTypeList[0]).FirstOrDefault();
                                                    if (tvItem == null)
                                                    {
                                                        sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                                    }
                                                    else
                                                    {
                                                        sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { tvItem.TVItemID };");
                                                    }
                                                }
                                            }
                                        }
                                        break;
                                    case "TVItemLink":
                                        {
                                            TVItemLinkService tvItemLinkService = new TVItemLinkService(new Query(), dbTestDB, CharlesLeBlancTVItemID);
                                            TVItemLink tvItemLink = tvItemLinkService.GetTVItemLinkList().FirstOrDefault();
                                            if (tvItemLink == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { tvItemLink.TVItemLinkID };");
                                            }
                                        }
                                        break;
                                    default:
                                        {
                                            sb.AppendLine($@"            //You need to add a switch for [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }] in CreateGetFilledRandomClass under CSSPServiceCodeWriter.ServicesGeneratClassServiceTest");
                                            sb.AppendLine();
                                            sb.AppendLine($@"            ERRORReadMessageAbove");
                                            sb.AppendLine();
                                        }
                                        break;
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
                                    if (TypeName == "MWQMLookupMPN" && (prop.Name == "Tubes01" || prop.Name == "Tubes1" || prop.Name == "Tubes10"))
                                    {
                                        sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = GetRandom{ propTypeTxt }({ 2.ToString() }{ numbExt }, { 5.ToString() }{ numbExt });");
                                    }
                                    else if (TypeName == "MWQMLookupMPN" && prop.Name == "MPN_100ml")
                                    {
                                        sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = 14;");
                                    }
                                    else
                                    {
                                        sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = GetRandom{ propTypeTxt }({ csspProp.Min.ToString() }{ numbExt }, { csspProp.Max.ToString() }{ numbExt });");
                                    }
                                }
                            }
                            else if (csspProp.Min != null)
                            {
                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = GetRandom{ propTypeTxt }({ csspProp.Min.ToString() }{ numbExt }, { (csspProp.Min + 10).ToString() }{ numbExt });");
                            }
                            else if (csspProp.Max != null)
                            {
                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = GetRandom{ propTypeTxt }({ (csspProp.Max - 10).ToString() }{ numbExt }, { csspProp.Max.ToString() }{ numbExt });");
                            }
                            else
                            {
                                sb.AppendLine($@"            // should implement a Range for the property { prop.Name } and type { TypeName }");
                            }
                        }
                    }
                    break;
                case "DateTime":
                case "DateTimeOffset":
                    {
                        switch ($"{ TypeName }_{ csspProp.PropName }")
                        {
                            case "AppTask_EndDateTime_UTC":
                            case "ClimateSite_HourlyEndDate_Local":
                            case "ClimateSite_DailyEndDate_Local":
                            case "ClimateSite_MonthlyEndDate_Local":
                            case "HydrometricSite_EndDate_Local":
                            case "MikeScenario_MikeScenarioEndDateTime_Local":
                            case "MikeSourceStartEnd_EndDateAndTime_Local":
                            case "MWQMRun_EndDateTime_Local":
                            case "MWQMSiteStartEndDate_EndDate":
                            case "MWQMSubsector_IncludeRainEndDate":
                            case "MWQMSubsector_NoRainEndDate":
                            case "MWQMSubsector_OnlyRainEndDate":
                            case "Spill_EndDateTime_Local":
                            case "TVItemLink_EndDateTime_Local":
                                break;
                            case "AppTask_StartDateTime_UTC":
                            case "ClimateSite_HourlyStartDate_Local":
                            case "ClimateSite_DailyStartDate_Local":
                            case "ClimateSite_MonthlyStartDate_Local":
                            case "HydrometricSite_StartDate_Local":
                            case "MikeScenario_MikeScenarioStartDateTime_Local":
                            case "MikeSourceStartEnd_StartDateAndTime_Local":
                            case "MWQMRun_StartDateTime_Local":
                            case "MWQMSiteStartEndDate_StartDate":
                            case "MWQMSubsector_IncludeRainStartDate":
                            case "MWQMSubsector_NoRainStartDate":
                            case "MWQMSubsector_OnlyRainStartDate":
                            case "Spill_StartDateTime_Local":
                            case "TVItemLink_StartDateTime_Local":
                                {
                                    sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = new DateTime(2005, 3, 6);");
                                    sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name.Replace("Start", "End") }"") { TypeNameLower }.{ prop.Name.Replace("Start", "End") } = new DateTime(2005, 3, 7);");
                                }
                                break;
                            default:
                                {
                                    sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = new DateTime(2005, 3, 6);");
                                }
                                break;
                        }
                    }
                    break;
                case "Boolean":
                    {
                        if (csspProp.PropName == "HasErrors")
                        {
                            //sb.AppendLine($@"            //if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = true;");
                        }
                        else
                        {
                            sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = true;");
                        }
                    }
                    break;
                case "String":
                    {
                        if (csspProp.HasDataTypeAttribute) // will have to do this better ... works because it's only use when email
                        {
                            sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = GetRandomEmail();");
                        }
                        else
                        {
                            if (csspProp.Min != null && csspProp.Max > 0)
                            {
                                if (csspProp.Min > csspProp.Max)
                                {
                                    sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = MinBiggerMaxLengthPleaseFix;");
                                }
                                else
                                {
                                    double? StrLen = (int)csspProp.Min + 5;
                                    if (StrLen > csspProp.Max)
                                    {
                                        StrLen = csspProp.Max;
                                    }
                                    sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = GetRandomString("""", { StrLen.ToString() });");
                                }
                            }
                            else if (csspProp.Min != null)
                            {
                                double StrLen = (int)csspProp.Min + 5;
                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = GetRandomString("""", { StrLen.ToString() });");
                            }
                            else if (csspProp.Max > 0)
                            {
                                double? StrLen = 5;
                                if (StrLen > csspProp.Max)
                                {
                                    StrLen = csspProp.Max;
                                }
                                if (TypeName == "Contact" && csspProp.HasCSSPExistAttribute)
                                {
                                    switch (csspProp.ExistTypeName)
                                    {
                                        case "AspNetUser":
                                            {
                                                using (CSSPDBContext db = new CSSPDBContext())
                                                {
                                                    //AspNetUserService aspNetUserService = new AspNetUserService(new Query(), db, 2);
                                                    //AspNetUser AspNetUser = aspNetUserService.GetAspNetUserList().FirstOrDefault();

                                                    //if (AspNetUser == null)
                                                    //{
                                                    //    sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                                    //}
                                                    //else
                                                    //{
                                                    //    sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = ""{ AspNetUser.Id }"";");
                                                    //}
                                                }
                                            }
                                            break;
                                        default:
                                            {
                                                sb.AppendLine($@"            // Need to implement [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            break;
                                    }
                                }
                                else
                                {
                                    sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = GetRandomString("""", { StrLen.ToString() });");
                                }
                            }
                            else
                            {
                                if (csspProp.IsList)
                                {
                                    sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = new List<string>() {{ GetRandomString("""", 20), GetRandomString("""", 20) }};");
                                }
                                else
                                {
                                    sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = GetRandomString("""", 20);");
                                }
                            }
                        }
                    }
                    break;
                case "Byte[]":
                    {
                        if (TypeName == "ContactLogin")
                        {
                            if (csspProp.PropName == "PasswordSalt")
                            {
                                // Don't do anything for this property
                                // everything will be done while at the PasswordHash property
                            }

                            if (csspProp.PropName == "PasswordHash")
                            {
                                sb.AppendLine(@"            ContactService contactService = new ContactService(LanguageRequest, dbTestDB, ContactID);");
                                sb.AppendLine(@"");
                                sb.AppendLine(@"            Register register = new Register();");
                                sb.AppendLine(@"            register.Password = GetRandomPassword(); // the only thing needed for CreatePasswordHashAndSalt");
                                sb.AppendLine(@"");
                                sb.AppendLine(@"            byte[] passwordHash;");
                                sb.AppendLine(@"            byte[] passwordSalt;");
                                sb.AppendLine(@"            contactService.CreatePasswordHashAndSalt(register, out passwordHash, out passwordSalt);");
                                sb.AppendLine(@"");
                                sb.AppendLine(@"            if (OmitPropName != ""PasswordHash"") contactLogin.PasswordHash = passwordHash;");
                                sb.AppendLine(@"            if (OmitPropName != ""PasswordSalt"") contactLogin.PasswordSalt = passwordSalt;");
                            }
                        }
                    }
                    break;
                default:
                    {
                        if (csspProp.PropType.Contains("Enum"))
                        {
                            if (csspProp.PropType.Contains("LanguageEnum"))
                            {
                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = LanguageRequest;");
                            }
                            else
                            {
                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = ({ csspProp.PropType })GetRandomEnumType(typeof({ csspProp.PropType }));");
                            }
                        }
                        else if (csspProp.PropName.EndsWith("Web") || csspProp.PropName.EndsWith("Report"))
                        {
                            // nothing for now
                        }
                        else
                        {
                            sb.AppendLine($@"            //CSSPError: property [{ csspProp.PropName }] and type [{ TypeName }] is  not implemented");
                        }
                    }
                    break;
            }
        }
        #endregion Functions private

        #region Functions private
        /// <summary>
        /// Generates:
        ///     C:\CSSPTools\src\tests\CSSPServices.Tests\tests\Generated\[ServiceClassName]ServiceTestGenerated.cs file
        /// 
        /// Requires:
        ///     C:\CSSPTools\src\dlls\CSSPModels\bin\Debug\netcoreapp3.1\CSSPModels.dll
        /// </summary>
        public void ClassNameServiceTestGenerated()
        {
            StatusTempEvent(new StatusEventArgs(""));
            ClearPermanentEvent(new StatusEventArgs(""));

            FileInfo fiDLL = new FileInfo(@"C:\CSSPTools\src\dlls\CSSPModels\bin\Debug\netcoreapp3.1\CSSPModels.dll");

            if (!fiDLL.Exists)
            {
                CSSPErrorEvent(new CSSPErrorEventArgs($"{ fiDLL.FullName } does not exist"));
                return;
            }

            var importAssembly = Assembly.LoadFile(fiDLL.FullName);
            List<Type> types = importAssembly.GetTypes().ToList();
            foreach (Type type in types)
            {
                bool ClassNotMapped = false;
                StringBuilder sb = new StringBuilder();
                string TypeName = type.Name;

                string TypeNameLower = "";

                if (type.Name.StartsWith("MWQM"))
                {
                    TypeNameLower = $"{ type.Name.Substring(0, 4).ToLower() }{ type.Name.Substring(4) }";
                }
                else if (type.Name.StartsWith("TV") || type.Name.StartsWith("VP"))
                {
                    TypeNameLower = $"{ type.Name.Substring(0, 2).ToLower() }{ type.Name.Substring(2) }";
                }
                else
                {
                    TypeNameLower = $"{ type.Name.Substring(0, 1).ToLower() }{ type.Name.Substring(1) }";
                }

                StatusTempEvent(new StatusEventArgs(TypeName));
                //Application.DoEvents();

                if (modelsGenerateCodeHelper.SkipType(type))
                {
                    continue;
                }

                foreach (CustomAttributeData customAttributeData in type.CustomAttributes)
                {
                    if (customAttributeData.AttributeType.Name == "NotMappedAttribute")
                    {
                        ClassNotMapped = true;
                        break;
                    }
                }

                //if (TypeName != "DrogueRunPosition")
                //{
                //    continue;
                //}

                sb.AppendLine(@" /* Auto generated from the CSSPCodeWriter.proj by clicking on the [\src\Generated\[ClassName]ServiceGenerated.cs] button");
                sb.AppendLine(@" *");
                sb.AppendLine(@" * Do not edit this file.");
                sb.AppendLine(@" *");
                sb.AppendLine(@" */ ");
                sb.AppendLine(@"");
                sb.AppendLine(@"using System;");
                sb.AppendLine(@"using Xunit;");
                sb.AppendLine(@"using System.Linq;");
                sb.AppendLine(@"using System.Collections.Generic;");
                sb.AppendLine(@"using CSSPModels;");
                sb.AppendLine(@"using CSSPServices;");
                sb.AppendLine(@"using Microsoft.EntityFrameworkCore.Metadata;");
                sb.AppendLine(@"using System.Reflection;");
                sb.AppendLine(@"using CSSPEnums;");
                sb.AppendLine(@"using System.Security.Principal;");
                sb.AppendLine(@"using System.Globalization;");
                sb.AppendLine(@"using CSSPServices.Resources;");
                sb.AppendLine(@"using CSSPModels.Resources;");
                sb.AppendLine(@"using CSSPEnums.Resources;");
                sb.AppendLine(@"");
                sb.AppendLine(@"namespace CSSPServices.Tests");
                sb.AppendLine(@"{");
                sb.AppendLine($@"    public partial class { TypeName }ServiceTest : TestHelper");
                sb.AppendLine(@"    {");
                sb.AppendLine(@"        #region Variables");
                sb.AppendLine(@"        #endregion Variables");
                sb.AppendLine(@"");
                sb.AppendLine(@"        #region Properties");
                sb.AppendLine($@"        //private { TypeName }Service { TypeNameLower }Service {{ get; set; }}");
                sb.AppendLine(@"        #endregion Properties");
                sb.AppendLine(@"");
                sb.AppendLine(@"        #region Constructors");
                sb.AppendLine($@"        public { TypeName }ServiceTest() : base()");
                sb.AppendLine(@"        {");
                sb.AppendLine($@"            //{ TypeNameLower }Service = new { TypeName }Service(LanguageRequest, dbTestDB, ContactID);");
                sb.AppendLine(@"        }");
                sb.AppendLine(@"        #endregion Constructors");
                sb.AppendLine(@"");
                if (!ClassNotMapped)
                {
                    GenerateCRUDTestCode(TypeName, TypeNameLower, sb);

                    GeneratePropertiesTestCode(TypeName, TypeNameLower, type, sb);

                    GenerateGetWithIDTestCode(TypeName, TypeNameLower, types, sb);

                    GenerateGetListTestCode(TypeName, TypeNameLower, types, sb);

                    GenerateGetListSkipTakeTestCode(TypeName, TypeNameLower, types, sb);

                    GenerateGetListSkipTakeAscTestCode(TypeName, TypeNameLower, types, sb);

                    GenerateGetListSkipTake2AscTestCode(TypeName, TypeNameLower, type, types, sb);

                    GenerateGetListSkipTakeAscWhereTestCode(TypeName, TypeNameLower, types, sb);

                    GenerateGetListSkipTakeAsc2WhereTestCode(TypeName, TypeNameLower, types, sb);

                    GenerateGetListSkipTakeDescTestCode(TypeName, TypeNameLower, types, sb);

                    GenerateGetListSkipTake2DescTestCode(TypeName, TypeNameLower, type, types, sb);

                    GenerateGetListSkipTakeDescWhereTestCode(TypeName, TypeNameLower, types, sb);

                    GenerateGetListSkipTakeDesc2WhereTestCode(TypeName, TypeNameLower, types, sb);

                    GenerateGetList2WhereTestCode(TypeName, TypeNameLower, types, sb);
                }
                sb.AppendLine(@"        #region Functions private");
                if (!ClassNotMapped)
                {
                    sb.AppendLine($@"        private void Check{ TypeName }Fields(List<{ TypeName }> { TypeNameLower }List)");
                    sb.AppendLine(@"        {");
                    foreach (PropertyInfo prop in type.GetProperties())
                    {
                        CSSPProp csspProp = new CSSPProp();
                        if (!modelsGenerateCodeHelper.FillCSSPProp(prop, csspProp, type))
                        {
                            return;
                        }
                        if (csspProp.PropName == "ValidationResults")
                        {
                            continue;
                        }

                        if (TypeName == "ContactLogin" && (csspProp.PropName == "PasswordHash" || csspProp.PropName == "PasswordSalt"))
                        {
                            continue;
                        }

                        if (TypeName == "ResetPassword" && (csspProp.PropName == "Password" || csspProp.PropName == "ConfirmPassword"))
                        {
                            continue;
                        }

                        if (csspProp.IsNullable)
                        {
                            if (csspProp.PropType == "String")
                            {
                                sb.AppendLine($@"            if (!string.IsNullOrWhiteSpace({ TypeNameLower }List[0].{ csspProp.PropName }))");
                            }
                            else
                            {
                                sb.AppendLine($@"            if ({ TypeNameLower }List[0].{ csspProp.PropName } != null)");
                            }
                            sb.AppendLine(@"            {");
                        }
                        if (csspProp.PropType == "String")
                        {
                            sb.AppendLine($@"            { (csspProp.IsNullable ? "    " : "") }Assert.False(string.IsNullOrWhiteSpace({ TypeNameLower }List[0].{ csspProp.PropName }));");
                        }
                        else
                        {
                            if (csspProp.IsNullable)
                            {
                                sb.AppendLine($@"            { (csspProp.IsNullable ? "    " : "") }Assert.NotNull({ TypeNameLower }List[0].{ csspProp.PropName });");
                            }
                        }
                        if (csspProp.IsNullable)
                        {
                            sb.AppendLine(@"            }");
                        }
                    }
                    sb.AppendLine(@"        }");
                }
                sb.AppendLine($@"        private { TypeName } GetFilledRandom{ TypeName }(string OmitPropName)");
                sb.AppendLine(@"        {");
                sb.AppendLine($@"            { TypeName } { TypeNameLower } = new { TypeName }();");
                sb.AppendLine(@"");

                foreach (PropertyInfo prop in type.GetProperties())
                {
                    CSSPProp csspProp = new CSSPProp();
                    if (!modelsGenerateCodeHelper.FillCSSPProp(prop, csspProp, type))
                    {
                        return;
                    }

                    if (csspProp.IsKey || prop.GetGetMethod().IsVirtual || prop.Name == "ValidationResults")
                    {
                        continue;
                    }

                    CreateGetFilledRandomClass(prop, csspProp, TypeName, TypeNameLower, sb);
                }

                sb.AppendLine(@"");
                sb.AppendLine($@"            return { TypeNameLower };");
                sb.AppendLine(@"        }");
                sb.AppendLine(@"        #endregion Functions private");
                sb.AppendLine(@"    }");
                sb.AppendLine(@"}");

                FileInfo fiOutputGen = new FileInfo($@"C:\CSSPTools\src\tests\CSSPServices.Tests\tests\Generated\{ TypeName }ServiceTestGenerated.cs");
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
        private void GetTestForDifferentQueryDetailType(List<Type> types, string CountText, string TypeName, string TypeNameLower, StringBuilder sb, bool AssertDirectQuery)
        {
            sb.AppendLine($@"                        List<{ TypeName }> { TypeNameLower }List = new List<{ TypeName }>();");
            sb.AppendLine($@"                        { TypeNameLower }List = { TypeNameLower }Service.Get{ TypeName }List().ToList();");
            sb.AppendLine($@"                        Check{ TypeName }Fields({ TypeNameLower }List);");
            if (AssertDirectQuery)
            {
                sb.AppendLine($@"                        Assert.Equal({ TypeNameLower }DirectQueryList[0].{ TypeName }ID, { TypeNameLower }List[0].{ TypeName }ID);");
            }
        }
        #endregion Functions private
    }
}
