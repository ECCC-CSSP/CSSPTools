using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;;

namespace CSSPWebAPI.Controllers
{
    [Route("api/tideSite")]
    public partial class TideSiteController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public TideSiteController() : base()
        {
        }
        public TideSiteController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/tideSite
        [Route("")]
        public IHttpActionResult GetTideSiteList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TideSiteService tideSiteService = new TideSiteService(new Query() { Lang = lang }, db, ContactID);

                else
                {
                   tideSiteService.Query = tideSiteService.FillQuery(typeof(TideSite), lang, skip, take, asc, desc, where);

                    if (tideSiteService.Query.HasErrors)
                    {
                        return Ok(new List<TideSite>()
                        {
                            new TideSite()
                            {
                                HasErrors = tideSiteService.Query.HasErrors,
                                ValidationResults = tideSiteService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(tideSiteService.GetTideSiteList().ToList());
                    }
                }
            }
        }
        // GET api/tideSite/1
        [Route("{TideSiteID:int}")]
        public IHttpActionResult GetTideSiteWithID([FromUri]int TideSiteID, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TideSiteService tideSiteService = new TideSiteService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                tideSiteService.Query = tideSiteService.FillQuery(typeof(TideSite), lang, 0, 1, "", "");

                else
                {
                    TideSite tideSite = new TideSite();
                    tideSite = tideSiteService.GetTideSiteWithTideSiteID(TideSiteID);

                    if (tideSite == null)
                    {
                        return NotFound();
                    }

                    return Ok(tideSite);
                }
            }
        }
        // POST api/tideSite
        [Route("")]
        public IHttpActionResult Post([FromBody]TideSite tideSite, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TideSiteService tideSiteService = new TideSiteService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!tideSiteService.Add(tideSite))
                {
                    return BadRequest(String.Join("|||", tideSite.ValidationResults));
                }
                else
                {
                    tideSite.ValidationResults = null;
                    return Created<TideSite>(new Uri(Request.RequestUri, tideSite.TideSiteID.ToString()), tideSite);
                }
            }
        }
        // PUT api/tideSite
        [Route("")]
        public IHttpActionResult Put([FromBody]TideSite tideSite, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TideSiteService tideSiteService = new TideSiteService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!tideSiteService.Update(tideSite))
                {
                    return BadRequest(String.Join("|||", tideSite.ValidationResults));
                }
                else
                {
                    tideSite.ValidationResults = null;
                    return Ok(tideSite);
                }
            }
        }
        // DELETE api/tideSite
        [Route("")]
        public IHttpActionResult Delete([FromBody]TideSite tideSite, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TideSiteService tideSiteService = new TideSiteService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!tideSiteService.Delete(tideSite))
                {
                    return BadRequest(String.Join("|||", tideSite.ValidationResults));
                }
                else
                {
                    tideSite.ValidationResults = null;
                    return Ok(tideSite);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
