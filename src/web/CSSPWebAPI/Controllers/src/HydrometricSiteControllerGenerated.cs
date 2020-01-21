using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSSPWebAPI.Controllers
{
    [Route("api/hydrometricSite")]
    public partial class HydrometricSiteController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public HydrometricSiteController() : base()
        {
        }
        public HydrometricSiteController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/hydrometricSite
        [Route("")]
        public IActionResult GetHydrometricSiteList([FromQuery]string lang = "en", [FromQuery]int skip = 0, [FromQuery]int take = 200,
            [FromQuery]string asc = "", [FromQuery]string desc = "", [FromQuery]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                HydrometricSiteService hydrometricSiteService = new HydrometricSiteService(new Query() { Lang = lang }, db, ContactID);

                hydrometricSiteService.Query = hydrometricSiteService.FillQuery(typeof(HydrometricSite), lang, skip, take, asc, desc, where);

                 if (hydrometricSiteService.Query.HasErrors)
                 {
                     return Ok(new List<HydrometricSite>()
                     {
                         new HydrometricSite()
                         {
                             HasErrors = hydrometricSiteService.Query.HasErrors,
                             ValidationResults = hydrometricSiteService.Query.ValidationResults,
                         },
                     }.ToList());
                 }
                 else
                 {
                     return Ok(hydrometricSiteService.GetHydrometricSiteList().ToList());
                 }
            }
        }
        // GET api/hydrometricSite/1
        [Route("{HydrometricSiteID:int}")]
        public IActionResult GetHydrometricSiteWithID([FromQuery]int HydrometricSiteID, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                HydrometricSiteService hydrometricSiteService = new HydrometricSiteService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                hydrometricSiteService.Query = hydrometricSiteService.FillQuery(typeof(HydrometricSite), lang, 0, 1, "", "");

                HydrometricSite hydrometricSite = new HydrometricSite();
                hydrometricSite = hydrometricSiteService.GetHydrometricSiteWithHydrometricSiteID(HydrometricSiteID);

                if (hydrometricSite == null)
                {
                    return NotFound();
                }

                return Ok(hydrometricSite);
            }
        }
        // POST api/hydrometricSite
        [Route("")]
        public IActionResult Post([FromBody]HydrometricSite hydrometricSite, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                HydrometricSiteService hydrometricSiteService = new HydrometricSiteService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!hydrometricSiteService.Add(hydrometricSite))
                {
                    return BadRequest(String.Join("|||", hydrometricSite.ValidationResults));
                }
                else
                {
                    hydrometricSite.ValidationResults = null;
                    return Created(Url.ToString(), hydrometricSite);
                }
            }
        }
        // PUT api/hydrometricSite
        [Route("")]
        public IActionResult Put([FromBody]HydrometricSite hydrometricSite, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                HydrometricSiteService hydrometricSiteService = new HydrometricSiteService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!hydrometricSiteService.Update(hydrometricSite))
                {
                    return BadRequest(String.Join("|||", hydrometricSite.ValidationResults));
                }
                else
                {
                    hydrometricSite.ValidationResults = null;
                    return Ok(hydrometricSite);
                }
            }
        }
        // DELETE api/hydrometricSite
        [Route("")]
        public IActionResult Delete([FromBody]HydrometricSite hydrometricSite, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                HydrometricSiteService hydrometricSiteService = new HydrometricSiteService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!hydrometricSiteService.Delete(hydrometricSite))
                {
                    return BadRequest(String.Join("|||", hydrometricSite.ValidationResults));
                }
                else
                {
                    hydrometricSite.ValidationResults = null;
                    return Ok(hydrometricSite);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
