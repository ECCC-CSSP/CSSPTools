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

namespace CSSPServices
{
    public interface ILoggedInService
    {
        LoggedInContactInfo LoggedInContactInfo { get; set; }
        DBLocationEnum DBLocation { get; set; }
        RunningOnEnum RunningOn { get; set; }

        Task<bool> SetLoggedInContactInfo(string Id);
    }
    public class LoggedInService : ILoggedInService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public  LoggedInContactInfo LoggedInContactInfo { get; set; }
        public DBLocationEnum DBLocation { get; set; }
        public RunningOnEnum RunningOn { get; set; } = RunningOnEnum.Local;

        private ICSSPCultureService CSSPCultureService { get; }
        private CSSPDBContext db { get; }
        private CSSPDBInMemoryContext dbIM { get; }
        #endregion Properties

        #region Constructors
        public LoggedInService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, CSSPDBContext db, CSSPDBInMemoryContext dbIM)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.db = db;
            this.dbIM = dbIM;

            LoggedInContactInfo = new LoggedInContactInfo();

            RunningOn = Configuration.GetValue<string>("RunningOn") == "Local" ? RunningOnEnum.Local : RunningOnEnum.Azure;
        }
        #endregion Constructors

        #region Functions public
        public async Task<bool> SetLoggedInContactInfo(string Id)
        {
            LoggedInContactInfo = new LoggedInContactInfo();

            LoggedInContactInfo.LoggedInContact = (from c in dbIM.Contacts
                                                   where c.Id == Id
                                                   select c).FirstOrDefault();

            if (LoggedInContactInfo.LoggedInContact == null)
            {
                LoggedInContactInfo.LoggedInContact = (from c in db.Contacts
                                                       where c.Id == Id
                                                       select c).FirstOrDefault();

                if (LoggedInContactInfo.LoggedInContact == null)
                {
                    LoggedInContactInfo.TVTypeUserAuthorizationList = new List<TVTypeUserAuthorization>();
                    LoggedInContactInfo.TVItemUserAuthorizationList = new List<TVItemUserAuthorization>();
                }
                else
                {
                    try
                    {
                        dbIM.Contacts.Add(LoggedInContactInfo.LoggedInContact);
                        await dbIM.SaveChangesAsync();
                    }
                    catch (Exception)
                    {
                        // nothing yet
                        return await Task.FromResult(false);
                    }

                    LoggedInContactInfo.TVTypeUserAuthorizationList = (from c in db.TVTypeUserAuthorizations
                                                                       where c.ContactTVItemID == LoggedInContactInfo.LoggedInContact.ContactTVItemID
                                                                       select c).ToList();

                    if (LoggedInContactInfo.TVTypeUserAuthorizationList.Count > 0)
                    {
                        try
                        {
                            dbIM.TVTypeUserAuthorizations.AddRange(LoggedInContactInfo.TVTypeUserAuthorizationList);
                            await dbIM.SaveChangesAsync();
                        }
                        catch (Exception)
                        {
                            // nothing yet
                            return await Task.FromResult(false);
                        }
                    }

                    LoggedInContactInfo.TVItemUserAuthorizationList = (from c in db.TVItemUserAuthorizations
                                                                       where c.ContactTVItemID == LoggedInContactInfo.LoggedInContact.ContactTVItemID
                                                                       select c).ToList();

                    if (LoggedInContactInfo.TVItemUserAuthorizationList.Count > 0)
                    {
                        try
                        {
                            dbIM.TVItemUserAuthorizations.AddRange(LoggedInContactInfo.TVItemUserAuthorizationList);
                            await dbIM.SaveChangesAsync();
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
                LoggedInContactInfo.TVTypeUserAuthorizationList = (from c in dbIM.TVTypeUserAuthorizations
                                                                   where c.ContactTVItemID == LoggedInContactInfo.LoggedInContact.ContactTVItemID
                                                                   select c).ToList();

                LoggedInContactInfo.TVItemUserAuthorizationList = (from c in dbIM.TVItemUserAuthorizations
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
