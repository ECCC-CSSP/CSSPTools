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
using System.Text.RegularExpressions;

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
                TVItemModel tvItemModel = new TVItemModel();
                tvItemModel.TVItem = tvItem;
                tvItemModel.TVItemLanguageList = (from c in TVItemLanguageList
                                                  where c.TVItemID == tvItem.TVItemID
                                                  select c).ToList();

                foreach (TVItemLanguage tvItemLanguage in tvItemModel.TVItemLanguageList)
                {
                    tvItemLanguage.TVText = tvItemLanguage.TVText.Replace(Convert.ToChar(160), ' ');

                    RegexOptions options = RegexOptions.None;
                    Regex regex = new Regex("[ ]{2,}", options);
                    tvItemLanguage.TVText = regex.Replace(tvItemLanguage.TVText, " ");
                }

                AddressModelList.Add(new AddressModel()
                {
                    TVItemModel = tvItemModel,
                    Address = AddressList.Where(c => c.AddressTVItemID == tvItem.TVItemID).FirstOrDefault(),
                }); ;
            }
        }
    }
}