using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSSPWebAPI.Controllers
{
    [Route("api/useOfSite")]
    public partial class UseOfSiteController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public UseOfSiteController() : base()
        {
        }
        public UseOfSiteController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/useOfSite
        [Route("")]
        public IActionResult GetUseOfSiteList([FromQuery]string lang = "en", [FromQuery]int skip = 0, [FromQuery]int take = 200,
            [FromQuery]string asc = "", [FromQuery]string desc = "", [FromQuery]string where = "")
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
        [Route("{UseOfSiteID:int}")]
        public IActionResult GetUseOfSiteWithID([FromQuery]int UseOfSiteID, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                UseOfSiteService useOfSiteService = new UseOfSiteService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

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
        [Route("")]
        public IActionResult Post([FromBody]UseOfSite useOfSite, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                UseOfSiteService useOfSiteService = new UseOfSiteService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!useOfSiteService.Add(useOfSite))
                {
                    return BadRequest(String.Join("|||", useOfSite.ValidationResults));
                }
                else
                {
                    useOfSite.ValidationResults = null;
                    return Created<UseOfSite>(new Uri(Request.RequestUri, useOfSite.UseOfSiteID.ToString()), useOfSite);
                }
            }
        }
        // PUT api/useOfSite
        [Route("")]
        public IActionResult Put([FromBody]UseOfSite useOfSite, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                UseOfSiteService useOfSiteService = new UseOfSiteService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

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
        [Route("")]
        public IActionResult Delete([FromBody]UseOfSite useOfSite, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                UseOfSiteService useOfSiteService = new UseOfSiteService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

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
