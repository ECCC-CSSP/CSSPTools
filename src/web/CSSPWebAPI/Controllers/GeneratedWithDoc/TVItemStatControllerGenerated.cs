using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;;

namespace CSSPWebAPI.Controllers
{
    [Route("api/tvItemStat")]
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
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TVItemStatService tvItemStatService = new TVItemStatService(new Query() { Lang = lang }, db, ContactID);

                else
                {
                   tvItemStatService.Query = tvItemStatService.FillQuery(typeof(TVItemStat), lang, skip, take, asc, desc, where);

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
        public IHttpActionResult GetTVItemStatWithID([FromUri]int TVItemStatID, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TVItemStatService tvItemStatService = new TVItemStatService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                tvItemStatService.Query = tvItemStatService.FillQuery(typeof(TVItemStat), lang, 0, 1, "", "");

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
