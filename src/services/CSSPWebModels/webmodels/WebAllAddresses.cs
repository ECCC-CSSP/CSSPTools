namespace CSSPWebModels;

[NotMapped]
public partial class WebAllAddresses
{
    public List<Address> AddressList { get; set; }

    public WebAllAddresses()
    {
        AddressList = new List<Address>();
    }
}

