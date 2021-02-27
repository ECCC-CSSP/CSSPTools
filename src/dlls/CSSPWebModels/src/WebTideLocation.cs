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
    public partial class WebAllTideLocations
    {
        #region Properties
        public List<TideLocation> TideLocationList { get; set; }
        #endregion Properties

        #region Constructors
        public WebAllTideLocations()
        {
            TideLocationList = new List<TideLocation>();
        }
        #endregion Constructors
    }
}
