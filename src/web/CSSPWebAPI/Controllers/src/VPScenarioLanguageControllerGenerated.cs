using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSSPWebAPI.Controllers
{
    [Route("api/vpScenarioLanguage")]
    public partial class VPScenarioLanguageController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public VPScenarioLanguageController() : base()
        {
        }
        public VPScenarioLanguageController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/vpScenarioLanguage
        [Route("")]
        public IActionResult GetVPScenarioLanguageList([FromQuery]string lang = "en", [FromQuery]int skip = 0, [FromQuery]int take = 200,
            [FromQuery]string asc = "", [FromQuery]string desc = "", [FromQuery]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                VPScenarioLanguageService vpScenarioLanguageService = new VPScenarioLanguageService(new Query() { Lang = lang }, db, ContactID);

                vpScenarioLanguageService.Query = vpScenarioLanguageService.FillQuery(typeof(VPScenarioLanguage), lang, skip, take, asc, desc, where);

                 if (vpScenarioLanguageService.Query.HasErrors)
                 {
                     return Ok(new List<VPScenarioLanguage>()
                     {
                         new VPScenarioLanguage()
                         {
                             HasErrors = vpScenarioLanguageService.Query.HasErrors,
                             ValidationResults = vpScenarioLanguageService.Query.ValidationResults,
                         },
                     }.ToList());
                 }
                 else
                 {
                     return Ok(vpScenarioLanguageService.GetVPScenarioLanguageList().ToList());
                 }
            }
        }
        // GET api/vpScenarioLanguage/1
        [Route("{VPScenarioLanguageID:int}")]
        public IActionResult GetVPScenarioLanguageWithID([FromQuery]int VPScenarioLanguageID, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                VPScenarioLanguageService vpScenarioLanguageService = new VPScenarioLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                vpScenarioLanguageService.Query = vpScenarioLanguageService.FillQuery(typeof(VPScenarioLanguage), lang, 0, 1, "", "");

                VPScenarioLanguage vpScenarioLanguage = new VPScenarioLanguage();
                vpScenarioLanguage = vpScenarioLanguageService.GetVPScenarioLanguageWithVPScenarioLanguageID(VPScenarioLanguageID);

                if (vpScenarioLanguage == null)
                {
                    return NotFound();
                }

                return Ok(vpScenarioLanguage);
            }
        }
        // POST api/vpScenarioLanguage
        [Route("")]
        public IActionResult Post([FromBody]VPScenarioLanguage vpScenarioLanguage, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                VPScenarioLanguageService vpScenarioLanguageService = new VPScenarioLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!vpScenarioLanguageService.Add(vpScenarioLanguage))
                {
                    return BadRequest(String.Join("|||", vpScenarioLanguage.ValidationResults));
                }
                else
                {
                    vpScenarioLanguage.ValidationResults = null;
                    return Created(Url.ToString(), vpScenarioLanguage);
                }
            }
        }
        // PUT api/vpScenarioLanguage
        [Route("")]
        public IActionResult Put([FromBody]VPScenarioLanguage vpScenarioLanguage, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                VPScenarioLanguageService vpScenarioLanguageService = new VPScenarioLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!vpScenarioLanguageService.Update(vpScenarioLanguage))
                {
                    return BadRequest(String.Join("|||", vpScenarioLanguage.ValidationResults));
                }
                else
                {
                    vpScenarioLanguage.ValidationResults = null;
                    return Ok(vpScenarioLanguage);
                }
            }
        }
        // DELETE api/vpScenarioLanguage
        [Route("")]
        public IActionResult Delete([FromBody]VPScenarioLanguage vpScenarioLanguage, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                VPScenarioLanguageService vpScenarioLanguageService = new VPScenarioLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!vpScenarioLanguageService.Delete(vpScenarioLanguage))
                {
                    return BadRequest(String.Join("|||", vpScenarioLanguage.ValidationResults));
                }
                else
                {
                    vpScenarioLanguage.ValidationResults = null;
                    return Ok(vpScenarioLanguage);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
