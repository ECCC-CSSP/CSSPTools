using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSSPWebAPI.Controllers
{
    [Route("api/mwqmAnalysisReportParameter")]
    public partial class MWQMAnalysisReportParameterController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MWQMAnalysisReportParameterController() : base()
        {
        }
        public MWQMAnalysisReportParameterController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/mwqmAnalysisReportParameter
        [Route("")]
        public IActionResult GetMWQMAnalysisReportParameterList([FromQuery]string lang = "en", [FromQuery]int skip = 0, [FromQuery]int take = 200,
            [FromQuery]string asc = "", [FromQuery]string desc = "", [FromQuery]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMAnalysisReportParameterService mwqmAnalysisReportParameterService = new MWQMAnalysisReportParameterService(new Query() { Lang = lang }, db, ContactID);

                mwqmAnalysisReportParameterService.Query = mwqmAnalysisReportParameterService.FillQuery(typeof(MWQMAnalysisReportParameter), lang, skip, take, asc, desc, where);

                 if (mwqmAnalysisReportParameterService.Query.HasErrors)
                 {
                     return Ok(new List<MWQMAnalysisReportParameter>()
                     {
                         new MWQMAnalysisReportParameter()
                         {
                             HasErrors = mwqmAnalysisReportParameterService.Query.HasErrors,
                             ValidationResults = mwqmAnalysisReportParameterService.Query.ValidationResults,
                         },
                     }.ToList());
                 }
                 else
                 {
                     return Ok(mwqmAnalysisReportParameterService.GetMWQMAnalysisReportParameterList().ToList());
                 }
            }
        }
        // GET api/mwqmAnalysisReportParameter/1
        [Route("{MWQMAnalysisReportParameterID:int}")]
        public IActionResult GetMWQMAnalysisReportParameterWithID([FromQuery]int MWQMAnalysisReportParameterID, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMAnalysisReportParameterService mwqmAnalysisReportParameterService = new MWQMAnalysisReportParameterService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                mwqmAnalysisReportParameterService.Query = mwqmAnalysisReportParameterService.FillQuery(typeof(MWQMAnalysisReportParameter), lang, 0, 1, "", "");

                MWQMAnalysisReportParameter mwqmAnalysisReportParameter = new MWQMAnalysisReportParameter();
                mwqmAnalysisReportParameter = mwqmAnalysisReportParameterService.GetMWQMAnalysisReportParameterWithMWQMAnalysisReportParameterID(MWQMAnalysisReportParameterID);

                if (mwqmAnalysisReportParameter == null)
                {
                    return NotFound();
                }

                return Ok(mwqmAnalysisReportParameter);
            }
        }
        // POST api/mwqmAnalysisReportParameter
        [Route("")]
        public IActionResult Post([FromBody]MWQMAnalysisReportParameter mwqmAnalysisReportParameter, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMAnalysisReportParameterService mwqmAnalysisReportParameterService = new MWQMAnalysisReportParameterService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!mwqmAnalysisReportParameterService.Add(mwqmAnalysisReportParameter))
                {
                    return BadRequest(String.Join("|||", mwqmAnalysisReportParameter.ValidationResults));
                }
                else
                {
                    mwqmAnalysisReportParameter.ValidationResults = null;
                    return Created(Url.ToString(), mwqmAnalysisReportParameter);
                }
            }
        }
        // PUT api/mwqmAnalysisReportParameter
        [Route("")]
        public IActionResult Put([FromBody]MWQMAnalysisReportParameter mwqmAnalysisReportParameter, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMAnalysisReportParameterService mwqmAnalysisReportParameterService = new MWQMAnalysisReportParameterService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!mwqmAnalysisReportParameterService.Update(mwqmAnalysisReportParameter))
                {
                    return BadRequest(String.Join("|||", mwqmAnalysisReportParameter.ValidationResults));
                }
                else
                {
                    mwqmAnalysisReportParameter.ValidationResults = null;
                    return Ok(mwqmAnalysisReportParameter);
                }
            }
        }
        // DELETE api/mwqmAnalysisReportParameter
        [Route("")]
        public IActionResult Delete([FromBody]MWQMAnalysisReportParameter mwqmAnalysisReportParameter, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MWQMAnalysisReportParameterService mwqmAnalysisReportParameterService = new MWQMAnalysisReportParameterService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!mwqmAnalysisReportParameterService.Delete(mwqmAnalysisReportParameter))
                {
                    return BadRequest(String.Join("|||", mwqmAnalysisReportParameter.ValidationResults));
                }
                else
                {
                    mwqmAnalysisReportParameter.ValidationResults = null;
                    return Ok(mwqmAnalysisReportParameter);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
