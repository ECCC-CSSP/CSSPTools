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
    public partial class WebAllReportTypes
    {
        #region Properties
        public List<ReportTypeModel> ReportTypeModelList { get; set; }
        #endregion Properties

        #region Constructors
        public WebAllReportTypes()
        {
            ReportTypeModelList = new List<ReportTypeModel>();
        }
        #endregion Constructors
    }
}