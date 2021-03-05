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
    public partial class WebAllPolSourceGroupings
    {
        #region Properties
        public List<PolSourceGrouping> PolSourceGroupingList { get; set; }
        public List<PolSourceGroupingLanguage> PolSourceGroupingLanguageList { get; set; }
        #endregion Properties

        #region Constructors
        public WebAllPolSourceGroupings()
        {
            PolSourceGroupingList = new List<PolSourceGrouping>();
            PolSourceGroupingLanguageList = new List<PolSourceGroupingLanguage>();
        }
        #endregion Constructors
    }
}
