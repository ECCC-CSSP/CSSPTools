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
    public partial class LocalSpill : LocalBase
    {
        #region Properties in DB
        public Spill Spill { get; set; }
        #endregion Properties in DB

        #region Constructors
        public LocalSpill() : base()
        {
        }
        #endregion Constructors
    }


}
