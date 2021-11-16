using CSSPCultureServices.Resources;
using CSSPCultureServices.Services;
using CSSPDBModels;
using CSSPHelperModels;
using ManageServices;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggedInServices
{
    public interface ILoggedInService
    {
        // properties
        LoggedInContactInfo LoggedInContactInfo { get; set; }

        // functions
        string Descramble(string Text);
        string Scramble(string Text);
        Task<bool> SetLoggedInContactInfo(string LoginEmail);
        Task<bool> SetLoggedInLocalContactInfo();

    }
    public partial class LoggedInService : ILoggedInService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public LoggedInContactInfo LoggedInContactInfo { get; set; }

        private IConfiguration Configuration { get; }
        private CSSPDBContext db { get; }
        private CSSPDBManageContext dbManage { get; }
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
        #endregion Properties

        #region Constructors
        public LoggedInService(IConfiguration Configuration, CSSPDBContext db = null, CSSPDBManageContext dbManage = null)
        {
            if (Configuration == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "Configuration") }");
            if (db == null && dbManage == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "db && dbManage") }");

            if (string.IsNullOrEmpty(Configuration["CSSPDB"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDB", "LoggedInService") }");
            if (string.IsNullOrEmpty(Configuration["CSSPDBManage"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDBManage", "LoggedInService") }");

            this.Configuration = Configuration;
            this.db = db;
            this.dbManage = dbManage;
            
            LoggedInContactInfo = new LoggedInContactInfo();
        }
        #endregion Constructors

        #region Functions public
        public string Descramble(string Text)
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

            return retStr;
        }
        public string Scramble(string Text)
        {

            if (string.IsNullOrWhiteSpace(Text)) return "";

            Random r = new Random();
            int Start = r.Next(1, 9);

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

            return retStr2;
        }
        public async Task<bool> SetLoggedInContactInfo(string LoginEmail)
        {
            LoggedInContactInfo.LoggedInContact = (from c in db.Contacts
                                                   where c.LoginEmail == LoginEmail
                                                   select c).FirstOrDefault();

            if (LoggedInContactInfo.LoggedInContact == null)
            {
                LoggedInContactInfo.TVTypeUserAuthorizationList = new List<TVTypeUserAuthorization>();
                LoggedInContactInfo.TVItemUserAuthorizationList = new List<TVItemUserAuthorization>();
            }
            else
            {
                LoggedInContactInfo.TVTypeUserAuthorizationList = (from c in db.TVTypeUserAuthorizations
                                                                   where c.ContactTVItemID == LoggedInContactInfo.LoggedInContact.ContactTVItemID
                                                                   select c).ToList();

                LoggedInContactInfo.TVItemUserAuthorizationList = (from c in db.TVItemUserAuthorizations
                                                                   where c.ContactTVItemID == LoggedInContactInfo.LoggedInContact.ContactTVItemID
                                                                   select c).ToList();
            }

            return await Task.FromResult(true);
        }
        public async Task<bool> SetLoggedInLocalContactInfo()
        {
            LoggedInContactInfo = new LoggedInContactInfo();

            LoggedInContactInfo.LoggedInContact = (from c in dbManage.Contacts
                                                   orderby c.LoginEmail
                                                   select c).FirstOrDefault();

            if (LoggedInContactInfo.LoggedInContact == null)
            {
                LoggedInContactInfo.TVTypeUserAuthorizationList = new List<TVTypeUserAuthorization>();
                LoggedInContactInfo.TVItemUserAuthorizationList = new List<TVItemUserAuthorization>();
            }
            else
            {
                LoggedInContactInfo.TVTypeUserAuthorizationList = (from c in dbManage.TVTypeUserAuthorizations
                                                                   where c.ContactTVItemID == LoggedInContactInfo.LoggedInContact.ContactTVItemID
                                                                   select c).ToList();

                LoggedInContactInfo.TVItemUserAuthorizationList = (from c in dbManage.TVItemUserAuthorizations
                                                                   where c.ContactTVItemID == LoggedInContactInfo.LoggedInContact.ContactTVItemID
                                                                   select c).ToList();
            }


            return await Task.FromResult(true);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
