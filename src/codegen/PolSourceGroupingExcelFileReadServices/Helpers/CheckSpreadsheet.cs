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
using CultureServices.Resources;

namespace PolSourceGroupingExcelFileReadServices.Services
{
    public partial class PolSourceGroupingExcelFileReadService : IPolSourceGroupingExcelFileReadService
    {
        private async Task<bool> CheckSpreadsheet()
        {
            if (groupChoiceChildLevelList.Count == 0)
            {
                return await Task.FromResult(false);
            }

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
                    actionCommandDBService.ExecutionStatusText.AppendLine($"{ CultureServicesRes.Checking } ... { CultureServicesRes.That } { child } { CultureServicesRes.ExistOnColumnGroup }");
                    //await actionCommandDBService.Update( 0);
                }

                GroupChoiceChildLevel groupChoiceChildLevelExist = (from c in groupChoiceChildLevelList
                                                                    where c.Group == child
                                                                    select c).FirstOrDefault();

                if (groupChoiceChildLevelExist == null)
                {
                    actionCommandDBService.ErrorText.AppendLine($"{ child } ----- { CultureServicesRes.DoesNotExistOnColumnGroup }");
                    actionCommandDBService.ErrorText.AppendLine("");
                    actionCommandDBService.PercentCompleted = 0;
                    await actionCommandDBService.Update();

                    return await Task.FromResult(false);
                }
            }

            actionCommandDBService.ExecutionStatusText.AppendLine($"{ CultureServicesRes.AllChildDoExistOnColumnGroup }");
            actionCommandDBService.ExecutionStatusText.AppendLine("");
            //await actionCommandDBService.Update( 0);

            foreach (GroupChoiceChildLevel groupChoiceChildLevel in groupChoiceChildLevelList)
            {
                if (groupChoiceChildLevel.Group.Length < 5)
                {
                    actionCommandDBService.ErrorText.AppendLine($"{ CultureServicesRes.Group }: { groupChoiceChildLevel.CSSPID } { CultureServicesRes.PotentialEmptyRowAbove }.");
                    actionCommandDBService.ErrorText.AppendLine("");
                    actionCommandDBService.PercentCompleted = 0;
                    await actionCommandDBService.Update();

                    return await Task.FromResult(false);
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
                    actionCommandDBService.ExecutionStatusText.AppendLine($"{ CultureServicesRes.Checking } ... { CultureServicesRes.ThatGroup } { groupChoiceChildLevel.Group }--- EN/FR: { groupChoiceChildLevel.EN } { CultureServicesRes.HasENFRText }");
                    //await actionCommandDBService.Update( 0);
                }

                if (string.IsNullOrWhiteSpace(groupChoiceChildLevel.EN))
                {
                    actionCommandDBService.ErrorText.AppendLine($"Group: { groupChoiceChildLevel.Group } --- EN: { groupChoiceChildLevel.EN } ----- { CultureServicesRes.DoesNotHaveENText }");
                    actionCommandDBService.ErrorText.AppendLine("");
                    actionCommandDBService.PercentCompleted = 0;
                    await actionCommandDBService.Update();

                    return await Task.FromResult(false);
                }

                countChild += 1;

                if (string.IsNullOrWhiteSpace(groupChoiceChildLevel.FR))
                {
                    actionCommandDBService.ErrorText.AppendLine($"Group: { groupChoiceChildLevel.Group } --- EN: { groupChoiceChildLevel.FR } ----- { CultureServicesRes.DoesNotHaveFRText }");
                    actionCommandDBService.ErrorText.AppendLine("");
                    actionCommandDBService.PercentCompleted = 0;
                    await actionCommandDBService.Update();

                    return await Task.FromResult(false);
                }

            }

