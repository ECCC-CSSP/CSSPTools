using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;;

namespace CSSPWebAPI.Controllers
{
    [Route("api/labSheet")]
    public partial class LabSheetController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public LabSheetController() : base()
        {
        }
        public LabSheetController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/labSheet
        [Route("")]
        public IHttpActionResult GetLabSheetList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                LabSheetService labSheetService = new LabSheetService(new Query() { Lang = lang }, db, ContactID);

                else
                {
                   labSheetService.Query = labSheetService.FillQuery(typeof(LabSheet), lang, skip, take, asc, desc, where);

                    if (labSheetService.Query.HasErrors)
                    {
                        return Ok(new List<LabSheet>()
                        {
                            new LabSheet()
                            {
                                HasErrors = labSheetService.Query.HasErrors,
                                ValidationResults = labSheetService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(labSheetService.GetLabSheetList().ToList());
                    }
                }
            }
        }
        // GET api/labSheet/1
        [Route("{LabSheetID:int}")]
        public IHttpActionResult GetLabSheetWithID([FromUri]int LabSheetID, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                LabSheetService labSheetService = new LabSheetService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                labSheetService.Query = labSheetService.FillQuery(typeof(LabSheet), lang, 0, 1, "", "");

                else
                {
                    LabSheet labSheet = new LabSheet();
                    labSheet = labSheetService.GetLabSheetWithLabSheetID(LabSheetID);

                    if (labSheet == null)
                    {
                        return NotFound();
                    }

                    return Ok(labSheet);
                }
            }
        }
        // POST api/labSheet
        [Route("")]
        public IHttpActionResult Post([FromBody]LabSheet labSheet, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                LabSheetService labSheetService = new LabSheetService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!labSheetService.Add(labSheet))
                {
                    return BadRequest(String.Join("|||", labSheet.ValidationResults));
                }
                else
                {
                    labSheet.ValidationResults = null;
                    return Created<LabSheet>(new Uri(Request.RequestUri, labSheet.LabSheetID.ToString()), labSheet);
                }
            }
        }
        // PUT api/labSheet
        [Route("")]
        public IHttpActionResult Put([FromBody]LabSheet labSheet, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                LabSheetService labSheetService = new LabSheetService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!labSheetService.Update(labSheet))
                {
                    return BadRequest(String.Join("|||", labSheet.ValidationResults));
                }
                else
                {
                    labSheet.ValidationResults = null;
                    return Ok(labSheet);
                }
            }
        }
        // DELETE api/labSheet
        [Route("")]
        public IHttpActionResult Delete([FromBody]LabSheet labSheet, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                LabSheetService labSheetService = new LabSheetService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!labSheetService.Delete(labSheet))
                {
                    return BadRequest(String.Join("|||", labSheet.ValidationResults));
                }
                else
                {
                    labSheet.ValidationResults = null;
                    return Ok(labSheet);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
