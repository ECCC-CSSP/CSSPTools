using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSSPWebAPI.Controllers
{
    [Route("api/mapInfo")]
    public partial class MapInfoController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MapInfoController() : base()
        {
        }
        public MapInfoController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/mapInfo
        [Route("")]
        public IActionResult GetMapInfoList([FromQuery]string lang = "en", [FromQuery]int skip = 0, [FromQuery]int take = 200,
            [FromQuery]string asc = "", [FromQuery]string desc = "", [FromQuery]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MapInfoService mapInfoService = new MapInfoService(new Query() { Lang = lang }, db, ContactID);

                mapInfoService.Query = mapInfoService.FillQuery(typeof(MapInfo), lang, skip, take, asc, desc, where);

                 if (mapInfoService.Query.HasErrors)
                 {
                     return Ok(new List<MapInfo>()
                     {
                         new MapInfo()
                         {
                             HasErrors = mapInfoService.Query.HasErrors,
                             ValidationResults = mapInfoService.Query.ValidationResults,
                         },
                     }.ToList());
                 }
                 else
                 {
                     return Ok(mapInfoService.GetMapInfoList().ToList());
                 }
            }
        }
        // GET api/mapInfo/1
        [Route("{MapInfoID:int}")]
        public IActionResult GetMapInfoWithID([FromQuery]int MapInfoID, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MapInfoService mapInfoService = new MapInfoService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                mapInfoService.Query = mapInfoService.FillQuery(typeof(MapInfo), lang, 0, 1, "", "");

                MapInfo mapInfo = new MapInfo();
                mapInfo = mapInfoService.GetMapInfoWithMapInfoID(MapInfoID);

                if (mapInfo == null)
                {
                    return NotFound();
                }

                return Ok(mapInfo);
            }
        }
        // POST api/mapInfo
        [Route("")]
        public IActionResult Post([FromBody]MapInfo mapInfo, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MapInfoService mapInfoService = new MapInfoService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!mapInfoService.Add(mapInfo))
                {
                    return BadRequest(String.Join("|||", mapInfo.ValidationResults));
                }
                else
                {
                    mapInfo.ValidationResults = null;
                    return Created(Url.ToString(), mapInfo);
                }
            }
        }
        // PUT api/mapInfo
        [Route("")]
        public IActionResult Put([FromBody]MapInfo mapInfo, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MapInfoService mapInfoService = new MapInfoService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!mapInfoService.Update(mapInfo))
                {
                    return BadRequest(String.Join("|||", mapInfo.ValidationResults));
                }
                else
                {
                    mapInfo.ValidationResults = null;
                    return Ok(mapInfo);
                }
            }
        }
        // DELETE api/mapInfo
        [Route("")]
        public IActionResult Delete([FromBody]MapInfo mapInfo, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MapInfoService mapInfoService = new MapInfoService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!mapInfoService.Delete(mapInfo))
                {
                    return BadRequest(String.Join("|||", mapInfo.ValidationResults));
                }
                else
                {
                    mapInfo.ValidationResults = null;
                    return Ok(mapInfo);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
