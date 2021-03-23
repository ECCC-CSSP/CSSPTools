﻿/*
 * Manually edited
 * 
 */
using CSSPDBModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSSPWebModels
{
    [NotMapped]
    public partial class WebSubsector : WebBase
    {
        #region Properties
        public List<WebBase> TVItemParentList { get; set; }
        public List<WebBase> TVItemFileList { get; set; }

        public List<WebBase> TVItemClassificationList { get; set; }
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
            TVItemFileList = new List<WebBase>();
            TVItemClassificationList = new List<WebBase>();
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
}