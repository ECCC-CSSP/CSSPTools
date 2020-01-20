using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSSPWebAPI.Controllers
{
    [Route("api/tvItemLink")]
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
        public IActionResult GetTVItemLinkList([FromQuery]string lang = "en", [FromQuery]int skip = 0, [FromQuery]int take = 200,
            [FromQuery]string asc = "", [FromQuery]string desc = "", [FromQuery]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TVItemLinkService tvItemLinkService = new TVItemLinkService(new Query() { Lang = lang }, db, ContactID);

                tvItemLinkService.Query = tvItemLinkService.FillQuery(typeof(TVItemLink), lang, skip, take, asc, desc, where);

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
        // GET api/tvItemLink/1
        [Route("{TVItemLinkID:int}")]
        public IActionResult GetTVItemLinkWithID([FromQuery]int TVItemLinkID, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TVItemLinkService tvItemLinkService = new TVItemLinkService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                tvItemLinkService.Query = tvItemLinkService.FillQuery(typeof(TVItemLink), lang, 0, 1, "", "");

                TVItemLink tvItemLink = new TVItemLink();
                tvItemLink = tvItemLinkService.GetTVItemLinkWithTVItemLinkID(TVItemLinkID);

                if (tvItemLink == null)
                {
                    return NotFound();
                }

                return Ok(tvItemLink);
            }
        }
        // POST api/tvItemLink
        [Route("")]
        public IActionResult Post([FromBody]TVItemLink tvItemLink, [FromQuery]string lang = "en")
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
        public IActionResult Put([FromBody]TVItemLink tvItemLink, [FromQuery]string lang = "en")
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
        public IActionResult Delete([FromBody]TVItemLink tvItemLink, [FromQuery]string lang = "en")
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
