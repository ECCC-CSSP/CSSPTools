/*
 * Manually edited
 * 
 */
using CSSPCustomAttributes;
using CSSPDBModels;
using CSSPEnums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSSPHelperModels
{
    [NotMapped]
    public partial class TVItemInfrastructureTypeTVItemLink
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [CSSPEnumType]
        public InfrastructureTypeEnum InfrastructureType { get; set; }
        [CSSPAllowNull]
        public int? SeeOtherMunicipalityTVItemID { get; set; }
        [CSSPMaxLength(100)]
        [CSSPEnumTypeText(EnumTypeName = "InfrastructureTypeEnum", EnumType = "InfrastructureType")]
        [CSSPAllowNull]
        public string InfrastructureTypeText { get; set; }
        public TVItem TVItem { get; set; }
        public List<TVItemLink> TVItemLinkList { get; set; }
        public TVItemInfrastructureTypeTVItemLink FlowTo { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public TVItemInfrastructureTypeTVItemLink() : base()
        {
            TVItemLinkList = new List<TVItemLink>();
        }
        #endregion Constructors
    }
}
