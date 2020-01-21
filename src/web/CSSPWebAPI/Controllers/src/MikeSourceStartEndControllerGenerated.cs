using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSSPWebAPI.Controllers
{
    [Route("api/mikeSourceStartEnd")]
    public partial class MikeSourceStartEndController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MikeSourceStartEndController() : base()
        {
        }
        public MikeSourceStartEndController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/mikeSourceStartEnd
        [Route("")]
        public IActionResult GetMikeSourceStartEndList([FromQuery]string lang = "en", [FromQuery]int skip = 0, [FromQuery]int take = 200,
            [FromQuery]string asc = "", [FromQuery]string desc = "", [FromQuery]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MikeSourceStartEndService mikeSourceStartEndService = new MikeSourceStartEndService(new Query() { Lang = lang }, db, ContactID);

                mikeSourceStartEndService.Query = mikeSourceStartEndService.FillQuery(typeof(MikeSourceStartEnd), lang, skip, take, asc, desc, where);

                 if (mikeSourceStartEndService.Query.HasErrors)
                 {
                     return Ok(new List<MikeSourceStartEnd>()
                     {
                         new MikeSourceStartEnd()
                         {
                             HasErrors = mikeSourceStartEndService.Query.HasErrors,
                             ValidationResults = mikeSourceStartEndService.Query.ValidationResults,
                         },
                     }.ToList());
                 }
                 else
                 {
                     return Ok(mikeSourceStartEndService.GetMikeSourceStartEndList().ToList());
                 }
            }
        }
        // GET api/mikeSourceStartEnd/1
        [Route("{MikeSourceStartEndID:int}")]
        public IActionResult GetMikeSourceStartEndWithID([FromQuery]int MikeSourceStartEndID, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MikeSourceStartEndService mikeSourceStartEndService = new MikeSourceStartEndService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                mikeSourceStartEndService.Query = mikeSourceStartEndService.FillQuery(typeof(MikeSourceStartEnd), lang, 0, 1, "", "");

                MikeSourceStartEnd mikeSourceStartEnd = new MikeSourceStartEnd();
                mikeSourceStartEnd = mikeSourceStartEndService.GetMikeSourceStartEndWithMikeSourceStartEndID(MikeSourceStartEndID);

                if (mikeSourceStartEnd == null)
                {
                    return NotFound();
                }

                return Ok(mikeSourceStartEnd);
            }
        }
        // POST api/mikeSourceStartEnd
        [Route("")]
        public IActionResult Post([FromBody]MikeSourceStartEnd mikeSourceStartEnd, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MikeSourceStartEndService mikeSourceStartEndService = new MikeSourceStartEndService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!mikeSourceStartEndService.Add(mikeSourceStartEnd))
                {
                    return BadRequest(String.Join("|||", mikeSourceStartEnd.ValidationResults));
                }
                else
                {
                    mikeSourceStartEnd.ValidationResults = null;
                    return Created(Url.ToString(), mikeSourceStartEnd);
                }
            }
        }
        // PUT api/mikeSourceStartEnd
        [Route("")]
        public IActionResult Put([FromBody]MikeSourceStartEnd mikeSourceStartEnd, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MikeSourceStartEndService mikeSourceStartEndService = new MikeSourceStartEndService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!mikeSourceStartEndService.Update(mikeSourceStartEnd))
                {
                    return BadRequest(String.Join("|||", mikeSourceStartEnd.ValidationResults));
                }
                else
                {
                    mikeSourceStartEnd.ValidationResults = null;
                    return Ok(mikeSourceStartEnd);
                }
            }
        }
        // DELETE api/mikeSourceStartEnd
        [Route("")]
        public IActionResult Delete([FromBody]MikeSourceStartEnd mikeSourceStartEnd, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MikeSourceStartEndService mikeSourceStartEndService = new MikeSourceStartEndService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!mikeSourceStartEndService.Delete(mikeSourceStartEnd))
                {
                    return BadRequest(String.Join("|||", mikeSourceStartEnd.ValidationResults));
                }
                else
                {
                    mikeSourceStartEnd.ValidationResults = null;
                    return Ok(mikeSourceStartEnd);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
