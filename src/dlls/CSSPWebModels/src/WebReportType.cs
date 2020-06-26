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
    public partial class WebReportType
    {
        #region Properties
        public List<ReportType> ReportTypeList { get; set; }
        public List<ReportSection> ReportSectionList { get; set; }
        #endregion Properties

        #region Constructors
        public WebReportType()
        {
            ReportTypeList = new List<ReportType>();
            ReportSectionList = new List<ReportSection>();
        }
        #endregion Constructors
    }
}
