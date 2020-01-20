using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CSSPWebAPI.Controllers
{
    [RoutePrefix("api/boxModelLanguage")]
    public partial class BoxModelLanguageController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public BoxModelLanguageController() : base()
        {
        }
        public BoxModelLanguageController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/boxModelLanguage
        [Route("")]
        public IHttpActionResult GetBoxModelLanguageList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                BoxModelLanguageService boxModelLanguageService = new BoxModelLanguageService(new Query() { Lang = lang }, db, ContactID);

                if (extra == "A") // QueryString contains [extra=A]
                {
                   boxModelLanguageService.Query = boxModelLanguageService.FillQuery(typeof(BoxModelLanguageExtraA), lang, skip, take, asc, desc, where, extra);

                    if (boxModelLanguageService.Query.HasErrors)
                    {
                        return Ok(new List<BoxModelLanguageExtraA>()
                        {
                            new BoxModelLanguageExtraA()
                            {
                                HasErrors = boxModelLanguageService.Query.HasErrors,
                                ValidationResults = boxModelLanguageService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(boxModelLanguageService.GetBoxModelLanguageExtraAList().ToList());
                    }
                }
                else if (extra == "B") // QueryString contains [extra=B]
                {
                   boxModelLanguageService.Query = boxModelLanguageService.FillQuery(typeof(BoxModelLanguageExtraB), lang, skip, take, asc, desc, where, extra);

                    if (boxModelLanguageService.Query.HasErrors)
                    {
                        return Ok(new List<BoxModelLanguageExtraB>()
                        {
                            new BoxModelLanguageExtraB()
                            {
                                HasErrors = boxModelLanguageService.Query.HasErrors,
                                ValidationResults = boxModelLanguageService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(boxModelLanguageService.GetBoxModelLanguageExtraBList().ToList());
                    }
                }
                else // QueryString has no parameter [extra] or extra is empty
                {
                   boxModelLanguageService.Query = boxModelLanguageService.FillQuery(typeof(BoxModelLanguage), lang, skip, take, asc, desc, where, extra);

                    if (boxModelLanguageService.Query.HasErrors)
                    {
                        return Ok(new List<BoxModelLanguage>()
                        {
                            new BoxModelLanguage()
                            {
                                HasErrors = boxModelLanguageService.Query.HasErrors,
                                ValidationResults = boxModelLanguageService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(boxModelLanguageService.GetBoxModelLanguageList().ToList());
                    }
                }
            }
        }
        // GET api/boxModelLanguage/1
        [Route("{BoxModelLanguageID:int}")]
        public IHttpActionResult GetBoxModelLanguageWithID([FromUri]int BoxModelLanguageID, [FromUri]string lang = "en", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                BoxModelLanguageService boxModelLanguageService = new BoxModelLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                boxModelLanguageService.Query = boxModelLanguageService.FillQuery(typeof(BoxModelLanguage), lang, 0, 1, "", "", extra);

                if (boxModelLanguageService.Query.Extra == "A")
                {
                    BoxModelLanguageExtraA boxModelLanguageExtraA = new BoxModelLanguageExtraA();
                    boxModelLanguageExtraA = boxModelLanguageService.GetBoxModelLanguageExtraAWithBoxModelLanguageID(BoxModelLanguageID);

                    if (boxModelLanguageExtraA == null)
                    {
                        return NotFound();
                    }

                    return Ok(boxModelLanguageExtraA);
                }
                else if (boxModelLanguageService.Query.Extra == "B")
                {
                    BoxModelLanguageExtraB boxModelLanguageExtraB = new BoxModelLanguageExtraB();
                    boxModelLanguageExtraB = boxModelLanguageService.GetBoxModelLanguageExtraBWithBoxModelLanguageID(BoxModelLanguageID);

                    if (boxModelLanguageExtraB == null)
                    {
                        return NotFound();
                    }

                    return Ok(boxModelLanguageExtraB);
                }
                else
                {
                    BoxModelLanguage boxModelLanguage = new BoxModelLanguage();
                    boxModelLanguage = boxModelLanguageService.GetBoxModelLanguageWithBoxModelLanguageID(BoxModelLanguageID);

                    if (boxModelLanguage == null)
                    {
                        return NotFound();
                    }

                    return Ok(boxModelLanguage);
                }
            }
        }
        // POST api/boxModelLanguage
        [Route("")]
        public IHttpActionResult Post([FromBody]BoxModelLanguage boxModelLanguage, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                BoxModelLanguageService boxModelLanguageService = new BoxModelLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!boxModelLanguageService.Add(boxModelLanguage))
                {
                    return BadRequest(String.Join("|||", boxModelLanguage.ValidationResults));
                }
                else
                {
                    boxModelLanguage.ValidationResults = null;
                    return Created<BoxModelLanguage>(new Uri(Request.RequestUri, boxModelLanguage.BoxModelLanguageID.ToString()), boxModelLanguage);
                }
            }
        }
        // PUT api/boxModelLanguage
        [Route("")]
        public IHttpActionResult Put([FromBody]BoxModelLanguage boxModelLanguage, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                BoxModelLanguageService boxModelLanguageService = new BoxModelLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!boxModelLanguageService.Update(boxModelLanguage))
                {
                    return BadRequest(String.Join("|||", boxModelLanguage.ValidationResults));
                }
                else
                {
                    boxModelLanguage.ValidationResults = null;
                    return Ok(boxModelLanguage);
                }
            }
        }
        // DELETE api/boxModelLanguage
        [Route("")]
        public IHttpActionResult Delete([FromBody]BoxModelLanguage boxModelLanguage, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                BoxModelLanguageService boxModelLanguageService = new BoxModelLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!boxModelLanguageService.Delete(boxModelLanguage))
                {
                    return BadRequest(String.Join("|||", boxModelLanguage.ValidationResults));
                }
                else
                {
                    boxModelLanguage.ValidationResults = null;
                    return Ok(boxModelLanguage);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
