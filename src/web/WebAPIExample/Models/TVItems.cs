using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample.Models
{
    public partial class TVItems
    {
        public TVItems()
        {
            AddressesAddressTVItem = new HashSet<Addresses>();
            AddressesCountryTVItem = new HashSet<Addresses>();
            AddressesMunicipalityTVItem = new HashSet<Addresses>();
            AddressesProvinceTVItem = new HashSet<Addresses>();
            AppTasksTVItem = new HashSet<AppTasks>();
            AppTasksTVItemID2Navigation = new HashSet<AppTasks>();
            BoxModels = new HashSet<BoxModels>();
            Classifications = new HashSet<Classifications>();
            ClimateSites = new HashSet<ClimateSites>();
            Contacts = new HashSet<Contacts>();
            DocTemplates = new HashSet<DocTemplates>();
            DrogueRuns = new HashSet<DrogueRuns>();
            EmailDistributionLists = new HashSet<EmailDistributionLists>();
            Emails = new HashSet<Emails>();
            HydrometricSites = new HashSet<HydrometricSites>();
            InfrastructuresCivicAddressTVItem = new HashSet<Infrastructures>();
            InfrastructuresInfrastructureTVItem = new HashSet<Infrastructures>();
            InfrastructuresSeeOtherMunicipalityTVItem = new HashSet<Infrastructures>();
            InverseParent = new HashSet<TVItems>();
            LabSheetDetails = new HashSet<LabSheetDetails>();
            LabSheetTubeMPNDetails = new HashSet<LabSheetTubeMPNDetails>();
            LabSheetsAcceptedOrRejectedByContactTVItem = new HashSet<LabSheets>();
            LabSheetsMWQMRunTVItem = new HashSet<LabSheets>();
            LabSheetsSubsectorTVItem = new HashSet<LabSheets>();
            MWQMAnalysisReportParametersExcelTVFileTVItem = new HashSet<MWQMAnalysisReportParameters>();
            MWQMAnalysisReportParametersSubsectorTVItem = new HashSet<MWQMAnalysisReportParameters>();
            MWQMRunsLabSampleApprovalContactTVItem = new HashSet<MWQMRuns>();
            MWQMRunsMWQMRunTVItem = new HashSet<MWQMRuns>();
            MWQMRunsSubsectorTVItem = new HashSet<MWQMRuns>();
            MWQMSamplesMWQMRunTVItem = new HashSet<MWQMSamples>();
            MWQMSamplesMWQMSiteTVItem = new HashSet<MWQMSamples>();
            MWQMSiteStartEndDates = new HashSet<MWQMSiteStartEndDates>();
            MWQMSites = new HashSet<MWQMSites>();
            MWQMSubsectors = new HashSet<MWQMSubsectors>();
            MapInfos = new HashSet<MapInfos>();
            MikeBoundaryConditions = new HashSet<MikeBoundaryConditions>();
            MikeScenarioResults = new HashSet<MikeScenarioResults>();
            MikeScenarios = new HashSet<MikeScenarios>();
            MikeSourcesHydrometricTVItem = new HashSet<MikeSources>();
            MikeSourcesMikeSourceTVItem = new HashSet<MikeSources>();
            PolSourceObservations = new HashSet<PolSourceObservations>();
            PolSourceSiteEffectsAnalysisDocumentTVItem = new HashSet<PolSourceSiteEffects>();
            PolSourceSiteEffectsMWQMSiteTVItem = new HashSet<PolSourceSiteEffects>();
            PolSourceSiteEffectsPolSourceSiteOrInfrastructureTVItem = new HashSet<PolSourceSiteEffects>();
            PolSourceSitesCivicAddressTVItem = new HashSet<PolSourceSites>();
            PolSourceSitesPolSourceSiteTVItem = new HashSet<PolSourceSites>();
            RainExceedanceClimateSitesClimateSiteTVItem = new HashSet<RainExceedanceClimateSites>();
            RainExceedanceClimateSitesRainExceedanceTVItem = new HashSet<RainExceedanceClimateSites>();
            RainExceedances = new HashSet<RainExceedances>();
            ReportSections = new HashSet<ReportSections>();
            SamplingPlanSubsectorSites = new HashSet<SamplingPlanSubsectorSites>();
            SamplingPlanSubsectors = new HashSet<SamplingPlanSubsectors>();
            SamplingPlansCreatorTVItem = new HashSet<SamplingPlans>();
            SamplingPlansProvinceTVItem = new HashSet<SamplingPlans>();
            SamplingPlansSamplingPlanFileTVItem = new HashSet<SamplingPlans>();
            SpillsInfrastructureTVItem = new HashSet<Spills>();
            SpillsMunicipalityTVItem = new HashSet<Spills>();
            TVFiles = new HashSet<TVFiles>();
            TVItemLanguages = new HashSet<TVItemLanguages>();
            TVItemLinksFromTVItem = new HashSet<TVItemLinks>();
            TVItemLinksToTVItem = new HashSet<TVItemLinks>();
            TVItemStats = new HashSet<TVItemStats>();
            TVItemUserAuthorizationsContactTVItem = new HashSet<TVItemUserAuthorizations>();
            TVItemUserAuthorizationsTVItemID1Navigation = new HashSet<TVItemUserAuthorizations>();
            TVTypeUserAuthorizations = new HashSet<TVTypeUserAuthorizations>();
            Tels = new HashSet<Tels>();
            TideDataValues = new HashSet<TideDataValues>();
            TideSites = new HashSet<TideSites>();
            UseOfSitesSiteTVItem = new HashSet<UseOfSites>();
            UseOfSitesSubsectorTVItem = new HashSet<UseOfSites>();
            VPScenarios = new HashSet<VPScenarios>();
        }

        [Key]
        public int TVItemID { get; set; }
        public int TVLevel { get; set; }
        [Required]
        [StringLength(250)]
        public string TVPath { get; set; }
        public int TVType { get; set; }
        public int ParentID { get; set; }
        public bool IsActive { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        [ForeignKey(nameof(ParentID))]
        [InverseProperty(nameof(TVItems.InverseParent))]
        public virtual TVItems Parent { get; set; }
        [InverseProperty(nameof(Addresses.AddressTVItem))]
        public virtual ICollection<Addresses> AddressesAddressTVItem { get; set; }
        [InverseProperty(nameof(Addresses.CountryTVItem))]
        public virtual ICollection<Addresses> AddressesCountryTVItem { get; set; }
        [InverseProperty(nameof(Addresses.MunicipalityTVItem))]
        public virtual ICollection<Addresses> AddressesMunicipalityTVItem { get; set; }
        [InverseProperty(nameof(Addresses.ProvinceTVItem))]
        public virtual ICollection<Addresses> AddressesProvinceTVItem { get; set; }
        [InverseProperty(nameof(AppTasks.TVItem))]
        public virtual ICollection<AppTasks> AppTasksTVItem { get; set; }
        [InverseProperty(nameof(AppTasks.TVItemID2Navigation))]
        public virtual ICollection<AppTasks> AppTasksTVItemID2Navigation { get; set; }
        [InverseProperty("InfrastructureTVItem")]
        public virtual ICollection<BoxModels> BoxModels { get; set; }
        [InverseProperty("ClassificationTVItem")]
        public virtual ICollection<Classifications> Classifications { get; set; }
        [InverseProperty("ClimateSiteTVItem")]
        public virtual ICollection<ClimateSites> ClimateSites { get; set; }
        [InverseProperty("ContactTVItem")]
        public virtual ICollection<Contacts> Contacts { get; set; }
        [InverseProperty("TVFileTVItem")]
        public virtual ICollection<DocTemplates> DocTemplates { get; set; }
        [InverseProperty("SubsectorTVItem")]
        public virtual ICollection<DrogueRuns> DrogueRuns { get; set; }
        [InverseProperty("ParentTVItem")]
        public virtual ICollection<EmailDistributionLists> EmailDistributionLists { get; set; }
        [InverseProperty("EmailTVItem")]
        public virtual ICollection<Emails> Emails { get; set; }
        [InverseProperty("HydrometricSiteTVItem")]
        public virtual ICollection<HydrometricSites> HydrometricSites { get; set; }
        [InverseProperty(nameof(Infrastructures.CivicAddressTVItem))]
        public virtual ICollection<Infrastructures> InfrastructuresCivicAddressTVItem { get; set; }
        [InverseProperty(nameof(Infrastructures.InfrastructureTVItem))]
        public virtual ICollection<Infrastructures> InfrastructuresInfrastructureTVItem { get; set; }
        [InverseProperty(nameof(Infrastructures.SeeOtherMunicipalityTVItem))]
        public virtual ICollection<Infrastructures> InfrastructuresSeeOtherMunicipalityTVItem { get; set; }
        [InverseProperty(nameof(TVItems.Parent))]
        public virtual ICollection<TVItems> InverseParent { get; set; }
        [InverseProperty("SubsectorTVItem")]
        public virtual ICollection<LabSheetDetails> LabSheetDetails { get; set; }
        [InverseProperty("MWQMSiteTVItem")]
        public virtual ICollection<LabSheetTubeMPNDetails> LabSheetTubeMPNDetails { get; set; }
        [InverseProperty(nameof(LabSheets.AcceptedOrRejectedByContactTVItem))]
        public virtual ICollection<LabSheets> LabSheetsAcceptedOrRejectedByContactTVItem { get; set; }
        [InverseProperty(nameof(LabSheets.MWQMRunTVItem))]
        public virtual ICollection<LabSheets> LabSheetsMWQMRunTVItem { get; set; }
        [InverseProperty(nameof(LabSheets.SubsectorTVItem))]
        public virtual ICollection<LabSheets> LabSheetsSubsectorTVItem { get; set; }
        [InverseProperty(nameof(MWQMAnalysisReportParameters.ExcelTVFileTVItem))]
        public virtual ICollection<MWQMAnalysisReportParameters> MWQMAnalysisReportParametersExcelTVFileTVItem { get; set; }
        [InverseProperty(nameof(MWQMAnalysisReportParameters.SubsectorTVItem))]
        public virtual ICollection<MWQMAnalysisReportParameters> MWQMAnalysisReportParametersSubsectorTVItem { get; set; }
        [InverseProperty(nameof(MWQMRuns.LabSampleApprovalContactTVItem))]
        public virtual ICollection<MWQMRuns> MWQMRunsLabSampleApprovalContactTVItem { get; set; }
        [InverseProperty(nameof(MWQMRuns.MWQMRunTVItem))]
        public virtual ICollection<MWQMRuns> MWQMRunsMWQMRunTVItem { get; set; }
        [InverseProperty(nameof(MWQMRuns.SubsectorTVItem))]
        public virtual ICollection<MWQMRuns> MWQMRunsSubsectorTVItem { get; set; }
        [InverseProperty(nameof(MWQMSamples.MWQMRunTVItem))]
        public virtual ICollection<MWQMSamples> MWQMSamplesMWQMRunTVItem { get; set; }
        [InverseProperty(nameof(MWQMSamples.MWQMSiteTVItem))]
        public virtual ICollection<MWQMSamples> MWQMSamplesMWQMSiteTVItem { get; set; }
        [InverseProperty("MWQMSiteTVItem")]
        public virtual ICollection<MWQMSiteStartEndDates> MWQMSiteStartEndDates { get; set; }
        [InverseProperty("MWQMSiteTVItem")]
        public virtual ICollection<MWQMSites> MWQMSites { get; set; }
        [InverseProperty("MWQMSubsectorTVItem")]
        public virtual ICollection<MWQMSubsectors> MWQMSubsectors { get; set; }
        [InverseProperty("TVItem")]
        public virtual ICollection<MapInfos> MapInfos { get; set; }
        [InverseProperty("MikeBoundaryConditionTVItem")]
        public virtual ICollection<MikeBoundaryConditions> MikeBoundaryConditions { get; set; }
        [InverseProperty("MikeScenarioTVItem")]
        public virtual ICollection<MikeScenarioResults> MikeScenarioResults { get; set; }
        [InverseProperty("MikeScenarioTVItem")]
        public virtual ICollection<MikeScenarios> MikeScenarios { get; set; }
        [InverseProperty(nameof(MikeSources.HydrometricTVItem))]
        public virtual ICollection<MikeSources> MikeSourcesHydrometricTVItem { get; set; }
        [InverseProperty(nameof(MikeSources.MikeSourceTVItem))]
        public virtual ICollection<MikeSources> MikeSourcesMikeSourceTVItem { get; set; }
        [InverseProperty("ContactTVItem")]
        public virtual ICollection<PolSourceObservations> PolSourceObservations { get; set; }
        [InverseProperty(nameof(PolSourceSiteEffects.AnalysisDocumentTVItem))]
        public virtual ICollection<PolSourceSiteEffects> PolSourceSiteEffectsAnalysisDocumentTVItem { get; set; }
        [InverseProperty(nameof(PolSourceSiteEffects.MWQMSiteTVItem))]
        public virtual ICollection<PolSourceSiteEffects> PolSourceSiteEffectsMWQMSiteTVItem { get; set; }
        [InverseProperty(nameof(PolSourceSiteEffects.PolSourceSiteOrInfrastructureTVItem))]
        public virtual ICollection<PolSourceSiteEffects> PolSourceSiteEffectsPolSourceSiteOrInfrastructureTVItem { get; set; }
        [InverseProperty(nameof(PolSourceSites.CivicAddressTVItem))]
        public virtual ICollection<PolSourceSites> PolSourceSitesCivicAddressTVItem { get; set; }
        [InverseProperty(nameof(PolSourceSites.PolSourceSiteTVItem))]
        public virtual ICollection<PolSourceSites> PolSourceSitesPolSourceSiteTVItem { get; set; }
        [InverseProperty(nameof(RainExceedanceClimateSites.ClimateSiteTVItem))]
        public virtual ICollection<RainExceedanceClimateSites> RainExceedanceClimateSitesClimateSiteTVItem { get; set; }
        [InverseProperty(nameof(RainExceedanceClimateSites.RainExceedanceTVItem))]
        public virtual ICollection<RainExceedanceClimateSites> RainExceedanceClimateSitesRainExceedanceTVItem { get; set; }
        [InverseProperty("RainExceedanceTVItem")]
        public virtual ICollection<RainExceedances> RainExceedances { get; set; }
        [InverseProperty("TVItem")]
        public virtual ICollection<ReportSections> ReportSections { get; set; }
        [InverseProperty("MWQMSiteTVItem")]
        public virtual ICollection<SamplingPlanSubsectorSites> SamplingPlanSubsectorSites { get; set; }
        [InverseProperty("SubsectorTVItem")]
        public virtual ICollection<SamplingPlanSubsectors> SamplingPlanSubsectors { get; set; }
        [InverseProperty(nameof(SamplingPlans.CreatorTVItem))]
        public virtual ICollection<SamplingPlans> SamplingPlansCreatorTVItem { get; set; }
        [InverseProperty(nameof(SamplingPlans.ProvinceTVItem))]
        public virtual ICollection<SamplingPlans> SamplingPlansProvinceTVItem { get; set; }
        [InverseProperty(nameof(SamplingPlans.SamplingPlanFileTVItem))]
        public virtual ICollection<SamplingPlans> SamplingPlansSamplingPlanFileTVItem { get; set; }
        [InverseProperty(nameof(Spills.InfrastructureTVItem))]
        public virtual ICollection<Spills> SpillsInfrastructureTVItem { get; set; }
        [InverseProperty(nameof(Spills.MunicipalityTVItem))]
        public virtual ICollection<Spills> SpillsMunicipalityTVItem { get; set; }
        [InverseProperty("TVFileTVItem")]
        public virtual ICollection<TVFiles> TVFiles { get; set; }
        [InverseProperty("TVItem")]
        public virtual ICollection<TVItemLanguages> TVItemLanguages { get; set; }
        [InverseProperty(nameof(TVItemLinks.FromTVItem))]
        public virtual ICollection<TVItemLinks> TVItemLinksFromTVItem { get; set; }
        [InverseProperty(nameof(TVItemLinks.ToTVItem))]
        public virtual ICollection<TVItemLinks> TVItemLinksToTVItem { get; set; }
        [InverseProperty("TVItem")]
        public virtual ICollection<TVItemStats> TVItemStats { get; set; }
        [InverseProperty(nameof(TVItemUserAuthorizations.ContactTVItem))]
        public virtual ICollection<TVItemUserAuthorizations> TVItemUserAuthorizationsContactTVItem { get; set; }
        [InverseProperty(nameof(TVItemUserAuthorizations.TVItemID1Navigation))]
        public virtual ICollection<TVItemUserAuthorizations> TVItemUserAuthorizationsTVItemID1Navigation { get; set; }
        [InverseProperty("ContactTVItem")]
        public virtual ICollection<TVTypeUserAuthorizations> TVTypeUserAuthorizations { get; set; }
        [InverseProperty("TelTVItem")]
        public virtual ICollection<Tels> Tels { get; set; }
        [InverseProperty("TideSiteTVItem")]
        public virtual ICollection<TideDataValues> TideDataValues { get; set; }
        [InverseProperty("TideSiteTVItem")]
        public virtual ICollection<TideSites> TideSites { get; set; }
        [InverseProperty(nameof(UseOfSites.SiteTVItem))]
        public virtual ICollection<UseOfSites> UseOfSitesSiteTVItem { get; set; }
        [InverseProperty(nameof(UseOfSites.SubsectorTVItem))]
        public virtual ICollection<UseOfSites> UseOfSitesSubsectorTVItem { get; set; }
        [InverseProperty("InfrastructureTVItem")]
        public virtual ICollection<VPScenarios> VPScenarios { get; set; }
    }
}
