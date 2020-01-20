using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public IActionResult GetTVFileList([FromQuery]string lang = "en", [FromQuery]int skip = 0, [FromQuery]int take = 200,
            [FromQuery]string asc = "", [FromQuery]string desc = "", [FromQuery]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TVFileService tvFileService = new TVFileService(new Query() { Lang = lang }, db, ContactID);

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
        // GET api/tvFile/1
        [Route("{TVFileID:int}")]
        public IActionResult GetTVFileWithID([FromQuery]int TVFileID, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TVFileService tvFileService = new TVFileService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                tvFileService.Query = tvFileService.FillQuery(typeof(TVFile), lang, 0, 1, "", "");

                TVFile tvFile = new TVFile();
                tvFile = tvFileService.GetTVFileWithTVFileID(TVFileID);

                if (tvFile == null)
                {
                    return NotFound();
                }

                return Ok(tvFile);
            }
        }
        // POST api/tvFile
        [Route("")]
        public IActionResult Post([FromBody]TVFile tvFile, [FromQuery]string lang = "en")
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
        public IActionResult Put([FromBody]TVFile tvFile, [FromQuery]string lang = "en")
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
        public IActionResult Delete([FromBody]TVFile tvFile, [FromQuery]string lang = "en")
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
