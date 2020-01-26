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
    public partial class MWQMSampleDuplicateItem : CSSPError
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [StringLength(200, MinimumLength = 1)]
        [CSSPDisplayEN(DisplayEN = "Parent site")]
        [CSSPDisplayFR(DisplayFR = "Site du parent")]
        [CSSPDescriptionEN(DescriptionEN = @"Parent site")]
        [CSSPDescriptionFR(DescriptionFR = @"Site du parent")]
        public string ParentSite { get; set; }
        [StringLength(200, MinimumLength = 1)]
        [CSSPDisplayEN(DisplayEN = "Duplicate site")]
        [CSSPDisplayFR(DisplayFR = "Site duplicata")]
        [CSSPDescriptionEN(DescriptionEN = @"Duplicate site")]
        [CSSPDescriptionFR(DescriptionFR = @"Site duplicata")]
        public string DuplicateSite { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public MWQMSampleDuplicateItem() : base()
        {
        }
        #endregion Constructors
    }
}
