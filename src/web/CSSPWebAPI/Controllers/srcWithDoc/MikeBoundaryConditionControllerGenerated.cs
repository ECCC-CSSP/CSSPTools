using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSSPWebAPI.Controllers
{
    [Route("api/mikeBoundaryCondition")]
    public partial class MikeBoundaryConditionController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MikeBoundaryConditionController() : base()
        {
        }
        public MikeBoundaryConditionController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/mikeBoundaryCondition
        [Route("")]
        public IActionResult GetMikeBoundaryConditionList([FromQuery]string lang = "en", [FromQuery]int skip = 0, [FromQuery]int take = 200,
            [FromQuery]string asc = "", [FromQuery]string desc = "", [FromQuery]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MikeBoundaryConditionService mikeBoundaryConditionService = new MikeBoundaryConditionService(new Query() { Lang = lang }, db, ContactID);

                mikeBoundaryConditionService.Query = mikeBoundaryConditionService.FillQuery(typeof(MikeBoundaryCondition), lang, skip, take, asc, desc, where);

                 if (mikeBoundaryConditionService.Query.HasErrors)
                 {
                     return Ok(new List<MikeBoundaryCondition>()
                     {
                         new MikeBoundaryCondition()
                         {
                             HasErrors = mikeBoundaryConditionService.Query.HasErrors,
                             ValidationResults = mikeBoundaryConditionService.Query.ValidationResults,
                         },
                     }.ToList());
                 }
                 else
                 {
                     return Ok(mikeBoundaryConditionService.GetMikeBoundaryConditionList().ToList());
                 }
            }
        }
        // GET api/mikeBoundaryCondition/1
        [Route("{MikeBoundaryConditionID:int}")]
        public IActionResult GetMikeBoundaryConditionWithID([FromQuery]int MikeBoundaryConditionID, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MikeBoundaryConditionService mikeBoundaryConditionService = new MikeBoundaryConditionService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                mikeBoundaryConditionService.Query = mikeBoundaryConditionService.FillQuery(typeof(MikeBoundaryCondition), lang, 0, 1, "", "");

                MikeBoundaryCondition mikeBoundaryCondition = new MikeBoundaryCondition();
                mikeBoundaryCondition = mikeBoundaryConditionService.GetMikeBoundaryConditionWithMikeBoundaryConditionID(MikeBoundaryConditionID);

                if (mikeBoundaryCondition == null)
                {
                    return NotFound();
                }

                return Ok(mikeBoundaryCondition);
            }
        }
        // POST api/mikeBoundaryCondition
        [Route("")]
        public IActionResult Post([FromBody]MikeBoundaryCondition mikeBoundaryCondition, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MikeBoundaryConditionService mikeBoundaryConditionService = new MikeBoundaryConditionService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!mikeBoundaryConditionService.Add(mikeBoundaryCondition))
                {
                    return BadRequest(String.Join("|||", mikeBoundaryCondition.ValidationResults));
                }
                else
                {
                    mikeBoundaryCondition.ValidationResults = null;
                    return Created(Url.ToString(), mikeBoundaryCondition);
                }
            }
        }
        // PUT api/mikeBoundaryCondition
        [Route("")]
        public IActionResult Put([FromBody]MikeBoundaryCondition mikeBoundaryCondition, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MikeBoundaryConditionService mikeBoundaryConditionService = new MikeBoundaryConditionService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!mikeBoundaryConditionService.Update(mikeBoundaryCondition))
                {
                    return BadRequest(String.Join("|||", mikeBoundaryCondition.ValidationResults));
                }
                else
                {
                    mikeBoundaryCondition.ValidationResults = null;
                    return Ok(mikeBoundaryCondition);
                }
            }
        }
        // DELETE api/mikeBoundaryCondition
        [Route("")]
        public IActionResult Delete([FromBody]MikeBoundaryCondition mikeBoundaryCondition, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MikeBoundaryConditionService mikeBoundaryConditionService = new MikeBoundaryConditionService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!mikeBoundaryConditionService.Delete(mikeBoundaryCondition))
                {
                    return BadRequest(String.Join("|||", mikeBoundaryCondition.ValidationResults));
                }
                else
                {
                    mikeBoundaryCondition.ValidationResults = null;
                    return Ok(mikeBoundaryCondition);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
