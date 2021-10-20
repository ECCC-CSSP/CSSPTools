/*
 * Manually edited
 * 
 */
using CSSPDBModels;
using CSSPEnums;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CSSPReadGzFileServices
{
    public partial class CSSPReadGzFileService : ControllerBase, ICSSPReadGzFileService
    {
        private async Task<bool> DoMergeJsonWebAllAddresses(WebAllAddresses webAllAddresses, WebAllAddresses webAllAddressesLocal)
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(WebAllAddresses WebAllAddresses, WebAllAddresses WebAllAddressesLocal)";
            CSSPLogService.FunctionLog(FunctionName);

            DoMergeJsonWebAllAddressesAddressModelList(webAllAddresses, webAllAddressesLocal);

            CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(true);
        }

        private void DoMergeJsonWebAllAddressesAddressModelList(WebAllAddresses webAllAddresses, WebAllAddresses webAllAddressesLocal)
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
}