            actionCommandDBService.ExecutionStatusText.AppendLine($"{ CultureServicesRes.EachGroupWithEndingName } = 'Start' { CultureServicesRes.DoesHaveENandFRText }.");
            actionCommandDBService.ExecutionStatusText.AppendLine("");
            //await actionCommandDBService.Update( 0);

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
                        actionCommandDBService.ExecutionStatusText.AppendLine($"{ CultureServicesRes.Checking } ... { CultureServicesRes.ThatGroup } { groupChoiceChildLevel.Group } --- EN/FR: { groupChoiceChildLevel.EN } { CultureServicesRes.HasDescENDescFRText }");
                        actionCommandDBService.ExecutionStatusText.AppendLine("");
                        //await actionCommandDBService.Update( 0);
                    }

                    if (string.IsNullOrWhiteSpace(groupChoiceChildLevel.DescEN))
                    {
                        actionCommandDBService.ErrorText.AppendLine($"{ CultureServicesRes.Group}: { groupChoiceChildLevel.Group } --- EN: { groupChoiceChildLevel.EN } ----- { CultureServicesRes.DoesNotHaveDescENText }");
                        actionCommandDBService.ErrorText.AppendLine("");
                        actionCommandDBService.PercentCompleted = 0;
                        await actionCommandDBService.Update();

                        return await Task.FromResult(false);
                    }

                    if (string.IsNullOrWhiteSpace(groupChoiceChildLevel.DescFR))
                    {
                        actionCommandDBService.ErrorText.AppendLine($"{ CultureServicesRes.Group}: { groupChoiceChildLevel.Group } --- FR: { groupChoiceChildLevel.FR } ----- { CultureServicesRes.DoesNotHaveDescFRText }");
                        actionCommandDBService.ErrorText.AppendLine("");
                        actionCommandDBService.PercentCompleted = 0;
                        await actionCommandDBService.Update();

                        return await Task.FromResult(false);
                    }
                }
            }

            actionCommandDBService.ExecutionStatusText.AppendLine($"{ CultureServicesRes.EachGroupWithEndingName} = 'Start' { CultureServicesRes.DoesHaveDescENAndDescFRText }.");
            actionCommandDBService.ExecutionStatusText.AppendLine("");
            //await actionCommandDBService.Update( 0);

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
                    actionCommandDBService.ExecutionStatusText.AppendLine($"{ CultureServicesRes.Checking } ... { CultureServicesRes.ThatGroup } { groupChoiceChildLevel.Group } --- EN/FR: { groupChoiceChildLevel.EN } { CultureServicesRes.HasENFRText }");
                    actionCommandDBService.ExecutionStatusText.AppendLine("");
                    //await actionCommandDBService.Update( 0);
                }

                if (string.IsNullOrWhiteSpace(groupChoiceChildLevel.EN))
                {
                    actionCommandDBService.ErrorText.AppendLine($"{ CultureServicesRes.Group }: { groupChoiceChildLevel.Group } --- EN: { groupChoiceChildLevel.EN } ----- { CultureServicesRes.DoesNotHaveENText }");
                    actionCommandDBService.ErrorText.AppendLine("");
                    actionCommandDBService.PercentCompleted = 0;
                    await actionCommandDBService.Update();

                    return await Task.FromResult(false);
                }

                if (string.IsNullOrWhiteSpace(groupChoiceChildLevel.FR))
                {
                    actionCommandDBService.ErrorText.AppendLine($"{ CultureServicesRes.Group }: { groupChoiceChildLevel.Group } --- FR: { groupChoiceChildLevel.FR } ----- { CultureServicesRes.DoesNotHaveFRText }");
                    actionCommandDBService.ErrorText.AppendLine("");
                    actionCommandDBService.PercentCompleted = 0;
                    await actionCommandDBService.Update();

                    return await Task.FromResult(false);
                }

            }

            actionCommandDBService.ExecutionStatusText.AppendLine($"{ CultureServicesRes.EachChoiceDoesHaveENAndFRText }.");
            actionCommandDBService.ExecutionStatusText.AppendLine("");
            //await actionCommandDBService.Update( 0);

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
                    actionCommandDBService.ExecutionStatusText.AppendLine($"{ CultureServicesRes.Checking } ... { CultureServicesRes.ThatGroup } { groupChoiceChildLevel.Group } --- EN/FR: { groupChoiceChildLevel.EN } { CultureServicesRes.HasReportENReportFRText }. { CultureServicesRes.YouCanAddASpaceToFixTheProblem }.");
                    actionCommandDBService.ExecutionStatusText.AppendLine("");
                    //await actionCommandDBService.Update( 0);
                }

                if (string.IsNullOrWhiteSpace(groupChoiceChildLevel.ReportEN) && groupChoiceChildLevel.ReportEN.Length == 0)
                {
                    actionCommandDBService.ErrorText.AppendLine($"{ CultureServicesRes.Group}: { groupChoiceChildLevel.Group } --- EN: { groupChoiceChildLevel.EN } ----- { CultureServicesRes.DoesNotHaveReportENText }. { CultureServicesRes.YouCanAddASpaceToFixTheProblem }.");
                    actionCommandDBService.ErrorText.AppendLine("");
                    actionCommandDBService.PercentCompleted = 0;
                    await actionCommandDBService.Update();

                    return await Task.FromResult(false);
                }

                if (string.IsNullOrWhiteSpace(groupChoiceChildLevel.ReportFR) && groupChoiceChildLevel.ReportFR.Length == 0)
                {
                    actionCommandDBService.ErrorText.AppendLine($"{ CultureServicesRes.Group}: { groupChoiceChildLevel.Group } --- FR: { groupChoiceChildLevel.FR } ----- { CultureServicesRes.DoesNotHaveReportFRText }. { CultureServicesRes.YouCanAddASpaceToFixTheProblem }.");
                    actionCommandDBService.ErrorText.AppendLine("");
                    actionCommandDBService.PercentCompleted = 0;
                    await actionCommandDBService.Update();

                    return await Task.FromResult(false);
                }

            }

            actionCommandDBService.ExecutionStatusText.AppendLine($"{ CultureServicesRes.EachChoiceDoesHaveReportENAndReportFRText }.");
            actionCommandDBService.ExecutionStatusText.AppendLine("");
            //await actionCommandDBService.Update( 0);

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
                                                            actionCommandDBService.ErrorText.AppendLine($"{ fi.FullName } { CultureServicesRes.PolSourceGrouping } { item.Text } { CultureServicesRes.IsNotEqualTo } { FieldNameList[cellcount] }");
                                                            actionCommandDBService.ErrorText.AppendLine("");
                                                            actionCommandDBService.PercentCompleted = 0;
                                                            await actionCommandDBService.Update();

                                                            return await Task.FromResult(false);
                                                        }
                                                    }
                                                    else if (item.InnerText != null)
                                                    {
                                                        currentcellvalue = item.InnerText;
                                                        if (currentcellvalue != FieldNameList[cellcount])
                                                        {
                                                            actionCommandDBService.ErrorText.AppendLine($"{ fi.FullName } { CultureServicesRes.PolSourceGrouping } { item.Text } { CultureServicesRes.IsNotEqualTo } { FieldNameList[cellcount] }");
                                                            actionCommandDBService.ErrorText.AppendLine("");
                                                            actionCommandDBService.PercentCompleted = 0;
                                                            await actionCommandDBService.Update();

                                                            return await Task.FromResult(false);
                                                        }
                                                    }
                                                    else if (item.InnerXml != null)
                                                    {
                                                        currentcellvalue = item.InnerXml;
                                                        if (currentcellvalue != FieldNameList[cellcount])
                                                        {
                                                            actionCommandDBService.ErrorText.AppendLine($"{ fi.FullName } { CultureServicesRes.PolSourceGrouping } { item.Text } { CultureServicesRes.IsNotEqualTo }  { FieldNameList[cellcount] }");
                                                            actionCommandDBService.ErrorText.AppendLine("");
                                                            actionCommandDBService.PercentCompleted = 0;
                                                            await actionCommandDBService.Update();

                                                            return await Task.FromResult(false);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if ((thecurrentcell.InnerText + " ") != FieldNameList[cellcount])
                                            {
                                                actionCommandDBService.ErrorText.AppendLine($"{ fi.FullName } { CultureServicesRes.PolSourceGrouping } { (thecurrentcell.InnerText + " ") } { CultureServicesRes.IsNotEqualTo } { FieldNameList[cellcount] }");
                                                actionCommandDBService.ErrorText.AppendLine("");
                                                actionCommandDBService.PercentCompleted = 0;
                                                await actionCommandDBService.Update();

                                                return await Task.FromResult(false);
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
                                        actionCommandDBService.ExecutionStatusText.AppendLine($"{ CultureServicesRes.ReadingSpreadsheet } ... { rowCount }");
                                        actionCommandDBService.ExecutionStatusText.AppendLine("");
                                        //await actionCommandDBService.Update( 0);
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
                actionCommandDBService.ErrorText.AppendLine($"{ ex.Message }");
                actionCommandDBService.ErrorText.AppendLine("");
                actionCommandDBService.PercentCompleted = 0;
                await actionCommandDBService.Update();

                return await Task.FromResult(false);
            }

            List<GroupChoiceChildLevel> groupChoiceChildLevelOrderedList = (from c in groupChoiceChildLevelStraitList
                                                                            orderby c.Group
                                                                            select c).ToList();

            for (int i = 0, count = groupChoiceChildLevelOrderedList.Count; i < (count - 1); i++)
            {
                if (i % 200 == 0)
                {
                    actionCommandDBService.ExecutionStatusText.AppendLine($"{ CultureServicesRes.Checking } ... { CultureServicesRes.ThatGroup } { groupChoiceChildLevelOrderedList[i].Group } ---- { CultureServicesRes.HasNoDuplicates }");
                    actionCommandDBService.ExecutionStatusText.AppendLine("");
                    //await actionCommandDBService.Update( 0);
                }

                if (groupChoiceChildLevelOrderedList[i].Group == groupChoiceChildLevelOrderedList[i + 1].Group)
                {
                    actionCommandDBService.ErrorText.AppendLine($"{ groupChoiceChildLevelOrderedList[i].Group } ---- { CultureServicesRes.HasDuplicates }");
                    actionCommandDBService.ErrorText.AppendLine("");
                    actionCommandDBService.PercentCompleted = 0;
                    await actionCommandDBService.Update();

                    return await Task.FromResult(false);
                }
            }

            actionCommandDBService.ExecutionStatusText.AppendLine($"{ CultureServicesRes.ColumnGroupDoesNotHaveDuplicates }.");
            actionCommandDBService.ExecutionStatusText.AppendLine("");
            //await actionCommandDBService.Update( 0);

            for (int i = 0, count = groupChoiceChildLevelOrderedList.Count; i < count; i++)
            {
                if (!string.IsNullOrWhiteSpace(groupChoiceChildLevelOrderedList[i].Group))
                {
                    if (i % 200 == 0)
                    {
                        actionCommandDBService.ExecutionStatusText.AppendLine($"{ CultureServicesRes.Checking } ... { CultureServicesRes.ThatGroup } { groupChoiceChildLevelOrderedList[i].Group } ---- { CultureServicesRes.ShouldNotContainSpace }");
                        actionCommandDBService.ExecutionStatusText.AppendLine("");
                        //await actionCommandDBService.Update( 0);
                    }

                    if (groupChoiceChildLevelOrderedList[i].Group.Contains(" "))
                    {
                        actionCommandDBService.ErrorText.AppendLine($"{ CultureServicesRes.Group} --- { groupChoiceChildLevelOrderedList[i].Group } ---- { CultureServicesRes.ShouldNotContainSpace}");
                        actionCommandDBService.ErrorText.AppendLine("");
                        actionCommandDBService.PercentCompleted = 0;
                        await actionCommandDBService.Update();

                        return await Task.FromResult(false);
                    }
                }
                if (!string.IsNullOrWhiteSpace(groupChoiceChildLevelOrderedList[i].Child))
                {
                    if (i % 200 == 0)
                    {
                        actionCommandDBService.ExecutionStatusText.AppendLine($"{ CultureServicesRes.Checking} ... { CultureServicesRes.ThatGroup} { groupChoiceChildLevelOrderedList[i].Child } ---- { CultureServicesRes.ShouldNotContainSpace}");
                        actionCommandDBService.ExecutionStatusText.AppendLine("");
                        //await actionCommandDBService.Update( 0);
                    }

                    if (groupChoiceChildLevelOrderedList[i].Child.Contains(" "))
                    {
                        actionCommandDBService.ErrorText.AppendLine($"{ CultureServicesRes.Child } --- { groupChoiceChildLevelOrderedList[i].Child } ---- { CultureServicesRes.ShouldNotContainSpace }");
                        actionCommandDBService.ErrorText.AppendLine("");
                        actionCommandDBService.PercentCompleted = 0;
                        await actionCommandDBService.Update();

                        return await Task.FromResult(false);
                    }
                }

            }

            actionCommandDBService.ExecutionStatusText.AppendLine($"{ CultureServicesRes.AllTextInGroupAndChildColumnsDoesNotContainSpace }.");
            actionCommandDBService.ExecutionStatusText.AppendLine("");
            //await actionCommandDBService.Update( 0);

            string AllowableChar = "abcdefghijklmnopqrstuvwxyz_ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";

            for (int i = 0, count = groupChoiceChildLevelOrderedList.Count; i < count; i++)
            {
                if (i % 200 == 0)
                {
                    actionCommandDBService.ExecutionStatusText.AppendLine($"{ CultureServicesRes.Checking} ... { CultureServicesRes.ThatGroup} { groupChoiceChildLevelOrderedList[i].Group } ---- { CultureServicesRes.ShouldOnlyContainCharactersLike } [{ AllowableChar }]");
                    actionCommandDBService.ExecutionStatusText.AppendLine("");
                    //await actionCommandDBService.Update( 0);
                }

                foreach (char c in groupChoiceChildLevelOrderedList[i].Group)
                {
                    if (!AllowableChar.Contains(c))
                    {
                        actionCommandDBService.ErrorText.AppendLine($"{ CultureServicesRes.Group} --- { groupChoiceChildLevelOrderedList[i].Group } ---- { CultureServicesRes.ShouldNotContain } [{ c }]. { CultureServicesRes.AllowableCharactersAre } [{ AllowableChar }]");
                        actionCommandDBService.ErrorText.AppendLine("");
                        actionCommandDBService.PercentCompleted = 0;
                        await actionCommandDBService.Update();

                        return await Task.FromResult(false);
                    }
                }
                foreach (char c in groupChoiceChildLevelOrderedList[i].Child)
                {
                    if (i % 200 == 0)
                    {
                        actionCommandDBService.ExecutionStatusText.AppendLine($"{ CultureServicesRes.Checking} ... { CultureServicesRes.ThatGroup } { groupChoiceChildLevelOrderedList[i].Child } ---- { CultureServicesRes.ShouldOnlyContainCharactersLike } [{ AllowableChar }]");
                        actionCommandDBService.ExecutionStatusText.AppendLine("");
                        //await actionCommandDBService.Update( 0);
                    }

                    if (!AllowableChar.Contains(c))
                    {
                        actionCommandDBService.ErrorText.AppendLine($"{ CultureServicesRes.Child } --- { groupChoiceChildLevelOrderedList[i].Child } ---- { CultureServicesRes.ShouldNotContain} [{ c }]. { CultureServicesRes.AllowableCharactersAre } [{ AllowableChar }]");
                        actionCommandDBService.ErrorText.AppendLine("");
                        actionCommandDBService.PercentCompleted = 0;
                        await actionCommandDBService.Update();

                        return await Task.FromResult(false);
                    }
                }
            }

            actionCommandDBService.ExecutionStatusText.AppendLine($"{ CultureServicesRes.AllTextInGroupAndChildColumnsDoesNotContainSpace }.");
            actionCommandDBService.ExecutionStatusText.AppendLine("");
            //await actionCommandDBService.Update( 0);

            for (int i = 0, count = groupChoiceChildLevelOrderedList.Count; i < count; i++)
            {
                if (!string.IsNullOrWhiteSpace(groupChoiceChildLevelOrderedList[i].Group))
                {
                    if (i % 200 == 0)
                    {
                        actionCommandDBService.ExecutionStatusText.AppendLine($"{ CultureServicesRes.Checking} ... { CultureServicesRes.ThatCSSPID } { groupChoiceChildLevelOrderedList[i].Group } ---- { CultureServicesRes.DoesNotContainSpace }");
                        actionCommandDBService.ExecutionStatusText.AppendLine("");
                        //await actionCommandDBService.Update( 0);
                    }

                    if (groupChoiceChildLevelOrderedList[i].CSSPID.Contains(" "))
                    {
                        actionCommandDBService.ErrorText.AppendLine($"{ CultureServicesRes.CSSPID } --- { groupChoiceChildLevelOrderedList[i].Group } ---- { CultureServicesRes.ShouldNotContainSpace }");
                        actionCommandDBService.ErrorText.AppendLine("");
                        actionCommandDBService.PercentCompleted = 0;
                        await actionCommandDBService.Update();

                        return await Task.FromResult(false);
                    }
                }
                if (!string.IsNullOrWhiteSpace(groupChoiceChildLevelOrderedList[i].Child))
                {
                    if (i % 200 == 0)
                    {
                        actionCommandDBService.ExecutionStatusText.AppendLine($"{ CultureServicesRes.Checking} ... { CultureServicesRes.ThatCSSPID } { groupChoiceChildLevelOrderedList[i].Child } ---- { CultureServicesRes.DoesNotContainSpace }");
                        actionCommandDBService.ExecutionStatusText.AppendLine("");
                        //await actionCommandDBService.Update( 0);
                    }

                    if (groupChoiceChildLevelOrderedList[i].CSSPID.Contains(" "))
                    {
                        actionCommandDBService.ErrorText.AppendLine($"{ CultureServicesRes.CSSPID } --- { groupChoiceChildLevelOrderedList[i].Child } ---- { CultureServicesRes.ShouldNotContainSpace }");
                        actionCommandDBService.ErrorText.AppendLine("");
                        actionCommandDBService.PercentCompleted = 0;
                        await actionCommandDBService.Update();

                        return await Task.FromResult(false);
                    }
                }

            }

            actionCommandDBService.ExecutionStatusText.AppendLine($"{ CultureServicesRes.AllTextInCSSPIDColumnDoesNotContainSpace }.");
            actionCommandDBService.ExecutionStatusText.AppendLine("");
            //await actionCommandDBService.Update( 0);

            List<string> UniqueCSSPIDList = new List<string>();
            for (int i = 0, count = groupChoiceChildLevelOrderedList.Count; i < count; i++)
            {
                if (!string.IsNullOrWhiteSpace(groupChoiceChildLevelOrderedList[i].Group))
                {
                    if (i % 200 == 0)
                    {
                        actionCommandDBService.ExecutionStatusText.AppendLine($"{ CultureServicesRes.Checking} ... { CultureServicesRes.ThatGroupCSSPID } { groupChoiceChildLevelOrderedList[i].Group } ---- { CultureServicesRes.IsUnique }.");
                        actionCommandDBService.ExecutionStatusText.AppendLine("");
                        //await actionCommandDBService.Update( 0);
                    }

                    if (string.IsNullOrWhiteSpace(groupChoiceChildLevelOrderedList[i].CSSPID))
                    {
                        actionCommandDBService.ErrorText.AppendLine($"{ CultureServicesRes.Group} --- { groupChoiceChildLevelOrderedList[i].Group } ---- { CultureServicesRes.RequiredAUniqueNumberInFirstColumn }.");
                        actionCommandDBService.ErrorText.AppendLine("");
                        actionCommandDBService.PercentCompleted = 0;
                        await actionCommandDBService.Update();

                        return await Task.FromResult(false);
                    }
                }
                if (!string.IsNullOrWhiteSpace(groupChoiceChildLevelOrderedList[i].Child))
                {
                    if (i % 200 == 0)
                    {
                        actionCommandDBService.ExecutionStatusText.AppendLine($"{ CultureServicesRes.Checking} ... { CultureServicesRes.ThatGroupCSSPID } { groupChoiceChildLevelOrderedList[i].Child } ---- { CultureServicesRes.IsUnique }.");
                        actionCommandDBService.ExecutionStatusText.AppendLine("");
                        //await actionCommandDBService.Update( 0);
                    }

                    if (string.IsNullOrWhiteSpace(groupChoiceChildLevelOrderedList[i].CSSPID))
                    {
                        actionCommandDBService.ErrorText.AppendLine($"{ CultureServicesRes.Child } --- { groupChoiceChildLevelOrderedList[i].Child } ---- { CultureServicesRes.RequiredAUniqueNumberInFirstColumn }");
                        actionCommandDBService.ErrorText.AppendLine("");
                        actionCommandDBService.PercentCompleted = 0;
                        await actionCommandDBService.Update();

                        return await Task.FromResult(false);
                    }
                }

                if (i % 200 == 0)
                {
                    actionCommandDBService.ExecutionStatusText.AppendLine($"{ CultureServicesRes.Checking} ... { CultureServicesRes.ThatCSSPID } { groupChoiceChildLevelOrderedList[i].Child } ---- { CultureServicesRes.IsNotEmpty }.");
                    actionCommandDBService.ExecutionStatusText.AppendLine("");
                    //await actionCommandDBService.Update( 0);
                }

                if (string.IsNullOrWhiteSpace(groupChoiceChildLevelOrderedList[i].CSSPID))
                {
                    actionCommandDBService.ErrorText.AppendLine($"{ CultureServicesRes.CSSPIDIsRequiredForGroupOrChild } [{ (groupChoiceChildLevelOrderedList[i].Choice.Length > 0 ? groupChoiceChildLevelOrderedList[i].Choice : groupChoiceChildLevelOrderedList[i].Group) }]");
                    actionCommandDBService.ErrorText.AppendLine("");
                    actionCommandDBService.PercentCompleted = 0;
                    await actionCommandDBService.Update();

                    return await Task.FromResult(false);
                }

                actionCommandDBService.ExecutionStatusText.AppendLine($"{ CultureServicesRes.Checking } ... { CultureServicesRes.ThatCSSPID } { groupChoiceChildLevelOrderedList[i].Child } ---- { CultureServicesRes.IsUnique }.");
                actionCommandDBService.ExecutionStatusText.AppendLine("");
                //await actionCommandDBService.Update( 0);

                if (UniqueCSSPIDList.Contains(groupChoiceChildLevelOrderedList[i].CSSPID))
                {
                    actionCommandDBService.ErrorText.AppendLine($"{ CultureServicesRes.CSSPID } [{ groupChoiceChildLevelOrderedList[i].CSSPID }] { CultureServicesRes.IsNotUnique }");
                    actionCommandDBService.ErrorText.AppendLine("");
                    actionCommandDBService.PercentCompleted = 0;
                    await actionCommandDBService.Update();

                    return await Task.FromResult(false);
                }

                UniqueCSSPIDList.Add(groupChoiceChildLevelOrderedList[i].CSSPID);

                if (i % 200 == 0)
                {
                    actionCommandDBService.ExecutionStatusText.AppendLine($"{ CultureServicesRes.Checking } ... { CultureServicesRes.ThatEachHideCellWithInformationContainsValidChildID }, { CultureServicesRes.CSSPIDAreNotDupliate }, { CultureServicesRes.CSSPIDWithDashAreWellFormed }.");
                    actionCommandDBService.ExecutionStatusText.AppendLine("");
                    //await actionCommandDBService.Update( 0);
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
                                    actionCommandDBService.ErrorText.AppendLine($"{ CultureServicesRes.CSSPID } [{ groupChoiceChildLevelOrderedList[i].CSSPID }] { CultureServicesRes.HideCellContains } [{ childCSSPID }] { CultureServicesRes.PleaseRemoveADash }");
                                    actionCommandDBService.ErrorText.AppendLine("");
                                    actionCommandDBService.PercentCompleted = 0;
                                    await actionCommandDBService.Update();

                                    return await Task.FromResult(false);
                                }

                                foreach (char s in childCSSPID)
                                {
                                    if (!NumberAndDashOnlyList.Contains(s.ToString()))
                                    {
                                        actionCommandDBService.ErrorText.AppendLine($"{ CultureServicesRes.CSSPID} [{ groupChoiceChildLevelOrderedList[i].CSSPID }] { CultureServicesRes.HideCellContains } [{ childCSSPID }]. { CultureServicesRes.AllowableCharactersAre } [{ String.Join(",", NumberAndDashOnlyList) }]");
                                        actionCommandDBService.ErrorText.AppendLine("");
                                        actionCommandDBService.PercentCompleted = 0;
                                        await actionCommandDBService.Update();

                                        return await Task.FromResult(false);
                                    }
                                }

                                fromCSSPID = int.Parse(childCSSPID.Substring(0, childCSSPID.IndexOf("-")));
                                int endPos = childCSSPID.IndexOf("-") + 1;
                                if (childCSSPID.Length <= endPos)
                                {
                                    actionCommandDBService.ErrorText.AppendLine($"{ CultureServicesRes.CSSPID } [{ groupChoiceChildLevelOrderedList[i].CSSPID }] { CultureServicesRes.HideCellContains } [{ childCSSPID }] { CultureServicesRes.MissingEndValue }");
                                    actionCommandDBService.ErrorText.AppendLine("");
                                    actionCommandDBService.PercentCompleted = 0;
                                    await actionCommandDBService.Update();

                                    return await Task.FromResult(false);
                                }

                                toCSSPID = int.Parse(childCSSPID.Substring(endPos));

                                if (fromCSSPID >= toCSSPID)
                                {
                                    actionCommandDBService.ErrorText.AppendLine($"{ CultureServicesRes.CSSPID } [{ groupChoiceChildLevelOrderedList[i].CSSPID }] { CultureServicesRes.HideCellContains } [{ childCSSPID }] { CultureServicesRes.WhichTheFirstValueIs } >= { CultureServicesRes.ThanTheLastValue }");
                                    actionCommandDBService.ErrorText.AppendLine("");
                                    actionCommandDBService.PercentCompleted = 0;
                                    await actionCommandDBService.Update();

                                    return await Task.FromResult(false);
                                }
                            }

                            if (fromCSSPID != -1)
                            {
                                for (int id = fromCSSPID; id <= toCSSPID; id++)
                                {
                                    if (CSSPIDList2.Contains(id.ToString()) || CSSPIDList.Contains(id.ToString()))
                                    {
                                        actionCommandDBService.ErrorText.AppendLine($"{ CultureServicesRes.CSSPID } [{ groupChoiceChildLevelOrderedList[i].CSSPID }] { CultureServicesRes.HideCellContains } [{ childCSSPID }] { CultureServicesRes.WhichWillDuplicate } [{ id.ToString() }]");
                                        actionCommandDBService.ErrorText.AppendLine("");
                                        actionCommandDBService.PercentCompleted = 0;
                                        await actionCommandDBService.Update();

                                        return await Task.FromResult(false);
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
                                actionCommandDBService.ErrorText.AppendLine($"{ CultureServicesRes.CSSPID } [{ groupChoiceChildLevelOrderedList[i].CSSPID }] { CultureServicesRes.HideCellHasDuplicate } [{ csspID }]");
                                actionCommandDBService.ErrorText.AppendLine("");
                                actionCommandDBService.PercentCompleted = 0;
                                await actionCommandDBService.Update();

                                return await Task.FromResult(false);
                            }
                            oldCSSPID = csspID;
                        }
                        foreach (string childCSSPID in CSSPIDList)
                        {
                            GroupChoiceChildLevel groupChoiceChildLevelChild = groupChoiceChildLevelOrderedList.Where(c => c.CSSPID == childCSSPID).FirstOrDefault();
                            if (groupChoiceChildLevelChild == null)
                            {
                                actionCommandDBService.ErrorText.AppendLine($"{ CultureServicesRes.CSSPID } [{ groupChoiceChildLevelOrderedList[i].CSSPID }] { CultureServicesRes.HideCellContainsID } [{ childCSSPID.ToString() }] { CultureServicesRes.WhichDoesNotExist }");
                                actionCommandDBService.ErrorText.AppendLine("");
                                actionCommandDBService.PercentCompleted = 0;
                                await actionCommandDBService.Update();

                                return await Task.FromResult(false);
                            }
                            string startCSSPID = $"{ childCSSPID.Substring(0, 3) }00";

                            GroupChoiceChildLevel groupChoiceChildLevel = groupChoiceChildLevelOrderedList.Where(c => c.CSSPID == startCSSPID).FirstOrDefault();

                            if (groupChoiceChildLevel == null)
                            {
                                actionCommandDBService.ErrorText.AppendLine($"{ CultureServicesRes.CSSPID } [{ groupChoiceChildLevelOrderedList[i].CSSPID }] { CultureServicesRes.GroupChoiceChildLevelIsNullForStartCSSPID } [{ startCSSPID.ToString() }]");
                                actionCommandDBService.ErrorText.AppendLine("");
                                actionCommandDBService.PercentCompleted = 0;
                                await actionCommandDBService.Update();

                                return await Task.FromResult(false);
                            }

                            string group = groupChoiceChildLevel.Group;
                            if (groupChoiceChildLevelOrderedList[i].Child != group)
                            {
                                actionCommandDBService.ErrorText.AppendLine($"{ CultureServicesRes.CSSPID } [{ groupChoiceChildLevelOrderedList[i].CSSPID }] { CultureServicesRes.HideCellContainsID } [{ childCSSPID.ToString() }] { CultureServicesRes.WhichIsNotADirectChild }");
                                actionCommandDBService.ErrorText.AppendLine("");
                                actionCommandDBService.PercentCompleted = 0;
                                await actionCommandDBService.Update();

                                return await Task.FromResult(false);
                            }
                        }
                        if (CSSPIDList.Count > 0)
                        {
                            string childCSSPID = CSSPIDList[0];

                            GroupChoiceChildLevel groupChoiceChildLevelChild = groupChoiceChildLevelOrderedList.Where(c => c.CSSPID == childCSSPID).FirstOrDefault();
                            if (groupChoiceChildLevelChild == null)
                            {
                                actionCommandDBService.ErrorText.AppendLine($"{ CultureServicesRes.CSSPID } [{ groupChoiceChildLevelOrderedList[i].CSSPID }] { CultureServicesRes.HideCellContainsID } [{ childCSSPID.ToString() }] { CultureServicesRes.WhichDoesNotExist}");
                                actionCommandDBService.ErrorText.AppendLine("");
                                actionCommandDBService.PercentCompleted = 0;
                                await actionCommandDBService.Update();

                                return await Task.FromResult(false);
                            }
                            string start3CharCSSPID = $"{ childCSSPID.Substring(0, 3) }";

                            int CountChild = groupChoiceChildLevelOrderedList.Where(c => c.CSSPID.StartsWith(start3CharCSSPID) && !c.CSSPID.EndsWith("00")).Count();

                            if (CSSPIDList.Count == CountChild)
                            {
                                actionCommandDBService.ErrorText.AppendLine($"{ CultureServicesRes.CSSPID } [{ groupChoiceChildLevelOrderedList[i].CSSPID }] { CultureServicesRes.IsHidingAllPossibleSelection }");
                                actionCommandDBService.ErrorText.AppendLine("");
                                actionCommandDBService.PercentCompleted = 0;
                                await actionCommandDBService.Update();

                                return await Task.FromResult(false);

                            }
                        }
                    }
                }
            }

            actionCommandDBService.ExecutionStatusText.AppendLine($"{ CultureServicesRes.AllGroupsAndChoicesColumnsHaveAUniqueCSSPID }.");
            actionCommandDBService.ExecutionStatusText.AppendLine("");

            actionCommandDBService.ExecutionStatusText.AppendLine($"{ CultureServicesRes.AllHideColumnsWithInformationHasValidCSSPIDIEExistAndIsChild }.");
            actionCommandDBService.ExecutionStatusText.AppendLine("");

            actionCommandDBService.ExecutionStatusText.AppendLine($"{ CultureServicesRes.EverythingIsOK }.");
            actionCommandDBService.ExecutionStatusText.AppendLine("");
            //await actionCommandDBService.Update( 0);

            return await Task.FromResult(true);
        }
    }
}
