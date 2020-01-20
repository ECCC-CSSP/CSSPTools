using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CSSPWebAPI.Controllers
{
    [RoutePrefix("api/mwqmSample")]
    public partial class MWQMSampleController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MWQMSampleController() : base()
        {
        }
        public MWQMSampleController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/mwqmSample
        [Route("")]
        public IHttpActionResult GetMWQMSampleList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMSampleService mwqmSampleService = new MWQMSampleService(new Query() { Lang = lang }, db, ContactID);

                if (extra == "A") // QueryString contains [extra=A]
                {
                   mwqmSampleService.Query = mwqmSampleService.FillQuery(typeof(MWQMSampleExtraA), lang, skip, take, asc, desc, where, extra);

                    if (mwqmSampleService.Query.HasErrors)
                    {
                        return Ok(new List<MWQMSampleExtraA>()
                        {
                            new MWQMSampleExtraA()
                            {
                                HasErrors = mwqmSampleService.Query.HasErrors,
                                ValidationResults = mwqmSampleService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(mwqmSampleService.GetMWQMSampleExtraAList().ToList());
                    }
                }
                else if (extra == "B") // QueryString contains [extra=B]
                {
                   mwqmSampleService.Query = mwqmSampleService.FillQuery(typeof(MWQMSampleExtraB), lang, skip, take, asc, desc, where, extra);

                    if (mwqmSampleService.Query.HasErrors)
                    {
                        return Ok(new List<MWQMSampleExtraB>()
                        {
                            new MWQMSampleExtraB()
                            {
                                HasErrors = mwqmSampleService.Query.HasErrors,
                                ValidationResults = mwqmSampleService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(mwqmSampleService.GetMWQMSampleExtraBList().ToList());
                    }
                }
                else // QueryString has no parameter [extra] or extra is empty
                {
                   mwqmSampleService.Query = mwqmSampleService.FillQuery(typeof(MWQMSample), lang, skip, take, asc, desc, where, extra);

                    if (mwqmSampleService.Query.HasErrors)
                    {
                        return Ok(new List<MWQMSample>()
                        {
                            new MWQMSample()
                            {
                                HasErrors = mwqmSampleService.Query.HasErrors,
                                ValidationResults = mwqmSampleService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(mwqmSampleService.GetMWQMSampleList().ToList());
                    }
                }
            }
        }
        // GET api/mwqmSample/1
        [Route("{MWQMSampleID:int}")]
        public IHttpActionResult GetMWQMSampleWithID([FromUri]int MWQMSampleID, [FromUri]string lang = "en", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMSampleService mwqmSampleService = new MWQMSampleService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                mwqmSampleService.Query = mwqmSampleService.FillQuery(typeof(MWQMSample), lang, 0, 1, "", "", extra);

                if (mwqmSampleService.Query.Extra == "A")
                {
                    MWQMSampleExtraA mwqmSampleExtraA = new MWQMSampleExtraA();
                    mwqmSampleExtraA = mwqmSampleService.GetMWQMSampleExtraAWithMWQMSampleID(MWQMSampleID);

                    if (mwqmSampleExtraA == null)
                    {
                        return NotFound();
                    }

                    return Ok(mwqmSampleExtraA);
                }
                else if (mwqmSampleService.Query.Extra == "B")
                {
                    MWQMSampleExtraB mwqmSampleExtraB = new MWQMSampleExtraB();
                    mwqmSampleExtraB = mwqmSampleService.GetMWQMSampleExtraBWithMWQMSampleID(MWQMSampleID);

                    if (mwqmSampleExtraB == null)
                    {
                        return NotFound();
                    }

                    return Ok(mwqmSampleExtraB);
                }
                else
                {
                    MWQMSample mwqmSample = new MWQMSample();
                    mwqmSample = mwqmSampleService.GetMWQMSampleWithMWQMSampleID(MWQMSampleID);

                    if (mwqmSample == null)
                    {
                        return NotFound();
                    }

                    return Ok(mwqmSample);
                }
            }
        }
        // POST api/mwqmSample
        [Route("")]
        public IHttpActionResult Post([FromBody]MWQMSample mwqmSample, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMSampleService mwqmSampleService = new MWQMSampleService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!mwqmSampleService.Add(mwqmSample))
                {
                    return BadRequest(String.Join("|||", mwqmSample.ValidationResults));
                }
                else
                {
                    mwqmSample.ValidationResults = null;
                    return Created<MWQMSample>(new Uri(Request.RequestUri, mwqmSample.MWQMSampleID.ToString()), mwqmSample);
                }
            }
        }
        // PUT api/mwqmSample
        [Route("")]
        public IHttpActionResult Put([FromBody]MWQMSample mwqmSample, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMSampleService mwqmSampleService = new MWQMSampleService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!mwqmSampleService.Update(mwqmSample))
                {
                    return BadRequest(String.Join("|||", mwqmSample.ValidationResults));
                }
                else
                {
                    mwqmSample.ValidationResults = null;
                    return Ok(mwqmSample);
                }
            }
        }
        // DELETE api/mwqmSample
        [Route("")]
        public IHttpActionResult Delete([FromBody]MWQMSample mwqmSample, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMSampleService mwqmSampleService = new MWQMSampleService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!mwqmSampleService.Delete(mwqmSample))
                {
                    return BadRequest(String.Join("|||", mwqmSample.ValidationResults));
                }
                else
                {
                    mwqmSample.ValidationResults = null;
                    return Ok(mwqmSample);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
