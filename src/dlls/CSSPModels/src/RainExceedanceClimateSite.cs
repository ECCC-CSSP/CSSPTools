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
    public partial class RainExceedanceClimateSite : LastUpdate
    {
        #region Properties in DB
        [Key]
        [CSSPDisplayEN(DisplayEN = "RainExceedanceClimateSite ID")]
        [CSSPDisplayFR(DisplayFR = "RainExceedanceClimateSite ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Contains the unique ""identifier on each row of the RainExceedanceClimateSites table")]
        [CSSPDescriptionFR(DescriptionFR = @"Contient l'identifiant unique sur chaque ligne de la table RainExceedanceClimateSites")]
        public int RainExceedanceClimateSiteID { get; set; }
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "75")]
        [CSSPDisplayEN(DisplayEN = "Rain exceedance TVItemID")]
        [CSSPDisplayFR(DisplayFR = "Excédance de pluie TVItemID (fr)")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the TVItems table representing rain exceedance")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table TVItems représentant l'excédance de pluie")]
        public int RainExceedanceTVItemID { get; set; }
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "4")]
        [CSSPDisplayEN(DisplayEN = "Climate Site TVItemID")]
        [CSSPDisplayFR(DisplayFR = "Site climatique TVItemID (fr)")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the TVItems table representing climate site")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table TVItems représentant le site climatique")]
        public int ClimateSiteTVItemID { get; set; }
        #endregion Properties in DB

        #region Constructors
        public RainExceedanceClimateSite() : base()
        {
        }
        #endregion Constructors
    }
}
