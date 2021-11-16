/*
 * Manually edited
 * 
 */
using CSSPEnums;
using CSSPModels.local;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CSSPModels
{
    public partial class LocalUseOfSite : LocalBase
    {
        #region Properties in DB
        public UseOfSite UseOfSite { get; set; }
        #endregion Properties in DB

        #region Constructors
        public LocalUseOfSite() : base()
        {
        }
        #endregion Constructors
    }


}
