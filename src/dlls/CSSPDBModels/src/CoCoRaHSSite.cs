﻿/*
 * Manually edited
 * 
 */
using CSSPCustomAttributes;
using CSSPEnums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CSSPDBModels
{
    public partial class CoCoRaHSSite : LastUpdate
    {
        #region Properties in DB
        [Key]
        public int CoCoRaHSSiteID { get; set; }
        [CSSPEnumType]
        public DBCommandEnum DBCommand { get; set; }
        [CSSPMaxLength(100)]
        public string StationNumber { get; set; }
        [CSSPMaxLength(100)]
        public string StationName { get; set; }
        [CSSPRange(-90.0D, 90.0D)]
        public double Latitude { get; set; }
        [CSSPRange(-180.0D, 180.0D)]
        public double Longitude { get; set; }
        #endregion Properties in DB

        #region Constructors
        public CoCoRaHSSite() : base()
        {
        }
        #endregion Constructors
    }
   
}
