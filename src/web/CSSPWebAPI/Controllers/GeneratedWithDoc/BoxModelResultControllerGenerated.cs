using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;;

namespace CSSPWebAPI.Controllers
{
    [Route("api/boxModelResult")]
    public partial class BoxModelResultController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public BoxModelResultController() : base()
        {
        }
        public BoxModelResultController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/boxModelResult
        [Route("")]
        public IHttpActionResult GetBoxModelResultList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                BoxModelResultService boxModelResultService = new BoxModelResultService(new Query() { Lang = lang }, db, ContactID);

                else
                {
                   boxModelResultService.Query = boxModelResultService.FillQuery(typeof(BoxModelResult), lang, skip, take, asc, desc, where);

                    if (boxModelResultService.Query.HasErrors)
                    {
                        return Ok(new List<BoxModelResult>()
                        {
                            new BoxModelResult()
                            {
                                HasErrors = boxModelResultService.Query.HasErrors,
                                ValidationResults = boxModelResultService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(boxModelResultService.GetBoxModelResultList().ToList());
                    }
                }
            }
        }
        // GET api/boxModelResult/1
        [Route("{BoxModelResultID:int}")]
        public IHttpActionResult GetBoxModelResultWithID([FromUri]int BoxModelResultID, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                BoxModelResultService boxModelResultService = new BoxModelResultService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                boxModelResultService.Query = boxModelResultService.FillQuery(typeof(BoxModelResult), lang, 0, 1, "", "");

                else
                {
                    BoxModelResult boxModelResult = new BoxModelResult();
                    boxModelResult = boxModelResultService.GetBoxModelResultWithBoxModelResultID(BoxModelResultID);

                    if (boxModelResult == null)
                    {
                        return NotFound();
                    }

                    return Ok(boxModelResult);
                }
            }
        }
        // POST api/boxModelResult
        [Route("")]
        public IHttpActionResult Post([FromBody]BoxModelResult boxModelResult, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                BoxModelResultService boxModelResultService = new BoxModelResultService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!boxModelResultService.Add(boxModelResult))
                {
                    return BadRequest(String.Join("|||", boxModelResult.ValidationResults));
                }
                else
                {
                    boxModelResult.ValidationResults = null;
                    return Created<BoxModelResult>(new Uri(Request.RequestUri, boxModelResult.BoxModelResultID.ToString()), boxModelResult);
                }
            }
        }
        // PUT api/boxModelResult
        [Route("")]
        public IHttpActionResult Put([FromBody]BoxModelResult boxModelResult, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                BoxModelResultService boxModelResultService = new BoxModelResultService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!boxModelResultService.Update(boxModelResult))
                {
                    return BadRequest(String.Join("|||", boxModelResult.ValidationResults));
                }
                else
                {
                    boxModelResult.ValidationResults = null;
                    return Ok(boxModelResult);
                }
            }
        }
        // DELETE api/boxModelResult
        [Route("")]
        public IHttpActionResult Delete([FromBody]BoxModelResult boxModelResult, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                BoxModelResultService boxModelResultService = new BoxModelResultService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!boxModelResultService.Delete(boxModelResult))
                {
                    return BadRequest(String.Join("|||", boxModelResult.ValidationResults));
                }
                else
                {
                    boxModelResult.ValidationResults = null;
                    return Ok(boxModelResult);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
