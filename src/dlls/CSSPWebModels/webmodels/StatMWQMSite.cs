/*
 * Manually edited
 * 
 */
using CSSPDBModels;
using CSSPEnums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CSSPWebModels
{
    [NotMapped]
    public partial class StatMWQMSite
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        public TVItemModel TVItemModel { get; set; }
        public MWQMSiteModel MWQMSiteModel { get; set; }
        public List<StatMWQMSiteSample> StatMWQMSiteSampleList { get; set; }
        public double SalinityAverage { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public StatMWQMSite() : base()
        {
        }
        #endregion Constructors
    }
}
