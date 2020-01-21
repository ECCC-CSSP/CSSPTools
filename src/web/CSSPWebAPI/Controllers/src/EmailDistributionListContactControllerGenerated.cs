using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSSPWebAPI.Controllers
{
    [Route("api/emailDistributionListContact")]
    public partial class EmailDistributionListContactController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public EmailDistributionListContactController() : base()
        {
        }
        public EmailDistributionListContactController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/emailDistributionListContact
        [Route("")]
        public IActionResult GetEmailDistributionListContactList([FromQuery]string lang = "en", [FromQuery]int skip = 0, [FromQuery]int take = 200,
            [FromQuery]string asc = "", [FromQuery]string desc = "", [FromQuery]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                EmailDistributionListContactService emailDistributionListContactService = new EmailDistributionListContactService(new Query() { Lang = lang }, db, ContactID);

                emailDistributionListContactService.Query = emailDistributionListContactService.FillQuery(typeof(EmailDistributionListContact), lang, skip, take, asc, desc, where);

                 if (emailDistributionListContactService.Query.HasErrors)
                 {
                     return Ok(new List<EmailDistributionListContact>()
                     {
                         new EmailDistributionListContact()
                         {
                             HasErrors = emailDistributionListContactService.Query.HasErrors,
                             ValidationResults = emailDistributionListContactService.Query.ValidationResults,
                         },
                     }.ToList());
                 }
                 else
                 {
                     return Ok(emailDistributionListContactService.GetEmailDistributionListContactList().ToList());
                 }
            }
        }
        // GET api/emailDistributionListContact/1
        [Route("{EmailDistributionListContactID:int}")]
        public IActionResult GetEmailDistributionListContactWithID([FromQuery]int EmailDistributionListContactID, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                EmailDistributionListContactService emailDistributionListContactService = new EmailDistributionListContactService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                emailDistributionListContactService.Query = emailDistributionListContactService.FillQuery(typeof(EmailDistributionListContact), lang, 0, 1, "", "");

                EmailDistributionListContact emailDistributionListContact = new EmailDistributionListContact();
                emailDistributionListContact = emailDistributionListContactService.GetEmailDistributionListContactWithEmailDistributionListContactID(EmailDistributionListContactID);

                if (emailDistributionListContact == null)
                {
                    return NotFound();
                }

                return Ok(emailDistributionListContact);
            }
        }
        // POST api/emailDistributionListContact
        [Route("")]
        public IActionResult Post([FromBody]EmailDistributionListContact emailDistributionListContact, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                EmailDistributionListContactService emailDistributionListContactService = new EmailDistributionListContactService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!emailDistributionListContactService.Add(emailDistributionListContact))
                {
                    return BadRequest(String.Join("|||", emailDistributionListContact.ValidationResults));
                }
                else
                {
                    emailDistributionListContact.ValidationResults = null;
                    return Created(Url.ToString(), emailDistributionListContact);
                }
            }
        }
        // PUT api/emailDistributionListContact
        [Route("")]
        public IActionResult Put([FromBody]EmailDistributionListContact emailDistributionListContact, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                EmailDistributionListContactService emailDistributionListContactService = new EmailDistributionListContactService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!emailDistributionListContactService.Update(emailDistributionListContact))
                {
                    return BadRequest(String.Join("|||", emailDistributionListContact.ValidationResults));
                }
                else
                {
                    emailDistributionListContact.ValidationResults = null;
                    return Ok(emailDistributionListContact);
                }
            }
        }
        // DELETE api/emailDistributionListContact
        [Route("")]
        public IActionResult Delete([FromBody]EmailDistributionListContact emailDistributionListContact, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                EmailDistributionListContactService emailDistributionListContactService = new EmailDistributionListContactService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!emailDistributionListContactService.Delete(emailDistributionListContact))
                {
                    return BadRequest(String.Join("|||", emailDistributionListContact.ValidationResults));
                }
                else
                {
                    emailDistributionListContact.ValidationResults = null;
                    return Ok(emailDistributionListContact);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
