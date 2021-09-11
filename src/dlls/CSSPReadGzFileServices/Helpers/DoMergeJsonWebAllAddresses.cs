﻿/*
 * Manually edited
 * 
 */
using CSSPEnums;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ReadGzFileServices
{
    public partial class ReadGzFileService : ControllerBase, IReadGzFileService
    {
        private void DoMergeJsonWebAllAddresses(WebAllAddresses WebAllAddresses, WebAllAddresses WebAllAddressesLocal)
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(WebAllAddresses WebAllAddresses, WebAllAddresses WebAllAddressesLocal)";
            CSSPLogService.FunctionLog(FunctionName);

            List<AddressModel> addressModelLocalList = (from c in WebAllAddressesLocal.AddressModelList
                                                        where c.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
                                                        || c.TVItemModel.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                                                        || c.TVItemModel.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original
                                                        || c.Address.DBCommand != DBCommandEnum.Original
                                                        select c).ToList();

            foreach (AddressModel addressModelLocal in addressModelLocalList)
            {
                AddressModel addressModelOriginal = WebAllAddresses.AddressModelList.Where(c => c.TVItemModel.TVItem.TVItemID == addressModelLocal.TVItemModel.TVItem.TVItemID).FirstOrDefault();
                if (addressModelOriginal == null)
                {
                    WebAllAddresses.AddressModelList.Add(addressModelLocal);
                }
                else
                {
                    addressModelOriginal = addressModelLocal;
                }
            }

            CSSPLogService.EndFunctionLog(FunctionName);
        }
    }
}
