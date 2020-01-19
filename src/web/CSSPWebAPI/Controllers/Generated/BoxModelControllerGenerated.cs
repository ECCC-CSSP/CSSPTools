using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;;

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
        public IHttpActionResult GetBoxModelList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                BoxModelService boxModelService = new BoxModelService(new Query() { Lang = lang }, db, ContactID);

                else
                {
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
        }
        // GET api/boxModel/1
        [Route("{BoxModelID:int}")]
        public IHttpActionResult GetBoxModelWithID([FromUri]int BoxModelID, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                BoxModelService boxModelService = new BoxModelService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                boxModelService.Query = boxModelService.FillQuery(typeof(BoxModel), lang, 0, 1, "", "");

                else
                {
                    BoxModel boxModel = new BoxModel();
                    boxModel = boxModelService.GetBoxModelWithBoxModelID(BoxModelID);

                    if (boxModel == null)
                    {
                        return NotFound();
                    }

                    return Ok(boxModel);
                }
            }
        }
        // POST api/boxModel
        [Route("")]
        public IHttpActionResult Post([FromBody]BoxModel boxModel, [FromUri]string lang = "en")
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
                    return Created<BoxModel>(new Uri(Request.RequestUri, boxModel.BoxModelID.ToString()), boxModel);
                }
            }
        }
        // PUT api/boxModel
        [Route("")]
        public IHttpActionResult Put([FromBody]BoxModel boxModel, [FromUri]string lang = "en")
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
        public IHttpActionResult Delete([FromBody]BoxModel boxModel, [FromUri]string lang = "en")
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
