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
    public partial class UseOfSiteController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public UseOfSiteController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/useOfSite
        [HttpGet]
        public IActionResult GetUseOfSiteList(string lang = "en", int skip = 0, int take = 200,
            string asc = "", string desc = "", string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                UseOfSiteService useOfSiteService = new UseOfSiteService(new Query() { Lang = lang }, db, ContactID);

                useOfSiteService.Query = useOfSiteService.FillQuery(typeof(UseOfSite), lang, skip, take, asc, desc, where);

                 if (useOfSiteService.Query.HasErrors)
                 {
                     return Ok(new List<UseOfSite>()
                     {
                         new UseOfSite()
                         {
                             HasErrors = useOfSiteService.Query.HasErrors,
                             ValidationResults = useOfSiteService.Query.ValidationResults,
                         },
                     }.ToList());
                 }
                 else
                 {
                     return Ok(useOfSiteService.GetUseOfSiteList().ToList());
                 }
            }
        }
        // GET api/useOfSite/1
        [HttpGet("{UseOfSiteID}")]
        public IActionResult GetUseOfSiteWithID(int UseOfSiteID, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                UseOfSiteService useOfSiteService = new UseOfSiteService(new Query() { Lang = lang }, db, ContactID);

                useOfSiteService.Query = useOfSiteService.FillQuery(typeof(UseOfSite), lang, 0, 1, "", "");

                UseOfSite useOfSite = new UseOfSite();
                useOfSite = useOfSiteService.GetUseOfSiteWithUseOfSiteID(UseOfSiteID);

                if (useOfSite == null)
                {
                    return NotFound();
                }

                return Ok(useOfSite);
            }
        }
        // POST api/useOfSite
        [HttpPost]
        public IActionResult Post(UseOfSite useOfSite, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                UseOfSiteService useOfSiteService = new UseOfSiteService(new Query() { Lang = lang }, db, ContactID);

                if (!useOfSiteService.Add(useOfSite))
                {
                    return BadRequest(String.Join("|||", useOfSite.ValidationResults));
                }
                else
                {
                    useOfSite.ValidationResults = null;
                    return Created("/api/useOfSite/" + useOfSite.UseOfSiteID, useOfSite);
                }
            }
        }
        // PUT api/useOfSite
        [HttpPut]
        public IActionResult Put(UseOfSite useOfSite, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                UseOfSiteService useOfSiteService = new UseOfSiteService(new Query() { Lang = lang }, db, ContactID);

                if (!useOfSiteService.Update(useOfSite))
                {
                    return BadRequest(String.Join("|||", useOfSite.ValidationResults));
                }
                else
                {
                    useOfSite.ValidationResults = null;
                    return Ok(useOfSite);
                }
            }
        }
        // DELETE api/useOfSite
        [HttpDelete]
        public IActionResult Delete(UseOfSite useOfSite, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                UseOfSiteService useOfSiteService = new UseOfSiteService(new Query() { Lang = lang }, db, ContactID);

                if (!useOfSiteService.Delete(useOfSite))
                {
                    return BadRequest(String.Join("|||", useOfSite.ValidationResults));
                }
                else
                {
                    useOfSite.ValidationResults = null;
                    return Ok(useOfSite);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}