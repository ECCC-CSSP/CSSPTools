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
    /// > <para>**DB properties for table TVItemStats** : [TVItemStatID](CSSPModels.TVItemStat.html#CSSPModels_TVItemStat_TVItemStatID), [TVItemID](CSSPModels.TVItemStat.html#CSSPModels_TVItemStat_TVItemID), [TVType](CSSPModels.TVItemStat.html#CSSPModels_TVItemStat_TVType), [ChildCount](CSSPModels.TVItemStat.html#CSSPModels_TVItemStat_ChildCount), [LastUpdate.LastUpdateDate_UTC](CSSPModels.LastUpdate.html#CSSPModels_LastUpdate_LastUpdateDate_UTC), [LastUpdate.LastUpdateContactTVItemID](CSSPModels.LastUpdate.html#CSSPModels_LastUpdate_LastUpdateContactTVItemID)</para>
    /// > <para>**Other properties** : [CSSPError.HasErrors](CSSPModels.CSSPError.html#CSSPModels_CSSPError_HasErrors), [CSSPError.ValidationResults](CSSPModels.CSSPError.html#CSSPModels_CSSPError_ValidationResults)</para>
    /// > 
    /// > <para>**Used by [CSSPServices](CSSPServices.html)** : [TVItemStatService](CSSPServices.TVItemStatService.html)</para>
    /// > <para>**Used by [CSSPWebAPI.Controllers](CSSPWebAPI.Controllers.html)** : [TVItemStatController](CSSPWebAPI.Controllers.TVItemStatController.html)</para>
    /// > <para>**Requires [CSSPEnums](CSSPEnums.html)** : [TVTypeEnum](CSSPEnums.TVTypeEnum.html)</para>
    /// > <para>**Inherits [LastUpdate](CSSPModels.LastUpdate.html)**</para>
    /// > <para>**Return to [CSSPModels](CSSPModels.html)**</para>
    /// </summary>
    public partial class TVItemStat : LastUpdate
    {
        #region Properties in DB
        /// <summary>
        /// > [!NOTE]
        /// > <para>**Other custom attributes**</para>
        /// > <para>[[CSSPDisplayEN](CSSPModels.CSSPDisplayEN.html)(DisplayEN = "TVItemStat ID")]</para>
        /// > <para>[[CSSPDisplayFR](CSSPModels.CSSPDisplayFR.html)(DisplayFR = "TVItemStat ID")]</para>
        /// > <para>[[CSSPDescriptionEN](CSSPModels.CSSPDescriptionEN.html)(DescriptionEN = "Contains the unique "identifier on each row of the TVItemStats table")]</para>
        /// > <para>[[CSSPDescriptionFR](CSSPModels.CSSPDescriptionFR.html)(DescriptionFR = "Contient l'identifiant unique sur chaque ligne de la table TVItemStats")]</para>
        /// </summary>
        /// <returns>
        /// 
        /// **Display (en)** --- TVItemStat ID
        /// 
        /// **Display (fr)** --- TVItemStat ID
        /// 
        /// **Description (en)** --- Contains the unique "identifier on each row of the TVItemStats table
        /// 
        /// **Description (fr)** --- Contient l'identifiant unique sur chaque ligne de la table TVItemStats
        /// </returns>
        [Key]
        [CSSPDisplayEN(DisplayEN = "TVItemStat ID")]
        [CSSPDisplayFR(DisplayFR = "TVItemStat ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Contains the unique ""identifier on each row of the TVItemStats table")]
        [CSSPDescriptionFR(DescriptionFR = @"Contient l'identifiant unique sur chaque ligne de la table TVItemStats")]
        public int TVItemStatID { get; set; }
        /// <summary>
        /// > [!NOTE]
        /// > <para>**Other custom attributes**</para>
        /// > <para>**AllowableTVTypeList is of type [CSSPEnums.TVTypeEnum](CSSPEnums.TVTypeEnum.html)**</para>
        /// > <para>1 == Root, 2 == Address, 3 == Area, 4 == ClimateSite, 5 == Contact, 6 == Country, 7 == Email, 8 == File, 9 == HydrometricSite, 10 == Infrastructure, 13 == MikeScenario, 14 == MikeSource, 15 == Municipality, 16 == MWQMSite, 17 == PolSourceSite, 18 == Province, 19 == Sector, 20 == Subsector, 21 == Tel, 22 == TideSite, 24 == WasteWaterTreatmentPlant, 25 == LiftStation, 26 == Spill, 27 == BoxModel, 28 == VisualPlumesScenario, 30 == OtherInfrastructure, 31 == MWQMRun, 38 == MeshNode, 39 == WebTideNode, 40 == SamplingPlan, 41 == SeeOtherMunicipality, 42 == LineOverflow, 52 == MapInfo, 53 == MapInfoPoint</para>
        /// > <para>[[CSSPExist](CSSPModels.CSSPExistAttribute.html)(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "1,2,3,4,5,6,7,8,9,10,13,14,15,16,17,18,19,20,21,22,24,25,26,27,28,30,31,38,39,40,41,42,52,53")]</para>
        /// > <para>[[CSSPDisplayEN](CSSPModels.CSSPDisplayEN.html)(DisplayEN = "TVItemID")]</para>
        /// > <para>[[CSSPDisplayFR](CSSPModels.CSSPDisplayFR.html)(DisplayFR = "TVItemID")]</para>
        /// > <para>[[CSSPDescriptionEN](CSSPModels.CSSPDescriptionEN.html)(DescriptionEN = "Link to the TVItems table representing item of the tree view")]</para>
        /// > <para>[[CSSPDescriptionFR](CSSPModels.CSSPDescriptionFR.html)(DescriptionFR = "Lien à la table TVItems représentant l'item de l'arbre visuel")]</para>
        /// </summary>
        /// <returns>
        /// 
        /// **Display (en)** --- TVItemID
        /// 
        /// **Display (fr)** --- TVItemID
        /// 
        /// **Description (en)** --- Link to the TVItems table representing item of the tree view
        /// 
        /// **Description (fr)** --- Lien à la table TVItems représentant l'item de l'arbre visuel
        /// </returns>
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "1,2,3,4,5,6,7,8,9,10,13,14,15,16,17,18,19,20,21,22,24,25,26,27,28,30,31,38,39,40,41,42,52,53")]
        [CSSPDisplayEN(DisplayEN = "TVItemID")]
        [CSSPDisplayFR(DisplayFR = "TVItemID")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the TVItems table representing item of the tree view")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table TVItems représentant l'item de l'arbre visuel")]
        public int TVItemID { get; set; }
        /// <summary>
        /// > [!NOTE]
        /// > <para>**Other custom attributes**</para>
        /// > <para>[[CSSPEnumType](CSSPModels.CSSPEnumTypeAttribute.html)]</para>
        /// > <para>[[CSSPDisplayEN](CSSPModels.CSSPDisplayEN.html)(DisplayEN = "TV type")]</para>
        /// > <para>[[CSSPDisplayFR](CSSPModels.CSSPDisplayFR.html)(DisplayFR = "Type d'arbre visuel")]</para>
        /// > <para>[[CSSPDescriptionEN](CSSPModels.CSSPDescriptionEN.html)(DescriptionEN = "Tree view type")]</para>
        /// > <para>[[CSSPDescriptionFR](CSSPModels.CSSPDescriptionFR.html)(DescriptionFR = "Type d'arbre visuel")]</para>
        /// </summary>
        /// <returns>
        /// 
        /// **Display (en)** --- TV type
        /// 
        /// **Display (fr)** --- Type d'arbre visuel
        /// 
        /// **Description (en)** --- Tree view type
        /// 
        /// **Description (fr)** --- Type d'arbre visuel
        /// </returns>
        [CSSPEnumType]
        [CSSPDisplayEN(DisplayEN = "TV type")]
        [CSSPDisplayFR(DisplayFR = "Type d'arbre visuel")]
        [CSSPDescriptionEN(DescriptionEN = @"Tree view type")]
        [CSSPDescriptionFR(DescriptionFR = @"Type d'arbre visuel")]
        public TVTypeEnum TVType { get; set; }
        /// <summary>
        /// > [!NOTE]
        /// > <para>**Other custom attributes**</para>
        /// > <para>[[CSSPDisplayEN](CSSPModels.CSSPDisplayEN.html)(DisplayEN = "Child items number")]</para>
        /// > <para>[[CSSPDisplayFR](CSSPModels.CSSPDisplayFR.html)(DisplayFR = "Nombre sous items")]</para>
        /// > <para>[[CSSPDescriptionEN](CSSPModels.CSSPDescriptionEN.html)(DescriptionEN = "Child items number")]</para>
        /// > <para>[[CSSPDescriptionFR](CSSPModels.CSSPDescriptionFR.html)(DescriptionFR = "Nombre sous items")]</para>
        /// </summary>
        /// <returns>
        /// 
        /// **Display (en)** --- Child items number
        /// 
        /// **Display (fr)** --- Nombre sous items
        /// 
        /// **Description (en)** --- Child items number
        /// 
        /// **Description (fr)** --- Nombre sous items
        /// </returns>
        [Range(0, 10000000)]
        [CSSPDisplayEN(DisplayEN = "Child items number")]
        [CSSPDisplayFR(DisplayFR = "Nombre sous items")]
        [CSSPDescriptionEN(DescriptionEN = @"Child items number")]
        [CSSPDescriptionFR(DescriptionFR = @"Nombre sous items")]
        public int ChildCount { get; set; }
        #endregion Properties in DB

        #region Constructors
        public TVItemStat() : base()
        {
        }
        #endregion Constructors
    }
    /// <summary>
    /// > [!NOTE]
    /// > 
    /// > <para>**No DB properties** :</para>
    /// > <para>**Other properties** : [TVItemStatID](CSSPModels.TVItemStat.html#CSSPModels_TVItemStat_TVItemStatID), [TVItemID](CSSPModels.TVItemStat.html#CSSPModels_TVItemStat_TVItemID), [TVType](CSSPModels.TVItemStat.html#CSSPModels_TVItemStat_TVType), [ChildCount](CSSPModels.TVItemStat.html#CSSPModels_TVItemStat_ChildCount)</para>
    /// > 
    /// > <para>**Used by [CSSPServices](CSSPServices.html)** : [TVItemStatService](CSSPServices.TVItemStatService.html)</para>
    /// > <para>**Used by [CSSPWebAPI.Controllers](CSSPWebAPI.Controllers.html)** : [TVItemStatController](CSSPWebAPI.Controllers.TVItemStatController.html)</para>
    /// > <para>**Requires [CSSPEnums](CSSPEnums.html)** : [TVTypeEnum](CSSPEnums.TVTypeEnum.html)</para>
    /// > <para>**Return to [CSSPModels](CSSPModels.html)**</para>
    /// </summary>
}
