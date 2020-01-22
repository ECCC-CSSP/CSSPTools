using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSSPWebAPI.Controllers
{
    [Route("api/rainExceedanceClimateSite")]
    public partial class RainExceedanceClimateSiteController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public RainExceedanceClimateSiteController() : base()
        {
        }
        public RainExceedanceClimateSiteController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/rainExceedanceClimateSite
        [Route("")]
        public IActionResult GetRainExceedanceClimateSiteList([FromQuery]string lang = "en", [FromQuery]int skip = 0, [FromQuery]int take = 200,
            [FromQuery]string asc = "", [FromQuery]string desc = "", [FromQuery]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                RainExceedanceClimateSiteService rainExceedanceClimateSiteService = new RainExceedanceClimateSiteService(new Query() { Lang = lang }, db, ContactID);

                rainExceedanceClimateSiteService.Query = rainExceedanceClimateSiteService.FillQuery(typeof(RainExceedanceClimateSite), lang, skip, take, asc, desc, where);

                 if (rainExceedanceClimateSiteService.Query.HasErrors)
                 {
                     return Ok(new List<RainExceedanceClimateSite>()
                     {
                         new RainExceedanceClimateSite()
                         {
                             HasErrors = rainExceedanceClimateSiteService.Query.HasErrors,
                             ValidationResults = rainExceedanceClimateSiteService.Query.ValidationResults,
                         },
                     }.ToList());
                 }
                 else
                 {
                     return Ok(rainExceedanceClimateSiteService.GetRainExceedanceClimateSiteList().ToList());
                 }
            }
        }
        // GET api/rainExceedanceClimateSite/1
        [Route("{RainExceedanceClimateSiteID:int}")]
        public IActionResult GetRainExceedanceClimateSiteWithID([FromQuery]int RainExceedanceClimateSiteID, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                RainExceedanceClimateSiteService rainExceedanceClimateSiteService = new RainExceedanceClimateSiteService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                rainExceedanceClimateSiteService.Query = rainExceedanceClimateSiteService.FillQuery(typeof(RainExceedanceClimateSite), lang, 0, 1, "", "");

                RainExceedanceClimateSite rainExceedanceClimateSite = new RainExceedanceClimateSite();
                rainExceedanceClimateSite = rainExceedanceClimateSiteService.GetRainExceedanceClimateSiteWithRainExceedanceClimateSiteID(RainExceedanceClimateSiteID);

                if (rainExceedanceClimateSite == null)
                {
                    return NotFound();
                }

                return Ok(rainExceedanceClimateSite);
            }
        }
        // POST api/rainExceedanceClimateSite
        [Route("")]
        public IActionResult Post([FromBody]RainExceedanceClimateSite rainExceedanceClimateSite, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                RainExceedanceClimateSiteService rainExceedanceClimateSiteService = new RainExceedanceClimateSiteService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!rainExceedanceClimateSiteService.Add(rainExceedanceClimateSite))
                {
                    return BadRequest(String.Join("|||", rainExceedanceClimateSite.ValidationResults));
                }
                else
                {
                    rainExceedanceClimateSite.ValidationResults = null;
                    return Created(Url.ToString(), rainExceedanceClimateSite);
                }
            }
        }
        // PUT api/rainExceedanceClimateSite
        [Route("")]
        public IActionResult Put([FromBody]RainExceedanceClimateSite rainExceedanceClimateSite, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                RainExceedanceClimateSiteService rainExceedanceClimateSiteService = new RainExceedanceClimateSiteService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!rainExceedanceClimateSiteService.Update(rainExceedanceClimateSite))
                {
                    return BadRequest(String.Join("|||", rainExceedanceClimateSite.ValidationResults));
                }
                else
                {
                    rainExceedanceClimateSite.ValidationResults = null;
                    return Ok(rainExceedanceClimateSite);
                }
            }
        }
        // DELETE api/rainExceedanceClimateSite
        [Route("")]
        public IActionResult Delete([FromBody]RainExceedanceClimateSite rainExceedanceClimateSite, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                RainExceedanceClimateSiteService rainExceedanceClimateSiteService = new RainExceedanceClimateSiteService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!rainExceedanceClimateSiteService.Delete(rainExceedanceClimateSite))
                {
                    return BadRequest(String.Join("|||", rainExceedanceClimateSite.ValidationResults));
                }
                else
                {
                    rainExceedanceClimateSite.ValidationResults = null;
                    return Ok(rainExceedanceClimateSite);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
