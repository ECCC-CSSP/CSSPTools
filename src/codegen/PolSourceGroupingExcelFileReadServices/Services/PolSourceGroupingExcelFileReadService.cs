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
using CSSPCultureServices.Resources;
using CSSPCultureServices.Services;

namespace PolSourceGroupingExcelFileReadServices.Services
{
    public interface IPolSourceGroupingExcelFileReadService
    {
        List<GroupChoiceChildLevel> GroupChoiceChildLevelList { get; set; }

        Task<bool> ReadExcelSheet(string FullFileName, bool DoCheck);
    }
    public partial class PolSourceGroupingExcelFileReadService : IPolSourceGroupingExcelFileReadService
    {
        #region Variables
        private string FullFileName;
        List<string> NumberAndDashOnlyList = new List<string>() { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "-" };
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; set; }
        private IActionCommandDBService ActionCommandDBService { get; set; }
        private IValidateAppSettingsService ValidateAppSettingsService { get; set; }
        public List<GroupChoiceChildLevel> GroupChoiceChildLevelList { get; set; }
        #endregion Properties

        #region Constructors
        public PolSourceGroupingExcelFileReadService(ICSSPCultureService CSSPCultureService,
            IActionCommandDBService ActionCommandDBService,
            IValidateAppSettingsService ValidateAppSettingsService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.ActionCommandDBService = ActionCommandDBService;
            this.ValidateAppSettingsService = ValidateAppSettingsService;
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
                            ActionCommandDBService.ErrorText.AppendLine($"CSSPID [{ groupChoiceChildLevel.CSSPID }] { CSSPCultureServicesRes.HideCellContains } [{ childCSSPID }] { CSSPCultureServicesRes.MissingEndValue }");
                            ActionCommandDBService.PercentCompleted = 0;
                            await ActionCommandDBService.Update();

                            return false;
                        }

                        toCSSPID = int.Parse(childCSSPID.Substring(childCSSPID.IndexOf("-") + 1));

                        if (fromCSSPID >= toCSSPID)
                        {
                            ActionCommandDBService.ErrorText.AppendLine($"CSSPID [{ groupChoiceChildLevel.CSSPID }] { CSSPCultureServicesRes.HideCellContains } [{ childCSSPID }] { CSSPCultureServicesRes.WhichTheFirstValueIs }  >= { CSSPCultureServicesRes.ThanTheLastValue }");
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
                                ActionCommandDBService.ErrorText.AppendLine($"CSSPID [{ groupChoiceChildLevel.CSSPID }] { CSSPCultureServicesRes.HideCellContains } [{ childCSSPID }] { CSSPCultureServicesRes.WhichWillDuplicate } [{ id.ToString() }]");
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

            ActionCommandDBService.ExecutionStatusText.AppendLine($"{ CSSPCultureServicesRes.ExcelDocReadCompleted } ... ");
            //await actionCommandDBService.Update( 0);

            return true;
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
