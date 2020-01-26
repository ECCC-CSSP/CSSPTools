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
    public partial class MWQMSubsectorLanguage : LastUpdate
    {
        #region Properties in DB
        [Key]
        [CSSPDisplayEN(DisplayEN = "MWQMSubsectorLanguage ID")]
        [CSSPDisplayFR(DisplayFR = "MWQMSubsectorLanguage ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Contains the unique ""identifier on each row of the MWQMSubsectorLanguages table")]
        [CSSPDescriptionFR(DescriptionFR = @"Contient l'identifiant unique sur chaque ligne de la table MWQMSubsectorLanguages")]
        public int MWQMSubsectorLanguageID { get; set; }
        [CSSPExist(ExistTypeName = "MWQMSubsector", ExistPlurial = "s", ExistFieldID = "MWQMSubsectorID")]
        [CSSPDisplayEN(DisplayEN = "MWQM subsector ID")]
        [CSSPDisplayFR(DisplayFR = "Sous-secteur MWQM ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the MWQMSubsectors table representing the MWQM subsector")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table MWQMSubsectors représentant le sous-secteur MWQM")]
        public int MWQMSubsectorID { get; set; }
        [CSSPEnumType]
        [CSSPDisplayEN(DisplayEN = "Language")]
        [CSSPDisplayFR(DisplayFR = "Langage")]
        [CSSPDescriptionEN(DescriptionEN = @"Language of item")]
        [CSSPDescriptionFR(DescriptionFR = @"Langage de l'item")]
        public LanguageEnum Language { get; set; }
        [StringLength(250)]
        [CSSPDisplayEN(DisplayEN = "Subsector description")]
        [CSSPDisplayFR(DisplayFR = "Description du sous-secteur")]
        [CSSPDescriptionEN(DescriptionEN = @"Subsector description")]
        [CSSPDescriptionFR(DescriptionFR = @"Description du sous-secteur")]
        public string SubsectorDesc { get; set; }
        [CSSPEnumType]
        [CSSPDisplayEN(DisplayEN = "Translation status")]
        [CSSPDisplayFR(DisplayFR = "Le statut de la traduction")]
        [CSSPDescriptionEN(DescriptionEN = @"Translation status of the subsector description")]
        [CSSPDescriptionFR(DescriptionFR = @"Le statut de la traduction du la description du sous-secteur")]
        public TranslationStatusEnum TranslationStatusSubsectorDesc { get; set; }
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Log book")]
        [CSSPDisplayFR(DisplayFR = "Carnet de bord")]
        [CSSPDescriptionEN(DescriptionEN = @"Log book")]
        [CSSPDescriptionFR(DescriptionFR = @"Carnet de bord")]
        public string LogBook { get; set; }
        [CSSPEnumType]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Translation status")]
        [CSSPDisplayFR(DisplayFR = "Le statut de la traduction")]
        [CSSPDescriptionEN(DescriptionEN = @"Translation status of the log book")]
        [CSSPDescriptionFR(DescriptionFR = @"Le statut de la traduction du carnet de bord")]
        public TranslationStatusEnum? TranslationStatusLogBook { get; set; }
        #endregion Properties in DB

        #region Constructors
        public MWQMSubsectorLanguage() : base()
        {
        }
        #endregion Constructors
    }
}
