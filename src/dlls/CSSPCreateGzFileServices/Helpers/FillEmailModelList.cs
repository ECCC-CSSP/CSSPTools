﻿/*
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
using System.Reflection;

namespace CreateGzFileServices
{
    public partial class CreateGzFileService : ControllerBase, ICreateGzFileService
    {
        private async Task<bool> FillEmailModelList(List<EmailModel> EmailModelList, TVItem TVItem)
        {
            string FunctionName = $"{ await CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(List<EmailModel> EmailModelList, TVItem TVItem) -- TVItem.TVItemID: { TVItem.TVItemID }   TVItem.TVPath: { TVItem.TVPath })";
            await CSSPLogService.FunctionLog(FunctionName);

            List<Email> EmailList = await GetAllEmail();
            List<TVItem> TVItemList = await GetTVItemChildrenListWithTVItemID(TVItem, TVTypeEnum.Email);
            List<TVItemLanguage> TVItemLanguageList = await GetTVItemLanguageChildrenListWithTVItemID(TVItem, TVTypeEnum.Email);

            foreach (TVItem tvItem in TVItemList)
            {
                TVItemModel tvItemModel = new TVItemModel();
                tvItemModel.TVItem = tvItem;
                tvItemModel.TVItemLanguageList = (from c in TVItemLanguageList
                                                  where c.TVItemID == c.TVItemID
                                                  select c).ToList();
               
                foreach (TVItemLanguage tvItemLanguage in tvItemModel.TVItemLanguageList)
                {
                    tvItemLanguage.TVText = tvItemLanguage.TVText.Replace(Convert.ToChar(160), ' ');

                    RegexOptions options = RegexOptions.None;
                    Regex regex = new Regex("[ ]{2,}", options);
                    tvItemLanguage.TVText = regex.Replace(tvItemLanguage.TVText, " ");
                }
                EmailModelList.Add(new EmailModel()
                {
                    TVItemModel = tvItemModel,
                    Email = EmailList.Where(c => c.EmailTVItemID == tvItem.TVItemID).FirstOrDefault(),
                });
            }

            await CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(true);
        }
    }
}