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
    public partial class WebClimateSites
    {
        #region Properties
        public TVItemStatMapModel TVItemStatMapModel { get; set; }
        public List<TVItemStatModel> TVItemStatModelParentList { get; set; }
        public List<ClimateSiteModel> ClimateSiteModelList { get; set; }
        #endregion Properties

        #region Constructors
        public WebClimateSites()
        {
            TVItemStatMapModel = new TVItemStatMapModel();
            TVItemStatModelParentList = new List<TVItemStatModel>();
            ClimateSiteModelList = new List<ClimateSiteModel>();
        }
        #endregion Constructors
    }
}
