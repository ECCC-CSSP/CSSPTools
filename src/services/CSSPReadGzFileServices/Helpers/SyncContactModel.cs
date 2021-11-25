namespace CSSPReadGzFileServices;

public partial class CSSPReadGzFileService : ICSSPReadGzFileService
{
    private void SyncContactModel(ContactModel contactModelOriginal, ContactModel contactModelLocal)
    {
        if (contactModelLocal != null)
        {
            if (contactModelLocal.Contact != null)
            {
                contactModelOriginal.Contact = contactModelLocal.Contact;
            }
            if (contactModelLocal.ContactEmailTVItemIDList != null)
            {
                contactModelOriginal.ContactEmailTVItemIDList = contactModelLocal.ContactEmailTVItemIDList;
            }
            if (contactModelLocal.ContactTelTVItemIDList != null)
            {
                contactModelOriginal.ContactTelTVItemIDList = contactModelLocal.ContactTelTVItemIDList;
            }
            if (contactModelLocal.ContactAddressTVItemIDList != null)
            {
                contactModelOriginal.ContactAddressTVItemIDList = contactModelLocal.ContactAddressTVItemIDList;
            }
        }
    }
}

