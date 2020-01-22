using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSSPWebAPI.Controllers
{
    [Route("api/boxModel")]
    public partial class BoxModelController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public BoxModelController() : base()
        {
        }
        public BoxModelController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/boxModel
        [Route("")]
        public IActionResult GetBoxModelList([FromQuery]string lang = "en", [FromQuery]int skip = 0, [FromQuery]int take = 200,
            [FromQuery]string asc = "", [FromQuery]string desc = "", [FromQuery]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                BoxModelService boxModelService = new BoxModelService(new Query() { Lang = lang }, db, ContactID);

                boxModelService.Query = boxModelService.FillQuery(typeof(BoxModel), lang, skip, take, asc, desc, where);

                 if (boxModelService.Query.HasErrors)
                 {
                     return Ok(new List<BoxModel>()
                     {
                         new BoxModel()
                         {
                             HasErrors = boxModelService.Query.HasErrors,
                             ValidationResults = boxModelService.Query.ValidationResults,
                         },
                     }.ToList());
                 }
                 else
                 {
                     return Ok(boxModelService.GetBoxModelList().ToList());
                 }
            }
        }
        // GET api/boxModel/1
        [Route("{BoxModelID:int}")]
        public IActionResult GetBoxModelWithID([FromQuery]int BoxModelID, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                BoxModelService boxModelService = new BoxModelService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                boxModelService.Query = boxModelService.FillQuery(typeof(BoxModel), lang, 0, 1, "", "");

                BoxModel boxModel = new BoxModel();
                boxModel = boxModelService.GetBoxModelWithBoxModelID(BoxModelID);

                if (boxModel == null)
                {
                    return NotFound();
                }

                return Ok(boxModel);
            }
        }
        // POST api/boxModel
        [Route("")]
        public IActionResult Post([FromBody]BoxModel boxModel, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                BoxModelService boxModelService = new BoxModelService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!boxModelService.Add(boxModel))
                {
                    return BadRequest(String.Join("|||", boxModel.ValidationResults));
                }
                else
                {
                    boxModel.ValidationResults = null;
                    return Created(Url.ToString(), boxModel);
                }
            }
        }
        // PUT api/boxModel
        [Route("")]
        public IActionResult Put([FromBody]BoxModel boxModel, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                BoxModelService boxModelService = new BoxModelService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!boxModelService.Update(boxModel))
                {
                    return BadRequest(String.Join("|||", boxModel.ValidationResults));
                }
                else
                {
                    boxModel.ValidationResults = null;
                    return Ok(boxModel);
                }
            }
        }
        // DELETE api/boxModel
        [Route("")]
        public IActionResult Delete([FromBody]BoxModel boxModel, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                BoxModelService boxModelService = new BoxModelService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!boxModelService.Delete(boxModel))
                {
                    return BadRequest(String.Join("|||", boxModel.ValidationResults));
                }
                else
                {
                    boxModel.ValidationResults = null;
                    return Ok(boxModel);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
