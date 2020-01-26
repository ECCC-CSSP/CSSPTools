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
    public partial class CSSPWQInputParam : CSSPError
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [CSSPEnumType]
        [CSSPDisplayEN(DisplayEN = "CSSP WQ input type")]
        [CSSPDisplayFR(DisplayFR = "Type d'input de qualité d'eau CSSP")]
        [CSSPDescriptionEN(DescriptionEN = @"CSSP water quality input type")]
        [CSSPDescriptionFR(DescriptionFR = @"Type d'input de qualité d'eau CSSP")]
        public CSSPWQInputTypeEnum CSSPWQInputType { get; set; }
        [StringLength(200, MinimumLength = 1)]
        [CSSPDisplayEN(DisplayEN = "Name")]
        [CSSPDisplayFR(DisplayFR = "Nom")]
        [CSSPDescriptionEN(DescriptionEN = @"Name")]
        [CSSPDescriptionFR(DescriptionFR = @"Nom")]
        public string Name { get; set; }
        [Range(1, -1)]
        [CSSPDisplayEN(DisplayEN = "TVItemID")]
        [CSSPDisplayFR(DisplayFR = "TVItemID")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the TVItems table with the unique identifier")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table TVItems avec l'identifiant unique")]
        public int TVItemID { get; set; }
        [StringLength(100)]
        [CSSPEnumTypeText(EnumTypeName = "CSSPWQInputTypeEnum", EnumType = "CSSPWQInputType")]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "CSSP WQ input type text")]
        [CSSPDisplayFR(DisplayFR = "Texte du type d'input de qualité d'eau CSSP")]
        [CSSPDescriptionEN(DescriptionEN = @"CSSP water quality input type text")]
        [CSSPDescriptionFR(DescriptionFR = @"Texte du type d'input de qualité d'eau CSSP")]
        public string CSSPWQInputTypeText { get; set; }
        [CSSPDisplayEN(DisplayEN = "SID list")]
        [CSSPDisplayFR(DisplayFR = "List de SID")]
        [CSSPDescriptionEN(DescriptionEN = @"Tide sites ID list")]
        [CSSPDescriptionFR(DescriptionFR = @"Liste des ID des sites de marée")]
        public List<string> sidList { get; set; }
        [CSSPDisplayEN(DisplayEN = "MWQM site list")]
        [CSSPDisplayFR(DisplayFR = "Liste des sites MWQM (fr)")]
        [CSSPDescriptionEN(DescriptionEN = @"Marine water quality monitoring site list")]
        [CSSPDescriptionFR(DescriptionFR = @"Liste des sitess MWQM (fr)")]
        public List<string> MWQMSiteList { get; set; }
        [CSSPDisplayEN(DisplayEN = "MWQM site TVItemID list")]
        [CSSPDisplayFR(DisplayFR = "Liste de TVItemID des sites MWQM (fr)")]
        [CSSPDescriptionEN(DescriptionEN = @"MWQM site TVItemID list")]
        [CSSPDescriptionFR(DescriptionFR = @"Liste de TVItemID des sites MWQM (fr)")]
        public List<int> MWQMSiteTVItemIDList { get; set; }
        [CSSPDisplayEN(DisplayEN = "Daily duplicate MWQM site list")]
        [CSSPDisplayFR(DisplayFR = "Liste de duplicata journalier des sites MWQM (fr)")]
        [CSSPDescriptionEN(DescriptionEN = @"Daily duplicate MWQM site list")]
        [CSSPDescriptionFR(DescriptionFR = @"Liste de duplicata journalier des sites MWQM (fr)")]
        public List<string> DailyDuplicateMWQMSiteList { get; set; }
        [CSSPDisplayEN(DisplayEN = "Daily duplicate MWQM site TVItemID list")]
        [CSSPDisplayFR(DisplayFR = "Liste de TVItemID des duplicata journalier des sites MWQM (fr)")]
        [CSSPDescriptionEN(DescriptionEN = @"Daily duplicate MWQM site TVItemID list")]
        [CSSPDescriptionFR(DescriptionFR = @"Liste de TVItemID des duplicata journalier des sites MWQM (fr)")]
        public List<int> DailyDuplicateMWQMSiteTVItemIDList { get; set; }
        [CSSPDisplayEN(DisplayEN = "Infrastructure list")]
        [CSSPDisplayFR(DisplayFR = "Liste des infrastructures")]
        [CSSPDescriptionEN(DescriptionEN = @"Infrastructure list")]
        [CSSPDescriptionFR(DescriptionFR = @"Liste des infrastructures")]
        public List<string> InfrastructureList { get; set; }
        [CSSPDisplayEN(DisplayEN = "Infrastructure TVItemID list")]
        [CSSPDisplayFR(DisplayFR = "Liste de TVItemID des infrastructures")]
        [CSSPDescriptionEN(DescriptionEN = @"Infrastructure TVItemID list")]
        [CSSPDescriptionFR(DescriptionFR = @"Liste de TVItemID des infrastructures")]
        public List<int> InfrastructureTVItemIDList { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public CSSPWQInputParam() : base()
        {
            sidList = new List<string>();
            MWQMSiteList = new List<string>();
            MWQMSiteTVItemIDList = new List<int>();
            DailyDuplicateMWQMSiteList = new List<string>();
            DailyDuplicateMWQMSiteTVItemIDList = new List<int>();
            InfrastructureList = new List<string>();
            InfrastructureTVItemIDList = new List<int>();
        }
        #endregion Constructors
    }
}
