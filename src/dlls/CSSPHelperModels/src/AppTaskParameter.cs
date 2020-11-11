/*
 * Manually edited
 * 
 */
using CSSPEnums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CSSPHelperModels
{
    [NotMapped]
    public partial class AppTaskParameter
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [CSSPMaxLength(255)]
        public string Name { get; set; }
        [CSSPMaxLength(255)]
        public string Value { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public AppTaskParameter() : base()
        {
        }
        #endregion Constructors
    }
}
