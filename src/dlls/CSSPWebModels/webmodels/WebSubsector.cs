/*
 * Manually edited
 * 
 */
using CSSPDBModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSSPWebModels
{
    [NotMapped]
    public partial class WebSubsector
    {
        #region Properties
        public TVItemModel TVItemModel { get; set; }
        public List<TVItemModel> TVItemModelParentList { get; set; }
        public List<TVFileModel> TVFileModelList { get; set; }
        public List<TVItemModel> TVItemModelClassificationList { get; set; }
        public List<TVItemModel> TVItemModelMWQMSiteList { get; set; }
        public List<TVItemModel> TVItemModelMWQMRunList { get; set; }
        public List<TVItemModel> TVItemModelPolSourceSiteList { get; set; }
        public List<MWQMAnalysisReportParameter> MWQMAnalysisReportParameterList { get; set; }
        public MWQMSubsector MWQMSubsector { get; set; }
        public List<MWQMSubsectorLanguage> MWQMSubsectorLanguageList { get; set; }
        public List<UseOfSite> UseOfSiteList { get; set; }
        #endregion Properties

        #region Constructors
        public WebSubsector()
        {
            TVItemModel = new TVItemModel();
            TVItemModelParentList = new List<TVItemModel>();
            TVFileModelList = new List<TVFileModel>();
            TVItemModelClassificationList = new List<TVItemModel>();
            TVItemModelMWQMSiteList = new List<TVItemModel>();
            TVItemModelMWQMRunList = new List<TVItemModel>();
            TVItemModelPolSourceSiteList = new List<TVItemModel>();
            MWQMAnalysisReportParameterList = new List<MWQMAnalysisReportParameter>();
            MWQMSubsector = new MWQMSubsector();
            MWQMSubsectorLanguageList = new List<MWQMSubsectorLanguage>();
            UseOfSiteList = new List<UseOfSite>();
        }
        #endregion Constructors
    }
}
