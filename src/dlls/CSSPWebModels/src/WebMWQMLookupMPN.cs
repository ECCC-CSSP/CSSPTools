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
