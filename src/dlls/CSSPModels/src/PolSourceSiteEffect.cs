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
    public partial class PolSourceSiteEffect : LastUpdate
    {
        #region Properties in DB
        [Key]
        [CSSPDisplayEN(DisplayEN = "PolSourceSiteEffect ID")]
        [CSSPDisplayFR(DisplayFR = "PolSourceSiteEffect ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Contains the unique ""identifier on each row of the PolSourceSiteEffects table")]
        [CSSPDescriptionFR(DescriptionFR = @"Contient l'identifiant unique sur chaque ligne de la table PolSourceSiteEffects")]
        public int PolSourceSiteEffectID { get; set; }
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "10,17")]
        [CSSPDisplayEN(DisplayEN = "Pollution source site or infrastructure TVItemID")]
        [CSSPDisplayFR(DisplayFR = "Site de source de pollution ou infrastructure TVItemID (fr)")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the TVItems table representing pollution source site or infrastructure")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table TVItems représentant le site de source de pollution ou infrastructure")]
        public int PolSourceSiteOrInfrastructureTVItemID { get; set; }
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "16")]
        [CSSPDisplayEN(DisplayEN = "MWQM site TVItemID")]
        [CSSPDisplayFR(DisplayFR = "Site MWQM TVItemID (fr)")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the TVItems table representing MWQM site")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table TVItems représentant le site MWQM (fr)")]
        public int MWQMSiteTVItemID { get; set; }
        [StringLength(250)]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "List of terms ID")]
        [CSSPDisplayFR(DisplayFR = "Liste d'identifiant des termes")]
        [CSSPDescriptionEN(DescriptionEN = @"List of terms ID")]
        [CSSPDescriptionFR(DescriptionFR = @"Liste d'identifiant des termes")]
        public string PolSourceSiteEffectTermIDs { get; set; }
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Comments")]
        [CSSPDisplayFR(DisplayFR = "Commentaires")]
        [CSSPDescriptionEN(DescriptionEN = @"Comments")]
        [CSSPDescriptionFR(DescriptionFR = @"Commentaires")]
        public string Comments { get; set; }
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "8")]
        [CSSPDisplayEN(DisplayEN = "File TVItemID")]
        [CSSPDisplayFR(DisplayFR = "Filière TVItemID (fr)")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the TVItems table representing file")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table TVItems représentant une filière")]
        public int? AnalysisDocumentTVItemID { get; set; }
        #endregion Properties in DB

        #region Constructors
        public PolSourceSiteEffect() : base()
        {
        }
        #endregion Constructors
    }
}
