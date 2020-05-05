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
using GenerateCodeStatusDB.Services;

namespace PolSourceGroupingExcelFileReadServices.Services
{
    public class PolSourceGroupingExcelFileReadService : IPolSourceGroupingExcelFileReadService
    {
        #region Variables
        private string FullFileName;
        List<string> NumberAndDashOnlyList = new List<string>() { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "-" };
        #endregion Variables

        #region Properties
        private IGenerateCodeStatusDBService generateCodeStatusDBService { get; set; }
        public List<GroupChoiceChildLevel> groupChoiceChildLevelList { get; set; }
        #endregion Properties

        #region Constructors
        public PolSourceGroupingExcelFileReadService(IGenerateCodeStatusDBService generateCodeStatusDBService)
        {
            this.generateCodeStatusDBService = generateCodeStatusDBService;
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
                            generateCodeStatusDBService.Error.AppendLine($"CSSPID [{ groupChoiceChildLevel.CSSPID }] { PolSourceGroupingExcelFileReadServicesRes.HideCellContains } [{ childCSSPID }] { PolSourceGroupingExcelFileReadServicesRes.MissingEndValue }");
                            await generateCodeStatusDBService.Update(0);
                            return false;
                        }

                        toCSSPID = int.Parse(childCSSPID.Substring(childCSSPID.IndexOf("-") + 1));

                        if (fromCSSPID >= toCSSPID)
                        {
                            generateCodeStatusDBService.Error.AppendLine($"CSSPID [{ groupChoiceChildLevel.CSSPID }] { PolSourceGroupingExcelFileReadServicesRes.HideCellContains } [{ childCSSPID }] { PolSourceGroupingExcelFileReadServicesRes.WhichTheFirstValueIs }  >= { PolSourceGroupingExcelFileReadServicesRes.ThanTheLastValue }");
                            await generateCodeStatusDBService.Update(0);
                            return false;
                        }
                    }

                    if (fromCSSPID != -1)
                    {
                        for (int id = fromCSSPID; id <= toCSSPID; id++)
                        {
                            if (CSSPIDList2.Contains(id.ToString()) || CSSPIDList.Contains(id.ToString()))
                            {
                                generateCodeStatusDBService.Error.AppendLine($"CSSPID [{ groupChoiceChildLevel.CSSPID }] { PolSourceGroupingExcelFileReadServicesRes.HideCellContains } [{ childCSSPID }] { PolSourceGroupingExcelFileReadServicesRes.WhichWillDuplicate } [{ id.ToString() }]");
                                await generateCodeStatusDBService.Update(0);
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

            generateCodeStatusDBService.Status.AppendLine($"{ PolSourceGroupingExcelFileReadServicesRes.ExcelDocReadCompleted } ... ");
            //await generateCodeStatusDBService.Update( 0);

            return true;
        }
        public async Task<bool> GetRecursiveForShowAllPaths(string s, List<string> textList, int Level, bool RaiseEvents, StringBuilder sb)
        {
            textList.RemoveRange(Level, (textList.Count - Level));

            if (textList.Contains(s))
            {
                generateCodeStatusDBService.Error.AppendLine($"{ PolSourceGroupingExcelFileReadServicesRes.RecursiveFound } ...");
                generateCodeStatusDBService.Error.AppendLine("");
                await generateCodeStatusDBService.Update(0);
                foreach (string sp in textList)
                {
                    generateCodeStatusDBService.Error.AppendLine($"{ sp }");
                    await generateCodeStatusDBService.Update(0);
                }
                generateCodeStatusDBService.Error.AppendLine($"{ s }");
                await generateCodeStatusDBService.Update(0);

                return false;
            }

            generateCodeStatusDBService.Status.AppendLine($"{ PolSourceGroupingExcelFileReadServicesRes.Doing } ... { s }");
            //await generateCodeStatusDBService.Update( 0);

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
                    if (!await GetRecursiveForShowAllPaths(child, textList, Level, RaiseEvents, sb))
                        return false;
                }
            }

            generateCodeStatusDBService.Status.AppendLine($"");
            //await generateCodeStatusDBService.Update( 0);

            return true;
        }
        public void SetCulture(CultureInfo Culture)
        {
            PolSourceGroupingExcelFileReadServicesRes.Culture = Culture;
        }
        #endregion Functions public

