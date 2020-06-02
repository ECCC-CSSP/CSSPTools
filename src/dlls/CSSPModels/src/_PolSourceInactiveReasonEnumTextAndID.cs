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
    public partial class PolSourceInactiveReasonEnumTextAndID
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [CSSPDisplayEN(DisplayEN = "Text")]
        [CSSPDisplayFR(DisplayFR = "Texte")]
        [CSSPDescriptionEN(DescriptionEN = @"Text")]
        [CSSPDescriptionFR(DescriptionFR = @"Texte")]
        public string Text { get; set; }
        [Range(1, -1)]
        [CSSPDisplayEN(DisplayEN = "ID")]
        [CSSPDisplayFR(DisplayFR = "ID")]
        [CSSPDescriptionEN(DescriptionEN = @"ID")]
        [CSSPDescriptionFR(DescriptionFR = @"Identifiant")]
        public int ID { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public PolSourceInactiveReasonEnumTextAndID() : base()
        {
        }
        #endregion Constructors
    }
}
