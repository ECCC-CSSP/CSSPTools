using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CSSPWebAPI.Controllers
{
    [RoutePrefix("api/climateDataValue")]
    public partial class ClimateDataValueController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ClimateDataValueController() : base()
        {
        }
        public ClimateDataValueController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/climateDataValue
        [Route("")]
        public IHttpActionResult GetClimateDataValueList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ClimateDataValueService climateDataValueService = new ClimateDataValueService(new Query() { Lang = lang }, db, ContactID);

                else // QueryString has no parameter [extra] or extra is empty
                {
                   climateDataValueService.Query = climateDataValueService.FillQuery(typeof(ClimateDataValue), lang, skip, take, asc, desc, where, extra);

                    if (climateDataValueService.Query.HasErrors)
                    {
                        return Ok(new List<ClimateDataValue>()
                        {
                            new ClimateDataValue()
                            {
                                HasErrors = climateDataValueService.Query.HasErrors,
                                ValidationResults = climateDataValueService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(climateDataValueService.GetClimateDataValueList().ToList());
                    }
                }
            }
        }
        // GET api/climateDataValue/1
        [Route("{ClimateDataValueID:int}")]
        public IHttpActionResult GetClimateDataValueWithID([FromUri]int ClimateDataValueID, [FromUri]string lang = "en", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ClimateDataValueService climateDataValueService = new ClimateDataValueService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                climateDataValueService.Query = climateDataValueService.FillQuery(typeof(ClimateDataValue), lang, 0, 1, "", "", extra);

                else
                {
                    ClimateDataValue climateDataValue = new ClimateDataValue();
                    climateDataValue = climateDataValueService.GetClimateDataValueWithClimateDataValueID(ClimateDataValueID);

                    if (climateDataValue == null)
                    {
                        return NotFound();
                    }

                    return Ok(climateDataValue);
                }
            }
        }
        // POST api/climateDataValue
        [Route("")]
        public IHttpActionResult Post([FromBody]ClimateDataValue climateDataValue, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ClimateDataValueService climateDataValueService = new ClimateDataValueService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!climateDataValueService.Add(climateDataValue))
                {
                    return BadRequest(String.Join("|||", climateDataValue.ValidationResults));
                }
                else
                {
                    climateDataValue.ValidationResults = null;
                    return Created<ClimateDataValue>(new Uri(Request.RequestUri, climateDataValue.ClimateDataValueID.ToString()), climateDataValue);
                }
            }
        }
        // PUT api/climateDataValue
        [Route("")]
        public IHttpActionResult Put([FromBody]ClimateDataValue climateDataValue, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ClimateDataValueService climateDataValueService = new ClimateDataValueService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!climateDataValueService.Update(climateDataValue))
                {
                    return BadRequest(String.Join("|||", climateDataValue.ValidationResults));
                }
                else
                {
                    climateDataValue.ValidationResults = null;
                    return Ok(climateDataValue);
                }
            }
        }
        // DELETE api/climateDataValue
        [Route("")]
        public IHttpActionResult Delete([FromBody]ClimateDataValue climateDataValue, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ClimateDataValueService climateDataValueService = new ClimateDataValueService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!climateDataValueService.Delete(climateDataValue))
                {
                    return BadRequest(String.Join("|||", climateDataValue.ValidationResults));
                }
                else
                {
                    climateDataValue.ValidationResults = null;
                    return Ok(climateDataValue);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
