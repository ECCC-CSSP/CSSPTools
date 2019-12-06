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
    public partial class MWQMSite : LastUpdate
    {
        #region Properties in DB
        [Key]
        [CSSPDisplayEN(DisplayEN = "MWQMSite ID")]
        [CSSPDisplayFR(DisplayFR = "MWQMSite ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Contains the unique ""identifier on each row of the MWQMSites table")]
        [CSSPDescriptionFR(DescriptionFR = @"Contient l'identifiant unique sur chaque ligne de la table MWQMSites")]
        public int MWQMSiteID { get; set; }
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "16")]
        [CSSPDisplayEN(DisplayEN = "MWQM site TVItemID")]
        [CSSPDisplayFR(DisplayFR = "Site MWQM TVItemID (fr)")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the TVItems table representing MWQM site")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table TVItems représentant le site MWQM (fr)")]
        public int MWQMSiteTVItemID { get; set; }
        [StringLength(8)]
        [CSSPDisplayEN(DisplayEN = "MWQM site number")]
        [CSSPDisplayFR(DisplayFR = "Numéro du site MWQM (fr)")]
        [CSSPDescriptionEN(DescriptionEN = @"MWQM site number")]
        [CSSPDescriptionFR(DescriptionFR = @"Numéro du site MWQM (fr)")]
        public string MWQMSiteNumber { get; set; }
        [StringLength(200)]
        [CSSPDisplayEN(DisplayEN = "MWQM site description")]
        [CSSPDisplayFR(DisplayFR = "Description du site MWQM (fr)")]
        [CSSPDescriptionEN(DescriptionEN = @"MWQM site description")]
        [CSSPDescriptionFR(DescriptionFR = @"Description du site MWQM (fr)")]
        public string MWQMSiteDescription { get; set; }
        [CSSPEnumType]
        [CSSPDisplayEN(DisplayEN = "MWQM site latest classification")]
        [CSSPDisplayFR(DisplayFR = "Dernière classification du site MWQM (fr)")]
        [CSSPDescriptionEN(DescriptionEN = @"MWQM site latest classification")]
        [CSSPDescriptionFR(DescriptionFR = @"Dernière classification du site MWQM (fr)")]
        public MWQMSiteLatestClassificationEnum MWQMSiteLatestClassification { get; set; }
        [Range(0, 1000)]
        [CSSPDisplayEN(DisplayEN = "Ordinal")]
        [CSSPDisplayFR(DisplayFR = "Ordre")]
        [CSSPDescriptionEN(DescriptionEN = @"Ordinal")]
        [CSSPDescriptionFR(DescriptionFR = @"Ordre")]
        public int Ordinal { get; set; }
        #endregion Properties in DB

        #region Constructors
        public MWQMSite() : base()
        {
        }
        #endregion Constructors
    }
}
