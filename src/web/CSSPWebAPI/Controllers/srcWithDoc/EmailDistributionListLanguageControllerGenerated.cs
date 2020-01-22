using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSSPWebAPI.Controllers
{
    [Route("api/emailDistributionListLanguage")]
    public partial class EmailDistributionListLanguageController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public EmailDistributionListLanguageController() : base()
        {
        }
        public EmailDistributionListLanguageController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/emailDistributionListLanguage
        [Route("")]
        public IActionResult GetEmailDistributionListLanguageList([FromQuery]string lang = "en", [FromQuery]int skip = 0, [FromQuery]int take = 200,
            [FromQuery]string asc = "", [FromQuery]string desc = "", [FromQuery]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                EmailDistributionListLanguageService emailDistributionListLanguageService = new EmailDistributionListLanguageService(new Query() { Lang = lang }, db, ContactID);

                emailDistributionListLanguageService.Query = emailDistributionListLanguageService.FillQuery(typeof(EmailDistributionListLanguage), lang, skip, take, asc, desc, where);

                 if (emailDistributionListLanguageService.Query.HasErrors)
                 {
                     return Ok(new List<EmailDistributionListLanguage>()
                     {
                         new EmailDistributionListLanguage()
                         {
                             HasErrors = emailDistributionListLanguageService.Query.HasErrors,
                             ValidationResults = emailDistributionListLanguageService.Query.ValidationResults,
                         },
                     }.ToList());
                 }
                 else
                 {
                     return Ok(emailDistributionListLanguageService.GetEmailDistributionListLanguageList().ToList());
                 }
            }
        }
        // GET api/emailDistributionListLanguage/1
        [Route("{EmailDistributionListLanguageID:int}")]
        public IActionResult GetEmailDistributionListLanguageWithID([FromQuery]int EmailDistributionListLanguageID, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                EmailDistributionListLanguageService emailDistributionListLanguageService = new EmailDistributionListLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                emailDistributionListLanguageService.Query = emailDistributionListLanguageService.FillQuery(typeof(EmailDistributionListLanguage), lang, 0, 1, "", "");

                EmailDistributionListLanguage emailDistributionListLanguage = new EmailDistributionListLanguage();
                emailDistributionListLanguage = emailDistributionListLanguageService.GetEmailDistributionListLanguageWithEmailDistributionListLanguageID(EmailDistributionListLanguageID);

                if (emailDistributionListLanguage == null)
                {
                    return NotFound();
                }

                return Ok(emailDistributionListLanguage);
            }
        }
        // POST api/emailDistributionListLanguage
        [Route("")]
        public IActionResult Post([FromBody]EmailDistributionListLanguage emailDistributionListLanguage, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                EmailDistributionListLanguageService emailDistributionListLanguageService = new EmailDistributionListLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!emailDistributionListLanguageService.Add(emailDistributionListLanguage))
                {
                    return BadRequest(String.Join("|||", emailDistributionListLanguage.ValidationResults));
                }
                else
                {
                    emailDistributionListLanguage.ValidationResults = null;
                    return Created(Url.ToString(), emailDistributionListLanguage);
                }
            }
        }
        // PUT api/emailDistributionListLanguage
        [Route("")]
        public IActionResult Put([FromBody]EmailDistributionListLanguage emailDistributionListLanguage, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                EmailDistributionListLanguageService emailDistributionListLanguageService = new EmailDistributionListLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!emailDistributionListLanguageService.Update(emailDistributionListLanguage))
                {
                    return BadRequest(String.Join("|||", emailDistributionListLanguage.ValidationResults));
                }
                else
                {
                    emailDistributionListLanguage.ValidationResults = null;
                    return Ok(emailDistributionListLanguage);
                }
            }
        }
        // DELETE api/emailDistributionListLanguage
        [Route("")]
        public IActionResult Delete([FromBody]EmailDistributionListLanguage emailDistributionListLanguage, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                EmailDistributionListLanguageService emailDistributionListLanguageService = new EmailDistributionListLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!emailDistributionListLanguageService.Delete(emailDistributionListLanguage))
                {
                    return BadRequest(String.Join("|||", emailDistributionListLanguage.ValidationResults));
                }
                else
                {
                    emailDistributionListLanguage.ValidationResults = null;
                    return Ok(emailDistributionListLanguage);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
