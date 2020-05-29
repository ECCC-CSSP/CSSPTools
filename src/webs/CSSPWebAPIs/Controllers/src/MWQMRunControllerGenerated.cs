using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CSSPWebAPI.Controllers
{
    [RoutePrefix("api/mwqmRun")]
    public partial class MWQMRunController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MWQMRunController() : base()
        {
        }
        public MWQMRunController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/mwqmRun
        [Route("")]
        public IHttpActionResult GetMWQMRunList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMRunService mwqmRunService = new MWQMRunService(new Query() { Lang = lang }, db, ContactID);

                else // QueryString has no parameter [extra] or extra is empty
                {
                   mwqmRunService.Query = mwqmRunService.FillQuery(typeof(MWQMRun), lang, skip, take, asc, desc, where, extra);

                    if (mwqmRunService.Query.HasErrors)
                    {
                        return Ok(new List<MWQMRun>()
                        {
                            new MWQMRun()
                            {
                                HasErrors = mwqmRunService.Query.HasErrors,
                                ValidationResults = mwqmRunService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(mwqmRunService.GetMWQMRunList().ToList());
                    }
                }
            }
        }
        // GET api/mwqmRun/1
        [Route("{MWQMRunID:int}")]
        public IHttpActionResult GetMWQMRunWithID([FromUri]int MWQMRunID, [FromUri]string lang = "en", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMRunService mwqmRunService = new MWQMRunService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                mwqmRunService.Query = mwqmRunService.FillQuery(typeof(MWQMRun), lang, 0, 1, "", "", extra);

                else
                {
                    MWQMRun mwqmRun = new MWQMRun();
                    mwqmRun = mwqmRunService.GetMWQMRunWithMWQMRunID(MWQMRunID);

                    if (mwqmRun == null)
                    {
                        return NotFound();
                    }

                    return Ok(mwqmRun);
                }
            }
        }
        // POST api/mwqmRun
        [Route("")]
        public IHttpActionResult Post([FromBody]MWQMRun mwqmRun, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMRunService mwqmRunService = new MWQMRunService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!mwqmRunService.Add(mwqmRun))
                {
                    return BadRequest(String.Join("|||", mwqmRun.ValidationResults));
                }
                else
                {
                    mwqmRun.ValidationResults = null;
                    return Created<MWQMRun>(new Uri(Request.RequestUri, mwqmRun.MWQMRunID.ToString()), mwqmRun);
                }
            }
        }
        // PUT api/mwqmRun
        [Route("")]
        public IHttpActionResult Put([FromBody]MWQMRun mwqmRun, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMRunService mwqmRunService = new MWQMRunService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!mwqmRunService.Update(mwqmRun))
                {
                    return BadRequest(String.Join("|||", mwqmRun.ValidationResults));
                }
                else
                {
                    mwqmRun.ValidationResults = null;
                    return Ok(mwqmRun);
                }
            }
        }
        // DELETE api/mwqmRun
        [Route("")]
        public IHttpActionResult Delete([FromBody]MWQMRun mwqmRun, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMRunService mwqmRunService = new MWQMRunService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!mwqmRunService.Delete(mwqmRun))
                {
                    return BadRequest(String.Join("|||", mwqmRun.ValidationResults));
                }
                else
                {
                    mwqmRun.ValidationResults = null;
                    return Ok(mwqmRun);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
