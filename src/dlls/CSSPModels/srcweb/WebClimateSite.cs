/*
 * Manually edited
 * 
 */
using System.Collections.Generic;

namespace CSSPModels
{
    public partial class WebClimateSite
    {
        #region Properties
        public List<WebBase> TVItemParentList { get; set; }
        public List<ClimateSite> ClimateSiteList { get; set; }
        public List<WebBase> TVItemClimateSiteList { get; set; }
        #endregion Properties

        #region Constructors
        public WebClimateSite()
        {
            TVItemParentList = new List<WebBase>();
            ClimateSiteList = new List<ClimateSite>();
            TVItemClimateSiteList = new List<WebBase>();
        }
        #endregion Constructors
    }
}
