namespace CSSPCreateGzFileServices;

public partial class CSSPCreateGzFileService : ControllerBase, ICSSPCreateGzFileService
{
    private async Task<bool> FillEmailDistributionListModelListAsync(List<EmailDistributionListModel> EmailDistributionListModelList, TVItem TVItem)
    {
        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(List<EmailDistributionListModel> EmailDistributionListModelList, TVItem TVItem) -- TVItem.TVItemID: { TVItem.TVItemID }   TVItem.TVPath: { TVItem.TVPath })";
        CSSPLogService.FunctionLog(FunctionName);

        List<EmailDistributionList> EmailDistributionListList = await GetEmailDistributionListListUnderCountryAsync(TVItem);
        List<EmailDistributionListLanguage> EmailDistributionListLanguageList = await GetEmailDistributionListLanguageListUnderCountryAsync(TVItem);
        List<EmailDistributionListContact> EmailDistributionListContactList = await GetEmailDistributionListContactListUnderCountryAsync(TVItem);
        List<EmailDistributionListContactLanguage> EmailDistributionListContactLanguageList = await GetEmailDistributionListContactLanguageListUnderCountryAsync(TVItem);

        foreach (EmailDistributionList emailDistributionList in EmailDistributionListList)
        {
            List<EmailDistributionListContactModel> emailDistributionListContactModelList = new List<EmailDistributionListContactModel>();

            List<EmailDistributionListContact> emailDistributionListContactList = EmailDistributionListContactList.Where(c => c.EmailDistributionListID == emailDistributionList.EmailDistributionListID).ToList();
            foreach (EmailDistributionListContact emailDistributionListContact in emailDistributionListContactList)
            {
                emailDistributionListContactModelList.Add(new EmailDistributionListContactModel()
                {
                    EmailDistributionListContact = emailDistributionListContact,
                    EmailDistributionListContactLanguageList = EmailDistributionListContactLanguageList.Where(c => c.EmailDistributionListContactID == emailDistributionListContact.EmailDistributionListContactID).ToList(),
                });
            }

            EmailDistributionListModelList.Add(new EmailDistributionListModel()
            {
                EmailDistributionList = emailDistributionList,
                EmailDistributionListLanguageList = EmailDistributionListLanguageList.Where(c => c.EmailDistributionListID == emailDistributionList.EmailDistributionListID).ToList(),
                EmailDistributionListContactModelList = emailDistributionListContactModelList,
            }); ;
        }

        CSSPLogService.EndFunctionLog(FunctionName);

        return await Task.FromResult(true);
    }
}
