using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CSSPWebAPI.Controllers
{
    [RoutePrefix("api/mapInfo")]
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
        public IHttpActionResult GetMapInfoList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MapInfoService mapInfoService = new MapInfoService(new Query() { Lang = lang }, db, ContactID);

                if (extra == "A") // QueryString contains [extra=A]
                {
                   mapInfoService.Query = mapInfoService.FillQuery(typeof(MapInfoExtraA), lang, skip, take, asc, desc, where, extra);

                    if (mapInfoService.Query.HasErrors)
                    {
                        return Ok(new List<MapInfoExtraA>()
                        {
                            new MapInfoExtraA()
                            {
                                HasErrors = mapInfoService.Query.HasErrors,
                                ValidationResults = mapInfoService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(mapInfoService.GetMapInfoExtraAList().ToList());
                    }
                }
                else if (extra == "B") // QueryString contains [extra=B]
                {
                   mapInfoService.Query = mapInfoService.FillQuery(typeof(MapInfoExtraB), lang, skip, take, asc, desc, where, extra);

                    if (mapInfoService.Query.HasErrors)
                    {
                        return Ok(new List<MapInfoExtraB>()
                        {
                            new MapInfoExtraB()
                            {
                                HasErrors = mapInfoService.Query.HasErrors,
                                ValidationResults = mapInfoService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(mapInfoService.GetMapInfoExtraBList().ToList());
                    }
                }
                else // QueryString has no parameter [extra] or extra is empty
                {
                   mapInfoService.Query = mapInfoService.FillQuery(typeof(MapInfo), lang, skip, take, asc, desc, where, extra);

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
        }
        // GET api/mapInfo/1
        [Route("{MapInfoID:int}")]
        public IHttpActionResult GetMapInfoWithID([FromUri]int MapInfoID, [FromUri]string lang = "en", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MapInfoService mapInfoService = new MapInfoService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                mapInfoService.Query = mapInfoService.FillQuery(typeof(MapInfo), lang, 0, 1, "", "", extra);

                if (mapInfoService.Query.Extra == "A")
                {
                    MapInfoExtraA mapInfoExtraA = new MapInfoExtraA();
                    mapInfoExtraA = mapInfoService.GetMapInfoExtraAWithMapInfoID(MapInfoID);

                    if (mapInfoExtraA == null)
                    {
                        return NotFound();
                    }

                    return Ok(mapInfoExtraA);
                }
                else if (mapInfoService.Query.Extra == "B")
                {
                    MapInfoExtraB mapInfoExtraB = new MapInfoExtraB();
                    mapInfoExtraB = mapInfoService.GetMapInfoExtraBWithMapInfoID(MapInfoID);

                    if (mapInfoExtraB == null)
                    {
                        return NotFound();
                    }

                    return Ok(mapInfoExtraB);
                }
                else
                {
                    MapInfo mapInfo = new MapInfo();
                    mapInfo = mapInfoService.GetMapInfoWithMapInfoID(MapInfoID);

                    if (mapInfo == null)
                    {
                        return NotFound();
                    }

                    return Ok(mapInfo);
                }
            }
        }
        // POST api/mapInfo
        [Route("")]
        public IHttpActionResult Post([FromBody]MapInfo mapInfo, [FromUri]string lang = "en")
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
                    return Created<MapInfo>(new Uri(Request.RequestUri, mapInfo.MapInfoID.ToString()), mapInfo);
                }
            }
        }
        // PUT api/mapInfo
        [Route("")]
        public IHttpActionResult Put([FromBody]MapInfo mapInfo, [FromUri]string lang = "en")
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
        public IHttpActionResult Delete([FromBody]MapInfo mapInfo, [FromUri]string lang = "en")
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
