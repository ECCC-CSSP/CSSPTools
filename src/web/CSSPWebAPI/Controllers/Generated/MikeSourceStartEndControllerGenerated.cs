using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;;

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
        public IHttpActionResult GetMikeSourceStartEndList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MikeSourceStartEndService mikeSourceStartEndService = new MikeSourceStartEndService(new Query() { Lang = lang }, db, ContactID);

                else
                {
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
        }
        // GET api/mikeSourceStartEnd/1
        [Route("{MikeSourceStartEndID:int}")]
        public IHttpActionResult GetMikeSourceStartEndWithID([FromUri]int MikeSourceStartEndID, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MikeSourceStartEndService mikeSourceStartEndService = new MikeSourceStartEndService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                mikeSourceStartEndService.Query = mikeSourceStartEndService.FillQuery(typeof(MikeSourceStartEnd), lang, 0, 1, "", "");

                else
                {
                    MikeSourceStartEnd mikeSourceStartEnd = new MikeSourceStartEnd();
                    mikeSourceStartEnd = mikeSourceStartEndService.GetMikeSourceStartEndWithMikeSourceStartEndID(MikeSourceStartEndID);

                    if (mikeSourceStartEnd == null)
                    {
                        return NotFound();
                    }

                    return Ok(mikeSourceStartEnd);
                }
            }
        }
        // POST api/mikeSourceStartEnd
        [Route("")]
        public IHttpActionResult Post([FromBody]MikeSourceStartEnd mikeSourceStartEnd, [FromUri]string lang = "en")
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
                    return Created<MikeSourceStartEnd>(new Uri(Request.RequestUri, mikeSourceStartEnd.MikeSourceStartEndID.ToString()), mikeSourceStartEnd);
                }
            }
        }
        // PUT api/mikeSourceStartEnd
        [Route("")]
        public IHttpActionResult Put([FromBody]MikeSourceStartEnd mikeSourceStartEnd, [FromUri]string lang = "en")
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
        public IHttpActionResult Delete([FromBody]MikeSourceStartEnd mikeSourceStartEnd, [FromUri]string lang = "en")
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
