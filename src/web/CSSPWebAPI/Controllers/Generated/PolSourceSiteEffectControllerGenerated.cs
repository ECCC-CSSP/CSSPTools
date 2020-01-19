using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;;

namespace CSSPWebAPI.Controllers
{
    [Route("api/polSourceSiteEffect")]
    public partial class PolSourceSiteEffectController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public PolSourceSiteEffectController() : base()
        {
        }
        public PolSourceSiteEffectController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/polSourceSiteEffect
        [Route("")]
        public IHttpActionResult GetPolSourceSiteEffectList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                PolSourceSiteEffectService polSourceSiteEffectService = new PolSourceSiteEffectService(new Query() { Lang = lang }, db, ContactID);

                else
                {
                   polSourceSiteEffectService.Query = polSourceSiteEffectService.FillQuery(typeof(PolSourceSiteEffect), lang, skip, take, asc, desc, where);

                    if (polSourceSiteEffectService.Query.HasErrors)
                    {
                        return Ok(new List<PolSourceSiteEffect>()
                        {
                            new PolSourceSiteEffect()
                            {
                                HasErrors = polSourceSiteEffectService.Query.HasErrors,
                                ValidationResults = polSourceSiteEffectService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(polSourceSiteEffectService.GetPolSourceSiteEffectList().ToList());
                    }
                }
            }
        }
        // GET api/polSourceSiteEffect/1
        [Route("{PolSourceSiteEffectID:int}")]
        public IHttpActionResult GetPolSourceSiteEffectWithID([FromUri]int PolSourceSiteEffectID, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                PolSourceSiteEffectService polSourceSiteEffectService = new PolSourceSiteEffectService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                polSourceSiteEffectService.Query = polSourceSiteEffectService.FillQuery(typeof(PolSourceSiteEffect), lang, 0, 1, "", "");

                else
                {
                    PolSourceSiteEffect polSourceSiteEffect = new PolSourceSiteEffect();
                    polSourceSiteEffect = polSourceSiteEffectService.GetPolSourceSiteEffectWithPolSourceSiteEffectID(PolSourceSiteEffectID);

                    if (polSourceSiteEffect == null)
                    {
                        return NotFound();
                    }

                    return Ok(polSourceSiteEffect);
                }
            }
        }
        // POST api/polSourceSiteEffect
        [Route("")]
        public IHttpActionResult Post([FromBody]PolSourceSiteEffect polSourceSiteEffect, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                PolSourceSiteEffectService polSourceSiteEffectService = new PolSourceSiteEffectService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!polSourceSiteEffectService.Add(polSourceSiteEffect))
                {
                    return BadRequest(String.Join("|||", polSourceSiteEffect.ValidationResults));
                }
                else
                {
                    polSourceSiteEffect.ValidationResults = null;
                    return Created<PolSourceSiteEffect>(new Uri(Request.RequestUri, polSourceSiteEffect.PolSourceSiteEffectID.ToString()), polSourceSiteEffect);
                }
            }
        }
        // PUT api/polSourceSiteEffect
        [Route("")]
        public IHttpActionResult Put([FromBody]PolSourceSiteEffect polSourceSiteEffect, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                PolSourceSiteEffectService polSourceSiteEffectService = new PolSourceSiteEffectService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!polSourceSiteEffectService.Update(polSourceSiteEffect))
                {
                    return BadRequest(String.Join("|||", polSourceSiteEffect.ValidationResults));
                }
                else
                {
                    polSourceSiteEffect.ValidationResults = null;
                    return Ok(polSourceSiteEffect);
                }
            }
        }
        // DELETE api/polSourceSiteEffect
        [Route("")]
        public IHttpActionResult Delete([FromBody]PolSourceSiteEffect polSourceSiteEffect, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                PolSourceSiteEffectService polSourceSiteEffectService = new PolSourceSiteEffectService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!polSourceSiteEffectService.Delete(polSourceSiteEffect))
                {
                    return BadRequest(String.Join("|||", polSourceSiteEffect.ValidationResults));
                }
                else
                {
                    polSourceSiteEffect.ValidationResults = null;
                    return Ok(polSourceSiteEffect);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
