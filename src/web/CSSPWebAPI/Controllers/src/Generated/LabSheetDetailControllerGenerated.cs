/*
 * Auto generated from the CSSPCodeWriter.proj by clicking on the [[ModelClassName]ControllerGenerated.cs] button
 *
 * Do not edit this file.
 *
 */ 

using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using CSSPWebAPI.Controllers.Resources;

namespace CSSPWebAPI.Controllers
{
    [Route("api/[controller]")]
    public partial class LabSheetDetailController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public LabSheetDetailController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/labSheetDetail
        [HttpGet]
        public IActionResult GetLabSheetDetailList(string lang = "en", int skip = 0, int take = 200,
            string asc = "", string desc = "", string where = "")
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
        [HttpGet("{LabSheetDetailID}")]
        public IActionResult GetLabSheetDetailWithID(int LabSheetDetailID, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                LabSheetDetailService labSheetDetailService = new LabSheetDetailService(new Query() { Lang = lang }, db, ContactID);

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
        [HttpPost]
        public IActionResult Post(LabSheetDetail labSheetDetail, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                LabSheetDetailService labSheetDetailService = new LabSheetDetailService(new Query() { Lang = lang }, db, ContactID);

                if (!labSheetDetailService.Add(labSheetDetail))
                {
                    return BadRequest(String.Join("|||", labSheetDetail.ValidationResults));
                }
                else
                {
                    labSheetDetail.ValidationResults = null;
                    return Created("/api/labSheetDetail/" + labSheetDetail.LabSheetDetailID, labSheetDetail);
                }
            }
        }
        // PUT api/labSheetDetail
        [HttpPut]
        public IActionResult Put(LabSheetDetail labSheetDetail, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                LabSheetDetailService labSheetDetailService = new LabSheetDetailService(new Query() { Lang = lang }, db, ContactID);

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
        [HttpDelete]
        public IActionResult Delete(LabSheetDetail labSheetDetail, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                LabSheetDetailService labSheetDetailService = new LabSheetDetailService(new Query() { Lang = lang }, db, ContactID);

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
