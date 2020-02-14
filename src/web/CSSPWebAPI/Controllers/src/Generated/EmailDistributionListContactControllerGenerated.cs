/*
 * Auto generated from the CSSPCodeWriter.proj by clicking on the [[ModelClassName]ControllerGenerated.cs] button
 *
 * Do not edit this file.
 *
 */ 

using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using CSSPWebAPI.Controllers.Resources;

namespace CSSPWebAPI.Controllers
{
    [Route("api/[controller]")]
    public partial class EmailDistributionListContactController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public EmailDistributionListContactController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/emailDistributionListContact
        [HttpGet]
        public IActionResult GetEmailDistributionListContactList(string lang = "en", int skip = 0, int take = 200,
            string asc = "", string desc = "", string where = "")
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
        [HttpGet("{EmailDistributionListContactID}")]
        public IActionResult GetEmailDistributionListContactWithID(int EmailDistributionListContactID, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                EmailDistributionListContactService emailDistributionListContactService = new EmailDistributionListContactService(new Query() { Lang = lang }, db, ContactID);

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
        [HttpPost]
        public IActionResult Post(EmailDistributionListContact emailDistributionListContact, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                EmailDistributionListContactService emailDistributionListContactService = new EmailDistributionListContactService(new Query() { Lang = lang }, db, ContactID);

                if (!emailDistributionListContactService.Add(emailDistributionListContact))
                {
                    return BadRequest(String.Join("|||", emailDistributionListContact.ValidationResults));
                }
                else
                {
                    emailDistributionListContact.ValidationResults = null;
                    return Created("/api/emailDistributionListContact/" + emailDistributionListContact.EmailDistributionListContactID, emailDistributionListContact);
                }
            }
        }
        // PUT api/emailDistributionListContact
        [HttpPut]
        public IActionResult Put(EmailDistributionListContact emailDistributionListContact, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                EmailDistributionListContactService emailDistributionListContactService = new EmailDistributionListContactService(new Query() { Lang = lang }, db, ContactID);

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
        [HttpDelete]
        public IActionResult Delete(EmailDistributionListContact emailDistributionListContact, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                EmailDistributionListContactService emailDistributionListContactService = new EmailDistributionListContactService(new Query() { Lang = lang }, db, ContactID);

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
