using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;;

namespace CSSPWebAPI.Controllers
{
    [Route("api/tvFile")]
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
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TVFileService tvFileService = new TVFileService(new Query() { Lang = lang }, db, ContactID);

                else
                {
                   tvFileService.Query = tvFileService.FillQuery(typeof(TVFile), lang, skip, take, asc, desc, where);

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
        public IHttpActionResult GetTVFileWithID([FromUri]int TVFileID, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TVFileService tvFileService = new TVFileService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                tvFileService.Query = tvFileService.FillQuery(typeof(TVFile), lang, 0, 1, "", "");

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
