using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSSPWebAPI.Controllers
{
    [Route("api/drogueRun")]
    public partial class DrogueRunController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public DrogueRunController() : base()
        {
        }
        public DrogueRunController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/drogueRun
        [Route("")]
        public IActionResult GetDrogueRunList([FromQuery]string lang = "en", [FromQuery]int skip = 0, [FromQuery]int take = 200,
            [FromQuery]string asc = "", [FromQuery]string desc = "", [FromQuery]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                DrogueRunService drogueRunService = new DrogueRunService(new Query() { Lang = lang }, db, ContactID);

                drogueRunService.Query = drogueRunService.FillQuery(typeof(DrogueRun), lang, skip, take, asc, desc, where);

                 if (drogueRunService.Query.HasErrors)
                 {
                     return Ok(new List<DrogueRun>()
                     {
                         new DrogueRun()
                         {
                             HasErrors = drogueRunService.Query.HasErrors,
                             ValidationResults = drogueRunService.Query.ValidationResults,
                         },
                     }.ToList());
                 }
                 else
                 {
                     return Ok(drogueRunService.GetDrogueRunList().ToList());
                 }
            }
        }
        // GET api/drogueRun/1
        [Route("{DrogueRunID:int}")]
        public IActionResult GetDrogueRunWithID([FromQuery]int DrogueRunID, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                DrogueRunService drogueRunService = new DrogueRunService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                drogueRunService.Query = drogueRunService.FillQuery(typeof(DrogueRun), lang, 0, 1, "", "");

                DrogueRun drogueRun = new DrogueRun();
                drogueRun = drogueRunService.GetDrogueRunWithDrogueRunID(DrogueRunID);

                if (drogueRun == null)
                {
                    return NotFound();
                }

                return Ok(drogueRun);
            }
        }
        // POST api/drogueRun
        [Route("")]
        public IActionResult Post([FromBody]DrogueRun drogueRun, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                DrogueRunService drogueRunService = new DrogueRunService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!drogueRunService.Add(drogueRun))
                {
                    return BadRequest(String.Join("|||", drogueRun.ValidationResults));
                }
                else
                {
                    drogueRun.ValidationResults = null;
                    return Created(Url.ToString(), drogueRun);
                }
            }
        }
        // PUT api/drogueRun
        [Route("")]
        public IActionResult Put([FromBody]DrogueRun drogueRun, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                DrogueRunService drogueRunService = new DrogueRunService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!drogueRunService.Update(drogueRun))
                {
                    return BadRequest(String.Join("|||", drogueRun.ValidationResults));
                }
                else
                {
                    drogueRun.ValidationResults = null;
                    return Ok(drogueRun);
                }
            }
        }
        // DELETE api/drogueRun
        [Route("")]
        public IActionResult Delete([FromBody]DrogueRun drogueRun, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                DrogueRunService drogueRunService = new DrogueRunService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!drogueRunService.Delete(drogueRun))
                {
                    return BadRequest(String.Join("|||", drogueRun.ValidationResults));
                }
                else
                {
                    drogueRun.ValidationResults = null;
                    return Ok(drogueRun);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
