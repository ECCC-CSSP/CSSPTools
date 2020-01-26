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
    public partial class TVItemSubsectorAndMWQMSite : CSSPError
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [CSSPDisplayEN(DisplayEN = "TV item of the subsector")]
        [CSSPDisplayFR(DisplayFR = "L'item de l'arbre visuel du sous-secteur")]
        [CSSPDescriptionEN(DescriptionEN = @"Tree view item of the subsector")]
        [CSSPDescriptionFR(DescriptionFR = @"L'item de l'arbre visuel du sous-secteur")]
        public TVItem TVItemSubsector { get; set; }
        [CSSPDisplayEN(DisplayEN = "TV item of the MWQM site")]
        [CSSPDisplayFR(DisplayFR = "L'item de l'arbre visuel du site MWQM (fr)")]
        [CSSPDescriptionEN(DescriptionEN = @"Tree view item of the MWQM site")]
        [CSSPDescriptionFR(DescriptionFR = @"L'item de l'arbre visuel du site MWQM (fr)")]
        public List<TVItem> TVItemMWQMSiteList { get; set; }
        [CSSPDisplayEN(DisplayEN = "TV item of the duplicate MWQM site")]
        [CSSPDisplayFR(DisplayFR = "L'item de l'arbre visuel du site duplicata MWQM (fr)")]
        [CSSPDescriptionEN(DescriptionEN = @"Tree view item of the duplicate MWQM site")]
        [CSSPDescriptionFR(DescriptionFR = @"L'item de l'arbre visuel du site duplicata MWQM (fr)")]
        public TVItem TVItemMWQMSiteDuplicate { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public TVItemSubsectorAndMWQMSite() : base()
        {
            TVItemMWQMSiteList = new List<TVItem>();
        }
        #endregion Constructors
    }
}
