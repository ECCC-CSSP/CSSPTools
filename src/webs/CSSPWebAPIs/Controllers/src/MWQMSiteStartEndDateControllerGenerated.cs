using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CSSPWebAPI.Controllers
{
    [RoutePrefix("api/mwqmSiteStartEndDate")]
    public partial class MWQMSiteStartEndDateController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MWQMSiteStartEndDateController() : base()
        {
        }
        public MWQMSiteStartEndDateController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/mwqmSiteStartEndDate
        [Route("")]
        public IHttpActionResult GetMWQMSiteStartEndDateList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMSiteStartEndDateService mwqmSiteStartEndDateService = new MWQMSiteStartEndDateService(new Query() { Lang = lang }, db, ContactID);

                else // QueryString has no parameter [extra] or extra is empty
                {
                   mwqmSiteStartEndDateService.Query = mwqmSiteStartEndDateService.FillQuery(typeof(MWQMSiteStartEndDate), lang, skip, take, asc, desc, where, extra);

                    if (mwqmSiteStartEndDateService.Query.HasErrors)
                    {
                        return Ok(new List<MWQMSiteStartEndDate>()
                        {
                            new MWQMSiteStartEndDate()
                            {
                                HasErrors = mwqmSiteStartEndDateService.Query.HasErrors,
                                ValidationResults = mwqmSiteStartEndDateService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(mwqmSiteStartEndDateService.GetMWQMSiteStartEndDateList().ToList());
                    }
                }
            }
        }
        // GET api/mwqmSiteStartEndDate/1
        [Route("{MWQMSiteStartEndDateID:int}")]
        public IHttpActionResult GetMWQMSiteStartEndDateWithID([FromUri]int MWQMSiteStartEndDateID, [FromUri]string lang = "en", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMSiteStartEndDateService mwqmSiteStartEndDateService = new MWQMSiteStartEndDateService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                mwqmSiteStartEndDateService.Query = mwqmSiteStartEndDateService.FillQuery(typeof(MWQMSiteStartEndDate), lang, 0, 1, "", "", extra);

                else
                {
                    MWQMSiteStartEndDate mwqmSiteStartEndDate = new MWQMSiteStartEndDate();
                    mwqmSiteStartEndDate = mwqmSiteStartEndDateService.GetMWQMSiteStartEndDateWithMWQMSiteStartEndDateID(MWQMSiteStartEndDateID);

                    if (mwqmSiteStartEndDate == null)
                    {
                        return NotFound();
                    }

                    return Ok(mwqmSiteStartEndDate);
                }
            }
        }
        // POST api/mwqmSiteStartEndDate
        [Route("")]
        public IHttpActionResult Post([FromBody]MWQMSiteStartEndDate mwqmSiteStartEndDate, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMSiteStartEndDateService mwqmSiteStartEndDateService = new MWQMSiteStartEndDateService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!mwqmSiteStartEndDateService.Add(mwqmSiteStartEndDate))
                {
                    return BadRequest(String.Join("|||", mwqmSiteStartEndDate.ValidationResults));
                }
                else
                {
                    mwqmSiteStartEndDate.ValidationResults = null;
                    return Created<MWQMSiteStartEndDate>(new Uri(Request.RequestUri, mwqmSiteStartEndDate.MWQMSiteStartEndDateID.ToString()), mwqmSiteStartEndDate);
                }
            }
        }
        // PUT api/mwqmSiteStartEndDate
        [Route("")]
        public IHttpActionResult Put([FromBody]MWQMSiteStartEndDate mwqmSiteStartEndDate, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMSiteStartEndDateService mwqmSiteStartEndDateService = new MWQMSiteStartEndDateService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!mwqmSiteStartEndDateService.Update(mwqmSiteStartEndDate))
                {
                    return BadRequest(String.Join("|||", mwqmSiteStartEndDate.ValidationResults));
                }
                else
                {
                    mwqmSiteStartEndDate.ValidationResults = null;
                    return Ok(mwqmSiteStartEndDate);
                }
            }
        }
        // DELETE api/mwqmSiteStartEndDate
        [Route("")]
        public IHttpActionResult Delete([FromBody]MWQMSiteStartEndDate mwqmSiteStartEndDate, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMSiteStartEndDateService mwqmSiteStartEndDateService = new MWQMSiteStartEndDateService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!mwqmSiteStartEndDateService.Delete(mwqmSiteStartEndDate))
                {
                    return BadRequest(String.Join("|||", mwqmSiteStartEndDate.ValidationResults));
                }
                else
                {
                    mwqmSiteStartEndDate.ValidationResults = null;
                    return Ok(mwqmSiteStartEndDate);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
