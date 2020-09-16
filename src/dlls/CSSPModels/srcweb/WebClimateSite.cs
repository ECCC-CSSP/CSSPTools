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
        public List<ClimateSite> ClimateSiteList { get; set; }
        public List<WebBase> TVItemClimateSiteList { get; set; }
        #endregion Properties

        #region Constructors
        public WebClimateSite()
        {
            ClimateSiteList = new List<ClimateSite>();
            TVItemClimateSiteList = new List<WebBase>();
        }
        #endregion Constructors
    }
}
