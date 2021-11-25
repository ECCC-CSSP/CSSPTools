namespace CSSPWebModels;

[NotMapped]
public partial class ContactModel
{
    public Contact Contact { get; set; }
    public List<int> ContactEmailTVItemIDList { get; set; }
    public List<int> ContactTelTVItemIDList { get; set; }
    public List<int> ContactAddressTVItemIDList { get; set; }

    public ContactModel()
    {
        Contact = new Contact();
        ContactEmailTVItemIDList = new List<int>();
        ContactTelTVItemIDList = new List<int>();
        ContactAddressTVItemIDList = new List<int>();
    }
}

