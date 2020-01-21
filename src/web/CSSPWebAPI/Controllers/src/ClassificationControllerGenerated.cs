using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSSPWebAPI.Controllers
{
    [Route("api/classification")]
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
        public IActionResult GetClassificationList([FromQuery]string lang = "en", [FromQuery]int skip = 0, [FromQuery]int take = 200,
            [FromQuery]string asc = "", [FromQuery]string desc = "", [FromQuery]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ClassificationService classificationService = new ClassificationService(new Query() { Lang = lang }, db, ContactID);

                classificationService.Query = classificationService.FillQuery(typeof(Classification), lang, skip, take, asc, desc, where);

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
        // GET api/classification/1
        [Route("{ClassificationID:int}")]
        public IActionResult GetClassificationWithID([FromQuery]int ClassificationID, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ClassificationService classificationService = new ClassificationService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                classificationService.Query = classificationService.FillQuery(typeof(Classification), lang, 0, 1, "", "");

                Classification classification = new Classification();
                classification = classificationService.GetClassificationWithClassificationID(ClassificationID);

                if (classification == null)
                {
                    return NotFound();
                }

                return Ok(classification);
            }
        }
        // POST api/classification
        [Route("")]
        public IActionResult Post([FromBody]Classification classification, [FromQuery]string lang = "en")
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
                    return Created(Url.ToString(), classification);
                }
            }
        }
        // PUT api/classification
        [Route("")]
        public IActionResult Put([FromBody]Classification classification, [FromQuery]string lang = "en")
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
        public IActionResult Delete([FromBody]Classification classification, [FromQuery]string lang = "en")
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
