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

    [NotMapped]
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
