using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSSPWebAPI.Controllers
{
    [Route("api/docTemplate")]
    public partial class DocTemplateController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public DocTemplateController() : base()
        {
        }
        public DocTemplateController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/docTemplate
        [Route("")]
        public IActionResult GetDocTemplateList([FromQuery]string lang = "en", [FromQuery]int skip = 0, [FromQuery]int take = 200,
            [FromQuery]string asc = "", [FromQuery]string desc = "", [FromQuery]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                DocTemplateService docTemplateService = new DocTemplateService(new Query() { Lang = lang }, db, ContactID);

                docTemplateService.Query = docTemplateService.FillQuery(typeof(DocTemplate), lang, skip, take, asc, desc, where);

                 if (docTemplateService.Query.HasErrors)
                 {
                     return Ok(new List<DocTemplate>()
                     {
                         new DocTemplate()
                         {
                             HasErrors = docTemplateService.Query.HasErrors,
                             ValidationResults = docTemplateService.Query.ValidationResults,
                         },
                     }.ToList());
                 }
                 else
                 {
                     return Ok(docTemplateService.GetDocTemplateList().ToList());
                 }
            }
        }
        // GET api/docTemplate/1
        [Route("{DocTemplateID:int}")]
        public IActionResult GetDocTemplateWithID([FromQuery]int DocTemplateID, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                DocTemplateService docTemplateService = new DocTemplateService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                docTemplateService.Query = docTemplateService.FillQuery(typeof(DocTemplate), lang, 0, 1, "", "");

                DocTemplate docTemplate = new DocTemplate();
                docTemplate = docTemplateService.GetDocTemplateWithDocTemplateID(DocTemplateID);

                if (docTemplate == null)
                {
                    return NotFound();
                }

                return Ok(docTemplate);
            }
        }
        // POST api/docTemplate
        [Route("")]
        public IActionResult Post([FromBody]DocTemplate docTemplate, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                DocTemplateService docTemplateService = new DocTemplateService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!docTemplateService.Add(docTemplate))
                {
                    return BadRequest(String.Join("|||", docTemplate.ValidationResults));
                }
                else
                {
                    docTemplate.ValidationResults = null;
                    return Created(Url.ToString(), docTemplate);
                }
            }
        }
        // PUT api/docTemplate
        [Route("")]
        public IActionResult Put([FromBody]DocTemplate docTemplate, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                DocTemplateService docTemplateService = new DocTemplateService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!docTemplateService.Update(docTemplate))
                {
                    return BadRequest(String.Join("|||", docTemplate.ValidationResults));
                }
                else
                {
                    docTemplate.ValidationResults = null;
                    return Ok(docTemplate);
                }
            }
        }
        // DELETE api/docTemplate
        [Route("")]
        public IActionResult Delete([FromBody]DocTemplate docTemplate, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                DocTemplateService docTemplateService = new DocTemplateService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!docTemplateService.Delete(docTemplate))
                {
                    return BadRequest(String.Join("|||", docTemplate.ValidationResults));
                }
                else
                {
                    docTemplate.ValidationResults = null;
                    return Ok(docTemplate);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
