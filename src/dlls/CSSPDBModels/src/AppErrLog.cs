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

namespace CSSPDBModels
{
    public partial class AppErrLog : LastUpdate
    {
        #region Properties in DB
        [Key]
        public int AppErrLogID { get; set; }
        [CSSPMaxLength(100)]
        public string Tag { get; set; }
        [CSSPRange(1, -1)]
        public int LineNumber { get; set; }
        public string Source { get; set; }
        public string Message { get; set; }
        [CSSPAfter(Year = 1980)]
        public DateTime DateTime_UTC { get; set; }
        #endregion Properties in DB

        #region Constructors
        public AppErrLog() : base()
        {
        }
        #endregion Constructors
    }
}
