/*
 * Manually edited
 * 
 */
using System.Collections.Generic;

namespace CSSPModels
{
    public partial class WebSector : WebBase
    {
        #region Properties
        public List<WebBase> TVItemParentList { get; set; }
        public List<WebBase> TVItemSubsectorList { get; set; }      
        public List<WebBase> TVItemMikeScenarioList { get; set; }
        #endregion Properties

        #region Constructors
        public WebSector()
        {
            TVItemParentList = new List<WebBase>();
            TVItemSubsectorList = new List<WebBase>();
            TVItemMikeScenarioList = new List<WebBase>();
        }
        #endregion Constructors
    }
}
