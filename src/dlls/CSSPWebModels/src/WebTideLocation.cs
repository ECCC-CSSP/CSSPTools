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
