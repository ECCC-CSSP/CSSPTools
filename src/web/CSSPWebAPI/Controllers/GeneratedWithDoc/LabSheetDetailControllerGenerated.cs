using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;;

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
        public IHttpActionResult GetLabSheetDetailList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                LabSheetDetailService labSheetDetailService = new LabSheetDetailService(new Query() { Lang = lang }, db, ContactID);

                else
                {
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
        }
        // GET api/labSheetDetail/1
        [Route("{LabSheetDetailID:int}")]
        public IHttpActionResult GetLabSheetDetailWithID([FromUri]int LabSheetDetailID, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                LabSheetDetailService labSheetDetailService = new LabSheetDetailService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                labSheetDetailService.Query = labSheetDetailService.FillQuery(typeof(LabSheetDetail), lang, 0, 1, "", "");

                else
                {
                    LabSheetDetail labSheetDetail = new LabSheetDetail();
                    labSheetDetail = labSheetDetailService.GetLabSheetDetailWithLabSheetDetailID(LabSheetDetailID);

                    if (labSheetDetail == null)
                    {
                        return NotFound();
                    }

                    return Ok(labSheetDetail);
                }
            }
        }
        // POST api/labSheetDetail
        [Route("")]
        public IHttpActionResult Post([FromBody]LabSheetDetail labSheetDetail, [FromUri]string lang = "en")
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
                    return Created<LabSheetDetail>(new Uri(Request.RequestUri, labSheetDetail.LabSheetDetailID.ToString()), labSheetDetail);
                }
            }
        }
        // PUT api/labSheetDetail
        [Route("")]
        public IHttpActionResult Put([FromBody]LabSheetDetail labSheetDetail, [FromUri]string lang = "en")
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
        public IHttpActionResult Delete([FromBody]LabSheetDetail labSheetDetail, [FromUri]string lang = "en")
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
