namespace CSSPModels;

[NotMapped]
public partial class TVItemInfrastructureTypeTVItemLink
{
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

    public TVItemInfrastructureTypeTVItemLink() : base()
    {
        TVItemLinkList = new List<TVItemLink>();
    }
}

