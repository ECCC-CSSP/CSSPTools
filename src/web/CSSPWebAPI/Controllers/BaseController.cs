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
        }
        #endregion Constructors

        #region Functions override
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            if (!string.IsNullOrWhiteSpace(controllerContext.RequestContext.Principal.Identity.Name))
            {
                if (controllerContext.RequestContext.Principal.Identity.IsAuthenticated)
                {
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        ContactService contactService = new ContactService(new Query(), db, 1);
                        Contact contact = (from c in db.Contacts select c).Where(c => c.LoginEmail == controllerContext.RequestContext.Principal.Identity.Name).FirstOrDefault();

                        if (contact != null)
                        {
                            ContactID = contact.ContactID;
                        }
                    }
                }
            }

            base.Initialize(controllerContext);
        }
        #endregion Functions override

        #region Functions public

        #endregion Functions public

        #region Functions private
        #endregion Functions private

    }
}
