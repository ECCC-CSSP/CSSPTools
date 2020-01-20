using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CSSPWebAPI.Controllers
{
    [RoutePrefix("api/samplingPlanSubsectorSite")]
    public partial class SamplingPlanSubsectorSiteController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public SamplingPlanSubsectorSiteController() : base()
        {
        }
        public SamplingPlanSubsectorSiteController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/samplingPlanSubsectorSite
        [Route("")]
        public IHttpActionResult GetSamplingPlanSubsectorSiteList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                SamplingPlanSubsectorSiteService samplingPlanSubsectorSiteService = new SamplingPlanSubsectorSiteService(new Query() { Lang = lang }, db, ContactID);

                if (extra == "A") // QueryString contains [extra=A]
                {
                   samplingPlanSubsectorSiteService.Query = samplingPlanSubsectorSiteService.FillQuery(typeof(SamplingPlanSubsectorSiteExtraA), lang, skip, take, asc, desc, where, extra);

                    if (samplingPlanSubsectorSiteService.Query.HasErrors)
                    {
                        return Ok(new List<SamplingPlanSubsectorSiteExtraA>()
                        {
                            new SamplingPlanSubsectorSiteExtraA()
                            {
                                HasErrors = samplingPlanSubsectorSiteService.Query.HasErrors,
                                ValidationResults = samplingPlanSubsectorSiteService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(samplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteExtraAList().ToList());
                    }
                }
                else if (extra == "B") // QueryString contains [extra=B]
                {
                   samplingPlanSubsectorSiteService.Query = samplingPlanSubsectorSiteService.FillQuery(typeof(SamplingPlanSubsectorSiteExtraB), lang, skip, take, asc, desc, where, extra);

                    if (samplingPlanSubsectorSiteService.Query.HasErrors)
                    {
                        return Ok(new List<SamplingPlanSubsectorSiteExtraB>()
                        {
                            new SamplingPlanSubsectorSiteExtraB()
                            {
                                HasErrors = samplingPlanSubsectorSiteService.Query.HasErrors,
                                ValidationResults = samplingPlanSubsectorSiteService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(samplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteExtraBList().ToList());
                    }
                }
                else // QueryString has no parameter [extra] or extra is empty
                {
                   samplingPlanSubsectorSiteService.Query = samplingPlanSubsectorSiteService.FillQuery(typeof(SamplingPlanSubsectorSite), lang, skip, take, asc, desc, where, extra);

                    if (samplingPlanSubsectorSiteService.Query.HasErrors)
                    {
                        return Ok(new List<SamplingPlanSubsectorSite>()
                        {
                            new SamplingPlanSubsectorSite()
                            {
                                HasErrors = samplingPlanSubsectorSiteService.Query.HasErrors,
                                ValidationResults = samplingPlanSubsectorSiteService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(samplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteList().ToList());
                    }
                }
            }
        }
        // GET api/samplingPlanSubsectorSite/1
        [Route("{SamplingPlanSubsectorSiteID:int}")]
        public IHttpActionResult GetSamplingPlanSubsectorSiteWithID([FromUri]int SamplingPlanSubsectorSiteID, [FromUri]string lang = "en", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                SamplingPlanSubsectorSiteService samplingPlanSubsectorSiteService = new SamplingPlanSubsectorSiteService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                samplingPlanSubsectorSiteService.Query = samplingPlanSubsectorSiteService.FillQuery(typeof(SamplingPlanSubsectorSite), lang, 0, 1, "", "", extra);

                if (samplingPlanSubsectorSiteService.Query.Extra == "A")
                {
                    SamplingPlanSubsectorSiteExtraA samplingPlanSubsectorSiteExtraA = new SamplingPlanSubsectorSiteExtraA();
                    samplingPlanSubsectorSiteExtraA = samplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteExtraAWithSamplingPlanSubsectorSiteID(SamplingPlanSubsectorSiteID);

                    if (samplingPlanSubsectorSiteExtraA == null)
                    {
                        return NotFound();
                    }

                    return Ok(samplingPlanSubsectorSiteExtraA);
                }
                else if (samplingPlanSubsectorSiteService.Query.Extra == "B")
                {
                    SamplingPlanSubsectorSiteExtraB samplingPlanSubsectorSiteExtraB = new SamplingPlanSubsectorSiteExtraB();
                    samplingPlanSubsectorSiteExtraB = samplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteExtraBWithSamplingPlanSubsectorSiteID(SamplingPlanSubsectorSiteID);

                    if (samplingPlanSubsectorSiteExtraB == null)
                    {
                        return NotFound();
                    }

                    return Ok(samplingPlanSubsectorSiteExtraB);
                }
                else
                {
                    SamplingPlanSubsectorSite samplingPlanSubsectorSite = new SamplingPlanSubsectorSite();
                    samplingPlanSubsectorSite = samplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteWithSamplingPlanSubsectorSiteID(SamplingPlanSubsectorSiteID);

                    if (samplingPlanSubsectorSite == null)
                    {
                        return NotFound();
                    }

                    return Ok(samplingPlanSubsectorSite);
                }
            }
        }
        // POST api/samplingPlanSubsectorSite
        [Route("")]
        public IHttpActionResult Post([FromBody]SamplingPlanSubsectorSite samplingPlanSubsectorSite, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                SamplingPlanSubsectorSiteService samplingPlanSubsectorSiteService = new SamplingPlanSubsectorSiteService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!samplingPlanSubsectorSiteService.Add(samplingPlanSubsectorSite))
                {
                    return BadRequest(String.Join("|||", samplingPlanSubsectorSite.ValidationResults));
                }
                else
                {
                    samplingPlanSubsectorSite.ValidationResults = null;
                    return Created<SamplingPlanSubsectorSite>(new Uri(Request.RequestUri, samplingPlanSubsectorSite.SamplingPlanSubsectorSiteID.ToString()), samplingPlanSubsectorSite);
                }
            }
        }
        // PUT api/samplingPlanSubsectorSite
        [Route("")]
        public IHttpActionResult Put([FromBody]SamplingPlanSubsectorSite samplingPlanSubsectorSite, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                SamplingPlanSubsectorSiteService samplingPlanSubsectorSiteService = new SamplingPlanSubsectorSiteService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!samplingPlanSubsectorSiteService.Update(samplingPlanSubsectorSite))
                {
                    return BadRequest(String.Join("|||", samplingPlanSubsectorSite.ValidationResults));
                }
                else
                {
                    samplingPlanSubsectorSite.ValidationResults = null;
                    return Ok(samplingPlanSubsectorSite);
                }
            }
        }
        // DELETE api/samplingPlanSubsectorSite
        [Route("")]
        public IHttpActionResult Delete([FromBody]SamplingPlanSubsectorSite samplingPlanSubsectorSite, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                SamplingPlanSubsectorSiteService samplingPlanSubsectorSiteService = new SamplingPlanSubsectorSiteService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!samplingPlanSubsectorSiteService.Delete(samplingPlanSubsectorSite))
                {
                    return BadRequest(String.Join("|||", samplingPlanSubsectorSite.ValidationResults));
                }
                else
                {
                    samplingPlanSubsectorSite.ValidationResults = null;
                    return Ok(samplingPlanSubsectorSite);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
