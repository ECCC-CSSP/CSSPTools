/*
 * Manually edited
 * 
 */
using System.Collections.Generic;

namespace CSSPModels
{
    public partial class WebSubsector : WebBase
    {
        #region Properties
        public List<WebBase> TVItemMWQMSiteList { get; set; }
        public List<WebBase> TVItemMWQMRunList { get; set; }
        public List<WebBase> TVItemPolSourceSiteList { get; set; }

        public List<MWQMAnalysisReportParameter> MWQMAnalysisReportParameterList { get; set; }

        public List<LabSheet> LabSheetList { get; set; }
        public List<LabSheetDetail> LabSheetDetailList { get; set; }
        public List<LabSheetTubeMPNDetail> LabSheetTubeMPNDetailList { get; set; }

        public MWQMSubsector MWQMSubsector { get; set; }
        public List<MWQMSubsectorLanguage> MWQMSubsectorLanguageList { get; set; }
        public List<UseOfSite> UseOfSiteList { get; set; }
        #endregion Properties

        #region Constructors
        public WebSubsector()
        {
            TVItemMWQMSiteList = new List<WebBase>();
            TVItemMWQMRunList = new List<WebBase>();
            TVItemPolSourceSiteList = new List<WebBase>();

            MWQMAnalysisReportParameterList = new List<MWQMAnalysisReportParameter>();

            LabSheetList = new List<LabSheet>();
            LabSheetDetailList = new List<LabSheetDetail>();
            LabSheetTubeMPNDetailList = new List<LabSheetTubeMPNDetail>();

            MWQMSubsector = new MWQMSubsector();
            MWQMSubsectorLanguageList = new List<MWQMSubsectorLanguage>();
            UseOfSiteList = new List<UseOfSite>();
        }
        #endregion Constructors
    }
}
