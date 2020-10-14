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
        public int PreferenceID { get; set; }
        [CSSPMaxLength(200)]
        public string VariableName { get; set; }
        [CSSPMaxLength(300)]
        public string VariableValue { get; set; }
        #endregion Properties in DB

        #region Constructors
        public Preference() : base()
        {
        }
        #endregion Constructors
    }
}
