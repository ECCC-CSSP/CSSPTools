using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CSSPWebAPI.Controllers
{
    [RoutePrefix("api/hydrometricDataValue")]
    public partial class HydrometricDataValueController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public HydrometricDataValueController() : base()
        {
        }
        public HydrometricDataValueController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/hydrometricDataValue
        [Route("")]
        public IHttpActionResult GetHydrometricDataValueList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                HydrometricDataValueService hydrometricDataValueService = new HydrometricDataValueService(new Query() { Lang = lang }, db, ContactID);

                if (extra == "A") // QueryString contains [extra=A]
                {
                   hydrometricDataValueService.Query = hydrometricDataValueService.FillQuery(typeof(HydrometricDataValueExtraA), lang, skip, take, asc, desc, where, extra);

                    if (hydrometricDataValueService.Query.HasErrors)
                    {
                        return Ok(new List<HydrometricDataValueExtraA>()
                        {
                            new HydrometricDataValueExtraA()
                            {
                                HasErrors = hydrometricDataValueService.Query.HasErrors,
                                ValidationResults = hydrometricDataValueService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(hydrometricDataValueService.GetHydrometricDataValueExtraAList().ToList());
                    }
                }
                else if (extra == "B") // QueryString contains [extra=B]
                {
                   hydrometricDataValueService.Query = hydrometricDataValueService.FillQuery(typeof(HydrometricDataValueExtraB), lang, skip, take, asc, desc, where, extra);

                    if (hydrometricDataValueService.Query.HasErrors)
                    {
                        return Ok(new List<HydrometricDataValueExtraB>()
                        {
                            new HydrometricDataValueExtraB()
                            {
                                HasErrors = hydrometricDataValueService.Query.HasErrors,
                                ValidationResults = hydrometricDataValueService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(hydrometricDataValueService.GetHydrometricDataValueExtraBList().ToList());
                    }
                }
                else // QueryString has no parameter [extra] or extra is empty
                {
                   hydrometricDataValueService.Query = hydrometricDataValueService.FillQuery(typeof(HydrometricDataValue), lang, skip, take, asc, desc, where, extra);

                    if (hydrometricDataValueService.Query.HasErrors)
                    {
                        return Ok(new List<HydrometricDataValue>()
                        {
                            new HydrometricDataValue()
                            {
                                HasErrors = hydrometricDataValueService.Query.HasErrors,
                                ValidationResults = hydrometricDataValueService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(hydrometricDataValueService.GetHydrometricDataValueList().ToList());
                    }
                }
            }
        }
        // GET api/hydrometricDataValue/1
        [Route("{HydrometricDataValueID:int}")]
        public IHttpActionResult GetHydrometricDataValueWithID([FromUri]int HydrometricDataValueID, [FromUri]string lang = "en", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                HydrometricDataValueService hydrometricDataValueService = new HydrometricDataValueService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                hydrometricDataValueService.Query = hydrometricDataValueService.FillQuery(typeof(HydrometricDataValue), lang, 0, 1, "", "", extra);

                if (hydrometricDataValueService.Query.Extra == "A")
                {
                    HydrometricDataValueExtraA hydrometricDataValueExtraA = new HydrometricDataValueExtraA();
                    hydrometricDataValueExtraA = hydrometricDataValueService.GetHydrometricDataValueExtraAWithHydrometricDataValueID(HydrometricDataValueID);

                    if (hydrometricDataValueExtraA == null)
                    {
                        return NotFound();
                    }

                    return Ok(hydrometricDataValueExtraA);
                }
                else if (hydrometricDataValueService.Query.Extra == "B")
                {
                    HydrometricDataValueExtraB hydrometricDataValueExtraB = new HydrometricDataValueExtraB();
                    hydrometricDataValueExtraB = hydrometricDataValueService.GetHydrometricDataValueExtraBWithHydrometricDataValueID(HydrometricDataValueID);

                    if (hydrometricDataValueExtraB == null)
                    {
                        return NotFound();
                    }

                    return Ok(hydrometricDataValueExtraB);
                }
                else
                {
                    HydrometricDataValue hydrometricDataValue = new HydrometricDataValue();
                    hydrometricDataValue = hydrometricDataValueService.GetHydrometricDataValueWithHydrometricDataValueID(HydrometricDataValueID);

                    if (hydrometricDataValue == null)
                    {
                        return NotFound();
                    }

                    return Ok(hydrometricDataValue);
                }
            }
        }
        // POST api/hydrometricDataValue
        [Route("")]
        public IHttpActionResult Post([FromBody]HydrometricDataValue hydrometricDataValue, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                HydrometricDataValueService hydrometricDataValueService = new HydrometricDataValueService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!hydrometricDataValueService.Add(hydrometricDataValue))
                {
                    return BadRequest(String.Join("|||", hydrometricDataValue.ValidationResults));
                }
                else
                {
                    hydrometricDataValue.ValidationResults = null;
                    return Created<HydrometricDataValue>(new Uri(Request.RequestUri, hydrometricDataValue.HydrometricDataValueID.ToString()), hydrometricDataValue);
                }
            }
        }
        // PUT api/hydrometricDataValue
        [Route("")]
        public IHttpActionResult Put([FromBody]HydrometricDataValue hydrometricDataValue, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                HydrometricDataValueService hydrometricDataValueService = new HydrometricDataValueService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!hydrometricDataValueService.Update(hydrometricDataValue))
                {
                    return BadRequest(String.Join("|||", hydrometricDataValue.ValidationResults));
                }
                else
                {
                    hydrometricDataValue.ValidationResults = null;
                    return Ok(hydrometricDataValue);
                }
            }
        }
        // DELETE api/hydrometricDataValue
        [Route("")]
        public IHttpActionResult Delete([FromBody]HydrometricDataValue hydrometricDataValue, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                HydrometricDataValueService hydrometricDataValueService = new HydrometricDataValueService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!hydrometricDataValueService.Delete(hydrometricDataValue))
                {
                    return BadRequest(String.Join("|||", hydrometricDataValue.ValidationResults));
                }
                else
                {
                    hydrometricDataValue.ValidationResults = null;
                    return Ok(hydrometricDataValue);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
