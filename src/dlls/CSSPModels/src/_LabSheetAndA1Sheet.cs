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
    public partial class LabSheetAndA1Sheet : CSSPError
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [CSSPDisplayEN(DisplayEN = "Lab sheet")]
        [CSSPDisplayFR(DisplayFR = "Feuille de lab")]
        [CSSPDescriptionEN(DescriptionEN = @"Laboratory sheet")]
        [CSSPDescriptionFR(DescriptionFR = @"Feuille de laboratoire")]
        public LabSheet LabSheet { get; set; }
        [CSSPDisplayEN(DisplayEN = "Lab sheet A1")]
        [CSSPDisplayFR(DisplayFR = "Feuille de laboratoir A1")]
        [CSSPDescriptionEN(DescriptionEN = @"Lab sheet A1")]
        [CSSPDescriptionFR(DescriptionFR = @"Feuille de laboratoir A1")]
        public LabSheetA1Sheet LabSheetA1Sheet { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public LabSheetAndA1Sheet() : base()
        {
        }
        #endregion Constructors
    }
}
