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
    public partial class MWQMSubsectorLanguageController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MWQMSubsectorLanguageController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/mwqmSubsectorLanguage
        [HttpGet]
        public IActionResult GetMWQMSubsectorLanguageList(string lang = "en", int skip = 0, int take = 200,
            string asc = "", string desc = "", string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMSubsectorLanguageService mwqmSubsectorLanguageService = new MWQMSubsectorLanguageService(new Query() { Lang = lang }, db, ContactID);

                mwqmSubsectorLanguageService.Query = mwqmSubsectorLanguageService.FillQuery(typeof(MWQMSubsectorLanguage), lang, skip, take, asc, desc, where);

                 if (mwqmSubsectorLanguageService.Query.HasErrors)
                 {
                     return Ok(new List<MWQMSubsectorLanguage>()
                     {
                         new MWQMSubsectorLanguage()
                         {
                             HasErrors = mwqmSubsectorLanguageService.Query.HasErrors,
                             ValidationResults = mwqmSubsectorLanguageService.Query.ValidationResults,
                         },
                     }.ToList());
                 }
                 else
                 {
                     return Ok(mwqmSubsectorLanguageService.GetMWQMSubsectorLanguageList().ToList());
                 }
            }
        }
        // GET api/mwqmSubsectorLanguage/1
        [HttpGet("{MWQMSubsectorLanguageID}")]
        public IActionResult GetMWQMSubsectorLanguageWithID(int MWQMSubsectorLanguageID, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMSubsectorLanguageService mwqmSubsectorLanguageService = new MWQMSubsectorLanguageService(new Query() { Lang = lang }, db, ContactID);

                mwqmSubsectorLanguageService.Query = mwqmSubsectorLanguageService.FillQuery(typeof(MWQMSubsectorLanguage), lang, 0, 1, "", "");

                MWQMSubsectorLanguage mwqmSubsectorLanguage = new MWQMSubsectorLanguage();
                mwqmSubsectorLanguage = mwqmSubsectorLanguageService.GetMWQMSubsectorLanguageWithMWQMSubsectorLanguageID(MWQMSubsectorLanguageID);

                if (mwqmSubsectorLanguage == null)
                {
                    return NotFound();
                }

                return Ok(mwqmSubsectorLanguage);
            }
        }
        // POST api/mwqmSubsectorLanguage
        [HttpPost]
        public IActionResult Post(MWQMSubsectorLanguage mwqmSubsectorLanguage, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMSubsectorLanguageService mwqmSubsectorLanguageService = new MWQMSubsectorLanguageService(new Query() { Lang = lang }, db, ContactID);

                if (!mwqmSubsectorLanguageService.Add(mwqmSubsectorLanguage))
                {
                    return BadRequest(String.Join("|||", mwqmSubsectorLanguage.ValidationResults));
                }
                else
                {
                    mwqmSubsectorLanguage.ValidationResults = null;
                    return Created("/api/mwqmSubsectorLanguage/" + mwqmSubsectorLanguage.MWQMSubsectorLanguageID, mwqmSubsectorLanguage);
                }
            }
        }
        // PUT api/mwqmSubsectorLanguage
        [HttpPut]
        public IActionResult Put(MWQMSubsectorLanguage mwqmSubsectorLanguage, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMSubsectorLanguageService mwqmSubsectorLanguageService = new MWQMSubsectorLanguageService(new Query() { Lang = lang }, db, ContactID);

                if (!mwqmSubsectorLanguageService.Update(mwqmSubsectorLanguage))
                {
                    return BadRequest(String.Join("|||", mwqmSubsectorLanguage.ValidationResults));
                }
                else
                {
                    mwqmSubsectorLanguage.ValidationResults = null;
                    return Ok(mwqmSubsectorLanguage);
                }
            }
        }
        // DELETE api/mwqmSubsectorLanguage
        [HttpDelete]
        public IActionResult Delete(MWQMSubsectorLanguage mwqmSubsectorLanguage, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMSubsectorLanguageService mwqmSubsectorLanguageService = new MWQMSubsectorLanguageService(new Query() { Lang = lang }, db, ContactID);

                if (!mwqmSubsectorLanguageService.Delete(mwqmSubsectorLanguage))
                {
                    return BadRequest(String.Join("|||", mwqmSubsectorLanguage.ValidationResults));
                }
                else
                {
                    mwqmSubsectorLanguage.ValidationResults = null;
                    return Ok(mwqmSubsectorLanguage);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}