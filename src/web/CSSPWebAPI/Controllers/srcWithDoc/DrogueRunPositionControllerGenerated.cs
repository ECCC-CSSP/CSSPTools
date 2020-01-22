using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSSPWebAPI.Controllers
{
    [Route("api/drogueRunPosition")]
    public partial class DrogueRunPositionController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public DrogueRunPositionController() : base()
        {
        }
        public DrogueRunPositionController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/drogueRunPosition
        [Route("")]
        public IActionResult GetDrogueRunPositionList([FromQuery]string lang = "en", [FromQuery]int skip = 0, [FromQuery]int take = 200,
            [FromQuery]string asc = "", [FromQuery]string desc = "", [FromQuery]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                DrogueRunPositionService drogueRunPositionService = new DrogueRunPositionService(new Query() { Lang = lang }, db, ContactID);

                drogueRunPositionService.Query = drogueRunPositionService.FillQuery(typeof(DrogueRunPosition), lang, skip, take, asc, desc, where);

                 if (drogueRunPositionService.Query.HasErrors)
                 {
                     return Ok(new List<DrogueRunPosition>()
                     {
                         new DrogueRunPosition()
                         {
                             HasErrors = drogueRunPositionService.Query.HasErrors,
                             ValidationResults = drogueRunPositionService.Query.ValidationResults,
                         },
                     }.ToList());
                 }
                 else
                 {
                     return Ok(drogueRunPositionService.GetDrogueRunPositionList().ToList());
                 }
            }
        }
        // GET api/drogueRunPosition/1
        [Route("{DrogueRunPositionID:int}")]
        public IActionResult GetDrogueRunPositionWithID([FromQuery]int DrogueRunPositionID, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                DrogueRunPositionService drogueRunPositionService = new DrogueRunPositionService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                drogueRunPositionService.Query = drogueRunPositionService.FillQuery(typeof(DrogueRunPosition), lang, 0, 1, "", "");

                DrogueRunPosition drogueRunPosition = new DrogueRunPosition();
                drogueRunPosition = drogueRunPositionService.GetDrogueRunPositionWithDrogueRunPositionID(DrogueRunPositionID);

                if (drogueRunPosition == null)
                {
                    return NotFound();
                }

                return Ok(drogueRunPosition);
            }
        }
        // POST api/drogueRunPosition
        [Route("")]
        public IActionResult Post([FromBody]DrogueRunPosition drogueRunPosition, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                DrogueRunPositionService drogueRunPositionService = new DrogueRunPositionService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!drogueRunPositionService.Add(drogueRunPosition))
                {
                    return BadRequest(String.Join("|||", drogueRunPosition.ValidationResults));
                }
                else
                {
                    drogueRunPosition.ValidationResults = null;
                    return Created(Url.ToString(), drogueRunPosition);
                }
            }
        }
        // PUT api/drogueRunPosition
        [Route("")]
        public IActionResult Put([FromBody]DrogueRunPosition drogueRunPosition, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                DrogueRunPositionService drogueRunPositionService = new DrogueRunPositionService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!drogueRunPositionService.Update(drogueRunPosition))
                {
                    return BadRequest(String.Join("|||", drogueRunPosition.ValidationResults));
                }
                else
                {
                    drogueRunPosition.ValidationResults = null;
                    return Ok(drogueRunPosition);
                }
            }
        }
        // DELETE api/drogueRunPosition
        [Route("")]
        public IActionResult Delete([FromBody]DrogueRunPosition drogueRunPosition, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                DrogueRunPositionService drogueRunPositionService = new DrogueRunPositionService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!drogueRunPositionService.Delete(drogueRunPosition))
                {
                    return BadRequest(String.Join("|||", drogueRunPosition.ValidationResults));
                }
                else
                {
                    drogueRunPosition.ValidationResults = null;
                    return Ok(drogueRunPosition);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
