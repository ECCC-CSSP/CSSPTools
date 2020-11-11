/*
 * Manually edited
 * 
 */
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSSPModels
{
    [NotMapped]
    public partial class WebMWQMLookupMPN
    {
        #region Properties
        public List<MWQMLookupMPN> MWQMLookupMPNList { get; set; }
        #endregion Properties

        #region Constructors
        public WebMWQMLookupMPN()
        {
            MWQMLookupMPNList = new List<MWQMLookupMPN>();
        }
        #endregion Constructors
    }
}
