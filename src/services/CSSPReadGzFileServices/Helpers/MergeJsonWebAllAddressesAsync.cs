namespace CSSPReadGzFileServices;

public partial class CSSPReadGzFileService : ICSSPReadGzFileService
{
    private async Task<bool> MergeJsonWebAllAddressesAsync(WebAllAddresses webAllAddresses, WebAllAddresses webAllAddressesLocal)
    {
        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(WebAllAddresses WebAllAddresses, WebAllAddresses WebAllAddressesLocal)";
        CSSPLogService.FunctionLog(FunctionName);

        MergeJsonWebAllAddressesAddressModelList(webAllAddresses, webAllAddressesLocal);

        CSSPLogService.EndFunctionLog(FunctionName);

        return await Task.FromResult(true);
    }

    private void MergeJsonWebAllAddressesAddressModelList(WebAllAddresses webAllAddresses, WebAllAddresses webAllAddressesLocal)
    {
        List<Address> addressLocalList = (from c in webAllAddressesLocal.AddressList
                                          where c.DBCommand != DBCommandEnum.Original
                                          select c).ToList();

        foreach (Address addressLocal in addressLocalList)
        {
            Address addressOriginal = webAllAddresses.AddressList.Where(c => c.AddressID == addressLocal.AddressID).FirstOrDefault();
            if (addressOriginal == null)
            {
                webAllAddresses.AddressList.Add(addressLocal);
            }
            else
            {
                addressOriginal = addressLocal;
            }
        }
    }
}

