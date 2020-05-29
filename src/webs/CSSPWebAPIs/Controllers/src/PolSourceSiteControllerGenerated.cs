using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CSSPWebAPI.Controllers
{
    [RoutePrefix("api/polSourceSite")]
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
        public IHttpActionResult GetPolSourceSiteList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                PolSourceSiteService polSourceSiteService = new PolSourceSiteService(new Query() { Lang = lang }, db, ContactID);

                else // QueryString has no parameter [extra] or extra is empty
                {
                   polSourceSiteService.Query = polSourceSiteService.FillQuery(typeof(PolSourceSite), lang, skip, take, asc, desc, where, extra);

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
        }
        // GET api/polSourceSite/1
        [Route("{PolSourceSiteID:int}")]
        public IHttpActionResult GetPolSourceSiteWithID([FromUri]int PolSourceSiteID, [FromUri]string lang = "en", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                PolSourceSiteService polSourceSiteService = new PolSourceSiteService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                polSourceSiteService.Query = polSourceSiteService.FillQuery(typeof(PolSourceSite), lang, 0, 1, "", "", extra);

                else
                {
                    PolSourceSite polSourceSite = new PolSourceSite();
                    polSourceSite = polSourceSiteService.GetPolSourceSiteWithPolSourceSiteID(PolSourceSiteID);

                    if (polSourceSite == null)
                    {
                        return NotFound();
                    }

                    return Ok(polSourceSite);
                }
            }
        }
        // POST api/polSourceSite
        [Route("")]
        public IHttpActionResult Post([FromBody]PolSourceSite polSourceSite, [FromUri]string lang = "en")
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
        public IHttpActionResult Put([FromBody]PolSourceSite polSourceSite, [FromUri]string lang = "en")
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
        public IHttpActionResult Delete([FromBody]PolSourceSite polSourceSite, [FromUri]string lang = "en")
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
