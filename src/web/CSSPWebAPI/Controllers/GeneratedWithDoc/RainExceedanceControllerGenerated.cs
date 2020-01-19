using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;;

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
        public IHttpActionResult GetRainExceedanceList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                RainExceedanceService rainExceedanceService = new RainExceedanceService(new Query() { Lang = lang }, db, ContactID);

                else
                {
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
        }
        // GET api/rainExceedance/1
        [Route("{RainExceedanceID:int}")]
        public IHttpActionResult GetRainExceedanceWithID([FromUri]int RainExceedanceID, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                RainExceedanceService rainExceedanceService = new RainExceedanceService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                rainExceedanceService.Query = rainExceedanceService.FillQuery(typeof(RainExceedance), lang, 0, 1, "", "");

                else
                {
                    RainExceedance rainExceedance = new RainExceedance();
                    rainExceedance = rainExceedanceService.GetRainExceedanceWithRainExceedanceID(RainExceedanceID);

                    if (rainExceedance == null)
                    {
                        return NotFound();
                    }

                    return Ok(rainExceedance);
                }
            }
        }
        // POST api/rainExceedance
        [Route("")]
        public IHttpActionResult Post([FromBody]RainExceedance rainExceedance, [FromUri]string lang = "en")
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
        public IHttpActionResult Put([FromBody]RainExceedance rainExceedance, [FromUri]string lang = "en")
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
        public IHttpActionResult Delete([FromBody]RainExceedance rainExceedance, [FromUri]string lang = "en")
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
