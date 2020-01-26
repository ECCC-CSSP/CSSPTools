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
    public partial class SamplingPlanEmail : LastUpdate
    {
        #region Properties in DB
        [Key]
        [CSSPDisplayEN(DisplayEN = "SamplingPlanEmail ID")]
        [CSSPDisplayFR(DisplayFR = "SamplingPlanEmail ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Contains the unique ""identifier on each row of the SamplingPlanEmails table")]
        [CSSPDescriptionFR(DescriptionFR = @"Contient l'identifiant unique sur chaque ligne de la table SamplingPlanEmails")]
        public int SamplingPlanEmailID { get; set; }
        [CSSPExist(ExistTypeName = "SamplingPlan", ExistPlurial = "s", ExistFieldID = "SamplingPlanID")]
        [CSSPDisplayEN(DisplayEN = "Sampling plan ID")]
        [CSSPDisplayFR(DisplayFR = "Plan d'échantillonnage ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the SamplingPlans table representing the sampling plan")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table SamplingPlans représentant le plan d'échantillonnage")]
        public int SamplingPlanID { get; set; }
        [StringLength(150)]
        [DataType(DataType.EmailAddress)]
        [CSSPDisplayEN(DisplayEN = "Email")]
        [CSSPDisplayFR(DisplayFR = "Courriel")]
        [CSSPDescriptionEN(DescriptionEN = @"Email")]
        [CSSPDescriptionFR(DescriptionFR = @"Courriel")]
        public string Email { get; set; }
        [CSSPDisplayEN(DisplayEN = "Is contractor")]
        [CSSPDisplayFR(DisplayFR = "Est un contracteur")]
        [CSSPDescriptionEN(DescriptionEN = @"Is contractor")]
        [CSSPDescriptionFR(DescriptionFR = @"Est un contracteur")]
        public bool IsContractor { get; set; }
        [CSSPDisplayEN(DisplayEN = "Lab sheet has value over 500")]
        [CSSPDisplayFR(DisplayFR = "La feuille de laboratoire a une valeur supérieur à 500")]
        [CSSPDescriptionEN(DescriptionEN = @"Lab sheet has value over 500")]
        [CSSPDescriptionFR(DescriptionFR = @"La feuille de laboratoire a une valeur supérieur à 500")]
        public bool LabSheetHasValueOver500 { get; set; }
        [CSSPDisplayEN(DisplayEN = "Lab sheet received")]
        [CSSPDisplayFR(DisplayFR = "Feuille de laboratoire reçu")]
        [CSSPDescriptionEN(DescriptionEN = @"Lab sheet received")]
        [CSSPDescriptionFR(DescriptionFR = @"Feuille de laboratoire reçu")]
        public bool LabSheetReceived { get; set; }
        [CSSPDisplayEN(DisplayEN = "Lab sheet accepted")]
        [CSSPDisplayFR(DisplayFR = "Feuille de laboratoire approuvé")]
        [CSSPDescriptionEN(DescriptionEN = @"Lab sheet accepted")]
        [CSSPDescriptionFR(DescriptionFR = @"Feuille de laboratoire approuvé")]
        public bool LabSheetAccepted { get; set; }
        [CSSPDisplayEN(DisplayEN = "Lab sheet rejected")]
        [CSSPDisplayFR(DisplayFR = "Feuille de laboratoire rejeté")]
        [CSSPDescriptionEN(DescriptionEN = @"Lab sheet rejected")]
        [CSSPDescriptionFR(DescriptionFR = @"Feuille de laboratoire rejeté")]
        public bool LabSheetRejected { get; set; }
        #endregion Properties in DB

        #region Constructors
        public SamplingPlanEmail() : base()
        {
        }
        #endregion Constructors
    }
}
