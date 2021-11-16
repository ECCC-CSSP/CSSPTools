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
    public partial class PolSourceGroupingModel
    {
        #region Properties
        public PolSourceGrouping PolSourceGrouping { get; set; }
        public List<PolSourceGroupingLanguage> PolSourceGroupingLanguageList { get; set; }
        #endregion Properties

        #region Constructors
        public PolSourceGroupingModel()
        {
            PolSourceGrouping = new PolSourceGrouping();
            PolSourceGroupingLanguageList = new List<PolSourceGroupingLanguage>();
        }
        #endregion Constructors
    }
}
