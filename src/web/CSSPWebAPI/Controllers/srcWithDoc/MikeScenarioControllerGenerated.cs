using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CSSPWebAPI.Controllers
{
    [RoutePrefix("api/mikeScenario")]
    public partial class MikeScenarioController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MikeScenarioController() : base()
        {
        }
        public MikeScenarioController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/mikeScenario
        [Route("")]
        public IHttpActionResult GetMikeScenarioList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MikeScenarioService mikeScenarioService = new MikeScenarioService(new Query() { Lang = lang }, db, ContactID);

                if (extra == "A") // QueryString contains [extra=A]
                {
                   mikeScenarioService.Query = mikeScenarioService.FillQuery(typeof(MikeScenarioExtraA), lang, skip, take, asc, desc, where, extra);

                    if (mikeScenarioService.Query.HasErrors)
                    {
                        return Ok(new List<MikeScenarioExtraA>()
                        {
                            new MikeScenarioExtraA()
                            {
                                HasErrors = mikeScenarioService.Query.HasErrors,
                                ValidationResults = mikeScenarioService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(mikeScenarioService.GetMikeScenarioExtraAList().ToList());
                    }
                }
                else if (extra == "B") // QueryString contains [extra=B]
                {
                   mikeScenarioService.Query = mikeScenarioService.FillQuery(typeof(MikeScenarioExtraB), lang, skip, take, asc, desc, where, extra);

                    if (mikeScenarioService.Query.HasErrors)
                    {
                        return Ok(new List<MikeScenarioExtraB>()
                        {
                            new MikeScenarioExtraB()
                            {
                                HasErrors = mikeScenarioService.Query.HasErrors,
                                ValidationResults = mikeScenarioService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(mikeScenarioService.GetMikeScenarioExtraBList().ToList());
                    }
                }
                else // QueryString has no parameter [extra] or extra is empty
                {
                   mikeScenarioService.Query = mikeScenarioService.FillQuery(typeof(MikeScenario), lang, skip, take, asc, desc, where, extra);

                    if (mikeScenarioService.Query.HasErrors)
                    {
                        return Ok(new List<MikeScenario>()
                        {
                            new MikeScenario()
                            {
                                HasErrors = mikeScenarioService.Query.HasErrors,
                                ValidationResults = mikeScenarioService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(mikeScenarioService.GetMikeScenarioList().ToList());
                    }
                }
            }
        }
        // GET api/mikeScenario/1
        [Route("{MikeScenarioID:int}")]
        public IHttpActionResult GetMikeScenarioWithID([FromUri]int MikeScenarioID, [FromUri]string lang = "en", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MikeScenarioService mikeScenarioService = new MikeScenarioService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                mikeScenarioService.Query = mikeScenarioService.FillQuery(typeof(MikeScenario), lang, 0, 1, "", "", extra);

                if (mikeScenarioService.Query.Extra == "A")
                {
                    MikeScenarioExtraA mikeScenarioExtraA = new MikeScenarioExtraA();
                    mikeScenarioExtraA = mikeScenarioService.GetMikeScenarioExtraAWithMikeScenarioID(MikeScenarioID);

                    if (mikeScenarioExtraA == null)
                    {
                        return NotFound();
                    }

                    return Ok(mikeScenarioExtraA);
                }
                else if (mikeScenarioService.Query.Extra == "B")
                {
                    MikeScenarioExtraB mikeScenarioExtraB = new MikeScenarioExtraB();
                    mikeScenarioExtraB = mikeScenarioService.GetMikeScenarioExtraBWithMikeScenarioID(MikeScenarioID);

                    if (mikeScenarioExtraB == null)
                    {
                        return NotFound();
                    }

                    return Ok(mikeScenarioExtraB);
                }
                else
                {
                    MikeScenario mikeScenario = new MikeScenario();
                    mikeScenario = mikeScenarioService.GetMikeScenarioWithMikeScenarioID(MikeScenarioID);

                    if (mikeScenario == null)
                    {
                        return NotFound();
                    }

                    return Ok(mikeScenario);
                }
            }
        }
        // POST api/mikeScenario
        [Route("")]
        public IHttpActionResult Post([FromBody]MikeScenario mikeScenario, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MikeScenarioService mikeScenarioService = new MikeScenarioService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!mikeScenarioService.Add(mikeScenario))
                {
                    return BadRequest(String.Join("|||", mikeScenario.ValidationResults));
                }
                else
                {
                    mikeScenario.ValidationResults = null;
                    return Created<MikeScenario>(new Uri(Request.RequestUri, mikeScenario.MikeScenarioID.ToString()), mikeScenario);
                }
            }
        }
        // PUT api/mikeScenario
        [Route("")]
        public IHttpActionResult Put([FromBody]MikeScenario mikeScenario, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MikeScenarioService mikeScenarioService = new MikeScenarioService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!mikeScenarioService.Update(mikeScenario))
                {
                    return BadRequest(String.Join("|||", mikeScenario.ValidationResults));
                }
                else
                {
                    mikeScenario.ValidationResults = null;
                    return Ok(mikeScenario);
                }
            }
        }
        // DELETE api/mikeScenario
        [Route("")]
        public IHttpActionResult Delete([FromBody]MikeScenario mikeScenario, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MikeScenarioService mikeScenarioService = new MikeScenarioService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!mikeScenarioService.Delete(mikeScenario))
                {
                    return BadRequest(String.Join("|||", mikeScenario.ValidationResults));
                }
                else
                {
                    mikeScenario.ValidationResults = null;
                    return Ok(mikeScenario);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
