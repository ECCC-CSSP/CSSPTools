using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSSPWebAPI.Controllers
{
    [Route("api/mwqmSite")]
    public partial class MWQMSiteController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MWQMSiteController() : base()
        {
        }
        public MWQMSiteController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/mwqmSite
        [Route("")]
        public IActionResult GetMWQMSiteList([FromQuery]string lang = "en", [FromQuery]int skip = 0, [FromQuery]int take = 200,
            [FromQuery]string asc = "", [FromQuery]string desc = "", [FromQuery]string where = "")
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
        [Route("{MWQMSiteID:int}")]
        public IActionResult GetMWQMSiteWithID([FromQuery]int MWQMSiteID, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMSiteService mwqmSiteService = new MWQMSiteService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

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
        [Route("")]
        public IActionResult Post([FromBody]MWQMSite mwqmSite, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMSiteService mwqmSiteService = new MWQMSiteService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

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
        [Route("")]
        public IActionResult Put([FromBody]MWQMSite mwqmSite, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMSiteService mwqmSiteService = new MWQMSiteService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

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
        [Route("")]
        public IActionResult Delete([FromBody]MWQMSite mwqmSite, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMSiteService mwqmSiteService = new MWQMSiteService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

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
