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
    public partial class MapObj
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [Range(1, -1)]
        [CSSPDisplayEN(DisplayEN = "MapInfoID")]
        [CSSPDisplayFR(DisplayFR = "MapInfoID")]
        [CSSPDescriptionEN(DescriptionEN = @"MapInfoID of the MapInfos database table")]
        [CSSPDescriptionFR(DescriptionFR = @"MapInfoID de la table MapInfos de la base de données")]
        public int MapInfoID { get; set; }
        [CSSPEnumType]
        [CSSPDisplayEN(DisplayEN = "Map info draw type")]
        [CSSPDisplayFR(DisplayFR = "Type d'object de l'info pour carte")]
        [CSSPDescriptionEN(DescriptionEN = @"Map info draw type")]
        [CSSPDescriptionFR(DescriptionFR = @"Type d'object de l'info pour carte")]
        public MapInfoDrawTypeEnum MapInfoDrawType { get; set; }
        [StringLength(100)]
        [CSSPEnumTypeText(EnumTypeName = "MapInfoDrawTypeEnum", EnumType = "MapInfoDrawType")]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Map info draw type text")]
        [CSSPDisplayFR(DisplayFR = "Texte du type d'object de l'info pour carte")]
        [CSSPDescriptionEN(DescriptionEN = @"Map info draw type text")]
        [CSSPDescriptionFR(DescriptionFR = @"Texte du type d'object de l'info pour carte")]
        public string MapInfoDrawTypeText { get; set; }
        [CSSPDisplayEN(DisplayEN = "Coord list")]
        [CSSPDisplayFR(DisplayFR = "List Coord")]
        [CSSPDescriptionEN(DescriptionEN = @"Coord list")]
        [CSSPDescriptionFR(DescriptionFR = @"List Coord")]
        public List<Coord> CoordList { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public MapObj() : base()
        {
            CoordList = new List<Coord>();
        }
        #endregion Constructors
    }
}
