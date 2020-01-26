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
    public partial class MikeSource : LastUpdate
    {
        #region Properties in DB
        [Key]
        [CSSPDisplayEN(DisplayEN = "MikeSource ID")]
        [CSSPDisplayFR(DisplayFR = "MikeSource ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Contains the unique ""identifier on each row of the MikeSources table")]
        [CSSPDescriptionFR(DescriptionFR = @"Contient l'identifiant unique sur chaque ligne de la table MikeSources")]
        public int MikeSourceID { get; set; }
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "14")]
        [CSSPDisplayEN(DisplayEN = "MIKE source TVItemID")]
        [CSSPDisplayFR(DisplayFR = "Item de source MIKE")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the TVItems table representing MIKE source")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table TVItems représentant une source MIKE")]
        public int MikeSourceTVItemID { get; set; }
        [CSSPDisplayEN(DisplayEN = "Continuous")]
        [CSSPDisplayFR(DisplayFR = "Continue")]
        [CSSPDescriptionEN(DescriptionEN = @"Source is continuous")]
        [CSSPDescriptionFR(DescriptionFR = @"La source est continue")]
        public bool IsContinuous { get; set; }
        [CSSPDisplayEN(DisplayEN = "Include")]
        [CSSPDisplayFR(DisplayFR = "Inclue")]
        [CSSPDescriptionEN(DescriptionEN = @"Source is included")]
        [CSSPDescriptionFR(DescriptionFR = @"La source est incluse")]
        public bool Include { get; set; }
        [CSSPDisplayEN(DisplayEN = "River")]
        [CSSPDisplayFR(DisplayFR = "Rivière")]
        [CSSPDescriptionEN(DescriptionEN = @"Source is a river")]
        [CSSPDescriptionFR(DescriptionFR = @"La source est une rivière")]
        public bool IsRiver { get; set; }
        [CSSPDisplayEN(DisplayEN = "Use hydrometric site")]
        [CSSPDisplayFR(DisplayFR = "Utilise site hydrometric")]
        [CSSPDescriptionEN(DescriptionEN = @"Source should use hydrometric site with factor for discharge")]
        [CSSPDescriptionFR(DescriptionFR = @"La source devrait usiliser un site hydrométrique avec facteur comme débits")]
        public bool UseHydrometric { get; set; }
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "9")]
        [CSSPDisplayEN(DisplayEN = "Hydrometric site")]
        [CSSPDisplayFR(DisplayFR = "Site hydrométrique")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the TVItems table representing hydrometric site")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table TVItems représentant un site hydrométrique")]
        public int? HydrometricTVItemID { get; set; }
        [Range(0.0D, 1000000.0D)]
        [CSSPDisplayEN(DisplayEN = "Drainage area (km2)")]
        [CSSPDisplayFR(DisplayFR = "Bassin versant (km2)")]
        [CSSPDescriptionEN(DescriptionEN = @"Drainage area in square kilometers")]
        [CSSPDescriptionFR(DescriptionFR = @"Bassin versant en kilomètres carrés")]
        public double? DrainageArea_km2 { get; set; }
        [Range(0.0D, 1000000.0D)]
        [CSSPDisplayEN(DisplayEN = "Factor")]
        [CSSPDisplayFR(DisplayFR = "Facteur")]
        [CSSPDescriptionEN(DescriptionEN = @"Factor")]
        [CSSPDescriptionFR(DescriptionFR = @"Facteur")]
        public double? Factor { get; set; }
        [StringLength(50)]
        [CSSPDisplayEN(DisplayEN = "Source number")]
        [CSSPDisplayFR(DisplayFR = "Nombre de source")]
        [CSSPDescriptionEN(DescriptionEN = @"Source number")]
        [CSSPDescriptionFR(DescriptionFR = @"Nombre de source")]
        public string SourceNumberString { get; set; }
        #endregion Properties in DB

        #region Constructors
        public MikeSource() : base()
        {
        }
        #endregion Constructors
    }
}
