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
    public partial class FileItemList : CSSPError
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [StringLength(255, MinimumLength = 1)]
        [CSSPDisplayEN(DisplayEN = "Text")]
        [CSSPDisplayFR(DisplayFR = "Texte")]
        [CSSPDescriptionEN(DescriptionEN = @"Text")]
        [CSSPDescriptionFR(DescriptionFR = @"Texte")]
        public string Text { get; set; }
        [StringLength(255, MinimumLength = 1)]
        [CSSPDisplayEN(DisplayEN = "File name")]
        [CSSPDisplayFR(DisplayFR = "Nom du fichier")]
        [CSSPDescriptionEN(DescriptionEN = @"File name")]
        [CSSPDescriptionFR(DescriptionFR = @"Nom du fichier")]
        public string FileName { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public FileItemList() : base()
        {
        }
        #endregion Constructors
    }
}
