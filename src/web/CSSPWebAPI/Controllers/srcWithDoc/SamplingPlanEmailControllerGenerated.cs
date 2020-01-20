using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CSSPWebAPI.Controllers
{
    [RoutePrefix("api/samplingPlanEmail")]
    public partial class SamplingPlanEmailController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public SamplingPlanEmailController() : base()
        {
        }
        public SamplingPlanEmailController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/samplingPlanEmail
        [Route("")]
        public IHttpActionResult GetSamplingPlanEmailList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                SamplingPlanEmailService samplingPlanEmailService = new SamplingPlanEmailService(new Query() { Lang = lang }, db, ContactID);

                if (extra == "A") // QueryString contains [extra=A]
                {
                   samplingPlanEmailService.Query = samplingPlanEmailService.FillQuery(typeof(SamplingPlanEmailExtraA), lang, skip, take, asc, desc, where, extra);

                    if (samplingPlanEmailService.Query.HasErrors)
                    {
                        return Ok(new List<SamplingPlanEmailExtraA>()
                        {
                            new SamplingPlanEmailExtraA()
                            {
                                HasErrors = samplingPlanEmailService.Query.HasErrors,
                                ValidationResults = samplingPlanEmailService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(samplingPlanEmailService.GetSamplingPlanEmailExtraAList().ToList());
                    }
                }
                else if (extra == "B") // QueryString contains [extra=B]
                {
                   samplingPlanEmailService.Query = samplingPlanEmailService.FillQuery(typeof(SamplingPlanEmailExtraB), lang, skip, take, asc, desc, where, extra);

                    if (samplingPlanEmailService.Query.HasErrors)
                    {
                        return Ok(new List<SamplingPlanEmailExtraB>()
                        {
                            new SamplingPlanEmailExtraB()
                            {
                                HasErrors = samplingPlanEmailService.Query.HasErrors,
                                ValidationResults = samplingPlanEmailService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(samplingPlanEmailService.GetSamplingPlanEmailExtraBList().ToList());
                    }
                }
                else // QueryString has no parameter [extra] or extra is empty
                {
                   samplingPlanEmailService.Query = samplingPlanEmailService.FillQuery(typeof(SamplingPlanEmail), lang, skip, take, asc, desc, where, extra);

                    if (samplingPlanEmailService.Query.HasErrors)
                    {
                        return Ok(new List<SamplingPlanEmail>()
                        {
                            new SamplingPlanEmail()
                            {
                                HasErrors = samplingPlanEmailService.Query.HasErrors,
                                ValidationResults = samplingPlanEmailService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(samplingPlanEmailService.GetSamplingPlanEmailList().ToList());
                    }
                }
            }
        }
        // GET api/samplingPlanEmail/1
        [Route("{SamplingPlanEmailID:int}")]
        public IHttpActionResult GetSamplingPlanEmailWithID([FromUri]int SamplingPlanEmailID, [FromUri]string lang = "en", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                SamplingPlanEmailService samplingPlanEmailService = new SamplingPlanEmailService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                samplingPlanEmailService.Query = samplingPlanEmailService.FillQuery(typeof(SamplingPlanEmail), lang, 0, 1, "", "", extra);

                if (samplingPlanEmailService.Query.Extra == "A")
                {
                    SamplingPlanEmailExtraA samplingPlanEmailExtraA = new SamplingPlanEmailExtraA();
                    samplingPlanEmailExtraA = samplingPlanEmailService.GetSamplingPlanEmailExtraAWithSamplingPlanEmailID(SamplingPlanEmailID);

                    if (samplingPlanEmailExtraA == null)
                    {
                        return NotFound();
                    }

                    return Ok(samplingPlanEmailExtraA);
                }
                else if (samplingPlanEmailService.Query.Extra == "B")
                {
                    SamplingPlanEmailExtraB samplingPlanEmailExtraB = new SamplingPlanEmailExtraB();
                    samplingPlanEmailExtraB = samplingPlanEmailService.GetSamplingPlanEmailExtraBWithSamplingPlanEmailID(SamplingPlanEmailID);

                    if (samplingPlanEmailExtraB == null)
                    {
                        return NotFound();
                    }

                    return Ok(samplingPlanEmailExtraB);
                }
                else
                {
                    SamplingPlanEmail samplingPlanEmail = new SamplingPlanEmail();
                    samplingPlanEmail = samplingPlanEmailService.GetSamplingPlanEmailWithSamplingPlanEmailID(SamplingPlanEmailID);

                    if (samplingPlanEmail == null)
                    {
                        return NotFound();
                    }

                    return Ok(samplingPlanEmail);
                }
            }
        }
        // POST api/samplingPlanEmail
        [Route("")]
        public IHttpActionResult Post([FromBody]SamplingPlanEmail samplingPlanEmail, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                SamplingPlanEmailService samplingPlanEmailService = new SamplingPlanEmailService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!samplingPlanEmailService.Add(samplingPlanEmail))
                {
                    return BadRequest(String.Join("|||", samplingPlanEmail.ValidationResults));
                }
                else
                {
                    samplingPlanEmail.ValidationResults = null;
                    return Created<SamplingPlanEmail>(new Uri(Request.RequestUri, samplingPlanEmail.SamplingPlanEmailID.ToString()), samplingPlanEmail);
                }
            }
        }
        // PUT api/samplingPlanEmail
        [Route("")]
        public IHttpActionResult Put([FromBody]SamplingPlanEmail samplingPlanEmail, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                SamplingPlanEmailService samplingPlanEmailService = new SamplingPlanEmailService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!samplingPlanEmailService.Update(samplingPlanEmail))
                {
                    return BadRequest(String.Join("|||", samplingPlanEmail.ValidationResults));
                }
                else
                {
                    samplingPlanEmail.ValidationResults = null;
                    return Ok(samplingPlanEmail);
                }
            }
        }
        // DELETE api/samplingPlanEmail
        [Route("")]
        public IHttpActionResult Delete([FromBody]SamplingPlanEmail samplingPlanEmail, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                SamplingPlanEmailService samplingPlanEmailService = new SamplingPlanEmailService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!samplingPlanEmailService.Delete(samplingPlanEmail))
                {
                    return BadRequest(String.Join("|||", samplingPlanEmail.ValidationResults));
                }
                else
                {
                    samplingPlanEmail.ValidationResults = null;
                    return Ok(samplingPlanEmail);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
