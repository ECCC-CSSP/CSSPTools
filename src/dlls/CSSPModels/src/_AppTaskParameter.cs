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
    public partial class AppTaskParameter
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [StringLength(255)]
        [CSSPDisplayEN(DisplayEN = "Name")]
        [CSSPDisplayFR(DisplayFR = "Nom")]
        [CSSPDescriptionEN(DescriptionEN = @"Name of the app task parameter")]
        [CSSPDescriptionFR(DescriptionFR = @"Nom du paramètre de app task")]
        public string Name { get; set; }
        [StringLength(255)]
        [CSSPDisplayEN(DisplayEN = "Value")]
        [CSSPDisplayFR(DisplayFR = "Valeur")]
        [CSSPDescriptionEN(DescriptionEN = @"Value of the app task parameter")]
        [CSSPDescriptionFR(DescriptionFR = @"Valeur du paramètre de app task")]
        public string Value { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public AppTaskParameter() : base()
        {
        }
        #endregion Constructors
    }
}
