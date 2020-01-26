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
    public partial class RainExceedance : LastUpdate
    {
        #region Properties in DB
        [Key]
        [CSSPDisplayEN(DisplayEN = "RainExceedance ID")]
        [CSSPDisplayFR(DisplayFR = "RainExceedance ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Contains the unique ""identifier on each row of the RainExceedances table")]
        [CSSPDescriptionFR(DescriptionFR = @"Contient l'identifiant unique sur chaque ligne de la table RainExceedances")]
        public int RainExceedanceID { get; set; }
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "75")]
        [CSSPDisplayEN(DisplayEN = "Rain Exceedance TVItemID")]
        [CSSPDisplayFR(DisplayFR = "Rain Exceedance TVItemID (fr)")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the TVItems table representing rain exceedance")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table TVItems représentant l'item rain exceedance (fr)")]
        public int RainExceedanceTVItemID { get; set; }
        [Range(1, 12)]
        [CSSPDisplayEN(DisplayEN = "Starting month")]
        [CSSPDisplayFR(DisplayFR = "Mois de départ")]
        [CSSPDescriptionEN(DescriptionEN = @"Starting month")]
        [CSSPDescriptionFR(DescriptionFR = @"Mois de départ")]
        public int StartMonth { get; set; }
        [Range(1, 31)]
        [CSSPDisplayEN(DisplayEN = "Starting day")]
        [CSSPDisplayFR(DisplayFR = "Jour de départ")]
        [CSSPDescriptionEN(DescriptionEN = @"Starting day")]
        [CSSPDescriptionFR(DescriptionFR = @"Jour de départ")]
        public int StartDay { get; set; }
        [Range(1, 12)]
        [CSSPDisplayEN(DisplayEN = "Ending month")]
        [CSSPDisplayFR(DisplayFR = "Mois de fin")]
        [CSSPDescriptionEN(DescriptionEN = @"Ending month")]
        [CSSPDescriptionFR(DescriptionFR = @"Mois de fin")]
        public int EndMonth { get; set; }
        [Range(1, 31)]
        [CSSPDisplayEN(DisplayEN = "Ending day")]
        [CSSPDisplayFR(DisplayFR = "Jour de fin")]
        [CSSPDescriptionEN(DescriptionEN = @"Ending day")]
        [CSSPDescriptionFR(DescriptionFR = @"Jour de fin")]
        public int EndDay { get; set; }
        [Range(0.0D, 300.0D)]
        [CSSPDisplayEN(DisplayEN = "Rain maximum (mm)")]
        [CSSPDisplayFR(DisplayFR = "Pluie maximale (mm)")]
        [CSSPDescriptionEN(DescriptionEN = @"Rain maximum in millimètres")]
        [CSSPDescriptionFR(DescriptionFR = @"Pluie maximale en millimètres")]
        public double RainMaximum_mm { get; set; }
        [CSSPExist(ExistTypeName = "EmailDistributionList", ExistPlurial = "s", ExistFieldID = "EmailDistributionListID")]
        [CSSPDisplayEN(DisplayEN = "Email distribution list")]
        [CSSPDisplayFR(DisplayFR = "Liste de distribution de courriels")]
        [CSSPDescriptionEN(DescriptionEN = @"Email distribution list")]
        [CSSPDescriptionFR(DescriptionFR = @"Liste de distribution de courriels")]
        public int? StakeholdersEmailDistributionListID { get; set; }
        [CSSPExist(ExistTypeName = "EmailDistributionList", ExistPlurial = "s", ExistFieldID = "EmailDistributionListID")]
        [CSSPDisplayEN(DisplayEN = "Email distribution list")]
        [CSSPDisplayFR(DisplayFR = "Liste de distribution de courriels")]
        [CSSPDescriptionEN(DescriptionEN = @"Email distribution list")]
        [CSSPDescriptionFR(DescriptionFR = @"Liste de distribution de courriels")]
        public int? OnlyStaffEmailDistributionListID { get; set; }
        [CSSPDisplayEN(DisplayEN = "Active")]
        [CSSPDisplayFR(DisplayFR = "Actif")]
        [CSSPDescriptionEN(DescriptionEN = @"The rain exceedance is active")]
        [CSSPDescriptionFR(DescriptionFR = @"L'excédance de pluie est actif")]
        public bool IsActive { get; set; }
        #endregion Properties in DB

        #region Constructors
        public RainExceedance() : base()
        {
        }
        #endregion Constructors
    }
}
