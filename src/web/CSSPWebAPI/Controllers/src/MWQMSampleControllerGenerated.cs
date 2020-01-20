using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSSPWebAPI.Controllers
{
    [Route("api/mwqmSample")]
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
        public IActionResult GetMWQMSampleList([FromQuery]string lang = "en", [FromQuery]int skip = 0, [FromQuery]int take = 200,
            [FromQuery]string asc = "", [FromQuery]string desc = "", [FromQuery]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMSampleService mwqmSampleService = new MWQMSampleService(new Query() { Lang = lang }, db, ContactID);

                mwqmSampleService.Query = mwqmSampleService.FillQuery(typeof(MWQMSample), lang, skip, take, asc, desc, where);

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
        // GET api/mwqmSample/1
        [Route("{MWQMSampleID:int}")]
        public IActionResult GetMWQMSampleWithID([FromQuery]int MWQMSampleID, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMSampleService mwqmSampleService = new MWQMSampleService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                mwqmSampleService.Query = mwqmSampleService.FillQuery(typeof(MWQMSample), lang, 0, 1, "", "");

                MWQMSample mwqmSample = new MWQMSample();
                mwqmSample = mwqmSampleService.GetMWQMSampleWithMWQMSampleID(MWQMSampleID);

                if (mwqmSample == null)
                {
                    return NotFound();
                }

                return Ok(mwqmSample);
            }
        }
        // POST api/mwqmSample
        [Route("")]
        public IActionResult Post([FromBody]MWQMSample mwqmSample, [FromQuery]string lang = "en")
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
        public IActionResult Put([FromBody]MWQMSample mwqmSample, [FromQuery]string lang = "en")
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
        public IActionResult Delete([FromBody]MWQMSample mwqmSample, [FromQuery]string lang = "en")
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
