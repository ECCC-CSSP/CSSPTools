/*
 * Manually edited
 * 
 */
using CSSPCultureServices.Resources;
using CSSPEnums;
using CSSPDBModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSSPWebModels;

namespace CreateGzFileServices
{
    public partial class CreateGzFileService : ControllerBase, ICreateGzFileService
    {
        private async Task FillAddressModelList(List<AddressModel> AddressModelList, TVItem TVItem)
        {
            List<Address> AddressList = await GetAllAddress();
            List<TVItem> TVItemList = await GetTVItemChildrenListWithTVItemID(TVItem, TVTypeEnum.Address);
            List<TVItemLanguage> TVItemLanguageList = await GetTVItemLanguageChildrenListWithTVItemID(TVItem, TVTypeEnum.Address);

            foreach (TVItem tvItem in TVItemList)
            {
                AddressModelList.Add(new AddressModel()
                {
                    Address = AddressList.Where(c => c.AddressTVItemID == tvItem.TVItemID).FirstOrDefault(),
                    TVItem = tvItem,
                    TVItemLanguageList = TVItemLanguageList.Where(c => c.TVItemID == tvItem.TVItemID).ToList(),
                });
            }
        }
    }
}