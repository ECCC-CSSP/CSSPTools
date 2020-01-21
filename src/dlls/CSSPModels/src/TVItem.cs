/*
 * Manually edited by Charles LeBlanc 
 * 
 */
using CSSPEnums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CSSPModels
{
    public partial class TVItem : LastUpdate
    {
        #region Properties in DB
        [Key]
        [CSSPDisplayEN(DisplayEN = "TVItem ID")]
        [CSSPDisplayFR(DisplayFR = "TVItem ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Contains the unique ""identifier on each row of the TVItems table")]
        [CSSPDescriptionFR(DescriptionFR = @"Contient l'identifiant unique sur chaque ligne de la table TVItems")]
        public int TVItemID { get; set; }
        [Range(0, 100)]
        [CSSPDisplayEN(DisplayEN = "TV level")]
        [CSSPDisplayFR(DisplayFR = "Niveau de l'arbre visuel")]
        [CSSPDescriptionEN(DescriptionEN = @"Tree view level")]
        [CSSPDescriptionFR(DescriptionFR = @"Niveau de l'arbre visuel")]
        public int TVLevel { get; set; }
        [StringLength(250)]
        [CSSPDisplayEN(DisplayEN = "TV path")]
        [CSSPDisplayFR(DisplayFR = "Chemin de l'arbre visuel")]
        [CSSPDescriptionEN(DescriptionEN = @"Tree view path")]
        [CSSPDescriptionFR(DescriptionFR = @"Chemin de l'arbre visuel")]
        public string TVPath { get; set; }
        [CSSPEnumType]
        [CSSPDisplayEN(DisplayEN = "TV type")]
        [CSSPDisplayFR(DisplayFR = "Type d'arbre visuel")]
        [CSSPDescriptionEN(DescriptionEN = @"TV type")]
        [CSSPDescriptionFR(DescriptionFR = @"Type d'arbre visuel")]
        public TVTypeEnum TVType { get; set; }
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "1,2,3,4,5,6,7,9,10,11,12,13,14,15,16,17,18,19,20,21,31,75,79")]
        [CSSPDisplayEN(DisplayEN = "Parent TV ID")]
        [CSSPDisplayFR(DisplayFR = "Parent de l'arbre visuel ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the TVFiles table representing the parent of the tree view")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table TVItems représentant le parent de l'arbre visuel")]
        public int ParentID { get; set; }
        [CSSPDisplayEN(DisplayEN = "Is active")]
        [CSSPDisplayFR(DisplayFR = "Est actif")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the TVFiles table representing the parent of the tree view")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table TVItems représentant le parent de l'arbre visuel")]
        public bool IsActive { get; set; }

        [ForeignKey(nameof(ParentID))]
        [InverseProperty(nameof(TVItem.InverseParents))]
        public virtual TVItem Parent { get; set; }
        [InverseProperty(nameof(Address.AddressTVItem))]
        public virtual ICollection<Address> AddressAddressTVItems { get; set; }
        [InverseProperty(nameof(Address.CountryTVItem))]
        public virtual ICollection<Address> AddressCountryTVItems { get; set; }
        [InverseProperty(nameof(Address.MunicipalityTVItem))]
        public virtual ICollection<Address> AddressMunicipalityTVItems { get; set; }
        [InverseProperty(nameof(Address.ProvinceTVItem))]
        public virtual ICollection<Address> AddressProvinceTVItems { get; set; }
        [InverseProperty(nameof(AppTask.TVItemIDNavigation))]
        public virtual ICollection<AppTask> AppTaskTVItems { get; set; }
        [InverseProperty(nameof(AppTask.TVItemID2Navigation))]
        public virtual ICollection<AppTask> AppTaskTVItemID2Navigations { get; set; }
        [InverseProperty("InfrastructureTVItem")]
        public virtual ICollection<BoxModel> BoxModels { get; set; }
        [InverseProperty("ClassificationTVItem")]
        public virtual ICollection<Classification> Classifications { get; set; }
        [InverseProperty("ClimateSiteTVItem")]
        public virtual ICollection<ClimateSite> ClimateSites { get; set; }
        [InverseProperty("ContactTVItem")]
        public virtual ICollection<Contact> Contacts { get; set; }
        [InverseProperty("TVFileTVItem")]
        public virtual ICollection<DocTemplate> DocTemplates { get; set; }
        [InverseProperty("SubsectorTVItem")]
        public virtual ICollection<DrogueRun> DrogueRuns { get; set; }
        [InverseProperty("ParentTVItem")]
        public virtual ICollection<EmailDistributionList> EmailDistributionLists { get; set; }
        [InverseProperty("EmailTVItem")]
        public virtual ICollection<Email> Emails { get; set; }
        [InverseProperty("HydrometricSiteTVItem")]
        public virtual ICollection<HydrometricSite> HydrometricSites { get; set; }
        [InverseProperty(nameof(Infrastructure.CivicAddressTVItem))]
        public virtual ICollection<Infrastructure> InfrastructureCivicAddressTVItems { get; set; }
        [InverseProperty(nameof(Infrastructure.InfrastructureTVItem))]
        public virtual ICollection<Infrastructure> InfrastructureInfrastructureTVItems { get; set; }
        [InverseProperty(nameof(Infrastructure.SeeOtherMunicipalityTVItem))]
        public virtual ICollection<Infrastructure> InfrastructureSeeOtherMunicipalityTVItems { get; set; }
        [InverseProperty(nameof(TVItem.Parent))]
        public virtual ICollection<TVItem> InverseParents { get; set; }
        [InverseProperty("SubsectorTVItem")]
        public virtual ICollection<LabSheetDetail> LabSheetDetails { get; set; }
        [InverseProperty("MWQMSiteTVItem")]
        public virtual ICollection<LabSheetTubeMPNDetail> LabSheetTubeMPNDetails { get; set; }
        [InverseProperty(nameof(LabSheet.AcceptedOrRejectedByContactTVItem))]
        public virtual ICollection<LabSheet> LabSheetAcceptedOrRejectedByContactTVItems { get; set; }
        [InverseProperty(nameof(LabSheet.MWQMRunTVItem))]
        public virtual ICollection<LabSheet> LabSheetMWQMRunTVItems { get; set; }
        [InverseProperty(nameof(LabSheet.SubsectorTVItem))]
        public virtual ICollection<LabSheet> LabSheetSubsectorTVItems { get; set; }
        [InverseProperty(nameof(MWQMAnalysisReportParameter.ExcelTVFileTVItem))]
        public virtual ICollection<MWQMAnalysisReportParameter> MWQMAnalysisReportParameterExcelTVFileTVItems { get; set; }
        [InverseProperty(nameof(MWQMAnalysisReportParameter.SubsectorTVItem))]
        public virtual ICollection<MWQMAnalysisReportParameter> MWQMAnalysisReportParameterSubsectorTVItems { get; set; }
        [InverseProperty(nameof(MWQMRun.LabSampleApprovalContactTVItem))]
        public virtual ICollection<MWQMRun> MWQMRunLabSampleApprovalContactTVItems { get; set; }
        [InverseProperty(nameof(MWQMRun.MWQMRunTVItem))]
        public virtual ICollection<MWQMRun> MWQMRunMWQMRunTVItems { get; set; }
        [InverseProperty(nameof(MWQMRun.SubsectorTVItem))]
        public virtual ICollection<MWQMRun> MWQMRunSubsectorTVItems { get; set; }
        [InverseProperty(nameof(MWQMSample.MWQMRunTVItem))]
        public virtual ICollection<MWQMSample> MWQMSampleMWQMRunTVItems { get; set; }
        [InverseProperty(nameof(MWQMSample.MWQMSiteTVItem))]
        public virtual ICollection<MWQMSample> MWQMSampleMWQMSiteTVItems { get; set; }
        [InverseProperty("MWQMSiteTVItem")]
        public virtual ICollection<MWQMSiteStartEndDate> MWQMSiteStartEndDates { get; set; }
        [InverseProperty("MWQMSiteTVItem")]
        public virtual ICollection<MWQMSite> MWQMSites { get; set; }
        [InverseProperty("MWQMSubsectorTVItem")]
        public virtual ICollection<MWQMSubsector> MWQMSubsectors { get; set; }
        [InverseProperty("TVItem")]
        public virtual ICollection<MapInfo> MapInfos { get; set; }
        [InverseProperty("MikeBoundaryConditionTVItem")]
        public virtual ICollection<MikeBoundaryCondition> MikeBoundaryConditions { get; set; }
        [InverseProperty("MikeScenarioTVItem")]
        public virtual ICollection<MikeScenarioResult> MikeScenarioResults { get; set; }
        [InverseProperty("MikeScenarioTVItem")]
        public virtual ICollection<MikeScenario> MikeScenarios { get; set; }
        [InverseProperty(nameof(MikeSource.HydrometricTVItem))]
        public virtual ICollection<MikeSource> MikeSourceHydrometricTVItems { get; set; }
        [InverseProperty(nameof(MikeSource.MikeSourceTVItem))]
        public virtual ICollection<MikeSource> MikeSourceMikeSourceTVItems { get; set; }
        [InverseProperty("ContactTVItem")]
        public virtual ICollection<PolSourceObservation> PolSourceObservations { get; set; }
        [InverseProperty(nameof(PolSourceSiteEffect.AnalysisDocumentTVItem))]
        public virtual ICollection<PolSourceSiteEffect> PolSourceSiteEffectAnalysisDocumentTVItems { get; set; }
        [InverseProperty(nameof(PolSourceSiteEffect.MWQMSiteTVItem))]
        public virtual ICollection<PolSourceSiteEffect> PolSourceSiteEffectMWQMSiteTVItems { get; set; }
        [InverseProperty(nameof(PolSourceSiteEffect.PolSourceSiteOrInfrastructureTVItem))]
        public virtual ICollection<PolSourceSiteEffect> PolSourceSiteEffectPolSourceSiteOrInfrastructureTVItems { get; set; }
        [InverseProperty(nameof(PolSourceSite.CivicAddressTVItem))]
        public virtual ICollection<PolSourceSite> PolSourceSiteCivicAddressTVItems { get; set; }
        [InverseProperty(nameof(PolSourceSite.PolSourceSiteTVItem))]
        public virtual ICollection<PolSourceSite> PolSourceSitePolSourceSiteTVItems { get; set; }
        [InverseProperty(nameof(RainExceedanceClimateSite.ClimateSiteTVItem))]
        public virtual ICollection<RainExceedanceClimateSite> RainExceedanceClimateSiteClimateSiteTVItems { get; set; }
        [InverseProperty(nameof(RainExceedanceClimateSite.RainExceedanceTVItem))]
        public virtual ICollection<RainExceedanceClimateSite> RainExceedanceClimateSiteRainExceedanceTVItems { get; set; }
        [InverseProperty("RainExceedanceTVItem")]
        public virtual ICollection<RainExceedance> RainExceedances { get; set; }
        [InverseProperty("TVItem")]
        public virtual ICollection<ReportSection> ReportSections { get; set; }
        [InverseProperty("MWQMSiteTVItem")]
        public virtual ICollection<SamplingPlanSubsectorSite> SamplingPlanSubsectorSites { get; set; }
        [InverseProperty("SubsectorTVItem")]
        public virtual ICollection<SamplingPlanSubsector> SamplingPlanSubsectors { get; set; }
        [InverseProperty(nameof(SamplingPlan.CreatorTVItem))]
        public virtual ICollection<SamplingPlan> SamplingPlanCreatorTVItems { get; set; }
        [InverseProperty(nameof(SamplingPlan.ProvinceTVItem))]
        public virtual ICollection<SamplingPlan> SamplingPlanProvinceTVItems { get; set; }
        [InverseProperty(nameof(SamplingPlan.SamplingPlanFileTVItem))]
        public virtual ICollection<SamplingPlan> SamplingPlanSamplingPlanFileTVItems { get; set; }
        [InverseProperty(nameof(Spill.InfrastructureTVItem))]
        public virtual ICollection<Spill> SpillInfrastructureTVItems { get; set; }
        [InverseProperty(nameof(Spill.MunicipalityTVItem))]
        public virtual ICollection<Spill> SpillMunicipalityTVItems { get; set; }
        [InverseProperty("TVFileTVItem")]
        public virtual ICollection<TVFile> TVFiles { get; set; }
        [InverseProperty("TVItem")]
        public virtual ICollection<TVItemLanguage> TVItemLanguages { get; set; }
        [InverseProperty(nameof(TVItemLink.FromTVItem))]
        public virtual ICollection<TVItemLink> TVItemLinkFromTVItems { get; set; }
        [InverseProperty(nameof(TVItemLink.ToTVItem))]
        public virtual ICollection<TVItemLink> TVItemLinkToTVItems { get; set; }
        [InverseProperty("TVItem")]
        public virtual ICollection<TVItemStat> TVItemStats { get; set; }
        [InverseProperty(nameof(TVItemUserAuthorization.ContactTVItem))]
        public virtual ICollection<TVItemUserAuthorization> TVItemUserAuthorizationContactTVItems { get; set; }
        [InverseProperty(nameof(TVItemUserAuthorization.TVItemID1Navigation))]
        public virtual ICollection<TVItemUserAuthorization> TVItemUserAuthorizationTVItemID1Navigations { get; set; }
        [InverseProperty("ContactTVItem")]
        public virtual ICollection<TVTypeUserAuthorization> TVTypeUserAuthorizations { get; set; }
        [InverseProperty("TelTVItem")]
        public virtual ICollection<Tel> Tels { get; set; }
        [InverseProperty("TideSiteTVItem")]
        public virtual ICollection<TideDataValue> TideDataValues { get; set; }
        [InverseProperty("TideSiteTVItem")]
        public virtual ICollection<TideSite> TideSites { get; set; }
        [InverseProperty(nameof(UseOfSite.SiteTVItem))]
        public virtual ICollection<UseOfSite> UseOfSiteSiteTVItems { get; set; }
        [InverseProperty(nameof(UseOfSite.SubsectorTVItem))]
        public virtual ICollection<UseOfSite> UseOfSiteSubsectorTVItems { get; set; }
        [InverseProperty("InfrastructureTVItem")]
        public virtual ICollection<VPScenario> VPScenarios { get; set; }

        #endregion Properties in DB

        #region Constructors
        public TVItem() : base()
        {
        }
        #endregion Constructors
    }
}
