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
    public partial class MWQMSiteController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MWQMSiteController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/mwqmSite
        [HttpGet]
        public IActionResult GetMWQMSiteList(string lang = "en", int skip = 0, int take = 200,
            string asc = "", string desc = "", string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMSiteService mwqmSiteService = new MWQMSiteService(new Query() { Lang = lang }, db, ContactID);

                mwqmSiteService.Query = mwqmSiteService.FillQuery(typeof(MWQMSite), lang, skip, take, asc, desc, where);

                 if (mwqmSiteService.Query.HasErrors)
                 {
                     return Ok(new List<MWQMSite>()
                     {
                         new MWQMSite()
                         {
                             HasErrors = mwqmSiteService.Query.HasErrors,
                             ValidationResults = mwqmSiteService.Query.ValidationResults,
                         },
                     }.ToList());
                 }
                 else
                 {
                     return Ok(mwqmSiteService.GetMWQMSiteList().ToList());
                 }
            }
        }
        // GET api/mwqmSite/1
        [HttpGet("{MWQMSiteID}")]
        public IActionResult GetMWQMSiteWithID(int MWQMSiteID, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMSiteService mwqmSiteService = new MWQMSiteService(new Query() { Lang = lang }, db, ContactID);

                mwqmSiteService.Query = mwqmSiteService.FillQuery(typeof(MWQMSite), lang, 0, 1, "", "");

                MWQMSite mwqmSite = new MWQMSite();
                mwqmSite = mwqmSiteService.GetMWQMSiteWithMWQMSiteID(MWQMSiteID);

                if (mwqmSite == null)
                {
                    return NotFound();
                }

                return Ok(mwqmSite);
            }
        }
        // POST api/mwqmSite
        [HttpPost]
        public IActionResult Post(MWQMSite mwqmSite, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMSiteService mwqmSiteService = new MWQMSiteService(new Query() { Lang = lang }, db, ContactID);

                if (!mwqmSiteService.Add(mwqmSite))
                {
                    return BadRequest(String.Join("|||", mwqmSite.ValidationResults));
                }
                else
                {
                    mwqmSite.ValidationResults = null;
                    return Created(Url.ToString(), mwqmSite);
                }
            }
        }
        // PUT api/mwqmSite
        [HttpPut]
        public IActionResult Put(MWQMSite mwqmSite, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMSiteService mwqmSiteService = new MWQMSiteService(new Query() { Lang = lang }, db, ContactID);

                if (!mwqmSiteService.Update(mwqmSite))
                {
                    return BadRequest(String.Join("|||", mwqmSite.ValidationResults));
                }
                else
                {
                    mwqmSite.ValidationResults = null;
                    return Ok(mwqmSite);
                }
            }
        }
        // DELETE api/mwqmSite
        [HttpDelete]
        public IActionResult Delete(MWQMSite mwqmSite, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMSiteService mwqmSiteService = new MWQMSiteService(new Query() { Lang = lang }, db, ContactID);

                if (!mwqmSiteService.Delete(mwqmSite))
                {
                    return BadRequest(String.Join("|||", mwqmSite.ValidationResults));
                }
                else
                {
                    mwqmSite.ValidationResults = null;
                    return Ok(mwqmSite);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
