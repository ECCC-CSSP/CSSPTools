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
    public partial class TVFileLanguageController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public TVFileLanguageController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/tvFileLanguage
        [HttpGet]
        public IActionResult GetTVFileLanguageList(string lang = "en", int skip = 0, int take = 200,
            string asc = "", string desc = "", string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TVFileLanguageService tvFileLanguageService = new TVFileLanguageService(new Query() { Lang = lang }, db, ContactID);

                tvFileLanguageService.Query = tvFileLanguageService.FillQuery(typeof(TVFileLanguage), lang, skip, take, asc, desc, where);

                 if (tvFileLanguageService.Query.HasErrors)
                 {
                     return Ok(new List<TVFileLanguage>()
                     {
                         new TVFileLanguage()
                         {
                             HasErrors = tvFileLanguageService.Query.HasErrors,
                             ValidationResults = tvFileLanguageService.Query.ValidationResults,
                         },
                     }.ToList());
                 }
                 else
                 {
                     return Ok(tvFileLanguageService.GetTVFileLanguageList().ToList());
                 }
            }
        }
        // GET api/tvFileLanguage/1
        [HttpGet("{TVFileLanguageID}")]
        public IActionResult GetTVFileLanguageWithID(int TVFileLanguageID, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TVFileLanguageService tvFileLanguageService = new TVFileLanguageService(new Query() { Lang = lang }, db, ContactID);

                tvFileLanguageService.Query = tvFileLanguageService.FillQuery(typeof(TVFileLanguage), lang, 0, 1, "", "");

                TVFileLanguage tvFileLanguage = new TVFileLanguage();
                tvFileLanguage = tvFileLanguageService.GetTVFileLanguageWithTVFileLanguageID(TVFileLanguageID);

                if (tvFileLanguage == null)
                {
                    return NotFound();
                }

                return Ok(tvFileLanguage);
            }
        }
        // POST api/tvFileLanguage
        [HttpPost]
        public IActionResult Post(TVFileLanguage tvFileLanguage, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TVFileLanguageService tvFileLanguageService = new TVFileLanguageService(new Query() { Lang = lang }, db, ContactID);

                if (!tvFileLanguageService.Add(tvFileLanguage))
                {
                    return BadRequest(String.Join("|||", tvFileLanguage.ValidationResults));
                }
                else
                {
                    tvFileLanguage.ValidationResults = null;
                    return Created(Url.ToString(), tvFileLanguage);
                }
            }
        }
        // PUT api/tvFileLanguage
        [HttpPut]
        public IActionResult Put(TVFileLanguage tvFileLanguage, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TVFileLanguageService tvFileLanguageService = new TVFileLanguageService(new Query() { Lang = lang }, db, ContactID);

                if (!tvFileLanguageService.Update(tvFileLanguage))
                {
                    return BadRequest(String.Join("|||", tvFileLanguage.ValidationResults));
                }
                else
                {
                    tvFileLanguage.ValidationResults = null;
                    return Ok(tvFileLanguage);
                }
            }
        }
        // DELETE api/tvFileLanguage
        [HttpDelete]
        public IActionResult Delete(TVFileLanguage tvFileLanguage, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TVFileLanguageService tvFileLanguageService = new TVFileLanguageService(new Query() { Lang = lang }, db, ContactID);

                if (!tvFileLanguageService.Delete(tvFileLanguage))
                {
                    return BadRequest(String.Join("|||", tvFileLanguage.ValidationResults));
                }
                else
                {
                    tvFileLanguage.ValidationResults = null;
                    return Ok(tvFileLanguage);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
