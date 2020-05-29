using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CSSPWebAPI.Controllers
{
    [RoutePrefix("api/drogueRunPosition")]
    public partial class DrogueRunPositionController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public DrogueRunPositionController() : base()
        {
        }
        public DrogueRunPositionController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/drogueRunPosition
        [Route("")]
        public IHttpActionResult GetDrogueRunPositionList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                DrogueRunPositionService drogueRunPositionService = new DrogueRunPositionService(new Query() { Lang = lang }, db, ContactID);

                else // QueryString has no parameter [extra] or extra is empty
                {
                   drogueRunPositionService.Query = drogueRunPositionService.FillQuery(typeof(DrogueRunPosition), lang, skip, take, asc, desc, where, extra);

                    if (drogueRunPositionService.Query.HasErrors)
                    {
                        return Ok(new List<DrogueRunPosition>()
                        {
                            new DrogueRunPosition()
                            {
                                HasErrors = drogueRunPositionService.Query.HasErrors,
                                ValidationResults = drogueRunPositionService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(drogueRunPositionService.GetDrogueRunPositionList().ToList());
                    }
                }
            }
        }
        // GET api/drogueRunPosition/1
        [Route("{DrogueRunPositionID:int}")]
        public IHttpActionResult GetDrogueRunPositionWithID([FromUri]int DrogueRunPositionID, [FromUri]string lang = "en", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                DrogueRunPositionService drogueRunPositionService = new DrogueRunPositionService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                drogueRunPositionService.Query = drogueRunPositionService.FillQuery(typeof(DrogueRunPosition), lang, 0, 1, "", "", extra);

                else
                {
                    DrogueRunPosition drogueRunPosition = new DrogueRunPosition();
                    drogueRunPosition = drogueRunPositionService.GetDrogueRunPositionWithDrogueRunPositionID(DrogueRunPositionID);

                    if (drogueRunPosition == null)
                    {
                        return NotFound();
                    }

                    return Ok(drogueRunPosition);
                }
            }
        }
        // POST api/drogueRunPosition
        [Route("")]
        public IHttpActionResult Post([FromBody]DrogueRunPosition drogueRunPosition, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                DrogueRunPositionService drogueRunPositionService = new DrogueRunPositionService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!drogueRunPositionService.Add(drogueRunPosition))
                {
                    return BadRequest(String.Join("|||", drogueRunPosition.ValidationResults));
                }
                else
                {
                    drogueRunPosition.ValidationResults = null;
                    return Created<DrogueRunPosition>(new Uri(Request.RequestUri, drogueRunPosition.DrogueRunPositionID.ToString()), drogueRunPosition);
                }
            }
        }
        // PUT api/drogueRunPosition
        [Route("")]
        public IHttpActionResult Put([FromBody]DrogueRunPosition drogueRunPosition, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                DrogueRunPositionService drogueRunPositionService = new DrogueRunPositionService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!drogueRunPositionService.Update(drogueRunPosition))
                {
                    return BadRequest(String.Join("|||", drogueRunPosition.ValidationResults));
                }
                else
                {
                    drogueRunPosition.ValidationResults = null;
                    return Ok(drogueRunPosition);
                }
            }
        }
        // DELETE api/drogueRunPosition
        [Route("")]
        public IHttpActionResult Delete([FromBody]DrogueRunPosition drogueRunPosition, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                DrogueRunPositionService drogueRunPositionService = new DrogueRunPositionService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!drogueRunPositionService.Delete(drogueRunPosition))
                {
                    return BadRequest(String.Join("|||", drogueRunPosition.ValidationResults));
                }
                else
                {
                    drogueRunPosition.ValidationResults = null;
                    return Ok(drogueRunPosition);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
