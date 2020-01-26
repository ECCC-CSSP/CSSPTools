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
    public partial class InfrastructureLanguage : LastUpdate
    {
        #region Properties in DB
        [Key]
        [CSSPDisplayEN(DisplayEN = "InfrastructureLanguage ID")]
        [CSSPDisplayFR(DisplayFR = "InfrastructureLanguage ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Contains the unique ""identifier on each row of the InfrastructureLanguages table")]
        [CSSPDescriptionFR(DescriptionFR = @"Contient l'identifiant unique sur chaque ligne de la table InfrastructureLanguages")]
        public int InfrastructureLanguageID { get; set; }
        [CSSPExist(ExistTypeName = "Infrastructure", ExistPlurial = "s", ExistFieldID = "InfrastructureID")]
        [CSSPDisplayEN(DisplayEN = "Infrastructure")]
        [CSSPDisplayFR(DisplayFR = "Infrastructure")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the Infrastructure table representing the infrastructure")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table Infrastructure représentant l'infrastructure")]
        public int InfrastructureID { get; set; }
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
        public string Comment { get; set; }
        [CSSPEnumType]
        [CSSPDisplayEN(DisplayEN = "Translation status")]
        [CSSPDisplayFR(DisplayFR = "Le statut de la traduction")]
        [CSSPDescriptionEN(DescriptionEN = @"Translation status of the comment")]
        [CSSPDescriptionFR(DescriptionFR = @"Le statut de la traduction du commentaire")]
        public TranslationStatusEnum TranslationStatus { get; set; }
        #endregion Properties in DB

        #region Constructors
        public InfrastructureLanguage() : base()
        {
        }
        #endregion Constructors
    }
}
