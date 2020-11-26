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
        public MWQMSite MWQMSite { get; set; }
        public List<StatMWQMSiteSample> StatMWQMSiteSampleList { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public StatMWQMSite() : base()
        {
        }
        #endregion Constructors
    }
}
