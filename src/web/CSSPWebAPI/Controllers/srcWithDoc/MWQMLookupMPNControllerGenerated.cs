using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CSSPWebAPI.Controllers
{
    [RoutePrefix("api/mwqmLookupMPN")]
    public partial class MWQMLookupMPNController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MWQMLookupMPNController() : base()
        {
        }
        public MWQMLookupMPNController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/mwqmLookupMPN
        [Route("")]
        public IHttpActionResult GetMWQMLookupMPNList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMLookupMPNService mwqmLookupMPNService = new MWQMLookupMPNService(new Query() { Lang = lang }, db, ContactID);

                if (extra == "A") // QueryString contains [extra=A]
                {
                   mwqmLookupMPNService.Query = mwqmLookupMPNService.FillQuery(typeof(MWQMLookupMPNExtraA), lang, skip, take, asc, desc, where, extra);

                    if (mwqmLookupMPNService.Query.HasErrors)
                    {
                        return Ok(new List<MWQMLookupMPNExtraA>()
                        {
                            new MWQMLookupMPNExtraA()
                            {
                                HasErrors = mwqmLookupMPNService.Query.HasErrors,
                                ValidationResults = mwqmLookupMPNService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(mwqmLookupMPNService.GetMWQMLookupMPNExtraAList().ToList());
                    }
                }
                else if (extra == "B") // QueryString contains [extra=B]
                {
                   mwqmLookupMPNService.Query = mwqmLookupMPNService.FillQuery(typeof(MWQMLookupMPNExtraB), lang, skip, take, asc, desc, where, extra);

                    if (mwqmLookupMPNService.Query.HasErrors)
                    {
                        return Ok(new List<MWQMLookupMPNExtraB>()
                        {
                            new MWQMLookupMPNExtraB()
                            {
                                HasErrors = mwqmLookupMPNService.Query.HasErrors,
                                ValidationResults = mwqmLookupMPNService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(mwqmLookupMPNService.GetMWQMLookupMPNExtraBList().ToList());
                    }
                }
                else // QueryString has no parameter [extra] or extra is empty
                {
                   mwqmLookupMPNService.Query = mwqmLookupMPNService.FillQuery(typeof(MWQMLookupMPN), lang, skip, take, asc, desc, where, extra);

                    if (mwqmLookupMPNService.Query.HasErrors)
                    {
                        return Ok(new List<MWQMLookupMPN>()
                        {
                            new MWQMLookupMPN()
                            {
                                HasErrors = mwqmLookupMPNService.Query.HasErrors,
                                ValidationResults = mwqmLookupMPNService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(mwqmLookupMPNService.GetMWQMLookupMPNList().ToList());
                    }
                }
            }
        }
        // GET api/mwqmLookupMPN/1
        [Route("{MWQMLookupMPNID:int}")]
        public IHttpActionResult GetMWQMLookupMPNWithID([FromUri]int MWQMLookupMPNID, [FromUri]string lang = "en", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMLookupMPNService mwqmLookupMPNService = new MWQMLookupMPNService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                mwqmLookupMPNService.Query = mwqmLookupMPNService.FillQuery(typeof(MWQMLookupMPN), lang, 0, 1, "", "", extra);

                if (mwqmLookupMPNService.Query.Extra == "A")
                {
                    MWQMLookupMPNExtraA mwqmLookupMPNExtraA = new MWQMLookupMPNExtraA();
                    mwqmLookupMPNExtraA = mwqmLookupMPNService.GetMWQMLookupMPNExtraAWithMWQMLookupMPNID(MWQMLookupMPNID);

                    if (mwqmLookupMPNExtraA == null)
                    {
                        return NotFound();
                    }

                    return Ok(mwqmLookupMPNExtraA);
                }
                else if (mwqmLookupMPNService.Query.Extra == "B")
                {
                    MWQMLookupMPNExtraB mwqmLookupMPNExtraB = new MWQMLookupMPNExtraB();
                    mwqmLookupMPNExtraB = mwqmLookupMPNService.GetMWQMLookupMPNExtraBWithMWQMLookupMPNID(MWQMLookupMPNID);

                    if (mwqmLookupMPNExtraB == null)
                    {
                        return NotFound();
                    }

                    return Ok(mwqmLookupMPNExtraB);
                }
                else
                {
                    MWQMLookupMPN mwqmLookupMPN = new MWQMLookupMPN();
                    mwqmLookupMPN = mwqmLookupMPNService.GetMWQMLookupMPNWithMWQMLookupMPNID(MWQMLookupMPNID);

                    if (mwqmLookupMPN == null)
                    {
                        return NotFound();
                    }

                    return Ok(mwqmLookupMPN);
                }
            }
        }
        // POST api/mwqmLookupMPN
        [Route("")]
        public IHttpActionResult Post([FromBody]MWQMLookupMPN mwqmLookupMPN, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMLookupMPNService mwqmLookupMPNService = new MWQMLookupMPNService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!mwqmLookupMPNService.Add(mwqmLookupMPN))
                {
                    return BadRequest(String.Join("|||", mwqmLookupMPN.ValidationResults));
                }
                else
                {
                    mwqmLookupMPN.ValidationResults = null;
                    return Created<MWQMLookupMPN>(new Uri(Request.RequestUri, mwqmLookupMPN.MWQMLookupMPNID.ToString()), mwqmLookupMPN);
                }
            }
        }
        // PUT api/mwqmLookupMPN
        [Route("")]
        public IHttpActionResult Put([FromBody]MWQMLookupMPN mwqmLookupMPN, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMLookupMPNService mwqmLookupMPNService = new MWQMLookupMPNService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!mwqmLookupMPNService.Update(mwqmLookupMPN))
                {
                    return BadRequest(String.Join("|||", mwqmLookupMPN.ValidationResults));
                }
                else
                {
                    mwqmLookupMPN.ValidationResults = null;
                    return Ok(mwqmLookupMPN);
                }
            }
        }
        // DELETE api/mwqmLookupMPN
        [Route("")]
        public IHttpActionResult Delete([FromBody]MWQMLookupMPN mwqmLookupMPN, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMLookupMPNService mwqmLookupMPNService = new MWQMLookupMPNService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!mwqmLookupMPNService.Delete(mwqmLookupMPN))
                {
                    return BadRequest(String.Join("|||", mwqmLookupMPN.ValidationResults));
                }
                else
                {
                    mwqmLookupMPN.ValidationResults = null;
                    return Ok(mwqmLookupMPN);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
