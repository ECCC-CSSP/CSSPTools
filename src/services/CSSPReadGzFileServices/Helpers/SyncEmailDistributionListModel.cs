namespace CSSPReadGzFileServices;

public partial class CSSPReadGzFileService : ICSSPReadGzFileService
{
    private void SyncEmailDistributionListModel(EmailDistributionListModel emailDistributionListModelOriginal, EmailDistributionListModel emailDistributionListModelLocal)
    {
        if (emailDistributionListModelLocal != null)
        {
            if (emailDistributionListModelLocal.EmailDistributionList != null)
            {
                emailDistributionListModelOriginal.EmailDistributionList = emailDistributionListModelLocal.EmailDistributionList;
            }

            if (emailDistributionListModelLocal.EmailDistributionListLanguageList != null)
            {
                emailDistributionListModelOriginal.EmailDistributionListLanguageList = emailDistributionListModelLocal.EmailDistributionListLanguageList;
            }

            foreach (EmailDistributionListContactModel emailDistributionListContactModelLocal in emailDistributionListModelLocal.EmailDistributionListContactModelList)
            {
                EmailDistributionListContactModel emailDistributionListContactModelOriginal = emailDistributionListModelOriginal.EmailDistributionListContactModelList.Where(c => c.EmailDistributionListContact.EmailDistributionListContactID == emailDistributionListContactModelLocal.EmailDistributionListContact.EmailDistributionListContactID).FirstOrDefault();

                if (emailDistributionListContactModelLocal.EmailDistributionListContact != null)
                {
                    emailDistributionListContactModelOriginal.EmailDistributionListContact = emailDistributionListContactModelLocal.EmailDistributionListContact;
                }
                if (emailDistributionListContactModelLocal.EmailDistributionListContactLanguageList != null)
                {
                    emailDistributionListContactModelOriginal.EmailDistributionListContactLanguageList = emailDistributionListContactModelLocal.EmailDistributionListContactLanguageList;
                }
            }
        }
    }
}

