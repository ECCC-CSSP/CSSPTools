namespace CSSPCreateGzFileServices;

public partial class CSSPCreateGzFileService : ControllerBase, ICSSPCreateGzFileService
{
    private async Task<bool> FillAllContactModelListAsync(List<ContactModel> ContactModelList)
    {
        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(List<ContactModel> ContactModelList)";
        CSSPLogService.FunctionLog(FunctionName);

        List<Contact> ContactList = await GetAllContactAsync();
        List<Email> EmailList = await GetAllEmailAsync();
        List<Tel> TelList = await GetAllTelAsync();
        List<Address> AddressList = await GetAllAddressAsync();

        List<TVItemLink> TVItemLinkContactEmailList = await GetAllTVItemLinkAsync(TVTypeEnum.Contact, TVTypeEnum.Email);
        List<TVItemLink> TVItemLinkContactTelList = await GetAllTVItemLinkAsync(TVTypeEnum.Contact, TVTypeEnum.Tel);
        List<TVItemLink> TVItemLinkContactAddressList = await GetAllTVItemLinkAsync(TVTypeEnum.Contact, TVTypeEnum.Address);

        foreach (Contact contact in ContactList)
        {
            ContactModel contactModel = new ContactModel();
            contactModel.Contact = ContactList.Where(c => c.ContactTVItemID == contact.ContactTVItemID).FirstOrDefault();

            contactModel.ContactEmailTVItemIDList = (from c in TVItemLinkContactEmailList
                                                     where c.FromTVItemID == contact.ContactTVItemID
                                                     select c.ToTVItemID).ToList();

            contactModel.ContactTelTVItemIDList = (from c in TVItemLinkContactTelList
                                                   where c.FromTVItemID == contact.ContactTVItemID
                                                   select c.ToTVItemID).ToList();

            contactModel.ContactAddressTVItemIDList = (from c in TVItemLinkContactAddressList
                                                       where c.FromTVItemID == contact.ContactTVItemID
                                                       select c.ToTVItemID).ToList();

            ContactModelList.Add(contactModel);
        }

        CSSPLogService.EndFunctionLog(FunctionName);

        return await Task.FromResult(true);
    }
}
