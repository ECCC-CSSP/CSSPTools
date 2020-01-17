/*
 * Auto generated from the CSSPCodeWriter.proj by clicking on the [\srcWithDoc\[ModelClassName]Generated.cs] button
 *
 * Do not edit this file.
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
    /// <summary>
    /// > [!NOTE]
    /// > 
    /// > <para>**DB properties for table PolSourceSiteEffects** : [PolSourceSiteEffectID](CSSPModels.PolSourceSiteEffect.html#CSSPModels_PolSourceSiteEffect_PolSourceSiteEffectID), [PolSourceSiteOrInfrastructureTVItemID](CSSPModels.PolSourceSiteEffect.html#CSSPModels_PolSourceSiteEffect_PolSourceSiteOrInfrastructureTVItemID), [MWQMSiteTVItemID](CSSPModels.PolSourceSiteEffect.html#CSSPModels_PolSourceSiteEffect_MWQMSiteTVItemID), [PolSourceSiteEffectTermIDs](CSSPModels.PolSourceSiteEffect.html#CSSPModels_PolSourceSiteEffect_PolSourceSiteEffectTermIDs), [Comments](CSSPModels.PolSourceSiteEffect.html#CSSPModels_PolSourceSiteEffect_Comments), [AnalysisDocumentTVItemID](CSSPModels.PolSourceSiteEffect.html#CSSPModels_PolSourceSiteEffect_AnalysisDocumentTVItemID), [LastUpdate.LastUpdateDate_UTC](CSSPModels.LastUpdate.html#CSSPModels_LastUpdate_LastUpdateDate_UTC), [LastUpdate.LastUpdateContactTVItemID](CSSPModels.LastUpdate.html#CSSPModels_LastUpdate_LastUpdateContactTVItemID)</para>
    /// > <para>**Other properties** : [CSSPError.HasErrors](CSSPModels.CSSPError.html#CSSPModels_CSSPError_HasErrors), [CSSPError.ValidationResults](CSSPModels.CSSPError.html#CSSPModels_CSSPError_ValidationResults)</para>
    /// > 
    /// > <para>**Used by [CSSPServices](CSSPServices.html)** : [PolSourceSiteEffectService](CSSPServices.PolSourceSiteEffectService.html)</para>
    /// > <para>**Used by [CSSPWebAPI.Controllers](CSSPWebAPI.Controllers.html)** : [PolSourceSiteEffectController](CSSPWebAPI.Controllers.PolSourceSiteEffectController.html)</para>
    /// > <para>**Inherits [LastUpdate](CSSPModels.LastUpdate.html)**</para>
    /// > <para>**Return to [CSSPModels](CSSPModels.html)**</para>
    /// </summary>
    public partial class PolSourceSiteEffect : LastUpdate
    {
        #region Properties in DB
        /// <summary>
        /// > [!NOTE]
        /// > <para>**Other custom attributes**</para>
        /// > <para>[[CSSPDisplayEN](CSSPModels.CSSPDisplayEN.html)(DisplayEN = "PolSourceSiteEffect ID")]</para>
        /// > <para>[[CSSPDisplayFR](CSSPModels.CSSPDisplayFR.html)(DisplayFR = "PolSourceSiteEffect ID")]</para>
        /// > <para>[[CSSPDescriptionEN](CSSPModels.CSSPDescriptionEN.html)(DescriptionEN = "Contains the unique "identifier on each row of the PolSourceSiteEffects table")]</para>
        /// > <para>[[CSSPDescriptionFR](CSSPModels.CSSPDescriptionFR.html)(DescriptionFR = "Contient l'identifiant unique sur chaque ligne de la table PolSourceSiteEffects")]</para>
        /// </summary>
        /// <returns>
        /// 
        /// **Display (en)** --- PolSourceSiteEffect ID
        /// 
        /// **Display (fr)** --- PolSourceSiteEffect ID
        /// 
        /// **Description (en)** --- Contains the unique "identifier on each row of the PolSourceSiteEffects table
        /// 
        /// **Description (fr)** --- Contient l'identifiant unique sur chaque ligne de la table PolSourceSiteEffects
        /// </returns>
        [Key]
        [CSSPDisplayEN(DisplayEN = "PolSourceSiteEffect ID")]
        [CSSPDisplayFR(DisplayFR = "PolSourceSiteEffect ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Contains the unique ""identifier on each row of the PolSourceSiteEffects table")]
        [CSSPDescriptionFR(DescriptionFR = @"Contient l'identifiant unique sur chaque ligne de la table PolSourceSiteEffects")]
        public int PolSourceSiteEffectID { get; set; }
        /// <summary>
        /// > [!NOTE]
        /// > <para>**Other custom attributes**</para>
        /// > <para>**AllowableTVTypeList is of type [CSSPEnums.TVTypeEnum](CSSPEnums.TVTypeEnum.html)**</para>
        /// > <para>10 == Infrastructure, 17 == PolSourceSite</para>
        /// > <para>[[CSSPExist](CSSPModels.CSSPExistAttribute.html)(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "10,17")]</para>
        /// > <para>[[CSSPDisplayEN](CSSPModels.CSSPDisplayEN.html)(DisplayEN = "Pollution source site or infrastructure TVItemID")]</para>
        /// > <para>[[CSSPDisplayFR](CSSPModels.CSSPDisplayFR.html)(DisplayFR = "Site de source de pollution ou infrastructure TVItemID (fr)")]</para>
        /// > <para>[[CSSPDescriptionEN](CSSPModels.CSSPDescriptionEN.html)(DescriptionEN = "Link to the TVItems table representing pollution source site or infrastructure")]</para>
        /// > <para>[[CSSPDescriptionFR](CSSPModels.CSSPDescriptionFR.html)(DescriptionFR = "Lien à la table TVItems représentant le site de source de pollution ou infrastructure")]</para>
        /// </summary>
        /// <returns>
        /// 
        /// **Display (en)** --- Pollution source site or infrastructure TVItemID
        /// 
        /// **Display (fr)** --- Site de source de pollution ou infrastructure TVItemID (fr)
        /// 
        /// **Description (en)** --- Link to the TVItems table representing pollution source site or infrastructure
        /// 
        /// **Description (fr)** --- Lien à la table TVItems représentant le site de source de pollution ou infrastructure
        /// </returns>
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "10,17")]
        [CSSPDisplayEN(DisplayEN = "Pollution source site or infrastructure TVItemID")]
        [CSSPDisplayFR(DisplayFR = "Site de source de pollution ou infrastructure TVItemID (fr)")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the TVItems table representing pollution source site or infrastructure")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table TVItems représentant le site de source de pollution ou infrastructure")]
        public int PolSourceSiteOrInfrastructureTVItemID { get; set; }
        /// <summary>
        /// > [!NOTE]
        /// > <para>**Other custom attributes**</para>
        /// > <para>**AllowableTVTypeList is of type [CSSPEnums.TVTypeEnum](CSSPEnums.TVTypeEnum.html)**</para>
        /// > <para>16 == MWQMSite</para>
        /// > <para>[[CSSPExist](CSSPModels.CSSPExistAttribute.html)(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "16")]</para>
        /// > <para>[[CSSPDisplayEN](CSSPModels.CSSPDisplayEN.html)(DisplayEN = "MWQM site TVItemID")]</para>
        /// > <para>[[CSSPDisplayFR](CSSPModels.CSSPDisplayFR.html)(DisplayFR = "Site MWQM TVItemID (fr)")]</para>
        /// > <para>[[CSSPDescriptionEN](CSSPModels.CSSPDescriptionEN.html)(DescriptionEN = "Link to the TVItems table representing MWQM site")]</para>
        /// > <para>[[CSSPDescriptionFR](CSSPModels.CSSPDescriptionFR.html)(DescriptionFR = "Lien à la table TVItems représentant le site MWQM (fr)")]</para>
        /// </summary>
        /// <returns>
        /// 
        /// **Display (en)** --- MWQM site TVItemID
        /// 
        /// **Display (fr)** --- Site MWQM TVItemID (fr)
        /// 
        /// **Description (en)** --- Link to the TVItems table representing MWQM site
        /// 
        /// **Description (fr)** --- Lien à la table TVItems représentant le site MWQM (fr)
        /// </returns>
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "16")]
        [CSSPDisplayEN(DisplayEN = "MWQM site TVItemID")]
        [CSSPDisplayFR(DisplayFR = "Site MWQM TVItemID (fr)")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the TVItems table representing MWQM site")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table TVItems représentant le site MWQM (fr)")]
        public int MWQMSiteTVItemID { get; set; }
        /// <summary>
        /// > [!NOTE]
        /// > <para>**Other custom attributes**</para>
        /// > <para>[[CSSPDisplayEN](CSSPModels.CSSPDisplayEN.html)(DisplayEN = "List of terms ID")]</para>
        /// > <para>[[CSSPDisplayFR](CSSPModels.CSSPDisplayFR.html)(DisplayFR = "Liste d'identifiant des termes")]</para>
        /// > <para>[[CSSPDescriptionEN](CSSPModels.CSSPDescriptionEN.html)(DescriptionEN = "List of terms ID")]</para>
        /// > <para>[[CSSPDescriptionFR](CSSPModels.CSSPDescriptionFR.html)(DescriptionFR = "Liste d'identifiant des termes")]</para>
        /// > <para>[[CSSPAllowNull](CSSPModels.CSSPAllowNullAttribute.html)]</para>
        /// </summary>
        /// <returns>
        /// 
        /// **Display (en)** --- List of terms ID
        /// 
        /// **Display (fr)** --- Liste d'identifiant des termes
        /// 
        /// **Description (en)** --- List of terms ID
        /// 
        /// **Description (fr)** --- Liste d'identifiant des termes
        /// </returns>
        [StringLength(250)]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "List of terms ID")]
        [CSSPDisplayFR(DisplayFR = "Liste d'identifiant des termes")]
        [CSSPDescriptionEN(DescriptionEN = @"List of terms ID")]
        [CSSPDescriptionFR(DescriptionFR = @"Liste d'identifiant des termes")]
        public string PolSourceSiteEffectTermIDs { get; set; }
        /// <summary>
        /// > [!NOTE]
        /// > <para>**Other custom attributes**</para>
        /// > <para>[[CSSPDisplayEN](CSSPModels.CSSPDisplayEN.html)(DisplayEN = "Comments")]</para>
        /// > <para>[[CSSPDisplayFR](CSSPModels.CSSPDisplayFR.html)(DisplayFR = "Commentaires")]</para>
        /// > <para>[[CSSPDescriptionEN](CSSPModels.CSSPDescriptionEN.html)(DescriptionEN = "Comments")]</para>
        /// > <para>[[CSSPDescriptionFR](CSSPModels.CSSPDescriptionFR.html)(DescriptionFR = "Commentaires")]</para>
        /// > <para>[[CSSPAllowNull](CSSPModels.CSSPAllowNullAttribute.html)]</para>
        /// </summary>
        /// <returns>
        /// 
        /// **Display (en)** --- Comments
        /// 
        /// **Display (fr)** --- Commentaires
        /// 
        /// **Description (en)** --- Comments
        /// 
        /// **Description (fr)** --- Commentaires
        /// </returns>
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Comments")]
        [CSSPDisplayFR(DisplayFR = "Commentaires")]
        [CSSPDescriptionEN(DescriptionEN = @"Comments")]
        [CSSPDescriptionFR(DescriptionFR = @"Commentaires")]
        public string Comments { get; set; }
        /// <summary>
        /// > [!NOTE]
        /// > <para>**Other custom attributes**</para>
        /// > <para>**AllowableTVTypeList is of type [CSSPEnums.TVTypeEnum](CSSPEnums.TVTypeEnum.html)**</para>
        /// > <para>8 == File</para>
        /// > <para>[[CSSPExist](CSSPModels.CSSPExistAttribute.html)(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "8")]</para>
        /// > <para>[[CSSPDisplayEN](CSSPModels.CSSPDisplayEN.html)(DisplayEN = "File TVItemID")]</para>
        /// > <para>[[CSSPDisplayFR](CSSPModels.CSSPDisplayFR.html)(DisplayFR = "Filière TVItemID (fr)")]</para>
        /// > <para>[[CSSPDescriptionEN](CSSPModels.CSSPDescriptionEN.html)(DescriptionEN = "Link to the TVItems table representing file")]</para>
        /// > <para>[[CSSPDescriptionFR](CSSPModels.CSSPDescriptionFR.html)(DescriptionFR = "Lien à la table TVItems représentant une filière")]</para>
        /// </summary>
        /// <returns>
        /// 
        /// **Display (en)** --- File TVItemID
        /// 
        /// **Display (fr)** --- Filière TVItemID (fr)
        /// 
        /// **Description (en)** --- Link to the TVItems table representing file
        /// 
        /// **Description (fr)** --- Lien à la table TVItems représentant une filière
        /// </returns>
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
    /// <summary>
    /// > [!NOTE]
    /// > 
    /// > <para>**No DB properties** :</para>
    /// > <para>**Other properties** : [PolSourceSiteEffectID](CSSPModels.PolSourceSiteEffect.html#CSSPModels_PolSourceSiteEffect_PolSourceSiteEffectID), [PolSourceSiteOrInfrastructureTVItemID](CSSPModels.PolSourceSiteEffect.html#CSSPModels_PolSourceSiteEffect_PolSourceSiteOrInfrastructureTVItemID), [MWQMSiteTVItemID](CSSPModels.PolSourceSiteEffect.html#CSSPModels_PolSourceSiteEffect_MWQMSiteTVItemID), [PolSourceSiteEffectTermIDs](CSSPModels.PolSourceSiteEffect.html#CSSPModels_PolSourceSiteEffect_PolSourceSiteEffectTermIDs), [Comments](CSSPModels.PolSourceSiteEffect.html#CSSPModels_PolSourceSiteEffect_Comments), [AnalysisDocumentTVItemID](CSSPModels.PolSourceSiteEffect.html#CSSPModels_PolSourceSiteEffect_AnalysisDocumentTVItemID)</para>
    /// > 
    /// > <para>**Used by [CSSPServices](CSSPServices.html)** : [PolSourceSiteEffectService](CSSPServices.PolSourceSiteEffectService.html)</para>
    /// > <para>**Used by [CSSPWebAPI.Controllers](CSSPWebAPI.Controllers.html)** : [PolSourceSiteEffectController](CSSPWebAPI.Controllers.PolSourceSiteEffectController.html)</para>
    /// > <para>**Return to [CSSPModels](CSSPModels.html)**</para>
    /// </summary>
}
