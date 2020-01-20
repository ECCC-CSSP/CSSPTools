using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CSSPWebAPI.Controllers
{
    [RoutePrefix("api/vpAmbient")]
    public partial class VPAmbientController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public VPAmbientController() : base()
        {
        }
        public VPAmbientController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/vpAmbient
        [Route("")]
        public IHttpActionResult GetVPAmbientList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                VPAmbientService vpAmbientService = new VPAmbientService(new Query() { Lang = lang }, db, ContactID);

                if (extra == "A") // QueryString contains [extra=A]
                {
                   vpAmbientService.Query = vpAmbientService.FillQuery(typeof(VPAmbientExtraA), lang, skip, take, asc, desc, where, extra);

                    if (vpAmbientService.Query.HasErrors)
                    {
                        return Ok(new List<VPAmbientExtraA>()
                        {
                            new VPAmbientExtraA()
                            {
                                HasErrors = vpAmbientService.Query.HasErrors,
                                ValidationResults = vpAmbientService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(vpAmbientService.GetVPAmbientExtraAList().ToList());
                    }
                }
                else if (extra == "B") // QueryString contains [extra=B]
                {
                   vpAmbientService.Query = vpAmbientService.FillQuery(typeof(VPAmbientExtraB), lang, skip, take, asc, desc, where, extra);

                    if (vpAmbientService.Query.HasErrors)
                    {
                        return Ok(new List<VPAmbientExtraB>()
                        {
                            new VPAmbientExtraB()
                            {
                                HasErrors = vpAmbientService.Query.HasErrors,
                                ValidationResults = vpAmbientService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(vpAmbientService.GetVPAmbientExtraBList().ToList());
                    }
                }
                else // QueryString has no parameter [extra] or extra is empty
                {
                   vpAmbientService.Query = vpAmbientService.FillQuery(typeof(VPAmbient), lang, skip, take, asc, desc, where, extra);

                    if (vpAmbientService.Query.HasErrors)
                    {
                        return Ok(new List<VPAmbient>()
                        {
                            new VPAmbient()
                            {
                                HasErrors = vpAmbientService.Query.HasErrors,
                                ValidationResults = vpAmbientService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(vpAmbientService.GetVPAmbientList().ToList());
                    }
                }
            }
        }
        // GET api/vpAmbient/1
        [Route("{VPAmbientID:int}")]
        public IHttpActionResult GetVPAmbientWithID([FromUri]int VPAmbientID, [FromUri]string lang = "en", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                VPAmbientService vpAmbientService = new VPAmbientService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                vpAmbientService.Query = vpAmbientService.FillQuery(typeof(VPAmbient), lang, 0, 1, "", "", extra);

                if (vpAmbientService.Query.Extra == "A")
                {
                    VPAmbientExtraA vpAmbientExtraA = new VPAmbientExtraA();
                    vpAmbientExtraA = vpAmbientService.GetVPAmbientExtraAWithVPAmbientID(VPAmbientID);

                    if (vpAmbientExtraA == null)
                    {
                        return NotFound();
                    }

                    return Ok(vpAmbientExtraA);
                }
                else if (vpAmbientService.Query.Extra == "B")
                {
                    VPAmbientExtraB vpAmbientExtraB = new VPAmbientExtraB();
                    vpAmbientExtraB = vpAmbientService.GetVPAmbientExtraBWithVPAmbientID(VPAmbientID);

                    if (vpAmbientExtraB == null)
                    {
                        return NotFound();
                    }

                    return Ok(vpAmbientExtraB);
                }
                else
                {
                    VPAmbient vpAmbient = new VPAmbient();
                    vpAmbient = vpAmbientService.GetVPAmbientWithVPAmbientID(VPAmbientID);

                    if (vpAmbient == null)
                    {
                        return NotFound();
                    }

                    return Ok(vpAmbient);
                }
            }
        }
        // POST api/vpAmbient
        [Route("")]
        public IHttpActionResult Post([FromBody]VPAmbient vpAmbient, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                VPAmbientService vpAmbientService = new VPAmbientService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!vpAmbientService.Add(vpAmbient))
                {
                    return BadRequest(String.Join("|||", vpAmbient.ValidationResults));
                }
                else
                {
                    vpAmbient.ValidationResults = null;
                    return Created<VPAmbient>(new Uri(Request.RequestUri, vpAmbient.VPAmbientID.ToString()), vpAmbient);
                }
            }
        }
        // PUT api/vpAmbient
        [Route("")]
        public IHttpActionResult Put([FromBody]VPAmbient vpAmbient, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                VPAmbientService vpAmbientService = new VPAmbientService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!vpAmbientService.Update(vpAmbient))
                {
                    return BadRequest(String.Join("|||", vpAmbient.ValidationResults));
                }
                else
                {
                    vpAmbient.ValidationResults = null;
                    return Ok(vpAmbient);
                }
            }
        }
        // DELETE api/vpAmbient
        [Route("")]
        public IHttpActionResult Delete([FromBody]VPAmbient vpAmbient, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                VPAmbientService vpAmbientService = new VPAmbientService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!vpAmbientService.Delete(vpAmbient))
                {
                    return BadRequest(String.Join("|||", vpAmbient.ValidationResults));
                }
                else
                {
                    vpAmbient.ValidationResults = null;
                    return Ok(vpAmbient);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
