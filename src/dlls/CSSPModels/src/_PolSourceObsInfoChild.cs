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
    public partial class PolSourceObsInfoChild
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [CSSPEnumType]
        [CSSPDisplayEN(DisplayEN = "Pol source obs info")]
        [CSSPDisplayFR(DisplayFR = "Info de obs de la source de pollution")]
        [CSSPDescriptionEN(DescriptionEN = @"Pollution source observation information")]
        [CSSPDescriptionFR(DescriptionFR = @"Information de l'observation de la source de pollution")]
        public PolSourceObsInfoEnum PolSourceObsInfo { get; set; }
        [CSSPEnumType]
        [CSSPDisplayEN(DisplayEN = "Pol source obs info of child start")]
        [CSSPDisplayFR(DisplayFR = "Info de obs de la source de pollution de départ de l'enfant")]
        [CSSPDescriptionEN(DescriptionEN = @"Pollution source observation information of child start")]
        [CSSPDescriptionFR(DescriptionFR = @"Information de l'observation de la source de pollution du départ de l'enfant")]
        public PolSourceObsInfoEnum PolSourceObsInfoChildStart { get; set; }
        [StringLength(100)]
        [CSSPEnumTypeText(EnumTypeName = "PolSourceObsInfoEnum", EnumType = "PolSourceObsInfo")]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Pol source obs info text")]
        [CSSPDisplayFR(DisplayFR = "Texte de info de obs de la source de pollution")]
        [CSSPDescriptionEN(DescriptionEN = @"Pollution source observation information text")]
        [CSSPDescriptionFR(DescriptionFR = @"Texte de l'nformation de l'observation de la source de pollution")]
        public string PolSourceObsInfoText { get; set; }
        [StringLength(100)]
        [CSSPEnumTypeText(EnumTypeName = "PolSourceObsInfoEnum", EnumType = "PolSourceObsInfoChildStart")]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Pol source obs info of child start text")]
        [CSSPDisplayFR(DisplayFR = "Texte de l'info de obs de la source de pollution de départ de l'enfant")]
        [CSSPDescriptionEN(DescriptionEN = @"Pollution source observation information of child start text")]
        [CSSPDescriptionFR(DescriptionFR = @"Texte de l'information de l'observation de la source de pollution du départ de l'enfant")]
        public string PolSourceObsInfoChildStartText { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public PolSourceObsInfoChild() : base()
        {
        }
        #endregion Constructors
    }
}
