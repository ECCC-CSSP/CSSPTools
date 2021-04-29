/*
 * Manually edited
 * 
 */
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSSPWebModels
{
    [NotMapped]
    public partial class WebAppLoaded
    {
        #region Properties
        public WebAllAddresses WebAllAddresses { get; set; }
        public WebAllContacts WebAllContacts { get; set; }
        public WebAllCountries WebAllCountries { get; set; }
        public WebAllEmails WebAllEmails { get; set; }
        public WebAllHelpDocs WebAllHelpDocs { get; set; }
        public WebAllMunicipalities WebAllMunicipalities { get; set; }
        public WebAllMWQMLookupMPNs WebAllMWQMLookupMPNs { get; set; }
        public WebAllPolSourceGroupings WebAllPolSourceGroupings { get; set; }
        public WebAllPolSourceSiteEffectTerms WebAllPolSourceSiteEffectTerms { get; set; }
        public WebAllProvinces WebAllProvinces { get; set; }
        public WebAllReportTypes WebAllReportTypes { get; set; }
        public WebAllTels WebAllTels { get; set; }
        public WebAllTideLocations WebAllTideLocations { get; set; }
        public WebAllTVItemLanguages WebAllTVItemLanguages1980_2020 { get; set; }
        public WebAllTVItemLanguages WebAllTVItemLanguages2021_2060 { get; set; }
        public WebAllTVItems WebAllTVItems1980_2020 { get; set; }
        public WebAllTVItems WebAllTVItems2021_2060 { get; set; }
        public WebArea WebArea { get; set; }
        public WebClimateSites WebClimateSites { get; set; }
        public WebCountry WebCountry { get; set; }
        public WebDrogueRuns WebDrogueRuns { get; set; }
        public WebHydrometricSites WebHydrometricSites { get; set; }
        public WebLabSheets WebLabSheets { get; set; }
        public WebMikeScenarios WebMikeScenarios { get; set; }
        public WebMunicipality WebMunicipality { get; set; }
        public WebMWQMRuns WebMWQMRuns { get; set; }
        public WebMWQMSamples WebMWQMSamples1980_2020 { get; set; }
        public WebMWQMSamples WebMWQMSamples2021_2060 { get; set; }
        public WebMWQMSites WebMWQMSites { get; set; }
        public WebPolSourceSites WebPolSourceSites { get; set; }
        public WebProvince WebProvince { get; set; }
        public WebRoot WebRoot { get; set; }
        public WebSector WebSector { get; set; }
        public WebSubsector WebSubsector { get; set; }
        public WebTideSites WebTideSites { get; set; }

        #endregion Properties

        #region Constructors
        public WebAppLoaded()
        {
        }
        #endregion Constructors
    }
}
