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
        public TVItem TVItem { get; set; }
        public List<TVItemLanguage> TVItemLanguageList { get; set; }
        public RainExceedance RainExceedance { get; set; }
        public List<RainExceedanceClimateSite> RainExceedanceClimateSiteList { get; set; } 
        #endregion Properties

        #region Constructors
        public RainExceedanceModel()
        {
            TVItem = new TVItem();
            TVItemLanguageList = new List<TVItemLanguage>();
            RainExceedance = new RainExceedance();
            RainExceedanceClimateSiteList = new List<RainExceedanceClimateSite>();
        }
        #endregion Constructors
    }
}
