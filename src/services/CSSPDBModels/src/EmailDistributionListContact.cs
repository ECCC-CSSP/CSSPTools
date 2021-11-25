namespace CSSPDBModels;

public partial class EmailDistributionListContact : LastUpdate
{
    [Key]
    public int EmailDistributionListContactID { get; set; }
    [CSSPEnumType]
    public DBCommandEnum DBCommand { get; set; }
    [CSSPExist(ExistTypeName = "EmailDistributionList", ExistPlurial = "s", ExistFieldID = "EmailDistributionListID")]
    [CSSPForeignKey(TableName = "EmailDistributionLists", FieldName = "EmailDistributionListID")]
    public int EmailDistributionListID { get; set; }
    public bool IsCC { get; set; }
    [CSSPMaxLength(100)]
    public string Name { get; set; }
    [CSSPMaxLength(200)]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
    public bool CMPRainfallSeasonal { get; set; }
    public bool CMPWastewater { get; set; }
    public bool EmergencyWeather { get; set; }
    public bool EmergencyWastewater { get; set; }
    public bool ReopeningAllTypes { get; set; }

    public EmailDistributionListContact() : base()
    {
    }
}

