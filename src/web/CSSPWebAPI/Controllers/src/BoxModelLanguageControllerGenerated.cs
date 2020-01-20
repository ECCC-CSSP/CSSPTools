using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSSPWebAPI.Controllers
{
    [Route("api/boxModelLanguage")]
    public partial class BoxModelLanguageController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public BoxModelLanguageController() : base()
        {
        }
        public BoxModelLanguageController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/boxModelLanguage
        [Route("")]
        public IActionResult GetBoxModelLanguageList([FromQuery]string lang = "en", [FromQuery]int skip = 0, [FromQuery]int take = 200,
            [FromQuery]string asc = "", [FromQuery]string desc = "", [FromQuery]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                BoxModelLanguageService boxModelLanguageService = new BoxModelLanguageService(new Query() { Lang = lang }, db, ContactID);

                boxModelLanguageService.Query = boxModelLanguageService.FillQuery(typeof(BoxModelLanguage), lang, skip, take, asc, desc, where);

                 if (boxModelLanguageService.Query.HasErrors)
                 {
                     return Ok(new List<BoxModelLanguage>()
                     {
                         new BoxModelLanguage()
                         {
                             HasErrors = boxModelLanguageService.Query.HasErrors,
                             ValidationResults = boxModelLanguageService.Query.ValidationResults,
                         },
                     }.ToList());
                 }
                 else
                 {
                     return Ok(boxModelLanguageService.GetBoxModelLanguageList().ToList());
                 }
            }
        }
        // GET api/boxModelLanguage/1
        [Route("{BoxModelLanguageID:int}")]
        public IActionResult GetBoxModelLanguageWithID([FromQuery]int BoxModelLanguageID, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                BoxModelLanguageService boxModelLanguageService = new BoxModelLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                boxModelLanguageService.Query = boxModelLanguageService.FillQuery(typeof(BoxModelLanguage), lang, 0, 1, "", "");

                BoxModelLanguage boxModelLanguage = new BoxModelLanguage();
                boxModelLanguage = boxModelLanguageService.GetBoxModelLanguageWithBoxModelLanguageID(BoxModelLanguageID);

                if (boxModelLanguage == null)
                {
                    return NotFound();
                }

                return Ok(boxModelLanguage);
            }
        }
        // POST api/boxModelLanguage
        [Route("")]
        public IActionResult Post([FromBody]BoxModelLanguage boxModelLanguage, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                BoxModelLanguageService boxModelLanguageService = new BoxModelLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!boxModelLanguageService.Add(boxModelLanguage))
                {
                    return BadRequest(String.Join("|||", boxModelLanguage.ValidationResults));
                }
                else
                {
                    boxModelLanguage.ValidationResults = null;
                    return Created<BoxModelLanguage>(new Uri(Request.RequestUri, boxModelLanguage.BoxModelLanguageID.ToString()), boxModelLanguage);
                }
            }
        }
        // PUT api/boxModelLanguage
        [Route("")]
        public IActionResult Put([FromBody]BoxModelLanguage boxModelLanguage, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                BoxModelLanguageService boxModelLanguageService = new BoxModelLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!boxModelLanguageService.Update(boxModelLanguage))
                {
                    return BadRequest(String.Join("|||", boxModelLanguage.ValidationResults));
                }
                else
                {
                    boxModelLanguage.ValidationResults = null;
                    return Ok(boxModelLanguage);
                }
            }
        }
        // DELETE api/boxModelLanguage
        [Route("")]
        public IActionResult Delete([FromBody]BoxModelLanguage boxModelLanguage, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                BoxModelLanguageService boxModelLanguageService = new BoxModelLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!boxModelLanguageService.Delete(boxModelLanguage))
                {
                    return BadRequest(String.Join("|||", boxModelLanguage.ValidationResults));
                }
                else
                {
                    boxModelLanguage.ValidationResults = null;
                    return Ok(boxModelLanguage);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
