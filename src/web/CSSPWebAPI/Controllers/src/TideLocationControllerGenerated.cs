using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSSPWebAPI.Controllers
{
    [Route("api/tideLocation")]
    public partial class TideLocationController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public TideLocationController() : base()
        {
        }
        public TideLocationController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/tideLocation
        [Route("")]
        public IActionResult GetTideLocationList([FromQuery]string lang = "en", [FromQuery]int skip = 0, [FromQuery]int take = 200,
            [FromQuery]string asc = "", [FromQuery]string desc = "", [FromQuery]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TideLocationService tideLocationService = new TideLocationService(new Query() { Lang = lang }, db, ContactID);

                tideLocationService.Query = tideLocationService.FillQuery(typeof(TideLocation), lang, skip, take, asc, desc, where);

                 if (tideLocationService.Query.HasErrors)
                 {
                     return Ok(new List<TideLocation>()
                     {
                         new TideLocation()
                         {
                             HasErrors = tideLocationService.Query.HasErrors,
                             ValidationResults = tideLocationService.Query.ValidationResults,
                         },
                     }.ToList());
                 }
                 else
                 {
                     return Ok(tideLocationService.GetTideLocationList().ToList());
                 }
            }
        }
        // GET api/tideLocation/1
        [Route("{TideLocationID:int}")]
        public IActionResult GetTideLocationWithID([FromQuery]int TideLocationID, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TideLocationService tideLocationService = new TideLocationService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                tideLocationService.Query = tideLocationService.FillQuery(typeof(TideLocation), lang, 0, 1, "", "");

                TideLocation tideLocation = new TideLocation();
                tideLocation = tideLocationService.GetTideLocationWithTideLocationID(TideLocationID);

                if (tideLocation == null)
                {
                    return NotFound();
                }

                return Ok(tideLocation);
            }
        }
        // POST api/tideLocation
        [Route("")]
        public IActionResult Post([FromBody]TideLocation tideLocation, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TideLocationService tideLocationService = new TideLocationService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!tideLocationService.Add(tideLocation))
                {
                    return BadRequest(String.Join("|||", tideLocation.ValidationResults));
                }
                else
                {
                    tideLocation.ValidationResults = null;
                    return Created<TideLocation>(new Uri(Request.RequestUri, tideLocation.TideLocationID.ToString()), tideLocation);
                }
            }
        }
        // PUT api/tideLocation
        [Route("")]
        public IActionResult Put([FromBody]TideLocation tideLocation, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TideLocationService tideLocationService = new TideLocationService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!tideLocationService.Update(tideLocation))
                {
                    return BadRequest(String.Join("|||", tideLocation.ValidationResults));
                }
                else
                {
                    tideLocation.ValidationResults = null;
                    return Ok(tideLocation);
                }
            }
        }
        // DELETE api/tideLocation
        [Route("")]
        public IActionResult Delete([FromBody]TideLocation tideLocation, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TideLocationService tideLocationService = new TideLocationService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!tideLocationService.Delete(tideLocation))
                {
                    return BadRequest(String.Join("|||", tideLocation.ValidationResults));
                }
                else
                {
                    tideLocation.ValidationResults = null;
                    return Ok(tideLocation);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
