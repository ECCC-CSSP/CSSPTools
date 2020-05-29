using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CSSPWebAPI.Controllers
{
    [RoutePrefix("api/tvItem")]
    public partial class TVItemController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public TVItemController() : base()
        {
        }
        public TVItemController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/tvItem
        [Route("")]
        public IHttpActionResult GetTVItemList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TVItemService tvItemService = new TVItemService(new Query() { Lang = lang }, db, ContactID);

                else // QueryString has no parameter [extra] or extra is empty
                {
                   tvItemService.Query = tvItemService.FillQuery(typeof(TVItem), lang, skip, take, asc, desc, where, extra);

                    if (tvItemService.Query.HasErrors)
                    {
                        return Ok(new List<TVItem>()
                        {
                            new TVItem()
                            {
                                HasErrors = tvItemService.Query.HasErrors,
                                ValidationResults = tvItemService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(tvItemService.GetTVItemList().ToList());
                    }
                }
            }
        }
        // GET api/tvItem/1
        [Route("{TVItemID:int}")]
        public IHttpActionResult GetTVItemWithID([FromUri]int TVItemID, [FromUri]string lang = "en", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TVItemService tvItemService = new TVItemService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                tvItemService.Query = tvItemService.FillQuery(typeof(TVItem), lang, 0, 1, "", "", extra);

                else
                {
                    TVItem tvItem = new TVItem();
                    tvItem = tvItemService.GetTVItemWithTVItemID(TVItemID);

                    if (tvItem == null)
                    {
                        return NotFound();
                    }

                    return Ok(tvItem);
                }
            }
        }
        // POST api/tvItem
        [Route("")]
        public IHttpActionResult Post([FromBody]TVItem tvItem, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TVItemService tvItemService = new TVItemService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!tvItemService.Add(tvItem))
                {
                    return BadRequest(String.Join("|||", tvItem.ValidationResults));
                }
                else
                {
                    tvItem.ValidationResults = null;
                    return Created<TVItem>(new Uri(Request.RequestUri, tvItem.TVItemID.ToString()), tvItem);
                }
            }
        }
        // PUT api/tvItem
        [Route("")]
        public IHttpActionResult Put([FromBody]TVItem tvItem, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TVItemService tvItemService = new TVItemService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!tvItemService.Update(tvItem))
                {
                    return BadRequest(String.Join("|||", tvItem.ValidationResults));
                }
                else
                {
                    tvItem.ValidationResults = null;
                    return Ok(tvItem);
                }
            }
        }
        // DELETE api/tvItem
        [Route("")]
        public IHttpActionResult Delete([FromBody]TVItem tvItem, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TVItemService tvItemService = new TVItemService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!tvItemService.Delete(tvItem))
                {
                    return BadRequest(String.Join("|||", tvItem.ValidationResults));
                }
                else
                {
                    tvItem.ValidationResults = null;
                    return Ok(tvItem);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
