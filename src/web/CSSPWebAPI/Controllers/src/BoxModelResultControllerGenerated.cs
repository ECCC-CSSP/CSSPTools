using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSSPWebAPI.Controllers
{
    [Route("api/boxModelResult")]
    public partial class BoxModelResultController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public BoxModelResultController() : base()
        {
        }
        public BoxModelResultController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/boxModelResult
        [Route("")]
        public IActionResult GetBoxModelResultList([FromQuery]string lang = "en", [FromQuery]int skip = 0, [FromQuery]int take = 200,
            [FromQuery]string asc = "", [FromQuery]string desc = "", [FromQuery]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                BoxModelResultService boxModelResultService = new BoxModelResultService(new Query() { Lang = lang }, db, ContactID);

                boxModelResultService.Query = boxModelResultService.FillQuery(typeof(BoxModelResult), lang, skip, take, asc, desc, where);

                 if (boxModelResultService.Query.HasErrors)
                 {
                     return Ok(new List<BoxModelResult>()
                     {
                         new BoxModelResult()
                         {
                             HasErrors = boxModelResultService.Query.HasErrors,
                             ValidationResults = boxModelResultService.Query.ValidationResults,
                         },
                     }.ToList());
                 }
                 else
                 {
                     return Ok(boxModelResultService.GetBoxModelResultList().ToList());
                 }
            }
        }
        // GET api/boxModelResult/1
        [Route("{BoxModelResultID:int}")]
        public IActionResult GetBoxModelResultWithID([FromQuery]int BoxModelResultID, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                BoxModelResultService boxModelResultService = new BoxModelResultService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                boxModelResultService.Query = boxModelResultService.FillQuery(typeof(BoxModelResult), lang, 0, 1, "", "");

                BoxModelResult boxModelResult = new BoxModelResult();
                boxModelResult = boxModelResultService.GetBoxModelResultWithBoxModelResultID(BoxModelResultID);

                if (boxModelResult == null)
                {
                    return NotFound();
                }

                return Ok(boxModelResult);
            }
        }
        // POST api/boxModelResult
        [Route("")]
        public IActionResult Post([FromBody]BoxModelResult boxModelResult, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                BoxModelResultService boxModelResultService = new BoxModelResultService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!boxModelResultService.Add(boxModelResult))
                {
                    return BadRequest(String.Join("|||", boxModelResult.ValidationResults));
                }
                else
                {
                    boxModelResult.ValidationResults = null;
                    return Created(Url.ToString(), boxModelResult);
                }
            }
        }
        // PUT api/boxModelResult
        [Route("")]
        public IActionResult Put([FromBody]BoxModelResult boxModelResult, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                BoxModelResultService boxModelResultService = new BoxModelResultService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!boxModelResultService.Update(boxModelResult))
                {
                    return BadRequest(String.Join("|||", boxModelResult.ValidationResults));
                }
                else
                {
                    boxModelResult.ValidationResults = null;
                    return Ok(boxModelResult);
                }
            }
        }
        // DELETE api/boxModelResult
        [Route("")]
        public IActionResult Delete([FromBody]BoxModelResult boxModelResult, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                BoxModelResultService boxModelResultService = new BoxModelResultService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!boxModelResultService.Delete(boxModelResult))
                {
                    return BadRequest(String.Join("|||", boxModelResult.ValidationResults));
                }
                else
                {
                    boxModelResult.ValidationResults = null;
                    return Ok(boxModelResult);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
