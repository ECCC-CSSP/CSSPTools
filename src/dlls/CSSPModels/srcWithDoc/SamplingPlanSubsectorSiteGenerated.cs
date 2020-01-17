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
    /// > <para>**DB properties for table SamplingPlanSubsectorSites** : [SamplingPlanSubsectorSiteID](CSSPModels.SamplingPlanSubsectorSite.html#CSSPModels_SamplingPlanSubsectorSite_SamplingPlanSubsectorSiteID), [SamplingPlanSubsectorID](CSSPModels.SamplingPlanSubsectorSite.html#CSSPModels_SamplingPlanSubsectorSite_SamplingPlanSubsectorID), [MWQMSiteTVItemID](CSSPModels.SamplingPlanSubsectorSite.html#CSSPModels_SamplingPlanSubsectorSite_MWQMSiteTVItemID), [IsDuplicate](CSSPModels.SamplingPlanSubsectorSite.html#CSSPModels_SamplingPlanSubsectorSite_IsDuplicate), [LastUpdate.LastUpdateDate_UTC](CSSPModels.LastUpdate.html#CSSPModels_LastUpdate_LastUpdateDate_UTC), [LastUpdate.LastUpdateContactTVItemID](CSSPModels.LastUpdate.html#CSSPModels_LastUpdate_LastUpdateContactTVItemID)</para>
    /// > <para>**Other properties** : [CSSPError.HasErrors](CSSPModels.CSSPError.html#CSSPModels_CSSPError_HasErrors), [CSSPError.ValidationResults](CSSPModels.CSSPError.html#CSSPModels_CSSPError_ValidationResults)</para>
    /// > 
    /// > <para>**Used by [CSSPServices](CSSPServices.html)** : [SamplingPlanSubsectorSiteService](CSSPServices.SamplingPlanSubsectorSiteService.html)</para>
    /// > <para>**Used by [CSSPWebAPI.Controllers](CSSPWebAPI.Controllers.html)** : [SamplingPlanSubsectorSiteController](CSSPWebAPI.Controllers.SamplingPlanSubsectorSiteController.html)</para>
    /// > <para>**Inherits [LastUpdate](CSSPModels.LastUpdate.html)**</para>
    /// > <para>**Return to [CSSPModels](CSSPModels.html)**</para>
    /// </summary>
    public partial class SamplingPlanSubsectorSite : LastUpdate
    {
        #region Properties in DB
        /// <summary>
        /// > [!NOTE]
        /// > <para>**Other custom attributes**</para>
        /// > <para>[[CSSPDisplayEN](CSSPModels.CSSPDisplayEN.html)(DisplayEN = "SamplingPlanSubsectorSite ID")]</para>
        /// > <para>[[CSSPDisplayFR](CSSPModels.CSSPDisplayFR.html)(DisplayFR = "SamplingPlanSubsectorSite ID")]</para>
        /// > <para>[[CSSPDescriptionEN](CSSPModels.CSSPDescriptionEN.html)(DescriptionEN = "Contains the unique "identifier on each row of the SamplingPlanSubsectorSites table")]</para>
        /// > <para>[[CSSPDescriptionFR](CSSPModels.CSSPDescriptionFR.html)(DescriptionFR = "Contient l'identifiant unique sur chaque ligne de la table SamplingPlanSubsectorSites")]</para>
        /// </summary>
        /// <returns>
        /// 
        /// **Display (en)** --- SamplingPlanSubsectorSite ID
        /// 
        /// **Display (fr)** --- SamplingPlanSubsectorSite ID
        /// 
        /// **Description (en)** --- Contains the unique "identifier on each row of the SamplingPlanSubsectorSites table
        /// 
        /// **Description (fr)** --- Contient l'identifiant unique sur chaque ligne de la table SamplingPlanSubsectorSites
        /// </returns>
        [Key]
        [CSSPDisplayEN(DisplayEN = "SamplingPlanSubsectorSite ID")]
        [CSSPDisplayFR(DisplayFR = "SamplingPlanSubsectorSite ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Contains the unique ""identifier on each row of the SamplingPlanSubsectorSites table")]
        [CSSPDescriptionFR(DescriptionFR = @"Contient l'identifiant unique sur chaque ligne de la table SamplingPlanSubsectorSites")]
        public int SamplingPlanSubsectorSiteID { get; set; }
        /// <summary>
        /// > [!NOTE]
        /// > <para>**Other custom attributes**</para>
        /// > <para>[[CSSPExist](CSSPModels.CSSPExistAttribute.html)(ExistTypeName = "SamplingPlanSubsector", ExistPlurial = "s", ExistFieldID = "SamplingPlanSubsectorID")]</para>
        /// > <para>[[CSSPDisplayEN](CSSPModels.CSSPDisplayEN.html)(DisplayEN = "Sampling plan subsector ID")]</para>
        /// > <para>[[CSSPDisplayFR](CSSPModels.CSSPDisplayFR.html)(DisplayFR = "Sous-secteur du plan d'échantillonnage ID")]</para>
        /// > <para>[[CSSPDescriptionEN](CSSPModels.CSSPDescriptionEN.html)(DescriptionEN = "Link to the SamplingPlanSubsectors table representing the sampling plan subsector")]</para>
        /// > <para>[[CSSPDescriptionFR](CSSPModels.CSSPDescriptionFR.html)(DescriptionFR = "Lien à la table SamplingPlanSubsectors représentant le sous-secteur du plan d'échantillonnage")]</para>
        /// </summary>
        /// <returns>
        /// 
        /// **Display (en)** --- Sampling plan subsector ID
        /// 
        /// **Display (fr)** --- Sous-secteur du plan d'échantillonnage ID
        /// 
        /// **Description (en)** --- Link to the SamplingPlanSubsectors table representing the sampling plan subsector
        /// 
        /// **Description (fr)** --- Lien à la table SamplingPlanSubsectors représentant le sous-secteur du plan d'échantillonnage
        /// </returns>
        [CSSPExist(ExistTypeName = "SamplingPlanSubsector", ExistPlurial = "s", ExistFieldID = "SamplingPlanSubsectorID")]
        [CSSPDisplayEN(DisplayEN = "Sampling plan subsector ID")]
        [CSSPDisplayFR(DisplayFR = "Sous-secteur du plan d'échantillonnage ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the SamplingPlanSubsectors table representing the sampling plan subsector")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table SamplingPlanSubsectors représentant le sous-secteur du plan d'échantillonnage")]
        public int SamplingPlanSubsectorID { get; set; }
        /// <summary>
        /// > [!NOTE]
        /// > <para>**Other custom attributes**</para>
        /// > <para>**AllowableTVTypeList is of type [CSSPEnums.TVTypeEnum](CSSPEnums.TVTypeEnum.html)**</para>
        /// > <para>16 == MWQMSite</para>
        /// > <para>[[CSSPExist](CSSPModels.CSSPExistAttribute.html)(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "16")]</para>
        /// > <para>[[CSSPDisplayEN](CSSPModels.CSSPDisplayEN.html)(DisplayEN = "MWQM site TVItemID")]</para>
        /// > <para>[[CSSPDisplayFR](CSSPModels.CSSPDisplayFR.html)(DisplayFR = "Site MWQM TVItemID (fr)")]</para>
        /// > <para>[[CSSPDescriptionEN](CSSPModels.CSSPDescriptionEN.html)(DescriptionEN = "Link to the TVItems table representing the MWQM site")]</para>
        /// > <para>[[CSSPDescriptionFR](CSSPModels.CSSPDescriptionFR.html)(DescriptionFR = "Lien à la table TVItems représentant le site MWQM (fr)")]</para>
        /// </summary>
        /// <returns>
        /// 
        /// **Display (en)** --- MWQM site TVItemID
        /// 
        /// **Display (fr)** --- Site MWQM TVItemID (fr)
        /// 
        /// **Description (en)** --- Link to the TVItems table representing the MWQM site
        /// 
        /// **Description (fr)** --- Lien à la table TVItems représentant le site MWQM (fr)
        /// </returns>
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "16")]
        [CSSPDisplayEN(DisplayEN = "MWQM site TVItemID")]
        [CSSPDisplayFR(DisplayFR = "Site MWQM TVItemID (fr)")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the TVItems table representing the MWQM site")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table TVItems représentant le site MWQM (fr)")]
        public int MWQMSiteTVItemID { get; set; }
        /// <summary>
        /// > [!NOTE]
        /// > <para>**Other custom attributes**</para>
        /// > <para>[[CSSPDisplayEN](CSSPModels.CSSPDisplayEN.html)(DisplayEN = "Is duplicate")]</para>
        /// > <para>[[CSSPDisplayFR](CSSPModels.CSSPDisplayFR.html)(DisplayFR = "Est en double")]</para>
        /// > <para>[[CSSPDescriptionEN](CSSPModels.CSSPDescriptionEN.html)(DescriptionEN = "Is duplicate")]</para>
        /// > <para>[[CSSPDescriptionFR](CSSPModels.CSSPDescriptionFR.html)(DescriptionFR = "Est en double")]</para>
        /// </summary>
        /// <returns>
        /// 
        /// **Display (en)** --- Is duplicate
        /// 
        /// **Display (fr)** --- Est en double
        /// 
        /// **Description (en)** --- Is duplicate
        /// 
        /// **Description (fr)** --- Est en double
        /// </returns>
        [CSSPDisplayEN(DisplayEN = "Is duplicate")]
        [CSSPDisplayFR(DisplayFR = "Est en double")]
        [CSSPDescriptionEN(DescriptionEN = @"Is duplicate")]
        [CSSPDescriptionFR(DescriptionFR = @"Est en double")]
        public bool IsDuplicate { get; set; }
        #endregion Properties in DB

        #region Constructors
        public SamplingPlanSubsectorSite() : base()
        {
        }
        #endregion Constructors
    }
    /// <summary>
    /// > [!NOTE]
    /// > 
    /// > <para>**No DB properties** :</para>
    /// > <para>**Other properties** : [SamplingPlanSubsectorSiteID](CSSPModels.SamplingPlanSubsectorSite.html#CSSPModels_SamplingPlanSubsectorSite_SamplingPlanSubsectorSiteID), [MWQMSiteTVItemID](CSSPModels.SamplingPlanSubsectorSite.html#CSSPModels_SamplingPlanSubsectorSite_MWQMSiteTVItemID), [IsDuplicate](CSSPModels.SamplingPlanSubsectorSite.html#CSSPModels_SamplingPlanSubsectorSite_IsDuplicate)</para>
    /// > 
    /// > <para>**Used by [CSSPServices](CSSPServices.html)** : [SamplingPlanSubsectorSiteService](CSSPServices.SamplingPlanSubsectorSiteService.html)</para>
    /// > <para>**Used by [CSSPWebAPI.Controllers](CSSPWebAPI.Controllers.html)** : [SamplingPlanSubsectorSiteController](CSSPWebAPI.Controllers.SamplingPlanSubsectorSiteController.html)</para>
    /// > <para>**Return to [CSSPModels](CSSPModels.html)**</para>
    /// </summary>
}
