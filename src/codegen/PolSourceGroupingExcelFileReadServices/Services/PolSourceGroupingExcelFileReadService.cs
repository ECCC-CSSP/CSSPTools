using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using PolSourceGroupingExcelFileReadServices.Models;
using PolSourceGroupingExcelFileReadServices.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActionCommandDBServices.Services;
using ValidateAppSettingsServices.Services;

namespace PolSourceGroupingExcelFileReadServices.Services
{
    public partial class PolSourceGroupingExcelFileReadService : IPolSourceGroupingExcelFileReadService
    {
        #region Variables
        private string FullFileName;
        List<string> NumberAndDashOnlyList = new List<string>() { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "-" };
        #endregion Variables

        #region Properties
        private IActionCommandDBService actionCommandDBService { get; set; }
        private IValidateAppSettingsService validateAppSettingsService { get; set; }
        public List<GroupChoiceChildLevel> groupChoiceChildLevelList { get; set; }
        #endregion Properties

        #region Constructors
        public PolSourceGroupingExcelFileReadService(IActionCommandDBService actionCommandDBService,
            IValidateAppSettingsService validateAppSettingsService)
        {
            this.actionCommandDBService = actionCommandDBService;
            this.validateAppSettingsService = validateAppSettingsService;
        }
        #endregion Constructors

        #region Functions public
        public async Task<bool> ReadExcelSheet(string FullFileName, bool DoCheck)
        {
            this.FullFileName = FullFileName;
            groupChoiceChildLevelList = new List<GroupChoiceChildLevel>();

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

            foreach (GroupChoiceChildLevel groupChoiceChildLevel in groupChoiceChildLevelList)
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
                            actionCommandDBService.ErrorText.AppendLine($"CSSPID [{ groupChoiceChildLevel.CSSPID }] { PolSourceGroupingExcelFileReadServicesRes.HideCellContains } [{ childCSSPID }] { PolSourceGroupingExcelFileReadServicesRes.MissingEndValue }");
                            actionCommandDBService.PercentCompleted = 0;
                            await actionCommandDBService.Update();

                            return false;
                        }

                        toCSSPID = int.Parse(childCSSPID.Substring(childCSSPID.IndexOf("-") + 1));

                        if (fromCSSPID >= toCSSPID)
                        {
                            actionCommandDBService.ErrorText.AppendLine($"CSSPID [{ groupChoiceChildLevel.CSSPID }] { PolSourceGroupingExcelFileReadServicesRes.HideCellContains } [{ childCSSPID }] { PolSourceGroupingExcelFileReadServicesRes.WhichTheFirstValueIs }  >= { PolSourceGroupingExcelFileReadServicesRes.ThanTheLastValue }");
                            actionCommandDBService.PercentCompleted = 0;
                            await actionCommandDBService.Update();

                            return false;
                        }
                    }

                    if (fromCSSPID != -1)
                    {
                        for (int id = fromCSSPID; id <= toCSSPID; id++)
                        {
                            if (CSSPIDList2.Contains(id.ToString()) || CSSPIDList.Contains(id.ToString()))
                            {
                                actionCommandDBService.ErrorText.AppendLine($"CSSPID [{ groupChoiceChildLevel.CSSPID }] { PolSourceGroupingExcelFileReadServicesRes.HideCellContains } [{ childCSSPID }] { PolSourceGroupingExcelFileReadServicesRes.WhichWillDuplicate } [{ id.ToString() }]");
                                actionCommandDBService.PercentCompleted = 0;
                                await actionCommandDBService.Update();

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

            actionCommandDBService.ExecutionStatusText.AppendLine($"{ PolSourceGroupingExcelFileReadServicesRes.ExcelDocReadCompleted } ... ");
            //await actionCommandDBService.Update( 0);

            return true;
        }
        public async Task SetCulture(CultureInfo Culture)
        {
            PolSourceGroupingExcelFileReadServicesRes.Culture = Culture;
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
