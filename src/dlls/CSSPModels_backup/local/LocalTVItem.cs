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
    public partial class LocalTVItem : LocalBase
    {
        #region Properties in DB
        public TVItem TVItem { get; set; }
        #endregion Properties in DB

        #region Constructors
        public LocalTVItem() : base()
        {
        }
        #endregion Constructors
    }


}
