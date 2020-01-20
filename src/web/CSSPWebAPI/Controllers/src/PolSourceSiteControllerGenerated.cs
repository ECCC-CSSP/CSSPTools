using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSSPWebAPI.Controllers
{
    [Route("api/polSourceSite")]
    public partial class PolSourceSiteController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public PolSourceSiteController() : base()
        {
        }
        public PolSourceSiteController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/polSourceSite
        [Route("")]
        public IActionResult GetPolSourceSiteList([FromQuery]string lang = "en", [FromQuery]int skip = 0, [FromQuery]int take = 200,
            [FromQuery]string asc = "", [FromQuery]string desc = "", [FromQuery]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                PolSourceSiteService polSourceSiteService = new PolSourceSiteService(new Query() { Lang = lang }, db, ContactID);

                polSourceSiteService.Query = polSourceSiteService.FillQuery(typeof(PolSourceSite), lang, skip, take, asc, desc, where);

                 if (polSourceSiteService.Query.HasErrors)
                 {
                     return Ok(new List<PolSourceSite>()
                     {
                         new PolSourceSite()
                         {
                             HasErrors = polSourceSiteService.Query.HasErrors,
                             ValidationResults = polSourceSiteService.Query.ValidationResults,
                         },
                     }.ToList());
                 }
                 else
                 {
                     return Ok(polSourceSiteService.GetPolSourceSiteList().ToList());
                 }
            }
        }
        // GET api/polSourceSite/1
        [Route("{PolSourceSiteID:int}")]
        public IActionResult GetPolSourceSiteWithID([FromQuery]int PolSourceSiteID, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                PolSourceSiteService polSourceSiteService = new PolSourceSiteService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                polSourceSiteService.Query = polSourceSiteService.FillQuery(typeof(PolSourceSite), lang, 0, 1, "", "");

                PolSourceSite polSourceSite = new PolSourceSite();
                polSourceSite = polSourceSiteService.GetPolSourceSiteWithPolSourceSiteID(PolSourceSiteID);

                if (polSourceSite == null)
                {
                    return NotFound();
                }

                return Ok(polSourceSite);
            }
        }
        // POST api/polSourceSite
        [Route("")]
        public IActionResult Post([FromBody]PolSourceSite polSourceSite, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                PolSourceSiteService polSourceSiteService = new PolSourceSiteService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!polSourceSiteService.Add(polSourceSite))
                {
                    return BadRequest(String.Join("|||", polSourceSite.ValidationResults));
                }
                else
                {
                    polSourceSite.ValidationResults = null;
                    return Created<PolSourceSite>(new Uri(Request.RequestUri, polSourceSite.PolSourceSiteID.ToString()), polSourceSite);
                }
            }
        }
        // PUT api/polSourceSite
        [Route("")]
        public IActionResult Put([FromBody]PolSourceSite polSourceSite, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                PolSourceSiteService polSourceSiteService = new PolSourceSiteService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!polSourceSiteService.Update(polSourceSite))
                {
                    return BadRequest(String.Join("|||", polSourceSite.ValidationResults));
                }
                else
                {
                    polSourceSite.ValidationResults = null;
                    return Ok(polSourceSite);
                }
            }
        }
        // DELETE api/polSourceSite
        [Route("")]
        public IActionResult Delete([FromBody]PolSourceSite polSourceSite, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                PolSourceSiteService polSourceSiteService = new PolSourceSiteService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!polSourceSiteService.Delete(polSourceSite))
                {
                    return BadRequest(String.Join("|||", polSourceSite.ValidationResults));
                }
                else
                {
                    polSourceSite.ValidationResults = null;
                    return Ok(polSourceSite);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
