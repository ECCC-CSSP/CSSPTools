﻿using CSSPCultureServices.Services;
using CSSPDBModels;
using CSSPHelperModels;
using CSSPScrambleServices;
using ManageServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggedInServices
{
    public interface ILoggedInService
    {
        LoggedInContactInfo LoggedInContactInfo { get; set; }
        Task<bool> SetLoggedInContactInfo(string LoginEmail);
        Task<bool> SetLoggedInLocalContactInfo();
    }
    public class LoggedInService : ILoggedInService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public LoggedInContactInfo LoggedInContactInfo { get; set; }

        private ICSSPCultureService CSSPCultureService { get; }
        private CSSPDBContext db { get; }
        private CSSPDBManageContext dbManage { get; }
        private IScrambleService ScrambleService { get; }
        #endregion Properties

        #region Constructors
        public LoggedInService(ICSSPCultureService CSSPCultureService, IScrambleService ScrambleService, CSSPDBContext db = null, CSSPDBManageContext dbManage = null)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.ScrambleService = ScrambleService;
            this.db = db;
            this.dbManage = dbManage;
            this.LoggedInContactInfo = new LoggedInContactInfo();
        }
        #endregion Constructors

        #region Functions public
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
