using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CSSPWebAPI.Controllers
{
    [RoutePrefix("api/vpScenarioLanguage")]
    public partial class VPScenarioLanguageController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public VPScenarioLanguageController() : base()
        {
        }
        public VPScenarioLanguageController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/vpScenarioLanguage
        [Route("")]
        public IHttpActionResult GetVPScenarioLanguageList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                VPScenarioLanguageService vpScenarioLanguageService = new VPScenarioLanguageService(new Query() { Lang = lang }, db, ContactID);

                if (extra == "A") // QueryString contains [extra=A]
                {
                   vpScenarioLanguageService.Query = vpScenarioLanguageService.FillQuery(typeof(VPScenarioLanguageExtraA), lang, skip, take, asc, desc, where, extra);

                    if (vpScenarioLanguageService.Query.HasErrors)
                    {
                        return Ok(new List<VPScenarioLanguageExtraA>()
                        {
                            new VPScenarioLanguageExtraA()
                            {
                                HasErrors = vpScenarioLanguageService.Query.HasErrors,
                                ValidationResults = vpScenarioLanguageService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(vpScenarioLanguageService.GetVPScenarioLanguageExtraAList().ToList());
                    }
                }
                else if (extra == "B") // QueryString contains [extra=B]
                {
                   vpScenarioLanguageService.Query = vpScenarioLanguageService.FillQuery(typeof(VPScenarioLanguageExtraB), lang, skip, take, asc, desc, where, extra);

                    if (vpScenarioLanguageService.Query.HasErrors)
                    {
                        return Ok(new List<VPScenarioLanguageExtraB>()
                        {
                            new VPScenarioLanguageExtraB()
                            {
                                HasErrors = vpScenarioLanguageService.Query.HasErrors,
                                ValidationResults = vpScenarioLanguageService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(vpScenarioLanguageService.GetVPScenarioLanguageExtraBList().ToList());
                    }
                }
                else // QueryString has no parameter [extra] or extra is empty
                {
                   vpScenarioLanguageService.Query = vpScenarioLanguageService.FillQuery(typeof(VPScenarioLanguage), lang, skip, take, asc, desc, where, extra);

                    if (vpScenarioLanguageService.Query.HasErrors)
                    {
                        return Ok(new List<VPScenarioLanguage>()
                        {
                            new VPScenarioLanguage()
                            {
                                HasErrors = vpScenarioLanguageService.Query.HasErrors,
                                ValidationResults = vpScenarioLanguageService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(vpScenarioLanguageService.GetVPScenarioLanguageList().ToList());
                    }
                }
            }
        }
        // GET api/vpScenarioLanguage/1
        [Route("{VPScenarioLanguageID:int}")]
        public IHttpActionResult GetVPScenarioLanguageWithID([FromUri]int VPScenarioLanguageID, [FromUri]string lang = "en", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                VPScenarioLanguageService vpScenarioLanguageService = new VPScenarioLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                vpScenarioLanguageService.Query = vpScenarioLanguageService.FillQuery(typeof(VPScenarioLanguage), lang, 0, 1, "", "", extra);

                if (vpScenarioLanguageService.Query.Extra == "A")
                {
                    VPScenarioLanguageExtraA vpScenarioLanguageExtraA = new VPScenarioLanguageExtraA();
                    vpScenarioLanguageExtraA = vpScenarioLanguageService.GetVPScenarioLanguageExtraAWithVPScenarioLanguageID(VPScenarioLanguageID);

                    if (vpScenarioLanguageExtraA == null)
                    {
                        return NotFound();
                    }

                    return Ok(vpScenarioLanguageExtraA);
                }
                else if (vpScenarioLanguageService.Query.Extra == "B")
                {
                    VPScenarioLanguageExtraB vpScenarioLanguageExtraB = new VPScenarioLanguageExtraB();
                    vpScenarioLanguageExtraB = vpScenarioLanguageService.GetVPScenarioLanguageExtraBWithVPScenarioLanguageID(VPScenarioLanguageID);

                    if (vpScenarioLanguageExtraB == null)
                    {
                        return NotFound();
                    }

                    return Ok(vpScenarioLanguageExtraB);
                }
                else
                {
                    VPScenarioLanguage vpScenarioLanguage = new VPScenarioLanguage();
                    vpScenarioLanguage = vpScenarioLanguageService.GetVPScenarioLanguageWithVPScenarioLanguageID(VPScenarioLanguageID);

                    if (vpScenarioLanguage == null)
                    {
                        return NotFound();
                    }

                    return Ok(vpScenarioLanguage);
                }
            }
        }
        // POST api/vpScenarioLanguage
        [Route("")]
        public IHttpActionResult Post([FromBody]VPScenarioLanguage vpScenarioLanguage, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                VPScenarioLanguageService vpScenarioLanguageService = new VPScenarioLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!vpScenarioLanguageService.Add(vpScenarioLanguage))
                {
                    return BadRequest(String.Join("|||", vpScenarioLanguage.ValidationResults));
                }
                else
                {
                    vpScenarioLanguage.ValidationResults = null;
                    return Created<VPScenarioLanguage>(new Uri(Request.RequestUri, vpScenarioLanguage.VPScenarioLanguageID.ToString()), vpScenarioLanguage);
                }
            }
        }
        // PUT api/vpScenarioLanguage
        [Route("")]
        public IHttpActionResult Put([FromBody]VPScenarioLanguage vpScenarioLanguage, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                VPScenarioLanguageService vpScenarioLanguageService = new VPScenarioLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!vpScenarioLanguageService.Update(vpScenarioLanguage))
                {
                    return BadRequest(String.Join("|||", vpScenarioLanguage.ValidationResults));
                }
                else
                {
                    vpScenarioLanguage.ValidationResults = null;
                    return Ok(vpScenarioLanguage);
                }
            }
        }
        // DELETE api/vpScenarioLanguage
        [Route("")]
        public IHttpActionResult Delete([FromBody]VPScenarioLanguage vpScenarioLanguage, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                VPScenarioLanguageService vpScenarioLanguageService = new VPScenarioLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!vpScenarioLanguageService.Delete(vpScenarioLanguage))
                {
                    return BadRequest(String.Join("|||", vpScenarioLanguage.ValidationResults));
                }
                else
                {
                    vpScenarioLanguage.ValidationResults = null;
                    return Ok(vpScenarioLanguage);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
