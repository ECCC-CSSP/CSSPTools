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
    public partial class PolSourceGrouping : LastUpdate
    {
        #region Properties in DB
        [Key]
        public int PolSourceGroupingID { get; set; }
        [CSSPRange(10000, 100000)]
        public int CSSPID { get; set; }
        [CSSPMaxLength(500)]
        public string GroupName { get; set; }
        [CSSPMaxLength(500)]
        public string Child { get; set; }
        [CSSPMaxLength(500)]
        public string Hide { get; set; }
        #endregion Properties in DB

        #region Constructors
        public PolSourceGrouping() : base()
        {
        }
        #endregion Constructors
    }
}
