using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSSPWebAPI.Controllers
{
    [Route("api/labSheetDetail")]
    public partial class LabSheetDetailController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public LabSheetDetailController() : base()
        {
        }
        public LabSheetDetailController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/labSheetDetail
        [Route("")]
        public IActionResult GetLabSheetDetailList([FromQuery]string lang = "en", [FromQuery]int skip = 0, [FromQuery]int take = 200,
            [FromQuery]string asc = "", [FromQuery]string desc = "", [FromQuery]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                LabSheetDetailService labSheetDetailService = new LabSheetDetailService(new Query() { Lang = lang }, db, ContactID);

                labSheetDetailService.Query = labSheetDetailService.FillQuery(typeof(LabSheetDetail), lang, skip, take, asc, desc, where);

                 if (labSheetDetailService.Query.HasErrors)
                 {
                     return Ok(new List<LabSheetDetail>()
                     {
                         new LabSheetDetail()
                         {
                             HasErrors = labSheetDetailService.Query.HasErrors,
                             ValidationResults = labSheetDetailService.Query.ValidationResults,
                         },
                     }.ToList());
                 }
                 else
                 {
                     return Ok(labSheetDetailService.GetLabSheetDetailList().ToList());
                 }
            }
        }
        // GET api/labSheetDetail/1
        [Route("{LabSheetDetailID:int}")]
        public IActionResult GetLabSheetDetailWithID([FromQuery]int LabSheetDetailID, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                LabSheetDetailService labSheetDetailService = new LabSheetDetailService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                labSheetDetailService.Query = labSheetDetailService.FillQuery(typeof(LabSheetDetail), lang, 0, 1, "", "");

                LabSheetDetail labSheetDetail = new LabSheetDetail();
                labSheetDetail = labSheetDetailService.GetLabSheetDetailWithLabSheetDetailID(LabSheetDetailID);

                if (labSheetDetail == null)
                {
                    return NotFound();
                }

                return Ok(labSheetDetail);
            }
        }
        // POST api/labSheetDetail
        [Route("")]
        public IActionResult Post([FromBody]LabSheetDetail labSheetDetail, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                LabSheetDetailService labSheetDetailService = new LabSheetDetailService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!labSheetDetailService.Add(labSheetDetail))
                {
                    return BadRequest(String.Join("|||", labSheetDetail.ValidationResults));
                }
                else
                {
                    labSheetDetail.ValidationResults = null;
                    return Created(Url.ToString(), labSheetDetail);
                }
            }
        }
        // PUT api/labSheetDetail
        [Route("")]
        public IActionResult Put([FromBody]LabSheetDetail labSheetDetail, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                LabSheetDetailService labSheetDetailService = new LabSheetDetailService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!labSheetDetailService.Update(labSheetDetail))
                {
                    return BadRequest(String.Join("|||", labSheetDetail.ValidationResults));
                }
                else
                {
                    labSheetDetail.ValidationResults = null;
                    return Ok(labSheetDetail);
                }
            }
        }
        // DELETE api/labSheetDetail
        [Route("")]
        public IActionResult Delete([FromBody]LabSheetDetail labSheetDetail, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                LabSheetDetailService labSheetDetailService = new LabSheetDetailService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!labSheetDetailService.Delete(labSheetDetail))
                {
                    return BadRequest(String.Join("|||", labSheetDetail.ValidationResults));
                }
                else
                {
                    labSheetDetail.ValidationResults = null;
                    return Ok(labSheetDetail);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
