namespace CSSPModels;

[NotMapped]
public partial class ContactSearch
{
    [CSSPRange(1, -1)]
    public int ContactID { get; set; }
    [CSSPRange(1, -1)]
    public int ContactTVItemID { get; set; }
    [CSSPMaxLength(255)]
    public string FullName { get; set; }

    public ContactSearch() : base()
    {
    }
}

