using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSSPWebAPI.Controllers
{
    [Route("api/rainExceedance")]
    public partial class RainExceedanceController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public RainExceedanceController() : base()
        {
        }
        public RainExceedanceController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/rainExceedance
        [Route("")]
        public IActionResult GetRainExceedanceList([FromQuery]string lang = "en", [FromQuery]int skip = 0, [FromQuery]int take = 200,
            [FromQuery]string asc = "", [FromQuery]string desc = "", [FromQuery]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                RainExceedanceService rainExceedanceService = new RainExceedanceService(new Query() { Lang = lang }, db, ContactID);

                rainExceedanceService.Query = rainExceedanceService.FillQuery(typeof(RainExceedance), lang, skip, take, asc, desc, where);

                 if (rainExceedanceService.Query.HasErrors)
                 {
                     return Ok(new List<RainExceedance>()
                     {
                         new RainExceedance()
                         {
                             HasErrors = rainExceedanceService.Query.HasErrors,
                             ValidationResults = rainExceedanceService.Query.ValidationResults,
                         },
                     }.ToList());
                 }
                 else
                 {
                     return Ok(rainExceedanceService.GetRainExceedanceList().ToList());
                 }
            }
        }
        // GET api/rainExceedance/1
        [Route("{RainExceedanceID:int}")]
        public IActionResult GetRainExceedanceWithID([FromQuery]int RainExceedanceID, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                RainExceedanceService rainExceedanceService = new RainExceedanceService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                rainExceedanceService.Query = rainExceedanceService.FillQuery(typeof(RainExceedance), lang, 0, 1, "", "");

                RainExceedance rainExceedance = new RainExceedance();
                rainExceedance = rainExceedanceService.GetRainExceedanceWithRainExceedanceID(RainExceedanceID);

                if (rainExceedance == null)
                {
                    return NotFound();
                }

                return Ok(rainExceedance);
            }
        }
        // POST api/rainExceedance
        [Route("")]
        public IActionResult Post([FromBody]RainExceedance rainExceedance, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                RainExceedanceService rainExceedanceService = new RainExceedanceService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!rainExceedanceService.Add(rainExceedance))
                {
                    return BadRequest(String.Join("|||", rainExceedance.ValidationResults));
                }
                else
                {
                    rainExceedance.ValidationResults = null;
                    return Created<RainExceedance>(new Uri(Request.RequestUri, rainExceedance.RainExceedanceID.ToString()), rainExceedance);
                }
            }
        }
        // PUT api/rainExceedance
        [Route("")]
        public IActionResult Put([FromBody]RainExceedance rainExceedance, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                RainExceedanceService rainExceedanceService = new RainExceedanceService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!rainExceedanceService.Update(rainExceedance))
                {
                    return BadRequest(String.Join("|||", rainExceedance.ValidationResults));
                }
                else
                {
                    rainExceedance.ValidationResults = null;
                    return Ok(rainExceedance);
                }
            }
        }
        // DELETE api/rainExceedance
        [Route("")]
        public IActionResult Delete([FromBody]RainExceedance rainExceedance, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                RainExceedanceService rainExceedanceService = new RainExceedanceService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!rainExceedanceService.Delete(rainExceedance))
                {
                    return BadRequest(String.Join("|||", rainExceedance.ValidationResults));
                }
                else
                {
                    rainExceedance.ValidationResults = null;
                    return Ok(rainExceedance);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
