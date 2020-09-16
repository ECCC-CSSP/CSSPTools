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
        public List<ReportTypeModel> ReportTypeModelList { get; set; }
        #endregion Properties

        #region Constructors
        public WebReportType()
        {
            ReportTypeModelList = new List<ReportTypeModel>();
        }
        #endregion Constructors
    }

    public partial class ReportTypeModel
    {
        #region Properties
        public ReportType ReportType { get; set; }
        public List<ReportSection> ReportSectionList { get; set; }
        #endregion Properties

        #region Constructors
        public ReportTypeModel()
        {
            ReportType = new ReportType();
            ReportSectionList = new List<ReportSection>();
        }
        #endregion Constructors

    }
}
