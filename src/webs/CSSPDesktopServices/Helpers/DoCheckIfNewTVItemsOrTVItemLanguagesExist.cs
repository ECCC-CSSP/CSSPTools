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
using CSSPModels;

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

            TVItem LastTVItem = await (from c in dbSearch.TVItems
                                       orderby c.LastUpdateDate_UTC descending
                                       select c).FirstOrDefaultAsync();

            if (LastTVItem == null)
            {
                AppendStatus(new AppendEventArgs(appTextModel.CSSPDBSearchIsEmpty));
                AppendStatus(new AppendEventArgs(appTextModel.UpdatingCSSPDBSearchThisCanTakeSomeTime));

                if (!await FillCSSPDBSearch()) return await Task.FromResult(false);

                int numberOfTVItem = await (from c in dbSearch.TVItems
                                            select c).CountAsync();

                AppendStatus(new AppendEventArgs(string.Format(appTextModel.CSSPDBSearchHasBeenUpdated_TVItems, numberOfTVItem.ToString())));
            }
            else
            {
                AppendStatus(new AppendEventArgs(appTextModel.CSSPDBSearchIsNotEmpty));
                AppendStatus(new AppendEventArgs(appTextModel.UpdatingCSSPDBSearchThisCanTakeSomeTime));

                int numberOfTVItem = await (from c in dbSearch.TVItems
                                            select c).CountAsync();

                AppendStatus(new AppendEventArgs(string.Format(appTextModel.CSSPDBSearchHas_TVItems, numberOfTVItem.ToString())));

                if (!await UpdateCSSPDBSearch()) return await Task.FromResult(false);

                numberOfTVItem = await (from c in dbSearch.TVItems
                                        select c).CountAsync();

                AppendStatus(new AppendEventArgs(string.Format(appTextModel.CSSPDBSearchHasBeenUpdated_TVItems, numberOfTVItem.ToString())));
            }

            AppendStatus(new AppendEventArgs(""));

            return await Task.FromResult(true);
        }
    }
}
