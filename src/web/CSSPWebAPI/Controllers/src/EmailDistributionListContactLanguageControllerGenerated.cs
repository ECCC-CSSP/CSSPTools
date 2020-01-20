using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSSPWebAPI.Controllers
{
    [Route("api/emailDistributionListContactLanguage")]
    public partial class EmailDistributionListContactLanguageController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public EmailDistributionListContactLanguageController() : base()
        {
        }
        public EmailDistributionListContactLanguageController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/emailDistributionListContactLanguage
        [Route("")]
        public IActionResult GetEmailDistributionListContactLanguageList([FromQuery]string lang = "en", [FromQuery]int skip = 0, [FromQuery]int take = 200,
            [FromQuery]string asc = "", [FromQuery]string desc = "", [FromQuery]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                EmailDistributionListContactLanguageService emailDistributionListContactLanguageService = new EmailDistributionListContactLanguageService(new Query() { Lang = lang }, db, ContactID);

                emailDistributionListContactLanguageService.Query = emailDistributionListContactLanguageService.FillQuery(typeof(EmailDistributionListContactLanguage), lang, skip, take, asc, desc, where);

                 if (emailDistributionListContactLanguageService.Query.HasErrors)
                 {
                     return Ok(new List<EmailDistributionListContactLanguage>()
                     {
                         new EmailDistributionListContactLanguage()
                         {
                             HasErrors = emailDistributionListContactLanguageService.Query.HasErrors,
                             ValidationResults = emailDistributionListContactLanguageService.Query.ValidationResults,
                         },
                     }.ToList());
                 }
                 else
                 {
                     return Ok(emailDistributionListContactLanguageService.GetEmailDistributionListContactLanguageList().ToList());
                 }
            }
        }
        // GET api/emailDistributionListContactLanguage/1
        [Route("{EmailDistributionListContactLanguageID:int}")]
        public IActionResult GetEmailDistributionListContactLanguageWithID([FromQuery]int EmailDistributionListContactLanguageID, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                EmailDistributionListContactLanguageService emailDistributionListContactLanguageService = new EmailDistributionListContactLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                emailDistributionListContactLanguageService.Query = emailDistributionListContactLanguageService.FillQuery(typeof(EmailDistributionListContactLanguage), lang, 0, 1, "", "");

                EmailDistributionListContactLanguage emailDistributionListContactLanguage = new EmailDistributionListContactLanguage();
                emailDistributionListContactLanguage = emailDistributionListContactLanguageService.GetEmailDistributionListContactLanguageWithEmailDistributionListContactLanguageID(EmailDistributionListContactLanguageID);

                if (emailDistributionListContactLanguage == null)
                {
                    return NotFound();
                }

                return Ok(emailDistributionListContactLanguage);
            }
        }
        // POST api/emailDistributionListContactLanguage
        [Route("")]
        public IActionResult Post([FromBody]EmailDistributionListContactLanguage emailDistributionListContactLanguage, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                EmailDistributionListContactLanguageService emailDistributionListContactLanguageService = new EmailDistributionListContactLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!emailDistributionListContactLanguageService.Add(emailDistributionListContactLanguage))
                {
                    return BadRequest(String.Join("|||", emailDistributionListContactLanguage.ValidationResults));
                }
                else
                {
                    emailDistributionListContactLanguage.ValidationResults = null;
                    return Created<EmailDistributionListContactLanguage>(new Uri(Request.RequestUri, emailDistributionListContactLanguage.EmailDistributionListContactLanguageID.ToString()), emailDistributionListContactLanguage);
                }
            }
        }
        // PUT api/emailDistributionListContactLanguage
        [Route("")]
        public IActionResult Put([FromBody]EmailDistributionListContactLanguage emailDistributionListContactLanguage, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                EmailDistributionListContactLanguageService emailDistributionListContactLanguageService = new EmailDistributionListContactLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!emailDistributionListContactLanguageService.Update(emailDistributionListContactLanguage))
                {
                    return BadRequest(String.Join("|||", emailDistributionListContactLanguage.ValidationResults));
                }
                else
                {
                    emailDistributionListContactLanguage.ValidationResults = null;
                    return Ok(emailDistributionListContactLanguage);
                }
            }
        }
        // DELETE api/emailDistributionListContactLanguage
        [Route("")]
        public IActionResult Delete([FromBody]EmailDistributionListContactLanguage emailDistributionListContactLanguage, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                EmailDistributionListContactLanguageService emailDistributionListContactLanguageService = new EmailDistributionListContactLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!emailDistributionListContactLanguageService.Delete(emailDistributionListContactLanguage))
                {
                    return BadRequest(String.Join("|||", emailDistributionListContactLanguage.ValidationResults));
                }
                else
                {
                    emailDistributionListContactLanguage.ValidationResults = null;
                    return Ok(emailDistributionListContactLanguage);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
