using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;;

namespace CSSPWebAPI.Controllers
{
    [Route("api/mikeScenarioResult")]
    public partial class MikeScenarioResultController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MikeScenarioResultController() : base()
        {
        }
        public MikeScenarioResultController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/mikeScenarioResult
        [Route("")]
        public IHttpActionResult GetMikeScenarioResultList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MikeScenarioResultService mikeScenarioResultService = new MikeScenarioResultService(new Query() { Lang = lang }, db, ContactID);

                else
                {
                   mikeScenarioResultService.Query = mikeScenarioResultService.FillQuery(typeof(MikeScenarioResult), lang, skip, take, asc, desc, where);

                    if (mikeScenarioResultService.Query.HasErrors)
                    {
                        return Ok(new List<MikeScenarioResult>()
                        {
                            new MikeScenarioResult()
                            {
                                HasErrors = mikeScenarioResultService.Query.HasErrors,
                                ValidationResults = mikeScenarioResultService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(mikeScenarioResultService.GetMikeScenarioResultList().ToList());
                    }
                }
            }
        }
        // GET api/mikeScenarioResult/1
        [Route("{MikeScenarioResultID:int}")]
        public IHttpActionResult GetMikeScenarioResultWithID([FromUri]int MikeScenarioResultID, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MikeScenarioResultService mikeScenarioResultService = new MikeScenarioResultService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                mikeScenarioResultService.Query = mikeScenarioResultService.FillQuery(typeof(MikeScenarioResult), lang, 0, 1, "", "");

                else
                {
                    MikeScenarioResult mikeScenarioResult = new MikeScenarioResult();
                    mikeScenarioResult = mikeScenarioResultService.GetMikeScenarioResultWithMikeScenarioResultID(MikeScenarioResultID);

                    if (mikeScenarioResult == null)
                    {
                        return NotFound();
                    }

                    return Ok(mikeScenarioResult);
                }
            }
        }
        // POST api/mikeScenarioResult
        [Route("")]
        public IHttpActionResult Post([FromBody]MikeScenarioResult mikeScenarioResult, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MikeScenarioResultService mikeScenarioResultService = new MikeScenarioResultService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!mikeScenarioResultService.Add(mikeScenarioResult))
                {
                    return BadRequest(String.Join("|||", mikeScenarioResult.ValidationResults));
                }
                else
                {
                    mikeScenarioResult.ValidationResults = null;
                    return Created<MikeScenarioResult>(new Uri(Request.RequestUri, mikeScenarioResult.MikeScenarioResultID.ToString()), mikeScenarioResult);
                }
            }
        }
        // PUT api/mikeScenarioResult
        [Route("")]
        public IHttpActionResult Put([FromBody]MikeScenarioResult mikeScenarioResult, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MikeScenarioResultService mikeScenarioResultService = new MikeScenarioResultService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!mikeScenarioResultService.Update(mikeScenarioResult))
                {
                    return BadRequest(String.Join("|||", mikeScenarioResult.ValidationResults));
                }
                else
                {
                    mikeScenarioResult.ValidationResults = null;
                    return Ok(mikeScenarioResult);
                }
            }
        }
        // DELETE api/mikeScenarioResult
        [Route("")]
        public IHttpActionResult Delete([FromBody]MikeScenarioResult mikeScenarioResult, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MikeScenarioResultService mikeScenarioResultService = new MikeScenarioResultService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!mikeScenarioResultService.Delete(mikeScenarioResult))
                {
                    return BadRequest(String.Join("|||", mikeScenarioResult.ValidationResults));
                }
                else
                {
                    mikeScenarioResult.ValidationResults = null;
                    return Ok(mikeScenarioResult);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
