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
    public partial class SpillLanguage : LastUpdate
    {
        #region Properties in DB
        [Key]
        [CSSPDisplayEN(DisplayEN = "SpillLanguage ID")]
        [CSSPDisplayFR(DisplayFR = "SpillLanguage ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Contains the unique ""identifier on each row of the SpillLanguages table")]
        [CSSPDescriptionFR(DescriptionFR = @"Contient l'identifiant unique sur chaque ligne de la table SpillLanguages")]
        public int SpillLanguageID { get; set; }
        [CSSPExist(ExistTypeName = "Spill", ExistPlurial = "s", ExistFieldID = "SpillID")]
        [CSSPDisplayEN(DisplayEN = "Spill ID")]
        [CSSPDisplayFR(DisplayFR = "Déversement ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the Spills table representing the spill")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table Spills représentant le déversement")]
        public int SpillID { get; set; }
        [CSSPEnumType]
        [CSSPDisplayEN(DisplayEN = "Language")]
        [CSSPDisplayFR(DisplayFR = "Langage")]
        [CSSPDescriptionEN(DescriptionEN = @"Language of item")]
        [CSSPDescriptionFR(DescriptionFR = @"Langage de l'item")]
        public LanguageEnum Language { get; set; }
        [CSSPDisplayEN(DisplayEN = "Comment")]
        [CSSPDisplayFR(DisplayFR = "Commentaire")]
        [CSSPDescriptionEN(DescriptionEN = @"Comment")]
        [CSSPDescriptionFR(DescriptionFR = @"Commentaire")]
        public string SpillComment { get; set; }
        [CSSPEnumType]
        [CSSPDisplayEN(DisplayEN = "Translation status")]
        [CSSPDisplayFR(DisplayFR = "Le statut de la traduction")]
        [CSSPDescriptionEN(DescriptionEN = @"Translation status of the spill comment")]
        [CSSPDescriptionFR(DescriptionFR = @"Le statut de la traduction du commentaire du déversement")]
        public TranslationStatusEnum TranslationStatus { get; set; }

        [ForeignKey(nameof(SpillID))]
        [InverseProperty(nameof(Spill.SpillLanguages))]
        public virtual Spill SpillNavigation { get; set; }
        #endregion Properties in DB

        #region Constructors
        public SpillLanguage() : base()
        {
        }
        #endregion Constructors
    }
}
