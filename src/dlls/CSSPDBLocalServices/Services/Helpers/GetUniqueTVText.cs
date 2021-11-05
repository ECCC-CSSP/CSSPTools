/*
 * Manually edited
 *
 */

using CSSPCreateGzFileServices;
using CSSPCultureServices.Resources;
using CSSPCultureServices.Services;
using CSSPDBModels;
using CSSPEnums;
using CSSPLocalLoggedInServices;
using CSSPLogServices;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using System.Linq;

namespace CSSPDBLocalServices
{

    public partial class HelperLocalService : ControllerBase, IHelperLocalService
    {
        public async Task<string> GetUniqueTVText(List<TVItemModel> TVItemModelList, LanguageEnum language, string StartText)
        {
            int LangID = language == LanguageEnum.fr ? 1 : 0;

            string TVText = "";
            for (int i = 1; i < 1000; i++)
            {
                TVText = $"{ StartText} { i }";

                if (!(from c in TVItemModelList
                      where c.TVItemLanguageList[LangID].TVText == TVText
                      select c).Any())
                {
                    break;
                }
            }

            return await Task.FromResult(TVText);
        }
    }
}