using CSSPCultureServices.Resources;
using CSSPDesktopServices.Models;
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.SignalR;

namespace CSSPDesktopServices.Services
{
    public partial class CSSPDesktopService : ICSSPDesktopService
    {
        #region Properties
        #endregion Properties

        #region Functions private
        private async Task<bool> DoStoreVariableIndbLogin(string strName, string strValue)
        {
            // Adding Preference AzureStore item in dbLogin
            Preference preference = (from c in dbLogin.Preferences
                                     where c.PreferenceName == strName
                                     select c).FirstOrDefault();

            if (preference == null)
            {
                int lastPreferenceID = (from c in dbLogin.Preferences
                                        orderby c.PreferenceID descending
                                        select c.PreferenceID).FirstOrDefault();

                preference = new Preference()
                {
                    PreferenceID = lastPreferenceID + 1,
                    PreferenceName = strName,
                    PreferenceText = await Scramble(strValue)
                };

                dbLogin.Preferences.Add(preference);
            }
            else
            {
                preference.PreferenceText = await Scramble(strValue);
            }

            try
            {
                dbLogin.SaveChanges();

                AppendStatus(new AppendEventArgs(string.Format(appTextModel._StoredInTable_AndDatabase_, strName, "Preferences", "CSSPDBLogin.db")));
            }
            catch (Exception ex)
            {
                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, $"Preference { strName }", ex.Message)));
                return await Task.FromResult(false);
            }

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
