using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CSSPWebAPI.Controllers
{
    [RoutePrefix("api/hydrometricSite")]
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
        public IHttpActionResult GetHydrometricSiteList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                HydrometricSiteService hydrometricSiteService = new HydrometricSiteService(new Query() { Lang = lang }, db, ContactID);

                if (extra == "A") // QueryString contains [extra=A]
                {
                   hydrometricSiteService.Query = hydrometricSiteService.FillQuery(typeof(HydrometricSiteExtraA), lang, skip, take, asc, desc, where, extra);

                    if (hydrometricSiteService.Query.HasErrors)
                    {
                        return Ok(new List<HydrometricSiteExtraA>()
                        {
                            new HydrometricSiteExtraA()
                            {
                                HasErrors = hydrometricSiteService.Query.HasErrors,
                                ValidationResults = hydrometricSiteService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(hydrometricSiteService.GetHydrometricSiteExtraAList().ToList());
                    }
                }
                else if (extra == "B") // QueryString contains [extra=B]
                {
                   hydrometricSiteService.Query = hydrometricSiteService.FillQuery(typeof(HydrometricSiteExtraB), lang, skip, take, asc, desc, where, extra);

                    if (hydrometricSiteService.Query.HasErrors)
                    {
                        return Ok(new List<HydrometricSiteExtraB>()
                        {
                            new HydrometricSiteExtraB()
                            {
                                HasErrors = hydrometricSiteService.Query.HasErrors,
                                ValidationResults = hydrometricSiteService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(hydrometricSiteService.GetHydrometricSiteExtraBList().ToList());
                    }
                }
                else // QueryString has no parameter [extra] or extra is empty
                {
                   hydrometricSiteService.Query = hydrometricSiteService.FillQuery(typeof(HydrometricSite), lang, skip, take, asc, desc, where, extra);

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
        }
        // GET api/hydrometricSite/1
        [Route("{HydrometricSiteID:int}")]
        public IHttpActionResult GetHydrometricSiteWithID([FromUri]int HydrometricSiteID, [FromUri]string lang = "en", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                HydrometricSiteService hydrometricSiteService = new HydrometricSiteService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                hydrometricSiteService.Query = hydrometricSiteService.FillQuery(typeof(HydrometricSite), lang, 0, 1, "", "", extra);

                if (hydrometricSiteService.Query.Extra == "A")
                {
                    HydrometricSiteExtraA hydrometricSiteExtraA = new HydrometricSiteExtraA();
                    hydrometricSiteExtraA = hydrometricSiteService.GetHydrometricSiteExtraAWithHydrometricSiteID(HydrometricSiteID);

                    if (hydrometricSiteExtraA == null)
                    {
                        return NotFound();
                    }

                    return Ok(hydrometricSiteExtraA);
                }
                else if (hydrometricSiteService.Query.Extra == "B")
                {
                    HydrometricSiteExtraB hydrometricSiteExtraB = new HydrometricSiteExtraB();
                    hydrometricSiteExtraB = hydrometricSiteService.GetHydrometricSiteExtraBWithHydrometricSiteID(HydrometricSiteID);

                    if (hydrometricSiteExtraB == null)
                    {
                        return NotFound();
                    }

                    return Ok(hydrometricSiteExtraB);
                }
                else
                {
                    HydrometricSite hydrometricSite = new HydrometricSite();
                    hydrometricSite = hydrometricSiteService.GetHydrometricSiteWithHydrometricSiteID(HydrometricSiteID);

                    if (hydrometricSite == null)
                    {
                        return NotFound();
                    }

                    return Ok(hydrometricSite);
                }
            }
        }
        // POST api/hydrometricSite
        [Route("")]
        public IHttpActionResult Post([FromBody]HydrometricSite hydrometricSite, [FromUri]string lang = "en")
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
                    return Created<HydrometricSite>(new Uri(Request.RequestUri, hydrometricSite.HydrometricSiteID.ToString()), hydrometricSite);
                }
            }
        }
        // PUT api/hydrometricSite
        [Route("")]
        public IHttpActionResult Put([FromBody]HydrometricSite hydrometricSite, [FromUri]string lang = "en")
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
        public IHttpActionResult Delete([FromBody]HydrometricSite hydrometricSite, [FromUri]string lang = "en")
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
