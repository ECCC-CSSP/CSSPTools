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
    public partial class TideLocation : LastUpdate
    {
        #region Properties in DB
        [Key]
        public int TideLocationID { get; set; }
        [CSSPRange(0, 10000)]
        public int Zone { get; set; }
        [CSSPMaxLength(100)]
        public string Name { get; set; }
        [CSSPMaxLength(100)]
        public string Prov { get; set; }
        [CSSPRange(0, 100000)]
        public int sid { get; set; }
        [CSSPRange(-90.0D, 90.0D)]
        public double Lat { get; set; }
        [CSSPRange(-180.0D, 180.0D)]
        public double Lng { get; set; }
        #endregion Properties in DB

        #region Constructors
        public TideLocation() : base()
        {
        }
        #endregion Constructors
    }
}
