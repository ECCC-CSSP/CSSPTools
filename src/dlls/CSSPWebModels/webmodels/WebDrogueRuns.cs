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
    public partial class WebDrogueRuns
    {
        #region Properties
        public TVItemStatMapModel TVItemStatMapModel { get; set; }
        public List<TVItemStatModel> TVItemStatModelParentList { get; set; }
        public List<DrogueRunModel> DrogueRunModelList { get; set; }
        #endregion Properties

        #region Constructors
        public WebDrogueRuns()
        {
            TVItemStatMapModel = new TVItemStatMapModel();
            TVItemStatModelParentList = new List<TVItemStatModel>();
            DrogueRunModelList = new List<DrogueRunModel>();
        }
        #endregion Constructors
    }
}
