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
    public partial class WebTideSite : WebBase
    {
        #region Properties
        public List<WebBase> TVItemParentList { get; set; }
        public List<TideSite> TideSiteList { get; set; }
        public List<WebBase> TVItemTideSiteList { get; set; }
        #endregion Properties

        #region Constructors
        public WebTideSite()
        {
            TVItemParentList = new List<WebBase>();
            TideSiteList = new List<TideSite>();
            TVItemTideSiteList = new List<WebBase>();
        }
        #endregion Constructors
    }
}
