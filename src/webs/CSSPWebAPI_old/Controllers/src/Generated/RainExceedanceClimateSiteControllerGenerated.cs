/*
 * Auto generated from the CSSPCodeWriter.proj by clicking on the [[ModelClassName]ControllerGenerated.cs] button
 *
 * Do not edit this file.
 *
 */ 

using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using CSSPWebAPI.Controllers.Resources;

namespace CSSPWebAPI.Controllers
{
    [Route("api/[controller]")]
    public partial class RainExceedanceClimateSiteController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public RainExceedanceClimateSiteController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/rainExceedanceClimateSite
        [HttpGet]
        public IActionResult GetRainExceedanceClimateSiteList(string lang = "en", int skip = 0, int take = 200,
            string asc = "", string desc = "", string where = "")
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
        [HttpGet("{RainExceedanceClimateSiteID}")]
        public IActionResult GetRainExceedanceClimateSiteWithID(int RainExceedanceClimateSiteID, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                RainExceedanceClimateSiteService rainExceedanceClimateSiteService = new RainExceedanceClimateSiteService(new Query() { Lang = lang }, db, ContactID);

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
        [HttpPost]
        public IActionResult Post(RainExceedanceClimateSite rainExceedanceClimateSite, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                RainExceedanceClimateSiteService rainExceedanceClimateSiteService = new RainExceedanceClimateSiteService(new Query() { Lang = lang }, db, ContactID);

                if (!rainExceedanceClimateSiteService.Add(rainExceedanceClimateSite))
                {
                    return BadRequest(String.Join("|||", rainExceedanceClimateSite.ValidationResults));
                }
                else
                {
                    rainExceedanceClimateSite.ValidationResults = null;
                    return Created("/api/rainExceedanceClimateSite/" + rainExceedanceClimateSite.RainExceedanceClimateSiteID, rainExceedanceClimateSite);
                }
            }
        }
        // PUT api/rainExceedanceClimateSite
        [HttpPut]
        public IActionResult Put(RainExceedanceClimateSite rainExceedanceClimateSite, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                RainExceedanceClimateSiteService rainExceedanceClimateSiteService = new RainExceedanceClimateSiteService(new Query() { Lang = lang }, db, ContactID);

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
        [HttpDelete]
        public IActionResult Delete(RainExceedanceClimateSite rainExceedanceClimateSite, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                RainExceedanceClimateSiteService rainExceedanceClimateSiteService = new RainExceedanceClimateSiteService(new Query() { Lang = lang }, db, ContactID);

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