using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;;

namespace CSSPWebAPI.Controllers
{
    [Route("api/mwqmSubsectorLanguage")]
    public partial class MWQMSubsectorLanguageController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MWQMSubsectorLanguageController() : base()
        {
        }
        public MWQMSubsectorLanguageController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/mwqmSubsectorLanguage
        [Route("")]
        public IHttpActionResult GetMWQMSubsectorLanguageList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMSubsectorLanguageService mwqmSubsectorLanguageService = new MWQMSubsectorLanguageService(new Query() { Lang = lang }, db, ContactID);

                else
                {
                   mwqmSubsectorLanguageService.Query = mwqmSubsectorLanguageService.FillQuery(typeof(MWQMSubsectorLanguage), lang, skip, take, asc, desc, where);

                    if (mwqmSubsectorLanguageService.Query.HasErrors)
                    {
                        return Ok(new List<MWQMSubsectorLanguage>()
                        {
                            new MWQMSubsectorLanguage()
                            {
                                HasErrors = mwqmSubsectorLanguageService.Query.HasErrors,
                                ValidationResults = mwqmSubsectorLanguageService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(mwqmSubsectorLanguageService.GetMWQMSubsectorLanguageList().ToList());
                    }
                }
            }
        }
        // GET api/mwqmSubsectorLanguage/1
        [Route("{MWQMSubsectorLanguageID:int}")]
        public IHttpActionResult GetMWQMSubsectorLanguageWithID([FromUri]int MWQMSubsectorLanguageID, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMSubsectorLanguageService mwqmSubsectorLanguageService = new MWQMSubsectorLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                mwqmSubsectorLanguageService.Query = mwqmSubsectorLanguageService.FillQuery(typeof(MWQMSubsectorLanguage), lang, 0, 1, "", "");

                else
                {
                    MWQMSubsectorLanguage mwqmSubsectorLanguage = new MWQMSubsectorLanguage();
                    mwqmSubsectorLanguage = mwqmSubsectorLanguageService.GetMWQMSubsectorLanguageWithMWQMSubsectorLanguageID(MWQMSubsectorLanguageID);

                    if (mwqmSubsectorLanguage == null)
                    {
                        return NotFound();
                    }

                    return Ok(mwqmSubsectorLanguage);
                }
            }
        }
        // POST api/mwqmSubsectorLanguage
        [Route("")]
        public IHttpActionResult Post([FromBody]MWQMSubsectorLanguage mwqmSubsectorLanguage, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMSubsectorLanguageService mwqmSubsectorLanguageService = new MWQMSubsectorLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!mwqmSubsectorLanguageService.Add(mwqmSubsectorLanguage))
                {
                    return BadRequest(String.Join("|||", mwqmSubsectorLanguage.ValidationResults));
                }
                else
                {
                    mwqmSubsectorLanguage.ValidationResults = null;
                    return Created<MWQMSubsectorLanguage>(new Uri(Request.RequestUri, mwqmSubsectorLanguage.MWQMSubsectorLanguageID.ToString()), mwqmSubsectorLanguage);
                }
            }
        }
        // PUT api/mwqmSubsectorLanguage
        [Route("")]
        public IHttpActionResult Put([FromBody]MWQMSubsectorLanguage mwqmSubsectorLanguage, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMSubsectorLanguageService mwqmSubsectorLanguageService = new MWQMSubsectorLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!mwqmSubsectorLanguageService.Update(mwqmSubsectorLanguage))
                {
                    return BadRequest(String.Join("|||", mwqmSubsectorLanguage.ValidationResults));
                }
                else
                {
                    mwqmSubsectorLanguage.ValidationResults = null;
                    return Ok(mwqmSubsectorLanguage);
                }
            }
        }
        // DELETE api/mwqmSubsectorLanguage
        [Route("")]
        public IHttpActionResult Delete([FromBody]MWQMSubsectorLanguage mwqmSubsectorLanguage, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMSubsectorLanguageService mwqmSubsectorLanguageService = new MWQMSubsectorLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!mwqmSubsectorLanguageService.Delete(mwqmSubsectorLanguage))
                {
                    return BadRequest(String.Join("|||", mwqmSubsectorLanguage.ValidationResults));
                }
                else
                {
                    mwqmSubsectorLanguage.ValidationResults = null;
                    return Ok(mwqmSubsectorLanguage);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
