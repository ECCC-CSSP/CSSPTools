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
    public partial class PolSourceGrouping : LastUpdate
    {
        #region Properties in DB
        [Key]
        [CSSPDisplayEN(DisplayEN = "PolSourceGroupingD ID")]
        [CSSPDisplayFR(DisplayFR = "PolSourceGrouping ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Contains the unique ""identifier on each row of the PolSourceGroupings table")]
        [CSSPDescriptionFR(DescriptionFR = @"Contient l'identifiant unique sur chaque ligne de la table PolSourceGroupings")]
        public int PolSourceGroupingID { get; set; }
        [Range(10000, 100000)]
        [CSSPDisplayEN(DisplayEN = "CSSP unique ID")]
        [CSSPDisplayFR(DisplayFR = "Identifiant unique de CSSP")]
        [CSSPDescriptionEN(DescriptionEN = @"CSSP unique ID")]
        [CSSPDescriptionFR(DescriptionFR = @"Identifiant unique de CSSP")]
        public int CSSPID { get; set; }
        [StringLength(150)]
        [CSSPDisplayEN(DisplayEN = "Group name")]
        [CSSPDisplayFR(DisplayFR = "Nom du groupe")]
        [CSSPDescriptionEN(DescriptionEN = @"Groupe name")]
        [CSSPDescriptionFR(DescriptionFR = @"Nom du groupe")]
        public string GroupName { get; set; }
        [StringLength(150)]
        [CSSPDisplayEN(DisplayEN = "Group name")]
        [CSSPDisplayFR(DisplayFR = "Nom du groupe")]
        [CSSPDescriptionEN(DescriptionEN = @"Groupe name")]
        [CSSPDescriptionFR(DescriptionFR = @"Nom du groupe")]
        public string Child { get; set; }
        [StringLength(150)]
        [CSSPDisplayEN(DisplayEN = "Group name")]
        [CSSPDisplayFR(DisplayFR = "Nom du groupe")]
        [CSSPDescriptionEN(DescriptionEN = @"Groupe name")]
        [CSSPDescriptionFR(DescriptionFR = @"Nom du groupe")]
        public string Hide { get; set; }
        #endregion Properties in DB

        #region Constructors
        public PolSourceGrouping() : base()
        {
        }
        #endregion Constructors
    }
}
