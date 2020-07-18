/*
 * Manually edited
 * 
 */
using System.Collections.Generic;

namespace CSSPModels
{
    public partial class WebTideLocation
    {
        #region Properties
        public List<TideLocation> TideLocationList { get; set; }
        #endregion Properties

        #region Constructors
        public WebTideLocation()
        {
            TideLocationList = new List<TideLocation>();
        }
        #endregion Constructors
    }
}
