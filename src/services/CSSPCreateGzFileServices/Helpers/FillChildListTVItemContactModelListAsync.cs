namespace CSSPCreateGzFileServices;

public partial class CSSPCreateGzFileService : ControllerBase, ICSSPCreateGzFileService
{
    private async Task<bool> FillChildListTVItemContactModelListAsync(List<ContactModel> ContactModelList, TVItem TVItem)
    {
        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(List<ContactModel> ContactModelList, TVItem TVItem) -- TVItem.TVItemID: { TVItem.TVItemID }   TVItem.TVPath: { TVItem.TVPath }";
        CSSPLogService.FunctionLog(FunctionName);

        List<Contact> MunicipalityContactList = await GetMunicipalityContactListUnderMunicipalityAsync(TVItem);
        List<int> MunicipalityContactEmailTVItemIDList = await GetMunicipalityContactEmailTVItemIDListUnderMunicipalityAsync(TVItem);
        List<int> MunicipalityContactTelTVItemIDList = await GetMunicipalityContactTelTVItemIDListUnderMunicipalityAsync(TVItem);
        List<int> MunicipalityContactAddressTVItemIDList = await GetMunicipalityContactAddressTVItemIDListUnderMunicipalityAsync(TVItem);


        foreach (Contact Contact in MunicipalityContactList)
        {
            ContactModel ContactModel = new ContactModel();
            ContactModel.Contact = Contact;
            ContactModel.ContactAddressTVItemIDList = MunicipalityContactAddressTVItemIDList;
            ContactModel.ContactEmailTVItemIDList = MunicipalityContactEmailTVItemIDList;
            ContactModel.ContactTelTVItemIDList = MunicipalityContactTelTVItemIDList;

            ContactModelList.Add(ContactModel);
        }

        CSSPLogService.EndFunctionLog(FunctionName);

        return await Task.FromResult(true);
    }
}
