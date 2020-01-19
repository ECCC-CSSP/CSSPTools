using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;;

namespace CSSPWebAPI.Controllers
{
    [Route("api/tideDataValue")]
    public partial class TideDataValueController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public TideDataValueController() : base()
        {
        }
        public TideDataValueController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/tideDataValue
        [Route("")]
        public IHttpActionResult GetTideDataValueList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TideDataValueService tideDataValueService = new TideDataValueService(new Query() { Lang = lang }, db, ContactID);

                else
                {
                   tideDataValueService.Query = tideDataValueService.FillQuery(typeof(TideDataValue), lang, skip, take, asc, desc, where);

                    if (tideDataValueService.Query.HasErrors)
                    {
                        return Ok(new List<TideDataValue>()
                        {
                            new TideDataValue()
                            {
                                HasErrors = tideDataValueService.Query.HasErrors,
                                ValidationResults = tideDataValueService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(tideDataValueService.GetTideDataValueList().ToList());
                    }
                }
            }
        }
        // GET api/tideDataValue/1
        [Route("{TideDataValueID:int}")]
        public IHttpActionResult GetTideDataValueWithID([FromUri]int TideDataValueID, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TideDataValueService tideDataValueService = new TideDataValueService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                tideDataValueService.Query = tideDataValueService.FillQuery(typeof(TideDataValue), lang, 0, 1, "", "");

                else
                {
                    TideDataValue tideDataValue = new TideDataValue();
                    tideDataValue = tideDataValueService.GetTideDataValueWithTideDataValueID(TideDataValueID);

                    if (tideDataValue == null)
                    {
                        return NotFound();
                    }

                    return Ok(tideDataValue);
                }
            }
        }
        // POST api/tideDataValue
        [Route("")]
        public IHttpActionResult Post([FromBody]TideDataValue tideDataValue, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TideDataValueService tideDataValueService = new TideDataValueService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!tideDataValueService.Add(tideDataValue))
                {
                    return BadRequest(String.Join("|||", tideDataValue.ValidationResults));
                }
                else
                {
                    tideDataValue.ValidationResults = null;
                    return Created<TideDataValue>(new Uri(Request.RequestUri, tideDataValue.TideDataValueID.ToString()), tideDataValue);
                }
            }
        }
        // PUT api/tideDataValue
        [Route("")]
        public IHttpActionResult Put([FromBody]TideDataValue tideDataValue, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TideDataValueService tideDataValueService = new TideDataValueService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!tideDataValueService.Update(tideDataValue))
                {
                    return BadRequest(String.Join("|||", tideDataValue.ValidationResults));
                }
                else
                {
                    tideDataValue.ValidationResults = null;
                    return Ok(tideDataValue);
                }
            }
        }
        // DELETE api/tideDataValue
        [Route("")]
        public IHttpActionResult Delete([FromBody]TideDataValue tideDataValue, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TideDataValueService tideDataValueService = new TideDataValueService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!tideDataValueService.Delete(tideDataValue))
                {
                    return BadRequest(String.Join("|||", tideDataValue.ValidationResults));
                }
                else
                {
                    tideDataValue.ValidationResults = null;
                    return Ok(tideDataValue);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
