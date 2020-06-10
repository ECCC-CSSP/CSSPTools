using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using PolSourceGroupingExcelFileReadServices.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActionCommandDBServices.Services;
using ValidateAppSettingsServices.Services;
using CultureServices.Resources;
using CultureServices.Services;

namespace PolSourceGroupingExcelFileReadServices.Services
{
    public partial class PolSourceGroupingExcelFileReadService : IPolSourceGroupingExcelFileReadService
    {
        #region Variables
        private string FullFileName;
        List<string> NumberAndDashOnlyList = new List<string>() { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "-" };
        #endregion Variables

        #region Properties
        private ICultureService CultureService { get; set; }
        private IActionCommandDBService ActionCommandDBService { get; set; }
        private IValidateAppSettingsService ValidateAppSettingsService { get; set; }
        public List<GroupChoiceChildLevel> GroupChoiceChildLevelList { get; set; }
        #endregion Properties

        #region Constructors
        public PolSourceGroupingExcelFileReadService(ICultureService cultureService,
            IActionCommandDBService actionCommandDBService,
            IValidateAppSettingsService validateAppSettingsService)
        {
            CultureService = cultureService;
            ActionCommandDBService = actionCommandDBService;
            ValidateAppSettingsService = validateAppSettingsService;
        }
        #endregion Constructors

        #region Functions public
        public async Task<bool> ReadExcelSheet(string FullFileName, bool DoCheck)
        {
            this.FullFileName = FullFileName;
            GroupChoiceChildLevelList = new List<GroupChoiceChildLevel>();

            if (!await ReadExcelFile())
            {
                return false;
            }

            if (DoCheck)
            {
                if (!await CheckSpreadsheet())
                {
                    return false;
                }
            }

            foreach (GroupChoiceChildLevel groupChoiceChildLevel in GroupChoiceChildLevelList)
            {
                List<string> CSSPIDList2 = new List<string>();
                List<string> CSSPIDList = groupChoiceChildLevel.Hide.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(c => c.Trim()).ToList();
                foreach (string childCSSPID in CSSPIDList)
                {
                    int fromCSSPID = -1;
                    int toCSSPID = -1;
                    if (childCSSPID.Contains("-"))
                    {
                        fromCSSPID = int.Parse(childCSSPID.Substring(0, childCSSPID.IndexOf("-")));

                        int endPos = childCSSPID.IndexOf("-") + 1;
                        if (childCSSPID.Length <= endPos)
                        {
                            ActionCommandDBService.ErrorText.AppendLine($"CSSPID [{ groupChoiceChildLevel.CSSPID }] { CultureServicesRes.HideCellContains } [{ childCSSPID }] { CultureServicesRes.MissingEndValue }");
                            ActionCommandDBService.PercentCompleted = 0;
                            await ActionCommandDBService.Update();

                            return false;
                        }

                        toCSSPID = int.Parse(childCSSPID.Substring(childCSSPID.IndexOf("-") + 1));

                        if (fromCSSPID >= toCSSPID)
                        {
                            ActionCommandDBService.ErrorText.AppendLine($"CSSPID [{ groupChoiceChildLevel.CSSPID }] { CultureServicesRes.HideCellContains } [{ childCSSPID }] { CultureServicesRes.WhichTheFirstValueIs }  >= { CultureServicesRes.ThanTheLastValue }");
                            ActionCommandDBService.PercentCompleted = 0;
                            await ActionCommandDBService.Update();

                            return false;
                        }
                    }

                    if (fromCSSPID != -1)
                    {
                        for (int id = fromCSSPID; id <= toCSSPID; id++)
                        {
                            if (CSSPIDList2.Contains(id.ToString()) || CSSPIDList.Contains(id.ToString()))
                            {
                                ActionCommandDBService.ErrorText.AppendLine($"CSSPID [{ groupChoiceChildLevel.CSSPID }] { CultureServicesRes.HideCellContains } [{ childCSSPID }] { CultureServicesRes.WhichWillDuplicate } [{ id.ToString() }]");
                                ActionCommandDBService.PercentCompleted = 0;
                                await ActionCommandDBService.Update();

                                return false;
                            }

                            CSSPIDList2.Add(id.ToString());
                        }
                    }
                }
                foreach (string s in CSSPIDList2)
                {
                    CSSPIDList.Add(s);
                }

                CSSPIDList = CSSPIDList.Where(c => !c.Contains("-")).Distinct().ToList();

                groupChoiceChildLevel.Hide = string.Join(",", CSSPIDList);

                groupChoiceChildLevel.ID = int.Parse(groupChoiceChildLevel.CSSPID);
            }

            ActionCommandDBService.ExecutionStatusText.AppendLine($"{ CultureServicesRes.ExcelDocReadCompleted } ... ");
            //await actionCommandDBService.Update( 0);

            return true;
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
