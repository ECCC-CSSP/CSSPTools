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
    public partial class SamplingPlan : LastUpdate
    {
        #region Properties in DB
        [Key]
        [CSSPDisplayEN(DisplayEN = "SamplingPlan ID")]
        [CSSPDisplayFR(DisplayFR = "SamplingPlan ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Contains the unique ""identifier on each row of the SamplingPlans table")]
        [CSSPDescriptionFR(DescriptionFR = @"Contient l'identifiant unique sur chaque ligne de la table SamplingPlans")]
        public int SamplingPlanID { get; set; }
        [CSSPDisplayEN(DisplayEN = "Is active")]
        [CSSPDisplayFR(DisplayFR = "Est actif")]
        [CSSPDescriptionEN(DescriptionEN = @"Is active")]
        [CSSPDescriptionFR(DescriptionFR = @"Est actif")]
        public bool IsActive { get; set; }
        [StringLength(200)]
        [CSSPDisplayEN(DisplayEN = "Sampling plan name")]
        [CSSPDisplayFR(DisplayFR = "Nom du plan d'échantillonnage")]
        [CSSPDescriptionEN(DescriptionEN = @"Sampling plan name")]
        [CSSPDescriptionFR(DescriptionFR = @"Nom du plan d'échantillonnage")]
        public string SamplingPlanName { get; set; }
        [StringLength(100)]
        [CSSPDisplayEN(DisplayEN = "For group name")]
        [CSSPDisplayFR(DisplayFR = "Nom pour le group")]
        [CSSPDescriptionEN(DescriptionEN = @"For group name")]
        [CSSPDescriptionFR(DescriptionFR = @"Nom pour le group")]
        public string ForGroupName { get; set; }
        [CSSPEnumType]
        [CSSPDisplayEN(DisplayEN = "Sample type")]
        [CSSPDisplayFR(DisplayFR = "Type d'échantillon")]
        [CSSPDescriptionEN(DescriptionEN = @"Sample type")]
        [CSSPDescriptionFR(DescriptionFR = @"Type d'échantillon")]
        public SampleTypeEnum SampleType { get; set; }
        [CSSPEnumType]
        [CSSPDisplayEN(DisplayEN = "Sampling plan type")]
        [CSSPDisplayFR(DisplayFR = "Type de plan d'échantillonnage")]
        [CSSPDescriptionEN(DescriptionEN = @"Sampling plan type")]
        [CSSPDescriptionFR(DescriptionFR = @"Type de plan d'échantillonnage")]
        public SamplingPlanTypeEnum SamplingPlanType { get; set; }
        [CSSPEnumType]
        [CSSPDisplayEN(DisplayEN = "Lab sheet type")]
        [CSSPDisplayFR(DisplayFR = "Type de feuille de laboratoire")]
        [CSSPDescriptionEN(DescriptionEN = @"Lab sheet type")]
        [CSSPDescriptionFR(DescriptionFR = @"Type de feuille de laboratoire")]
        public LabSheetTypeEnum LabSheetType { get; set; }
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "18")]
        [CSSPDisplayEN(DisplayEN = "Province TVItemID")]
        [CSSPDisplayFR(DisplayFR = "Province TVItemID")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the TVItems table representing the province")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table TVItems représentant la province")]
        public int ProvinceTVItemID { get; set; }
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "5")]
        [CSSPDisplayEN(DisplayEN = "Creator of sampling plan TVItemID")]
        [CSSPDisplayFR(DisplayFR = "Créateur du plan d'échantillonnage TVItemID")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the TVItems table representing the creator of the sampling plan")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table TVItems représentant le créateur du plan d'échantillonnage")]
        public int CreatorTVItemID { get; set; }
        [Range(2000, 2050)]
        [CSSPDisplayEN(DisplayEN = "Year")]
        [CSSPDisplayFR(DisplayFR = "Année")]
        [CSSPDescriptionEN(DescriptionEN = @"Year")]
        [CSSPDescriptionFR(DescriptionFR = @"Année")]
        public int Year { get; set; }
        [StringLength(15)]
        [CSSPDisplayEN(DisplayEN = "Access code")]
        [CSSPDisplayFR(DisplayFR = "Code d'accès")]
        [CSSPDescriptionEN(DescriptionEN = @"Access code")]
        [CSSPDescriptionFR(DescriptionFR = @"Code d'accès")]
        public string AccessCode { get; set; }
        [Range(0.0D, 100.0D)]
        [CSSPDisplayEN(DisplayEN = "Daily duplicate precision criteria")]
        [CSSPDisplayFR(DisplayFR = "Critère de précision pour le duplicata journalier")]
        [CSSPDescriptionEN(DescriptionEN = @"Daily duplicate precision criteria")]
        [CSSPDescriptionFR(DescriptionFR = @"Critère de précision pour le duplicata journalier")]
        public double DailyDuplicatePrecisionCriteria { get; set; }
        [Range(0.0D, 100.0D)]
        [CSSPDisplayEN(DisplayEN = "Intertech duplicate precision criteria")]
        [CSSPDisplayFR(DisplayFR = "Critère de précision pour le duplicata intertech")]
        [CSSPDescriptionEN(DescriptionEN = @"Intertech duplicate precision criteria")]
        [CSSPDescriptionFR(DescriptionFR = @"Critère de précision pour le duplicata intertech")]
        public double IntertechDuplicatePrecisionCriteria { get; set; }
        [CSSPDisplayEN(DisplayEN = "Include laboratory QA/QC")]
        [CSSPDisplayFR(DisplayFR = "Inclure le QA/QC de laboratoire")]
        [CSSPDescriptionEN(DescriptionEN = @"Include laboratory QA/QC")]
        [CSSPDescriptionFR(DescriptionFR = @"Inclure le QA/QC de laboratoire")]
        public bool IncludeLaboratoryQAQC { get; set; }
        [StringLength(15)]
        [CSSPDisplayEN(DisplayEN = "Approval code")]
        [CSSPDisplayFR(DisplayFR = "Code d'approbation")]
        [CSSPDescriptionEN(DescriptionEN = @"Approval code")]
        [CSSPDescriptionFR(DescriptionFR = @"Code d'approbation")]
        public string ApprovalCode { get; set; }
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "8")]
        [CSSPDisplayEN(DisplayEN = "Sampling plan file TVItemID")]
        [CSSPDisplayFR(DisplayFR = "Filière du plan d'échantillonnage TVItemID")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the TVItems table representing the sampling plan file")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table TVItems représentant la filière du plan d'échantillonnage")]
        public int? SamplingPlanFileTVItemID { get; set; }
        [CSSPEnumType]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Analyze method")]
        [CSSPDisplayFR(DisplayFR = "Méthode d'analyse")]
        [CSSPDescriptionEN(DescriptionEN = @"Analyze method")]
        [CSSPDescriptionFR(DescriptionFR = @"Méthode d'analyse")]
        public AnalyzeMethodEnum? AnalyzeMethodDefault { get; set; }
        [CSSPEnumType]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Sample matrix")]
        [CSSPDisplayFR(DisplayFR = "Milieu d'échantillon")]
        [CSSPDescriptionEN(DescriptionEN = @"Sample matrix")]
        [CSSPDescriptionFR(DescriptionFR = @"Milieu d'échantillon")]
        public SampleMatrixEnum? SampleMatrixDefault { get; set; }
        [CSSPEnumType]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Laboratory")]
        [CSSPDisplayFR(DisplayFR = "Laboratoire")]
        [CSSPDescriptionEN(DescriptionEN = @"Laboratory")]
        [CSSPDescriptionFR(DescriptionFR = @"Laboratoire")]
        public LaboratoryEnum? LaboratoryDefault { get; set; }
        [StringLength(250)]
        [CSSPDisplayEN(DisplayEN = "Backup directory")]
        [CSSPDisplayFR(DisplayFR = "Répertoire de sauvegarde")]
        [CSSPDescriptionEN(DescriptionEN = @"Backup directory")]
        [CSSPDescriptionFR(DescriptionFR = @"Répertoire de sauvegarde")]
        public string BackupDirectory { get; set; }
        #endregion Properties in DB

        #region Constructors
        public SamplingPlan() : base()
        {
        }
        #endregion Constructors
    }
}
