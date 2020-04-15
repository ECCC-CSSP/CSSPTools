using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using CSSPPolSourceGroupingExcelFileRead.Models;
using CSSPPolSourceGroupingExcelFileRead.Resources;
using StatusAndResultsDBService.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPPolSourceGroupingExcelFileRead.Services
{
    public class PolSourceGroupingExcelFileRead : IPolSourceGroupingExcelFileRead
    {
        #region Variables
        private string FullFileName;
        List<string> NumberAndDashOnlyList = new List<string>() { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "-" };
        #endregion Variables

        #region Properties
        public  List<GroupChoiceChildLevel> groupChoiceChildLevelList { get; set; }
        #endregion Properties

        #region Constructors
        public PolSourceGroupingExcelFileRead()
        {
        }
        #endregion Constructors

        #region Functions public
        public async Task<bool> ReadExcelSheet(string FullFileName, bool DoCheck, StringBuilder sbError, StringBuilder sbStatus, string command, IStatusAndResultsService statusAndResultsService)
        {
            this.FullFileName = FullFileName;
            groupChoiceChildLevelList = new List<GroupChoiceChildLevel>();

            if (!await ReadExcelFile(sbError, sbStatus, command, statusAndResultsService))
            {
                return false;
            }

            if (DoCheck)
            {
                if (! await CheckSpreadsheet(sbError, sbStatus, command, statusAndResultsService))
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
                            sbError.AppendLine($"CSSPID [{ groupChoiceChildLevel.CSSPID }] { PolSourceGroupingExcelFileReadRes.HideCellContains } [{ childCSSPID }] { PolSourceGroupingExcelFileReadRes.MissingEndValue }");
                            await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);
                            return false;
                        }

                        toCSSPID = int.Parse(childCSSPID.Substring(childCSSPID.IndexOf("-") + 1));

                        if (fromCSSPID >= toCSSPID)
                        {
                            sbError.AppendLine($"CSSPID [{ groupChoiceChildLevel.CSSPID }] { PolSourceGroupingExcelFileReadRes.HideCellContains } [{ childCSSPID }] { PolSourceGroupingExcelFileReadRes.WhichTheFirstValueIs }  >= { PolSourceGroupingExcelFileReadRes.ThanTheLastValue }");
                            await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);
                            return false;
                        }
                    }

                    if (fromCSSPID != -1)
                    {
                        for (int id = fromCSSPID; id <= toCSSPID; id++)
                        {
                            if (CSSPIDList2.Contains(id.ToString()) || CSSPIDList.Contains(id.ToString()))
                            {
                                sbError.AppendLine($"CSSPID [{ groupChoiceChildLevel.CSSPID }] { PolSourceGroupingExcelFileReadRes.HideCellContains } [{ childCSSPID }] { PolSourceGroupingExcelFileReadRes.WhichWillDuplicate } [{ id.ToString() }]");
                                await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);
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

            sbStatus.AppendLine($"{ PolSourceGroupingExcelFileReadRes.ExcelDocReadCompleted } ... ");
            await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);

            return true;
        }
        public async Task<bool> GetRecursiveForShowAllPaths(string s, List<string> textList, int Level, bool RaiseEvents, StringBuilder sb, StringBuilder sbError, StringBuilder sbStatus, string command, IStatusAndResultsService statusAndResultsService)
        {
            textList.RemoveRange(Level, (textList.Count - Level));

            if (textList.Contains(s))
            {
                sbError.AppendLine($"{ PolSourceGroupingExcelFileReadRes.RecursiveFound } ...");
                sbError.AppendLine("");
                await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);
                foreach (string sp in textList)
                {
                    sbError.AppendLine($"{ sp }");
                    await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);
                }
                sbError.AppendLine($"{ s }");
                await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);

                return false;
            }

            sbStatus.AppendLine($"{ PolSourceGroupingExcelFileReadRes.Doing } ... { s }");
            await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);

            if (RaiseEvents)
            {
                StringBuilder sb2 = new StringBuilder();
                foreach (string text in textList)
                {
                    sb2.Append($"{ text }\t");
                }

                sb.AppendLine(sb2.ToString());
            }

            Level = Level + 1;
            textList.Add(s);

            List<GroupChoiceChildLevel> groupChoiceChildLevelChildList = groupChoiceChildLevelList.Where(c => c.Group == s && c.Choice != "").ToList();
            if (groupChoiceChildLevelChildList.Count > 0)
            {
                foreach (string child in groupChoiceChildLevelChildList.Select(c => c.Child).Distinct())
                {
                    if (! await GetRecursiveForShowAllPaths(child, textList, Level, RaiseEvents, sb, sbError, sbStatus, command, statusAndResultsService))
                        return false;
                }
            }

            sbStatus.AppendLine($"");
            await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);

            return true;
        }
        public async Task SetCulture(CultureInfo Culture)
        {
            PolSourceGroupingExcelFileReadRes.Culture = Culture;
        }
        #endregion Functions public

        #region Functions private
        private async Task<bool> CheckSpreadsheet(StringBuilder sbError, StringBuilder sbStatus, string command, IStatusAndResultsService statusAndResultsService)
        {
            if (groupChoiceChildLevelList.Count == 0)
                return false;

            // Checking child exist
            List<string> childList = (from c in groupChoiceChildLevelList
                                      where c.Child.Length > 0
                                      select c.Child).Distinct().ToList();

            int countChild = 0;
            foreach (string child in childList)
            {
                countChild += 1;

                if (countChild % 200 == 0)
                {
                    sbStatus.AppendLine($"{ PolSourceGroupingExcelFileReadRes.Checking } ... { PolSourceGroupingExcelFileReadRes.That } { child } { PolSourceGroupingExcelFileReadRes.ExistOnColumnGroup }");
                    await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);
                }

                GroupChoiceChildLevel groupChoiceChildLevelExist = (from c in groupChoiceChildLevelList
                                                                    where c.Group == child
                                                                    select c).FirstOrDefault();

                if (groupChoiceChildLevelExist == null)
                {
                    sbError.AppendLine($"{ child } ----- { PolSourceGroupingExcelFileReadRes.DoesNotExistOnColumnGroup }");
                    sbError.AppendLine("");
                    await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);

                    return false;
                }
            }

            sbStatus.AppendLine($"{ PolSourceGroupingExcelFileReadRes.AllChildDoExistOnColumnGroup }");
            sbStatus.AppendLine("");
            await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);

            foreach (GroupChoiceChildLevel groupChoiceChildLevel in groupChoiceChildLevelList)
            {
                if (groupChoiceChildLevel.Group.Length < 5)
                {
                    sbError.AppendLine($"{ PolSourceGroupingExcelFileReadRes.Group }: { groupChoiceChildLevel.CSSPID } { PolSourceGroupingExcelFileReadRes.PotentialEmptyRowAbove }.");
                    sbError.AppendLine("");
                    await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);

                    return false;
                }
            }

            // Checking EN and FR text exist for Group ending with Start
            List<GroupChoiceChildLevel> groupChoiceChildLevelGroupList = (from c in groupChoiceChildLevelList
                                                                          where c.Group.Substring(c.Group.Length - 5) == "Start"
                                                                          select c).Distinct().ToList();

            countChild = 0;
            foreach (GroupChoiceChildLevel groupChoiceChildLevel in groupChoiceChildLevelGroupList)
            {
                countChild += 1;

                if (countChild % 200 == 0)
                {
                    sbStatus.AppendLine($"{ PolSourceGroupingExcelFileReadRes.Checking } ... { PolSourceGroupingExcelFileReadRes.ThatGroup } { groupChoiceChildLevel.Group }--- EN/FR: { groupChoiceChildLevel.EN } { PolSourceGroupingExcelFileReadRes.HasENFRText }");
                    await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);
                }

                if (string.IsNullOrWhiteSpace(groupChoiceChildLevel.EN))
                {
                    sbError.AppendLine($"Group: { groupChoiceChildLevel.Group } --- EN: { groupChoiceChildLevel.EN } ----- { PolSourceGroupingExcelFileReadRes.DoesNotHaveENText }");
                    sbError.AppendLine("");
                    await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);

                    return false;
                }

                countChild += 1;

                if (string.IsNullOrWhiteSpace(groupChoiceChildLevel.FR))
                {
                    sbError.AppendLine($"Group: { groupChoiceChildLevel.Group } --- EN: { groupChoiceChildLevel.FR } ----- { PolSourceGroupingExcelFileReadRes.DoesNotHaveFRText }");
                    sbError.AppendLine("");
                    await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);

                    return false;
                }

            }

            sbStatus.AppendLine($"{ PolSourceGroupingExcelFileReadRes.EachGroupWithEndingName } = 'Start' { PolSourceGroupingExcelFileReadRes.DoesHaveENandFRText }.");
            sbStatus.AppendLine("");
            await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);

            // Checking DescEN and DescFR text exist for Group ending with Start
            List<GroupChoiceChildLevel> groupChoiceChildLevelGroupDescList = (from c in groupChoiceChildLevelList
                                                                              where c.Group.Substring(c.Group.Length - 5) == "Start"
                                                                              select c).Distinct().ToList();

            countChild = 0;
            foreach (GroupChoiceChildLevel groupChoiceChildLevel in groupChoiceChildLevelGroupDescList)
            {
                if (string.IsNullOrWhiteSpace(groupChoiceChildLevel.Choice))
                {
                    countChild += 1;

                    if (countChild % 200 == 0)
                    {
                        sbStatus.AppendLine($"{ PolSourceGroupingExcelFileReadRes.Checking } ... { PolSourceGroupingExcelFileReadRes.ThatGroup } { groupChoiceChildLevel.Group } --- EN/FR: { groupChoiceChildLevel.EN } { PolSourceGroupingExcelFileReadRes.HasDescENDescFRText }");
                        sbStatus.AppendLine("");
                        await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);
                    }

                    if (string.IsNullOrWhiteSpace(groupChoiceChildLevel.DescEN))
                    {
                        sbError.AppendLine($"{ PolSourceGroupingExcelFileReadRes.Group}: { groupChoiceChildLevel.Group } --- EN: { groupChoiceChildLevel.EN } ----- { PolSourceGroupingExcelFileReadRes.DoesNotHaveDescENText }");
                        sbError.AppendLine("");
                        await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);

                        return false;
                    }

                    if (string.IsNullOrWhiteSpace(groupChoiceChildLevel.DescFR))
                    {
                        sbError.AppendLine($"{ PolSourceGroupingExcelFileReadRes.Group}: { groupChoiceChildLevel.Group } --- FR: { groupChoiceChildLevel.FR } ----- { PolSourceGroupingExcelFileReadRes.DoesNotHaveDescFRText }");
                        sbError.AppendLine("");
                        await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);

                        return false;
                    }
                }
            }

            sbStatus.AppendLine($"{ PolSourceGroupingExcelFileReadRes.EachGroupWithEndingName} = 'Start' { PolSourceGroupingExcelFileReadRes.DoesHaveDescENAndDescFRText }.");
            sbStatus.AppendLine("");
            await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);

            // Checking EN and FR text exist for Choice.Length > 0
            List<GroupChoiceChildLevel> groupChoiceChildLevelChoiceList = (from c in groupChoiceChildLevelList
                                                                           where c.Choice.Length > 0
                                                                           select c).Distinct().ToList();

            countChild = 0;
            foreach (GroupChoiceChildLevel groupChoiceChildLevel in groupChoiceChildLevelChoiceList)
            {
                countChild += 1;

                if (countChild % 200 == 0)
                {
                    sbStatus.AppendLine($"{ PolSourceGroupingExcelFileReadRes.Checking } ... { PolSourceGroupingExcelFileReadRes.ThatGroup } { groupChoiceChildLevel.Group } --- EN/FR: { groupChoiceChildLevel.EN } { PolSourceGroupingExcelFileReadRes.HasENFRText }");
                    sbStatus.AppendLine("");
                    await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);
                }

                if (string.IsNullOrWhiteSpace(groupChoiceChildLevel.EN))
                {
                    sbError.AppendLine($"{ PolSourceGroupingExcelFileReadRes.Group }: { groupChoiceChildLevel.Group } --- EN: { groupChoiceChildLevel.EN } ----- { PolSourceGroupingExcelFileReadRes.DoesNotHaveENText }");
                    sbError.AppendLine("");
                    await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);

                    return false;
                }

                if (string.IsNullOrWhiteSpace(groupChoiceChildLevel.FR))
                {
                    sbError.AppendLine($"{ PolSourceGroupingExcelFileReadRes.Group }: { groupChoiceChildLevel.Group } --- FR: { groupChoiceChildLevel.FR } ----- { PolSourceGroupingExcelFileReadRes.DoesNotHaveFRText }");
                    sbError.AppendLine("");
                    await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);

                    return false;
                }

            }

            sbStatus.AppendLine($"{ PolSourceGroupingExcelFileReadRes.EachChoiceDoesHaveENAndFRText }.");
            sbStatus.AppendLine("");
            await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);

            // Checking ReportEN and ReportFR text exist for Child.Length > 0
            groupChoiceChildLevelChoiceList = (from c in groupChoiceChildLevelList
                                               where c.Child.Length > 0
                                               select c).Distinct().ToList();

            countChild = 0;
            foreach (GroupChoiceChildLevel groupChoiceChildLevel in groupChoiceChildLevelChoiceList)
            {
                countChild += 1;

                if (countChild % 200 == 0)
                {
                    sbStatus.AppendLine($"{ PolSourceGroupingExcelFileReadRes.Checking } ... { PolSourceGroupingExcelFileReadRes.ThatGroup } { groupChoiceChildLevel.Group } --- EN/FR: { groupChoiceChildLevel.EN } { PolSourceGroupingExcelFileReadRes.HasReportENReportFRText }. { PolSourceGroupingExcelFileReadRes.YouCanAddASpaceToFixTheProblem }.");
                    sbStatus.AppendLine("");
                    await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);
                }

                if (string.IsNullOrWhiteSpace(groupChoiceChildLevel.ReportEN) && groupChoiceChildLevel.ReportEN.Length == 0)
                {
                    sbError.AppendLine($"{ PolSourceGroupingExcelFileReadRes.Group}: { groupChoiceChildLevel.Group } --- EN: { groupChoiceChildLevel.EN } ----- { PolSourceGroupingExcelFileReadRes.DoesNotHaveReportENText }. { PolSourceGroupingExcelFileReadRes.YouCanAddASpaceToFixTheProblem }.");
                    sbError.AppendLine("");
                    await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);

                    return false;
                }

                if (string.IsNullOrWhiteSpace(groupChoiceChildLevel.ReportFR) && groupChoiceChildLevel.ReportFR.Length == 0)
                {
                    sbError.AppendLine($"{ PolSourceGroupingExcelFileReadRes.Group}: { groupChoiceChildLevel.Group } --- FR: { groupChoiceChildLevel.FR } ----- { PolSourceGroupingExcelFileReadRes.DoesNotHaveReportFRText }. { PolSourceGroupingExcelFileReadRes.YouCanAddASpaceToFixTheProblem }.");
                    sbError.AppendLine("");
                    await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);

                    return false;
                }

            }

            sbStatus.AppendLine($"{ PolSourceGroupingExcelFileReadRes.EachChoiceDoesHaveReportENAndReportFRText }.");
            sbStatus.AppendLine("");
            await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);

            // Checking for duplicates in column Group
            List<GroupChoiceChildLevel> groupChoiceChildLevelStraitList = new List<GroupChoiceChildLevel>();

            FileInfo fi = new FileInfo(FullFileName);

            try
            {
                //Lets open the existing excel file and read through its content . Open the excel using openxml sdk
                using (SpreadsheetDocument doc = SpreadsheetDocument.Open(fi.FullName, false))
                {
                    //create the object for workbook part  
                    WorkbookPart workbookPart = doc.WorkbookPart;
                    Sheets thesheetcollection = workbookPart.Workbook.GetFirstChild<Sheets>();
                    //StringBuilder sb = new StringBuilder();

                    //using for each loop to get the sheet from the sheetcollection  
                    foreach (Sheet thesheet in thesheetcollection)
                    {
                        if (thesheet.Name == "PolsourceGrouping")
                        {
                            string CSSPID = "";
                            string Group = "";
                            string Choice = "";
                            string Child = "";
                            string Hide = "";
                            string EN = "";
                            string InitEN = "";
                            string DescEN = "";
                            string ReportEN = "";
                            string TextEN = "";
                            string FR = "";
                            string InitFR = "";
                            string DescFR = "";
                            string ReportFR = "";
                            string TextFR = "";

                            Worksheet theWorksheet = ((WorksheetPart)workbookPart.GetPartById(thesheet.Id)).Worksheet;

                            SheetData thesheetdata = (SheetData)theWorksheet.GetFirstChild<SheetData>();
                            int rowCount = 0;
                            foreach (Row thecurrentrow in thesheetdata)
                            {
                                rowCount++;
                                if (rowCount == 1)
                                {
                                    List<string> FieldNameList = new List<string>();
                                    FieldNameList = new List<string>() { "CSSPID", "Group", "Child", "Hide", "EN", "InitEN", "DescEN", "ReportEN", "TextEN", "FR", "InitFR", "DescFR", "ReportFR", "TextFR" };
                                    int cellcount = 0;
                                    foreach (Cell thecurrentcell in thecurrentrow)
                                    {
                                        string currentcellvalue = string.Empty;
                                        if (thecurrentcell.DataType != null)
                                        {
                                            if (thecurrentcell.DataType == CellValues.SharedString)
                                            {
                                                int id;
                                                if (Int32.TryParse(thecurrentcell.InnerText, out id))
                                                {
                                                    SharedStringItem item = workbookPart.SharedStringTablePart.SharedStringTable.Elements<SharedStringItem>().ElementAt(id);
                                                    if (item.Text != null)
                                                    {
                                                        if ((item.Text.Text + "") != FieldNameList[cellcount])
                                                        {
                                                            sbError.AppendLine($"{ fi.FullName } { PolSourceGroupingExcelFileReadRes.PolSourceGrouping } { item.Text } { PolSourceGroupingExcelFileReadRes.IsNotEqualTo } { FieldNameList[cellcount] }");
                                                            sbError.AppendLine("");
                                                            await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);

                                                            return false;
                                                        }
                                                    }
                                                    else if (item.InnerText != null)
                                                    {
                                                        currentcellvalue = item.InnerText;
                                                        if (currentcellvalue != FieldNameList[cellcount])
                                                        {
                                                            sbError.AppendLine($"{ fi.FullName } { PolSourceGroupingExcelFileReadRes.PolSourceGrouping } { item.Text } { PolSourceGroupingExcelFileReadRes.IsNotEqualTo } { FieldNameList[cellcount] }");
                                                            sbError.AppendLine("");
                                                            await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);

                                                            return false;
                                                        }
                                                    }
                                                    else if (item.InnerXml != null)
                                                    {
                                                        currentcellvalue = item.InnerXml;
                                                        if (currentcellvalue != FieldNameList[cellcount])
                                                        {
                                                            sbError.AppendLine($"{ fi.FullName } { PolSourceGroupingExcelFileReadRes.PolSourceGrouping } { item.Text } { PolSourceGroupingExcelFileReadRes.IsNotEqualTo }  { FieldNameList[cellcount] }");
                                                            sbError.AppendLine("");
                                                            await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);

                                                            return false;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if ((thecurrentcell.InnerText + " ") != FieldNameList[cellcount])
                                            {
                                                sbError.AppendLine($"{ fi.FullName } { PolSourceGroupingExcelFileReadRes.PolSourceGrouping } { (thecurrentcell.InnerText + " ") } { PolSourceGroupingExcelFileReadRes.IsNotEqualTo } { FieldNameList[cellcount] }");
                                                sbError.AppendLine("");
                                                await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);

                                                return false;
                                            }
                                        }

                                        cellcount++;
                                    }
                                }
                                else // rowCount > 1
                                {
                                    int cellCount = 0;
                                    foreach (Cell thecurrentcell in thecurrentrow)
                                    {
                                        string currentcellvalue = string.Empty;
                                        if (thecurrentcell.DataType != null)
                                        {
                                            if (thecurrentcell.DataType == CellValues.SharedString)
                                            {
                                                int id;
                                                if (Int32.TryParse(thecurrentcell.InnerText, out id))
                                                {
                                                    string tempStr = "";
                                                    SharedStringItem item = workbookPart.SharedStringTablePart.SharedStringTable.Elements<SharedStringItem>().ElementAt(id);
                                                    if (item.Text != null)
                                                    {
                                                        tempStr = item.Text.Text;
                                                    }
                                                    else if (item.InnerText != null)
                                                    {
                                                        tempStr = item.InnerText;
                                                    }
                                                    else if (item.InnerXml != null)
                                                    {
                                                        tempStr = item.InnerXml;
                                                    }

                                                    switch (cellCount)
                                                    {
                                                        case 0:
                                                            {
                                                                CSSPID = tempStr.Trim();
                                                            }
                                                            break;
                                                        case 1:
                                                            {
                                                                Group = tempStr.Trim();
                                                                if (string.IsNullOrWhiteSpace(Group))
                                                                {
                                                                    CSSPID = "";
                                                                    Group = "";
                                                                    Choice = "";
                                                                    Child = "";
                                                                    Hide = "";
                                                                    EN = "";
                                                                    InitEN = "";
                                                                    DescEN = "";
                                                                    ReportEN = "";
                                                                    TextEN = "";
                                                                    FR = "";
                                                                    InitFR = "";
                                                                    DescFR = "";
                                                                    ReportFR = "";
                                                                    TextFR = "";
                                                                    continue;
                                                                }
                                                            }
                                                            break;
                                                        case 2:
                                                            {
                                                                Child = tempStr.Trim();
                                                            }
                                                            break;
                                                        case 3:
                                                            {
                                                                Hide = tempStr.Trim();
                                                            }
                                                            break;
                                                        case 4:
                                                            {
                                                                EN = tempStr.Trim();
                                                            }
                                                            break;
                                                        case 5:
                                                            {
                                                                InitEN = tempStr.Trim();
                                                            }
                                                            break;
                                                        case 6:
                                                            {
                                                                DescEN = tempStr.Trim();
                                                            }
                                                            break;
                                                        case 7:
                                                            {
                                                                ReportEN = tempStr.Trim();
                                                            }
                                                            break;
                                                        case 8:
                                                            {
                                                                TextEN = tempStr.Trim();
                                                            }
                                                            break;
                                                        case 9:
                                                            {
                                                                FR = tempStr.Trim();
                                                            }
                                                            break;
                                                        case 10:
                                                            {
                                                                InitFR = tempStr.Trim();
                                                            }
                                                            break;
                                                        case 11:
                                                            {
                                                                DescFR = tempStr.Trim();
                                                            }
                                                            break;
                                                        case 12:
                                                            {
                                                                ReportFR = tempStr.Trim();
                                                            }
                                                            break;
                                                        case 13:
                                                            {
                                                                TextFR = tempStr.Trim();
                                                            }
                                                            break;
                                                        default:
                                                            break;
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            switch (cellCount)
                                            {
                                                case 0:
                                                    {
                                                        CSSPID = thecurrentcell.InnerText.Trim();
                                                    }
                                                    break;
                                                case 1:
                                                    {
                                                        Group = thecurrentcell.InnerText.Trim();
                                                        if (string.IsNullOrWhiteSpace(Group))
                                                        {
                                                            CSSPID = "";
                                                            Group = "";
                                                            Choice = "";
                                                            Child = "";
                                                            Hide = "";
                                                            EN = "";
                                                            InitEN = "";
                                                            DescEN = "";
                                                            ReportEN = "";
                                                            TextEN = "";
                                                            FR = "";
                                                            InitFR = "";
                                                            DescFR = "";
                                                            ReportFR = "";
                                                            TextFR = "";
                                                            continue;
                                                        }
                                                    }
                                                    break;
                                                case 2:
                                                    {
                                                        Child = thecurrentcell.InnerText.Trim();
                                                    }
                                                    break;
                                                case 3:
                                                    {
                                                        Hide = thecurrentcell.InnerText.Trim();
                                                    }
                                                    break;
                                                case 4:
                                                    {
                                                        EN = thecurrentcell.InnerText.Trim();
                                                    }
                                                    break;
                                                case 5:
                                                    {
                                                        InitEN = thecurrentcell.InnerText.Trim();
                                                    }
                                                    break;
                                                case 6:
                                                    {
                                                        DescEN = thecurrentcell.InnerText.Trim();
                                                    }
                                                    break;
                                                case 7:
                                                    {
                                                        ReportEN = thecurrentcell.InnerText.Trim();
                                                    }
                                                    break;
                                                case 8:
                                                    {
                                                        TextEN = thecurrentcell.InnerText.Trim();
                                                    }
                                                    break;
                                                case 9:
                                                    {
                                                        FR = thecurrentcell.InnerText.Trim();
                                                    }
                                                    break;
                                                case 10:
                                                    {
                                                        InitFR = thecurrentcell.InnerText.Trim();
                                                    }
                                                    break;
                                                case 11:
                                                    {
                                                        DescFR = thecurrentcell.InnerText.Trim();
                                                    }
                                                    break;
                                                case 12:
                                                    {
                                                        ReportFR = thecurrentcell.InnerText.Trim();
                                                    }
                                                    break;
                                                case 13:
                                                    {
                                                        TextFR = thecurrentcell.InnerText.Trim();
                                                    }
                                                    break;
                                                default:
                                                    break;
                                            }
                                        }
                                        cellCount++;
                                    }

                                    if (rowCount % 200 == 0)
                                    {
                                        sbStatus.AppendLine($"{ PolSourceGroupingExcelFileReadRes.ReadingSpreadsheet } ... { rowCount }");
                                        sbStatus.AppendLine("");
                                        await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);
                                    }

                                    if (!string.IsNullOrWhiteSpace(CSSPID))
                                    {
                                        groupChoiceChildLevelStraitList.Add(new GroupChoiceChildLevel()
                                        {
                                            CSSPID = CSSPID,
                                            Group = Group,
                                            Choice = Choice,
                                            Child = Child,
                                            Hide = Hide,
                                            EN = EN,
                                            InitEN = InitEN,
                                            DescEN = DescEN,
                                            ReportEN = ReportEN,
                                            TextEN = TextEN,
                                            FR = FR,
                                            InitFR = InitFR,
                                            DescFR = DescFR,
                                            ReportFR = ReportFR,
                                            TextFR = TextFR,
                                        });
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                sbError.AppendLine($"{ ex.Message }");
                sbError.AppendLine("");
                await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);

                return false;
            }

            List<GroupChoiceChildLevel> groupChoiceChildLevelOrderedList = (from c in groupChoiceChildLevelStraitList
                                                                            orderby c.Group
                                                                            select c).ToList();

            for (int i = 0, count = groupChoiceChildLevelOrderedList.Count; i < (count - 1); i++)
            {
                if (i % 200 == 0)
                {
                    sbStatus.AppendLine($"{ PolSourceGroupingExcelFileReadRes.Checking } ... { PolSourceGroupingExcelFileReadRes.ThatGroup } { groupChoiceChildLevelOrderedList[i].Group } ---- { PolSourceGroupingExcelFileReadRes.HasNoDuplicates }");
                    sbStatus.AppendLine("");
                    await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);
                }

                if (groupChoiceChildLevelOrderedList[i].Group == groupChoiceChildLevelOrderedList[i + 1].Group)
                {
                    sbError.AppendLine($"{ groupChoiceChildLevelOrderedList[i].Group } ---- { PolSourceGroupingExcelFileReadRes.HasDuplicates }");
                    sbError.AppendLine("");
                    await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);

                    return false;
                }
            }

            sbStatus.AppendLine($"{ PolSourceGroupingExcelFileReadRes.ColumnGroupDoesNotHaveDuplicates }.");
            sbStatus.AppendLine("");
            await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);

            for (int i = 0, count = groupChoiceChildLevelOrderedList.Count; i < count; i++)
            {
                if (!string.IsNullOrWhiteSpace(groupChoiceChildLevelOrderedList[i].Group))
                {
                    if (i % 200 == 0)
                    {
                        sbStatus.AppendLine($"{ PolSourceGroupingExcelFileReadRes.Checking } ... { PolSourceGroupingExcelFileReadRes.ThatGroup } { groupChoiceChildLevelOrderedList[i].Group } ---- { PolSourceGroupingExcelFileReadRes.ShouldNotContainSpace }");
                        sbStatus.AppendLine("");
                        await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);
                    }

                    if (groupChoiceChildLevelOrderedList[i].Group.Contains(" "))
                    {
                        sbError.AppendLine($"{ PolSourceGroupingExcelFileReadRes.Group} --- { groupChoiceChildLevelOrderedList[i].Group } ---- { PolSourceGroupingExcelFileReadRes.ShouldNotContainSpace}");
                        sbError.AppendLine("");
                        await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);

                        return false;
                    }
                }
                if (!string.IsNullOrWhiteSpace(groupChoiceChildLevelOrderedList[i].Child))
                {
                    if (i % 200 == 0)
                    {
                        sbStatus.AppendLine($"{ PolSourceGroupingExcelFileReadRes.Checking} ... { PolSourceGroupingExcelFileReadRes.ThatGroup} { groupChoiceChildLevelOrderedList[i].Child } ---- { PolSourceGroupingExcelFileReadRes.ShouldNotContainSpace}");
                        sbStatus.AppendLine("");
                        await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);
                    }

                    if (groupChoiceChildLevelOrderedList[i].Child.Contains(" "))
                    {
                        sbError.AppendLine($"{ PolSourceGroupingExcelFileReadRes.Child } --- { groupChoiceChildLevelOrderedList[i].Child } ---- { PolSourceGroupingExcelFileReadRes.ShouldNotContainSpace }");
                        sbError.AppendLine("");
                        await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);

                        return false;
                    }
                }

            }

            sbStatus.AppendLine($"{ PolSourceGroupingExcelFileReadRes.AllTextInGroupAndChildColumnsDoesNotContainSpace }.");
            sbStatus.AppendLine("");
            await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);

            string AllowableChar = "abcdefghijklmnopqrstuvwxyz_ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";

            for (int i = 0, count = groupChoiceChildLevelOrderedList.Count; i < count; i++)
            {
                if (i % 200 == 0)
                {
                    sbStatus.AppendLine($"{ PolSourceGroupingExcelFileReadRes.Checking} ... { PolSourceGroupingExcelFileReadRes.ThatGroup} { groupChoiceChildLevelOrderedList[i].Group } ---- { PolSourceGroupingExcelFileReadRes.ShouldOnlyContainCharactersLike } [{ AllowableChar }]");
                    sbStatus.AppendLine("");
                    await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);
                }

                foreach (char c in groupChoiceChildLevelOrderedList[i].Group)
                {
                    if (!AllowableChar.Contains(c))
                    {
                        sbError.AppendLine($"{ PolSourceGroupingExcelFileReadRes.Group} --- { groupChoiceChildLevelOrderedList[i].Group } ---- { PolSourceGroupingExcelFileReadRes.ShouldNotContain } [{ c }]. { PolSourceGroupingExcelFileReadRes.AllowableCharactersAre } [{ AllowableChar }]");
                        sbError.AppendLine("");
                        await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);

                        return false;
                    }
                }
                foreach (char c in groupChoiceChildLevelOrderedList[i].Child)
                {
                    if (i % 200 == 0)
                    {
                        sbStatus.AppendLine($"{ PolSourceGroupingExcelFileReadRes.Checking} ... { PolSourceGroupingExcelFileReadRes.ThatGroup } { groupChoiceChildLevelOrderedList[i].Child } ---- { PolSourceGroupingExcelFileReadRes.ShouldOnlyContainCharactersLike } [{ AllowableChar }]");
                        sbStatus.AppendLine("");
                        await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);
                    }

                    if (!AllowableChar.Contains(c))
                    {
                        sbError.AppendLine($"{ PolSourceGroupingExcelFileReadRes.Child } --- { groupChoiceChildLevelOrderedList[i].Child } ---- { PolSourceGroupingExcelFileReadRes.ShouldNotContain} [{ c }]. { PolSourceGroupingExcelFileReadRes.AllowableCharactersAre } [{ AllowableChar }]");
                        sbError.AppendLine("");
                        await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);

                        return false;
                    }
                }
            }

            sbStatus.AppendLine($"{ PolSourceGroupingExcelFileReadRes.AllTextInGroupAndChildColumnsDoesNotContainSpace }.");
            sbStatus.AppendLine("");
            await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);

            for (int i = 0, count = groupChoiceChildLevelOrderedList.Count; i < count; i++)
            {
                if (!string.IsNullOrWhiteSpace(groupChoiceChildLevelOrderedList[i].Group))
                {
                    if (i % 200 == 0)
                    {
                        sbStatus.AppendLine($"{ PolSourceGroupingExcelFileReadRes.Checking} ... { PolSourceGroupingExcelFileReadRes.ThatCSSPID } { groupChoiceChildLevelOrderedList[i].Group } ---- { PolSourceGroupingExcelFileReadRes.DoesNotContainSpace }");
                        sbStatus.AppendLine("");
                        await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);
                    }

                    if (groupChoiceChildLevelOrderedList[i].CSSPID.Contains(" "))
                    {
                        sbError.AppendLine($"{ PolSourceGroupingExcelFileReadRes.CSSPID } --- { groupChoiceChildLevelOrderedList[i].Group } ---- { PolSourceGroupingExcelFileReadRes.ShouldNotContainSpace }");
                        sbError.AppendLine("");
                        await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);

                        return false;
                    }
                }
                if (!string.IsNullOrWhiteSpace(groupChoiceChildLevelOrderedList[i].Child))
                {
                    if (i % 200 == 0)
                    {
                        sbStatus.AppendLine($"{ PolSourceGroupingExcelFileReadRes.Checking} ... { PolSourceGroupingExcelFileReadRes.ThatCSSPID } { groupChoiceChildLevelOrderedList[i].Child } ---- { PolSourceGroupingExcelFileReadRes.DoesNotContainSpace }");
                        sbStatus.AppendLine("");
                        await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);
                    }

                    if (groupChoiceChildLevelOrderedList[i].CSSPID.Contains(" "))
                    {
                        sbError.AppendLine($"{ PolSourceGroupingExcelFileReadRes.CSSPID } --- { groupChoiceChildLevelOrderedList[i].Child } ---- { PolSourceGroupingExcelFileReadRes.ShouldNotContainSpace }");
                        sbError.AppendLine("");
                        await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);

                        return false;
                    }
                }

            }

            sbStatus.AppendLine($"{ PolSourceGroupingExcelFileReadRes.AllTextInCSSPIDColumnDoesNotContainSpace }.");
            sbStatus.AppendLine("");
            await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);

            List<string> UniqueCSSPIDList = new List<string>();
            for (int i = 0, count = groupChoiceChildLevelOrderedList.Count; i < count; i++)
            {
                if (!string.IsNullOrWhiteSpace(groupChoiceChildLevelOrderedList[i].Group))
                {
                    if (i % 200 == 0)
                    {
                        sbStatus.AppendLine($"{ PolSourceGroupingExcelFileReadRes.Checking} ... { PolSourceGroupingExcelFileReadRes.ThatGroupCSSPID } { groupChoiceChildLevelOrderedList[i].Group } ---- { PolSourceGroupingExcelFileReadRes.IsUnique }.");
                        sbStatus.AppendLine("");
                        await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);
                    }

                    if (string.IsNullOrWhiteSpace(groupChoiceChildLevelOrderedList[i].CSSPID))
                    {
                        sbError.AppendLine($"{ PolSourceGroupingExcelFileReadRes.Group} --- { groupChoiceChildLevelOrderedList[i].Group } ---- { PolSourceGroupingExcelFileReadRes.RequiredAUniqueNumberInFirstColumn }.");
                        sbError.AppendLine("");
                        await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);

                        return false;
                    }
                }
                if (!string.IsNullOrWhiteSpace(groupChoiceChildLevelOrderedList[i].Child))
                {
                    if (i % 200 == 0)
                    {
                        sbStatus.AppendLine($"{ PolSourceGroupingExcelFileReadRes.Checking} ... { PolSourceGroupingExcelFileReadRes.ThatGroupCSSPID } { groupChoiceChildLevelOrderedList[i].Child } ---- { PolSourceGroupingExcelFileReadRes.IsUnique }.");
                        sbStatus.AppendLine("");
                        await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);
                    }

                    if (string.IsNullOrWhiteSpace(groupChoiceChildLevelOrderedList[i].CSSPID))
                    {
                        sbError.AppendLine($"{ PolSourceGroupingExcelFileReadRes.Child } --- { groupChoiceChildLevelOrderedList[i].Child } ---- { PolSourceGroupingExcelFileReadRes.RequiredAUniqueNumberInFirstColumn }");
                        sbError.AppendLine("");
                        await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);

                        return false;
                    }
                }

                if (i % 200 == 0)
                {
                    sbStatus.AppendLine($"{ PolSourceGroupingExcelFileReadRes.Checking} ... { PolSourceGroupingExcelFileReadRes.ThatCSSPID } { groupChoiceChildLevelOrderedList[i].Child } ---- { PolSourceGroupingExcelFileReadRes.IsNotEmpty }.");
                    sbStatus.AppendLine("");
                    await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);
                }

                if (string.IsNullOrWhiteSpace(groupChoiceChildLevelOrderedList[i].CSSPID))
                {
                    sbError.AppendLine($"{ PolSourceGroupingExcelFileReadRes.CSSPIDIsRequiredForGroupOrChild } [{ (groupChoiceChildLevelOrderedList[i].Choice.Length > 0 ? groupChoiceChildLevelOrderedList[i].Choice : groupChoiceChildLevelOrderedList[i].Group) }]");
                    sbError.AppendLine("");
                    await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);

                    return false;
                }

                sbStatus.AppendLine($"{ PolSourceGroupingExcelFileReadRes.Checking } ... { PolSourceGroupingExcelFileReadRes.ThatCSSPID } { groupChoiceChildLevelOrderedList[i].Child } ---- { PolSourceGroupingExcelFileReadRes.IsUnique }.");
                sbStatus.AppendLine("");
                await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);

                if (UniqueCSSPIDList.Contains(groupChoiceChildLevelOrderedList[i].CSSPID))
                {
                    sbError.AppendLine($"{ PolSourceGroupingExcelFileReadRes.CSSPID } [{ groupChoiceChildLevelOrderedList[i].CSSPID }] { PolSourceGroupingExcelFileReadRes.IsNotUnique }");
                    sbError.AppendLine("");
                    await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);

                    return false;
                }

                UniqueCSSPIDList.Add(groupChoiceChildLevelOrderedList[i].CSSPID);

                if (i % 200 == 0)
                {
                    sbStatus.AppendLine($"{ PolSourceGroupingExcelFileReadRes.Checking } ... { PolSourceGroupingExcelFileReadRes.ThatEachHideCellWithInformationContainsValidChildID }, { PolSourceGroupingExcelFileReadRes.CSSPIDAreNotDupliate }, { PolSourceGroupingExcelFileReadRes.CSSPIDWithDashAreWellFormed }.");
                    sbStatus.AppendLine("");
                    await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);
                }

                if (!groupChoiceChildLevelOrderedList[i].CSSPID.EndsWith("00"))
                {
                    if (groupChoiceChildLevelOrderedList[i].Hide.Trim().Length != 0)
                    {
                        List<string> CSSPIDList2 = new List<string>();
                        List<string> CSSPIDList = groupChoiceChildLevelOrderedList[i].Hide.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(c => c.Trim()).ToList();
                        foreach (string childCSSPID in CSSPIDList)
                        {
                            int fromCSSPID = -1;
                            int toCSSPID = -1;
                            if (childCSSPID.Contains("-"))
                            {
                                List<string> stringList = childCSSPID.Split("-".ToCharArray(), StringSplitOptions.None).ToList();
                                if (stringList.Count > 2)
                                {
                                    sbError.AppendLine($"{ PolSourceGroupingExcelFileReadRes.CSSPID } [{ groupChoiceChildLevelOrderedList[i].CSSPID }] { PolSourceGroupingExcelFileReadRes.HideCellContains } [{ childCSSPID }] { PolSourceGroupingExcelFileReadRes.PleaseRemoveADash }");
                                    sbError.AppendLine("");
                                    await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);

                                    return false;
                                }

                                foreach (char s in childCSSPID)
                                {
                                    if (!NumberAndDashOnlyList.Contains(s.ToString()))
                                    {
                                        sbError.AppendLine($"{ PolSourceGroupingExcelFileReadRes.CSSPID} [{ groupChoiceChildLevelOrderedList[i].CSSPID }] { PolSourceGroupingExcelFileReadRes.HideCellContains } [{ childCSSPID }]. { PolSourceGroupingExcelFileReadRes.AllowableCharactersAre } [{ String.Join(",", NumberAndDashOnlyList) }]");
                                        sbError.AppendLine("");
                                        await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);

                                        return false;
                                    }
                                }

                                fromCSSPID = int.Parse(childCSSPID.Substring(0, childCSSPID.IndexOf("-")));
                                int endPos = childCSSPID.IndexOf("-") + 1;
                                if (childCSSPID.Length <= endPos)
                                {
                                    sbError.AppendLine($"{ PolSourceGroupingExcelFileReadRes.CSSPID } [{ groupChoiceChildLevelOrderedList[i].CSSPID }] { PolSourceGroupingExcelFileReadRes.HideCellContains } [{ childCSSPID }] { PolSourceGroupingExcelFileReadRes.MissingEndValue }");
                                    sbError.AppendLine("");
                                    await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);

                                    return false;
                                }

                                toCSSPID = int.Parse(childCSSPID.Substring(endPos));

                                if (fromCSSPID >= toCSSPID)
                                {
                                    sbError.AppendLine($"{ PolSourceGroupingExcelFileReadRes.CSSPID } [{ groupChoiceChildLevelOrderedList[i].CSSPID }] { PolSourceGroupingExcelFileReadRes.HideCellContains } [{ childCSSPID }] { PolSourceGroupingExcelFileReadRes.WhichTheFirstValueIs } >= { PolSourceGroupingExcelFileReadRes.ThanTheLastValue }");
                                    sbError.AppendLine("");
                                    await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);

                                    return false;
                                }
                            }

                            if (fromCSSPID != -1)
                            {
                                for (int id = fromCSSPID; id <= toCSSPID; id++)
                                {
                                    if (CSSPIDList2.Contains(id.ToString()) || CSSPIDList.Contains(id.ToString()))
                                    {
                                        sbError.AppendLine($"{ PolSourceGroupingExcelFileReadRes.CSSPID } [{ groupChoiceChildLevelOrderedList[i].CSSPID }] { PolSourceGroupingExcelFileReadRes.HideCellContains } [{ childCSSPID }] { PolSourceGroupingExcelFileReadRes.WhichWillDuplicate } [{ id.ToString() }]");
                                        sbError.AppendLine("");
                                        await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);

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

                        CSSPIDList = CSSPIDList.Where(c => !c.Contains("-")).ToList();

                        string oldCSSPID = "";
                        foreach (string csspID in CSSPIDList.OrderBy(c => c))
                        {
                            if (oldCSSPID == csspID)
                            {
                                sbError.AppendLine($"{ PolSourceGroupingExcelFileReadRes.CSSPID } [{ groupChoiceChildLevelOrderedList[i].CSSPID }] { PolSourceGroupingExcelFileReadRes.HideCellHasDuplicate } [{ csspID }]");
                                sbError.AppendLine("");
                                await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);

                                return false;
                            }
                            oldCSSPID = csspID;
                        }
                        foreach (string childCSSPID in CSSPIDList)
                        {
                            GroupChoiceChildLevel groupChoiceChildLevelChild = groupChoiceChildLevelOrderedList.Where(c => c.CSSPID == childCSSPID).FirstOrDefault();
                            if (groupChoiceChildLevelChild == null)
                            {
                                sbError.AppendLine($"{ PolSourceGroupingExcelFileReadRes.CSSPID } [{ groupChoiceChildLevelOrderedList[i].CSSPID }] { PolSourceGroupingExcelFileReadRes.HideCellContainsID } [{ childCSSPID.ToString() }] { PolSourceGroupingExcelFileReadRes.WhichDoesNotExist }");
                                sbError.AppendLine("");
                                await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);

                                return false;
                            }
                            string startCSSPID = $"{ childCSSPID.Substring(0, 3) }00";

                            GroupChoiceChildLevel groupChoiceChildLevel = groupChoiceChildLevelOrderedList.Where(c => c.CSSPID == startCSSPID).FirstOrDefault();

                            if (groupChoiceChildLevel == null)
                            {
                                sbError.AppendLine($"{ PolSourceGroupingExcelFileReadRes.CSSPID } [{ groupChoiceChildLevelOrderedList[i].CSSPID }] { PolSourceGroupingExcelFileReadRes.GroupChoiceChildLevelIsNullForStartCSSPID } [{ startCSSPID.ToString() }]");
                                sbError.AppendLine("");
                                await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);

                                return false;
                            }

                            string group = groupChoiceChildLevel.Group;
                            if (groupChoiceChildLevelOrderedList[i].Child != group)
                            {
                                sbError.AppendLine($"{ PolSourceGroupingExcelFileReadRes.CSSPID } [{ groupChoiceChildLevelOrderedList[i].CSSPID }] { PolSourceGroupingExcelFileReadRes.HideCellContainsID } [{ childCSSPID.ToString() }] { PolSourceGroupingExcelFileReadRes.WhichIsNotADirectChild }");
                                sbError.AppendLine("");
                                await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);

                                return false;
                            }
                        }
                        if (CSSPIDList.Count > 0)
                        {
                            string childCSSPID = CSSPIDList[0];

                            GroupChoiceChildLevel groupChoiceChildLevelChild = groupChoiceChildLevelOrderedList.Where(c => c.CSSPID == childCSSPID).FirstOrDefault();
                            if (groupChoiceChildLevelChild == null)
                            {
                                sbError.AppendLine($"{ PolSourceGroupingExcelFileReadRes.CSSPID } [{ groupChoiceChildLevelOrderedList[i].CSSPID }] { PolSourceGroupingExcelFileReadRes.HideCellContainsID } [{ childCSSPID.ToString() }] { PolSourceGroupingExcelFileReadRes.WhichDoesNotExist}");
                                sbError.AppendLine("");
                                await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);

                                return false;
                            }
                            string start3CharCSSPID = $"{ childCSSPID.Substring(0, 3) }";

                            int CountChild = groupChoiceChildLevelOrderedList.Where(c => c.CSSPID.StartsWith(start3CharCSSPID) && !c.CSSPID.EndsWith("00")).Count();

                            if (CSSPIDList.Count == CountChild)
                            {
                                sbError.AppendLine($"{ PolSourceGroupingExcelFileReadRes.CSSPID } [{ groupChoiceChildLevelOrderedList[i].CSSPID }] { PolSourceGroupingExcelFileReadRes.IsHidingAllPossibleSelection }");
                                sbError.AppendLine("");
                                await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);

                                return false;

                            }
                        }
                    }
                }
            }

            sbStatus.AppendLine($"{ PolSourceGroupingExcelFileReadRes.AllGroupsAndChoicesColumnsHaveAUniqueCSSPID }.");
            sbStatus.AppendLine("");

            sbStatus.AppendLine($"{ PolSourceGroupingExcelFileReadRes.AllHideColumnsWithInformationHasValidCSSPIDIEExistAndIsChild }.");
            sbStatus.AppendLine("");

            sbStatus.AppendLine($"{ PolSourceGroupingExcelFileReadRes.EverythingIsOK }.");
            sbStatus.AppendLine("");
            await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);

            return true;
        }
        private async Task<bool> ReadExcelFile(StringBuilder sbError, StringBuilder sbStatus, string command, IStatusAndResultsService statusAndResultsService)
        {
            groupChoiceChildLevelList = new List<GroupChoiceChildLevel>();

            sbStatus.AppendLine($"{ PolSourceGroupingExcelFileReadRes.ReadingSpreadsheet } [{ FullFileName }]");
            sbStatus.AppendLine("");
            await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);

            FileInfo fi = new FileInfo(FullFileName);

            try
            {
                //Lets open the existing excel file and read through its content . Open the excel using openxml sdk
                using (SpreadsheetDocument doc = SpreadsheetDocument.Open(fi.FullName, false))
                {
                    //create the object for workbook part  
                    WorkbookPart workbookPart = doc.WorkbookPart;
                    Sheets thesheetcollection = workbookPart.Workbook.GetFirstChild<Sheets>();
                    //StringBuilder sb = new StringBuilder();

                    //using for each loop to get the sheet from the sheetcollection  
                    foreach (Sheet thesheet in thesheetcollection)
                    {
                        if (thesheet.Name == "PolsourceGrouping")
                        {
                            string CSSPID = "";
                            string Group = "";
                            string Choice = "";
                            string Child = "";
                            string Hide = "";
                            string EN = "";
                            string InitEN = "";
                            string DescEN = "";
                            string ReportEN = "";
                            string TextEN = "";
                            string FR = "";
                            string InitFR = "";
                            string DescFR = "";
                            string ReportFR = "";
                            string TextFR = "";

                            Worksheet theWorksheet = ((WorksheetPart)workbookPart.GetPartById(thesheet.Id)).Worksheet;

                            SheetData thesheetdata = (SheetData)theWorksheet.GetFirstChild<SheetData>();
                            int rowCount = 0;
                            foreach (Row thecurrentrow in thesheetdata)
                            {
                                rowCount++;
                                if (rowCount == 1)
                                {
                                    List<string> FieldNameList = new List<string>();
                                    FieldNameList = new List<string>() { "CSSPID", "Group", "Child", "Hide", "EN", "InitEN", "DescEN", "ReportEN", "TextEN", "FR", "InitFR", "DescFR", "ReportFR", "TextFR" };
                                    int cellcount = 0;
                                    foreach (Cell thecurrentcell in thecurrentrow)
                                    {
                                        string currentcellvalue = string.Empty;
                                        if (thecurrentcell.DataType != null)
                                        {
                                            if (thecurrentcell.DataType == CellValues.SharedString)
                                            {
                                                int id;
                                                if (Int32.TryParse(thecurrentcell.InnerText, out id))
                                                {
                                                    SharedStringItem item = workbookPart.SharedStringTablePart.SharedStringTable.Elements<SharedStringItem>().ElementAt(id);
                                                    if (item.Text != null)
                                                    {
                                                        if ((item.Text.Text + "") != FieldNameList[cellcount])
                                                        {
                                                            sbError.AppendLine($"{ fi.FullName } { PolSourceGroupingExcelFileReadRes.PolSourceGrouping } { item.Text } { PolSourceGroupingExcelFileReadRes.IsNotEqualTo } { FieldNameList[cellcount] }");
                                                            sbError.AppendLine("");
                                                            await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);

                                                            return false;
                                                        }
                                                    }
                                                    else if (item.InnerText != null)
                                                    {
                                                        currentcellvalue = item.InnerText;
                                                        if (currentcellvalue != FieldNameList[cellcount])
                                                        {
                                                            sbError.AppendLine($"{ fi.FullName } { PolSourceGroupingExcelFileReadRes.PolSourceGrouping } { item.Text } { PolSourceGroupingExcelFileReadRes.IsNotEqualTo } { FieldNameList[cellcount] }");
                                                            sbError.AppendLine("");
                                                            await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);

                                                            return false;
                                                        }
                                                    }
                                                    else if (item.InnerXml != null)
                                                    {
                                                        currentcellvalue = item.InnerXml;
                                                        if (currentcellvalue != FieldNameList[cellcount])
                                                        {
                                                            sbError.AppendLine($"{ fi.FullName } { PolSourceGroupingExcelFileReadRes.PolSourceGrouping } { item.Text } { PolSourceGroupingExcelFileReadRes.IsNotEqualTo } { FieldNameList[cellcount] }");
                                                            sbError.AppendLine("");
                                                            await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);

                                                            return false;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if ((thecurrentcell.InnerText + " ") != FieldNameList[cellcount])
                                            {
                                                sbError.AppendLine($"{ fi.FullName } { PolSourceGroupingExcelFileReadRes.PolSourceGrouping } { (thecurrentcell.InnerText + " ") } { PolSourceGroupingExcelFileReadRes.IsNotEqualTo } { FieldNameList[cellcount] }");
                                                sbError.AppendLine("");
                                                await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);

                                                return false;
                                            }
                                        }

                                        cellcount++;
                                    }
                                }
                                else // rowCount > 1
                                {
                                    int cellCount = 0;
                                    foreach (Cell thecurrentcell in thecurrentrow)
                                    {
                                        string currentcellvalue = string.Empty;
                                        if (thecurrentcell.DataType != null)
                                        {
                                            if (thecurrentcell.DataType == CellValues.SharedString)
                                            {
                                                int id;
                                                if (Int32.TryParse(thecurrentcell.InnerText, out id))
                                                {
                                                    string tempStr = "";
                                                    SharedStringItem item = workbookPart.SharedStringTablePart.SharedStringTable.Elements<SharedStringItem>().ElementAt(id);
                                                    if (item.Text != null)
                                                    {
                                                        tempStr = item.Text.Text;
                                                    }
                                                    else if (item.InnerText != null)
                                                    {
                                                        tempStr = item.InnerText;
                                                    }
                                                    else if (item.InnerXml != null)
                                                    {
                                                        tempStr = item.InnerXml;
                                                    }

                                                    switch (cellCount)
                                                    {
                                                        case 0:
                                                            {
                                                                CSSPID = tempStr.Trim();
                                                            }
                                                            break;
                                                        case 1:
                                                            {
                                                                Group = tempStr.Trim();
                                                                if (string.IsNullOrWhiteSpace(Group))
                                                                {
                                                                    CSSPID = "";
                                                                    Group = "";
                                                                    Choice = "";
                                                                    Child = "";
                                                                    Hide = "";
                                                                    EN = "";
                                                                    InitEN = "";
                                                                    DescEN = "";
                                                                    ReportEN = "";
                                                                    TextEN = "";
                                                                    FR = "";
                                                                    InitFR = "";
                                                                    DescFR = "";
                                                                    ReportFR = "";
                                                                    TextFR = "";
                                                                    continue;
                                                                }
                                                                else
                                                                {
                                                                }
                                                            }
                                                            break;
                                                        case 2:
                                                            {
                                                                Child = tempStr;
                                                            }
                                                            break;
                                                        case 3:
                                                            {
                                                                Hide = tempStr;
                                                            }
                                                            break;
                                                        case 4:
                                                            {
                                                                EN = tempStr;
                                                            }
                                                            break;
                                                        case 5:
                                                            {
                                                                InitEN = tempStr;
                                                            }
                                                            break;
                                                        case 6:
                                                            {
                                                                DescEN = tempStr;
                                                            }
                                                            break;
                                                        case 7:
                                                            {
                                                                ReportEN = tempStr;
                                                            }
                                                            break;
                                                        case 8:
                                                            {
                                                                TextEN = tempStr;
                                                            }
                                                            break;
                                                        case 9:
                                                            {
                                                                FR = tempStr;
                                                            }
                                                            break;
                                                        case 10:
                                                            {
                                                                InitFR = tempStr;
                                                            }
                                                            break;
                                                        case 11:
                                                            {
                                                                DescFR = tempStr;
                                                            }
                                                            break;
                                                        case 12:
                                                            {
                                                                ReportFR = tempStr;
                                                            }
                                                            break;
                                                        case 13:
                                                            {
                                                                TextFR = tempStr;
                                                            }
                                                            break;
                                                        default:
                                                            break;
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            switch (cellCount)
                                            {
                                                case 0:
                                                    {
                                                        CSSPID = thecurrentcell.InnerText.Trim();
                                                        if (CSSPID == "16800")
                                                        {
                                                            int slifej = 34;
                                                        }
                                                    }
                                                    break;
                                                case 1:
                                                    {
                                                        Group = thecurrentcell.InnerText.Trim();
                                                        if (string.IsNullOrWhiteSpace(Group))
                                                        {
                                                            CSSPID = "";
                                                            Group = "";
                                                            Choice = "";
                                                            Child = "";
                                                            Hide = "";
                                                            EN = "";
                                                            InitEN = "";
                                                            DescEN = "";
                                                            ReportEN = "";
                                                            TextEN = "";
                                                            FR = "";
                                                            InitFR = "";
                                                            DescFR = "";
                                                            ReportFR = "";
                                                            TextFR = "";
                                                            continue;
                                                        }
                                                    }
                                                    break;
                                                case 2:
                                                    {
                                                        Child = thecurrentcell.InnerText;
                                                    }
                                                    break;
                                                case 3:
                                                    {
                                                        Hide = thecurrentcell.InnerText;
                                                    }
                                                    break;
                                                case 4:
                                                    {
                                                        EN = thecurrentcell.InnerText;
                                                    }
                                                    break;
                                                case 5:
                                                    {
                                                        InitEN = thecurrentcell.InnerText;
                                                    }
                                                    break;
                                                case 6:
                                                    {
                                                        DescEN = thecurrentcell.InnerText;
                                                    }
                                                    break;
                                                case 7:
                                                    {
                                                        ReportEN = thecurrentcell.InnerText;
                                                    }
                                                    break;
                                                case 8:
                                                    {
                                                        TextEN = thecurrentcell.InnerText;
                                                    }
                                                    break;
                                                case 9:
                                                    {
                                                        FR = thecurrentcell.InnerText;
                                                    }
                                                    break;
                                                case 10:
                                                    {
                                                        InitFR = thecurrentcell.InnerText;
                                                    }
                                                    break;
                                                case 11:
                                                    {
                                                        DescFR = thecurrentcell.InnerText;
                                                    }
                                                    break;
                                                case 12:
                                                    {
                                                        ReportFR = thecurrentcell.InnerText;
                                                    }
                                                    break;
                                                case 13:
                                                    {
                                                        TextFR = thecurrentcell.InnerText;
                                                    }
                                                    break;
                                                default:
                                                    break;
                                            }
                                        }
                                        cellCount++;
                                    }

                                    if (!string.IsNullOrWhiteSpace(Group))
                                    {
                                        if (Group.Substring(Group.Length - 5) == "Start")
                                        {
                                            Choice = "";
                                            Child = "";
                                            Hide = "";
                                        }
                                        else
                                        {
                                            Choice = Group;
                                        }
                                    }


                                    if (rowCount % 200 == 0)
                                    {
                                        sbStatus.AppendLine($"{ PolSourceGroupingExcelFileReadRes.ReadingSpreadsheet } ... { rowCount }");
                                        sbStatus.AppendLine("");
                                        await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);
                                    }

                                    if (!string.IsNullOrWhiteSpace(CSSPID))
                                    {
                                        groupChoiceChildLevelList.Add(new GroupChoiceChildLevel()
                                        {
                                            CSSPID = CSSPID,
                                            Group = Group,
                                            Choice = Choice,
                                            Child = Child,
                                            Hide = Hide,
                                            EN = EN,
                                            InitEN = InitEN,
                                            DescEN = DescEN,
                                            ReportEN = ReportEN,
                                            TextEN = TextEN,
                                            FR = FR,
                                            InitFR = InitFR,
                                            DescFR = DescFR,
                                            ReportFR = ReportFR,
                                            TextFR = TextFR,
                                        });
                                    }

                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                sbError.AppendLine($"{ ex.Message }");
                sbError.AppendLine("");
                await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);

                return false;
            }


            int Level = 0;
            List<string> textList = new List<string>();
            StringBuilder sb = new StringBuilder();
            if (! await GetRecursiveForShowAllPaths("Start", textList, Level, false, sb, sbError, sbStatus, command, statusAndResultsService))
            {
                return false;
            }

            return true;

        }
        #endregion Functions private
    }
}
