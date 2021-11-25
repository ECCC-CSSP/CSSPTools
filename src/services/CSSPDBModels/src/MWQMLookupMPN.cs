namespace CSSPDBModels;

public partial class MWQMLookupMPN : LastUpdate
{
    [Key]
    public int MWQMLookupMPNID { get; set; }
    [CSSPEnumType]
    public DBCommandEnum DBCommand { get; set; }
    [CSSPRange(0, 5)]
    public int Tubes10 { get; set; }
    [CSSPRange(0, 5)]
    public int Tubes1 { get; set; }
    [CSSPRange(0, 5)]
    public int Tubes01 { get; set; }
    [CSSPRange(1, 10000)]
    public int MPN_100ml { get; set; }

    public MWQMLookupMPN() : base()
    {
    }
}

