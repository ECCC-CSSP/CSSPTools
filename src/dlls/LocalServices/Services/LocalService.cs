using CSSPEnums;
using CSSPModels;
using CSSPCultureServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.Extensions.Configuration;

namespace LocalServices
{
    public interface ILocalService
    {
        // Properties
        LoggedInContactInfo LoggedInContactInfo { get; set; }

        // Functions
        Task<bool> CheckInternetConnection();
        Task<string> Descramble(string Text);
        Task<string> Scramble(string Text);
        Task<bool> SetLoggedInContactInfo();
    }
    public class LocalService : ILocalService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public LoggedInContactInfo LoggedInContactInfo { get; set; } = null;

        private List<int> skip { get; set; } = new List<int>()
        {
            3, 1, -3, 2, 2, 0, 4, 1, -2, 2, -1, 3, -2, 0, 1, 3, 1, 2, -4, -1, 1, 2, 0, 2, 1,
            -1, 4, -4, 2, 3, 1, 2, 3, 1, 2, 3, 1, 3, 1, -2, -1, -1, 4, -2, 2, -3, 2, 2, 0, 4,
            3, 1, 1, -2, -1, 3, -2, 0, 3, 2, 0, 1, 4, 1, 1, -4, -1, 2, 0, 2, 1, -3, 2, -2, -1, 3, -2, 0, 3, 1, -4, -1, 2, 0, 2, 1,
            -2, 3, 1, -3, 2, 3, -2, -1, 4, 1, -2, 2, 2, -1, 0, 4, 1, -2, -1, 3, -2, 0, 3, -1, 1, -4, -1, 2, 0, 2, 1,
            -1, 2, 3, 2, 1, -3, 2, 3, 2, 0, 4, 1, 2, -2, -1, 0, 3, -2, 0, 3, 1, -4, -1, 3, 2, 0, 2, 1,
            -4, 3, 1, -3, 1, 2, 2, 0, 1, 2, 4, 1, -1, 3, -1, -2, -1, 3, -2, 0, 3, 1, -4, -1, 2, 0, -1, 2, 1,
            1, 3, 4, 1, -3, -2, 2, 2, 0, -1, 4, 1, -2, -1, 3, 2, -2, 0, 1, 3, 1, -2, -4, -1, -1, 2, 0, 2, 1,
            4, 3, -2, -1, 2, 0, 2, -1, 4, 2, 0, 1, -1, -1, -3, -2, 2, -4, 3, 2, 1, -3, 2, -1, 2, 4, 0, 0, 1,
            2, 1, -2, -4, 1, 3, -3, 1, -1, 2, 1, 0, 4, -1, 1, -1, -3, 1, 1, -3, -4, 1, -3, 1, -3, 1, -1, 0,
            4, 2, 1, -3, 1, -2, 1, -4, 1, -2, 0, 3, -1, 4, 1, -2, 1, 0, -4, -1, -3, 2, 1, 4, -1, 1, 2, 4, 2
        };
        private ICSSPCultureService CSSPCultureService { get; set; }
        private CSSPDBLoginContext dbLogin { get; set; }
        private CSSPDBLoginInMemoryContext dbLoginIM { get; set; }
        #endregion Properties

