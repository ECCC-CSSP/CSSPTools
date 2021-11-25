namespace CSSPWebModels;

[NotMapped]
public partial class EmailDistributionListModel
{
    public EmailDistributionList EmailDistributionList { get; set; }
    public List<EmailDistributionListLanguage> EmailDistributionListLanguageList { get; set; }
    public List<EmailDistributionListContactModel> EmailDistributionListContactModelList { get; set; }

    public EmailDistributionListModel()
    {
        EmailDistributionList = new EmailDistributionList();
        EmailDistributionListLanguageList = new List<EmailDistributionListLanguage>();
        EmailDistributionListContactModelList = new List<EmailDistributionListContactModel>();
    }
}

