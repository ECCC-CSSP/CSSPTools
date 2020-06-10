using CSSPModels;
using CultureServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggedInServices.Services
{
    public class LoggedInService : ILoggedInService
    {
        #region Variables
        private string _ID;
        private Contact _Contact;
        private List<TVItemUserAuthorization> _TVItemUserAuthorizationList;
        private List<TVTypeUserAuthorization> _TVTypeUserAuthorizationList;

        #endregion Variables

        #region Properties
        private ICultureService CultureService { get; }
        private CSSPDBContext db { get; }
        #endregion Properties

        #region Constructors
        public LoggedInService(ICultureService cultureService, CSSPDBContext db)
        {
            CultureService = cultureService;
            this.db = db;
        }
        #endregion Constructors

        #region Functions public
        public async Task<string> GetID()
        {
            return await Task.FromResult(_ID);
        }
        public async Task SetID(string value)
        {
            _ID = value;
            _Contact = (from c in db.Contacts
                        where c.Id == _ID
                        select c).FirstOrDefault();

            _TVItemUserAuthorizationList = (from c in db.TVItemUserAuthorizations
                                            where c.ContactTVItemID == _Contact.ContactTVItemID
                                            select c).ToList();

            _TVTypeUserAuthorizationList = (from c in db.TVTypeUserAuthorizations
                                            where c.ContactTVItemID == _Contact.ContactTVItemID
                                            select c).ToList();

        }
        public async Task<Contact> GetContact()
        {
            return await Task.FromResult(_Contact);
        }
        public async Task<List<TVItemUserAuthorization>> GetTVItemUserAuthorizationList()
        {
            return await Task.FromResult(_TVItemUserAuthorizationList);
        }
        public async Task<List<TVTypeUserAuthorization>> GetTVTypeUserAuthorizationList()
        {
            return await Task.FromResult(_TVTypeUserAuthorizationList);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
