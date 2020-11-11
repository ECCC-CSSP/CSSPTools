using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using PolSourceGroupingExcelFileReadServices.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PolSourceGroupingExcelFileReadServices.Services
{
    public partial class PolSourceGroupingExcelFileReadService
    {
        private async Task<bool> CheckSpreadsheet()
        {
            if (GroupChoiceChildLevelList.Count == 0)
            {
                return await Task.FromResult(false);
            }

            // Checking child exist
            List<string> childList = (from c in GroupChoiceChildLevelList
                                      where c.Child.Length > 0
                                      select c.Child).Distinct().ToList();

            int countChild = 0;
            foreach (string child in childList)
            {
                countChild += 1;

                if (countChild % 200 == 0)
                {
                    Console.WriteLine($"Checking ... That { child } Exist On Column Group");
                    //await actionCommandDBService.Update( 0);
                }

                GroupChoiceChildLevel groupChoiceChildLevelExist = (from c in GroupChoiceChildLevelList
                                                                    where c.Group == child
                                                                    select c).FirstOrDefault();

                if (groupChoiceChildLevelExist == null)
                {
                    Console.WriteLine($"{ child } ----- Does Not Exist On Column Group");
                    Console.WriteLine("");

                    return await Task.FromResult(false);
                }
            }

            Console.WriteLine($"All Child Do Exist On Column Group");
            Console.WriteLine("");
            //await actionCommandDBService.Update( 0);

            foreach (GroupChoiceChildLevel groupChoiceChildLevel in GroupChoiceChildLevelList)
            {
                if (groupChoiceChildLevel.Group.Length < 5)
                {
                    Console.WriteLine($"Group: { groupChoiceChildLevel.CSSPID } Potential Empty Row Above.");
                    Console.WriteLine("");

                    return await Task.FromResult(false);
                }
            }

            // Checking EN and FR text exist for Group ending with Start
            List<GroupChoiceChildLevel> groupChoiceChildLevelGroupList = (from c in GroupChoiceChildLevelList
                                                                          where c.Group.Substring(c.Group.Length - 5) == "Start"
                                                                          select c).Distinct().ToList();

            countChild = 0;
            foreach (GroupChoiceChildLevel groupChoiceChildLevel in groupChoiceChildLevelGroupList)
            {
                countChild += 1;

                if (countChild % 200 == 0)
                {
                    Console.WriteLine($"Checking ... That Group { groupChoiceChildLevel.Group }--- EN/FR: { groupChoiceChildLevel.EN } Has EN FR Text");
                    //await actionCommandDBService.Update( 0);
                }

                if (string.IsNullOrWhiteSpace(groupChoiceChildLevel.EN))
                {
                    Console.WriteLine($"Group: { groupChoiceChildLevel.Group } --- EN: { groupChoiceChildLevel.EN } ----- Does Not Have En Text");
                    Console.WriteLine("");

                    return await Task.FromResult(false);
                }

                countChild += 1;

                if (string.IsNullOrWhiteSpace(groupChoiceChildLevel.FR))
                {
                    Console.WriteLine($"Group: { groupChoiceChildLevel.Group } --- EN: { groupChoiceChildLevel.FR } ----- Does Not Have FR Text");
                    Console.WriteLine("");

                    return await Task.FromResult(false);
                }

            }

            Console.WriteLine($"Each Group With Ending Name = 'Start' Does Have EN and FR Text.");
            Console.WriteLine("");
            //await actionCommandDBService.Update( 0);

            // Checking DescEN and DescFR text exist for Group ending with Start
            List<GroupChoiceChildLevel> groupChoiceChildLevelGroupDescList = (from c in GroupChoiceChildLevelList
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
                        Console.WriteLine($"Checking ... That Group { groupChoiceChildLevel.Group } --- EN/FR: { groupChoiceChildLevel.EN } Has Desc EN Desc FR Text");
                        Console.WriteLine("");
                        //await actionCommandDBService.Update( 0);
                    }

                    if (string.IsNullOrWhiteSpace(groupChoiceChildLevel.DescEN))
                    {
                        Console.WriteLine($"Group: { groupChoiceChildLevel.Group } --- EN: { groupChoiceChildLevel.EN } ----- Does Not Have Desc EN Text");
                        Console.WriteLine("");

                        return await Task.FromResult(false);
                    }

                    if (string.IsNullOrWhiteSpace(groupChoiceChildLevel.DescFR))
                    {
                        Console.WriteLine($"Group: { groupChoiceChildLevel.Group } --- FR: { groupChoiceChildLevel.FR } ----- Does Not Have Desc FR Text");
                        Console.WriteLine("");

                        return await Task.FromResult(false);
                    }
                }
            }

            Console.WriteLine($"Each Group With Ending Name = 'Start' Does Have Desc EN and Desc FR Text.");
            Console.WriteLine("");
            //await actionCommandDBService.Update( 0);

            // Checking EN and FR text exist for Choice.Length > 0
            List<GroupChoiceChildLevel> groupChoiceChildLevelChoiceList = (from c in GroupChoiceChildLevelList
                                                                           where c.Choice.Length > 0
                                                                           select c).Distinct().ToList();

            countChild = 0;
            foreach (GroupChoiceChildLevel groupChoiceChildLevel in groupChoiceChildLevelChoiceList)
            {
                countChild += 1;

                if (countChild % 200 == 0)
                {
                    Console.WriteLine($"Checking ... That Group { groupChoiceChildLevel.Group } --- EN/FR: { groupChoiceChildLevel.EN } Has EN FR Text");
                    Console.WriteLine("");
                    //await actionCommandDBService.Update( 0);
                }

                if (string.IsNullOrWhiteSpace(groupChoiceChildLevel.EN))
                {
                    Console.WriteLine($"Group: { groupChoiceChildLevel.Group } --- EN: { groupChoiceChildLevel.EN } ----- Does Not Have En Text");
                    Console.WriteLine("");

                    return await Task.FromResult(false);
                }

                if (string.IsNullOrWhiteSpace(groupChoiceChildLevel.FR))
                {
                    Console.WriteLine($"Group: { groupChoiceChildLevel.Group } --- FR: { groupChoiceChildLevel.FR } ----- Does Not Have FR Text");
                    Console.WriteLine("");

                    return await Task.FromResult(false);
                }

            }

            Console.WriteLine($"Each Choice Does Have EN and FR Text.");
            Console.WriteLine("");
            //await actionCommandDBService.Update( 0);

            // Checking ReportEN and ReportFR text exist for Child.Length > 0
            groupChoiceChildLevelChoiceList = (from c in GroupChoiceChildLevelList
                                               where c.Child.Length > 0
                                               select c).Distinct().ToList();

            countChild = 0;
            foreach (GroupChoiceChildLevel groupChoiceChildLevel in groupChoiceChildLevelChoiceList)
            {
                countChild += 1;

                if (countChild % 200 == 0)
                {
                    Console.WriteLine($"Checking ... That Group { groupChoiceChildLevel.Group } --- EN/FR: { groupChoiceChildLevel.EN } Has Report EN Report FR Text. You can add a space to fix the problem.");
                    Console.WriteLine("");
                    //await actionCommandDBService.Update( 0);
                }

                if (string.IsNullOrWhiteSpace(groupChoiceChildLevel.ReportEN) && groupChoiceChildLevel.ReportEN.Length == 0)
                {
                    Console.WriteLine($"Group: { groupChoiceChildLevel.Group } --- EN: { groupChoiceChildLevel.EN } ----- Does not have Report EN Text. You can add a space to fix the problem.");
                    Console.WriteLine("");

                    return await Task.FromResult(false);
                }

                if (string.IsNullOrWhiteSpace(groupChoiceChildLevel.ReportFR) && groupChoiceChildLevel.ReportFR.Length == 0)
                {
                    Console.WriteLine($"Group: { groupChoiceChildLevel.Group } --- FR: { groupChoiceChildLevel.FR } ----- Does not have Report FR Text. You can add a space to fix the problem.");
                    Console.WriteLine("");

                    return await Task.FromResult(false);
                }

            }

            Console.WriteLine($"Each choice does have report EN and Report FR Text.");
            Console.WriteLine("");
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
                                                            Console.WriteLine($"{ fi.FullName } Pol Source Grouping { item.Text } Is not equal to { FieldNameList[cellcount] }");
                                                            Console.WriteLine("");

                                                            return await Task.FromResult(false);
                                                        }
                                                    }
                                                    else if (item.InnerText != null)
                                                    {
                                                        currentcellvalue = item.InnerText;
                                                        if (currentcellvalue != FieldNameList[cellcount])
                                                        {
                                                            Console.WriteLine($"{ fi.FullName } Pol Source Grouping { item.Text } Is not equal to { FieldNameList[cellcount] }");
                                                            Console.WriteLine("");

                                                            return await Task.FromResult(false);
                                                        }
                                                    }
                                                    else if (item.InnerXml != null)
                                                    {
                                                        currentcellvalue = item.InnerXml;
                                                        if (currentcellvalue != FieldNameList[cellcount])
                                                        {
                                                            Console.WriteLine($"{ fi.FullName } Pol Source Grouping { item.Text } Is not equal to  { FieldNameList[cellcount] }");
                                                            Console.WriteLine("");

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
                                                Console.WriteLine($"{ fi.FullName } Pol Source Grouping { (thecurrentcell.InnerText + " ") } Is not equal to { FieldNameList[cellcount] }");
                                                Console.WriteLine("");

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
                                        Console.WriteLine($"Reading spreadsheet ... { rowCount }");
                                        Console.WriteLine("");
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
                Console.WriteLine($"{ ex.Message }");
                Console.WriteLine("");

                return await Task.FromResult(false);
            }

            List<GroupChoiceChildLevel> groupChoiceChildLevelOrderedList = (from c in groupChoiceChildLevelStraitList
                                                                            orderby c.Group
                                                                            select c).ToList();

            for (int i = 0, count = groupChoiceChildLevelOrderedList.Count; i < (count - 1); i++)
            {
                if (i % 200 == 0)
                {
                    Console.WriteLine($"Checking ... That Group { groupChoiceChildLevelOrderedList[i].Group } ---- Has no duplicates");
                    Console.WriteLine("");
                    //await actionCommandDBService.Update( 0);
                }

                if (groupChoiceChildLevelOrderedList[i].Group == groupChoiceChildLevelOrderedList[i + 1].Group)
                {
                    Console.WriteLine($"{ groupChoiceChildLevelOrderedList[i].Group } ---- Has duplicates");
                    Console.WriteLine("");

                    return await Task.FromResult(false);
                }
            }

            Console.WriteLine($"Column group does not have duplicates.");
            Console.WriteLine("");
            //await actionCommandDBService.Update( 0);

            for (int i = 0, count = groupChoiceChildLevelOrderedList.Count; i < count; i++)
            {
                if (!string.IsNullOrWhiteSpace(groupChoiceChildLevelOrderedList[i].Group))
                {
                    if (i % 200 == 0)
                    {
                        Console.WriteLine($"Checking ... That Group { groupChoiceChildLevelOrderedList[i].Group } ---- should not contain space");
                        Console.WriteLine("");
                        //await actionCommandDBService.Update( 0);
                    }

                    if (groupChoiceChildLevelOrderedList[i].Group.Contains(" "))
                    {
                        Console.WriteLine($"Group --- { groupChoiceChildLevelOrderedList[i].Group } ---- Should not  contain space");
                        Console.WriteLine("");

                        return await Task.FromResult(false);
                    }
                }
                if (!string.IsNullOrWhiteSpace(groupChoiceChildLevelOrderedList[i].Child))
                {
                    if (i % 200 == 0)
                    {
                        Console.WriteLine($"Checking ... that group { groupChoiceChildLevelOrderedList[i].Child } ---- Should not  contain space");
                        Console.WriteLine("");
                        //await actionCommandDBService.Update( 0);
                    }

                    if (groupChoiceChildLevelOrderedList[i].Child.Contains(" "))
                    {
                        Console.WriteLine($"Child --- { groupChoiceChildLevelOrderedList[i].Child } ---- should not contain space");
                        Console.WriteLine("");

                        return await Task.FromResult(false);
                    }
                }

            }

            Console.WriteLine($"All text in group and chile column does not contain space.");
            Console.WriteLine("");
            //await actionCommandDBService.Update( 0);

            string AllowableChar = "abcdefghijklmnopqrstuvwxyz_ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";

            for (int i = 0, count = groupChoiceChildLevelOrderedList.Count; i < count; i++)
            {
                if (i % 200 == 0)
                {
                    Console.WriteLine($"Checking ... that group { groupChoiceChildLevelOrderedList[i].Group } ---- should only contain characters like [{ AllowableChar }]");
                    Console.WriteLine("");
                    //await actionCommandDBService.Update( 0);
                }

                foreach (char c in groupChoiceChildLevelOrderedList[i].Group)
                {
                    if (!AllowableChar.Contains(c))
                    {
                        Console.WriteLine($"Group --- { groupChoiceChildLevelOrderedList[i].Group } ---- should not contain [{ c }]. Allowable characters are [{ AllowableChar }]");
                        Console.WriteLine("");

                        return await Task.FromResult(false);
                    }
                }
                foreach (char c in groupChoiceChildLevelOrderedList[i].Child)
                {
                    if (i % 200 == 0)
                    {
                        Console.WriteLine($"Checking ... That Group { groupChoiceChildLevelOrderedList[i].Child } ---- should only contain characters like [{ AllowableChar }]");
                        Console.WriteLine("");
                        //await actionCommandDBService.Update( 0);
                    }

                    if (!AllowableChar.Contains(c))
                    {
                        Console.WriteLine($"Child --- { groupChoiceChildLevelOrderedList[i].Child } ---- should not contain [{ c }]. Allowable characters are [{ AllowableChar }]");
                        Console.WriteLine("");

                        return await Task.FromResult(false);
                    }
                }
            }

            Console.WriteLine($"All text in group and chile column does not contain space.");
            Console.WriteLine("");
            //await actionCommandDBService.Update( 0);

            for (int i = 0, count = groupChoiceChildLevelOrderedList.Count; i < count; i++)
            {
                if (!string.IsNullOrWhiteSpace(groupChoiceChildLevelOrderedList[i].Group))
                {
                    if (i % 200 == 0)
                    {
                        Console.WriteLine($"Checking ... That CSSPID { groupChoiceChildLevelOrderedList[i].Group } ---- does not contain space");
                        Console.WriteLine("");
                        //await actionCommandDBService.Update( 0);
                    }

                    if (groupChoiceChildLevelOrderedList[i].CSSPID.Contains(" "))
                    {
                        Console.WriteLine($"CSSPID --- { groupChoiceChildLevelOrderedList[i].Group } ---- should not contain space");
                        Console.WriteLine("");

                        return await Task.FromResult(false);
                    }
                }
                if (!string.IsNullOrWhiteSpace(groupChoiceChildLevelOrderedList[i].Child))
                {
                    if (i % 200 == 0)
                    {
                        Console.WriteLine($"Checking ... That CSSPID { groupChoiceChildLevelOrderedList[i].Child } ---- does not contain space");
                        Console.WriteLine("");
                        //await actionCommandDBService.Update( 0);
                    }

                    if (groupChoiceChildLevelOrderedList[i].CSSPID.Contains(" "))
                    {
                        Console.WriteLine($"CSSPID --- { groupChoiceChildLevelOrderedList[i].Child } ---- should not contain space");
                        Console.WriteLine("");

                        return await Task.FromResult(false);
                    }
                }

            }

            Console.WriteLine($"All text in CSSPID column does not contain space.");
            Console.WriteLine("");
            //await actionCommandDBService.Update( 0);

            List<string> UniqueCSSPIDList = new List<string>();
            for (int i = 0, count = groupChoiceChildLevelOrderedList.Count; i < count; i++)
            {
                if (!string.IsNullOrWhiteSpace(groupChoiceChildLevelOrderedList[i].Group))
                {
                    if (i % 200 == 0)
                    {
                        Console.WriteLine($"Checking ... That group CSSPID { groupChoiceChildLevelOrderedList[i].Group } ---- is unique.");
                        Console.WriteLine("");
                        //await actionCommandDBService.Update( 0);
                    }

                    if (string.IsNullOrWhiteSpace(groupChoiceChildLevelOrderedList[i].CSSPID))
                    {
                        Console.WriteLine($"Group --- { groupChoiceChildLevelOrderedList[i].Group } ---- required a unique number in first column.");
                        Console.WriteLine("");

                        return await Task.FromResult(false);
                    }
                }
                if (!string.IsNullOrWhiteSpace(groupChoiceChildLevelOrderedList[i].Child))
                {
                    if (i % 200 == 0)
                    {
                        Console.WriteLine($"Checking ... That group CSSPID { groupChoiceChildLevelOrderedList[i].Child } ---- is unique.");
                        Console.WriteLine("");
                        //await actionCommandDBService.Update( 0);
                    }

                    if (string.IsNullOrWhiteSpace(groupChoiceChildLevelOrderedList[i].CSSPID))
                    {
                        Console.WriteLine($"Child --- { groupChoiceChildLevelOrderedList[i].Child } ---- required a unique number in first column");
                        Console.WriteLine("");

                        return await Task.FromResult(false);
                    }
                }

                if (i % 200 == 0)
                {
                    Console.WriteLine($"Checking ... That CSSPID { groupChoiceChildLevelOrderedList[i].Child } ---- is not empty.");
                    Console.WriteLine("");
                    //await actionCommandDBService.Update( 0);
                }

                if (string.IsNullOrWhiteSpace(groupChoiceChildLevelOrderedList[i].CSSPID))
                {
                    Console.WriteLine($"CSSPID is required for group or child [{ (groupChoiceChildLevelOrderedList[i].Choice.Length > 0 ? groupChoiceChildLevelOrderedList[i].Choice : groupChoiceChildLevelOrderedList[i].Group) }]");
                    Console.WriteLine("");

                    return await Task.FromResult(false);
                }

                Console.WriteLine($"Checking ... That CSSPID { groupChoiceChildLevelOrderedList[i].Child } ---- is unique.");
                Console.WriteLine("");
                //await actionCommandDBService.Update( 0);

                if (UniqueCSSPIDList.Contains(groupChoiceChildLevelOrderedList[i].CSSPID))
                {
                    Console.WriteLine($"CSSPID [{ groupChoiceChildLevelOrderedList[i].CSSPID }] is not unique");
                    Console.WriteLine("");

                    return await Task.FromResult(false);
                }

                UniqueCSSPIDList.Add(groupChoiceChildLevelOrderedList[i].CSSPID);

                if (i % 200 == 0)
                {
                    Console.WriteLine($"Checking ... That each hide cell with information contains valid child ID, CSSPID are not duplicate, CSSPID with dash are well formed.");
                    Console.WriteLine("");
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
                                    Console.WriteLine($"CSSPID [{ groupChoiceChildLevelOrderedList[i].CSSPID }] Hide Cell Contains [{ childCSSPID }] Please remove a dash");
                                    Console.WriteLine("");

                                    return await Task.FromResult(false);
                                }

                                foreach (char s in childCSSPID)
                                {
                                    if (!NumberAndDashOnlyList.Contains(s.ToString()))
                                    {
                                        Console.WriteLine($"CSSPID [{ groupChoiceChildLevelOrderedList[i].CSSPID }] Hide Cell Contains [{ childCSSPID }]. Allowable characters are [{ String.Join(",", NumberAndDashOnlyList) }]");
                                        Console.WriteLine("");

                                        return await Task.FromResult(false);
                                    }
                                }

                                fromCSSPID = int.Parse(childCSSPID.Substring(0, childCSSPID.IndexOf("-")));
                                int endPos = childCSSPID.IndexOf("-") + 1;
                                if (childCSSPID.Length <= endPos)
                                {
                                    Console.WriteLine($"CSSPID [{ groupChoiceChildLevelOrderedList[i].CSSPID }] Hide Cell Contains [{ childCSSPID }] Missing End Value");
                                    Console.WriteLine("");

                                    return await Task.FromResult(false);
                                }

                                toCSSPID = int.Parse(childCSSPID.Substring(endPos));

                                if (fromCSSPID >= toCSSPID)
                                {
                                    Console.WriteLine($"CSSPID [{ groupChoiceChildLevelOrderedList[i].CSSPID }] Hide Cell Contains [{ childCSSPID }] Wich The First Value Is >= Than The Last Value");
                                    Console.WriteLine("");

                                    return await Task.FromResult(false);
                                }
                            }

                            if (fromCSSPID != -1)
                            {
                                for (int id = fromCSSPID; id <= toCSSPID; id++)
                                {
                                    if (CSSPIDList2.Contains(id.ToString()) || CSSPIDList.Contains(id.ToString()))
                                    {
                                        Console.WriteLine($"CSSPID [{ groupChoiceChildLevelOrderedList[i].CSSPID }] Hide Cell Contains [{ childCSSPID }] Which Will Duplicate [{ id.ToString() }]");
                                        Console.WriteLine("");

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
                                Console.WriteLine($"CSSPID [{ groupChoiceChildLevelOrderedList[i].CSSPID }] Hide cell has duplicate [{ csspID }]");
                                Console.WriteLine("");

                                return await Task.FromResult(false);
                            }
                            oldCSSPID = csspID;
                        }
                        foreach (string childCSSPID in CSSPIDList)
                        {
                            GroupChoiceChildLevel groupChoiceChildLevelChild = groupChoiceChildLevelOrderedList.Where(c => c.CSSPID == childCSSPID).FirstOrDefault();
                            if (groupChoiceChildLevelChild == null)
                            {
                                Console.WriteLine($"CSSPID [{ groupChoiceChildLevelOrderedList[i].CSSPID }] Hide cell contains ID [{ childCSSPID.ToString() }] which does not exist");
                                Console.WriteLine("");

                                return await Task.FromResult(false);
                            }
                            string startCSSPID = $"{ childCSSPID.Substring(0, 3) }00";

                            GroupChoiceChildLevel groupChoiceChildLevel = groupChoiceChildLevelOrderedList.Where(c => c.CSSPID == startCSSPID).FirstOrDefault();

                            if (groupChoiceChildLevel == null)
                            {
                                Console.WriteLine($"CSSPID [{ groupChoiceChildLevelOrderedList[i].CSSPID }] Group choice child level is null for start CSSPID [{ startCSSPID.ToString() }]");
                                Console.WriteLine("");

                                return await Task.FromResult(false);
                            }

                            string group = groupChoiceChildLevel.Group;
                            if (groupChoiceChildLevelOrderedList[i].Child != group)
                            {
                                Console.WriteLine($"CSSPID [{ groupChoiceChildLevelOrderedList[i].CSSPID }] Hide cell contains ID [{ childCSSPID.ToString() }] which is ot a direct child");
                                Console.WriteLine("");

                                return await Task.FromResult(false);
                            }
                        }
                        if (CSSPIDList.Count > 0)
                        {
                            string childCSSPID = CSSPIDList[0];

                            GroupChoiceChildLevel groupChoiceChildLevelChild = groupChoiceChildLevelOrderedList.Where(c => c.CSSPID == childCSSPID).FirstOrDefault();
                            if (groupChoiceChildLevelChild == null)
                            {
                                Console.WriteLine($"CSSPID [{ groupChoiceChildLevelOrderedList[i].CSSPID }] Hide cell contains ID [{ childCSSPID.ToString() }] which does not exist");
                                Console.WriteLine("");

                                return await Task.FromResult(false);
                            }
                            string start3CharCSSPID = $"{ childCSSPID.Substring(0, 3) }";

                            int CountChild = groupChoiceChildLevelOrderedList.Where(c => c.CSSPID.StartsWith(start3CharCSSPID) && !c.CSSPID.EndsWith("00")).Count();

                            if (CSSPIDList.Count == CountChild)
                            {
                                Console.WriteLine($"CSSPID [{ groupChoiceChildLevelOrderedList[i].CSSPID }] is hiding all possible selection");
                                Console.WriteLine("");

                                return await Task.FromResult(false);

                            }
                        }
                    }
                }
            }

            Console.WriteLine($"All groups and choices column have a unique CSSPID.");
            Console.WriteLine("");

            Console.WriteLine($"All hide column with information has valid CSSPID  i.e. exist and is child.");
            Console.WriteLine("");

            Console.WriteLine($"Everything is OK.");
            Console.WriteLine("");
            //await actionCommandDBService.Update( 0);

            return await Task.FromResult(true);
        }
    }
}
