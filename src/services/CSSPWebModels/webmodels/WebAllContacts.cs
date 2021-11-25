namespace CSSPWebModels;

[NotMapped]
public partial class WebAllContacts
{
    public List<ContactModel> ContactModelList { get; set; }

    public WebAllContacts()
    {
        ContactModelList = new List<ContactModel>();
    }
}

