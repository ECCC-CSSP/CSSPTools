using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSSPWebAPI.Controllers
{
    [Route("api/labSheetTubeMPNDetail")]
    public partial class LabSheetTubeMPNDetailController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public LabSheetTubeMPNDetailController() : base()
        {
        }
        public LabSheetTubeMPNDetailController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/labSheetTubeMPNDetail
        [Route("")]
        public IActionResult GetLabSheetTubeMPNDetailList([FromQuery]string lang = "en", [FromQuery]int skip = 0, [FromQuery]int take = 200,
            [FromQuery]string asc = "", [FromQuery]string desc = "", [FromQuery]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                LabSheetTubeMPNDetailService labSheetTubeMPNDetailService = new LabSheetTubeMPNDetailService(new Query() { Lang = lang }, db, ContactID);

                labSheetTubeMPNDetailService.Query = labSheetTubeMPNDetailService.FillQuery(typeof(LabSheetTubeMPNDetail), lang, skip, take, asc, desc, where);

                 if (labSheetTubeMPNDetailService.Query.HasErrors)
                 {
                     return Ok(new List<LabSheetTubeMPNDetail>()
                     {
                         new LabSheetTubeMPNDetail()
                         {
                             HasErrors = labSheetTubeMPNDetailService.Query.HasErrors,
                             ValidationResults = labSheetTubeMPNDetailService.Query.ValidationResults,
                         },
                     }.ToList());
                 }
                 else
                 {
                     return Ok(labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList().ToList());
                 }
            }
        }
        // GET api/labSheetTubeMPNDetail/1
        [Route("{LabSheetTubeMPNDetailID:int}")]
        public IActionResult GetLabSheetTubeMPNDetailWithID([FromQuery]int LabSheetTubeMPNDetailID, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                LabSheetTubeMPNDetailService labSheetTubeMPNDetailService = new LabSheetTubeMPNDetailService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                labSheetTubeMPNDetailService.Query = labSheetTubeMPNDetailService.FillQuery(typeof(LabSheetTubeMPNDetail), lang, 0, 1, "", "");

                LabSheetTubeMPNDetail labSheetTubeMPNDetail = new LabSheetTubeMPNDetail();
                labSheetTubeMPNDetail = labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailWithLabSheetTubeMPNDetailID(LabSheetTubeMPNDetailID);

                if (labSheetTubeMPNDetail == null)
                {
                    return NotFound();
                }

                return Ok(labSheetTubeMPNDetail);
            }
        }
        // POST api/labSheetTubeMPNDetail
        [Route("")]
        public IActionResult Post([FromBody]LabSheetTubeMPNDetail labSheetTubeMPNDetail, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                LabSheetTubeMPNDetailService labSheetTubeMPNDetailService = new LabSheetTubeMPNDetailService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail))
                {
                    return BadRequest(String.Join("|||", labSheetTubeMPNDetail.ValidationResults));
                }
                else
                {
                    labSheetTubeMPNDetail.ValidationResults = null;
                    return Created(Url.ToString(), labSheetTubeMPNDetail);
                }
            }
        }
        // PUT api/labSheetTubeMPNDetail
        [Route("")]
        public IActionResult Put([FromBody]LabSheetTubeMPNDetail labSheetTubeMPNDetail, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                LabSheetTubeMPNDetailService labSheetTubeMPNDetailService = new LabSheetTubeMPNDetailService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!labSheetTubeMPNDetailService.Update(labSheetTubeMPNDetail))
                {
                    return BadRequest(String.Join("|||", labSheetTubeMPNDetail.ValidationResults));
                }
                else
                {
                    labSheetTubeMPNDetail.ValidationResults = null;
                    return Ok(labSheetTubeMPNDetail);
                }
            }
        }
        // DELETE api/labSheetTubeMPNDetail
        [Route("")]
        public IActionResult Delete([FromBody]LabSheetTubeMPNDetail labSheetTubeMPNDetail, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                LabSheetTubeMPNDetailService labSheetTubeMPNDetailService = new LabSheetTubeMPNDetailService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!labSheetTubeMPNDetailService.Delete(labSheetTubeMPNDetail))
                {
                    return BadRequest(String.Join("|||", labSheetTubeMPNDetail.ValidationResults));
                }
                else
                {
                    labSheetTubeMPNDetail.ValidationResults = null;
                    return Ok(labSheetTubeMPNDetail);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
