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
    public partial class MapInfoPoint : LastUpdate
    {
        #region Properties in DB
        [Key]
        [CSSPDisplayEN(DisplayEN = "MapInfoPoint ID")]
        [CSSPDisplayFR(DisplayFR = "MapInfoPoint ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Contains the unique ""identifier on each row of the MapInfoPoints table")]
        [CSSPDescriptionFR(DescriptionFR = @"Contient l'identifiant unique sur chaque ligne de la table MapInfoPoints")]
        public int MapInfoPointID { get; set; }
        [CSSPExist(ExistTypeName = "MapInfo", ExistPlurial = "s", ExistFieldID = "MapInfoID")]
        [CSSPDisplayEN(DisplayEN = "Map info")]
        [CSSPDisplayFR(DisplayFR = "Info de carte")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the MapInfos table representing the map information")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table MapInfos représentant l'information de carte")]
        public int MapInfoID { get; set; }
        [Range(0, -1)]
        [CSSPDisplayEN(DisplayEN = "Ordinal")]
        [CSSPDisplayFR(DisplayFR = "Ordre")]
        [CSSPDescriptionEN(DescriptionEN = @"Ordinal")]
        [CSSPDescriptionFR(DescriptionFR = @"Ordre")]
        public int Ordinal { get; set; }
        [Range(-90.0D, 90.0D)]
        [CSSPDisplayEN(DisplayEN = "Latitude")]
        [CSSPDisplayFR(DisplayFR = "Latitude")]
        [CSSPDescriptionEN(DescriptionEN = @"Latitude")]
        [CSSPDescriptionFR(DescriptionFR = @"Latitude")]
        public double Lat { get; set; }
        [Range(-180.0D, 180.0D)]
        [CSSPDisplayEN(DisplayEN = "Longitude")]
        [CSSPDisplayFR(DisplayFR = "Longitude")]
        [CSSPDescriptionEN(DescriptionEN = @"Longitude")]
        [CSSPDescriptionFR(DescriptionFR = @"Longitude")]
        public double Lng { get; set; }

        [ForeignKey(nameof(MapInfoID))]
        [InverseProperty(nameof(MapInfo.MapInfoPoints))]
        public virtual MapInfo MapInfoNavigation { get; set; }
        #endregion Properties in DB

        #region Constructors
        public MapInfoPoint() : base()
        {
        }
        #endregion Constructors
    }
}
