using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSSPWebAPI.Controllers
{
    [Route("api/helpDoc")]
    public partial class HelpDocController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public HelpDocController() : base()
        {
        }
        public HelpDocController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/helpDoc
        [Route("")]
        public IActionResult GetHelpDocList([FromQuery]string lang = "en", [FromQuery]int skip = 0, [FromQuery]int take = 200,
            [FromQuery]string asc = "", [FromQuery]string desc = "", [FromQuery]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                HelpDocService helpDocService = new HelpDocService(new Query() { Lang = lang }, db, ContactID);

                helpDocService.Query = helpDocService.FillQuery(typeof(HelpDoc), lang, skip, take, asc, desc, where);

                 if (helpDocService.Query.HasErrors)
                 {
                     return Ok(new List<HelpDoc>()
                     {
                         new HelpDoc()
                         {
                             HasErrors = helpDocService.Query.HasErrors,
                             ValidationResults = helpDocService.Query.ValidationResults,
                         },
                     }.ToList());
                 }
                 else
                 {
                     return Ok(helpDocService.GetHelpDocList().ToList());
                 }
            }
        }
        // GET api/helpDoc/1
        [Route("{HelpDocID:int}")]
        public IActionResult GetHelpDocWithID([FromQuery]int HelpDocID, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                HelpDocService helpDocService = new HelpDocService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                helpDocService.Query = helpDocService.FillQuery(typeof(HelpDoc), lang, 0, 1, "", "");

                HelpDoc helpDoc = new HelpDoc();
                helpDoc = helpDocService.GetHelpDocWithHelpDocID(HelpDocID);

                if (helpDoc == null)
                {
                    return NotFound();
                }

                return Ok(helpDoc);
            }
        }
        // POST api/helpDoc
        [Route("")]
        public IActionResult Post([FromBody]HelpDoc helpDoc, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                HelpDocService helpDocService = new HelpDocService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!helpDocService.Add(helpDoc))
                {
                    return BadRequest(String.Join("|||", helpDoc.ValidationResults));
                }
                else
                {
                    helpDoc.ValidationResults = null;
                    return Created(Url.ToString(), helpDoc);
                }
            }
        }
        // PUT api/helpDoc
        [Route("")]
        public IActionResult Put([FromBody]HelpDoc helpDoc, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                HelpDocService helpDocService = new HelpDocService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!helpDocService.Update(helpDoc))
                {
                    return BadRequest(String.Join("|||", helpDoc.ValidationResults));
                }
                else
                {
                    helpDoc.ValidationResults = null;
                    return Ok(helpDoc);
                }
            }
        }
        // DELETE api/helpDoc
        [Route("")]
        public IActionResult Delete([FromBody]HelpDoc helpDoc, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                HelpDocService helpDocService = new HelpDocService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!helpDocService.Delete(helpDoc))
                {
                    return BadRequest(String.Join("|||", helpDoc.ValidationResults));
                }
                else
                {
                    helpDoc.ValidationResults = null;
                    return Ok(helpDoc);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
