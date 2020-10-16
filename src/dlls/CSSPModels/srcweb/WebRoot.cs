/*
 * Manually edited
 * 
 */
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSSPModels
{
    [NotMapped]
    public partial class WebRoot : WebBase
    {
        #region Properties
        public List<WebBase> TVItemParentList { get; set; }
        public List<WebBase> TVItemCountryList { get; set; }
        #endregion Properties

        #region Constructors
        public WebRoot() : base()
        {
            TVItemParentList = new List<WebBase>();
            TVItemCountryList = new List<WebBase>();
        }
        #endregion Constructors
    }
}
