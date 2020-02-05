using System;
using System.Collections.Generic;

namespace WebAPIPrototype.Models
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

        public int TVItemID { get; set; }
        public int TVLevel { get; set; }
        public string TVPath { get; set; }
        public int TVType { get; set; }
        public int ParentID { get; set; }
        public bool IsActive { get; set; }
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        public virtual TVItems Parent { get; set; }
        public virtual ICollection<Addresses> AddressesAddressTVItem { get; set; }
        public virtual ICollection<Addresses> AddressesCountryTVItem { get; set; }
        public virtual ICollection<Addresses> AddressesMunicipalityTVItem { get; set; }
        public virtual ICollection<Addresses> AddressesProvinceTVItem { get; set; }
        public virtual ICollection<AppTasks> AppTasksTVItem { get; set; }
        public virtual ICollection<AppTasks> AppTasksTVItemID2Navigation { get; set; }
        public virtual ICollection<BoxModels> BoxModels { get; set; }
        public virtual ICollection<Classifications> Classifications { get; set; }
        public virtual ICollection<ClimateSites> ClimateSites { get; set; }
        public virtual ICollection<Contacts> Contacts { get; set; }
        public virtual ICollection<DocTemplates> DocTemplates { get; set; }
        public virtual ICollection<DrogueRuns> DrogueRuns { get; set; }
        public virtual ICollection<EmailDistributionLists> EmailDistributionLists { get; set; }
        public virtual ICollection<Emails> Emails { get; set; }
        public virtual ICollection<HydrometricSites> HydrometricSites { get; set; }
        public virtual ICollection<Infrastructures> InfrastructuresCivicAddressTVItem { get; set; }
        public virtual ICollection<Infrastructures> InfrastructuresInfrastructureTVItem { get; set; }
        public virtual ICollection<Infrastructures> InfrastructuresSeeOtherMunicipalityTVItem { get; set; }
        public virtual ICollection<TVItems> InverseParent { get; set; }
        public virtual ICollection<LabSheetDetails> LabSheetDetails { get; set; }
        public virtual ICollection<LabSheetTubeMPNDetails> LabSheetTubeMPNDetails { get; set; }
        public virtual ICollection<LabSheets> LabSheetsAcceptedOrRejectedByContactTVItem { get; set; }
        public virtual ICollection<LabSheets> LabSheetsMWQMRunTVItem { get; set; }
        public virtual ICollection<LabSheets> LabSheetsSubsectorTVItem { get; set; }
        public virtual ICollection<MWQMAnalysisReportParameters> MWQMAnalysisReportParametersExcelTVFileTVItem { get; set; }
        public virtual ICollection<MWQMAnalysisReportParameters> MWQMAnalysisReportParametersSubsectorTVItem { get; set; }
        public virtual ICollection<MWQMRuns> MWQMRunsLabSampleApprovalContactTVItem { get; set; }
        public virtual ICollection<MWQMRuns> MWQMRunsMWQMRunTVItem { get; set; }
        public virtual ICollection<MWQMRuns> MWQMRunsSubsectorTVItem { get; set; }
        public virtual ICollection<MWQMSamples> MWQMSamplesMWQMRunTVItem { get; set; }
        public virtual ICollection<MWQMSamples> MWQMSamplesMWQMSiteTVItem { get; set; }
        public virtual ICollection<MWQMSiteStartEndDates> MWQMSiteStartEndDates { get; set; }
        public virtual ICollection<MWQMSites> MWQMSites { get; set; }
        public virtual ICollection<MWQMSubsectors> MWQMSubsectors { get; set; }
        public virtual ICollection<MapInfos> MapInfos { get; set; }
        public virtual ICollection<MikeBoundaryConditions> MikeBoundaryConditions { get; set; }
        public virtual ICollection<MikeScenarioResults> MikeScenarioResults { get; set; }
        public virtual ICollection<MikeScenarios> MikeScenarios { get; set; }
        public virtual ICollection<MikeSources> MikeSourcesHydrometricTVItem { get; set; }
        public virtual ICollection<MikeSources> MikeSourcesMikeSourceTVItem { get; set; }
        public virtual ICollection<PolSourceObservations> PolSourceObservations { get; set; }
        public virtual ICollection<PolSourceSiteEffects> PolSourceSiteEffectsAnalysisDocumentTVItem { get; set; }
        public virtual ICollection<PolSourceSiteEffects> PolSourceSiteEffectsMWQMSiteTVItem { get; set; }
        public virtual ICollection<PolSourceSiteEffects> PolSourceSiteEffectsPolSourceSiteOrInfrastructureTVItem { get; set; }
        public virtual ICollection<PolSourceSites> PolSourceSitesCivicAddressTVItem { get; set; }
        public virtual ICollection<PolSourceSites> PolSourceSitesPolSourceSiteTVItem { get; set; }
        public virtual ICollection<RainExceedanceClimateSites> RainExceedanceClimateSitesClimateSiteTVItem { get; set; }
        public virtual ICollection<RainExceedanceClimateSites> RainExceedanceClimateSitesRainExceedanceTVItem { get; set; }
        public virtual ICollection<RainExceedances> RainExceedances { get; set; }
        public virtual ICollection<ReportSections> ReportSections { get; set; }
        public virtual ICollection<SamplingPlanSubsectorSites> SamplingPlanSubsectorSites { get; set; }
        public virtual ICollection<SamplingPlanSubsectors> SamplingPlanSubsectors { get; set; }
        public virtual ICollection<SamplingPlans> SamplingPlansCreatorTVItem { get; set; }
        public virtual ICollection<SamplingPlans> SamplingPlansProvinceTVItem { get; set; }
        public virtual ICollection<SamplingPlans> SamplingPlansSamplingPlanFileTVItem { get; set; }
        public virtual ICollection<Spills> SpillsInfrastructureTVItem { get; set; }
        public virtual ICollection<Spills> SpillsMunicipalityTVItem { get; set; }
        public virtual ICollection<TVFiles> TVFiles { get; set; }
        public virtual ICollection<TVItemLanguages> TVItemLanguages { get; set; }
        public virtual ICollection<TVItemLinks> TVItemLinksFromTVItem { get; set; }
        public virtual ICollection<TVItemLinks> TVItemLinksToTVItem { get; set; }
        public virtual ICollection<TVItemStats> TVItemStats { get; set; }
        public virtual ICollection<TVItemUserAuthorizations> TVItemUserAuthorizationsContactTVItem { get; set; }
        public virtual ICollection<TVItemUserAuthorizations> TVItemUserAuthorizationsTVItemID1Navigation { get; set; }
        public virtual ICollection<TVTypeUserAuthorizations> TVTypeUserAuthorizations { get; set; }
        public virtual ICollection<Tels> Tels { get; set; }
        public virtual ICollection<TideDataValues> TideDataValues { get; set; }
        public virtual ICollection<TideSites> TideSites { get; set; }
        public virtual ICollection<UseOfSites> UseOfSitesSiteTVItem { get; set; }
        public virtual ICollection<UseOfSites> UseOfSitesSubsectorTVItem { get; set; }
        public virtual ICollection<VPScenarios> VPScenarios { get; set; }
    }
}
