namespace CSSPDBModels;

public partial class PolSourceObservation : LastUpdate
{
    [Key]
    public int PolSourceObservationID { get; set; }
    [CSSPEnumType]
    public DBCommandEnum DBCommand { get; set; }
    [CSSPExist(ExistTypeName = "PolSourceSite", ExistPlurial = "s", ExistFieldID = "PolSourceSiteID")]
    [CSSPForeignKey(TableName = "PolSourceSites", FieldName = "PolSourceSiteID")]
    public int PolSourceSiteID { get; set; }
    [CSSPAfter(Year = 1980)]
    public DateTime ObservationDate_Local { get; set; }
    [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "5")]
    [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
    public int ContactTVItemID { get; set; }
    public bool DesktopReviewed { get; set; }
    public string Observation_ToBeDeleted { get; set; }

    public PolSourceObservation() : base()
    {
    }
}

