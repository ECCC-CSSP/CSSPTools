using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSSPWebAPI.Controllers
{
    [Route("api/vpResult")]
    public partial class VPResultController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public VPResultController() : base()
        {
        }
        public VPResultController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/vpResult
        [Route("")]
        public IActionResult GetVPResultList([FromQuery]string lang = "en", [FromQuery]int skip = 0, [FromQuery]int take = 200,
            [FromQuery]string asc = "", [FromQuery]string desc = "", [FromQuery]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                VPResultService vpResultService = new VPResultService(new Query() { Lang = lang }, db, ContactID);

                vpResultService.Query = vpResultService.FillQuery(typeof(VPResult), lang, skip, take, asc, desc, where);

                 if (vpResultService.Query.HasErrors)
                 {
                     return Ok(new List<VPResult>()
                     {
                         new VPResult()
                         {
                             HasErrors = vpResultService.Query.HasErrors,
                             ValidationResults = vpResultService.Query.ValidationResults,
                         },
                     }.ToList());
                 }
                 else
                 {
                     return Ok(vpResultService.GetVPResultList().ToList());
                 }
            }
        }
        // GET api/vpResult/1
        [Route("{VPResultID:int}")]
        public IActionResult GetVPResultWithID([FromQuery]int VPResultID, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                VPResultService vpResultService = new VPResultService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                vpResultService.Query = vpResultService.FillQuery(typeof(VPResult), lang, 0, 1, "", "");

                VPResult vpResult = new VPResult();
                vpResult = vpResultService.GetVPResultWithVPResultID(VPResultID);

                if (vpResult == null)
                {
                    return NotFound();
                }

                return Ok(vpResult);
            }
        }
        // POST api/vpResult
        [Route("")]
        public IActionResult Post([FromBody]VPResult vpResult, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                VPResultService vpResultService = new VPResultService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!vpResultService.Add(vpResult))
                {
                    return BadRequest(String.Join("|||", vpResult.ValidationResults));
                }
                else
                {
                    vpResult.ValidationResults = null;
                    return Created(Url.ToString(), vpResult);
                }
            }
        }
        // PUT api/vpResult
        [Route("")]
        public IActionResult Put([FromBody]VPResult vpResult, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                VPResultService vpResultService = new VPResultService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!vpResultService.Update(vpResult))
                {
                    return BadRequest(String.Join("|||", vpResult.ValidationResults));
                }
                else
                {
                    vpResult.ValidationResults = null;
                    return Ok(vpResult);
                }
            }
        }
        // DELETE api/vpResult
        [Route("")]
        public IActionResult Delete([FromBody]VPResult vpResult, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                VPResultService vpResultService = new VPResultService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!vpResultService.Delete(vpResult))
                {
                    return BadRequest(String.Join("|||", vpResult.ValidationResults));
                }
                else
                {
                    vpResult.ValidationResults = null;
                    return Ok(vpResult);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
