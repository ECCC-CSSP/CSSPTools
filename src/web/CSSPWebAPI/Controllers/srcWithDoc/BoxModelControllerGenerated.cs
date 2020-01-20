using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CSSPWebAPI.Controllers
{
    [RoutePrefix("api/boxModel")]
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
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                BoxModelService boxModelService = new BoxModelService(new Query() { Lang = lang }, db, ContactID);

                if (extra == "A") // QueryString contains [extra=A]
                {
                   boxModelService.Query = boxModelService.FillQuery(typeof(BoxModelExtraA), lang, skip, take, asc, desc, where, extra);

                    if (boxModelService.Query.HasErrors)
                    {
                        return Ok(new List<BoxModelExtraA>()
                        {
                            new BoxModelExtraA()
                            {
                                HasErrors = boxModelService.Query.HasErrors,
                                ValidationResults = boxModelService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(boxModelService.GetBoxModelExtraAList().ToList());
                    }
                }
                else if (extra == "B") // QueryString contains [extra=B]
                {
                   boxModelService.Query = boxModelService.FillQuery(typeof(BoxModelExtraB), lang, skip, take, asc, desc, where, extra);

                    if (boxModelService.Query.HasErrors)
                    {
                        return Ok(new List<BoxModelExtraB>()
                        {
                            new BoxModelExtraB()
                            {
                                HasErrors = boxModelService.Query.HasErrors,
                                ValidationResults = boxModelService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(boxModelService.GetBoxModelExtraBList().ToList());
                    }
                }
                else // QueryString has no parameter [extra] or extra is empty
                {
                   boxModelService.Query = boxModelService.FillQuery(typeof(BoxModel), lang, skip, take, asc, desc, where, extra);

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
        public IHttpActionResult GetBoxModelWithID([FromUri]int BoxModelID, [FromUri]string lang = "en", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                BoxModelService boxModelService = new BoxModelService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                boxModelService.Query = boxModelService.FillQuery(typeof(BoxModel), lang, 0, 1, "", "", extra);

                if (boxModelService.Query.Extra == "A")
                {
                    BoxModelExtraA boxModelExtraA = new BoxModelExtraA();
                    boxModelExtraA = boxModelService.GetBoxModelExtraAWithBoxModelID(BoxModelID);

                    if (boxModelExtraA == null)
                    {
                        return NotFound();
                    }

                    return Ok(boxModelExtraA);
                }
                else if (boxModelService.Query.Extra == "B")
                {
                    BoxModelExtraB boxModelExtraB = new BoxModelExtraB();
                    boxModelExtraB = boxModelService.GetBoxModelExtraBWithBoxModelID(BoxModelID);

                    if (boxModelExtraB == null)
                    {
                        return NotFound();
                    }

                    return Ok(boxModelExtraB);
                }
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
