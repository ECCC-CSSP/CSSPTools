using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CSSPWebAPI.Controllers
{
    [RoutePrefix("api/spill")]
    public partial class SpillController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public SpillController() : base()
        {
        }
        public SpillController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/spill
        [Route("")]
        public IHttpActionResult GetSpillList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                SpillService spillService = new SpillService(new Query() { Lang = lang }, db, ContactID);

                else // QueryString has no parameter [extra] or extra is empty
                {
                   spillService.Query = spillService.FillQuery(typeof(Spill), lang, skip, take, asc, desc, where, extra);

                    if (spillService.Query.HasErrors)
                    {
                        return Ok(new List<Spill>()
                        {
                            new Spill()
                            {
                                HasErrors = spillService.Query.HasErrors,
                                ValidationResults = spillService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(spillService.GetSpillList().ToList());
                    }
                }
            }
        }
        // GET api/spill/1
        [Route("{SpillID:int}")]
        public IHttpActionResult GetSpillWithID([FromUri]int SpillID, [FromUri]string lang = "en", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                SpillService spillService = new SpillService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                spillService.Query = spillService.FillQuery(typeof(Spill), lang, 0, 1, "", "", extra);

                else
                {
                    Spill spill = new Spill();
                    spill = spillService.GetSpillWithSpillID(SpillID);

                    if (spill == null)
                    {
                        return NotFound();
                    }

                    return Ok(spill);
                }
            }
        }
        // POST api/spill
        [Route("")]
        public IHttpActionResult Post([FromBody]Spill spill, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                SpillService spillService = new SpillService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!spillService.Add(spill))
                {
                    return BadRequest(String.Join("|||", spill.ValidationResults));
                }
                else
                {
                    spill.ValidationResults = null;
                    return Created<Spill>(new Uri(Request.RequestUri, spill.SpillID.ToString()), spill);
                }
            }
        }
        // PUT api/spill
        [Route("")]
        public IHttpActionResult Put([FromBody]Spill spill, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                SpillService spillService = new SpillService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!spillService.Update(spill))
                {
                    return BadRequest(String.Join("|||", spill.ValidationResults));
                }
                else
                {
                    spill.ValidationResults = null;
                    return Ok(spill);
                }
            }
        }
        // DELETE api/spill
        [Route("")]
        public IHttpActionResult Delete([FromBody]Spill spill, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                SpillService spillService = new SpillService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!spillService.Delete(spill))
                {
                    return BadRequest(String.Join("|||", spill.ValidationResults));
                }
                else
                {
                    spill.ValidationResults = null;
                    return Ok(spill);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
