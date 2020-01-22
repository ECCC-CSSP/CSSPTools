using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSSPWebAPI.Controllers
{
    [Route("api/infrastructureLanguage")]
    public partial class InfrastructureLanguageController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public InfrastructureLanguageController() : base()
        {
        }
        public InfrastructureLanguageController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/infrastructureLanguage
        [Route("")]
        public IActionResult GetInfrastructureLanguageList([FromQuery]string lang = "en", [FromQuery]int skip = 0, [FromQuery]int take = 200,
            [FromQuery]string asc = "", [FromQuery]string desc = "", [FromQuery]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                InfrastructureLanguageService infrastructureLanguageService = new InfrastructureLanguageService(new Query() { Lang = lang }, db, ContactID);

                infrastructureLanguageService.Query = infrastructureLanguageService.FillQuery(typeof(InfrastructureLanguage), lang, skip, take, asc, desc, where);

                 if (infrastructureLanguageService.Query.HasErrors)
                 {
                     return Ok(new List<InfrastructureLanguage>()
                     {
                         new InfrastructureLanguage()
                         {
                             HasErrors = infrastructureLanguageService.Query.HasErrors,
                             ValidationResults = infrastructureLanguageService.Query.ValidationResults,
                         },
                     }.ToList());
                 }
                 else
                 {
                     return Ok(infrastructureLanguageService.GetInfrastructureLanguageList().ToList());
                 }
            }
        }
        // GET api/infrastructureLanguage/1
        [Route("{InfrastructureLanguageID:int}")]
        public IActionResult GetInfrastructureLanguageWithID([FromQuery]int InfrastructureLanguageID, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                InfrastructureLanguageService infrastructureLanguageService = new InfrastructureLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                infrastructureLanguageService.Query = infrastructureLanguageService.FillQuery(typeof(InfrastructureLanguage), lang, 0, 1, "", "");

                InfrastructureLanguage infrastructureLanguage = new InfrastructureLanguage();
                infrastructureLanguage = infrastructureLanguageService.GetInfrastructureLanguageWithInfrastructureLanguageID(InfrastructureLanguageID);

                if (infrastructureLanguage == null)
                {
                    return NotFound();
                }

                return Ok(infrastructureLanguage);
            }
        }
        // POST api/infrastructureLanguage
        [Route("")]
        public IActionResult Post([FromBody]InfrastructureLanguage infrastructureLanguage, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                InfrastructureLanguageService infrastructureLanguageService = new InfrastructureLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!infrastructureLanguageService.Add(infrastructureLanguage))
                {
                    return BadRequest(String.Join("|||", infrastructureLanguage.ValidationResults));
                }
                else
                {
                    infrastructureLanguage.ValidationResults = null;
                    return Created(Url.ToString(), infrastructureLanguage);
                }
            }
        }
        // PUT api/infrastructureLanguage
        [Route("")]
        public IActionResult Put([FromBody]InfrastructureLanguage infrastructureLanguage, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                InfrastructureLanguageService infrastructureLanguageService = new InfrastructureLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!infrastructureLanguageService.Update(infrastructureLanguage))
                {
                    return BadRequest(String.Join("|||", infrastructureLanguage.ValidationResults));
                }
                else
                {
                    infrastructureLanguage.ValidationResults = null;
                    return Ok(infrastructureLanguage);
                }
            }
        }
        // DELETE api/infrastructureLanguage
        [Route("")]
        public IActionResult Delete([FromBody]InfrastructureLanguage infrastructureLanguage, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                InfrastructureLanguageService infrastructureLanguageService = new InfrastructureLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!infrastructureLanguageService.Delete(infrastructureLanguage))
                {
                    return BadRequest(String.Join("|||", infrastructureLanguage.ValidationResults));
                }
                else
                {
                    infrastructureLanguage.ValidationResults = null;
                    return Ok(infrastructureLanguage);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
