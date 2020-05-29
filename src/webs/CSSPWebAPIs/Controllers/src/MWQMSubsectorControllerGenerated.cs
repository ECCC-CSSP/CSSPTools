using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CSSPWebAPI.Controllers
{
    [RoutePrefix("api/mwqmSubsector")]
    public partial class MWQMSubsectorController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MWQMSubsectorController() : base()
        {
        }
        public MWQMSubsectorController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/mwqmSubsector
        [Route("")]
        public IHttpActionResult GetMWQMSubsectorList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMSubsectorService mwqmSubsectorService = new MWQMSubsectorService(new Query() { Lang = lang }, db, ContactID);

                else // QueryString has no parameter [extra] or extra is empty
                {
                   mwqmSubsectorService.Query = mwqmSubsectorService.FillQuery(typeof(MWQMSubsector), lang, skip, take, asc, desc, where, extra);

                    if (mwqmSubsectorService.Query.HasErrors)
                    {
                        return Ok(new List<MWQMSubsector>()
                        {
                            new MWQMSubsector()
                            {
                                HasErrors = mwqmSubsectorService.Query.HasErrors,
                                ValidationResults = mwqmSubsectorService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(mwqmSubsectorService.GetMWQMSubsectorList().ToList());
                    }
                }
            }
        }
        // GET api/mwqmSubsector/1
        [Route("{MWQMSubsectorID:int}")]
        public IHttpActionResult GetMWQMSubsectorWithID([FromUri]int MWQMSubsectorID, [FromUri]string lang = "en", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMSubsectorService mwqmSubsectorService = new MWQMSubsectorService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                mwqmSubsectorService.Query = mwqmSubsectorService.FillQuery(typeof(MWQMSubsector), lang, 0, 1, "", "", extra);

                else
                {
                    MWQMSubsector mwqmSubsector = new MWQMSubsector();
                    mwqmSubsector = mwqmSubsectorService.GetMWQMSubsectorWithMWQMSubsectorID(MWQMSubsectorID);

                    if (mwqmSubsector == null)
                    {
                        return NotFound();
                    }

                    return Ok(mwqmSubsector);
                }
            }
        }
        // POST api/mwqmSubsector
        [Route("")]
        public IHttpActionResult Post([FromBody]MWQMSubsector mwqmSubsector, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMSubsectorService mwqmSubsectorService = new MWQMSubsectorService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!mwqmSubsectorService.Add(mwqmSubsector))
                {
                    return BadRequest(String.Join("|||", mwqmSubsector.ValidationResults));
                }
                else
                {
                    mwqmSubsector.ValidationResults = null;
                    return Created<MWQMSubsector>(new Uri(Request.RequestUri, mwqmSubsector.MWQMSubsectorID.ToString()), mwqmSubsector);
                }
            }
        }
        // PUT api/mwqmSubsector
        [Route("")]
        public IHttpActionResult Put([FromBody]MWQMSubsector mwqmSubsector, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMSubsectorService mwqmSubsectorService = new MWQMSubsectorService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!mwqmSubsectorService.Update(mwqmSubsector))
                {
                    return BadRequest(String.Join("|||", mwqmSubsector.ValidationResults));
                }
                else
                {
                    mwqmSubsector.ValidationResults = null;
                    return Ok(mwqmSubsector);
                }
            }
        }
        // DELETE api/mwqmSubsector
        [Route("")]
        public IHttpActionResult Delete([FromBody]MWQMSubsector mwqmSubsector, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMSubsectorService mwqmSubsectorService = new MWQMSubsectorService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!mwqmSubsectorService.Delete(mwqmSubsector))
                {
                    return BadRequest(String.Join("|||", mwqmSubsector.ValidationResults));
                }
                else
                {
                    mwqmSubsector.ValidationResults = null;
                    return Ok(mwqmSubsector);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
