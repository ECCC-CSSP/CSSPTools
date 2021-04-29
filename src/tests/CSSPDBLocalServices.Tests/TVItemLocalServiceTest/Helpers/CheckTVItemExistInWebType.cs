/* 
 *  Manually Edited
 *  
 */

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
        private async Task CheckTVItemExistInWebType(int TVItemID, WebTypeEnum webType)
        {
            await LoadWebType(TVItemID, webType);

            TVItemModel webBase = await GetWebBase(webType);

            List<TVItemStatModel> tvItemParentList = await GetWebBaseParentList(webType);
            Assert.NotNull(tvItemParentList);

            CompareTVItems(webBase.TVItem, tvItemParentList[tvItemParentList.Count - 1].TVItem);

            CompareTVItemLanguage(webBase.TVItemLanguageList, tvItemParentList[tvItemParentList.Count - 1].TVItemLanguageList);
        }
    }
}
