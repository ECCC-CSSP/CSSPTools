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
    public partial class URLNumberOfSamples
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [CSSPMaxLength(255)]
        [CSSPMinLength(1)]
        public string url { get; set; }
        public int NumberOfSamples { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public URLNumberOfSamples() : base()
        {
        }
        #endregion Constructors
    }
}
