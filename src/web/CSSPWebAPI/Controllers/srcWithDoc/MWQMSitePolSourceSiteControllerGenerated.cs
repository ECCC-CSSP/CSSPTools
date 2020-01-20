using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CSSPWebAPI.Controllers
{
    [RoutePrefix("api/mwqmSitePolSourceSite")]
    public partial class MWQMSitePolSourceSiteController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MWQMSitePolSourceSiteController() : base()
        {
        }
        public MWQMSitePolSourceSiteController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/mwqmSitePolSourceSite
        [Route("")]
        public IHttpActionResult GetMWQMSitePolSourceSiteList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMSitePolSourceSiteService mwqmSitePolSourceSiteService = new MWQMSitePolSourceSiteService(new Query() { Lang = lang }, db, ContactID);

                if (extra == "A") // QueryString contains [extra=A]
                {
                   mwqmSitePolSourceSiteService.Query = mwqmSitePolSourceSiteService.FillQuery(typeof(MWQMSitePolSourceSiteExtraA), lang, skip, take, asc, desc, where, extra);

                    if (mwqmSitePolSourceSiteService.Query.HasErrors)
                    {
                        return Ok(new List<MWQMSitePolSourceSiteExtraA>()
                        {
                            new MWQMSitePolSourceSiteExtraA()
                            {
                                HasErrors = mwqmSitePolSourceSiteService.Query.HasErrors,
                                ValidationResults = mwqmSitePolSourceSiteService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(mwqmSitePolSourceSiteService.GetMWQMSitePolSourceSiteExtraAList().ToList());
                    }
                }
                else if (extra == "B") // QueryString contains [extra=B]
                {
                   mwqmSitePolSourceSiteService.Query = mwqmSitePolSourceSiteService.FillQuery(typeof(MWQMSitePolSourceSiteExtraB), lang, skip, take, asc, desc, where, extra);

                    if (mwqmSitePolSourceSiteService.Query.HasErrors)
                    {
                        return Ok(new List<MWQMSitePolSourceSiteExtraB>()
                        {
                            new MWQMSitePolSourceSiteExtraB()
                            {
                                HasErrors = mwqmSitePolSourceSiteService.Query.HasErrors,
                                ValidationResults = mwqmSitePolSourceSiteService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(mwqmSitePolSourceSiteService.GetMWQMSitePolSourceSiteExtraBList().ToList());
                    }
                }
                else // QueryString has no parameter [extra] or extra is empty
                {
                   mwqmSitePolSourceSiteService.Query = mwqmSitePolSourceSiteService.FillQuery(typeof(MWQMSitePolSourceSite), lang, skip, take, asc, desc, where, extra);

                    if (mwqmSitePolSourceSiteService.Query.HasErrors)
                    {
                        return Ok(new List<MWQMSitePolSourceSite>()
                        {
                            new MWQMSitePolSourceSite()
                            {
                                HasErrors = mwqmSitePolSourceSiteService.Query.HasErrors,
                                ValidationResults = mwqmSitePolSourceSiteService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(mwqmSitePolSourceSiteService.GetMWQMSitePolSourceSiteList().ToList());
                    }
                }
            }
        }
        // GET api/mwqmSitePolSourceSite/1
        [Route("{MWQMSitePolSourceSiteID:int}")]
        public IHttpActionResult GetMWQMSitePolSourceSiteWithID([FromUri]int MWQMSitePolSourceSiteID, [FromUri]string lang = "en", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMSitePolSourceSiteService mwqmSitePolSourceSiteService = new MWQMSitePolSourceSiteService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                mwqmSitePolSourceSiteService.Query = mwqmSitePolSourceSiteService.FillQuery(typeof(MWQMSitePolSourceSite), lang, 0, 1, "", "", extra);

                if (mwqmSitePolSourceSiteService.Query.Extra == "A")
                {
                    MWQMSitePolSourceSiteExtraA mwqmSitePolSourceSiteExtraA = new MWQMSitePolSourceSiteExtraA();
                    mwqmSitePolSourceSiteExtraA = mwqmSitePolSourceSiteService.GetMWQMSitePolSourceSiteExtraAWithMWQMSitePolSourceSiteID(MWQMSitePolSourceSiteID);

                    if (mwqmSitePolSourceSiteExtraA == null)
                    {
                        return NotFound();
                    }

                    return Ok(mwqmSitePolSourceSiteExtraA);
                }
                else if (mwqmSitePolSourceSiteService.Query.Extra == "B")
                {
                    MWQMSitePolSourceSiteExtraB mwqmSitePolSourceSiteExtraB = new MWQMSitePolSourceSiteExtraB();
                    mwqmSitePolSourceSiteExtraB = mwqmSitePolSourceSiteService.GetMWQMSitePolSourceSiteExtraBWithMWQMSitePolSourceSiteID(MWQMSitePolSourceSiteID);

                    if (mwqmSitePolSourceSiteExtraB == null)
                    {
                        return NotFound();
                    }

                    return Ok(mwqmSitePolSourceSiteExtraB);
                }
                else
                {
                    MWQMSitePolSourceSite mwqmSitePolSourceSite = new MWQMSitePolSourceSite();
                    mwqmSitePolSourceSite = mwqmSitePolSourceSiteService.GetMWQMSitePolSourceSiteWithMWQMSitePolSourceSiteID(MWQMSitePolSourceSiteID);

                    if (mwqmSitePolSourceSite == null)
                    {
                        return NotFound();
                    }

                    return Ok(mwqmSitePolSourceSite);
                }
            }
        }
        // POST api/mwqmSitePolSourceSite
        [Route("")]
        public IHttpActionResult Post([FromBody]MWQMSitePolSourceSite mwqmSitePolSourceSite, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMSitePolSourceSiteService mwqmSitePolSourceSiteService = new MWQMSitePolSourceSiteService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!mwqmSitePolSourceSiteService.Add(mwqmSitePolSourceSite))
                {
                    return BadRequest(String.Join("|||", mwqmSitePolSourceSite.ValidationResults));
                }
                else
                {
                    mwqmSitePolSourceSite.ValidationResults = null;
                    return Created<MWQMSitePolSourceSite>(new Uri(Request.RequestUri, mwqmSitePolSourceSite.MWQMSitePolSourceSiteID.ToString()), mwqmSitePolSourceSite);
                }
            }
        }
        // PUT api/mwqmSitePolSourceSite
        [Route("")]
        public IHttpActionResult Put([FromBody]MWQMSitePolSourceSite mwqmSitePolSourceSite, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMSitePolSourceSiteService mwqmSitePolSourceSiteService = new MWQMSitePolSourceSiteService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!mwqmSitePolSourceSiteService.Update(mwqmSitePolSourceSite))
                {
                    return BadRequest(String.Join("|||", mwqmSitePolSourceSite.ValidationResults));
                }
                else
                {
                    mwqmSitePolSourceSite.ValidationResults = null;
                    return Ok(mwqmSitePolSourceSite);
                }
            }
        }
        // DELETE api/mwqmSitePolSourceSite
        [Route("")]
        public IHttpActionResult Delete([FromBody]MWQMSitePolSourceSite mwqmSitePolSourceSite, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMSitePolSourceSiteService mwqmSitePolSourceSiteService = new MWQMSitePolSourceSiteService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!mwqmSitePolSourceSiteService.Delete(mwqmSitePolSourceSite))
                {
                    return BadRequest(String.Join("|||", mwqmSitePolSourceSite.ValidationResults));
                }
                else
                {
                    mwqmSitePolSourceSite.ValidationResults = null;
                    return Ok(mwqmSitePolSourceSite);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
