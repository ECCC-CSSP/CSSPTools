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
    public partial class LocalHelpDoc : LocalBase
    {
        #region Properties in DB
        public HelpDoc HelpDoc { get; set; }
        #endregion Properties in DB

        #region Constructors
        public LocalHelpDoc() : base()
        {
        }
        #endregion Constructors
    }


}
