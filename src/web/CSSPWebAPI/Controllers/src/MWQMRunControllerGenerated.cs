using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSSPWebAPI.Controllers
{
    [Route("api/mwqmRun")]
    public partial class MWQMRunController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MWQMRunController() : base()
        {
        }
        public MWQMRunController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/mwqmRun
        [Route("")]
        public IActionResult GetMWQMRunList([FromQuery]string lang = "en", [FromQuery]int skip = 0, [FromQuery]int take = 200,
            [FromQuery]string asc = "", [FromQuery]string desc = "", [FromQuery]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMRunService mwqmRunService = new MWQMRunService(new Query() { Lang = lang }, db, ContactID);

                mwqmRunService.Query = mwqmRunService.FillQuery(typeof(MWQMRun), lang, skip, take, asc, desc, where);

                 if (mwqmRunService.Query.HasErrors)
                 {
                     return Ok(new List<MWQMRun>()
                     {
                         new MWQMRun()
                         {
                             HasErrors = mwqmRunService.Query.HasErrors,
                             ValidationResults = mwqmRunService.Query.ValidationResults,
                         },
                     }.ToList());
                 }
                 else
                 {
                     return Ok(mwqmRunService.GetMWQMRunList().ToList());
                 }
            }
        }
        // GET api/mwqmRun/1
        [Route("{MWQMRunID:int}")]
        public IActionResult GetMWQMRunWithID([FromQuery]int MWQMRunID, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMRunService mwqmRunService = new MWQMRunService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                mwqmRunService.Query = mwqmRunService.FillQuery(typeof(MWQMRun), lang, 0, 1, "", "");

                MWQMRun mwqmRun = new MWQMRun();
                mwqmRun = mwqmRunService.GetMWQMRunWithMWQMRunID(MWQMRunID);

                if (mwqmRun == null)
                {
                    return NotFound();
                }

                return Ok(mwqmRun);
            }
        }
        // POST api/mwqmRun
        [Route("")]
        public IActionResult Post([FromBody]MWQMRun mwqmRun, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMRunService mwqmRunService = new MWQMRunService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!mwqmRunService.Add(mwqmRun))
                {
                    return BadRequest(String.Join("|||", mwqmRun.ValidationResults));
                }
                else
                {
                    mwqmRun.ValidationResults = null;
                    return Created<MWQMRun>(new Uri(Request.RequestUri, mwqmRun.MWQMRunID.ToString()), mwqmRun);
                }
            }
        }
        // PUT api/mwqmRun
        [Route("")]
        public IActionResult Put([FromBody]MWQMRun mwqmRun, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMRunService mwqmRunService = new MWQMRunService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!mwqmRunService.Update(mwqmRun))
                {
                    return BadRequest(String.Join("|||", mwqmRun.ValidationResults));
                }
                else
                {
                    mwqmRun.ValidationResults = null;
                    return Ok(mwqmRun);
                }
            }
        }
        // DELETE api/mwqmRun
        [Route("")]
        public IActionResult Delete([FromBody]MWQMRun mwqmRun, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMRunService mwqmRunService = new MWQMRunService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!mwqmRunService.Delete(mwqmRun))
                {
                    return BadRequest(String.Join("|||", mwqmRun.ValidationResults));
                }
                else
                {
                    mwqmRun.ValidationResults = null;
                    return Ok(mwqmRun);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
