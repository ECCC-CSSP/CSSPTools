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
    public partial class DocTemplate : LastUpdate
    {
        #region Properties in DB
        [Key]
        [CSSPDisplayEN(DisplayEN = "DocTemplate ID")]
        [CSSPDisplayFR(DisplayFR = "DocTemplate ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Contains the unique ""identifier on each row of the DocTemplates table")]
        [CSSPDescriptionFR(DescriptionFR = @"Contient l'identifiant unique sur chaque ligne de la table DocTemplates")]
        public int DocTemplateID { get; set; }
        [CSSPEnumType]
        [CSSPDisplayEN(DisplayEN = "Language")]
        [CSSPDisplayFR(DisplayFR = "Langage")]
        [CSSPDescriptionEN(DescriptionEN = @"Document template language")]
        [CSSPDescriptionFR(DescriptionFR = @"Langage du document modèle")]
        public LanguageEnum Language { get; set; }
        [CSSPEnumType]
        [CSSPDisplayEN(DisplayEN = "TV type")]
        [CSSPDisplayFR(DisplayFR = "Type AV")]
        [CSSPDescriptionEN(DescriptionEN = @"Tree view item type")]
        [CSSPDescriptionFR(DescriptionFR = @"Type d'item pour l'arbre visuel")]
        public TVTypeEnum TVType { get; set; }
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "8")]
        [CSSPDisplayEN(DisplayEN = "TVFile ID")]
        [CSSPDisplayFR(DisplayFR = "TVFile ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the TVFiles table with the unique identifier")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table TVFiles avec l'identifiant unique")]
        public int TVFileTVItemID { get; set; }
        [StringLength(150)]
        [CSSPDisplayEN(DisplayEN = "File name")]
        [CSSPDisplayFR(DisplayFR = "Nom de la filière")]
        [CSSPDescriptionEN(DescriptionEN = @"File name of the document template")]
        [CSSPDescriptionFR(DescriptionFR = @"Nom de la filière du document modèle")]
        public string FileName { get; set; }

        [ForeignKey(nameof(TVFileTVItemID))]
        [InverseProperty(nameof(TVItem.DocTemplates))]
        public virtual TVItem TVFileTVItem { get; set; }
        #endregion Properties in DB

        #region Constructors
        public DocTemplate() : base()
        {
        }
        #endregion Constructors
    }
}
