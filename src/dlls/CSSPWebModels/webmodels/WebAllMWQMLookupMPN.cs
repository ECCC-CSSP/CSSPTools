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
    public partial class WebAllMWQMLookupMPNs
    {
        #region Properties
        public List<MWQMLookupMPN> MWQMLookupMPNList { get; set; }
        #endregion Properties

        #region Constructors
        public WebAllMWQMLookupMPNs()
        {
            MWQMLookupMPNList = new List<MWQMLookupMPN>();
        }
        #endregion Constructors
    }
}
