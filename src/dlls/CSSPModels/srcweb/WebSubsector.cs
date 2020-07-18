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
        public List<TVItem> TVItemMWQMSiteList { get; set; }
        public List<TVItemLanguage> TVItemLanguageMWQMSiteList { get; set; }
        public List<TVItemStat> TVItemStatMWQMSiteList { get; set; }
        public List<MapInfo> MapInfoMWQMSiteList { get; set; }
        public List<MapInfoPoint> MapInfoPointMWQMSiteList { get; set; }

        public List<TVItem> TVItemMWQMRunList { get; set; }
        public List<TVItemLanguage> TVItemLanguageMWQMRunList { get; set; }
        public List<TVItemStat> TVItemStatMWQMRunList { get; set; }

        public List<TVItem> TVItemPolSourceSiteList { get; set; }
        public List<TVItemLanguage> TVItemLanguagePolSourceSiteList { get; set; }
        public List<TVItemStat> TVItemStatPolSourceSiteList { get; set; }
        public List<MapInfo> MapInfoPolSourceSiteList { get; set; }
        public List<MapInfoPoint> MapInfoPointPolSourceSiteList { get; set; }

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
            TVItemMWQMSiteList = new List<TVItem>();
            TVItemLanguageMWQMSiteList = new List<TVItemLanguage>();
            TVItemStatMWQMSiteList = new List<TVItemStat>();
            MapInfoMWQMSiteList = new List<MapInfo>();
            MapInfoPointMWQMSiteList = new List<MapInfoPoint>();

            TVItemMWQMRunList = new List<TVItem>();
            TVItemLanguageMWQMRunList = new List<TVItemLanguage>();
            TVItemStatMWQMRunList = new List<TVItemStat>();

            TVItemPolSourceSiteList = new List<TVItem>();
            TVItemLanguagePolSourceSiteList = new List<TVItemLanguage>();
            TVItemStatPolSourceSiteList = new List<TVItemStat>();
            MapInfoPolSourceSiteList = new List<MapInfo>();
            MapInfoPointPolSourceSiteList = new List<MapInfoPoint>();

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
