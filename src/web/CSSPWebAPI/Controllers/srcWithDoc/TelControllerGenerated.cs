using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSSPWebAPI.Controllers
{
    [Route("api/tel")]
    public partial class TelController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public TelController() : base()
        {
        }
        public TelController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/tel
        [Route("")]
        public IActionResult GetTelList([FromQuery]string lang = "en", [FromQuery]int skip = 0, [FromQuery]int take = 200,
            [FromQuery]string asc = "", [FromQuery]string desc = "", [FromQuery]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TelService telService = new TelService(new Query() { Lang = lang }, db, ContactID);

                telService.Query = telService.FillQuery(typeof(Tel), lang, skip, take, asc, desc, where);

                 if (telService.Query.HasErrors)
                 {
                     return Ok(new List<Tel>()
                     {
                         new Tel()
                         {
                             HasErrors = telService.Query.HasErrors,
                             ValidationResults = telService.Query.ValidationResults,
                         },
                     }.ToList());
                 }
                 else
                 {
                     return Ok(telService.GetTelList().ToList());
                 }
            }
        }
        // GET api/tel/1
        [Route("{TelID:int}")]
        public IActionResult GetTelWithID([FromQuery]int TelID, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TelService telService = new TelService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                telService.Query = telService.FillQuery(typeof(Tel), lang, 0, 1, "", "");

                Tel tel = new Tel();
                tel = telService.GetTelWithTelID(TelID);

                if (tel == null)
                {
                    return NotFound();
                }

                return Ok(tel);
            }
        }
        // POST api/tel
        [Route("")]
        public IActionResult Post([FromBody]Tel tel, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TelService telService = new TelService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!telService.Add(tel))
                {
                    return BadRequest(String.Join("|||", tel.ValidationResults));
                }
                else
                {
                    tel.ValidationResults = null;
                    return Created(Url.ToString(), tel);
                }
            }
        }
        // PUT api/tel
        [Route("")]
        public IActionResult Put([FromBody]Tel tel, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TelService telService = new TelService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!telService.Update(tel))
                {
                    return BadRequest(String.Join("|||", tel.ValidationResults));
                }
                else
                {
                    tel.ValidationResults = null;
                    return Ok(tel);
                }
            }
        }
        // DELETE api/tel
        [Route("")]
        public IActionResult Delete([FromBody]Tel tel, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TelService telService = new TelService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!telService.Delete(tel))
                {
                    return BadRequest(String.Join("|||", tel.ValidationResults));
                }
                else
                {
                    tel.ValidationResults = null;
                    return Ok(tel);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
