using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CSSPWebAPI.Controllers
{
    [RoutePrefix("api/mwqmSite")]
    public partial class MWQMSiteController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MWQMSiteController() : base()
        {
        }
        public MWQMSiteController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/mwqmSite
        [Route("")]
        public IHttpActionResult GetMWQMSiteList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMSiteService mwqmSiteService = new MWQMSiteService(new Query() { Lang = lang }, db, ContactID);

                else // QueryString has no parameter [extra] or extra is empty
                {
                   mwqmSiteService.Query = mwqmSiteService.FillQuery(typeof(MWQMSite), lang, skip, take, asc, desc, where, extra);

                    if (mwqmSiteService.Query.HasErrors)
                    {
                        return Ok(new List<MWQMSite>()
                        {
                            new MWQMSite()
                            {
                                HasErrors = mwqmSiteService.Query.HasErrors,
                                ValidationResults = mwqmSiteService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(mwqmSiteService.GetMWQMSiteList().ToList());
                    }
                }
            }
        }
        // GET api/mwqmSite/1
        [Route("{MWQMSiteID:int}")]
        public IHttpActionResult GetMWQMSiteWithID([FromUri]int MWQMSiteID, [FromUri]string lang = "en", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMSiteService mwqmSiteService = new MWQMSiteService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                mwqmSiteService.Query = mwqmSiteService.FillQuery(typeof(MWQMSite), lang, 0, 1, "", "", extra);

                else
                {
                    MWQMSite mwqmSite = new MWQMSite();
                    mwqmSite = mwqmSiteService.GetMWQMSiteWithMWQMSiteID(MWQMSiteID);

                    if (mwqmSite == null)
                    {
                        return NotFound();
                    }

                    return Ok(mwqmSite);
                }
            }
        }
        // POST api/mwqmSite
        [Route("")]
        public IHttpActionResult Post([FromBody]MWQMSite mwqmSite, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMSiteService mwqmSiteService = new MWQMSiteService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!mwqmSiteService.Add(mwqmSite))
                {
                    return BadRequest(String.Join("|||", mwqmSite.ValidationResults));
                }
                else
                {
                    mwqmSite.ValidationResults = null;
                    return Created<MWQMSite>(new Uri(Request.RequestUri, mwqmSite.MWQMSiteID.ToString()), mwqmSite);
                }
            }
        }
        // PUT api/mwqmSite
        [Route("")]
        public IHttpActionResult Put([FromBody]MWQMSite mwqmSite, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMSiteService mwqmSiteService = new MWQMSiteService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!mwqmSiteService.Update(mwqmSite))
                {
                    return BadRequest(String.Join("|||", mwqmSite.ValidationResults));
                }
                else
                {
                    mwqmSite.ValidationResults = null;
                    return Ok(mwqmSite);
                }
            }
        }
        // DELETE api/mwqmSite
        [Route("")]
        public IHttpActionResult Delete([FromBody]MWQMSite mwqmSite, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMSiteService mwqmSiteService = new MWQMSiteService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!mwqmSiteService.Delete(mwqmSite))
                {
                    return BadRequest(String.Join("|||", mwqmSite.ValidationResults));
                }
                else
                {
                    mwqmSite.ValidationResults = null;
                    return Ok(mwqmSite);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
