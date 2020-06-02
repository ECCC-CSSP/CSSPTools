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
    [NotMapped]
    public partial class SearchTagAndTerms
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [CSSPEnumType]
        [CSSPDisplayEN(DisplayEN = "Search tag")]
        [CSSPDisplayFR(DisplayFR = "Tag de recherche")]
        [CSSPDescriptionEN(DescriptionEN = @"Search tag")]
        [CSSPDescriptionFR(DescriptionFR = @"Tag de recherche")]
        public SearchTagEnum SearchTag { get; set; }
        [StringLength(100)]
        [CSSPEnumTypeText(EnumTypeName = "SearchTagEnum", EnumType = "SearchTag")]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Search tag text")]
        [CSSPDisplayFR(DisplayFR = "Texte du tag de recherche")]
        [CSSPDescriptionEN(DescriptionEN = @"Search tag text")]
        [CSSPDescriptionFR(DescriptionFR = @"Texte du tag de recherche")]
        public string SearchTagText { get; set; }
        [CSSPDisplayEN(DisplayEN = "Search term list")]
        [CSSPDisplayFR(DisplayFR = "Liste des terms de recherche")]
        [CSSPDescriptionEN(DescriptionEN = @"Search term list")]
        [CSSPDescriptionFR(DescriptionFR = @"Liste des terms de recherche")]
        public List<string> SearchTermList { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public SearchTagAndTerms() : base()
        {
            SearchTermList = new List<string>();
        }
        #endregion Constructors
    }
}
