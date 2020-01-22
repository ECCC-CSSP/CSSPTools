using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSSPWebAPI.Controllers
{
    [Route("api/emailDistributionList")]
    public partial class EmailDistributionListController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public EmailDistributionListController() : base()
        {
        }
        public EmailDistributionListController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/emailDistributionList
        [Route("")]
        public IActionResult GetEmailDistributionListList([FromQuery]string lang = "en", [FromQuery]int skip = 0, [FromQuery]int take = 200,
            [FromQuery]string asc = "", [FromQuery]string desc = "", [FromQuery]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                EmailDistributionListService emailDistributionListService = new EmailDistributionListService(new Query() { Lang = lang }, db, ContactID);

                emailDistributionListService.Query = emailDistributionListService.FillQuery(typeof(EmailDistributionList), lang, skip, take, asc, desc, where);

                 if (emailDistributionListService.Query.HasErrors)
                 {
                     return Ok(new List<EmailDistributionList>()
                     {
                         new EmailDistributionList()
                         {
                             HasErrors = emailDistributionListService.Query.HasErrors,
                             ValidationResults = emailDistributionListService.Query.ValidationResults,
                         },
                     }.ToList());
                 }
                 else
                 {
                     return Ok(emailDistributionListService.GetEmailDistributionListList().ToList());
                 }
            }
        }
        // GET api/emailDistributionList/1
        [Route("{EmailDistributionListID:int}")]
        public IActionResult GetEmailDistributionListWithID([FromQuery]int EmailDistributionListID, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                EmailDistributionListService emailDistributionListService = new EmailDistributionListService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                emailDistributionListService.Query = emailDistributionListService.FillQuery(typeof(EmailDistributionList), lang, 0, 1, "", "");

                EmailDistributionList emailDistributionList = new EmailDistributionList();
                emailDistributionList = emailDistributionListService.GetEmailDistributionListWithEmailDistributionListID(EmailDistributionListID);

                if (emailDistributionList == null)
                {
                    return NotFound();
                }

                return Ok(emailDistributionList);
            }
        }
        // POST api/emailDistributionList
        [Route("")]
        public IActionResult Post([FromBody]EmailDistributionList emailDistributionList, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                EmailDistributionListService emailDistributionListService = new EmailDistributionListService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!emailDistributionListService.Add(emailDistributionList))
                {
                    return BadRequest(String.Join("|||", emailDistributionList.ValidationResults));
                }
                else
                {
                    emailDistributionList.ValidationResults = null;
                    return Created(Url.ToString(), emailDistributionList);
                }
            }
        }
        // PUT api/emailDistributionList
        [Route("")]
        public IActionResult Put([FromBody]EmailDistributionList emailDistributionList, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                EmailDistributionListService emailDistributionListService = new EmailDistributionListService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!emailDistributionListService.Update(emailDistributionList))
                {
                    return BadRequest(String.Join("|||", emailDistributionList.ValidationResults));
                }
                else
                {
                    emailDistributionList.ValidationResults = null;
                    return Ok(emailDistributionList);
                }
            }
        }
        // DELETE api/emailDistributionList
        [Route("")]
        public IActionResult Delete([FromBody]EmailDistributionList emailDistributionList, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                EmailDistributionListService emailDistributionListService = new EmailDistributionListService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!emailDistributionListService.Delete(emailDistributionList))
                {
                    return BadRequest(String.Join("|||", emailDistributionList.ValidationResults));
                }
                else
                {
                    emailDistributionList.ValidationResults = null;
                    return Ok(emailDistributionList);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
