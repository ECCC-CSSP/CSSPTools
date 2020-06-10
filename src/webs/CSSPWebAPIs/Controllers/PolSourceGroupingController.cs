using CSSPEnums;
using CSSPModels;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PolSourceGroupingExcelFileReadServices.Models;
using PolSourceGroupingExcelFileReadServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSSPCodeGenWebAPI.Controllers
{
    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public class PolSourceGroupingController : ControllerBase
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IPolSourceGroupingExcelFileReadService PolSourceGroupingExcelFileReadService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public PolSourceGroupingController(IPolSourceGroupingExcelFileReadService polSourceGroupingExcelFileReadService, 
            CSSPDBContext db, ILoggedInService loggedInService)
        {
            PolSourceGroupingExcelFileReadService = polSourceGroupingExcelFileReadService;
            this.loggedInService = loggedInService;
            this.db = db;
        }
        #endregion Constructors

        #region Functions public
        [Route("GetGrouping")]
        [HttpGet]
        public async Task<ActionResult<GroupSourceGroupingModel>> GetGrouping()
        {
            await loggedInService.SetID(User.Identity.Name);

            GroupSourceGroupingModel groupSourceGroupingModel = new GroupSourceGroupingModel();

            List<PolSourceGrouping> polSourceGroupingList = (from c in db.PolSourceGroupings
                                                             select c).ToList();

            List<PolSourceGroupingLanguage> polSourceGroupingLanguageList = (from c in db.PolSourceGroupingLanguages
                                                                             select c).ToList();

            groupSourceGroupingModel.PolSourceGroupingList = polSourceGroupingList;
            groupSourceGroupingModel.PolSourceGroupingLanguageList = polSourceGroupingLanguageList;

            return Ok(groupSourceGroupingModel);
        }

        [Route("FillDBWithGrouping")]
        [HttpGet]
        public async Task<ActionResult<GroupSourceGroupingModel>> FillDBWithGrouping()
        {
            GroupSourceGroupingModel groupSourceGroupingModel = new GroupSourceGroupingModel();

            await PolSourceGroupingExcelFileReadService.ReadExcelSheet(@"C:\CSSPTools\src\assets\PolSourceGrouping.xlsm", false);

            foreach (GroupChoiceChildLevel groupChoiceChildLevel in PolSourceGroupingExcelFileReadService.GroupChoiceChildLevelList)
            {
                PolSourceGrouping polSourceGrouping = new PolSourceGrouping()
                {
                    CSSPID = int.Parse(groupChoiceChildLevel.CSSPID),
                    GroupName = groupChoiceChildLevel.Group,
                    Child = groupChoiceChildLevel.Child,
                    Hide = groupChoiceChildLevel.Hide
                };

                try
                {
                    db.PolSourceGroupings.Add(polSourceGrouping);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return BadRequest($"Could not add PolSourceGrouping with CSSPID [{ groupChoiceChildLevel.CSSPID }]");
                }

                PolSourceGroupingLanguage polSourceGroupingLanguageEN = new PolSourceGroupingLanguage()
                {
                    PolSourceGroupingID = polSourceGrouping.PolSourceGroupingID,
                    Language = LanguageEnum.en,
                    SourceName = groupChoiceChildLevel.EN,
                    SourceNameOrder = 0,
                    TranslationStatusSourceName = TranslationStatusEnum.Translated,
                    Init = groupChoiceChildLevel.InitEN,
                    TranslationStatusInit = TranslationStatusEnum.Translated,
                    Description = groupChoiceChildLevel.DescEN,
                    TranslationStatusDescription = TranslationStatusEnum.Translated,
                    Report = groupChoiceChildLevel.ReportEN,
                    TranslationStatusReport = TranslationStatusEnum.Translated,
                    Text = groupChoiceChildLevel.TextEN,
                    TranslationStatusText = TranslationStatusEnum.Translated
                };

                try
                {
                    db.PolSourceGroupingLanguages.Add(polSourceGroupingLanguageEN);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return BadRequest($"Could not add PolSourceGroupingLanguage with CSSPID [{ groupChoiceChildLevel.CSSPID }] and Language [{ LanguageEnum.en }]");
                }

                PolSourceGroupingLanguage polSourceGroupingLanguageFR = new PolSourceGroupingLanguage()
                {
                    PolSourceGroupingID = polSourceGrouping.PolSourceGroupingID,
                    Language = LanguageEnum.fr,
                    SourceName = groupChoiceChildLevel.FR,
                    SourceNameOrder = 0,
                    TranslationStatusSourceName = TranslationStatusEnum.Translated,
                    Init = groupChoiceChildLevel.InitFR,
                    TranslationStatusInit = TranslationStatusEnum.Translated,
                    Description = groupChoiceChildLevel.DescFR,
                    TranslationStatusDescription = TranslationStatusEnum.Translated,
                    Report = groupChoiceChildLevel.ReportFR,
                    TranslationStatusReport = TranslationStatusEnum.Translated,
                    Text = groupChoiceChildLevel.TextFR,
                    TranslationStatusText = TranslationStatusEnum.Translated
                };

                try
                {
                    db.PolSourceGroupingLanguages.Add(polSourceGroupingLanguageFR);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return BadRequest($"Could not add PolSourceGroupingLanguage with CSSPID [{ groupChoiceChildLevel.CSSPID }] and Language [{ LanguageEnum.fr }]");
                }
            }

            List<PolSourceGrouping> polSourceGroupingList = (from c in db.PolSourceGroupings
                                                             select c).ToList();

            List<PolSourceGroupingLanguage> polSourceGroupingLanguageList = (from c in db.PolSourceGroupingLanguages
                                                                             select c).ToList();

            groupSourceGroupingModel.PolSourceGroupingList = polSourceGroupingList;
            groupSourceGroupingModel.PolSourceGroupingLanguageList = polSourceGroupingLanguageList;

            return Ok(groupSourceGroupingModel);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }

    public class GroupSourceGroupingModel
    {
        public GroupSourceGroupingModel()
        {
            PolSourceGroupingList = new List<PolSourceGrouping>();
            PolSourceGroupingLanguageList = new List<PolSourceGroupingLanguage>();
        }

        public List<PolSourceGrouping> PolSourceGroupingList { get; set; }
        public List<PolSourceGroupingLanguage> PolSourceGroupingLanguageList { get; set; }
    }
}
