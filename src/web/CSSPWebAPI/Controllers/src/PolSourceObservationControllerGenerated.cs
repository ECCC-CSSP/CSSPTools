using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSSPWebAPI.Controllers
{
    [Route("api/polSourceObservation")]
    public partial class PolSourceObservationController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public PolSourceObservationController() : base()
        {
        }
        public PolSourceObservationController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/polSourceObservation
        [Route("")]
        public IActionResult GetPolSourceObservationList([FromQuery]string lang = "en", [FromQuery]int skip = 0, [FromQuery]int take = 200,
            [FromQuery]string asc = "", [FromQuery]string desc = "", [FromQuery]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                PolSourceObservationService polSourceObservationService = new PolSourceObservationService(new Query() { Lang = lang }, db, ContactID);

                polSourceObservationService.Query = polSourceObservationService.FillQuery(typeof(PolSourceObservation), lang, skip, take, asc, desc, where);

                 if (polSourceObservationService.Query.HasErrors)
                 {
                     return Ok(new List<PolSourceObservation>()
                     {
                         new PolSourceObservation()
                         {
                             HasErrors = polSourceObservationService.Query.HasErrors,
                             ValidationResults = polSourceObservationService.Query.ValidationResults,
                         },
                     }.ToList());
                 }
                 else
                 {
                     return Ok(polSourceObservationService.GetPolSourceObservationList().ToList());
                 }
            }
        }
        // GET api/polSourceObservation/1
        [Route("{PolSourceObservationID:int}")]
        public IActionResult GetPolSourceObservationWithID([FromQuery]int PolSourceObservationID, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                PolSourceObservationService polSourceObservationService = new PolSourceObservationService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                polSourceObservationService.Query = polSourceObservationService.FillQuery(typeof(PolSourceObservation), lang, 0, 1, "", "");

                PolSourceObservation polSourceObservation = new PolSourceObservation();
                polSourceObservation = polSourceObservationService.GetPolSourceObservationWithPolSourceObservationID(PolSourceObservationID);

                if (polSourceObservation == null)
                {
                    return NotFound();
                }

                return Ok(polSourceObservation);
            }
        }
        // POST api/polSourceObservation
        [Route("")]
        public IActionResult Post([FromBody]PolSourceObservation polSourceObservation, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                PolSourceObservationService polSourceObservationService = new PolSourceObservationService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!polSourceObservationService.Add(polSourceObservation))
                {
                    return BadRequest(String.Join("|||", polSourceObservation.ValidationResults));
                }
                else
                {
                    polSourceObservation.ValidationResults = null;
                    return Created<PolSourceObservation>(new Uri(Request.RequestUri, polSourceObservation.PolSourceObservationID.ToString()), polSourceObservation);
                }
            }
        }
        // PUT api/polSourceObservation
        [Route("")]
        public IActionResult Put([FromBody]PolSourceObservation polSourceObservation, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                PolSourceObservationService polSourceObservationService = new PolSourceObservationService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!polSourceObservationService.Update(polSourceObservation))
                {
                    return BadRequest(String.Join("|||", polSourceObservation.ValidationResults));
                }
                else
                {
                    polSourceObservation.ValidationResults = null;
                    return Ok(polSourceObservation);
                }
            }
        }
        // DELETE api/polSourceObservation
        [Route("")]
        public IActionResult Delete([FromBody]PolSourceObservation polSourceObservation, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                PolSourceObservationService polSourceObservationService = new PolSourceObservationService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!polSourceObservationService.Delete(polSourceObservation))
                {
                    return BadRequest(String.Join("|||", polSourceObservation.ValidationResults));
                }
                else
                {
                    polSourceObservation.ValidationResults = null;
                    return Ok(polSourceObservation);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
