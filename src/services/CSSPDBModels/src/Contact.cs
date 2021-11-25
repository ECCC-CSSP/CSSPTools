namespace CSSPDBModels;

public partial class Contact : LastUpdate
{
    [Key]
    public int ContactID { get; set; }
    [CSSPEnumType]
    public DBCommandEnum DBCommand { get; set; }
    //[CSSPExist(ExistTypeName = "AspNetUser", ExistPlurial = "s", ExistFieldID = "Id")]
    [CSSPMaxLength(450)]
    //[CSSPForeignKey(TableName = "AspNetUsers", FieldName = "Id")]
    public string Id { get; set; }
    [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "5")]
    [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
    public int ContactTVItemID { get; set; }
    [CSSPMaxLength(255)]
    [CSSPMinLength(6)]
    [DataType(DataType.EmailAddress)]
    public string LoginEmail { get; set; }
    [CSSPMaxLength(100)]
    public string FirstName { get; set; }
    [CSSPMaxLength(100)]
    public string LastName { get; set; }
    [CSSPMaxLength(50)]
    [CSSPAllowNull]
    public string Initial { get; set; }
    [CSSPMaxLength(50)]
    [CSSPAllowNull]
    public string CellNumber { get; set; }
    [CSSPAllowNull]
    public bool? CellNumberConfirmed { get; set; }
    [CSSPMaxLength(100)]
    public string WebName { get; set; }
    [CSSPEnumType]
    [CSSPAllowNull]
    public ContactTitleEnum? ContactTitle { get; set; }
    public bool IsAdmin { get; set; }
    public bool EmailValidated { get; set; }
    public bool Disabled { get; set; }
    public bool IsNew { get; set; }
    [CSSPMaxLength(200)]
    [CSSPAllowNull]
    public string SamplingPlanner_ProvincesTVItemID { get; set; }
    [CSSPMaxLength(255)]
    [CSSPAllowNull]
    public string PasswordHash { get; set; }
    [CSSPMaxLength(255)]
    [CSSPAllowNull]
    public string Token { get; set; }
    public bool? HasInternetConnection { get; set; }
    public bool? IsLoggedIn { get; set; }
    [CSSPMaxLength(255)]
    [CSSPAllowNull]
    public string GoogleMapKeyHash { get; set; }
    [CSSPMaxLength(255)]
    [CSSPAllowNull]
    public string AzureStoreHash { get; set; }
    [CSSPRange(0, 10)]
    [CSSPAllowNull]
    public int? AccessFailedCount { get; set; }

    public Contact() : base()
    {
    }
}

