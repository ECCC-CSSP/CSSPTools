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
using CSSPCultureServices.Resources;

namespace CSSPDesktopServices.Services
{
    public partial class CSSPDesktopService : ICSSPDesktopService
    {
        private async Task<bool> DoCheckIfNewTVItemsOrTVItemLanguagesExist()
        {
            AppendStatus(new AppendEventArgs(CSSPCultureDesktopRes.CheckIfNewTVItemsOrTVItemLanguagesExist));

            Preference preferenceHasInternetConnection = await GetPreferenceWithVariableName("HasInternetConnection");

            if (preferenceHasInternetConnection == null)
            {
                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.CouldNotFind_InDBLogin_, "HasInternetConnection", "Preferences")));
                return await Task.FromResult(true);
            }

            bool HasInternetConnection = bool.Parse(preferenceHasInternetConnection.VariableValue);

            //HasNewTVItemsOrTVItemLanguages = false;

            if (!HasInternetConnection)
            {
                return await Task.FromResult(true);
            }

            TVItem LastTVItem = await (from c in dbSearch.TVItems
                                       orderby c.LastUpdateDate_UTC descending
                                       select c).FirstOrDefaultAsync();

            if (LastTVItem == null)
            {
                AppendStatus(new AppendEventArgs(CSSPCultureDesktopRes.CSSPDBSearchIsEmpty));
                AppendStatus(new AppendEventArgs(CSSPCultureDesktopRes.UpdatingCSSPDBSearchThisCanTakeSomeTime));

                if (!await FillCSSPDBSearch()) return await Task.FromResult(false);

                int numberOfTVItem = await (from c in dbSearch.TVItems
                                            select c).CountAsync();

                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.CSSPDBSearchHasBeenUpdated_TVItems, numberOfTVItem.ToString())));
            }
            else
            {
                AppendStatus(new AppendEventArgs(CSSPCultureDesktopRes.CSSPDBSearchIsNotEmpty));
                AppendStatus(new AppendEventArgs(CSSPCultureDesktopRes.UpdatingCSSPDBSearchThisCanTakeSomeTime));

                int numberOfTVItem = await (from c in dbSearch.TVItems
                                            select c).CountAsync();

                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.CSSPDBSearchHas_TVItems, numberOfTVItem.ToString())));

                if (!await UpdateCSSPDBSearch()) return await Task.FromResult(false);

                numberOfTVItem = await (from c in dbSearch.TVItems
                                        select c).CountAsync();

                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.CSSPDBSearchHasBeenUpdated_TVItems, numberOfTVItem.ToString())));
            }

            AppendStatus(new AppendEventArgs(""));

            return await Task.FromResult(true);
        }
    }
}
