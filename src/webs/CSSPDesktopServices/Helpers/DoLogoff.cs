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
        private async Task<bool> DoLogoff()
        {
            // Adding Preference LoggedIn item in dbLogin
            Preference preference = (from c in dbLogin.Preferences
                                 where c.PreferenceName == "LoggedIn"
                                 select c).FirstOrDefault();

            if (preference == null)
            {
                int lastPreferenceID = (from c in dbLogin.Preferences
                                        orderby c.PreferenceID descending
                                        select c.PreferenceID).FirstOrDefault();

                preference = new Preference()
                {
                    PreferenceID = lastPreferenceID + 1,
                    PreferenceName = "LoggedIn",
                    PreferenceText = await Scramble("false")
                };

                dbLogin.Preferences.Add(preference);
            }
            else
            {
                preference.PreferenceText = await Scramble("false");
            }

            try
            {
                dbLogin.SaveChanges();
                IsLoggedIn = false;
            }
            catch (Exception ex)
            {
                AppendTempStatus(new AppendTempEventArgs(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "Preference LoggedIn Item", ex.Message)));
                return await Task.FromResult(false);
            }

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
