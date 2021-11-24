namespace ManageServices;

public partial class ManageFile
{
    [Key]
    public int ManageFileID { get; set; }
    [CSSPMaxLength(100)]
    public string AzureStorage { get; set; }
    [CSSPMaxLength(200)]
    public string AzureFileName { get; set; }
    [CSSPMaxLength(50)]
    public string AzureETag { get; set; }
    [CSSPAfter(Year = 1980)]
    public DateTime AzureCreationTimeUTC { get; set; }
    public bool LoadedOnce { get; set; }

    public ManageFile() : base()
    {
    }
}

