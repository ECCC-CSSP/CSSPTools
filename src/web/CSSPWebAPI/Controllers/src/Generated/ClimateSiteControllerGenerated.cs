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

namespace CSSPWebAPI.Controllers
{
    [Route("api/[controller]")]
    public partial class ClimateSiteController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ClimateSiteController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/climateSite
        [HttpGet]
        public IActionResult GetClimateSiteList(string lang = "en", int skip = 0, int take = 200,
            string asc = "", string desc = "", string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ClimateSiteService climateSiteService = new ClimateSiteService(new Query() { Lang = lang }, db, ContactID);

                climateSiteService.Query = climateSiteService.FillQuery(typeof(ClimateSite), lang, skip, take, asc, desc, where);

                 if (climateSiteService.Query.HasErrors)
                 {
                     return Ok(new List<ClimateSite>()
                     {
                         new ClimateSite()
                         {
                             HasErrors = climateSiteService.Query.HasErrors,
                             ValidationResults = climateSiteService.Query.ValidationResults,
                         },
                     }.ToList());
                 }
                 else
                 {
                     return Ok(climateSiteService.GetClimateSiteList().ToList());
                 }
            }
        }
        // GET api/climateSite/1
        [HttpGet("{ClimateSiteID}")]
        public IActionResult GetClimateSiteWithID(int ClimateSiteID, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ClimateSiteService climateSiteService = new ClimateSiteService(new Query() { Lang = lang }, db, ContactID);

                climateSiteService.Query = climateSiteService.FillQuery(typeof(ClimateSite), lang, 0, 1, "", "");

                ClimateSite climateSite = new ClimateSite();
                climateSite = climateSiteService.GetClimateSiteWithClimateSiteID(ClimateSiteID);

                if (climateSite == null)
                {
                    return NotFound();
                }

                return Ok(climateSite);
            }
        }
        // POST api/climateSite
        [HttpPost]
        public IActionResult Post(ClimateSite climateSite, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ClimateSiteService climateSiteService = new ClimateSiteService(new Query() { Lang = lang }, db, ContactID);

                if (!climateSiteService.Add(climateSite))
                {
                    return BadRequest(String.Join("|||", climateSite.ValidationResults));
                }
                else
                {
                    climateSite.ValidationResults = null;
                    return Created(Url.ToString(), climateSite);
                }
            }
        }
        // PUT api/climateSite
        [HttpPut]
        public IActionResult Put(ClimateSite climateSite, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ClimateSiteService climateSiteService = new ClimateSiteService(new Query() { Lang = lang }, db, ContactID);

                if (!climateSiteService.Update(climateSite))
                {
                    return BadRequest(String.Join("|||", climateSite.ValidationResults));
                }
                else
                {
                    climateSite.ValidationResults = null;
                    return Ok(climateSite);
                }
            }
        }
        // DELETE api/climateSite
        [HttpDelete]
        public IActionResult Delete(ClimateSite climateSite, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ClimateSiteService climateSiteService = new ClimateSiteService(new Query() { Lang = lang }, db, ContactID);

                if (!climateSiteService.Delete(climateSite))
                {
                    return BadRequest(String.Join("|||", climateSite.ValidationResults));
                }
                else
                {
                    climateSite.ValidationResults = null;
                    return Ok(climateSite);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
