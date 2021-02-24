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
        public WebAllCountries WebAllCountries { get; set; }
        public WebAllMunicipalities WebAllMunicipalities { get; set; }
        public WebAllProvinces WebAllProvinces { get; set; }
        public WebArea WebArea { get; set; }
        public WebClimateDataValue WebClimateDataValue { get; set; }
        public WebClimateSite WebClimateSite { get; set; }
        public WebContact WebContact { get; set; }
        public WebCountry WebCountry { get; set; }
        public WebDrogueRun WebDrogueRun { get; set; }
        public WebHelpDoc WebHelpDoc { get; set; }
        public WebHydrometricDataValue WebHydrometricDataValue { get; set; }
        public WebHydrometricSite WebHydrometricSite { get; set; }
        public WebMikeScenario WebMikeScenario { get; set; }
        public WebMunicipalities WebMunicipalities { get; set; }
        public WebMunicipality WebMunicipality { get; set; }
        public WebMWQMLookupMPN WebMWQMLookupMPN { get; set; }
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
        public WebPolSourceGrouping WebPolSourceGrouping { get; set; }
        public WebPolSourceSite WebPolSourceSite { get; set; }
        public WebPolSourceSiteEffectTerm WebPolSourceSiteEffectTerm { get; set; }
        public WebProvince WebProvince { get; set; }
        public WebReportType WebReportType { get; set; }
        public WebRoot WebRoot { get; set; }
        public WebSamplingPlan WebSamplingPlan { get; set; }
        public WebSector WebSector { get; set; }
        public WebSubsector WebSubsector { get; set; }
        public WebTideLocation WebTideLocation { get; set; }

        #endregion Properties

        #region Constructors
        public WebAppLoaded()
        {
        }
        #endregion Constructors
    }
}