        #region Constructors
        public LocalService(ICSSPCultureService CSSPCultureService, CSSPDBLoginContext dbLogin, CSSPDBLoginInMemoryContext dbLoginIM)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.dbLogin = dbLogin;
            this.dbLoginIM = dbLoginIM;
        }
        #endregion Constructors

        #region Functions public
        public async Task<bool> CheckInternetConnection()
        {
            string url = "https://www.google.com/";

            try
            {
                HttpClient httpClient = new HttpClient();
                string ret = httpClient.GetStringAsync(url).GetAwaiter().GetResult();
                if (!string.IsNullOrWhiteSpace(ret))
                {
                    return await Task.FromResult(true);
                }
                else
                {
                    return await Task.FromResult(false);
                }
            }
            catch (Exception)
            {
                return await Task.FromResult(false);
            }
        }
        public async Task<string> Descramble(string Text)
        {
            string retStr = "";
            if (string.IsNullOrWhiteSpace(Text)) return "";

            string retStr2 = "";
            int length = Text.Length - 1;
            for (int j = length; j > -1; j--)
            {
                retStr2 += Text[j].ToString();
            }

            Text = retStr2;

            int Start = int.Parse(Text.Substring(0, 1));

            Text = Text.Substring(1);
            int i = 0;
            foreach (char c in Text)
            {
                retStr += (char)((int)c - skip[i + Start]);
                i += 1;
            }

            return await Task.FromResult(retStr);
        }
        public async Task<string> Scramble(string Text)
        {
            Random r = new Random();
            int Start = r.Next(1, 9);

            if (Text.Length == 0) return await Task.FromResult("");

            string retStr = Start.ToString();
            int i = 0;
            foreach (char c in Text)
            {
                retStr += (char)((int)c + skip[i + Start]);
                i += 1;
            }

            string retStr2 = "";
            int length = retStr.Length - 1;
            for (int j = length; j > -1; j--)
            {
                retStr2 += retStr[j].ToString();
            }

            return await Task.FromResult(retStr2);
        }
        public async Task<bool> SetLoggedInContactInfo()
        {
            LoggedInContactInfo = new LoggedInContactInfo();

            LoggedInContactInfo.LoggedInContact = (from c in dbLoginIM.Contacts
                                                   select c).FirstOrDefault();

            if (LoggedInContactInfo.LoggedInContact == null)
            {
                LoggedInContactInfo.LoggedInContact = (from c in dbLogin.Contacts
                                                       select c).FirstOrDefault();

                if (LoggedInContactInfo.LoggedInContact == null)
                {
                    LoggedInContactInfo.TVTypeUserAuthorizationList = new List<TVTypeUserAuthorization>();
                    LoggedInContactInfo.TVItemUserAuthorizationList = new List<TVItemUserAuthorization>();
                    LoggedInContactInfo.Preference = new Preference();
                }
                else
                {
                    // doing LoggedInContacts
                    try
                    {
                        dbLoginIM.Contacts.Add(LoggedInContactInfo.LoggedInContact);
                        await dbLoginIM.SaveChangesAsync();
                    }
                    catch (Exception)
                    {
                        // nothing yet
                        return await Task.FromResult(false);
                    }

                    // doing TVTypeUserAuthorizationList 
                    LoggedInContactInfo.TVTypeUserAuthorizationList = (from c in dbLogin.TVTypeUserAuthorizations
                                                                       where c.ContactTVItemID == LoggedInContactInfo.LoggedInContact.ContactTVItemID
                                                                       select c).ToList();

                    if (LoggedInContactInfo.TVTypeUserAuthorizationList.Count > 0)
                    {
                        try
                        {
                            dbLoginIM.TVTypeUserAuthorizations.AddRange(LoggedInContactInfo.TVTypeUserAuthorizationList);
                            await dbLoginIM.SaveChangesAsync();
                        }
                        catch (Exception)
                        {
                            // nothing yet
                            return await Task.FromResult(false);
                        }
                    }

                    // doing TVItemUserAuthorizationList 
                    LoggedInContactInfo.TVItemUserAuthorizationList = (from c in dbLogin.TVItemUserAuthorizations
                                                                       where c.ContactTVItemID == LoggedInContactInfo.LoggedInContact.ContactTVItemID
                                                                       select c).ToList();

                    if (LoggedInContactInfo.TVItemUserAuthorizationList.Count > 0)
                    {
                        try
                        {
                            dbLoginIM.TVItemUserAuthorizations.AddRange(LoggedInContactInfo.TVItemUserAuthorizationList);
                            await dbLoginIM.SaveChangesAsync();
                        }
                        catch (Exception)
                        {
                            // nothing yet
                            return await Task.FromResult(false);
                        }
                    }

                    // doing Preference
                    LoggedInContactInfo.Preference = (from c in dbLogin.Preferences
                                                      select c).FirstOrDefault();

                    if (LoggedInContactInfo.Preference != null)
                    {
                        try
                        {
                            dbLoginIM.Preferences.Add(LoggedInContactInfo.Preference);
                            await dbLoginIM.SaveChangesAsync();
                        }
                        catch (Exception)
                        {
                            // nothing yet
                            return await Task.FromResult(false);
                        }
                    }
                }
            }
            else
            {
                LoggedInContactInfo.TVTypeUserAuthorizationList = (from c in dbLoginIM.TVTypeUserAuthorizations
                                                                   where c.ContactTVItemID == LoggedInContactInfo.LoggedInContact.ContactTVItemID
                                                                   select c).ToList();

                LoggedInContactInfo.TVItemUserAuthorizationList = (from c in dbLoginIM.TVItemUserAuthorizations
                                                                   where c.ContactTVItemID == LoggedInContactInfo.LoggedInContact.ContactTVItemID
                                                                   select c).ToList();

                LoggedInContactInfo.Preference = (from c in dbLoginIM.Preferences
                                                  select c).FirstOrDefault();
            }

            return await Task.FromResult(true);

        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
