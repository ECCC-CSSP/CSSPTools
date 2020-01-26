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
    public partial class BoxModelResult : LastUpdate
    {
        #region Properties in DB
        [Key]
        [CSSPDisplayEN(DisplayEN = "BoxModelResult ID")]
        [CSSPDisplayFR(DisplayFR = "BoxModelResult ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Contains the unique ""identifier on each row of the BoxModelResults table")]
        [CSSPDescriptionFR(DescriptionFR = @"Contient l'identifiant unique sur chaque ligne de la table BoxModelResults")]
        public int BoxModelResultID { get; set; }
        [CSSPExist(ExistTypeName = "BoxModel", ExistPlurial = "s", ExistFieldID = "BoxModelID")]
        [CSSPDisplayEN(DisplayEN = "BoxModel link")]
        [CSSPDisplayFR(DisplayFR = "Lien BoxModel")]
        [CSSPDescriptionEN(DescriptionEN = @"BoxModel link to parent BoxModels table item")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien au parent BoxModel à l'item de la table BoxModels")]
        public int BoxModelID { get; set; }
        [CSSPEnumType]
        [CSSPDisplayEN(DisplayEN = "Result type")]
        [CSSPDisplayFR(DisplayFR = "Type de résultats")]
        [CSSPDescriptionEN(DescriptionEN = @"Result type")]
        [CSSPDescriptionFR(DescriptionFR = @"Type de résultats")]
        public BoxModelResultTypeEnum BoxModelResultType { get; set; }
        [Range(0.0D, -1.0D)]
        [CSSPDisplayEN(DisplayEN = "Volume (m3)")]
        [CSSPDisplayFR(DisplayFR = "Volume (m3)")]
        [CSSPDescriptionEN(DescriptionEN = @"Volume (m3) of estuary water required to uptain the expected fecal coliform concentration")]
        [CSSPDescriptionFR(DescriptionFR = @"Volume (m3) d'eau de l'estuaire nécessaire pour obtenir la concentration de coliform fécaux attendue")]
        public double Volume_m3 { get; set; }
        [Range(0.0D, -1.0D)]
        [CSSPDisplayEN(DisplayEN = "Surface (m2)")]
        [CSSPDisplayFR(DisplayFR = "Surface (m2)")]
        [CSSPDescriptionEN(DescriptionEN = @"Surface (m2) of estuary water required to uptain the expected fecal coliform concentration")]
        [CSSPDescriptionFR(DescriptionFR = @"Surface (m2) d'eau de l'estuaire nécessaire pour obtenir la concentration de coliform fécaux attendue")]
        public double Surface_m2 { get; set; }
        [Range(0.0D, 100000.0D)]
        [CSSPDisplayEN(DisplayEN = "Half circle radius (m)")]
        [CSSPDisplayFR(DisplayFR = "Rayon d'un demi cercle (m)")]
        [CSSPDescriptionEN(DescriptionEN = @"Half circle radius (m) of estuary water required to uptain the expected fecal coliform concentration")]
        [CSSPDescriptionFR(DescriptionFR = @"Rayon d'un demi cercle (m) d'eau de l'estuaire nécessaire pour obtenir la concentration de coliform fécaux attendue")]
        public double Radius_m { get; set; }
        [Range(0.0D, 360.0D)]
        [CSSPDisplayEN(DisplayEN = "Left side diameter line angle (deg)")]
        [CSSPDisplayFR(DisplayFR = "Angle de ligne du diamètre du côté gauche (deg)")]
        [CSSPDescriptionEN(DescriptionEN = @"Left side diameter line angle (deg) used to draw helf circle on a map")]
        [CSSPDescriptionFR(DescriptionFR = @"Angle de ligne du diamètre du côté gauche (deg) utilisé pour dessiner un demi-cercle sur une carte")]
        public double? LeftSideDiameterLineAngle_deg { get; set; }
        [Range(-90.0D, 90.0D)]
        [CSSPDisplayEN(DisplayEN = "Circle center latitude (deg)")]
        [CSSPDisplayFR(DisplayFR = "Latitude du centre du cercle (deg)")]
        [CSSPDescriptionEN(DescriptionEN = @"Circle center latitude (deg) used to draw half circle on a map")]
        [CSSPDescriptionFR(DescriptionFR = @"Latitude du centre du cercle (deg) utilisé pour dessiner un demi-cercle sur une carte")]
        public double? CircleCenterLatitude { get; set; }
        [Range(-180.0D, 180.0D)]
        [CSSPDisplayEN(DisplayEN = "Circle center longitude (deg)")]
        [CSSPDisplayFR(DisplayFR = "Longitude du centre du cercle (deg)")]
        [CSSPDescriptionEN(DescriptionEN = @"Circle center longitude (deg) used to draw half circle on a map")]
        [CSSPDescriptionFR(DescriptionFR = @"Longitude du centre du cercle (deg) utilisé pour dessiner un demi-cercle sur une carte")]
        public double? CircleCenterLongitude { get; set; }
        [CSSPDisplayEN(DisplayEN = "Fix length")]
        [CSSPDisplayFR(DisplayFR = "Longueur fixe")]
        [CSSPDescriptionEN(DescriptionEN = @"Fix length is used to indicate we want the rectangle length to be fix a certain length. Only the width of the rectangle will redimensioned in order to find the rectangle size  to uptain the expected fecal coliform concentration")]
        [CSSPDescriptionFR(DescriptionFR = @"La longueur fixe est utilisée pour indiquer que la longueur du rectangle doit être fixée sur une certaine longueur. Seule la largeur du rectangle sera redimensionnée afin de trouver la taille du rectangle pour obtenir la concentration de coliform fécaux attendue")]
        public bool FixLength { get; set; }
        [CSSPDisplayEN(DisplayEN = "Fix width")]
        [CSSPDisplayFR(DisplayFR = "Largeur fixe")]
        [CSSPDescriptionEN(DescriptionEN = @"Fix width is used to indicate we want the rectangle width to be fix a certain width. Only the length of the rectangle will redimensioned in order to find the rectangle size  to uptain the expected fecal coliform concentration")]
        [CSSPDescriptionFR(DescriptionFR = @"La largeur fixe est utilisée pour indiquer que la largeur du rectangle doit être fixée sur une certaine largeur. Seule la longueur du rectangle sera redimensionnée afin de trouver la taille du rectangle pour obtenir la concentration de coliform fécaux attendue")]
        public bool FixWidth { get; set; }
        [Range(0.0D, 100000.0D)]
        [CSSPDisplayEN(DisplayEN = "Rectangle length (m)")]
        [CSSPDisplayFR(DisplayFR = "Longueur du rectangle (m)")]
        [CSSPDescriptionEN(DescriptionEN = @"Rectangle length (m) of estuary water required to uptain the expected fecal coliform concentration")]
        [CSSPDescriptionFR(DescriptionFR = @"Longueur du rectangle (m) d'eau de l'estuaire nécessaire pour obtenir la concentration de coliform fécaux attendue")]
        public double RectLength_m { get; set; }
        [Range(0.0D, 100000.0D)]
        [CSSPDisplayEN(DisplayEN = "Rectangle width (m)")]
        [CSSPDisplayFR(DisplayFR = "Largeur du rectangle (m)")]
        [CSSPDescriptionEN(DescriptionEN = @"Rectangle width (m) of estuary water required to uptain the expected fecal coliform concentration")]
        [CSSPDescriptionFR(DescriptionFR = @"Largeur du rectangle (m) d'eau de l'estuaire nécessaire pour obtenir la concentration de coliform fécaux attendue")]
        public double RectWidth_m { get; set; }
        [Range(0.0D, 360.0D)]
        [CSSPDisplayEN(DisplayEN = "Left side rectangle line angle (deg)")]
        [CSSPDisplayFR(DisplayFR = "Angle de ligne du côté gauche du rectangle (deg)")]
        [CSSPDescriptionEN(DescriptionEN = @"Left side rectangle line angle (deg) used to draw rectangle on a map")]
        [CSSPDescriptionFR(DescriptionFR = @"Angle de ligne du côté gauche du rectangle (deg) utilisé pour dessiner un rectangle sur une carte")]
        public double? LeftSideLineAngle_deg { get; set; }
        [Range(-90.0D, 90.0D)]
        [CSSPDisplayEN(DisplayEN = "Left side line start latitude (deg)")]
        [CSSPDisplayFR(DisplayFR = "Latitude de départ de la ligne latérale gauche (deg)")]
        [CSSPDescriptionEN(DescriptionEN = @"Left side line start latitude (deg) used to draw half circle on a map")]
        [CSSPDescriptionFR(DescriptionFR = @"Latitude de départ de la ligne latérale gauche (deg) utilisé pour dessiner un demi-cercle sur une carte")]
        public double? LeftSideLineStartLatitude { get; set; }
        [Range(-180.0D, 180.0D)]
        [CSSPDisplayEN(DisplayEN = "Left side line start longitude (deg)")]
        [CSSPDisplayFR(DisplayFR = "Longitude de départ de la ligne latérale gauche (deg)")]
        [CSSPDescriptionEN(DescriptionEN = @"Left side line start longitude (deg) used to draw half circle on a map")]
        [CSSPDescriptionFR(DescriptionFR = @"Longitude de départ de la ligne latérale gauche (deg) utilisé pour dessiner un demi-cercle sur une carte")]
        public double? LeftSideLineStartLongitude { get; set; }
        #endregion Properties in DB

        #region Constructors
        public BoxModelResult() : base()
        {
        }
        #endregion Constructors
    }
}
