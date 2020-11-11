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
