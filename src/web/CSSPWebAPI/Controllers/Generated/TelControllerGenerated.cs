using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;;

namespace CSSPWebAPI.Controllers
{
    [Route("api/tel")]
    public partial class TelController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public TelController() : base()
        {
        }
        public TelController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/tel
        [Route("")]
        public IHttpActionResult GetTelList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TelService telService = new TelService(new Query() { Lang = lang }, db, ContactID);

                else
                {
                   telService.Query = telService.FillQuery(typeof(Tel), lang, skip, take, asc, desc, where);

                    if (telService.Query.HasErrors)
                    {
                        return Ok(new List<Tel>()
                        {
                            new Tel()
                            {
                                HasErrors = telService.Query.HasErrors,
                                ValidationResults = telService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(telService.GetTelList().ToList());
                    }
                }
            }
        }
        // GET api/tel/1
        [Route("{TelID:int}")]
        public IHttpActionResult GetTelWithID([FromUri]int TelID, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TelService telService = new TelService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                telService.Query = telService.FillQuery(typeof(Tel), lang, 0, 1, "", "");

                else
                {
                    Tel tel = new Tel();
                    tel = telService.GetTelWithTelID(TelID);

                    if (tel == null)
                    {
                        return NotFound();
                    }

                    return Ok(tel);
                }
            }
        }
        // POST api/tel
        [Route("")]
        public IHttpActionResult Post([FromBody]Tel tel, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TelService telService = new TelService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!telService.Add(tel))
                {
                    return BadRequest(String.Join("|||", tel.ValidationResults));
                }
                else
                {
                    tel.ValidationResults = null;
                    return Created<Tel>(new Uri(Request.RequestUri, tel.TelID.ToString()), tel);
                }
            }
        }
        // PUT api/tel
        [Route("")]
        public IHttpActionResult Put([FromBody]Tel tel, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TelService telService = new TelService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!telService.Update(tel))
                {
                    return BadRequest(String.Join("|||", tel.ValidationResults));
                }
                else
                {
                    tel.ValidationResults = null;
                    return Ok(tel);
                }
            }
        }
        // DELETE api/tel
        [Route("")]
        public IHttpActionResult Delete([FromBody]Tel tel, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TelService telService = new TelService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!telService.Delete(tel))
                {
                    return BadRequest(String.Join("|||", tel.ValidationResults));
                }
                else
                {
                    tel.ValidationResults = null;
                    return Ok(tel);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
