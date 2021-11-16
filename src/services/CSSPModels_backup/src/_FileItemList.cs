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
    public partial class FileItemList
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [CSSPMaxLength(255)]
        [CSSPMinLength(1)]
        public string Text { get; set; }
        [CSSPMaxLength(255)]
        [CSSPMinLength(1)]
        public string FileName { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public FileItemList() : base()
        {
        }
        #endregion Constructors
    }
}
