using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;;

namespace CSSPWebAPI.Controllers
{
    [Route("api/infrastructureLanguage")]
    public partial class InfrastructureLanguageController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public InfrastructureLanguageController() : base()
        {
        }
        public InfrastructureLanguageController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/infrastructureLanguage
        [Route("")]
        public IHttpActionResult GetInfrastructureLanguageList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                InfrastructureLanguageService infrastructureLanguageService = new InfrastructureLanguageService(new Query() { Lang = lang }, db, ContactID);

                else
                {
                   infrastructureLanguageService.Query = infrastructureLanguageService.FillQuery(typeof(InfrastructureLanguage), lang, skip, take, asc, desc, where);

                    if (infrastructureLanguageService.Query.HasErrors)
                    {
                        return Ok(new List<InfrastructureLanguage>()
                        {
                            new InfrastructureLanguage()
                            {
                                HasErrors = infrastructureLanguageService.Query.HasErrors,
                                ValidationResults = infrastructureLanguageService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(infrastructureLanguageService.GetInfrastructureLanguageList().ToList());
                    }
                }
            }
        }
        // GET api/infrastructureLanguage/1
        [Route("{InfrastructureLanguageID:int}")]
        public IHttpActionResult GetInfrastructureLanguageWithID([FromUri]int InfrastructureLanguageID, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                InfrastructureLanguageService infrastructureLanguageService = new InfrastructureLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                infrastructureLanguageService.Query = infrastructureLanguageService.FillQuery(typeof(InfrastructureLanguage), lang, 0, 1, "", "");

                else
                {
                    InfrastructureLanguage infrastructureLanguage = new InfrastructureLanguage();
                    infrastructureLanguage = infrastructureLanguageService.GetInfrastructureLanguageWithInfrastructureLanguageID(InfrastructureLanguageID);

                    if (infrastructureLanguage == null)
                    {
                        return NotFound();
                    }

                    return Ok(infrastructureLanguage);
                }
            }
        }
        // POST api/infrastructureLanguage
        [Route("")]
        public IHttpActionResult Post([FromBody]InfrastructureLanguage infrastructureLanguage, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                InfrastructureLanguageService infrastructureLanguageService = new InfrastructureLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!infrastructureLanguageService.Add(infrastructureLanguage))
                {
                    return BadRequest(String.Join("|||", infrastructureLanguage.ValidationResults));
                }
                else
                {
                    infrastructureLanguage.ValidationResults = null;
                    return Created<InfrastructureLanguage>(new Uri(Request.RequestUri, infrastructureLanguage.InfrastructureLanguageID.ToString()), infrastructureLanguage);
                }
            }
        }
        // PUT api/infrastructureLanguage
        [Route("")]
        public IHttpActionResult Put([FromBody]InfrastructureLanguage infrastructureLanguage, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                InfrastructureLanguageService infrastructureLanguageService = new InfrastructureLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!infrastructureLanguageService.Update(infrastructureLanguage))
                {
                    return BadRequest(String.Join("|||", infrastructureLanguage.ValidationResults));
                }
                else
                {
                    infrastructureLanguage.ValidationResults = null;
                    return Ok(infrastructureLanguage);
                }
            }
        }
        // DELETE api/infrastructureLanguage
        [Route("")]
        public IHttpActionResult Delete([FromBody]InfrastructureLanguage infrastructureLanguage, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                InfrastructureLanguageService infrastructureLanguageService = new InfrastructureLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!infrastructureLanguageService.Delete(infrastructureLanguage))
                {
                    return BadRequest(String.Join("|||", infrastructureLanguage.ValidationResults));
                }
                else
                {
                    infrastructureLanguage.ValidationResults = null;
                    return Ok(infrastructureLanguage);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
