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
        public TVItemModel TVItemModel { get; set; }
        public List<TVItemModel> TVItemModelParentList { get; set; }
        public List<ClimateSiteModel> ClimateSiteModelList { get; set; }
        #endregion Properties

        #region Constructors
        public WebClimateSites()
        {
            TVItemModel = new TVItemModel();
            TVItemModelParentList = new List<TVItemModel>();
            ClimateSiteModelList = new List<ClimateSiteModel>();
        }
        #endregion Constructors
    }
}
