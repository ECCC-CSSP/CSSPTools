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
    public partial class PolSourceObservationIssue : LastUpdate
    {
        #region Properties in DB
        [Key]
        [CSSPDisplayEN(DisplayEN = "PolSourceObservationIssue ID")]
        [CSSPDisplayFR(DisplayFR = "PolSourceObservationIssue ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Contains the unique ""identifier on each row of the PolSourceObservationIssues table")]
        [CSSPDescriptionFR(DescriptionFR = @"Contient l'identifiant unique sur chaque ligne de la table PolSourceObservationIssues")]
        public int PolSourceObservationIssueID { get; set; }
        [CSSPExist(ExistTypeName = "PolSourceObservation", ExistPlurial = "s", ExistFieldID = "PolSourceObservationID")]
        [CSSPDisplayEN(DisplayEN = "Pollution source observation ID")]
        [CSSPDisplayFR(DisplayFR = "Observation de la source de pollution ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the PolSourceObservations table representing the pollution source observation")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table PolSourceObservations représentant l'observation de source de pollution")]
        public int PolSourceObservationID { get; set; }
        [StringLength(250)]
        [CSSPDisplayEN(DisplayEN = "Observation information")]
        [CSSPDisplayFR(DisplayFR = "L'information de l'observation")]
        [CSSPDescriptionEN(DescriptionEN = @"Observation information is a series of numbers representing the path of a collection of descriptive text")]
        [CSSPDescriptionFR(DescriptionFR = @"L'information de l'observation est une liste de chiffres représentant la ligne d'une collection de texte descriptif")]
        public string ObservationInfo { get; set; }
        [Range(0, 1000)]
        [CSSPDisplayEN(DisplayEN = "Ordinal")]
        [CSSPDisplayFR(DisplayFR = "Ordre")]
        [CSSPDescriptionEN(DescriptionEN = @"Ordinal")]
        [CSSPDescriptionFR(DescriptionFR = @"Ordre")]
        public int Ordinal { get; set; }
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Extra comment")]
        [CSSPDisplayFR(DisplayFR = "Commentaire d'extra")]
        [CSSPDescriptionEN(DescriptionEN = @"Extra comment")]
        [CSSPDescriptionFR(DescriptionFR = @"Commentaire d'extra")]
        public string ExtraComment { get; set; }

        [ForeignKey(nameof(PolSourceObservationID))]
        [InverseProperty(nameof(PolSourceObservation.PolSourceObservationIssues))]
        public virtual PolSourceObservation PolSourceObservationNavigation { get; set; }
        #endregion Properties in DB

        #region Constructors
        public PolSourceObservationIssue() : base()
        {
        }
        #endregion Constructors
    }
}
