using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSSPWebAPI.Controllers
{
    [Route("api/mwqmSampleLanguage")]
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
        public IActionResult GetMWQMSampleLanguageList([FromQuery]string lang = "en", [FromQuery]int skip = 0, [FromQuery]int take = 200,
            [FromQuery]string asc = "", [FromQuery]string desc = "", [FromQuery]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMSampleLanguageService mwqmSampleLanguageService = new MWQMSampleLanguageService(new Query() { Lang = lang }, db, ContactID);

                mwqmSampleLanguageService.Query = mwqmSampleLanguageService.FillQuery(typeof(MWQMSampleLanguage), lang, skip, take, asc, desc, where);

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
        // GET api/mwqmSampleLanguage/1
        [Route("{MWQMSampleLanguageID:int}")]
        public IActionResult GetMWQMSampleLanguageWithID([FromQuery]int MWQMSampleLanguageID, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMSampleLanguageService mwqmSampleLanguageService = new MWQMSampleLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                mwqmSampleLanguageService.Query = mwqmSampleLanguageService.FillQuery(typeof(MWQMSampleLanguage), lang, 0, 1, "", "");

                MWQMSampleLanguage mwqmSampleLanguage = new MWQMSampleLanguage();
                mwqmSampleLanguage = mwqmSampleLanguageService.GetMWQMSampleLanguageWithMWQMSampleLanguageID(MWQMSampleLanguageID);

                if (mwqmSampleLanguage == null)
                {
                    return NotFound();
                }

                return Ok(mwqmSampleLanguage);
            }
        }
        // POST api/mwqmSampleLanguage
        [Route("")]
        public IActionResult Post([FromBody]MWQMSampleLanguage mwqmSampleLanguage, [FromQuery]string lang = "en")
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
                    return Created(Url.ToString(), mwqmSampleLanguage);
                }
            }
        }
        // PUT api/mwqmSampleLanguage
        [Route("")]
        public IActionResult Put([FromBody]MWQMSampleLanguage mwqmSampleLanguage, [FromQuery]string lang = "en")
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
        public IActionResult Delete([FromBody]MWQMSampleLanguage mwqmSampleLanguage, [FromQuery]string lang = "en")
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
