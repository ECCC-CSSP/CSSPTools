using CSSPEnums;
using CSSPDBModels;
using CSSPCultureServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using CSSPDBPreferenceModels;
using CSSPHelperModels;

namespace LocalServices
{
    public interface ILocalService
    {
        // Properties
        LoggedInContactInfo LoggedInContactInfo { get; set; }

        // Functions
        Task<bool> CheckInternetConnection();
        Task<bool> SetLoggedInContactInfo();
    }
    public class LocalService : ILocalService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public LoggedInContactInfo LoggedInContactInfo { get; set; } = null;

        private ICSSPCultureService CSSPCultureService { get; set; }
        private CSSPDBPreferenceContext dbPreference { get; set; }
        //private CSSPDBPreferenceInMemoryContext dbPreferenceIM { get; set; }
        #endregion Properties

        #region Constructors
        public LocalService(ICSSPCultureService CSSPCultureService, CSSPDBPreferenceContext dbPreference/*, CSSPDBPreferenceInMemoryContext dbPreferenceIM*/)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.dbPreference = dbPreference;
            //this.dbPreferenceIM = dbPreferenceIM;
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
        public async Task<bool> SetLoggedInContactInfo()
        {
            LoggedInContactInfo = new LoggedInContactInfo();

            //LoggedInContactInfo.LoggedInContact = (from c in dbPreferenceIM.Contacts
            //                                       select c).FirstOrDefault();

            //if (LoggedInContactInfo.LoggedInContact == null)
            //{
            LoggedInContactInfo.LoggedInContact = (from c in dbPreference.Contacts
                                                   select c).FirstOrDefault();

            if (LoggedInContactInfo.LoggedInContact == null)
            {
                LoggedInContactInfo.TVTypeUserAuthorizationList = new List<TVTypeUserAuthorization>();
                LoggedInContactInfo.TVItemUserAuthorizationList = new List<TVItemUserAuthorization>();
                //LoggedInContactInfo.PreferenceList = new List<Preference>();
            }
            else
            {
                //// doing LoggedInContacts
                //try
                //{
                //    dbPreferenceIM.Contacts.Add(LoggedInContactInfo.LoggedInContact);
                //    await dbPreferenceIM.SaveChangesAsync();
                //}
                //catch (Exception)
                //{
                //    // nothing yet
                //    return await Task.FromResult(false);
                //}

                // doing TVTypeUserAuthorizationList 
                LoggedInContactInfo.TVTypeUserAuthorizationList = (from c in dbPreference.TVTypeUserAuthorizations
                                                                   where c.ContactTVItemID == LoggedInContactInfo.LoggedInContact.ContactTVItemID
                                                                   select c).ToList();

                //if (LoggedInContactInfo.TVTypeUserAuthorizationList.Count > 0)
                //{
                //    try
                //    {
                //        dbPreferenceIM.TVTypeUserAuthorizations.AddRange(LoggedInContactInfo.TVTypeUserAuthorizationList);
                //        await dbPreferenceIM.SaveChangesAsync();
                //    }
                //    catch (Exception)
                //    {
                //        // nothing yet
                //        return await Task.FromResult(false);
                //    }
                //}

                // doing TVItemUserAuthorizationList 
                LoggedInContactInfo.TVItemUserAuthorizationList = (from c in dbPreference.TVItemUserAuthorizations
                                                                   where c.ContactTVItemID == LoggedInContactInfo.LoggedInContact.ContactTVItemID
                                                                   select c).ToList();

                //if (LoggedInContactInfo.TVItemUserAuthorizationList.Count > 0)
                //{
                //    try
                //    {
                //        dbPreferenceIM.TVItemUserAuthorizations.AddRange(LoggedInContactInfo.TVItemUserAuthorizationList);
                //        await dbPreferenceIM.SaveChangesAsync();
                //    }
                //    catch (Exception)
                //    {
                //        // nothing yet
                //        return await Task.FromResult(false);
                //    }
                //}
                //}
                //}
                //else
                //{
                //    LoggedInContactInfo.TVTypeUserAuthorizationList = (from c in dbPreferenceIM.TVTypeUserAuthorizations
                //                                                       where c.ContactTVItemID == LoggedInContactInfo.LoggedInContact.ContactTVItemID
                //                                                       select c).ToList();

                //    LoggedInContactInfo.TVItemUserAuthorizationList = (from c in dbPreferenceIM.TVItemUserAuthorizations
                //                                                       where c.ContactTVItemID == LoggedInContactInfo.LoggedInContact.ContactTVItemID
                //                                                       select c).ToList();

            }

            return await Task.FromResult(true);

        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
