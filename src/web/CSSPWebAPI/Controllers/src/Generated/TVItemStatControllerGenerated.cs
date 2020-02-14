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
    public partial class TVItemStatController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public TVItemStatController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/tvItemStat
        [HttpGet]
        public IActionResult GetTVItemStatList(string lang = "en", int skip = 0, int take = 200,
            string asc = "", string desc = "", string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TVItemStatService tvItemStatService = new TVItemStatService(new Query() { Lang = lang }, db, ContactID);

                tvItemStatService.Query = tvItemStatService.FillQuery(typeof(TVItemStat), lang, skip, take, asc, desc, where);

                 if (tvItemStatService.Query.HasErrors)
                 {
                     return Ok(new List<TVItemStat>()
                     {
                         new TVItemStat()
                         {
                             HasErrors = tvItemStatService.Query.HasErrors,
                             ValidationResults = tvItemStatService.Query.ValidationResults,
                         },
                     }.ToList());
                 }
                 else
                 {
                     return Ok(tvItemStatService.GetTVItemStatList().ToList());
                 }
            }
        }
        // GET api/tvItemStat/1
        [HttpGet("{TVItemStatID}")]
        public IActionResult GetTVItemStatWithID(int TVItemStatID, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TVItemStatService tvItemStatService = new TVItemStatService(new Query() { Lang = lang }, db, ContactID);

                tvItemStatService.Query = tvItemStatService.FillQuery(typeof(TVItemStat), lang, 0, 1, "", "");

                TVItemStat tvItemStat = new TVItemStat();
                tvItemStat = tvItemStatService.GetTVItemStatWithTVItemStatID(TVItemStatID);

                if (tvItemStat == null)
                {
                    return NotFound();
                }

                return Ok(tvItemStat);
            }
        }
        // POST api/tvItemStat
        [HttpPost]
        public IActionResult Post(TVItemStat tvItemStat, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TVItemStatService tvItemStatService = new TVItemStatService(new Query() { Lang = lang }, db, ContactID);

                if (!tvItemStatService.Add(tvItemStat))
                {
                    return BadRequest(String.Join("|||", tvItemStat.ValidationResults));
                }
                else
                {
                    tvItemStat.ValidationResults = null;
                    return Created("/api/tvItemStat/" + tvItemStat.TVItemStatID, tvItemStat);
                }
            }
        }
        // PUT api/tvItemStat
        [HttpPut]
        public IActionResult Put(TVItemStat tvItemStat, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TVItemStatService tvItemStatService = new TVItemStatService(new Query() { Lang = lang }, db, ContactID);

                if (!tvItemStatService.Update(tvItemStat))
                {
                    return BadRequest(String.Join("|||", tvItemStat.ValidationResults));
                }
                else
                {
                    tvItemStat.ValidationResults = null;
                    return Ok(tvItemStat);
                }
            }
        }
        // DELETE api/tvItemStat
        [HttpDelete]
        public IActionResult Delete(TVItemStat tvItemStat, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TVItemStatService tvItemStatService = new TVItemStatService(new Query() { Lang = lang }, db, ContactID);

                if (!tvItemStatService.Delete(tvItemStat))
                {
                    return BadRequest(String.Join("|||", tvItemStat.ValidationResults));
                }
                else
                {
                    tvItemStat.ValidationResults = null;
                    return Ok(tvItemStat);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
