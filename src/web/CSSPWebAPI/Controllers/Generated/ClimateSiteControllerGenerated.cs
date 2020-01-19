using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;;

namespace CSSPWebAPI.Controllers
{
    [Route("api/climateSite")]
    public partial class ClimateSiteController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ClimateSiteController() : base()
        {
        }
        public ClimateSiteController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/climateSite
        [Route("")]
        public IHttpActionResult GetClimateSiteList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ClimateSiteService climateSiteService = new ClimateSiteService(new Query() { Lang = lang }, db, ContactID);

                else
                {
                   climateSiteService.Query = climateSiteService.FillQuery(typeof(ClimateSite), lang, skip, take, asc, desc, where);

                    if (climateSiteService.Query.HasErrors)
                    {
                        return Ok(new List<ClimateSite>()
                        {
                            new ClimateSite()
                            {
                                HasErrors = climateSiteService.Query.HasErrors,
                                ValidationResults = climateSiteService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(climateSiteService.GetClimateSiteList().ToList());
                    }
                }
            }
        }
        // GET api/climateSite/1
        [Route("{ClimateSiteID:int}")]
        public IHttpActionResult GetClimateSiteWithID([FromUri]int ClimateSiteID, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ClimateSiteService climateSiteService = new ClimateSiteService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                climateSiteService.Query = climateSiteService.FillQuery(typeof(ClimateSite), lang, 0, 1, "", "");

                else
                {
                    ClimateSite climateSite = new ClimateSite();
                    climateSite = climateSiteService.GetClimateSiteWithClimateSiteID(ClimateSiteID);

                    if (climateSite == null)
                    {
                        return NotFound();
                    }

                    return Ok(climateSite);
                }
            }
        }
        // POST api/climateSite
        [Route("")]
        public IHttpActionResult Post([FromBody]ClimateSite climateSite, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ClimateSiteService climateSiteService = new ClimateSiteService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!climateSiteService.Add(climateSite))
                {
                    return BadRequest(String.Join("|||", climateSite.ValidationResults));
                }
                else
                {
                    climateSite.ValidationResults = null;
                    return Created<ClimateSite>(new Uri(Request.RequestUri, climateSite.ClimateSiteID.ToString()), climateSite);
                }
            }
        }
        // PUT api/climateSite
        [Route("")]
        public IHttpActionResult Put([FromBody]ClimateSite climateSite, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ClimateSiteService climateSiteService = new ClimateSiteService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!climateSiteService.Update(climateSite))
                {
                    return BadRequest(String.Join("|||", climateSite.ValidationResults));
                }
                else
                {
                    climateSite.ValidationResults = null;
                    return Ok(climateSite);
                }
            }
        }
        // DELETE api/climateSite
        [Route("")]
        public IHttpActionResult Delete([FromBody]ClimateSite climateSite, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ClimateSiteService climateSiteService = new ClimateSiteService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!climateSiteService.Delete(climateSite))
                {
                    return BadRequest(String.Join("|||", climateSite.ValidationResults));
                }
                else
                {
                    climateSite.ValidationResults = null;
                    return Ok(climateSite);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
