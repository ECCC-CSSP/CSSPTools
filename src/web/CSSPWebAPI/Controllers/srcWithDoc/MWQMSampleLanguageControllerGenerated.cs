using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CSSPWebAPI.Controllers
{
    [RoutePrefix("api/mwqmSampleLanguage")]
    public partial class MWQMSampleLanguageController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MWQMSampleLanguageController() : base()
        {
        }
        public MWQMSampleLanguageController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/mwqmSampleLanguage
        [Route("")]
        public IHttpActionResult GetMWQMSampleLanguageList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMSampleLanguageService mwqmSampleLanguageService = new MWQMSampleLanguageService(new Query() { Lang = lang }, db, ContactID);

                if (extra == "A") // QueryString contains [extra=A]
                {
                   mwqmSampleLanguageService.Query = mwqmSampleLanguageService.FillQuery(typeof(MWQMSampleLanguageExtraA), lang, skip, take, asc, desc, where, extra);

                    if (mwqmSampleLanguageService.Query.HasErrors)
                    {
                        return Ok(new List<MWQMSampleLanguageExtraA>()
                        {
                            new MWQMSampleLanguageExtraA()
                            {
                                HasErrors = mwqmSampleLanguageService.Query.HasErrors,
                                ValidationResults = mwqmSampleLanguageService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(mwqmSampleLanguageService.GetMWQMSampleLanguageExtraAList().ToList());
                    }
                }
                else if (extra == "B") // QueryString contains [extra=B]
                {
                   mwqmSampleLanguageService.Query = mwqmSampleLanguageService.FillQuery(typeof(MWQMSampleLanguageExtraB), lang, skip, take, asc, desc, where, extra);

                    if (mwqmSampleLanguageService.Query.HasErrors)
                    {
                        return Ok(new List<MWQMSampleLanguageExtraB>()
                        {
                            new MWQMSampleLanguageExtraB()
                            {
                                HasErrors = mwqmSampleLanguageService.Query.HasErrors,
                                ValidationResults = mwqmSampleLanguageService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(mwqmSampleLanguageService.GetMWQMSampleLanguageExtraBList().ToList());
                    }
                }
                else // QueryString has no parameter [extra] or extra is empty
                {
                   mwqmSampleLanguageService.Query = mwqmSampleLanguageService.FillQuery(typeof(MWQMSampleLanguage), lang, skip, take, asc, desc, where, extra);

                    if (mwqmSampleLanguageService.Query.HasErrors)
                    {
                        return Ok(new List<MWQMSampleLanguage>()
                        {
                            new MWQMSampleLanguage()
                            {
                                HasErrors = mwqmSampleLanguageService.Query.HasErrors,
                                ValidationResults = mwqmSampleLanguageService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(mwqmSampleLanguageService.GetMWQMSampleLanguageList().ToList());
                    }
                }
            }
        }
        // GET api/mwqmSampleLanguage/1
        [Route("{MWQMSampleLanguageID:int}")]
        public IHttpActionResult GetMWQMSampleLanguageWithID([FromUri]int MWQMSampleLanguageID, [FromUri]string lang = "en", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMSampleLanguageService mwqmSampleLanguageService = new MWQMSampleLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                mwqmSampleLanguageService.Query = mwqmSampleLanguageService.FillQuery(typeof(MWQMSampleLanguage), lang, 0, 1, "", "", extra);

                if (mwqmSampleLanguageService.Query.Extra == "A")
                {
                    MWQMSampleLanguageExtraA mwqmSampleLanguageExtraA = new MWQMSampleLanguageExtraA();
                    mwqmSampleLanguageExtraA = mwqmSampleLanguageService.GetMWQMSampleLanguageExtraAWithMWQMSampleLanguageID(MWQMSampleLanguageID);

                    if (mwqmSampleLanguageExtraA == null)
                    {
                        return NotFound();
                    }

                    return Ok(mwqmSampleLanguageExtraA);
                }
                else if (mwqmSampleLanguageService.Query.Extra == "B")
                {
                    MWQMSampleLanguageExtraB mwqmSampleLanguageExtraB = new MWQMSampleLanguageExtraB();
                    mwqmSampleLanguageExtraB = mwqmSampleLanguageService.GetMWQMSampleLanguageExtraBWithMWQMSampleLanguageID(MWQMSampleLanguageID);

                    if (mwqmSampleLanguageExtraB == null)
                    {
                        return NotFound();
                    }

                    return Ok(mwqmSampleLanguageExtraB);
                }
                else
                {
                    MWQMSampleLanguage mwqmSampleLanguage = new MWQMSampleLanguage();
                    mwqmSampleLanguage = mwqmSampleLanguageService.GetMWQMSampleLanguageWithMWQMSampleLanguageID(MWQMSampleLanguageID);

                    if (mwqmSampleLanguage == null)
                    {
                        return NotFound();
                    }

                    return Ok(mwqmSampleLanguage);
                }
            }
        }
        // POST api/mwqmSampleLanguage
        [Route("")]
        public IHttpActionResult Post([FromBody]MWQMSampleLanguage mwqmSampleLanguage, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMSampleLanguageService mwqmSampleLanguageService = new MWQMSampleLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!mwqmSampleLanguageService.Add(mwqmSampleLanguage))
                {
                    return BadRequest(String.Join("|||", mwqmSampleLanguage.ValidationResults));
                }
                else
                {
                    mwqmSampleLanguage.ValidationResults = null;
                    return Created<MWQMSampleLanguage>(new Uri(Request.RequestUri, mwqmSampleLanguage.MWQMSampleLanguageID.ToString()), mwqmSampleLanguage);
                }
            }
        }
        // PUT api/mwqmSampleLanguage
        [Route("")]
        public IHttpActionResult Put([FromBody]MWQMSampleLanguage mwqmSampleLanguage, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMSampleLanguageService mwqmSampleLanguageService = new MWQMSampleLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!mwqmSampleLanguageService.Update(mwqmSampleLanguage))
                {
                    return BadRequest(String.Join("|||", mwqmSampleLanguage.ValidationResults));
                }
                else
                {
                    mwqmSampleLanguage.ValidationResults = null;
                    return Ok(mwqmSampleLanguage);
                }
            }
        }
        // DELETE api/mwqmSampleLanguage
        [Route("")]
        public IHttpActionResult Delete([FromBody]MWQMSampleLanguage mwqmSampleLanguage, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMSampleLanguageService mwqmSampleLanguageService = new MWQMSampleLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!mwqmSampleLanguageService.Delete(mwqmSampleLanguage))
                {
                    return BadRequest(String.Join("|||", mwqmSampleLanguage.ValidationResults));
                }
                else
                {
                    mwqmSampleLanguage.ValidationResults = null;
                    return Ok(mwqmSampleLanguage);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
