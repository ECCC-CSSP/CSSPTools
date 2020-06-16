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
    public partial class LabSheetAndA1Sheet
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        public LabSheet LabSheet { get; set; }
        public LabSheetA1Sheet LabSheetA1Sheet { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public LabSheetAndA1Sheet() : base()
        {
        }
        #endregion Constructors
    }
}
