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
    public partial class WebAllMWQMAnalysisReportParameters
    {
        #region Properties
        public List<MWQMAnalysisReportParameter> MWQMAnalysisReportParameterList { get; set; }
        #endregion Properties

        #region Constructors
        public WebAllMWQMAnalysisReportParameters()
        {
            MWQMAnalysisReportParameterList = new List<MWQMAnalysisReportParameter>();
        }
        #endregion Constructors
    }
}
