using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSSPWebAPI.Controllers
{
    [Route("api/appTaskLanguage")]
    public partial class AppTaskLanguageController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public AppTaskLanguageController() : base()
        {
        }
        public AppTaskLanguageController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/appTaskLanguage
        [Route("")]
        public IActionResult GetAppTaskLanguageList([FromQuery]string lang = "en", [FromQuery]int skip = 0, [FromQuery]int take = 200,
            [FromQuery]string asc = "", [FromQuery]string desc = "", [FromQuery]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                AppTaskLanguageService appTaskLanguageService = new AppTaskLanguageService(new Query() { Lang = lang }, db, ContactID);

                appTaskLanguageService.Query = appTaskLanguageService.FillQuery(typeof(AppTaskLanguage), lang, skip, take, asc, desc, where);

                 if (appTaskLanguageService.Query.HasErrors)
                 {
                     return Ok(new List<AppTaskLanguage>()
                     {
                         new AppTaskLanguage()
                         {
                             HasErrors = appTaskLanguageService.Query.HasErrors,
                             ValidationResults = appTaskLanguageService.Query.ValidationResults,
                         },
                     }.ToList());
                 }
                 else
                 {
                     return Ok(appTaskLanguageService.GetAppTaskLanguageList().ToList());
                 }
            }
        }
        // GET api/appTaskLanguage/1
        [Route("{AppTaskLanguageID:int}")]
        public IActionResult GetAppTaskLanguageWithID([FromQuery]int AppTaskLanguageID, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                AppTaskLanguageService appTaskLanguageService = new AppTaskLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                appTaskLanguageService.Query = appTaskLanguageService.FillQuery(typeof(AppTaskLanguage), lang, 0, 1, "", "");

                AppTaskLanguage appTaskLanguage = new AppTaskLanguage();
                appTaskLanguage = appTaskLanguageService.GetAppTaskLanguageWithAppTaskLanguageID(AppTaskLanguageID);

                if (appTaskLanguage == null)
                {
                    return NotFound();
                }

                return Ok(appTaskLanguage);
            }
        }
        // POST api/appTaskLanguage
        [Route("")]
        public IActionResult Post([FromBody]AppTaskLanguage appTaskLanguage, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                AppTaskLanguageService appTaskLanguageService = new AppTaskLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!appTaskLanguageService.Add(appTaskLanguage))
                {
                    return BadRequest(String.Join("|||", appTaskLanguage.ValidationResults));
                }
                else
                {
                    appTaskLanguage.ValidationResults = null;
                    return Created<AppTaskLanguage>(new Uri(Request.RequestUri, appTaskLanguage.AppTaskLanguageID.ToString()), appTaskLanguage);
                }
            }
        }
        // PUT api/appTaskLanguage
        [Route("")]
        public IActionResult Put([FromBody]AppTaskLanguage appTaskLanguage, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                AppTaskLanguageService appTaskLanguageService = new AppTaskLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!appTaskLanguageService.Update(appTaskLanguage))
                {
                    return BadRequest(String.Join("|||", appTaskLanguage.ValidationResults));
                }
                else
                {
                    appTaskLanguage.ValidationResults = null;
                    return Ok(appTaskLanguage);
                }
            }
        }
        // DELETE api/appTaskLanguage
        [Route("")]
        public IActionResult Delete([FromBody]AppTaskLanguage appTaskLanguage, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                AppTaskLanguageService appTaskLanguageService = new AppTaskLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!appTaskLanguageService.Delete(appTaskLanguage))
                {
                    return BadRequest(String.Join("|||", appTaskLanguage.ValidationResults));
                }
                else
                {
                    appTaskLanguage.ValidationResults = null;
                    return Ok(appTaskLanguage);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
