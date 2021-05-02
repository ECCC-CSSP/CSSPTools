/* 
 *  Manually Edited
 *  
 */

using CSSPCultureServices.Resources;
using CSSPCultureServices.Services;
using CSSPDBModels;
using CSSPDBPreferenceModels;
using CSSPEnums;
using CSSPHelperModels;
using CSSPScrambleServices;
using CSSPWebModels;
using LoggedInServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace CSSPDBLocalServices.Tests
{
    public partial class TVItemLocalServiceTest
    {
        private async Task DoValidateTest(int ParentTVItemID, WebTypeEnum webType, TVTypeEnum tvType, string obj, string variable, string err)
        {
            await LoadWebType(ParentTVItemID, webType);

            List<TVItemModel> tvItemParentList = await GetWebBaseParentList(webType);
            Assert.NotNull(tvItemParentList);

            string TVTextEN = "New item";
            string TVTextFR = "Nouveau item";
            PostTVItemModel postTVItemModel = FillPostTVItemModelForAdd(tvItemParentList, TVTextEN, TVTextFR, tvType);

            switch (obj)
            {
                case "TVItem":
                    {
                        ChangeTVItemVariableValue(postTVItemModel.TVItem, variable);
                    }
                    break;
                case "TVItemParent":
                    {
                        ChangeTVItemVariableValue(postTVItemModel.TVItemParent, variable);
                    }
                    break;
                //case "TVItemGrandParent":
                //    {
                //        ChangeTVItemVariableValue(postTVItemModel.TVItemGrandParent, variable);
                //    }
                //    break;
                case "TVItemLanguageEN":
                    {
                        ChangeTVItemLanguageVariableValue(postTVItemModel.TVItem, postTVItemModel.TVItemLanguageList[(int)LanguageEnum.en], variable);
                    }
                    break;
                case "TVItemLanguageFR":
                    {
                        ChangeTVItemLanguageVariableValue(postTVItemModel.TVItem, postTVItemModel.TVItemLanguageList[(int)LanguageEnum.fr], variable);
                    }
                    break;
                default:
                    break;
            }

            await TestAddOrModifyError(postTVItemModel, err);
        }
    }
}
