using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CSSPWebAPI.Controllers
{
    [RoutePrefix("api/mikeBoundaryCondition")]
    public partial class MikeBoundaryConditionController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MikeBoundaryConditionController() : base()
        {
        }
        public MikeBoundaryConditionController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/mikeBoundaryCondition
        [Route("")]
        public IHttpActionResult GetMikeBoundaryConditionList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MikeBoundaryConditionService mikeBoundaryConditionService = new MikeBoundaryConditionService(new Query() { Lang = lang }, db, ContactID);

                else // QueryString has no parameter [extra] or extra is empty
                {
                   mikeBoundaryConditionService.Query = mikeBoundaryConditionService.FillQuery(typeof(MikeBoundaryCondition), lang, skip, take, asc, desc, where, extra);

                    if (mikeBoundaryConditionService.Query.HasErrors)
                    {
                        return Ok(new List<MikeBoundaryCondition>()
                        {
                            new MikeBoundaryCondition()
                            {
                                HasErrors = mikeBoundaryConditionService.Query.HasErrors,
                                ValidationResults = mikeBoundaryConditionService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(mikeBoundaryConditionService.GetMikeBoundaryConditionList().ToList());
                    }
                }
            }
        }
        // GET api/mikeBoundaryCondition/1
        [Route("{MikeBoundaryConditionID:int}")]
        public IHttpActionResult GetMikeBoundaryConditionWithID([FromUri]int MikeBoundaryConditionID, [FromUri]string lang = "en", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MikeBoundaryConditionService mikeBoundaryConditionService = new MikeBoundaryConditionService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                mikeBoundaryConditionService.Query = mikeBoundaryConditionService.FillQuery(typeof(MikeBoundaryCondition), lang, 0, 1, "", "", extra);

                else
                {
                    MikeBoundaryCondition mikeBoundaryCondition = new MikeBoundaryCondition();
                    mikeBoundaryCondition = mikeBoundaryConditionService.GetMikeBoundaryConditionWithMikeBoundaryConditionID(MikeBoundaryConditionID);

                    if (mikeBoundaryCondition == null)
                    {
                        return NotFound();
                    }

                    return Ok(mikeBoundaryCondition);
                }
            }
        }
        // POST api/mikeBoundaryCondition
        [Route("")]
        public IHttpActionResult Post([FromBody]MikeBoundaryCondition mikeBoundaryCondition, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MikeBoundaryConditionService mikeBoundaryConditionService = new MikeBoundaryConditionService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!mikeBoundaryConditionService.Add(mikeBoundaryCondition))
                {
                    return BadRequest(String.Join("|||", mikeBoundaryCondition.ValidationResults));
                }
                else
                {
                    mikeBoundaryCondition.ValidationResults = null;
                    return Created<MikeBoundaryCondition>(new Uri(Request.RequestUri, mikeBoundaryCondition.MikeBoundaryConditionID.ToString()), mikeBoundaryCondition);
                }
            }
        }
        // PUT api/mikeBoundaryCondition
        [Route("")]
        public IHttpActionResult Put([FromBody]MikeBoundaryCondition mikeBoundaryCondition, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MikeBoundaryConditionService mikeBoundaryConditionService = new MikeBoundaryConditionService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!mikeBoundaryConditionService.Update(mikeBoundaryCondition))
                {
                    return BadRequest(String.Join("|||", mikeBoundaryCondition.ValidationResults));
                }
                else
                {
                    mikeBoundaryCondition.ValidationResults = null;
                    return Ok(mikeBoundaryCondition);
                }
            }
        }
        // DELETE api/mikeBoundaryCondition
        [Route("")]
        public IHttpActionResult Delete([FromBody]MikeBoundaryCondition mikeBoundaryCondition, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MikeBoundaryConditionService mikeBoundaryConditionService = new MikeBoundaryConditionService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!mikeBoundaryConditionService.Delete(mikeBoundaryCondition))
                {
                    return BadRequest(String.Join("|||", mikeBoundaryCondition.ValidationResults));
                }
                else
                {
                    mikeBoundaryCondition.ValidationResults = null;
                    return Ok(mikeBoundaryCondition);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
