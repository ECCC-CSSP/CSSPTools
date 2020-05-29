using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CSSPWebAPI.Controllers
{
    [RoutePrefix("api/vpResult")]
    public partial class VPResultController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public VPResultController() : base()
        {
        }
        public VPResultController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/vpResult
        [Route("")]
        public IHttpActionResult GetVPResultList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                VPResultService vpResultService = new VPResultService(new Query() { Lang = lang }, db, ContactID);

                else // QueryString has no parameter [extra] or extra is empty
                {
                   vpResultService.Query = vpResultService.FillQuery(typeof(VPResult), lang, skip, take, asc, desc, where, extra);

                    if (vpResultService.Query.HasErrors)
                    {
                        return Ok(new List<VPResult>()
                        {
                            new VPResult()
                            {
                                HasErrors = vpResultService.Query.HasErrors,
                                ValidationResults = vpResultService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(vpResultService.GetVPResultList().ToList());
                    }
                }
            }
        }
        // GET api/vpResult/1
        [Route("{VPResultID:int}")]
        public IHttpActionResult GetVPResultWithID([FromUri]int VPResultID, [FromUri]string lang = "en", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                VPResultService vpResultService = new VPResultService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                vpResultService.Query = vpResultService.FillQuery(typeof(VPResult), lang, 0, 1, "", "", extra);

                else
                {
                    VPResult vpResult = new VPResult();
                    vpResult = vpResultService.GetVPResultWithVPResultID(VPResultID);

                    if (vpResult == null)
                    {
                        return NotFound();
                    }

                    return Ok(vpResult);
                }
            }
        }
        // POST api/vpResult
        [Route("")]
        public IHttpActionResult Post([FromBody]VPResult vpResult, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                VPResultService vpResultService = new VPResultService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!vpResultService.Add(vpResult))
                {
                    return BadRequest(String.Join("|||", vpResult.ValidationResults));
                }
                else
                {
                    vpResult.ValidationResults = null;
                    return Created<VPResult>(new Uri(Request.RequestUri, vpResult.VPResultID.ToString()), vpResult);
                }
            }
        }
        // PUT api/vpResult
        [Route("")]
        public IHttpActionResult Put([FromBody]VPResult vpResult, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                VPResultService vpResultService = new VPResultService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!vpResultService.Update(vpResult))
                {
                    return BadRequest(String.Join("|||", vpResult.ValidationResults));
                }
                else
                {
                    vpResult.ValidationResults = null;
                    return Ok(vpResult);
                }
            }
        }
        // DELETE api/vpResult
        [Route("")]
        public IHttpActionResult Delete([FromBody]VPResult vpResult, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                VPResultService vpResultService = new VPResultService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!vpResultService.Delete(vpResult))
                {
                    return BadRequest(String.Join("|||", vpResult.ValidationResults));
                }
                else
                {
                    vpResult.ValidationResults = null;
                    return Ok(vpResult);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
