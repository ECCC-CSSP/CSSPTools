using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSSPWebAPI.Controllers
{
    [Route("api/mwqmLookupMPN")]
    public partial class MWQMLookupMPNController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MWQMLookupMPNController() : base()
        {
        }
        public MWQMLookupMPNController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/mwqmLookupMPN
        [Route("")]
        public IActionResult GetMWQMLookupMPNList([FromQuery]string lang = "en", [FromQuery]int skip = 0, [FromQuery]int take = 200,
            [FromQuery]string asc = "", [FromQuery]string desc = "", [FromQuery]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMLookupMPNService mwqmLookupMPNService = new MWQMLookupMPNService(new Query() { Lang = lang }, db, ContactID);

                mwqmLookupMPNService.Query = mwqmLookupMPNService.FillQuery(typeof(MWQMLookupMPN), lang, skip, take, asc, desc, where);

                 if (mwqmLookupMPNService.Query.HasErrors)
                 {
                     return Ok(new List<MWQMLookupMPN>()
                     {
                         new MWQMLookupMPN()
                         {
                             HasErrors = mwqmLookupMPNService.Query.HasErrors,
                             ValidationResults = mwqmLookupMPNService.Query.ValidationResults,
                         },
                     }.ToList());
                 }
                 else
                 {
                     return Ok(mwqmLookupMPNService.GetMWQMLookupMPNList().ToList());
                 }
            }
        }
        // GET api/mwqmLookupMPN/1
        [Route("{MWQMLookupMPNID:int}")]
        public IActionResult GetMWQMLookupMPNWithID([FromQuery]int MWQMLookupMPNID, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMLookupMPNService mwqmLookupMPNService = new MWQMLookupMPNService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                mwqmLookupMPNService.Query = mwqmLookupMPNService.FillQuery(typeof(MWQMLookupMPN), lang, 0, 1, "", "");

                MWQMLookupMPN mwqmLookupMPN = new MWQMLookupMPN();
                mwqmLookupMPN = mwqmLookupMPNService.GetMWQMLookupMPNWithMWQMLookupMPNID(MWQMLookupMPNID);

                if (mwqmLookupMPN == null)
                {
                    return NotFound();
                }

                return Ok(mwqmLookupMPN);
            }
        }
        // POST api/mwqmLookupMPN
        [Route("")]
        public IActionResult Post([FromBody]MWQMLookupMPN mwqmLookupMPN, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMLookupMPNService mwqmLookupMPNService = new MWQMLookupMPNService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!mwqmLookupMPNService.Add(mwqmLookupMPN))
                {
                    return BadRequest(String.Join("|||", mwqmLookupMPN.ValidationResults));
                }
                else
                {
                    mwqmLookupMPN.ValidationResults = null;
                    return Created(Url.ToString(), mwqmLookupMPN);
                }
            }
        }
        // PUT api/mwqmLookupMPN
        [Route("")]
        public IActionResult Put([FromBody]MWQMLookupMPN mwqmLookupMPN, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMLookupMPNService mwqmLookupMPNService = new MWQMLookupMPNService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!mwqmLookupMPNService.Update(mwqmLookupMPN))
                {
                    return BadRequest(String.Join("|||", mwqmLookupMPN.ValidationResults));
                }
                else
                {
                    mwqmLookupMPN.ValidationResults = null;
                    return Ok(mwqmLookupMPN);
                }
            }
        }
        // DELETE api/mwqmLookupMPN
        [Route("")]
        public IActionResult Delete([FromBody]MWQMLookupMPN mwqmLookupMPN, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMLookupMPNService mwqmLookupMPNService = new MWQMLookupMPNService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!mwqmLookupMPNService.Delete(mwqmLookupMPN))
                {
                    return BadRequest(String.Join("|||", mwqmLookupMPN.ValidationResults));
                }
                else
                {
                    mwqmLookupMPN.ValidationResults = null;
                    return Ok(mwqmLookupMPN);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
