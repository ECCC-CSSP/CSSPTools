using CSSPEnums;
using CSSPModels;
using CSSPCultureServices.Resources;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using System.IO;
using Azure.Storage.Blobs.Models;
using CSSPDesktopServices.Models;
using CSSPServices;

namespace CSSPDesktopServices.Services
{
    public partial class CSSPDesktopService : ICSSPDesktopService
    {
        private async Task<bool> DoCheckIfNewTVItemsOrTVItemLanguagesExist()
        {
            AppendStatus(new AppendEventArgs(appTextModel.CheckIfNewTVItemsOrTVItemLanguagesExist));

            HasNewTVItemsOrTVItemLanguages = false;

            if (preference.HasInternetConnection == null || (bool)preference.HasInternetConnection == false)
            {
                return await Task.FromResult(true);
            }

            DateTime dateTimeLastTVItem = await (from c in dbSearch.TVItems
                                                 orderby c.LastUpdateDate_UTC descending
                                                 select c.LastUpdateDate_UTC).FirstOrDefaultAsync();

            if (dateTimeLastTVItem == null)
            {
                var actionRes = await CSSPDBSearchService.FillCSSDBSearch();
                if (((ObjectResult)actionRes.Result).StatusCode == 200)
                {
                    return await Task.FromResult(false);
                }
                else 
                { 
                    return await Task.FromResult(false);
                }
            }
            else
            {
                var actionTVItem = await CSSPDBSearchService.UpdateCSSDBSearch(dateTimeLastTVItem);

            }


            DateTime dateTimeLastTVItemLanguage = await (from c in dbSearch.TVItems
                                                         orderby c.LastUpdateDate_UTC descending
                                                         select c.LastUpdateDate_UTC).FirstOrDefaultAsync();





            AppendStatus(new AppendEventArgs(""));

            return await Task.FromResult(true);
        }
    }
}
