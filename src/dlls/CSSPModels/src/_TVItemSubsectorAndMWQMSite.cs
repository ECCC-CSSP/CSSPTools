/*
 * Manually edited
 * 
 */
using CSSPEnums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CSSPModels
{
    [NotMapped]
    public partial class TVItemSubsectorAndMWQMSite
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        public TVItem TVItemSubsector { get; set; }
        public List<TVItem> TVItemMWQMSiteList { get; set; }
        public TVItem TVItemMWQMSiteDuplicate { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public TVItemSubsectorAndMWQMSite() : base()
        {
            TVItemMWQMSiteList = new List<TVItem>();
        }
        #endregion Constructors
    }
}
