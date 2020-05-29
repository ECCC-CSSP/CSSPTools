using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CSSPWebAPI.Controllers
{
    [RoutePrefix("api/drogueRun")]
    public partial class DrogueRunController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public DrogueRunController() : base()
        {
        }
        public DrogueRunController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/drogueRun
        [Route("")]
        public IHttpActionResult GetDrogueRunList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                DrogueRunService drogueRunService = new DrogueRunService(new Query() { Lang = lang }, db, ContactID);

                else // QueryString has no parameter [extra] or extra is empty
                {
                   drogueRunService.Query = drogueRunService.FillQuery(typeof(DrogueRun), lang, skip, take, asc, desc, where, extra);

                    if (drogueRunService.Query.HasErrors)
                    {
                        return Ok(new List<DrogueRun>()
                        {
                            new DrogueRun()
                            {
                                HasErrors = drogueRunService.Query.HasErrors,
                                ValidationResults = drogueRunService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(drogueRunService.GetDrogueRunList().ToList());
                    }
                }
            }
        }
        // GET api/drogueRun/1
        [Route("{DrogueRunID:int}")]
        public IHttpActionResult GetDrogueRunWithID([FromUri]int DrogueRunID, [FromUri]string lang = "en", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                DrogueRunService drogueRunService = new DrogueRunService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                drogueRunService.Query = drogueRunService.FillQuery(typeof(DrogueRun), lang, 0, 1, "", "", extra);

                else
                {
                    DrogueRun drogueRun = new DrogueRun();
                    drogueRun = drogueRunService.GetDrogueRunWithDrogueRunID(DrogueRunID);

                    if (drogueRun == null)
                    {
                        return NotFound();
                    }

                    return Ok(drogueRun);
                }
            }
        }
        // POST api/drogueRun
        [Route("")]
        public IHttpActionResult Post([FromBody]DrogueRun drogueRun, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                DrogueRunService drogueRunService = new DrogueRunService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!drogueRunService.Add(drogueRun))
                {
                    return BadRequest(String.Join("|||", drogueRun.ValidationResults));
                }
                else
                {
                    drogueRun.ValidationResults = null;
                    return Created<DrogueRun>(new Uri(Request.RequestUri, drogueRun.DrogueRunID.ToString()), drogueRun);
                }
            }
        }
        // PUT api/drogueRun
        [Route("")]
        public IHttpActionResult Put([FromBody]DrogueRun drogueRun, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                DrogueRunService drogueRunService = new DrogueRunService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!drogueRunService.Update(drogueRun))
                {
                    return BadRequest(String.Join("|||", drogueRun.ValidationResults));
                }
                else
                {
                    drogueRun.ValidationResults = null;
                    return Ok(drogueRun);
                }
            }
        }
        // DELETE api/drogueRun
        [Route("")]
        public IHttpActionResult Delete([FromBody]DrogueRun drogueRun, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                DrogueRunService drogueRunService = new DrogueRunService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!drogueRunService.Delete(drogueRun))
                {
                    return BadRequest(String.Join("|||", drogueRun.ValidationResults));
                }
                else
                {
                    drogueRun.ValidationResults = null;
                    return Ok(drogueRun);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
