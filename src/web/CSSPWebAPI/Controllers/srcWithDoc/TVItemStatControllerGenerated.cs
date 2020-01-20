using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CSSPWebAPI.Controllers
{
    [RoutePrefix("api/tvItemStat")]
    public partial class TVItemStatController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public TVItemStatController() : base()
        {
        }
        public TVItemStatController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/tvItemStat
        [Route("")]
        public IHttpActionResult GetTVItemStatList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TVItemStatService tvItemStatService = new TVItemStatService(new Query() { Lang = lang }, db, ContactID);

                if (extra == "A") // QueryString contains [extra=A]
                {
                   tvItemStatService.Query = tvItemStatService.FillQuery(typeof(TVItemStatExtraA), lang, skip, take, asc, desc, where, extra);

                    if (tvItemStatService.Query.HasErrors)
                    {
                        return Ok(new List<TVItemStatExtraA>()
                        {
                            new TVItemStatExtraA()
                            {
                                HasErrors = tvItemStatService.Query.HasErrors,
                                ValidationResults = tvItemStatService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(tvItemStatService.GetTVItemStatExtraAList().ToList());
                    }
                }
                else if (extra == "B") // QueryString contains [extra=B]
                {
                   tvItemStatService.Query = tvItemStatService.FillQuery(typeof(TVItemStatExtraB), lang, skip, take, asc, desc, where, extra);

                    if (tvItemStatService.Query.HasErrors)
                    {
                        return Ok(new List<TVItemStatExtraB>()
                        {
                            new TVItemStatExtraB()
                            {
                                HasErrors = tvItemStatService.Query.HasErrors,
                                ValidationResults = tvItemStatService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(tvItemStatService.GetTVItemStatExtraBList().ToList());
                    }
                }
                else // QueryString has no parameter [extra] or extra is empty
                {
                   tvItemStatService.Query = tvItemStatService.FillQuery(typeof(TVItemStat), lang, skip, take, asc, desc, where, extra);

                    if (tvItemStatService.Query.HasErrors)
                    {
                        return Ok(new List<TVItemStat>()
                        {
                            new TVItemStat()
                            {
                                HasErrors = tvItemStatService.Query.HasErrors,
                                ValidationResults = tvItemStatService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(tvItemStatService.GetTVItemStatList().ToList());
                    }
                }
            }
        }
        // GET api/tvItemStat/1
        [Route("{TVItemStatID:int}")]
        public IHttpActionResult GetTVItemStatWithID([FromUri]int TVItemStatID, [FromUri]string lang = "en", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TVItemStatService tvItemStatService = new TVItemStatService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                tvItemStatService.Query = tvItemStatService.FillQuery(typeof(TVItemStat), lang, 0, 1, "", "", extra);

                if (tvItemStatService.Query.Extra == "A")
                {
                    TVItemStatExtraA tvItemStatExtraA = new TVItemStatExtraA();
                    tvItemStatExtraA = tvItemStatService.GetTVItemStatExtraAWithTVItemStatID(TVItemStatID);

                    if (tvItemStatExtraA == null)
                    {
                        return NotFound();
                    }

                    return Ok(tvItemStatExtraA);
                }
                else if (tvItemStatService.Query.Extra == "B")
                {
                    TVItemStatExtraB tvItemStatExtraB = new TVItemStatExtraB();
                    tvItemStatExtraB = tvItemStatService.GetTVItemStatExtraBWithTVItemStatID(TVItemStatID);

                    if (tvItemStatExtraB == null)
                    {
                        return NotFound();
                    }

                    return Ok(tvItemStatExtraB);
                }
                else
                {
                    TVItemStat tvItemStat = new TVItemStat();
                    tvItemStat = tvItemStatService.GetTVItemStatWithTVItemStatID(TVItemStatID);

                    if (tvItemStat == null)
                    {
                        return NotFound();
                    }

                    return Ok(tvItemStat);
                }
            }
        }
        // POST api/tvItemStat
        [Route("")]
        public IHttpActionResult Post([FromBody]TVItemStat tvItemStat, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TVItemStatService tvItemStatService = new TVItemStatService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!tvItemStatService.Add(tvItemStat))
                {
                    return BadRequest(String.Join("|||", tvItemStat.ValidationResults));
                }
                else
                {
                    tvItemStat.ValidationResults = null;
                    return Created<TVItemStat>(new Uri(Request.RequestUri, tvItemStat.TVItemStatID.ToString()), tvItemStat);
                }
            }
        }
        // PUT api/tvItemStat
        [Route("")]
        public IHttpActionResult Put([FromBody]TVItemStat tvItemStat, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TVItemStatService tvItemStatService = new TVItemStatService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!tvItemStatService.Update(tvItemStat))
                {
                    return BadRequest(String.Join("|||", tvItemStat.ValidationResults));
                }
                else
                {
                    tvItemStat.ValidationResults = null;
                    return Ok(tvItemStat);
                }
            }
        }
        // DELETE api/tvItemStat
        [Route("")]
        public IHttpActionResult Delete([FromBody]TVItemStat tvItemStat, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TVItemStatService tvItemStatService = new TVItemStatService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!tvItemStatService.Delete(tvItemStat))
                {
                    return BadRequest(String.Join("|||", tvItemStat.ValidationResults));
                }
                else
                {
                    tvItemStat.ValidationResults = null;
                    return Ok(tvItemStat);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
