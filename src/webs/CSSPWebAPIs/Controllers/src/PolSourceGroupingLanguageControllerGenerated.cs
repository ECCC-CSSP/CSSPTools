using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CSSPWebAPI.Controllers
{
    [RoutePrefix("api/polSourceGroupingLanguage")]
    public partial class PolSourceGroupingLanguageController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public PolSourceGroupingLanguageController() : base()
        {
        }
        public PolSourceGroupingLanguageController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/polSourceGroupingLanguage
        [Route("")]
        public IHttpActionResult GetPolSourceGroupingLanguageList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                PolSourceGroupingLanguageService polSourceGroupingLanguageService = new PolSourceGroupingLanguageService(new Query() { Lang = lang }, db, ContactID);

                else // QueryString has no parameter [extra] or extra is empty
                {
                   polSourceGroupingLanguageService.Query = polSourceGroupingLanguageService.FillQuery(typeof(PolSourceGroupingLanguage), lang, skip, take, asc, desc, where, extra);

                    if (polSourceGroupingLanguageService.Query.HasErrors)
                    {
                        return Ok(new List<PolSourceGroupingLanguage>()
                        {
                            new PolSourceGroupingLanguage()
                            {
                                HasErrors = polSourceGroupingLanguageService.Query.HasErrors,
                                ValidationResults = polSourceGroupingLanguageService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(polSourceGroupingLanguageService.GetPolSourceGroupingLanguageList().ToList());
                    }
                }
            }
        }
        // GET api/polSourceGroupingLanguage/1
        [Route("{PolSourceGroupingLanguageID:int}")]
        public IHttpActionResult GetPolSourceGroupingLanguageWithID([FromUri]int PolSourceGroupingLanguageID, [FromUri]string lang = "en", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                PolSourceGroupingLanguageService polSourceGroupingLanguageService = new PolSourceGroupingLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                polSourceGroupingLanguageService.Query = polSourceGroupingLanguageService.FillQuery(typeof(PolSourceGroupingLanguage), lang, 0, 1, "", "", extra);

                else
                {
                    PolSourceGroupingLanguage polSourceGroupingLanguage = new PolSourceGroupingLanguage();
                    polSourceGroupingLanguage = polSourceGroupingLanguageService.GetPolSourceGroupingLanguageWithPolSourceGroupingLanguageID(PolSourceGroupingLanguageID);

                    if (polSourceGroupingLanguage == null)
                    {
                        return NotFound();
                    }

                    return Ok(polSourceGroupingLanguage);
                }
            }
        }
        // POST api/polSourceGroupingLanguage
        [Route("")]
        public IHttpActionResult Post([FromBody]PolSourceGroupingLanguage polSourceGroupingLanguage, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                PolSourceGroupingLanguageService polSourceGroupingLanguageService = new PolSourceGroupingLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!polSourceGroupingLanguageService.Add(polSourceGroupingLanguage))
                {
                    return BadRequest(String.Join("|||", polSourceGroupingLanguage.ValidationResults));
                }
                else
                {
                    polSourceGroupingLanguage.ValidationResults = null;
                    return Created<PolSourceGroupingLanguage>(new Uri(Request.RequestUri, polSourceGroupingLanguage.PolSourceGroupingLanguageID.ToString()), polSourceGroupingLanguage);
                }
            }
        }
        // PUT api/polSourceGroupingLanguage
        [Route("")]
        public IHttpActionResult Put([FromBody]PolSourceGroupingLanguage polSourceGroupingLanguage, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                PolSourceGroupingLanguageService polSourceGroupingLanguageService = new PolSourceGroupingLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!polSourceGroupingLanguageService.Update(polSourceGroupingLanguage))
                {
                    return BadRequest(String.Join("|||", polSourceGroupingLanguage.ValidationResults));
                }
                else
                {
                    polSourceGroupingLanguage.ValidationResults = null;
                    return Ok(polSourceGroupingLanguage);
                }
            }
        }
        // DELETE api/polSourceGroupingLanguage
        [Route("")]
        public IHttpActionResult Delete([FromBody]PolSourceGroupingLanguage polSourceGroupingLanguage, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                PolSourceGroupingLanguageService polSourceGroupingLanguageService = new PolSourceGroupingLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!polSourceGroupingLanguageService.Delete(polSourceGroupingLanguage))
                {
                    return BadRequest(String.Join("|||", polSourceGroupingLanguage.ValidationResults));
                }
                else
                {
                    polSourceGroupingLanguage.ValidationResults = null;
                    return Ok(polSourceGroupingLanguage);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
