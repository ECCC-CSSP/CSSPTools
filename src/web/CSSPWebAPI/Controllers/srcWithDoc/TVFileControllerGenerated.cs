using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CSSPWebAPI.Controllers
{
    [RoutePrefix("api/tvFile")]
    public partial class TVFileController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public TVFileController() : base()
        {
        }
        public TVFileController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/tvFile
        [Route("")]
        public IHttpActionResult GetTVFileList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TVFileService tvFileService = new TVFileService(new Query() { Lang = lang }, db, ContactID);

                if (extra == "A") // QueryString contains [extra=A]
                {
                   tvFileService.Query = tvFileService.FillQuery(typeof(TVFileExtraA), lang, skip, take, asc, desc, where, extra);

                    if (tvFileService.Query.HasErrors)
                    {
                        return Ok(new List<TVFileExtraA>()
                        {
                            new TVFileExtraA()
                            {
                                HasErrors = tvFileService.Query.HasErrors,
                                ValidationResults = tvFileService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(tvFileService.GetTVFileExtraAList().ToList());
                    }
                }
                else if (extra == "B") // QueryString contains [extra=B]
                {
                   tvFileService.Query = tvFileService.FillQuery(typeof(TVFileExtraB), lang, skip, take, asc, desc, where, extra);

                    if (tvFileService.Query.HasErrors)
                    {
                        return Ok(new List<TVFileExtraB>()
                        {
                            new TVFileExtraB()
                            {
                                HasErrors = tvFileService.Query.HasErrors,
                                ValidationResults = tvFileService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(tvFileService.GetTVFileExtraBList().ToList());
                    }
                }
                else // QueryString has no parameter [extra] or extra is empty
                {
                   tvFileService.Query = tvFileService.FillQuery(typeof(TVFile), lang, skip, take, asc, desc, where, extra);

                    if (tvFileService.Query.HasErrors)
                    {
                        return Ok(new List<TVFile>()
                        {
                            new TVFile()
                            {
                                HasErrors = tvFileService.Query.HasErrors,
                                ValidationResults = tvFileService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(tvFileService.GetTVFileList().ToList());
                    }
                }
            }
        }
        // GET api/tvFile/1
        [Route("{TVFileID:int}")]
        public IHttpActionResult GetTVFileWithID([FromUri]int TVFileID, [FromUri]string lang = "en", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TVFileService tvFileService = new TVFileService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                tvFileService.Query = tvFileService.FillQuery(typeof(TVFile), lang, 0, 1, "", "", extra);

                if (tvFileService.Query.Extra == "A")
                {
                    TVFileExtraA tvFileExtraA = new TVFileExtraA();
                    tvFileExtraA = tvFileService.GetTVFileExtraAWithTVFileID(TVFileID);

                    if (tvFileExtraA == null)
                    {
                        return NotFound();
                    }

                    return Ok(tvFileExtraA);
                }
                else if (tvFileService.Query.Extra == "B")
                {
                    TVFileExtraB tvFileExtraB = new TVFileExtraB();
                    tvFileExtraB = tvFileService.GetTVFileExtraBWithTVFileID(TVFileID);

                    if (tvFileExtraB == null)
                    {
                        return NotFound();
                    }

                    return Ok(tvFileExtraB);
                }
                else
                {
                    TVFile tvFile = new TVFile();
                    tvFile = tvFileService.GetTVFileWithTVFileID(TVFileID);

                    if (tvFile == null)
                    {
                        return NotFound();
                    }

                    return Ok(tvFile);
                }
            }
        }
        // POST api/tvFile
        [Route("")]
        public IHttpActionResult Post([FromBody]TVFile tvFile, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TVFileService tvFileService = new TVFileService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!tvFileService.Add(tvFile))
                {
                    return BadRequest(String.Join("|||", tvFile.ValidationResults));
                }
                else
                {
                    tvFile.ValidationResults = null;
                    return Created<TVFile>(new Uri(Request.RequestUri, tvFile.TVFileID.ToString()), tvFile);
                }
            }
        }
        // PUT api/tvFile
        [Route("")]
        public IHttpActionResult Put([FromBody]TVFile tvFile, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TVFileService tvFileService = new TVFileService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!tvFileService.Update(tvFile))
                {
                    return BadRequest(String.Join("|||", tvFile.ValidationResults));
                }
                else
                {
                    tvFile.ValidationResults = null;
                    return Ok(tvFile);
                }
            }
        }
        // DELETE api/tvFile
        [Route("")]
        public IHttpActionResult Delete([FromBody]TVFile tvFile, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TVFileService tvFileService = new TVFileService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!tvFileService.Delete(tvFile))
                {
                    return BadRequest(String.Join("|||", tvFile.ValidationResults));
                }
                else
                {
                    tvFile.ValidationResults = null;
                    return Ok(tvFile);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
