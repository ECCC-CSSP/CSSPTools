/*
 * Manually edited
 * 
 */
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSSPModels
{
    [NotMapped]
    public partial class WebSubsector : WebBase
    {
        #region Properties
        public List<WebBase> TVItemParentList { get; set; }
        public List<WebBase> TVItemMWQMSiteList { get; set; }
        public List<WebBase> TVItemMWQMRunList { get; set; }
        public List<WebBase> TVItemPolSourceSiteList { get; set; }
        public List<MWQMAnalysisReportParameter> MWQMAnalysisReportParameterList { get; set; }
        public List<LabSheetModel> LabSheetModelList { get; set; }
        public MWQMSubsector MWQMSubsector { get; set; }
        public List<MWQMSubsectorLanguage> MWQMSubsectorLanguageList { get; set; }
        public List<UseOfSite> UseOfSiteList { get; set; }
        #endregion Properties

        #region Constructors
        public WebSubsector()
        {
            TVItemParentList = new List<WebBase>();
            TVItemMWQMSiteList = new List<WebBase>();
            TVItemMWQMRunList = new List<WebBase>();
            TVItemPolSourceSiteList = new List<WebBase>();
            MWQMAnalysisReportParameterList = new List<MWQMAnalysisReportParameter>();
            LabSheetModelList = new List<LabSheetModel>();
            MWQMSubsector = new MWQMSubsector();
            MWQMSubsectorLanguageList = new List<MWQMSubsectorLanguage>();
            UseOfSiteList = new List<UseOfSite>();
        }
        #endregion Constructors
    }

    [NotMapped]
    public partial class LabSheetModel
    {
        #region Properties
        public LabSheet LabSheet { get; set; }
        public List<LabSheetDetailModel> LabSheetDetailModelList { get; set; }
        #endregion Properties

        #region Constructors
        public LabSheetModel()
        {
            LabSheet = new LabSheet();
            LabSheetDetailModelList = new List<LabSheetDetailModel>();
        }
        #endregion Constructors
    }

    [NotMapped]
    public partial class LabSheetDetailModel
    {
        #region Properties
        public LabSheetDetail LabSheetDetail { get; set; }
        public List<LabSheetTubeMPNDetail> LabSheetTubeMPNDetailList { get; set; }
        #endregion Properties

        #region Constructors
        public LabSheetDetailModel()
        {
            LabSheetDetail = new LabSheetDetail();
            LabSheetTubeMPNDetailList = new List<LabSheetTubeMPNDetail>();

        }
        #endregion Constructors
    }
}
