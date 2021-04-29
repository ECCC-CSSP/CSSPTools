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
        private async Task FillEmailModelList(List<EmailModel> EmailModelList, TVItem TVItem)
        {
            List<Email> EmailList = await GetAllEmail();
            List<TVItem> TVItemList = await GetTVItemChildrenListWithTVItemID(TVItem, TVTypeEnum.Email);
            List<TVItemLanguage> TVItemLanguageList = await GetTVItemLanguageChildrenListWithTVItemID(TVItem, TVTypeEnum.Email);

            foreach (TVItem tvItem in TVItemList)
            {
                EmailModelList.Add(new EmailModel()
                {
                    TVItem = tvItem,
                    TVItemLanguageList = TVItemLanguageList.Where(c => c.TVItemID == tvItem.TVItemID).ToList(),
                    Email = EmailList.Where(c => c.EmailTVItemID == tvItem.TVItemID).FirstOrDefault(),
                });
            }
        }
    }
}