        #region Functions private
        private async Task<bool> CheckSpreadsheet()
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
                    generateCodeStatusDBService.Status.AppendLine($"{ PolSourceGroupingExcelFileReadServicesRes.Checking } ... { PolSourceGroupingExcelFileReadServicesRes.That } { child } { PolSourceGroupingExcelFileReadServicesRes.ExistOnColumnGroup }");
                    //await generateCodeStatusDBService.Update( 0);
                }

                GroupChoiceChildLevel groupChoiceChildLevelExist = (from c in groupChoiceChildLevelList
                                                                    where c.Group == child
                                                                    select c).FirstOrDefault();

                if (groupChoiceChildLevelExist == null)
                {
                    generateCodeStatusDBService.Error.AppendLine($"{ child } ----- { PolSourceGroupingExcelFileReadServicesRes.DoesNotExistOnColumnGroup }");
                    generateCodeStatusDBService.Error.AppendLine("");
                    await generateCodeStatusDBService.Update(0);

                    return false;
                }
            }

            generateCodeStatusDBService.Status.AppendLine($"{ PolSourceGroupingExcelFileReadServicesRes.AllChildDoExistOnColumnGroup }");
            generateCodeStatusDBService.Status.AppendLine("");
            //await generateCodeStatusDBService.Update( 0);

            foreach (GroupChoiceChildLevel groupChoiceChildLevel in groupChoiceChildLevelList)
            {
                if (groupChoiceChildLevel.Group.Length < 5)
                {
                    generateCodeStatusDBService.Error.AppendLine($"{ PolSourceGroupingExcelFileReadServicesRes.Group }: { groupChoiceChildLevel.CSSPID } { PolSourceGroupingExcelFileReadServicesRes.PotentialEmptyRowAbove }.");
                    generateCodeStatusDBService.Error.AppendLine("");
                    await generateCodeStatusDBService.Update(0);

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
                    generateCodeStatusDBService.Status.AppendLine($"{ PolSourceGroupingExcelFileReadServicesRes.Checking } ... { PolSourceGroupingExcelFileReadServicesRes.ThatGroup } { groupChoiceChildLevel.Group }--- EN/FR: { groupChoiceChildLevel.EN } { PolSourceGroupingExcelFileReadServicesRes.HasENFRText }");
                    //await generateCodeStatusDBService.Update( 0);
                }

                if (string.IsNullOrWhiteSpace(groupChoiceChildLevel.EN))
                {
                    generateCodeStatusDBService.Error.AppendLine($"Group: { groupChoiceChildLevel.Group } --- EN: { groupChoiceChildLevel.EN } ----- { PolSourceGroupingExcelFileReadServicesRes.DoesNotHaveENText }");
                    generateCodeStatusDBService.Error.AppendLine("");
                    await generateCodeStatusDBService.Update(0);

                    return false;
                }

                countChild += 1;

                if (string.IsNullOrWhiteSpace(groupChoiceChildLevel.FR))
                {
                    generateCodeStatusDBService.Error.AppendLine($"Group: { groupChoiceChildLevel.Group } --- EN: { groupChoiceChildLevel.FR } ----- { PolSourceGroupingExcelFileReadServicesRes.DoesNotHaveFRText }");
                    generateCodeStatusDBService.Error.AppendLine("");
                    await generateCodeStatusDBService.Update(0);

                    return false;
                }

            }

            generateCodeStatusDBService.Status.AppendLine($"{ PolSourceGroupingExcelFileReadServicesRes.EachGroupWithEndingName } = 'Start' { PolSourceGroupingExcelFileReadServicesRes.DoesHaveENandFRText }.");
            generateCodeStatusDBService.Status.AppendLine("");
            //await generateCodeStatusDBService.Update( 0);

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
                        generateCodeStatusDBService.Status.AppendLine($"{ PolSourceGroupingExcelFileReadServicesRes.Checking } ... { PolSourceGroupingExcelFileReadServicesRes.ThatGroup } { groupChoiceChildLevel.Group } --- EN/FR: { groupChoiceChildLevel.EN } { PolSourceGroupingExcelFileReadServicesRes.HasDescENDescFRText }");
                        generateCodeStatusDBService.Status.AppendLine("");
                        //await generateCodeStatusDBService.Update( 0);
                    }

                    if (string.IsNullOrWhiteSpace(groupChoiceChildLevel.DescEN))
                    {
                        generateCodeStatusDBService.Error.AppendLine($"{ PolSourceGroupingExcelFileReadServicesRes.Group}: { groupChoiceChildLevel.Group } --- EN: { groupChoiceChildLevel.EN } ----- { PolSourceGroupingExcelFileReadServicesRes.DoesNotHaveDescENText }");
                        generateCodeStatusDBService.Error.AppendLine("");
                        await generateCodeStatusDBService.Update(0);

                        return false;
                    }

                    if (string.IsNullOrWhiteSpace(groupChoiceChildLevel.DescFR))
                    {
                        generateCodeStatusDBService.Error.AppendLine($"{ PolSourceGroupingExcelFileReadServicesRes.Group}: { groupChoiceChildLevel.Group } --- FR: { groupChoiceChildLevel.FR } ----- { PolSourceGroupingExcelFileReadServicesRes.DoesNotHaveDescFRText }");
                        generateCodeStatusDBService.Error.AppendLine("");
                        await generateCodeStatusDBService.Update(0);

                        return false;
                    }
                }
            }

            generateCodeStatusDBService.Status.AppendLine($"{ PolSourceGroupingExcelFileReadServicesRes.EachGroupWithEndingName} = 'Start' { PolSourceGroupingExcelFileReadServicesRes.DoesHaveDescENAndDescFRText }.");
            generateCodeStatusDBService.Status.AppendLine("");
            //await generateCodeStatusDBService.Update( 0);

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
                    generateCodeStatusDBService.Status.AppendLine($"{ PolSourceGroupingExcelFileReadServicesRes.Checking } ... { PolSourceGroupingExcelFileReadServicesRes.ThatGroup } { groupChoiceChildLevel.Group } --- EN/FR: { groupChoiceChildLevel.EN } { PolSourceGroupingExcelFileReadServicesRes.HasENFRText }");
                    generateCodeStatusDBService.Status.AppendLine("");
                    //await generateCodeStatusDBService.Update( 0);
                }

                if (string.IsNullOrWhiteSpace(groupChoiceChildLevel.EN))
                {
                    generateCodeStatusDBService.Error.AppendLine($"{ PolSourceGroupingExcelFileReadServicesRes.Group }: { groupChoiceChildLevel.Group } --- EN: { groupChoiceChildLevel.EN } ----- { PolSourceGroupingExcelFileReadServicesRes.DoesNotHaveENText }");
                    generateCodeStatusDBService.Error.AppendLine("");
                    await generateCodeStatusDBService.Update(0);

                    return false;
                }

                if (string.IsNullOrWhiteSpace(groupChoiceChildLevel.FR))
                {
                    generateCodeStatusDBService.Error.AppendLine($"{ PolSourceGroupingExcelFileReadServicesRes.Group }: { groupChoiceChildLevel.Group } --- FR: { groupChoiceChildLevel.FR } ----- { PolSourceGroupingExcelFileReadServicesRes.DoesNotHaveFRText }");
                    generateCodeStatusDBService.Error.AppendLine("");
                    await generateCodeStatusDBService.Update(0);

                    return false;
                }

            }

            generateCodeStatusDBService.Status.AppendLine($"{ PolSourceGroupingExcelFileReadServicesRes.EachChoiceDoesHaveENAndFRText }.");
            generateCodeStatusDBService.Status.AppendLine("");
            //await generateCodeStatusDBService.Update( 0);

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
                    generateCodeStatusDBService.Status.AppendLine($"{ PolSourceGroupingExcelFileReadServicesRes.Checking } ... { PolSourceGroupingExcelFileReadServicesRes.ThatGroup } { groupChoiceChildLevel.Group } --- EN/FR: { groupChoiceChildLevel.EN } { PolSourceGroupingExcelFileReadServicesRes.HasReportENReportFRText }. { PolSourceGroupingExcelFileReadServicesRes.YouCanAddASpaceToFixTheProblem }.");
                    generateCodeStatusDBService.Status.AppendLine("");
                    //await generateCodeStatusDBService.Update( 0);
                }

                if (string.IsNullOrWhiteSpace(groupChoiceChildLevel.ReportEN) && groupChoiceChildLevel.ReportEN.Length == 0)
                {
                    generateCodeStatusDBService.Error.AppendLine($"{ PolSourceGroupingExcelFileReadServicesRes.Group}: { groupChoiceChildLevel.Group } --- EN: { groupChoiceChildLevel.EN } ----- { PolSourceGroupingExcelFileReadServicesRes.DoesNotHaveReportENText }. { PolSourceGroupingExcelFileReadServicesRes.YouCanAddASpaceToFixTheProblem }.");
                    generateCodeStatusDBService.Error.AppendLine("");
                    await generateCodeStatusDBService.Update(0);

                    return false;
                }

                if (string.IsNullOrWhiteSpace(groupChoiceChildLevel.ReportFR) && groupChoiceChildLevel.ReportFR.Length == 0)
                {
                    generateCodeStatusDBService.Error.AppendLine($"{ PolSourceGroupingExcelFileReadServicesRes.Group}: { groupChoiceChildLevel.Group } --- FR: { groupChoiceChildLevel.FR } ----- { PolSourceGroupingExcelFileReadServicesRes.DoesNotHaveReportFRText }. { PolSourceGroupingExcelFileReadServicesRes.YouCanAddASpaceToFixTheProblem }.");
                    generateCodeStatusDBService.Error.AppendLine("");
                    await generateCodeStatusDBService.Update(0);

                    return false;
                }

            }

            generateCodeStatusDBService.Status.AppendLine($"{ PolSourceGroupingExcelFileReadServicesRes.EachChoiceDoesHaveReportENAndReportFRText }.");
            generateCodeStatusDBService.Status.AppendLine("");
            //await generateCodeStatusDBService.Update( 0);

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
                                                            generateCodeStatusDBService.Error.AppendLine($"{ fi.FullName } { PolSourceGroupingExcelFileReadServicesRes.PolSourceGrouping } { item.Text } { PolSourceGroupingExcelFileReadServicesRes.IsNotEqualTo } { FieldNameList[cellcount] }");
                                                            generateCodeStatusDBService.Error.AppendLine("");
                                                            await generateCodeStatusDBService.Update(0);

                                                            return false;
                                                        }
                                                    }
                                                    else if (item.InnerText != null)
                                                    {
                                                        currentcellvalue = item.InnerText;
                                                        if (currentcellvalue != FieldNameList[cellcount])
                                                        {
                                                            generateCodeStatusDBService.Error.AppendLine($"{ fi.FullName } { PolSourceGroupingExcelFileReadServicesRes.PolSourceGrouping } { item.Text } { PolSourceGroupingExcelFileReadServicesRes.IsNotEqualTo } { FieldNameList[cellcount] }");
                                                            generateCodeStatusDBService.Error.AppendLine("");
                                                            await generateCodeStatusDBService.Update(0);

                                                            return false;
                                                        }
                                                    }
                                                    else if (item.InnerXml != null)
                                                    {
                                                        currentcellvalue = item.InnerXml;
                                                        if (currentcellvalue != FieldNameList[cellcount])
                                                        {
                                                            generateCodeStatusDBService.Error.AppendLine($"{ fi.FullName } { PolSourceGroupingExcelFileReadServicesRes.PolSourceGrouping } { item.Text } { PolSourceGroupingExcelFileReadServicesRes.IsNotEqualTo }  { FieldNameList[cellcount] }");
                                                            generateCodeStatusDBService.Error.AppendLine("");
                                                            await generateCodeStatusDBService.Update(0);

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
                                                generateCodeStatusDBService.Error.AppendLine($"{ fi.FullName } { PolSourceGroupingExcelFileReadServicesRes.PolSourceGrouping } { (thecurrentcell.InnerText + " ") } { PolSourceGroupingExcelFileReadServicesRes.IsNotEqualTo } { FieldNameList[cellcount] }");
                                                generateCodeStatusDBService.Error.AppendLine("");
                                                await generateCodeStatusDBService.Update(0);

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
                                        generateCodeStatusDBService.Status.AppendLine($"{ PolSourceGroupingExcelFileReadServicesRes.ReadingSpreadsheet } ... { rowCount }");
                                        generateCodeStatusDBService.Status.AppendLine("");
                                        //await generateCodeStatusDBService.Update( 0);
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
                generateCodeStatusDBService.Error.AppendLine($"{ ex.Message }");
                generateCodeStatusDBService.Error.AppendLine("");
                await generateCodeStatusDBService.Update(0);

                return false;
            }

            List<GroupChoiceChildLevel> groupChoiceChildLevelOrderedList = (from c in groupChoiceChildLevelStraitList
                                                                            orderby c.Group
                                                                            select c).ToList();

            for (int i = 0, count = groupChoiceChildLevelOrderedList.Count; i < (count - 1); i++)
            {
                if (i % 200 == 0)
                {
                    generateCodeStatusDBService.Status.AppendLine($"{ PolSourceGroupingExcelFileReadServicesRes.Checking } ... { PolSourceGroupingExcelFileReadServicesRes.ThatGroup } { groupChoiceChildLevelOrderedList[i].Group } ---- { PolSourceGroupingExcelFileReadServicesRes.HasNoDuplicates }");
                    generateCodeStatusDBService.Status.AppendLine("");
                    //await generateCodeStatusDBService.Update( 0);
                }

                if (groupChoiceChildLevelOrderedList[i].Group == groupChoiceChildLevelOrderedList[i + 1].Group)
                {
                    generateCodeStatusDBService.Error.AppendLine($"{ groupChoiceChildLevelOrderedList[i].Group } ---- { PolSourceGroupingExcelFileReadServicesRes.HasDuplicates }");
                    generateCodeStatusDBService.Error.AppendLine("");
                    await generateCodeStatusDBService.Update(0);

                    return false;
                }
            }

            generateCodeStatusDBService.Status.AppendLine($"{ PolSourceGroupingExcelFileReadServicesRes.ColumnGroupDoesNotHaveDuplicates }.");
            generateCodeStatusDBService.Status.AppendLine("");
            //await generateCodeStatusDBService.Update( 0);

            for (int i = 0, count = groupChoiceChildLevelOrderedList.Count; i < count; i++)
            {
                if (!string.IsNullOrWhiteSpace(groupChoiceChildLevelOrderedList[i].Group))
                {
                    if (i % 200 == 0)
                    {
                        generateCodeStatusDBService.Status.AppendLine($"{ PolSourceGroupingExcelFileReadServicesRes.Checking } ... { PolSourceGroupingExcelFileReadServicesRes.ThatGroup } { groupChoiceChildLevelOrderedList[i].Group } ---- { PolSourceGroupingExcelFileReadServicesRes.ShouldNotContainSpace }");
                        generateCodeStatusDBService.Status.AppendLine("");
                        //await generateCodeStatusDBService.Update( 0);
                    }

                    if (groupChoiceChildLevelOrderedList[i].Group.Contains(" "))
                    {
                        generateCodeStatusDBService.Error.AppendLine($"{ PolSourceGroupingExcelFileReadServicesRes.Group} --- { groupChoiceChildLevelOrderedList[i].Group } ---- { PolSourceGroupingExcelFileReadServicesRes.ShouldNotContainSpace}");
                        generateCodeStatusDBService.Error.AppendLine("");
                        await generateCodeStatusDBService.Update(0);

                        return false;
                    }
                }
                if (!string.IsNullOrWhiteSpace(groupChoiceChildLevelOrderedList[i].Child))
                {
                    if (i % 200 == 0)
                    {
                        generateCodeStatusDBService.Status.AppendLine($"{ PolSourceGroupingExcelFileReadServicesRes.Checking} ... { PolSourceGroupingExcelFileReadServicesRes.ThatGroup} { groupChoiceChildLevelOrderedList[i].Child } ---- { PolSourceGroupingExcelFileReadServicesRes.ShouldNotContainSpace}");
                        generateCodeStatusDBService.Status.AppendLine("");
                        //await generateCodeStatusDBService.Update( 0);
                    }

                    if (groupChoiceChildLevelOrderedList[i].Child.Contains(" "))
                    {
                        generateCodeStatusDBService.Error.AppendLine($"{ PolSourceGroupingExcelFileReadServicesRes.Child } --- { groupChoiceChildLevelOrderedList[i].Child } ---- { PolSourceGroupingExcelFileReadServicesRes.ShouldNotContainSpace }");
                        generateCodeStatusDBService.Error.AppendLine("");
                        await generateCodeStatusDBService.Update(0);

                        return false;
                    }
                }

            }

            generateCodeStatusDBService.Status.AppendLine($"{ PolSourceGroupingExcelFileReadServicesRes.AllTextInGroupAndChildColumnsDoesNotContainSpace }.");
            generateCodeStatusDBService.Status.AppendLine("");
            //await generateCodeStatusDBService.Update( 0);

            string AllowableChar = "abcdefghijklmnopqrstuvwxyz_ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";

            for (int i = 0, count = groupChoiceChildLevelOrderedList.Count; i < count; i++)
            {
                if (i % 200 == 0)
                {
                    generateCodeStatusDBService.Status.AppendLine($"{ PolSourceGroupingExcelFileReadServicesRes.Checking} ... { PolSourceGroupingExcelFileReadServicesRes.ThatGroup} { groupChoiceChildLevelOrderedList[i].Group } ---- { PolSourceGroupingExcelFileReadServicesRes.ShouldOnlyContainCharactersLike } [{ AllowableChar }]");
                    generateCodeStatusDBService.Status.AppendLine("");
                    //await generateCodeStatusDBService.Update( 0);
                }

                foreach (char c in groupChoiceChildLevelOrderedList[i].Group)
                {
                    if (!AllowableChar.Contains(c))
                    {
                        generateCodeStatusDBService.Error.AppendLine($"{ PolSourceGroupingExcelFileReadServicesRes.Group} --- { groupChoiceChildLevelOrderedList[i].Group } ---- { PolSourceGroupingExcelFileReadServicesRes.ShouldNotContain } [{ c }]. { PolSourceGroupingExcelFileReadServicesRes.AllowableCharactersAre } [{ AllowableChar }]");
                        generateCodeStatusDBService.Error.AppendLine("");
                        await generateCodeStatusDBService.Update(0);

                        return false;
                    }
                }
                foreach (char c in groupChoiceChildLevelOrderedList[i].Child)
                {
                    if (i % 200 == 0)
                    {
                        generateCodeStatusDBService.Status.AppendLine($"{ PolSourceGroupingExcelFileReadServicesRes.Checking} ... { PolSourceGroupingExcelFileReadServicesRes.ThatGroup } { groupChoiceChildLevelOrderedList[i].Child } ---- { PolSourceGroupingExcelFileReadServicesRes.ShouldOnlyContainCharactersLike } [{ AllowableChar }]");
                        generateCodeStatusDBService.Status.AppendLine("");
                        //await generateCodeStatusDBService.Update( 0);
                    }

                    if (!AllowableChar.Contains(c))
                    {
                        generateCodeStatusDBService.Error.AppendLine($"{ PolSourceGroupingExcelFileReadServicesRes.Child } --- { groupChoiceChildLevelOrderedList[i].Child } ---- { PolSourceGroupingExcelFileReadServicesRes.ShouldNotContain} [{ c }]. { PolSourceGroupingExcelFileReadServicesRes.AllowableCharactersAre } [{ AllowableChar }]");
                        generateCodeStatusDBService.Error.AppendLine("");
                        await generateCodeStatusDBService.Update(0);

                        return false;
                    }
                }
            }

            generateCodeStatusDBService.Status.AppendLine($"{ PolSourceGroupingExcelFileReadServicesRes.AllTextInGroupAndChildColumnsDoesNotContainSpace }.");
            generateCodeStatusDBService.Status.AppendLine("");
            //await generateCodeStatusDBService.Update( 0);

            for (int i = 0, count = groupChoiceChildLevelOrderedList.Count; i < count; i++)
            {
                if (!string.IsNullOrWhiteSpace(groupChoiceChildLevelOrderedList[i].Group))
                {
                    if (i % 200 == 0)
                    {
                        generateCodeStatusDBService.Status.AppendLine($"{ PolSourceGroupingExcelFileReadServicesRes.Checking} ... { PolSourceGroupingExcelFileReadServicesRes.ThatCSSPID } { groupChoiceChildLevelOrderedList[i].Group } ---- { PolSourceGroupingExcelFileReadServicesRes.DoesNotContainSpace }");
                        generateCodeStatusDBService.Status.AppendLine("");
                        //await generateCodeStatusDBService.Update( 0);
                    }

                    if (groupChoiceChildLevelOrderedList[i].CSSPID.Contains(" "))
                    {
                        generateCodeStatusDBService.Error.AppendLine($"{ PolSourceGroupingExcelFileReadServicesRes.CSSPID } --- { groupChoiceChildLevelOrderedList[i].Group } ---- { PolSourceGroupingExcelFileReadServicesRes.ShouldNotContainSpace }");
                        generateCodeStatusDBService.Error.AppendLine("");
                        await generateCodeStatusDBService.Update(0);

                        return false;
                    }
                }
                if (!string.IsNullOrWhiteSpace(groupChoiceChildLevelOrderedList[i].Child))
                {
                    if (i % 200 == 0)
                    {
                        generateCodeStatusDBService.Status.AppendLine($"{ PolSourceGroupingExcelFileReadServicesRes.Checking} ... { PolSourceGroupingExcelFileReadServicesRes.ThatCSSPID } { groupChoiceChildLevelOrderedList[i].Child } ---- { PolSourceGroupingExcelFileReadServicesRes.DoesNotContainSpace }");
                        generateCodeStatusDBService.Status.AppendLine("");
                        //await generateCodeStatusDBService.Update( 0);
                    }

                    if (groupChoiceChildLevelOrderedList[i].CSSPID.Contains(" "))
                    {
                        generateCodeStatusDBService.Error.AppendLine($"{ PolSourceGroupingExcelFileReadServicesRes.CSSPID } --- { groupChoiceChildLevelOrderedList[i].Child } ---- { PolSourceGroupingExcelFileReadServicesRes.ShouldNotContainSpace }");
                        generateCodeStatusDBService.Error.AppendLine("");
                        await generateCodeStatusDBService.Update(0);

                        return false;
                    }
                }

            }

            generateCodeStatusDBService.Status.AppendLine($"{ PolSourceGroupingExcelFileReadServicesRes.AllTextInCSSPIDColumnDoesNotContainSpace }.");
            generateCodeStatusDBService.Status.AppendLine("");
            //await generateCodeStatusDBService.Update( 0);

            List<string> UniqueCSSPIDList = new List<string>();
            for (int i = 0, count = groupChoiceChildLevelOrderedList.Count; i < count; i++)
            {
                if (!string.IsNullOrWhiteSpace(groupChoiceChildLevelOrderedList[i].Group))
                {
                    if (i % 200 == 0)
                    {
                        generateCodeStatusDBService.Status.AppendLine($"{ PolSourceGroupingExcelFileReadServicesRes.Checking} ... { PolSourceGroupingExcelFileReadServicesRes.ThatGroupCSSPID } { groupChoiceChildLevelOrderedList[i].Group } ---- { PolSourceGroupingExcelFileReadServicesRes.IsUnique }.");
                        generateCodeStatusDBService.Status.AppendLine("");
                        //await generateCodeStatusDBService.Update( 0);
                    }

                    if (string.IsNullOrWhiteSpace(groupChoiceChildLevelOrderedList[i].CSSPID))
                    {
                        generateCodeStatusDBService.Error.AppendLine($"{ PolSourceGroupingExcelFileReadServicesRes.Group} --- { groupChoiceChildLevelOrderedList[i].Group } ---- { PolSourceGroupingExcelFileReadServicesRes.RequiredAUniqueNumberInFirstColumn }.");
                        generateCodeStatusDBService.Error.AppendLine("");
                        await generateCodeStatusDBService.Update(0);

                        return false;
                    }
                }
                if (!string.IsNullOrWhiteSpace(groupChoiceChildLevelOrderedList[i].Child))
                {
                    if (i % 200 == 0)
                    {
                        generateCodeStatusDBService.Status.AppendLine($"{ PolSourceGroupingExcelFileReadServicesRes.Checking} ... { PolSourceGroupingExcelFileReadServicesRes.ThatGroupCSSPID } { groupChoiceChildLevelOrderedList[i].Child } ---- { PolSourceGroupingExcelFileReadServicesRes.IsUnique }.");
                        generateCodeStatusDBService.Status.AppendLine("");
                        //await generateCodeStatusDBService.Update( 0);
                    }

                    if (string.IsNullOrWhiteSpace(groupChoiceChildLevelOrderedList[i].CSSPID))
                    {
                        generateCodeStatusDBService.Error.AppendLine($"{ PolSourceGroupingExcelFileReadServicesRes.Child } --- { groupChoiceChildLevelOrderedList[i].Child } ---- { PolSourceGroupingExcelFileReadServicesRes.RequiredAUniqueNumberInFirstColumn }");
                        generateCodeStatusDBService.Error.AppendLine("");
                        await generateCodeStatusDBService.Update(0);

                        return false;
                    }
                }

                if (i % 200 == 0)
                {
                    generateCodeStatusDBService.Status.AppendLine($"{ PolSourceGroupingExcelFileReadServicesRes.Checking} ... { PolSourceGroupingExcelFileReadServicesRes.ThatCSSPID } { groupChoiceChildLevelOrderedList[i].Child } ---- { PolSourceGroupingExcelFileReadServicesRes.IsNotEmpty }.");
                    generateCodeStatusDBService.Status.AppendLine("");
                    //await generateCodeStatusDBService.Update( 0);
                }

                if (string.IsNullOrWhiteSpace(groupChoiceChildLevelOrderedList[i].CSSPID))
                {
                    generateCodeStatusDBService.Error.AppendLine($"{ PolSourceGroupingExcelFileReadServicesRes.CSSPIDIsRequiredForGroupOrChild } [{ (groupChoiceChildLevelOrderedList[i].Choice.Length > 0 ? groupChoiceChildLevelOrderedList[i].Choice : groupChoiceChildLevelOrderedList[i].Group) }]");
                    generateCodeStatusDBService.Error.AppendLine("");
                    await generateCodeStatusDBService.Update(0);

                    return false;
                }

                generateCodeStatusDBService.Status.AppendLine($"{ PolSourceGroupingExcelFileReadServicesRes.Checking } ... { PolSourceGroupingExcelFileReadServicesRes.ThatCSSPID } { groupChoiceChildLevelOrderedList[i].Child } ---- { PolSourceGroupingExcelFileReadServicesRes.IsUnique }.");
                generateCodeStatusDBService.Status.AppendLine("");
                //await generateCodeStatusDBService.Update( 0);

                if (UniqueCSSPIDList.Contains(groupChoiceChildLevelOrderedList[i].CSSPID))
                {
                    generateCodeStatusDBService.Error.AppendLine($"{ PolSourceGroupingExcelFileReadServicesRes.CSSPID } [{ groupChoiceChildLevelOrderedList[i].CSSPID }] { PolSourceGroupingExcelFileReadServicesRes.IsNotUnique }");
                    generateCodeStatusDBService.Error.AppendLine("");
                    await generateCodeStatusDBService.Update(0);

                    return false;
                }

                UniqueCSSPIDList.Add(groupChoiceChildLevelOrderedList[i].CSSPID);

                if (i % 200 == 0)
                {
                    generateCodeStatusDBService.Status.AppendLine($"{ PolSourceGroupingExcelFileReadServicesRes.Checking } ... { PolSourceGroupingExcelFileReadServicesRes.ThatEachHideCellWithInformationContainsValidChildID }, { PolSourceGroupingExcelFileReadServicesRes.CSSPIDAreNotDupliate }, { PolSourceGroupingExcelFileReadServicesRes.CSSPIDWithDashAreWellFormed }.");
                    generateCodeStatusDBService.Status.AppendLine("");
                    //await generateCodeStatusDBService.Update( 0);
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
                                    generateCodeStatusDBService.Error.AppendLine($"{ PolSourceGroupingExcelFileReadServicesRes.CSSPID } [{ groupChoiceChildLevelOrderedList[i].CSSPID }] { PolSourceGroupingExcelFileReadServicesRes.HideCellContains } [{ childCSSPID }] { PolSourceGroupingExcelFileReadServicesRes.PleaseRemoveADash }");
                                    generateCodeStatusDBService.Error.AppendLine("");
                                    await generateCodeStatusDBService.Update(0);

                                    return false;
                                }

                                foreach (char s in childCSSPID)
                                {
                                    if (!NumberAndDashOnlyList.Contains(s.ToString()))
                                    {
                                        generateCodeStatusDBService.Error.AppendLine($"{ PolSourceGroupingExcelFileReadServicesRes.CSSPID} [{ groupChoiceChildLevelOrderedList[i].CSSPID }] { PolSourceGroupingExcelFileReadServicesRes.HideCellContains } [{ childCSSPID }]. { PolSourceGroupingExcelFileReadServicesRes.AllowableCharactersAre } [{ String.Join(",", NumberAndDashOnlyList) }]");
                                        generateCodeStatusDBService.Error.AppendLine("");
                                        await generateCodeStatusDBService.Update(0);

                                        return false;
                                    }
                                }

                                fromCSSPID = int.Parse(childCSSPID.Substring(0, childCSSPID.IndexOf("-")));
                                int endPos = childCSSPID.IndexOf("-") + 1;
                                if (childCSSPID.Length <= endPos)
                                {
                                    generateCodeStatusDBService.Error.AppendLine($"{ PolSourceGroupingExcelFileReadServicesRes.CSSPID } [{ groupChoiceChildLevelOrderedList[i].CSSPID }] { PolSourceGroupingExcelFileReadServicesRes.HideCellContains } [{ childCSSPID }] { PolSourceGroupingExcelFileReadServicesRes.MissingEndValue }");
                                    generateCodeStatusDBService.Error.AppendLine("");
                                    await generateCodeStatusDBService.Update(0);

                                    return false;
                                }

                                toCSSPID = int.Parse(childCSSPID.Substring(endPos));

                                if (fromCSSPID >= toCSSPID)
                                {
                                    generateCodeStatusDBService.Error.AppendLine($"{ PolSourceGroupingExcelFileReadServicesRes.CSSPID } [{ groupChoiceChildLevelOrderedList[i].CSSPID }] { PolSourceGroupingExcelFileReadServicesRes.HideCellContains } [{ childCSSPID }] { PolSourceGroupingExcelFileReadServicesRes.WhichTheFirstValueIs } >= { PolSourceGroupingExcelFileReadServicesRes.ThanTheLastValue }");
                                    generateCodeStatusDBService.Error.AppendLine("");
                                    await generateCodeStatusDBService.Update(0);

                                    return false;
                                }
                            }

                            if (fromCSSPID != -1)
                            {
                                for (int id = fromCSSPID; id <= toCSSPID; id++)
                                {
                                    if (CSSPIDList2.Contains(id.ToString()) || CSSPIDList.Contains(id.ToString()))
                                    {
                                        generateCodeStatusDBService.Error.AppendLine($"{ PolSourceGroupingExcelFileReadServicesRes.CSSPID } [{ groupChoiceChildLevelOrderedList[i].CSSPID }] { PolSourceGroupingExcelFileReadServicesRes.HideCellContains } [{ childCSSPID }] { PolSourceGroupingExcelFileReadServicesRes.WhichWillDuplicate } [{ id.ToString() }]");
                                        generateCodeStatusDBService.Error.AppendLine("");
                                        await generateCodeStatusDBService.Update(0);

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
                                generateCodeStatusDBService.Error.AppendLine($"{ PolSourceGroupingExcelFileReadServicesRes.CSSPID } [{ groupChoiceChildLevelOrderedList[i].CSSPID }] { PolSourceGroupingExcelFileReadServicesRes.HideCellHasDuplicate } [{ csspID }]");
                                generateCodeStatusDBService.Error.AppendLine("");
                                await generateCodeStatusDBService.Update(0);

                                return false;
                            }
                            oldCSSPID = csspID;
                        }
                        foreach (string childCSSPID in CSSPIDList)
                        {
                            GroupChoiceChildLevel groupChoiceChildLevelChild = groupChoiceChildLevelOrderedList.Where(c => c.CSSPID == childCSSPID).FirstOrDefault();
                            if (groupChoiceChildLevelChild == null)
                            {
                                generateCodeStatusDBService.Error.AppendLine($"{ PolSourceGroupingExcelFileReadServicesRes.CSSPID } [{ groupChoiceChildLevelOrderedList[i].CSSPID }] { PolSourceGroupingExcelFileReadServicesRes.HideCellContainsID } [{ childCSSPID.ToString() }] { PolSourceGroupingExcelFileReadServicesRes.WhichDoesNotExist }");
                                generateCodeStatusDBService.Error.AppendLine("");
                                await generateCodeStatusDBService.Update(0);

                                return false;
                            }
                            string startCSSPID = $"{ childCSSPID.Substring(0, 3) }00";

                            GroupChoiceChildLevel groupChoiceChildLevel = groupChoiceChildLevelOrderedList.Where(c => c.CSSPID == startCSSPID).FirstOrDefault();

                            if (groupChoiceChildLevel == null)
                            {
                                generateCodeStatusDBService.Error.AppendLine($"{ PolSourceGroupingExcelFileReadServicesRes.CSSPID } [{ groupChoiceChildLevelOrderedList[i].CSSPID }] { PolSourceGroupingExcelFileReadServicesRes.GroupChoiceChildLevelIsNullForStartCSSPID } [{ startCSSPID.ToString() }]");
                                generateCodeStatusDBService.Error.AppendLine("");
                                await generateCodeStatusDBService.Update(0);

                                return false;
                            }

                            string group = groupChoiceChildLevel.Group;
                            if (groupChoiceChildLevelOrderedList[i].Child != group)
                            {
                                generateCodeStatusDBService.Error.AppendLine($"{ PolSourceGroupingExcelFileReadServicesRes.CSSPID } [{ groupChoiceChildLevelOrderedList[i].CSSPID }] { PolSourceGroupingExcelFileReadServicesRes.HideCellContainsID } [{ childCSSPID.ToString() }] { PolSourceGroupingExcelFileReadServicesRes.WhichIsNotADirectChild }");
                                generateCodeStatusDBService.Error.AppendLine("");
                                await generateCodeStatusDBService.Update(0);

                                return false;
                            }
                        }
                        if (CSSPIDList.Count > 0)
                        {
                            string childCSSPID = CSSPIDList[0];

                            GroupChoiceChildLevel groupChoiceChildLevelChild = groupChoiceChildLevelOrderedList.Where(c => c.CSSPID == childCSSPID).FirstOrDefault();
                            if (groupChoiceChildLevelChild == null)
                            {
                                generateCodeStatusDBService.Error.AppendLine($"{ PolSourceGroupingExcelFileReadServicesRes.CSSPID } [{ groupChoiceChildLevelOrderedList[i].CSSPID }] { PolSourceGroupingExcelFileReadServicesRes.HideCellContainsID } [{ childCSSPID.ToString() }] { PolSourceGroupingExcelFileReadServicesRes.WhichDoesNotExist}");
                                generateCodeStatusDBService.Error.AppendLine("");
                                await generateCodeStatusDBService.Update(0);

                                return false;
                            }
                            string start3CharCSSPID = $"{ childCSSPID.Substring(0, 3) }";

                            int CountChild = groupChoiceChildLevelOrderedList.Where(c => c.CSSPID.StartsWith(start3CharCSSPID) && !c.CSSPID.EndsWith("00")).Count();

                            if (CSSPIDList.Count == CountChild)
                            {
                                generateCodeStatusDBService.Error.AppendLine($"{ PolSourceGroupingExcelFileReadServicesRes.CSSPID } [{ groupChoiceChildLevelOrderedList[i].CSSPID }] { PolSourceGroupingExcelFileReadServicesRes.IsHidingAllPossibleSelection }");
                                generateCodeStatusDBService.Error.AppendLine("");
                                await generateCodeStatusDBService.Update(0);

                                return false;

                            }
                        }
                    }
                }
            }

            generateCodeStatusDBService.Status.AppendLine($"{ PolSourceGroupingExcelFileReadServicesRes.AllGroupsAndChoicesColumnsHaveAUniqueCSSPID }.");
            generateCodeStatusDBService.Status.AppendLine("");

            generateCodeStatusDBService.Status.AppendLine($"{ PolSourceGroupingExcelFileReadServicesRes.AllHideColumnsWithInformationHasValidCSSPIDIEExistAndIsChild }.");
            generateCodeStatusDBService.Status.AppendLine("");

            generateCodeStatusDBService.Status.AppendLine($"{ PolSourceGroupingExcelFileReadServicesRes.EverythingIsOK }.");
            generateCodeStatusDBService.Status.AppendLine("");
            //await generateCodeStatusDBService.Update( 0);

            return true;
        }
        private async Task<bool> ReadExcelFile()
        {
            groupChoiceChildLevelList = new List<GroupChoiceChildLevel>();

            generateCodeStatusDBService.Status.AppendLine($"{ PolSourceGroupingExcelFileReadServicesRes.ReadingSpreadsheet } [{ FullFileName }]");
            generateCodeStatusDBService.Status.AppendLine("");
            //await generateCodeStatusDBService.Update( 0);

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
                                                            generateCodeStatusDBService.Error.AppendLine($"{ fi.FullName } { PolSourceGroupingExcelFileReadServicesRes.PolSourceGrouping } { item.Text } { PolSourceGroupingExcelFileReadServicesRes.IsNotEqualTo } { FieldNameList[cellcount] }");
                                                            generateCodeStatusDBService.Error.AppendLine("");
                                                            await generateCodeStatusDBService.Update(0);

                                                            return false;
                                                        }
                                                    }
                                                    else if (item.InnerText != null)
                                                    {
                                                        currentcellvalue = item.InnerText;
                                                        if (currentcellvalue != FieldNameList[cellcount])
                                                        {
                                                            generateCodeStatusDBService.Error.AppendLine($"{ fi.FullName } { PolSourceGroupingExcelFileReadServicesRes.PolSourceGrouping } { item.Text } { PolSourceGroupingExcelFileReadServicesRes.IsNotEqualTo } { FieldNameList[cellcount] }");
                                                            generateCodeStatusDBService.Error.AppendLine("");
                                                            await generateCodeStatusDBService.Update(0);

                                                            return false;
                                                        }
                                                    }
                                                    else if (item.InnerXml != null)
                                                    {
                                                        currentcellvalue = item.InnerXml;
                                                        if (currentcellvalue != FieldNameList[cellcount])
                                                        {
                                                            generateCodeStatusDBService.Error.AppendLine($"{ fi.FullName } { PolSourceGroupingExcelFileReadServicesRes.PolSourceGrouping } { item.Text } { PolSourceGroupingExcelFileReadServicesRes.IsNotEqualTo } { FieldNameList[cellcount] }");
                                                            generateCodeStatusDBService.Error.AppendLine("");
                                                            await generateCodeStatusDBService.Update(0);

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
                                                generateCodeStatusDBService.Error.AppendLine($"{ fi.FullName } { PolSourceGroupingExcelFileReadServicesRes.PolSourceGrouping } { (thecurrentcell.InnerText + " ") } { PolSourceGroupingExcelFileReadServicesRes.IsNotEqualTo } { FieldNameList[cellcount] }");
                                                generateCodeStatusDBService.Error.AppendLine("");
                                                await generateCodeStatusDBService.Update(0);

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
                                        generateCodeStatusDBService.Status.AppendLine($"{ PolSourceGroupingExcelFileReadServicesRes.ReadingSpreadsheet } ... { rowCount }");
                                        generateCodeStatusDBService.Status.AppendLine("");
                                        //await generateCodeStatusDBService.Update( 0);
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
                generateCodeStatusDBService.Error.AppendLine($"{ ex.Message }");
                generateCodeStatusDBService.Error.AppendLine("");
                await generateCodeStatusDBService.Update(0);

                return false;
            }


            int Level = 0;
            List<string> textList = new List<string>();
            StringBuilder sb = new StringBuilder();
            if (!await GetRecursiveForShowAllPaths("Start", textList, Level, false, sb))
            {
                return false;
            }

            return true;

        }
        #endregion Functions private
    }
}
