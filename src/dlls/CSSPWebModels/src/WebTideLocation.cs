/*
 * Manually edited
 * 
 */
using CSSPModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSSPWebModels
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
