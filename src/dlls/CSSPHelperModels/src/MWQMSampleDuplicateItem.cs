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

namespace CSSPHelperModels
{
    [NotMapped]
    public partial class MWQMSampleDuplicateItem
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [CSSPMaxLength(200)]
        [CSSPMinLength(1)]
        public string ParentSite { get; set; }
        [CSSPMaxLength(200)]
        [CSSPMinLength(1)]
        public string DuplicateSite { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public MWQMSampleDuplicateItem() : base()
        {
        }
        #endregion Constructors
    }
}
