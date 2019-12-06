/*
 * Manually edited by Charles LeBlanc 
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
    public partial class FilePurposeAndText : CSSPError
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [CSSPEnumType]
        [CSSPDisplayEN(DisplayEN = "File purpose")]
        [CSSPDisplayFR(DisplayFR = "But du fichier")]
        [CSSPDescriptionEN(DescriptionEN = @"File purpose")]
        [CSSPDescriptionFR(DescriptionFR = @"But du fichier")]
        public FilePurposeEnum FilePurpose { get; set; }
        [StringLength(100)]
        [CSSPEnumTypeText(EnumTypeName = "FilePurposeEnum", EnumType = "FilePurpose")]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "File purpose text")]
        [CSSPDisplayFR(DisplayFR = "Texte du but du fichier")]
        [CSSPDescriptionEN(DescriptionEN = @"File purpose text")]
        [CSSPDescriptionFR(DescriptionFR = @"Texte du but du fichier")]
        public string FilePurposeText { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public FilePurposeAndText() : base()
        {
        }
        #endregion Constructors
    }
}
