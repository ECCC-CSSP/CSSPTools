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
    public partial class LocalContactPreference : LocalBase
    {
        #region Properties in DB
        public ContactPreference ContactPreference { get; set; }
        #endregion Properties in DB

        #region Constructors
        public LocalContactPreference() : base()
        {
        }
        #endregion Constructors
    }


}
