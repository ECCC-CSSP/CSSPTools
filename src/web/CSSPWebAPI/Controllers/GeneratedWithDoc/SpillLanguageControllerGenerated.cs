using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;;

namespace CSSPWebAPI.Controllers
{
    [Route("api/spillLanguage")]
    public partial class SpillLanguageController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public SpillLanguageController() : base()
        {
        }
        public SpillLanguageController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/spillLanguage
        [Route("")]
        public IHttpActionResult GetSpillLanguageList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                SpillLanguageService spillLanguageService = new SpillLanguageService(new Query() { Lang = lang }, db, ContactID);

                else
                {
                   spillLanguageService.Query = spillLanguageService.FillQuery(typeof(SpillLanguage), lang, skip, take, asc, desc, where);

                    if (spillLanguageService.Query.HasErrors)
                    {
                        return Ok(new List<SpillLanguage>()
                        {
                            new SpillLanguage()
                            {
                                HasErrors = spillLanguageService.Query.HasErrors,
                                ValidationResults = spillLanguageService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(spillLanguageService.GetSpillLanguageList().ToList());
                    }
                }
            }
        }
        // GET api/spillLanguage/1
        [Route("{SpillLanguageID:int}")]
        public IHttpActionResult GetSpillLanguageWithID([FromUri]int SpillLanguageID, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                SpillLanguageService spillLanguageService = new SpillLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                spillLanguageService.Query = spillLanguageService.FillQuery(typeof(SpillLanguage), lang, 0, 1, "", "");

                else
                {
                    SpillLanguage spillLanguage = new SpillLanguage();
                    spillLanguage = spillLanguageService.GetSpillLanguageWithSpillLanguageID(SpillLanguageID);

                    if (spillLanguage == null)
                    {
                        return NotFound();
                    }

                    return Ok(spillLanguage);
                }
            }
        }
        // POST api/spillLanguage
        [Route("")]
        public IHttpActionResult Post([FromBody]SpillLanguage spillLanguage, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                SpillLanguageService spillLanguageService = new SpillLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!spillLanguageService.Add(spillLanguage))
                {
                    return BadRequest(String.Join("|||", spillLanguage.ValidationResults));
                }
                else
                {
                    spillLanguage.ValidationResults = null;
                    return Created<SpillLanguage>(new Uri(Request.RequestUri, spillLanguage.SpillLanguageID.ToString()), spillLanguage);
                }
            }
        }
        // PUT api/spillLanguage
        [Route("")]
        public IHttpActionResult Put([FromBody]SpillLanguage spillLanguage, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                SpillLanguageService spillLanguageService = new SpillLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!spillLanguageService.Update(spillLanguage))
                {
                    return BadRequest(String.Join("|||", spillLanguage.ValidationResults));
                }
                else
                {
                    spillLanguage.ValidationResults = null;
                    return Ok(spillLanguage);
                }
            }
        }
        // DELETE api/spillLanguage
        [Route("")]
        public IHttpActionResult Delete([FromBody]SpillLanguage spillLanguage, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                SpillLanguageService spillLanguageService = new SpillLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!spillLanguageService.Delete(spillLanguage))
                {
                    return BadRequest(String.Join("|||", spillLanguage.ValidationResults));
                }
                else
                {
                    spillLanguage.ValidationResults = null;
                    return Ok(spillLanguage);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
