namespace CSSPWebModels;

[NotMapped]
public partial class WebAllEmails
{
    public List<Email> EmailList { get; set; }

    public WebAllEmails()
    {
        EmailList = new List<Email>();
    }
}

