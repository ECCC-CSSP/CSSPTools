using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CSSPWebAPI.Controllers
{
    [RoutePrefix("api/mwqmAnalysisReportParameter")]
    public partial class MWQMAnalysisReportParameterController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MWQMAnalysisReportParameterController() : base()
        {
        }
        public MWQMAnalysisReportParameterController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/mwqmAnalysisReportParameter
        [Route("")]
        public IHttpActionResult GetMWQMAnalysisReportParameterList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMAnalysisReportParameterService mwqmAnalysisReportParameterService = new MWQMAnalysisReportParameterService(new Query() { Lang = lang }, db, ContactID);

                if (extra == "A") // QueryString contains [extra=A]
                {
                   mwqmAnalysisReportParameterService.Query = mwqmAnalysisReportParameterService.FillQuery(typeof(MWQMAnalysisReportParameterExtraA), lang, skip, take, asc, desc, where, extra);

                    if (mwqmAnalysisReportParameterService.Query.HasErrors)
                    {
                        return Ok(new List<MWQMAnalysisReportParameterExtraA>()
                        {
                            new MWQMAnalysisReportParameterExtraA()
                            {
                                HasErrors = mwqmAnalysisReportParameterService.Query.HasErrors,
                                ValidationResults = mwqmAnalysisReportParameterService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(mwqmAnalysisReportParameterService.GetMWQMAnalysisReportParameterExtraAList().ToList());
                    }
                }
                else if (extra == "B") // QueryString contains [extra=B]
                {
                   mwqmAnalysisReportParameterService.Query = mwqmAnalysisReportParameterService.FillQuery(typeof(MWQMAnalysisReportParameterExtraB), lang, skip, take, asc, desc, where, extra);

                    if (mwqmAnalysisReportParameterService.Query.HasErrors)
                    {
                        return Ok(new List<MWQMAnalysisReportParameterExtraB>()
                        {
                            new MWQMAnalysisReportParameterExtraB()
                            {
                                HasErrors = mwqmAnalysisReportParameterService.Query.HasErrors,
                                ValidationResults = mwqmAnalysisReportParameterService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(mwqmAnalysisReportParameterService.GetMWQMAnalysisReportParameterExtraBList().ToList());
                    }
                }
                else // QueryString has no parameter [extra] or extra is empty
                {
                   mwqmAnalysisReportParameterService.Query = mwqmAnalysisReportParameterService.FillQuery(typeof(MWQMAnalysisReportParameter), lang, skip, take, asc, desc, where, extra);

                    if (mwqmAnalysisReportParameterService.Query.HasErrors)
                    {
                        return Ok(new List<MWQMAnalysisReportParameter>()
                        {
                            new MWQMAnalysisReportParameter()
                            {
                                HasErrors = mwqmAnalysisReportParameterService.Query.HasErrors,
                                ValidationResults = mwqmAnalysisReportParameterService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(mwqmAnalysisReportParameterService.GetMWQMAnalysisReportParameterList().ToList());
                    }
                }
            }
        }
        // GET api/mwqmAnalysisReportParameter/1
        [Route("{MWQMAnalysisReportParameterID:int}")]
        public IHttpActionResult GetMWQMAnalysisReportParameterWithID([FromUri]int MWQMAnalysisReportParameterID, [FromUri]string lang = "en", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMAnalysisReportParameterService mwqmAnalysisReportParameterService = new MWQMAnalysisReportParameterService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                mwqmAnalysisReportParameterService.Query = mwqmAnalysisReportParameterService.FillQuery(typeof(MWQMAnalysisReportParameter), lang, 0, 1, "", "", extra);

                if (mwqmAnalysisReportParameterService.Query.Extra == "A")
                {
                    MWQMAnalysisReportParameterExtraA mwqmAnalysisReportParameterExtraA = new MWQMAnalysisReportParameterExtraA();
                    mwqmAnalysisReportParameterExtraA = mwqmAnalysisReportParameterService.GetMWQMAnalysisReportParameterExtraAWithMWQMAnalysisReportParameterID(MWQMAnalysisReportParameterID);

                    if (mwqmAnalysisReportParameterExtraA == null)
                    {
                        return NotFound();
                    }

                    return Ok(mwqmAnalysisReportParameterExtraA);
                }
                else if (mwqmAnalysisReportParameterService.Query.Extra == "B")
                {
                    MWQMAnalysisReportParameterExtraB mwqmAnalysisReportParameterExtraB = new MWQMAnalysisReportParameterExtraB();
                    mwqmAnalysisReportParameterExtraB = mwqmAnalysisReportParameterService.GetMWQMAnalysisReportParameterExtraBWithMWQMAnalysisReportParameterID(MWQMAnalysisReportParameterID);

                    if (mwqmAnalysisReportParameterExtraB == null)
                    {
                        return NotFound();
                    }

                    return Ok(mwqmAnalysisReportParameterExtraB);
                }
                else
                {
                    MWQMAnalysisReportParameter mwqmAnalysisReportParameter = new MWQMAnalysisReportParameter();
                    mwqmAnalysisReportParameter = mwqmAnalysisReportParameterService.GetMWQMAnalysisReportParameterWithMWQMAnalysisReportParameterID(MWQMAnalysisReportParameterID);

                    if (mwqmAnalysisReportParameter == null)
                    {
                        return NotFound();
                    }

                    return Ok(mwqmAnalysisReportParameter);
                }
            }
        }
        // POST api/mwqmAnalysisReportParameter
        [Route("")]
        public IHttpActionResult Post([FromBody]MWQMAnalysisReportParameter mwqmAnalysisReportParameter, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMAnalysisReportParameterService mwqmAnalysisReportParameterService = new MWQMAnalysisReportParameterService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!mwqmAnalysisReportParameterService.Add(mwqmAnalysisReportParameter))
                {
                    return BadRequest(String.Join("|||", mwqmAnalysisReportParameter.ValidationResults));
                }
                else
                {
                    mwqmAnalysisReportParameter.ValidationResults = null;
                    return Created<MWQMAnalysisReportParameter>(new Uri(Request.RequestUri, mwqmAnalysisReportParameter.MWQMAnalysisReportParameterID.ToString()), mwqmAnalysisReportParameter);
                }
            }
        }
        // PUT api/mwqmAnalysisReportParameter
        [Route("")]
        public IHttpActionResult Put([FromBody]MWQMAnalysisReportParameter mwqmAnalysisReportParameter, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMAnalysisReportParameterService mwqmAnalysisReportParameterService = new MWQMAnalysisReportParameterService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!mwqmAnalysisReportParameterService.Update(mwqmAnalysisReportParameter))
                {
                    return BadRequest(String.Join("|||", mwqmAnalysisReportParameter.ValidationResults));
                }
                else
                {
                    mwqmAnalysisReportParameter.ValidationResults = null;
                    return Ok(mwqmAnalysisReportParameter);
                }
            }
        }
        // DELETE api/mwqmAnalysisReportParameter
        [Route("")]
        public IHttpActionResult Delete([FromBody]MWQMAnalysisReportParameter mwqmAnalysisReportParameter, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMAnalysisReportParameterService mwqmAnalysisReportParameterService = new MWQMAnalysisReportParameterService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!mwqmAnalysisReportParameterService.Delete(mwqmAnalysisReportParameter))
                {
                    return BadRequest(String.Join("|||", mwqmAnalysisReportParameter.ValidationResults));
                }
                else
                {
                    mwqmAnalysisReportParameter.ValidationResults = null;
                    return Ok(mwqmAnalysisReportParameter);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
