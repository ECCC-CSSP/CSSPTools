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
    public partial class Preference
    {
        #region Properties in DB
        [Key]
        public int PreferenceID { get; set; }
        [CSSPMaxLength(500)]
        public string PreferenceText { get; set; }
        #endregion Properties in DB

        #region Constructors
        public Preference() : base()
        {
        }
        #endregion Constructors
    }
}
