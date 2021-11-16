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

namespace CSSPWebModels
{
    [NotMapped]
    public partial class ColorAndLetter
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        public string hexColor { get; set; }
        public string color { get; set; }
        public string letter { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public ColorAndLetter()
        {
        }
        #endregion Constructors
    }
}
