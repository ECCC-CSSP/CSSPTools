using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSSPWebAPI.Controllers
{
    [Route("api/mwqmRunLanguage")]
    public partial class MWQMRunLanguageController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MWQMRunLanguageController() : base()
        {
        }
        public MWQMRunLanguageController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/mwqmRunLanguage
        [Route("")]
        public IActionResult GetMWQMRunLanguageList([FromQuery]string lang = "en", [FromQuery]int skip = 0, [FromQuery]int take = 200,
            [FromQuery]string asc = "", [FromQuery]string desc = "", [FromQuery]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMRunLanguageService mwqmRunLanguageService = new MWQMRunLanguageService(new Query() { Lang = lang }, db, ContactID);

                mwqmRunLanguageService.Query = mwqmRunLanguageService.FillQuery(typeof(MWQMRunLanguage), lang, skip, take, asc, desc, where);

                 if (mwqmRunLanguageService.Query.HasErrors)
                 {
                     return Ok(new List<MWQMRunLanguage>()
                     {
                         new MWQMRunLanguage()
                         {
                             HasErrors = mwqmRunLanguageService.Query.HasErrors,
                             ValidationResults = mwqmRunLanguageService.Query.ValidationResults,
                         },
                     }.ToList());
                 }
                 else
                 {
                     return Ok(mwqmRunLanguageService.GetMWQMRunLanguageList().ToList());
                 }
            }
        }
        // GET api/mwqmRunLanguage/1
        [Route("{MWQMRunLanguageID:int}")]
        public IActionResult GetMWQMRunLanguageWithID([FromQuery]int MWQMRunLanguageID, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMRunLanguageService mwqmRunLanguageService = new MWQMRunLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                mwqmRunLanguageService.Query = mwqmRunLanguageService.FillQuery(typeof(MWQMRunLanguage), lang, 0, 1, "", "");

                MWQMRunLanguage mwqmRunLanguage = new MWQMRunLanguage();
                mwqmRunLanguage = mwqmRunLanguageService.GetMWQMRunLanguageWithMWQMRunLanguageID(MWQMRunLanguageID);

                if (mwqmRunLanguage == null)
                {
                    return NotFound();
                }

                return Ok(mwqmRunLanguage);
            }
        }
        // POST api/mwqmRunLanguage
        [Route("")]
        public IActionResult Post([FromBody]MWQMRunLanguage mwqmRunLanguage, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMRunLanguageService mwqmRunLanguageService = new MWQMRunLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!mwqmRunLanguageService.Add(mwqmRunLanguage))
                {
                    return BadRequest(String.Join("|||", mwqmRunLanguage.ValidationResults));
                }
                else
                {
                    mwqmRunLanguage.ValidationResults = null;
                    return Created(Url.ToString(), mwqmRunLanguage);
                }
            }
        }
        // PUT api/mwqmRunLanguage
        [Route("")]
        public IActionResult Put([FromBody]MWQMRunLanguage mwqmRunLanguage, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMRunLanguageService mwqmRunLanguageService = new MWQMRunLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!mwqmRunLanguageService.Update(mwqmRunLanguage))
                {
                    return BadRequest(String.Join("|||", mwqmRunLanguage.ValidationResults));
                }
                else
                {
                    mwqmRunLanguage.ValidationResults = null;
                    return Ok(mwqmRunLanguage);
                }
            }
        }
        // DELETE api/mwqmRunLanguage
        [Route("")]
        public IActionResult Delete([FromBody]MWQMRunLanguage mwqmRunLanguage, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMRunLanguageService mwqmRunLanguageService = new MWQMRunLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!mwqmRunLanguageService.Delete(mwqmRunLanguage))
                {
                    return BadRequest(String.Join("|||", mwqmRunLanguage.ValidationResults));
                }
                else
                {
                    mwqmRunLanguage.ValidationResults = null;
                    return Ok(mwqmRunLanguage);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
