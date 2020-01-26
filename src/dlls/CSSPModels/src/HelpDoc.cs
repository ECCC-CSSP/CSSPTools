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
    public partial class HelpDoc : LastUpdate
    {
        #region Properties in DB
        [Key]
        [CSSPDisplayEN(DisplayEN = "Help document ID")]
        [CSSPDisplayFR(DisplayFR = "Identifiant du document aide")]
        [CSSPDescriptionEN(DescriptionEN = @"Contains the unique ""identifier on each row of the HelpDocs table")]
        [CSSPDescriptionFR(DescriptionFR = @"Contient l'identifiant unique sur chaque ligne de la table HelpDocs")]
        public int HelpDocID { get; set; }
        [StringLength(100)]
        [CSSPDisplayEN(DisplayEN = "Help document key")]
        [CSSPDisplayFR(DisplayFR = "Identifiant du document aide")]
        [CSSPDescriptionEN(DescriptionEN = @"Help document key")]
        [CSSPDescriptionFR(DescriptionFR = @"Identifiant du document aide")]
        public string DocKey { get; set; }
        [CSSPEnumType]
        [CSSPDisplayEN(DisplayEN = "Language")]
        [CSSPDisplayFR(DisplayFR = "Langage")]
        [CSSPDescriptionEN(DescriptionEN = @"Language of the help document")]
        [CSSPDescriptionFR(DescriptionFR = @"Langage du document aide")]
        public LanguageEnum Language { get; set; }
        [StringLength(100000)]
        [CSSPDisplayEN(DisplayEN = "HTML text of help document")]
        [CSSPDisplayFR(DisplayFR = "Texte HTML du document help")]
        [CSSPDescriptionEN(DescriptionEN = @"HTML text of help document")]
        [CSSPDescriptionFR(DescriptionFR = @"Texte HTML du document help")]
        public string DocHTMLText { get; set; }
        #endregion Properties in DB

        #region Constructors
        public HelpDoc() : base()
        {
        }
        #endregion Constructors
    }
}
