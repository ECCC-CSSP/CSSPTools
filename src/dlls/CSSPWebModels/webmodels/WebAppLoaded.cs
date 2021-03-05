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
        public WebAllEmails WebAllEmails { get; set; }
        public WebAllTels WebAllTels { get; set; }
        public WebAllContacts WebAllContacts { get; set; }
        public WebAllCountries WebAllCountries { get; set; }
        public WebAllHelpDocs WebHelpDocs { get; set; }
        public WebAllMunicipalities WebAllMunicipalities { get; set; }
        public WebAllMWQMLookupMPNs WebAllMWQMLookupMPNs { get; set; }
        public WebAllPolSourceGroupings WebAllPolSourceGroupings { get; set; }
        public WebAllPolSourceSiteEffectTerms WebAllPolSourceSiteEffectTerms { get; set; }
        public WebAllProvinces WebAllProvinces { get; set; }
        public WebAllReportTypes WebAllReportTypes { get; set; }
        public WebAllTideLocations WebAllTideLocations { get; set; }
        public WebArea WebArea { get; set; }
        public WebClimateDataValue WebClimateDataValue { get; set; }
        public WebClimateSite WebClimateSite { get; set; }
        public WebCountry WebCountry { get; set; }
        public WebDrogueRun WebDrogueRun { get; set; }
        public WebHydrometricDataValue WebHydrometricDataValue { get; set; }
        public WebHydrometricSite WebHydrometricSite { get; set; }
        public WebMikeScenario WebMikeScenario { get; set; }
        public WebMunicipalities WebMunicipalities { get; set; }
        public WebMunicipality WebMunicipality { get; set; }
        public WebMWQMRun WebMWQMRun { get; set; }
        public WebMWQMSample WebMWQMSample1980_1989 { get; set; }
        public WebMWQMSample WebMWQMSample1990_1999 { get; set; }
        public WebMWQMSample WebMWQMSample2000_2009 { get; set; }
        public WebMWQMSample WebMWQMSample2010_2019 { get; set; }
        public WebMWQMSample WebMWQMSample2020_2029 { get; set; }
        public WebMWQMSample WebMWQMSample2030_2039 { get; set; }
        public WebMWQMSample WebMWQMSample2040_2049 { get; set; }
        public WebMWQMSample WebMWQMSample2050_2059 { get; set; }
        public WebMWQMSite WebMWQMSite { get; set; }
        public WebPolSourceSite WebPolSourceSite { get; set; }
        public WebProvince WebProvince { get; set; }
        public WebRoot WebRoot { get; set; }
        public WebSamplingPlan WebSamplingPlan { get; set; }
        public WebSector WebSector { get; set; }
        public WebSubsector WebSubsector { get; set; }

        #endregion Properties

        #region Constructors
        public WebAppLoaded()
        {
        }
        #endregion Constructors
    }
}
