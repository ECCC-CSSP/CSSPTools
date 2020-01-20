using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CSSPWebAPI.Controllers
{
    [RoutePrefix("api/tvItemLink")]
    public partial class TVItemLinkController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public TVItemLinkController() : base()
        {
        }
        public TVItemLinkController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/tvItemLink
        [Route("")]
        public IHttpActionResult GetTVItemLinkList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TVItemLinkService tvItemLinkService = new TVItemLinkService(new Query() { Lang = lang }, db, ContactID);

                if (extra == "A") // QueryString contains [extra=A]
                {
                   tvItemLinkService.Query = tvItemLinkService.FillQuery(typeof(TVItemLinkExtraA), lang, skip, take, asc, desc, where, extra);

                    if (tvItemLinkService.Query.HasErrors)
                    {
                        return Ok(new List<TVItemLinkExtraA>()
                        {
                            new TVItemLinkExtraA()
                            {
                                HasErrors = tvItemLinkService.Query.HasErrors,
                                ValidationResults = tvItemLinkService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(tvItemLinkService.GetTVItemLinkExtraAList().ToList());
                    }
                }
                else if (extra == "B") // QueryString contains [extra=B]
                {
                   tvItemLinkService.Query = tvItemLinkService.FillQuery(typeof(TVItemLinkExtraB), lang, skip, take, asc, desc, where, extra);

                    if (tvItemLinkService.Query.HasErrors)
                    {
                        return Ok(new List<TVItemLinkExtraB>()
                        {
                            new TVItemLinkExtraB()
                            {
                                HasErrors = tvItemLinkService.Query.HasErrors,
                                ValidationResults = tvItemLinkService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(tvItemLinkService.GetTVItemLinkExtraBList().ToList());
                    }
                }
                else // QueryString has no parameter [extra] or extra is empty
                {
                   tvItemLinkService.Query = tvItemLinkService.FillQuery(typeof(TVItemLink), lang, skip, take, asc, desc, where, extra);

                    if (tvItemLinkService.Query.HasErrors)
                    {
                        return Ok(new List<TVItemLink>()
                        {
                            new TVItemLink()
                            {
                                HasErrors = tvItemLinkService.Query.HasErrors,
                                ValidationResults = tvItemLinkService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(tvItemLinkService.GetTVItemLinkList().ToList());
                    }
                }
            }
        }
        // GET api/tvItemLink/1
        [Route("{TVItemLinkID:int}")]
        public IHttpActionResult GetTVItemLinkWithID([FromUri]int TVItemLinkID, [FromUri]string lang = "en", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TVItemLinkService tvItemLinkService = new TVItemLinkService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                tvItemLinkService.Query = tvItemLinkService.FillQuery(typeof(TVItemLink), lang, 0, 1, "", "", extra);

                if (tvItemLinkService.Query.Extra == "A")
                {
                    TVItemLinkExtraA tvItemLinkExtraA = new TVItemLinkExtraA();
                    tvItemLinkExtraA = tvItemLinkService.GetTVItemLinkExtraAWithTVItemLinkID(TVItemLinkID);

                    if (tvItemLinkExtraA == null)
                    {
                        return NotFound();
                    }

                    return Ok(tvItemLinkExtraA);
                }
                else if (tvItemLinkService.Query.Extra == "B")
                {
                    TVItemLinkExtraB tvItemLinkExtraB = new TVItemLinkExtraB();
                    tvItemLinkExtraB = tvItemLinkService.GetTVItemLinkExtraBWithTVItemLinkID(TVItemLinkID);

                    if (tvItemLinkExtraB == null)
                    {
                        return NotFound();
                    }

                    return Ok(tvItemLinkExtraB);
                }
                else
                {
                    TVItemLink tvItemLink = new TVItemLink();
                    tvItemLink = tvItemLinkService.GetTVItemLinkWithTVItemLinkID(TVItemLinkID);

                    if (tvItemLink == null)
                    {
                        return NotFound();
                    }

                    return Ok(tvItemLink);
                }
            }
        }
        // POST api/tvItemLink
        [Route("")]
        public IHttpActionResult Post([FromBody]TVItemLink tvItemLink, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TVItemLinkService tvItemLinkService = new TVItemLinkService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!tvItemLinkService.Add(tvItemLink))
                {
                    return BadRequest(String.Join("|||", tvItemLink.ValidationResults));
                }
                else
                {
                    tvItemLink.ValidationResults = null;
                    return Created<TVItemLink>(new Uri(Request.RequestUri, tvItemLink.TVItemLinkID.ToString()), tvItemLink);
                }
            }
        }
        // PUT api/tvItemLink
        [Route("")]
        public IHttpActionResult Put([FromBody]TVItemLink tvItemLink, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TVItemLinkService tvItemLinkService = new TVItemLinkService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!tvItemLinkService.Update(tvItemLink))
                {
                    return BadRequest(String.Join("|||", tvItemLink.ValidationResults));
                }
                else
                {
                    tvItemLink.ValidationResults = null;
                    return Ok(tvItemLink);
                }
            }
        }
        // DELETE api/tvItemLink
        [Route("")]
        public IHttpActionResult Delete([FromBody]TVItemLink tvItemLink, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TVItemLinkService tvItemLinkService = new TVItemLinkService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!tvItemLinkService.Delete(tvItemLink))
                {
                    return BadRequest(String.Join("|||", tvItemLink.ValidationResults));
                }
                else
                {
                    tvItemLink.ValidationResults = null;
                    return Ok(tvItemLink);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
