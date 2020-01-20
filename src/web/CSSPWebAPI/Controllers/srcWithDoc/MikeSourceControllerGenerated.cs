using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CSSPWebAPI.Controllers
{
    [RoutePrefix("api/mikeSource")]
    public partial class MikeSourceController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MikeSourceController() : base()
        {
        }
        public MikeSourceController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/mikeSource
        [Route("")]
        public IHttpActionResult GetMikeSourceList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MikeSourceService mikeSourceService = new MikeSourceService(new Query() { Lang = lang }, db, ContactID);

                if (extra == "A") // QueryString contains [extra=A]
                {
                   mikeSourceService.Query = mikeSourceService.FillQuery(typeof(MikeSourceExtraA), lang, skip, take, asc, desc, where, extra);

                    if (mikeSourceService.Query.HasErrors)
                    {
                        return Ok(new List<MikeSourceExtraA>()
                        {
                            new MikeSourceExtraA()
                            {
                                HasErrors = mikeSourceService.Query.HasErrors,
                                ValidationResults = mikeSourceService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(mikeSourceService.GetMikeSourceExtraAList().ToList());
                    }
                }
                else if (extra == "B") // QueryString contains [extra=B]
                {
                   mikeSourceService.Query = mikeSourceService.FillQuery(typeof(MikeSourceExtraB), lang, skip, take, asc, desc, where, extra);

                    if (mikeSourceService.Query.HasErrors)
                    {
                        return Ok(new List<MikeSourceExtraB>()
                        {
                            new MikeSourceExtraB()
                            {
                                HasErrors = mikeSourceService.Query.HasErrors,
                                ValidationResults = mikeSourceService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(mikeSourceService.GetMikeSourceExtraBList().ToList());
                    }
                }
                else // QueryString has no parameter [extra] or extra is empty
                {
                   mikeSourceService.Query = mikeSourceService.FillQuery(typeof(MikeSource), lang, skip, take, asc, desc, where, extra);

                    if (mikeSourceService.Query.HasErrors)
                    {
                        return Ok(new List<MikeSource>()
                        {
                            new MikeSource()
                            {
                                HasErrors = mikeSourceService.Query.HasErrors,
                                ValidationResults = mikeSourceService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(mikeSourceService.GetMikeSourceList().ToList());
                    }
                }
            }
        }
        // GET api/mikeSource/1
        [Route("{MikeSourceID:int}")]
        public IHttpActionResult GetMikeSourceWithID([FromUri]int MikeSourceID, [FromUri]string lang = "en", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MikeSourceService mikeSourceService = new MikeSourceService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                mikeSourceService.Query = mikeSourceService.FillQuery(typeof(MikeSource), lang, 0, 1, "", "", extra);

                if (mikeSourceService.Query.Extra == "A")
                {
                    MikeSourceExtraA mikeSourceExtraA = new MikeSourceExtraA();
                    mikeSourceExtraA = mikeSourceService.GetMikeSourceExtraAWithMikeSourceID(MikeSourceID);

                    if (mikeSourceExtraA == null)
                    {
                        return NotFound();
                    }

                    return Ok(mikeSourceExtraA);
                }
                else if (mikeSourceService.Query.Extra == "B")
                {
                    MikeSourceExtraB mikeSourceExtraB = new MikeSourceExtraB();
                    mikeSourceExtraB = mikeSourceService.GetMikeSourceExtraBWithMikeSourceID(MikeSourceID);

                    if (mikeSourceExtraB == null)
                    {
                        return NotFound();
                    }

                    return Ok(mikeSourceExtraB);
                }
                else
                {
                    MikeSource mikeSource = new MikeSource();
                    mikeSource = mikeSourceService.GetMikeSourceWithMikeSourceID(MikeSourceID);

                    if (mikeSource == null)
                    {
                        return NotFound();
                    }

                    return Ok(mikeSource);
                }
            }
        }
        // POST api/mikeSource
        [Route("")]
        public IHttpActionResult Post([FromBody]MikeSource mikeSource, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MikeSourceService mikeSourceService = new MikeSourceService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!mikeSourceService.Add(mikeSource))
                {
                    return BadRequest(String.Join("|||", mikeSource.ValidationResults));
                }
                else
                {
                    mikeSource.ValidationResults = null;
                    return Created<MikeSource>(new Uri(Request.RequestUri, mikeSource.MikeSourceID.ToString()), mikeSource);
                }
            }
        }
        // PUT api/mikeSource
        [Route("")]
        public IHttpActionResult Put([FromBody]MikeSource mikeSource, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MikeSourceService mikeSourceService = new MikeSourceService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!mikeSourceService.Update(mikeSource))
                {
                    return BadRequest(String.Join("|||", mikeSource.ValidationResults));
                }
                else
                {
                    mikeSource.ValidationResults = null;
                    return Ok(mikeSource);
                }
            }
        }
        // DELETE api/mikeSource
        [Route("")]
        public IHttpActionResult Delete([FromBody]MikeSource mikeSource, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MikeSourceService mikeSourceService = new MikeSourceService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!mikeSourceService.Delete(mikeSource))
                {
                    return BadRequest(String.Join("|||", mikeSource.ValidationResults));
                }
                else
                {
                    mikeSource.ValidationResults = null;
                    return Ok(mikeSource);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
