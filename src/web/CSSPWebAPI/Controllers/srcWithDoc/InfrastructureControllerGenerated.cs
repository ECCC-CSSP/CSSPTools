using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CSSPWebAPI.Controllers
{
    [RoutePrefix("api/infrastructure")]
    public partial class InfrastructureController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public InfrastructureController() : base()
        {
        }
        public InfrastructureController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/infrastructure
        [Route("")]
        public IHttpActionResult GetInfrastructureList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                InfrastructureService infrastructureService = new InfrastructureService(new Query() { Lang = lang }, db, ContactID);

                if (extra == "A") // QueryString contains [extra=A]
                {
                   infrastructureService.Query = infrastructureService.FillQuery(typeof(InfrastructureExtraA), lang, skip, take, asc, desc, where, extra);

                    if (infrastructureService.Query.HasErrors)
                    {
                        return Ok(new List<InfrastructureExtraA>()
                        {
                            new InfrastructureExtraA()
                            {
                                HasErrors = infrastructureService.Query.HasErrors,
                                ValidationResults = infrastructureService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(infrastructureService.GetInfrastructureExtraAList().ToList());
                    }
                }
                else if (extra == "B") // QueryString contains [extra=B]
                {
                   infrastructureService.Query = infrastructureService.FillQuery(typeof(InfrastructureExtraB), lang, skip, take, asc, desc, where, extra);

                    if (infrastructureService.Query.HasErrors)
                    {
                        return Ok(new List<InfrastructureExtraB>()
                        {
                            new InfrastructureExtraB()
                            {
                                HasErrors = infrastructureService.Query.HasErrors,
                                ValidationResults = infrastructureService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(infrastructureService.GetInfrastructureExtraBList().ToList());
                    }
                }
                else // QueryString has no parameter [extra] or extra is empty
                {
                   infrastructureService.Query = infrastructureService.FillQuery(typeof(Infrastructure), lang, skip, take, asc, desc, where, extra);

                    if (infrastructureService.Query.HasErrors)
                    {
                        return Ok(new List<Infrastructure>()
                        {
                            new Infrastructure()
                            {
                                HasErrors = infrastructureService.Query.HasErrors,
                                ValidationResults = infrastructureService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(infrastructureService.GetInfrastructureList().ToList());
                    }
                }
            }
        }
        // GET api/infrastructure/1
        [Route("{InfrastructureID:int}")]
        public IHttpActionResult GetInfrastructureWithID([FromUri]int InfrastructureID, [FromUri]string lang = "en", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                InfrastructureService infrastructureService = new InfrastructureService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                infrastructureService.Query = infrastructureService.FillQuery(typeof(Infrastructure), lang, 0, 1, "", "", extra);

                if (infrastructureService.Query.Extra == "A")
                {
                    InfrastructureExtraA infrastructureExtraA = new InfrastructureExtraA();
                    infrastructureExtraA = infrastructureService.GetInfrastructureExtraAWithInfrastructureID(InfrastructureID);

                    if (infrastructureExtraA == null)
                    {
                        return NotFound();
                    }

                    return Ok(infrastructureExtraA);
                }
                else if (infrastructureService.Query.Extra == "B")
                {
                    InfrastructureExtraB infrastructureExtraB = new InfrastructureExtraB();
                    infrastructureExtraB = infrastructureService.GetInfrastructureExtraBWithInfrastructureID(InfrastructureID);

                    if (infrastructureExtraB == null)
                    {
                        return NotFound();
                    }

                    return Ok(infrastructureExtraB);
                }
                else
                {
                    Infrastructure infrastructure = new Infrastructure();
                    infrastructure = infrastructureService.GetInfrastructureWithInfrastructureID(InfrastructureID);

                    if (infrastructure == null)
                    {
                        return NotFound();
                    }

                    return Ok(infrastructure);
                }
            }
        }
        // POST api/infrastructure
        [Route("")]
        public IHttpActionResult Post([FromBody]Infrastructure infrastructure, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                InfrastructureService infrastructureService = new InfrastructureService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!infrastructureService.Add(infrastructure))
                {
                    return BadRequest(String.Join("|||", infrastructure.ValidationResults));
                }
                else
                {
                    infrastructure.ValidationResults = null;
                    return Created<Infrastructure>(new Uri(Request.RequestUri, infrastructure.InfrastructureID.ToString()), infrastructure);
                }
            }
        }
        // PUT api/infrastructure
        [Route("")]
        public IHttpActionResult Put([FromBody]Infrastructure infrastructure, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                InfrastructureService infrastructureService = new InfrastructureService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!infrastructureService.Update(infrastructure))
                {
                    return BadRequest(String.Join("|||", infrastructure.ValidationResults));
                }
                else
                {
                    infrastructure.ValidationResults = null;
                    return Ok(infrastructure);
                }
            }
        }
        // DELETE api/infrastructure
        [Route("")]
        public IHttpActionResult Delete([FromBody]Infrastructure infrastructure, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                InfrastructureService infrastructureService = new InfrastructureService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!infrastructureService.Delete(infrastructure))
                {
                    return BadRequest(String.Join("|||", infrastructure.ValidationResults));
                }
                else
                {
                    infrastructure.ValidationResults = null;
                    return Ok(infrastructure);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
