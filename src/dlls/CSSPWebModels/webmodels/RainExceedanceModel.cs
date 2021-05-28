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
    public partial class RainExceedanceModel
    {
        #region Properties
        public TVItemModel TVItemModel { get; set; }
        public RainExceedance RainExceedance { get; set; }
        public List<RainExceedanceClimateSite> RainExceedanceClimateSiteList { get; set; } 
        #endregion Properties

        #region Constructors
        public RainExceedanceModel()
        {
            TVItemModel = new TVItemModel();
            RainExceedance = new RainExceedance();
            RainExceedanceClimateSiteList = new List<RainExceedanceClimateSite>();
        }
        #endregion Constructors
    }
}
