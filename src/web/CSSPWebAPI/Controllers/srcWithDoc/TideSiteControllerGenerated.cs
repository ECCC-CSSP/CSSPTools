using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSSPWebAPI.Controllers
{
    [Route("api/tideSite")]
    public partial class TideSiteController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public TideSiteController() : base()
        {
        }
        public TideSiteController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/tideSite
        [Route("")]
        public IActionResult GetTideSiteList([FromQuery]string lang = "en", [FromQuery]int skip = 0, [FromQuery]int take = 200,
            [FromQuery]string asc = "", [FromQuery]string desc = "", [FromQuery]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TideSiteService tideSiteService = new TideSiteService(new Query() { Lang = lang }, db, ContactID);

                tideSiteService.Query = tideSiteService.FillQuery(typeof(TideSite), lang, skip, take, asc, desc, where);

                 if (tideSiteService.Query.HasErrors)
                 {
                     return Ok(new List<TideSite>()
                     {
                         new TideSite()
                         {
                             HasErrors = tideSiteService.Query.HasErrors,
                             ValidationResults = tideSiteService.Query.ValidationResults,
                         },
                     }.ToList());
                 }
                 else
                 {
                     return Ok(tideSiteService.GetTideSiteList().ToList());
                 }
            }
        }
        // GET api/tideSite/1
        [Route("{TideSiteID:int}")]
        public IActionResult GetTideSiteWithID([FromQuery]int TideSiteID, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TideSiteService tideSiteService = new TideSiteService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                tideSiteService.Query = tideSiteService.FillQuery(typeof(TideSite), lang, 0, 1, "", "");

                TideSite tideSite = new TideSite();
                tideSite = tideSiteService.GetTideSiteWithTideSiteID(TideSiteID);

                if (tideSite == null)
                {
                    return NotFound();
                }

                return Ok(tideSite);
            }
        }
        // POST api/tideSite
        [Route("")]
        public IActionResult Post([FromBody]TideSite tideSite, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TideSiteService tideSiteService = new TideSiteService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!tideSiteService.Add(tideSite))
                {
                    return BadRequest(String.Join("|||", tideSite.ValidationResults));
                }
                else
                {
                    tideSite.ValidationResults = null;
                    return Created(Url.ToString(), tideSite);
                }
            }
        }
        // PUT api/tideSite
        [Route("")]
        public IActionResult Put([FromBody]TideSite tideSite, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TideSiteService tideSiteService = new TideSiteService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!tideSiteService.Update(tideSite))
                {
                    return BadRequest(String.Join("|||", tideSite.ValidationResults));
                }
                else
                {
                    tideSite.ValidationResults = null;
                    return Ok(tideSite);
                }
            }
        }
        // DELETE api/tideSite
        [Route("")]
        public IActionResult Delete([FromBody]TideSite tideSite, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TideSiteService tideSiteService = new TideSiteService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!tideSiteService.Delete(tideSite))
                {
                    return BadRequest(String.Join("|||", tideSite.ValidationResults));
                }
                else
                {
                    tideSite.ValidationResults = null;
                    return Ok(tideSite);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
