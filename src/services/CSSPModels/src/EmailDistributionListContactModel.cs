namespace CSSPModels;

[NotMapped]
public partial class EmailDistributionListContactModel
{
    public EmailDistributionListContact EmailDistributionListContact { get; set; }
    public List<EmailDistributionListContactLanguage> EmailDistributionListContactLanguageList { get; set; }

    public EmailDistributionListContactModel()
    {
        EmailDistributionListContact = EmailDistributionListContact;
        EmailDistributionListContactLanguageList = new List<EmailDistributionListContactLanguage>();
    }
}

