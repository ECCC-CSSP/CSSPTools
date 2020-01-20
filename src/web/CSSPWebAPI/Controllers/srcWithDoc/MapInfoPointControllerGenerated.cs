using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CSSPWebAPI.Controllers
{
    [RoutePrefix("api/mapInfoPoint")]
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
        public IHttpActionResult GetMapInfoPointList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MapInfoPointService mapInfoPointService = new MapInfoPointService(new Query() { Lang = lang }, db, ContactID);

                if (extra == "A") // QueryString contains [extra=A]
                {
                   mapInfoPointService.Query = mapInfoPointService.FillQuery(typeof(MapInfoPointExtraA), lang, skip, take, asc, desc, where, extra);

                    if (mapInfoPointService.Query.HasErrors)
                    {
                        return Ok(new List<MapInfoPointExtraA>()
                        {
                            new MapInfoPointExtraA()
                            {
                                HasErrors = mapInfoPointService.Query.HasErrors,
                                ValidationResults = mapInfoPointService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(mapInfoPointService.GetMapInfoPointExtraAList().ToList());
                    }
                }
                else if (extra == "B") // QueryString contains [extra=B]
                {
                   mapInfoPointService.Query = mapInfoPointService.FillQuery(typeof(MapInfoPointExtraB), lang, skip, take, asc, desc, where, extra);

                    if (mapInfoPointService.Query.HasErrors)
                    {
                        return Ok(new List<MapInfoPointExtraB>()
                        {
                            new MapInfoPointExtraB()
                            {
                                HasErrors = mapInfoPointService.Query.HasErrors,
                                ValidationResults = mapInfoPointService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(mapInfoPointService.GetMapInfoPointExtraBList().ToList());
                    }
                }
                else // QueryString has no parameter [extra] or extra is empty
                {
                   mapInfoPointService.Query = mapInfoPointService.FillQuery(typeof(MapInfoPoint), lang, skip, take, asc, desc, where, extra);

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
        }
        // GET api/mapInfoPoint/1
        [Route("{MapInfoPointID:int}")]
        public IHttpActionResult GetMapInfoPointWithID([FromUri]int MapInfoPointID, [FromUri]string lang = "en", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MapInfoPointService mapInfoPointService = new MapInfoPointService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                mapInfoPointService.Query = mapInfoPointService.FillQuery(typeof(MapInfoPoint), lang, 0, 1, "", "", extra);

                if (mapInfoPointService.Query.Extra == "A")
                {
                    MapInfoPointExtraA mapInfoPointExtraA = new MapInfoPointExtraA();
                    mapInfoPointExtraA = mapInfoPointService.GetMapInfoPointExtraAWithMapInfoPointID(MapInfoPointID);

                    if (mapInfoPointExtraA == null)
                    {
                        return NotFound();
                    }

                    return Ok(mapInfoPointExtraA);
                }
                else if (mapInfoPointService.Query.Extra == "B")
                {
                    MapInfoPointExtraB mapInfoPointExtraB = new MapInfoPointExtraB();
                    mapInfoPointExtraB = mapInfoPointService.GetMapInfoPointExtraBWithMapInfoPointID(MapInfoPointID);

                    if (mapInfoPointExtraB == null)
                    {
                        return NotFound();
                    }

                    return Ok(mapInfoPointExtraB);
                }
                else
                {
                    MapInfoPoint mapInfoPoint = new MapInfoPoint();
                    mapInfoPoint = mapInfoPointService.GetMapInfoPointWithMapInfoPointID(MapInfoPointID);

                    if (mapInfoPoint == null)
                    {
                        return NotFound();
                    }

                    return Ok(mapInfoPoint);
                }
            }
        }
        // POST api/mapInfoPoint
        [Route("")]
        public IHttpActionResult Post([FromBody]MapInfoPoint mapInfoPoint, [FromUri]string lang = "en")
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
        public IHttpActionResult Put([FromBody]MapInfoPoint mapInfoPoint, [FromUri]string lang = "en")
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
        public IHttpActionResult Delete([FromBody]MapInfoPoint mapInfoPoint, [FromUri]string lang = "en")
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
