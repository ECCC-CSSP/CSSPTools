using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSSPWebAPI.Controllers
{
    [Route("api/tvItem")]
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
        public IActionResult GetTVItemList([FromQuery]string lang = "en", [FromQuery]int skip = 0, [FromQuery]int take = 200,
            [FromQuery]string asc = "", [FromQuery]string desc = "", [FromQuery]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TVItemService tvItemService = new TVItemService(new Query() { Lang = lang }, db, ContactID);

                tvItemService.Query = tvItemService.FillQuery(typeof(TVItem), lang, skip, take, asc, desc, where);

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
        // GET api/tvItem/1
        [Route("{TVItemID:int}")]
        public IActionResult GetTVItemWithID([FromQuery]int TVItemID, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TVItemService tvItemService = new TVItemService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                tvItemService.Query = tvItemService.FillQuery(typeof(TVItem), lang, 0, 1, "", "");

                TVItem tvItem = new TVItem();
                tvItem = tvItemService.GetTVItemWithTVItemID(TVItemID);

                if (tvItem == null)
                {
                    return NotFound();
                }

                return Ok(tvItem);
            }
        }
        // POST api/tvItem
        [Route("")]
        public IActionResult Post([FromBody]TVItem tvItem, [FromQuery]string lang = "en")
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
                    return Created(Url.ToString(), tvItem);
                }
            }
        }
        // PUT api/tvItem
        [Route("")]
        public IActionResult Put([FromBody]TVItem tvItem, [FromQuery]string lang = "en")
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
        public IActionResult Delete([FromBody]TVItem tvItem, [FromQuery]string lang = "en")
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
