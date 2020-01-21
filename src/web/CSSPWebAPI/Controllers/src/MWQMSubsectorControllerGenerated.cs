using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSSPWebAPI.Controllers
{
    [Route("api/mwqmSubsector")]
    public partial class MWQMSubsectorController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MWQMSubsectorController() : base()
        {
        }
        public MWQMSubsectorController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/mwqmSubsector
        [Route("")]
        public IActionResult GetMWQMSubsectorList([FromQuery]string lang = "en", [FromQuery]int skip = 0, [FromQuery]int take = 200,
            [FromQuery]string asc = "", [FromQuery]string desc = "", [FromQuery]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMSubsectorService mwqmSubsectorService = new MWQMSubsectorService(new Query() { Lang = lang }, db, ContactID);

                mwqmSubsectorService.Query = mwqmSubsectorService.FillQuery(typeof(MWQMSubsector), lang, skip, take, asc, desc, where);

                 if (mwqmSubsectorService.Query.HasErrors)
                 {
                     return Ok(new List<MWQMSubsector>()
                     {
                         new MWQMSubsector()
                         {
                             HasErrors = mwqmSubsectorService.Query.HasErrors,
                             ValidationResults = mwqmSubsectorService.Query.ValidationResults,
                         },
                     }.ToList());
                 }
                 else
                 {
                     return Ok(mwqmSubsectorService.GetMWQMSubsectorList().ToList());
                 }
            }
        }
        // GET api/mwqmSubsector/1
        [Route("{MWQMSubsectorID:int}")]
        public IActionResult GetMWQMSubsectorWithID([FromQuery]int MWQMSubsectorID, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMSubsectorService mwqmSubsectorService = new MWQMSubsectorService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                mwqmSubsectorService.Query = mwqmSubsectorService.FillQuery(typeof(MWQMSubsector), lang, 0, 1, "", "");

                MWQMSubsector mwqmSubsector = new MWQMSubsector();
                mwqmSubsector = mwqmSubsectorService.GetMWQMSubsectorWithMWQMSubsectorID(MWQMSubsectorID);

                if (mwqmSubsector == null)
                {
                    return NotFound();
                }

                return Ok(mwqmSubsector);
            }
        }
        // POST api/mwqmSubsector
        [Route("")]
        public IActionResult Post([FromBody]MWQMSubsector mwqmSubsector, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMSubsectorService mwqmSubsectorService = new MWQMSubsectorService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!mwqmSubsectorService.Add(mwqmSubsector))
                {
                    return BadRequest(String.Join("|||", mwqmSubsector.ValidationResults));
                }
                else
                {
                    mwqmSubsector.ValidationResults = null;
                    return Created(Url.ToString(), mwqmSubsector);
                }
            }
        }
        // PUT api/mwqmSubsector
        [Route("")]
        public IActionResult Put([FromBody]MWQMSubsector mwqmSubsector, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMSubsectorService mwqmSubsectorService = new MWQMSubsectorService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!mwqmSubsectorService.Update(mwqmSubsector))
                {
                    return BadRequest(String.Join("|||", mwqmSubsector.ValidationResults));
                }
                else
                {
                    mwqmSubsector.ValidationResults = null;
                    return Ok(mwqmSubsector);
                }
            }
        }
        // DELETE api/mwqmSubsector
        [Route("")]
        public IActionResult Delete([FromBody]MWQMSubsector mwqmSubsector, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMSubsectorService mwqmSubsectorService = new MWQMSubsectorService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!mwqmSubsectorService.Delete(mwqmSubsector))
                {
                    return BadRequest(String.Join("|||", mwqmSubsector.ValidationResults));
                }
                else
                {
                    mwqmSubsector.ValidationResults = null;
                    return Ok(mwqmSubsector);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
