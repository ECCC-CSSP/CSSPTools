using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSSPWebAPI.Controllers
{
    [Route("api/infrastructure")]
    public partial class InfrastructureController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public InfrastructureController() : base()
        {
        }
        public InfrastructureController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/infrastructure
        [Route("")]
        public IActionResult GetInfrastructureList([FromQuery]string lang = "en", [FromQuery]int skip = 0, [FromQuery]int take = 200,
            [FromQuery]string asc = "", [FromQuery]string desc = "", [FromQuery]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                InfrastructureService infrastructureService = new InfrastructureService(new Query() { Lang = lang }, db, ContactID);

                infrastructureService.Query = infrastructureService.FillQuery(typeof(Infrastructure), lang, skip, take, asc, desc, where);

                 if (infrastructureService.Query.HasErrors)
                 {
                     return Ok(new List<Infrastructure>()
                     {
                         new Infrastructure()
                         {
                             HasErrors = infrastructureService.Query.HasErrors,
                             ValidationResults = infrastructureService.Query.ValidationResults,
                         },
                     }.ToList());
                 }
                 else
                 {
                     return Ok(infrastructureService.GetInfrastructureList().ToList());
                 }
            }
        }
        // GET api/infrastructure/1
        [Route("{InfrastructureID:int}")]
        public IActionResult GetInfrastructureWithID([FromQuery]int InfrastructureID, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                InfrastructureService infrastructureService = new InfrastructureService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                infrastructureService.Query = infrastructureService.FillQuery(typeof(Infrastructure), lang, 0, 1, "", "");

                Infrastructure infrastructure = new Infrastructure();
                infrastructure = infrastructureService.GetInfrastructureWithInfrastructureID(InfrastructureID);

                if (infrastructure == null)
                {
                    return NotFound();
                }

                return Ok(infrastructure);
            }
        }
        // POST api/infrastructure
        [Route("")]
        public IActionResult Post([FromBody]Infrastructure infrastructure, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                InfrastructureService infrastructureService = new InfrastructureService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!infrastructureService.Add(infrastructure))
                {
                    return BadRequest(String.Join("|||", infrastructure.ValidationResults));
                }
                else
                {
                    infrastructure.ValidationResults = null;
                    return Created(Url.ToString(), infrastructure);
                }
            }
        }
        // PUT api/infrastructure
        [Route("")]
        public IActionResult Put([FromBody]Infrastructure infrastructure, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                InfrastructureService infrastructureService = new InfrastructureService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!infrastructureService.Update(infrastructure))
                {
                    return BadRequest(String.Join("|||", infrastructure.ValidationResults));
                }
                else
                {
                    infrastructure.ValidationResults = null;
                    return Ok(infrastructure);
                }
            }
        }
        // DELETE api/infrastructure
        [Route("")]
        public IActionResult Delete([FromBody]Infrastructure infrastructure, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                InfrastructureService infrastructureService = new InfrastructureService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!infrastructureService.Delete(infrastructure))
                {
                    return BadRequest(String.Join("|||", infrastructure.ValidationResults));
                }
                else
                {
                    infrastructure.ValidationResults = null;
                    return Ok(infrastructure);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
