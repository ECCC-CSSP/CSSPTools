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
    public partial class MikeBoundaryCondition : LastUpdate
    {
        #region Properties in DB
        [Key]
        [CSSPDisplayEN(DisplayEN = "MikeBoundaryCondition ID")]
        [CSSPDisplayFR(DisplayFR = "MikeBoundaryCondition ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Contains the unique ""identifier on each row of the MikeBoundaryConditions table")]
        [CSSPDescriptionFR(DescriptionFR = @"Contient l'identifiant unique sur chaque ligne de la table MikeBoundaryConditions")]
        public int MikeBoundaryConditionID { get; set; }
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "12,11")]
        [CSSPDisplayEN(DisplayEN = "MIKE boundary contidition TVItemID")]
        [CSSPDisplayFR(DisplayFR = "TVItemID de conditions limits MIKE")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the TVItems table representing the MIKE boundary condition")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table TVItems représentant les conditions limits MIKE")]
        public int MikeBoundaryConditionTVItemID { get; set; }
        [StringLength(100)]
        [CSSPDisplayEN(DisplayEN = "MIKE boundary contidition code")]
        [CSSPDisplayFR(DisplayFR = "Code de conditions limits MIKE")]
        [CSSPDescriptionEN(DescriptionEN = @"MIKE boundary contidition code")]
        [CSSPDescriptionFR(DescriptionFR = @"Code de conditions limits MIKE")]
        public string MikeBoundaryConditionCode { get; set; }
        [StringLength(100)]
        [CSSPDisplayEN(DisplayEN = "MIKE boundary contidition name")]
        [CSSPDisplayFR(DisplayFR = "Nom de conditions limits MIKE")]
        [CSSPDescriptionEN(DescriptionEN = @"MIKE boundary contidition name")]
        [CSSPDescriptionFR(DescriptionFR = @"Nom de conditions limits MIKE")]
        public string MikeBoundaryConditionName { get; set; }
        [Range(1.0D, 100000.0D)]
        [CSSPDisplayEN(DisplayEN = "MIKE boundary contidition length (m)")]
        [CSSPDisplayFR(DisplayFR = "Longueur de conditions limits MIKE (m)")]
        [CSSPDescriptionEN(DescriptionEN = @"MIKE boundary contidition length in meters")]
        [CSSPDescriptionFR(DescriptionFR = @"Longueur de conditions limits MIKE en mètres")]
        public double MikeBoundaryConditionLength_m { get; set; }
        [StringLength(100)]
        [CSSPDisplayEN(DisplayEN = "MIKE boundary contidition format")]
        [CSSPDisplayFR(DisplayFR = "Format de conditions limits MIKE")]
        [CSSPDescriptionEN(DescriptionEN = @"MIKE boundary contidition format")]
        [CSSPDescriptionFR(DescriptionFR = @"Format de conditions limits MIKE")]
        public string MikeBoundaryConditionFormat { get; set; }
        [CSSPEnumType]
        [CSSPDisplayEN(DisplayEN = "MIKE boundary contidition level of velocity")]
        [CSSPDisplayFR(DisplayFR = "Niveau ou vélocité de conditions limits MIKE")]
        [CSSPDescriptionEN(DescriptionEN = @"MIKE boundary contidition level or velocity")]
        [CSSPDescriptionFR(DescriptionFR = @"Niveau ou vélocité de conditions limits MIKE")]
        public MikeBoundaryConditionLevelOrVelocityEnum MikeBoundaryConditionLevelOrVelocity { get; set; }
        [CSSPEnumType]
        [CSSPDisplayEN(DisplayEN = "Web tide data set")]
        [CSSPDisplayFR(DisplayFR = "Donnée web tide")]
        [CSSPDescriptionEN(DescriptionEN = @"Web tide data set")]
        [CSSPDescriptionFR(DescriptionFR = @"Donnée web tide")]
        public WebTideDataSetEnum WebTideDataSet { get; set; }
        [Range(0, 1000)]
        [CSSPDisplayEN(DisplayEN = "Number of web tide node")]
        [CSSPDisplayFR(DisplayFR = "Nombre de noeux de web tide")]
        [CSSPDescriptionEN(DescriptionEN = @"Number of web tide node")]
        [CSSPDescriptionFR(DescriptionFR = @"Nombre de noeux de web tide")]
        public int NumberOfWebTideNodes { get; set; }
        [CSSPDisplayEN(DisplayEN = "Web tide data between dates")]
        [CSSPDisplayFR(DisplayFR = "Données web tide entre les dates")]
        [CSSPDescriptionEN(DescriptionEN = @"Web tide data between dates")]
        [CSSPDescriptionFR(DescriptionFR = @"Données web tide entre les dates")]
        public string WebTideDataFromStartToEndDate { get; set; }
        [CSSPEnumType]
        [CSSPDisplayEN(DisplayEN = "TV type")]
        [CSSPDisplayFR(DisplayFR = "Type d'arbre visuel")]
        [CSSPDescriptionEN(DescriptionEN = @"Tree view type")]
        [CSSPDescriptionFR(DescriptionFR = @"Type d'arbre visuel")]
        public TVTypeEnum TVType { get; set; }

        [ForeignKey(nameof(MikeBoundaryConditionTVItemID))]
        [InverseProperty(nameof(TVItem.MikeBoundaryConditions))]
        public virtual TVItem MikeBoundaryConditionTVItem { get; set; }
        #endregion Properties in DB

        #region Constructors
        public MikeBoundaryCondition() : base()
        {
        }
        #endregion Constructors
    }
}
