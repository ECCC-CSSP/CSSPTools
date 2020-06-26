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
    public partial class WebClimateSite
    {
        #region Properties
        public List<ClimateSite> ClimateSiteList { get; set; }
        #endregion Properties

        #region Constructors
        public WebClimateSite()
        {
            ClimateSiteList = new List<ClimateSite>();
        }
        #endregion Constructors
    }
}
