/*
 * Manually edited
 * 
 */
using System.Collections.Generic;

namespace CSSPModels
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
