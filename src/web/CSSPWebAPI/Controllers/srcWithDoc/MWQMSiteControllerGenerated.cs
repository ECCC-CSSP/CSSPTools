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

                if (extra == "A") // QueryString contains [extra=A]
                {
                   mwqmSiteService.Query = mwqmSiteService.FillQuery(typeof(MWQMSiteExtraA), lang, skip, take, asc, desc, where, extra);

                    if (mwqmSiteService.Query.HasErrors)
                    {
                        return Ok(new List<MWQMSiteExtraA>()
                        {
                            new MWQMSiteExtraA()
                            {
                                HasErrors = mwqmSiteService.Query.HasErrors,
                                ValidationResults = mwqmSiteService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(mwqmSiteService.GetMWQMSiteExtraAList().ToList());
                    }
                }
                else if (extra == "B") // QueryString contains [extra=B]
                {
                   mwqmSiteService.Query = mwqmSiteService.FillQuery(typeof(MWQMSiteExtraB), lang, skip, take, asc, desc, where, extra);

                    if (mwqmSiteService.Query.HasErrors)
                    {
                        return Ok(new List<MWQMSiteExtraB>()
                        {
                            new MWQMSiteExtraB()
                            {
                                HasErrors = mwqmSiteService.Query.HasErrors,
                                ValidationResults = mwqmSiteService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(mwqmSiteService.GetMWQMSiteExtraBList().ToList());
                    }
                }
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

                if (mwqmSiteService.Query.Extra == "A")
                {
                    MWQMSiteExtraA mwqmSiteExtraA = new MWQMSiteExtraA();
                    mwqmSiteExtraA = mwqmSiteService.GetMWQMSiteExtraAWithMWQMSiteID(MWQMSiteID);

                    if (mwqmSiteExtraA == null)
                    {
                        return NotFound();
                    }

                    return Ok(mwqmSiteExtraA);
                }
                else if (mwqmSiteService.Query.Extra == "B")
                {
                    MWQMSiteExtraB mwqmSiteExtraB = new MWQMSiteExtraB();
                    mwqmSiteExtraB = mwqmSiteService.GetMWQMSiteExtraBWithMWQMSiteID(MWQMSiteID);

                    if (mwqmSiteExtraB == null)
                    {
                        return NotFound();
                    }

                    return Ok(mwqmSiteExtraB);
                }
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
