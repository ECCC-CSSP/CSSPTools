/*
 * Manually edited
 * 
 */
using CSSPEnums;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ReadGzFileServices
{
    public partial class ReadGzFileService : ControllerBase, IReadGzFileService
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
            List<AddressModel> addressModelLocalList = (from c in webAllAddressesLocal.AddressModelList
                                                        where c.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
                                                        || c.TVItemModel.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                                                        || c.TVItemModel.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original
                                                        || c.Address.DBCommand != DBCommandEnum.Original
                                                        select c).ToList();

            foreach (AddressModel addressModelLocal in addressModelLocalList)
            {
                AddressModel addressModelOriginal = webAllAddresses.AddressModelList.Where(c => c.TVItemModel.TVItem.TVItemID == addressModelLocal.TVItemModel.TVItem.TVItemID).FirstOrDefault();
                if (addressModelOriginal == null)
                {
                    webAllAddresses.AddressModelList.Add(addressModelLocal);
                }
                else
                {
                    SyncAddress(addressModelOriginal.Address, addressModelLocal.Address);
                    SyncTVItemModel(addressModelOriginal.TVItemModel, addressModelLocal.TVItemModel);
                }
            }
        }
    }
}
