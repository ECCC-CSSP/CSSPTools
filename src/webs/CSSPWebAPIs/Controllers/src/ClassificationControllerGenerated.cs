using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CSSPWebAPI.Controllers
{
    [RoutePrefix("api/classification")]
    public partial class ClassificationController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ClassificationController() : base()
        {
        }
        public ClassificationController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/classification
        [Route("")]
        public IHttpActionResult GetClassificationList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ClassificationService classificationService = new ClassificationService(new Query() { Lang = lang }, db, ContactID);

                else // QueryString has no parameter [extra] or extra is empty
                {
                   classificationService.Query = classificationService.FillQuery(typeof(Classification), lang, skip, take, asc, desc, where, extra);

                    if (classificationService.Query.HasErrors)
                    {
                        return Ok(new List<Classification>()
                        {
                            new Classification()
                            {
                                HasErrors = classificationService.Query.HasErrors,
                                ValidationResults = classificationService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(classificationService.GetClassificationList().ToList());
                    }
                }
            }
        }
        // GET api/classification/1
        [Route("{ClassificationID:int}")]
        public IHttpActionResult GetClassificationWithID([FromUri]int ClassificationID, [FromUri]string lang = "en", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ClassificationService classificationService = new ClassificationService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                classificationService.Query = classificationService.FillQuery(typeof(Classification), lang, 0, 1, "", "", extra);

                else
                {
                    Classification classification = new Classification();
                    classification = classificationService.GetClassificationWithClassificationID(ClassificationID);

                    if (classification == null)
                    {
                        return NotFound();
                    }

                    return Ok(classification);
                }
            }
        }
        // POST api/classification
        [Route("")]
        public IHttpActionResult Post([FromBody]Classification classification, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ClassificationService classificationService = new ClassificationService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!classificationService.Add(classification))
                {
                    return BadRequest(String.Join("|||", classification.ValidationResults));
                }
                else
                {
                    classification.ValidationResults = null;
                    return Created<Classification>(new Uri(Request.RequestUri, classification.ClassificationID.ToString()), classification);
                }
            }
        }
        // PUT api/classification
        [Route("")]
        public IHttpActionResult Put([FromBody]Classification classification, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ClassificationService classificationService = new ClassificationService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!classificationService.Update(classification))
                {
                    return BadRequest(String.Join("|||", classification.ValidationResults));
                }
                else
                {
                    classification.ValidationResults = null;
                    return Ok(classification);
                }
            }
        }
        // DELETE api/classification
        [Route("")]
        public IHttpActionResult Delete([FromBody]Classification classification, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ClassificationService classificationService = new ClassificationService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!classificationService.Delete(classification))
                {
                    return BadRequest(String.Join("|||", classification.ValidationResults));
                }
                else
                {
                    classification.ValidationResults = null;
                    return Ok(classification);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
