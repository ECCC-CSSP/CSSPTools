using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSSPWebAPI.Controllers
{
    [Route("api/mapInfoPoint")]
    public partial class MapInfoPointController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MapInfoPointController() : base()
        {
        }
        public MapInfoPointController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/mapInfoPoint
        [Route("")]
        public IActionResult GetMapInfoPointList([FromQuery]string lang = "en", [FromQuery]int skip = 0, [FromQuery]int take = 200,
            [FromQuery]string asc = "", [FromQuery]string desc = "", [FromQuery]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MapInfoPointService mapInfoPointService = new MapInfoPointService(new Query() { Lang = lang }, db, ContactID);

                mapInfoPointService.Query = mapInfoPointService.FillQuery(typeof(MapInfoPoint), lang, skip, take, asc, desc, where);

                 if (mapInfoPointService.Query.HasErrors)
                 {
                     return Ok(new List<MapInfoPoint>()
                     {
                         new MapInfoPoint()
                         {
                             HasErrors = mapInfoPointService.Query.HasErrors,
                             ValidationResults = mapInfoPointService.Query.ValidationResults,
                         },
                     }.ToList());
                 }
                 else
                 {
                     return Ok(mapInfoPointService.GetMapInfoPointList().ToList());
                 }
            }
        }
        // GET api/mapInfoPoint/1
        [Route("{MapInfoPointID:int}")]
        public IActionResult GetMapInfoPointWithID([FromQuery]int MapInfoPointID, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MapInfoPointService mapInfoPointService = new MapInfoPointService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                mapInfoPointService.Query = mapInfoPointService.FillQuery(typeof(MapInfoPoint), lang, 0, 1, "", "");

                MapInfoPoint mapInfoPoint = new MapInfoPoint();
                mapInfoPoint = mapInfoPointService.GetMapInfoPointWithMapInfoPointID(MapInfoPointID);

                if (mapInfoPoint == null)
                {
                    return NotFound();
                }

                return Ok(mapInfoPoint);
            }
        }
        // POST api/mapInfoPoint
        [Route("")]
        public IActionResult Post([FromBody]MapInfoPoint mapInfoPoint, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MapInfoPointService mapInfoPointService = new MapInfoPointService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!mapInfoPointService.Add(mapInfoPoint))
                {
                    return BadRequest(String.Join("|||", mapInfoPoint.ValidationResults));
                }
                else
                {
                    mapInfoPoint.ValidationResults = null;
                    return Created<MapInfoPoint>(new Uri(Request.RequestUri, mapInfoPoint.MapInfoPointID.ToString()), mapInfoPoint);
                }
            }
        }
        // PUT api/mapInfoPoint
        [Route("")]
        public IActionResult Put([FromBody]MapInfoPoint mapInfoPoint, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MapInfoPointService mapInfoPointService = new MapInfoPointService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!mapInfoPointService.Update(mapInfoPoint))
                {
                    return BadRequest(String.Join("|||", mapInfoPoint.ValidationResults));
                }
                else
                {
                    mapInfoPoint.ValidationResults = null;
                    return Ok(mapInfoPoint);
                }
            }
        }
        // DELETE api/mapInfoPoint
        [Route("")]
        public IActionResult Delete([FromBody]MapInfoPoint mapInfoPoint, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MapInfoPointService mapInfoPointService = new MapInfoPointService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!mapInfoPointService.Delete(mapInfoPoint))
                {
                    return BadRequest(String.Join("|||", mapInfoPoint.ValidationResults));
                }
                else
                {
                    mapInfoPoint.ValidationResults = null;
                    return Ok(mapInfoPoint);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
