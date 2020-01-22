using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;


namespace CSSPWebAPI.Controllers
{
    public class BaseController : ControllerBase
    {
        #region Variables
        #endregion Variables

        #region Properties
        public List<LanguageEnum> AllowableLanguages { get; private set; } = new List<LanguageEnum>() { LanguageEnum.en, LanguageEnum.fr };
        public int ContactID { get; private set; } = 0;
        public LanguageEnum LanguageRequest { get; set; } = LanguageEnum.en;
        public DatabaseTypeEnum DatabaseType { get; private set; } = DatabaseTypeEnum.SqlServerTestDB;
        #endregion Properties

        #region Constructors
        public BaseController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB)
        {
            DatabaseType = dbt;

            if (!string.IsNullOrWhiteSpace(User.Identity.Name))
            {
                if (User.Identity.IsAuthenticated)
                {
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        ContactService contactService = new ContactService(new Query(), db, 1);
                        Contact contact = (from c in db.Contacts select c).Where(c => c.LoginEmail == User.Identity.Name).FirstOrDefault();

                        if (contact != null)
                        {
                            ContactID = contact.ContactID;
                        }
                    }
                }
            }
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        #endregion Functions private

    }
}
