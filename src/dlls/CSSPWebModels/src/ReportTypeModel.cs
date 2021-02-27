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