using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CSSPWebAPI.Controllers
{
    [RoutePrefix("api/polSourceGrouping")]
    public partial class PolSourceGroupingController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public PolSourceGroupingController() : base()
        {
        }
        public PolSourceGroupingController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/polSourceGrouping
        [Route("")]
        public IHttpActionResult GetPolSourceGroupingList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                PolSourceGroupingService polSourceGroupingService = new PolSourceGroupingService(new Query() { Lang = lang }, db, ContactID);

                else // QueryString has no parameter [extra] or extra is empty
                {
                   polSourceGroupingService.Query = polSourceGroupingService.FillQuery(typeof(PolSourceGrouping), lang, skip, take, asc, desc, where, extra);

                    if (polSourceGroupingService.Query.HasErrors)
                    {
                        return Ok(new List<PolSourceGrouping>()
                        {
                            new PolSourceGrouping()
                            {
                                HasErrors = polSourceGroupingService.Query.HasErrors,
                                ValidationResults = polSourceGroupingService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(polSourceGroupingService.GetPolSourceGroupingList().ToList());
                    }
                }
            }
        }
        // GET api/polSourceGrouping/1
        [Route("{PolSourceGroupingID:int}")]
        public IHttpActionResult GetPolSourceGroupingWithID([FromUri]int PolSourceGroupingID, [FromUri]string lang = "en", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                PolSourceGroupingService polSourceGroupingService = new PolSourceGroupingService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                polSourceGroupingService.Query = polSourceGroupingService.FillQuery(typeof(PolSourceGrouping), lang, 0, 1, "", "", extra);

                else
                {
                    PolSourceGrouping polSourceGrouping = new PolSourceGrouping();
                    polSourceGrouping = polSourceGroupingService.GetPolSourceGroupingWithPolSourceGroupingID(PolSourceGroupingID);

                    if (polSourceGrouping == null)
                    {
                        return NotFound();
                    }

                    return Ok(polSourceGrouping);
                }
            }
        }
        // POST api/polSourceGrouping
        [Route("")]
        public IHttpActionResult Post([FromBody]PolSourceGrouping polSourceGrouping, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                PolSourceGroupingService polSourceGroupingService = new PolSourceGroupingService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!polSourceGroupingService.Add(polSourceGrouping))
                {
                    return BadRequest(String.Join("|||", polSourceGrouping.ValidationResults));
                }
                else
                {
                    polSourceGrouping.ValidationResults = null;
                    return Created<PolSourceGrouping>(new Uri(Request.RequestUri, polSourceGrouping.PolSourceGroupingID.ToString()), polSourceGrouping);
                }
            }
        }
        // PUT api/polSourceGrouping
        [Route("")]
        public IHttpActionResult Put([FromBody]PolSourceGrouping polSourceGrouping, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                PolSourceGroupingService polSourceGroupingService = new PolSourceGroupingService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!polSourceGroupingService.Update(polSourceGrouping))
                {
                    return BadRequest(String.Join("|||", polSourceGrouping.ValidationResults));
                }
                else
                {
                    polSourceGrouping.ValidationResults = null;
                    return Ok(polSourceGrouping);
                }
            }
        }
        // DELETE api/polSourceGrouping
        [Route("")]
        public IHttpActionResult Delete([FromBody]PolSourceGrouping polSourceGrouping, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                PolSourceGroupingService polSourceGroupingService = new PolSourceGroupingService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!polSourceGroupingService.Delete(polSourceGrouping))
                {
                    return BadRequest(String.Join("|||", polSourceGrouping.ValidationResults));
                }
                else
                {
                    polSourceGrouping.ValidationResults = null;
                    return Ok(polSourceGrouping);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
