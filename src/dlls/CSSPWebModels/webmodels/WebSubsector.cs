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
        public TVItemStatMapModel TVItemStatMapModel { get; set; }
        public List<TVItemStatModel> TVItemStatModelParentList { get; set; }
        public List<TVFileModel> TVFileModelList { get; set; }
        public List<TVItemStatMapModel> TVItemStatMapModelClassificationList { get; set; }
        public List<MWQMAnalysisReportParameter> MWQMAnalysisReportParameterList { get; set; }
        public MWQMSubsector MWQMSubsector { get; set; }
        public List<MWQMSubsectorLanguage> MWQMSubsectorLanguageList { get; set; }
        public List<UseOfSite> UseOfSiteList { get; set; }
        #endregion Properties

        #region Constructors
        public WebSubsector()
        {
            TVItemStatMapModel = new TVItemStatMapModel();
            TVItemStatModelParentList = new List<TVItemStatModel>();
            TVFileModelList = new List<TVFileModel>();
            TVItemStatMapModelClassificationList = new List<TVItemStatMapModel>();
            MWQMAnalysisReportParameterList = new List<MWQMAnalysisReportParameter>();
            MWQMSubsector = new MWQMSubsector();
            MWQMSubsectorLanguageList = new List<MWQMSubsectorLanguage>();
            UseOfSiteList = new List<UseOfSite>();
        }
        #endregion Constructors
    }
}
