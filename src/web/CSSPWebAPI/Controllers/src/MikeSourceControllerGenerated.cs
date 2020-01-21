using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSSPWebAPI.Controllers
{
    [Route("api/mikeSource")]
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
        public IActionResult GetMikeSourceList([FromQuery]string lang = "en", [FromQuery]int skip = 0, [FromQuery]int take = 200,
            [FromQuery]string asc = "", [FromQuery]string desc = "", [FromQuery]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MikeSourceService mikeSourceService = new MikeSourceService(new Query() { Lang = lang }, db, ContactID);

                mikeSourceService.Query = mikeSourceService.FillQuery(typeof(MikeSource), lang, skip, take, asc, desc, where);

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
        // GET api/mikeSource/1
        [Route("{MikeSourceID:int}")]
        public IActionResult GetMikeSourceWithID([FromQuery]int MikeSourceID, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MikeSourceService mikeSourceService = new MikeSourceService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                mikeSourceService.Query = mikeSourceService.FillQuery(typeof(MikeSource), lang, 0, 1, "", "");

                MikeSource mikeSource = new MikeSource();
                mikeSource = mikeSourceService.GetMikeSourceWithMikeSourceID(MikeSourceID);

                if (mikeSource == null)
                {
                    return NotFound();
                }

                return Ok(mikeSource);
            }
        }
        // POST api/mikeSource
        [Route("")]
        public IActionResult Post([FromBody]MikeSource mikeSource, [FromQuery]string lang = "en")
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
                    return Created(Url.ToString(), mikeSource);
                }
            }
        }
        // PUT api/mikeSource
        [Route("")]
        public IActionResult Put([FromBody]MikeSource mikeSource, [FromQuery]string lang = "en")
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
        public IActionResult Delete([FromBody]MikeSource mikeSource, [FromQuery]string lang = "en")
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
