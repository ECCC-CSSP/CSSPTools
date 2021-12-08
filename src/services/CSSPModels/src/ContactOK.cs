namespace CSSPModels;

[NotMapped]
public partial class ContactOK
{
    [CSSPRange(1, -1)]
    public int ContactID { get; set; }
    [CSSPRange(1, -1)]
    public int ContactTVItemID { get; set; }

    public ContactOK() : base()
    {
    }
}

