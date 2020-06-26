/*
 * Manually edited
 * 
 */
using CSSPModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSSPWebModels
{
    public partial class WebMWQMSite
    {
        #region Properties
        public List<MWQMSite> MWQMSiteList { get; set; }
        public List<MWQMSiteStartEndDate> MWQMSiteStartEndDateList { get; set; }
        #endregion Properties

        #region Constructors
        public WebMWQMSite()
        {
            MWQMSiteList = new List<MWQMSite>();
            MWQMSiteStartEndDateList = new List<MWQMSiteStartEndDate>();
        }
        #endregion Constructors
    }
}
