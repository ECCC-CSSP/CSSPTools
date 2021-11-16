using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPPolSourceGroupingExcelFileRead
{
    public class PolSourceGroupingExcelFileRead
    {
        #region Variables
        private string FullFileName;
        List<string> NumberAndDashOnlyList = new List<string>() { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "-" };
        #endregion Variables

        #region Properties
        public List<GroupChoiceChildLevel> groupChoiceChildLevelList { get; set; }
        #endregion Properties

        #region Constructors
        public PolSourceGroupingExcelFileRead()
        {
        }
        #endregion Constructors

        #region Events
        public delegate void StatusEventHandler(object sender, StatusEventArgs e);
        public delegate void CSSPErrorEventHandler(object sender, CSSPErrorEventArgs e);

        public event StatusEventHandler Status;
        public event CSSPErrorEventHandler CSSPError;

        protected virtual void OnStatus(StatusEventArgs e)
        {
            Status?.Invoke(this, e);
        }
        protected virtual void OnCSSPError(CSSPErrorEventArgs e)
        {
            CSSPError?.Invoke(this, e);
        }

        public class StatusEventArgs : EventArgs
        {
            public string status { get; set; }
        }
        public class CSSPErrorEventArgs : EventArgs
        {
            public string CSSPError { get; set; }
        }
        #endregion Events

        #region Functions
        private bool CheckSpreadsheet()
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
                    OnStatus(new StatusEventArgs() { status = $"Checking ... that { child } exist on Column Group" });
                }

                GroupChoiceChildLevel groupChoiceChildLevelExist = (from c in groupChoiceChildLevelList
                                                                    where c.Group == child
                                                                    select c).FirstOrDefault();

                if (groupChoiceChildLevelExist == null)
                {
                    OnCSSPError(new CSSPErrorEventArgs() { CSSPError = $"{ child } ----- does not exist on Column Group\r\n\r\n" });
                    return false;
                }
            }

            OnCSSPError(new CSSPErrorEventArgs() { CSSPError = "All Child do exist on Column Group\r\n\r\n" });

            foreach (GroupChoiceChildLevel groupChoiceChildLevel in groupChoiceChildLevelList)
            {
                if (groupChoiceChildLevel.Group.Length < 5)
                {
                    OnCSSPError(new CSSPErrorEventArgs() { CSSPError = $"Group: { groupChoiceChildLevel.CSSPID } potential empty row above. \r\n\r\n" });
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
                    OnStatus(new StatusEventArgs() { status = $"Checking ... that group { groupChoiceChildLevel.Group }--- EN/FR: { groupChoiceChildLevel.EN } has EN/FR text" });
                }

                if (string.IsNullOrWhiteSpace(groupChoiceChildLevel.EN))
                {
                    OnCSSPError(new CSSPErrorEventArgs() { CSSPError = $"Group: { groupChoiceChildLevel.Group } --- EN: { groupChoiceChildLevel.EN } ----- does not have EN text\r\n\r\n" });
                    return false;
                }

                countChild += 1;

                if (string.IsNullOrWhiteSpace(groupChoiceChildLevel.FR))
                {
                    OnCSSPError(new CSSPErrorEventArgs() { CSSPError = $"Group: { groupChoiceChildLevel.Group } --- EN: { groupChoiceChildLevel.FR } ----- does not have FR text\r\n\r\n" });
                    return false;
                }

            }

            OnCSSPError(new CSSPErrorEventArgs() { CSSPError = "Each Group with ending name = 'Start' does have EN and FR text.\r\n\r\n" });

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
                        OnStatus(new StatusEventArgs() { status = $"Checking ... that group { groupChoiceChildLevel.Group } --- EN/FR: { groupChoiceChildLevel.EN } has DescEN/DescFR text" });
                    }

                    if (string.IsNullOrWhiteSpace(groupChoiceChildLevel.DescEN))
                    {
                        OnCSSPError(new CSSPErrorEventArgs() { CSSPError = $"Group: { groupChoiceChildLevel.Group } --- EN: { groupChoiceChildLevel.EN } ----- does not have DescEN text\r\n\r\n" });
                        return false;
                    }

                    if (string.IsNullOrWhiteSpace(groupChoiceChildLevel.DescFR))
                    {
                        OnCSSPError(new CSSPErrorEventArgs() { CSSPError = $"Group: { groupChoiceChildLevel.Group } --- EN: { groupChoiceChildLevel.FR } ----- does not have DescFR text\r\n\r\n" });
                        return false;
                    }
                }
            }

            OnCSSPError(new CSSPErrorEventArgs() { CSSPError = "Each Group with ending name = 'Start' does have DescEN and DescFR text.\r\n\r\n" });

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
                    OnStatus(new StatusEventArgs() { status = $"Checking ... that group { groupChoiceChildLevel.Group } --- EN/FR: { groupChoiceChildLevel.EN } has EN/FR text" });
                }

                if (string.IsNullOrWhiteSpace(groupChoiceChildLevel.EN))
                {
                    OnCSSPError(new CSSPErrorEventArgs() { CSSPError = $"Group: { groupChoiceChildLevel.Group } --- EN: { groupChoiceChildLevel.EN } ----- does not have EN text\r\n\r\n" });
                    return false;
                }

                if (string.IsNullOrWhiteSpace(groupChoiceChildLevel.FR))
                {
                    OnCSSPError(new CSSPErrorEventArgs() { CSSPError = $"Group: { groupChoiceChildLevel.Group } --- FR: { groupChoiceChildLevel.FR } ----- does not have FR text\r\n\r\n" });
                    return false;
                }

            }

            OnCSSPError(new CSSPErrorEventArgs() { CSSPError = "Each Choice does have EN and FR text.\r\n\r\n" });

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
                    OnStatus(new StatusEventArgs() { status = $"Checking ... that group { groupChoiceChildLevel.Group } --- EN/FR: { groupChoiceChildLevel.EN } has ReportEN/ReportFR text. You can add a space to fix the problem." });
                }

                if (string.IsNullOrWhiteSpace(groupChoiceChildLevel.ReportEN) && groupChoiceChildLevel.ReportEN.Length == 0)
                {
                    OnCSSPError(new CSSPErrorEventArgs() { CSSPError = $"Group: { groupChoiceChildLevel.Group } --- EN: { groupChoiceChildLevel.EN } ----- does not have ReportEN text. You can add a space to fix the problem.\r\n\r\n" });
                    return false;
                }

                if (string.IsNullOrWhiteSpace(groupChoiceChildLevel.ReportFR) && groupChoiceChildLevel.ReportFR.Length == 0)
                {
                    OnCSSPError(new CSSPErrorEventArgs() { CSSPError = $"Group: { groupChoiceChildLevel.Group } --- FR: { groupChoiceChildLevel.FR } ----- does not have ReportFR text. You can add a space to fix the problem.\r\n\r\n" });
                    return false;
                }

            }

            OnCSSPError(new CSSPErrorEventArgs() { CSSPError = "Each Choice does have ReportEN and ReportFR text.\r\n\r\n" });

            // Checking for duplicates in column Group
            List<GroupChoiceChildLevel> groupChoiceChildLevelStraitList = new List<GroupChoiceChildLevel>();
            OnStatus(new StatusEventArgs() { status = "Each Choice does have ReportEN and ReportFR text.\r\n\r\n" });

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
                                                            OnCSSPError(new CSSPErrorEventArgs() { CSSPError = $"{ fi.FullName } PolSourceGrouping { item.Text } is not equal to { FieldNameList[cellcount] }\r\n" });
                                                            return false;
                                                        }
                                                    }
                                                    else if (item.InnerText != null)
                                                    {
                                                        currentcellvalue = item.InnerText;
                                                        if (currentcellvalue != FieldNameList[cellcount])
                                                        {
                                                            OnCSSPError(new CSSPErrorEventArgs() { CSSPError = $"{ fi.FullName } PolSourceGrouping { item.Text } is not equal to { FieldNameList[cellcount] }\r\n" });
                                                            return false;
                                                        }
                                                    }
                                                    else if (item.InnerXml != null)
                                                    {
                                                        currentcellvalue = item.InnerXml;
                                                        if (currentcellvalue != FieldNameList[cellcount])
                                                        {
                                                            OnCSSPError(new CSSPErrorEventArgs() { CSSPError = $"{ fi.FullName } PolSourceGrouping { item.Text } is not equal to { FieldNameList[cellcount] }\r\n" });
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
                                                OnCSSPError(new CSSPErrorEventArgs() { CSSPError = $"{ fi.FullName } PolSourceGrouping { (thecurrentcell.InnerText + " ") } is not equal to { FieldNameList[cellcount] }\r\n" });
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
                                        OnStatus(new StatusEventArgs() { status = $"Reading spreadsheet ... { rowCount }" });
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
                OnCSSPError(new CSSPErrorEventArgs() { CSSPError = $"{ ex.Message }" });
                return false;
            }

            #region Old Text
            //string connectionString = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={ fi.FullName };Extended Properties=Excel 12.0 Xml;HDR=YES";
            //OleDbConnection conn = new OleDbConnection(connectionString);

            //try
            //{
            //    conn.Open();
            //}
            //catch (Exception ex)
            //{
            //    string InnerException = (ex.InnerException == null ? "" : $" InnerException: { ex.InnerException.Message }");
            //    OnCSSPError(new CSSPErrorEventArgs() { CSSPError = $"{ ex.Message }{ InnerException }" });
            //    return false;
            //}
            //OleDbDataReader reader;

            //OleDbCommand comm = new OleDbCommand("Select * from [PolSourceGrouping$];");


            //comm.Connection = conn;
            //reader = comm.ExecuteReader();


            ////List<string> FieldNameList = new List<string>();
            ////FieldNameList = new List<string>() { "CSSPID", "Group", "Child", "Hide", "EN", "InitEN", "DescEN", "ReportEN", "TextEN", "FR", "InitFR", "DescFR", "ReportFR", "TextFR" };
            ////for (int j = 0; j < reader.FieldCount; j++)
            ////{
            ////    if (reader.GetName(j) != FieldNameList[j])
            ////    {
            ////        OnCSSPError(new CSSPErrorEventArgs() { CSSPError = $"{ fi.FullName } PolSourceGrouping { reader.GetName(j) } is not equal to { FieldNameList[j] }\r\n" });
            ////        return false;
            ////    }
            ////}
            //reader.Close();

            //reader = comm.ExecuteReader();

            //string CSSPID = "";
            //string Group = "";
            //string Choice = "";
            //string Child = "";
            //string Hide = "";
            //string EN = "";
            //string InitEN = "";
            //string DescEN = "";
            //string ReportEN = "";
            //string TextEN = "";
            //string FR = "";
            //string InitFR = "";
            //string DescFR = "";
            //string ReportFR = "";
            //string TextFR = "";

            //int CountRead = 0;
            //while (reader.Read())
            //{
            //    CountRead += 1;

            //    if (CountRead % 200 == 0)
            //    {
            //        OnStatus(new StatusEventArgs() { status = $"Reading spreadsheet ... { CountRead }" });
            //    }

            //    if (reader.GetValue(1).GetType() == typeof(DBNull) || string.IsNullOrEmpty(reader.GetValue(1).ToString()))
            //    {
            //        CSSPID = "";
            //        Group = "";
            //        Choice = "";
            //        Child = "";
            //        Hide = "";
            //        EN = "";
            //        InitEN = "";
            //        DescEN = "";
            //        ReportEN = "";
            //        TextEN = "";
            //        FR = "";
            //        InitFR = "";
            //        DescFR = "";
            //        ReportFR = "";
            //        TextFR = "";
            //        continue;
            //    }
            //    else
            //    {
            //        CSSPID = reader.GetValue(0).ToString();
            //        Group = reader.GetValue(1).ToString();
            //        Child = reader.GetValue(2).ToString();
            //        Hide = reader.GetValue(3).ToString();
            //        EN = reader.GetValue(4).ToString();
            //        InitEN = reader.GetValue(5).ToString();
            //        DescEN = reader.GetValue(6).ToString();
            //        ReportEN = reader.GetValue(7).ToString();
            //        TextEN = reader.GetValue(8).ToString();
            //        FR = reader.GetValue(9).ToString();
            //        InitFR = reader.GetValue(10).ToString();
            //        DescFR = reader.GetValue(11).ToString();
            //        ReportFR = reader.GetValue(12).ToString();
            //        TextFR = reader.GetValue(13).ToString();
            //    }
            //    groupChoiceChildLevelStraitList.Add(new GroupChoiceChildLevel()
            //    {
            //        CSSPID = CSSPID,
            //        Group = Group,
            //        Choice = Choice,
            //        Child = Child,
            //        Hide = Hide,
            //        EN = EN,
            //        InitEN = InitEN,
            //        DescEN = DescEN,
            //        ReportEN = ReportEN,
            //        TextEN = TextEN,
            //        FR = FR,
            //        InitFR = InitFR,
            //        DescFR = DescFR,
            //        ReportFR = ReportFR,
            //        TextFR = TextFR,
            //    });
            //}
            //reader.Close();

            //conn.Close();

            #endregion Old Text

            List<GroupChoiceChildLevel> groupChoiceChildLevelOrderedList = (from c in groupChoiceChildLevelStraitList
                                                                            orderby c.Group
                                                                            select c).ToList();

            for (int i = 0, count = groupChoiceChildLevelOrderedList.Count; i < (count - 1); i++)
            {
                if (i % 200 == 0)
                {
                    OnStatus(new StatusEventArgs() { status = $"Checking ... that group { groupChoiceChildLevelOrderedList[i].Group } ---- has no duplicates" });
                }

                if (groupChoiceChildLevelOrderedList[i].Group == groupChoiceChildLevelOrderedList[i + 1].Group)
                {
                    OnCSSPError(new CSSPErrorEventArgs() { CSSPError = $"{ groupChoiceChildLevelOrderedList[i].Group } ---- has duplicates" });
                    return false;
                }
            }


            OnCSSPError(new CSSPErrorEventArgs() { CSSPError = "Column Group does not have duplicates.\r\n\r\n" });

            for (int i = 0, count = groupChoiceChildLevelOrderedList.Count; i < count; i++)
            {
                if (!string.IsNullOrWhiteSpace(groupChoiceChildLevelOrderedList[i].Group))
                {
                    if (i % 200 == 0)
                    {
                        OnStatus(new StatusEventArgs() { status = $"Checking ... that group { groupChoiceChildLevelOrderedList[i].Group } ---- should not contain space" });
                    }

                    if (groupChoiceChildLevelOrderedList[i].Group.Contains(" "))
                    {
                        OnCSSPError(new CSSPErrorEventArgs() { CSSPError = $"Group --- { groupChoiceChildLevelOrderedList[i].Group } ---- should not contain space" });
                        return false;
                    }
                }
                if (!string.IsNullOrWhiteSpace(groupChoiceChildLevelOrderedList[i].Child))
                {
                    if (i % 200 == 0)
                    {
                        OnStatus(new StatusEventArgs() { status = $"Checking ... that group { groupChoiceChildLevelOrderedList[i].Child } ---- should not contain space" });
                    }

                    if (groupChoiceChildLevelOrderedList[i].Child.Contains(" "))
                    {
                        OnCSSPError(new CSSPErrorEventArgs() { CSSPError = $"Child --- { groupChoiceChildLevelOrderedList[i].Child } ---- should not contain space" });
                        return false;
                    }
                }

            }

            OnCSSPError(new CSSPErrorEventArgs() { CSSPError = "All Text in Group and Child Columns does not contain space.\r\n\r\n" });

            string AllowableChar = "abcdefghijklmnopqrstuvwxyz_ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";

            for (int i = 0, count = groupChoiceChildLevelOrderedList.Count; i < count; i++)
            {
                if (i % 200 == 0)
                {
                    OnStatus(new StatusEventArgs() { status = $"Checking ... that group { groupChoiceChildLevelOrderedList[i].Group } ---- should only contain characters like [{ AllowableChar }]" });
                }

                foreach (char c in groupChoiceChildLevelOrderedList[i].Group)
                {
                    if (!AllowableChar.Contains(c))
                    {
                        OnCSSPError(new CSSPErrorEventArgs() { CSSPError = $"Group --- { groupChoiceChildLevelOrderedList[i].Group } ---- should not contain [{ c }]. Allowable characters are [{ AllowableChar }]" });
                        return false;
                    }
                }
                foreach (char c in groupChoiceChildLevelOrderedList[i].Child)
                {
                    if (i % 200 == 0)
                    {
                        OnStatus(new StatusEventArgs() { status = $"Checking ... that group { groupChoiceChildLevelOrderedList[i].Child } ---- should only contain characters like [{ AllowableChar }]" });
                    }

                    if (!AllowableChar.Contains(c))
                    {
                        OnCSSPError(new CSSPErrorEventArgs() { CSSPError = $"Child --- { groupChoiceChildLevelOrderedList[i].Child } ---- should not contain [{ c }]. Allowable characters are [{ AllowableChar }]" });
                        return false;
                    }
                }
            }

            OnCSSPError(new CSSPErrorEventArgs() { CSSPError = "All Text in Group and Child Columns does not contain space.\r\n\r\n" });

            for (int i = 0, count = groupChoiceChildLevelOrderedList.Count; i < count; i++)
            {
                if (!string.IsNullOrWhiteSpace(groupChoiceChildLevelOrderedList[i].Group))
                {
                    if (i % 200 == 0)
                    {
                        OnStatus(new StatusEventArgs() { status = $"Checking ... that CSSPID { groupChoiceChildLevelOrderedList[i].Group } ---- does not contain space" });
                    }

                    if (groupChoiceChildLevelOrderedList[i].CSSPID.Contains(" "))
                    {
                        OnCSSPError(new CSSPErrorEventArgs() { CSSPError = $"CSSPID --- { groupChoiceChildLevelOrderedList[i].Group } ---- should not contain space" });
                        return false;
                    }
                }
                if (!string.IsNullOrWhiteSpace(groupChoiceChildLevelOrderedList[i].Child))
                {
                    if (i % 200 == 0)
                    {
                        OnStatus(new StatusEventArgs() { status = $"Checking ... that CSSPID { groupChoiceChildLevelOrderedList[i].Child } ---- does not contain space" });
                    }

                    if (groupChoiceChildLevelOrderedList[i].CSSPID.Contains(" "))
                    {
                        OnCSSPError(new CSSPErrorEventArgs() { CSSPError = $"CSSPID --- { groupChoiceChildLevelOrderedList[i].Child } ---- should not contain space" });
                        return false;
                    }
                }

            }

            OnCSSPError(new CSSPErrorEventArgs() { CSSPError = "All Text in CSSPID column does not contain space.\r\n\r\n" });

            List<string> UniqueCSSPIDList = new List<string>();
            for (int i = 0, count = groupChoiceChildLevelOrderedList.Count; i < count; i++)
            {
                if (!string.IsNullOrWhiteSpace(groupChoiceChildLevelOrderedList[i].Group))
                {
                    if (i % 200 == 0)
                    {
                        OnStatus(new StatusEventArgs() { status = $"Checking ... that Group CSSPID { groupChoiceChildLevelOrderedList[i].Group } ---- is unique." });
                    }

                    if (string.IsNullOrWhiteSpace(groupChoiceChildLevelOrderedList[i].CSSPID))
                    {
                        OnCSSPError(new CSSPErrorEventArgs() { CSSPError = $"Group --- { groupChoiceChildLevelOrderedList[i].Group } ---- required a unique number in first column." });
                        return false;
                    }
                }
                if (!string.IsNullOrWhiteSpace(groupChoiceChildLevelOrderedList[i].Child))
                {
                    if (i % 200 == 0)
                    {
                        OnStatus(new StatusEventArgs() { status = $"Checking ... that Group CSSPID { groupChoiceChildLevelOrderedList[i].Child } ---- is unique." });
                    }

                    if (string.IsNullOrWhiteSpace(groupChoiceChildLevelOrderedList[i].CSSPID))
                    {
                        OnCSSPError(new CSSPErrorEventArgs() { CSSPError = $"Child --- { groupChoiceChildLevelOrderedList[i].Child } ---- required a unique number in first column" });
                        return false;
                    }
                }

                if (i % 200 == 0)
                {
                    OnStatus(new StatusEventArgs() { status = $"Checking ... that CSSPID { groupChoiceChildLevelOrderedList[i].Child } ---- is not empty." });
                }

                if (string.IsNullOrWhiteSpace(groupChoiceChildLevelOrderedList[i].CSSPID))
                {
                    OnCSSPError(new CSSPErrorEventArgs() { CSSPError = $"CSSPID is required for Group or Child [{ (groupChoiceChildLevelOrderedList[i].Choice.Length > 0 ? groupChoiceChildLevelOrderedList[i].Choice : groupChoiceChildLevelOrderedList[i].Group) }]" });
                    return false;
                }

                OnStatus(new StatusEventArgs() { status = $"Checking ... that CSSPID { groupChoiceChildLevelOrderedList[i].Child } ---- is unique." });

                if (UniqueCSSPIDList.Contains(groupChoiceChildLevelOrderedList[i].CSSPID))
                {
                    OnCSSPError(new CSSPErrorEventArgs() { CSSPError = $"CSSPID [{ groupChoiceChildLevelOrderedList[i].CSSPID }] is not unique" });
                    return false;
                }

                UniqueCSSPIDList.Add(groupChoiceChildLevelOrderedList[i].CSSPID);

                if (i % 200 == 0)
                {
                    OnStatus(new StatusEventArgs() { status = "Checking ... that each Hide cell with information contains valid child id, CSSPID are not duplicated, CSSPID with '-' are well formed." });
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
                                    OnCSSPError(new CSSPErrorEventArgs() { CSSPError = $"CSSPID [{ groupChoiceChildLevelOrderedList[i].CSSPID }] Hide cell contains [{ childCSSPID }] please remove a '-'" });
                                    return false;
                                }

                                foreach (char s in childCSSPID)
                                {
                                    if (!NumberAndDashOnlyList.Contains(s.ToString()))
                                    {
                                        OnCSSPError(new CSSPErrorEventArgs() { CSSPError = $"CSSPID [{ groupChoiceChildLevelOrderedList[i].CSSPID }] Hide cell contains [{ childCSSPID }]. Allowable characters are [{ String.Join(",", NumberAndDashOnlyList) }]" });
                                        return false;
                                    }
                                }

                                fromCSSPID = int.Parse(childCSSPID.Substring(0, childCSSPID.IndexOf("-")));
                                int endPos = childCSSPID.IndexOf("-") + 1;
                                if (childCSSPID.Length <= endPos)
                                {
                                    OnCSSPError(new CSSPErrorEventArgs() { CSSPError = $"CSSPID [{ groupChoiceChildLevelOrderedList[i].CSSPID }] Hide cell contains [{ childCSSPID }] missing end value" });
                                    return false;
                                }

                                toCSSPID = int.Parse(childCSSPID.Substring(endPos));

                                if (fromCSSPID >= toCSSPID)
                                {
                                    OnCSSPError(new CSSPErrorEventArgs() { CSSPError = $"CSSPID [{ groupChoiceChildLevelOrderedList[i].CSSPID }] Hide cell contains [{ childCSSPID }] which the first value is >= then the last value" });
                                    return false;
                                }
                            }

                            if (fromCSSPID != -1)
                            {
                                for (int id = fromCSSPID; id <= toCSSPID; id++)
                                {
                                    if (CSSPIDList2.Contains(id.ToString()) || CSSPIDList.Contains(id.ToString()))
                                    {
                                        OnCSSPError(new CSSPErrorEventArgs() { CSSPError = $"CSSPID [{ groupChoiceChildLevelOrderedList[i].CSSPID }] Hide cell contains [{ childCSSPID }] which will duplicate [{ id.ToString() }]" });
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
                                OnCSSPError(new CSSPErrorEventArgs() { CSSPError = $"CSSPID [{ groupChoiceChildLevelOrderedList[i].CSSPID }] Hide cell has duplicate [{ csspID }]" });
                                return false;
                            }
                            oldCSSPID = csspID;
                        }
                        foreach (string childCSSPID in CSSPIDList)
                        {
                            GroupChoiceChildLevel groupChoiceChildLevelChild = groupChoiceChildLevelOrderedList.Where(c => c.CSSPID == childCSSPID).FirstOrDefault();
                            if (groupChoiceChildLevelChild == null)
                            {
                                OnCSSPError(new CSSPErrorEventArgs() { CSSPError = $"CSSPID [{ groupChoiceChildLevelOrderedList[i].CSSPID }] Hide cell contains id [{ childCSSPID.ToString() }] which does not exist" });
                                return false;
                            }
                            string startCSSPID = $"{ childCSSPID.Substring(0, 3) }00";

                            GroupChoiceChildLevel groupChoiceChildLevel = groupChoiceChildLevelOrderedList.Where(c => c.CSSPID == startCSSPID).FirstOrDefault();

                            if (groupChoiceChildLevel == null)
                            {
                                OnCSSPError(new CSSPErrorEventArgs() { CSSPError = $"CSSPID [{ groupChoiceChildLevelOrderedList[i].CSSPID }] Group Choice child level is null for startCSSPID [{ startCSSPID.ToString() }]" });
                                return false;
                            }

                            string group = groupChoiceChildLevel.Group;
                            if (groupChoiceChildLevelOrderedList[i].Child != group)
                            {
                                OnCSSPError(new CSSPErrorEventArgs() { CSSPError = $"CSSPID [{ groupChoiceChildLevelOrderedList[i].CSSPID }] Hide cell contains id [{ childCSSPID.ToString() }] which is not a direct child" });
                                return false;
                            }
                        }
                        if (CSSPIDList.Count > 0)
                        {
                            string childCSSPID = CSSPIDList[0];

                            GroupChoiceChildLevel groupChoiceChildLevelChild = groupChoiceChildLevelOrderedList.Where(c => c.CSSPID == childCSSPID).FirstOrDefault();
                            if (groupChoiceChildLevelChild == null)
                            {
                                OnCSSPError(new CSSPErrorEventArgs() { CSSPError = $"CSSPID [{ groupChoiceChildLevelOrderedList[i].CSSPID }] Hide cell contains id [{ childCSSPID.ToString() }] which does not exist" });
                                return false;
                            }
                            string start3CharCSSPID = $"{ childCSSPID.Substring(0, 3) }";

                            int CountChild = groupChoiceChildLevelOrderedList.Where(c => c.CSSPID.StartsWith(start3CharCSSPID) && !c.CSSPID.EndsWith("00")).Count();

                            if (CSSPIDList.Count == CountChild)
                            {
                                OnCSSPError(new CSSPErrorEventArgs() { CSSPError = $"CSSPID [{ groupChoiceChildLevelOrderedList[i].CSSPID }] is hiding all possible selection" });
                                return false;

                            }
                        }
                    }
                }
            }

            OnCSSPError(new CSSPErrorEventArgs() { CSSPError = "All Groups and Choices Columns have a unique CSSPID.\r\n\r\n" });

            OnCSSPError(new CSSPErrorEventArgs() { CSSPError = "All Hide Columns with information has valid CSSPID (i.e. exist and is child).\r\n\r\n" });

            OnCSSPError(new CSSPErrorEventArgs() { CSSPError = "Everything is OK" });

            return true;
        }
        private bool ReadExcelFile()
        {
            groupChoiceChildLevelList = new List<GroupChoiceChildLevel>();
            OnStatus(new StatusEventArgs() { status = $"Reading spreadsheet [{ FullFileName }] ..." });

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
                                                            OnCSSPError(new CSSPErrorEventArgs() { CSSPError = $"{ fi.FullName } PolSourceGrouping { item.Text } is not equal to { FieldNameList[cellcount] }\r\n" });
                                                            return false;
                                                        }
                                                    }
                                                    else if (item.InnerText != null)
                                                    {
                                                        currentcellvalue = item.InnerText;
                                                        if (currentcellvalue != FieldNameList[cellcount])
                                                        {
                                                            OnCSSPError(new CSSPErrorEventArgs() { CSSPError = $"{ fi.FullName } PolSourceGrouping { item.Text } is not equal to { FieldNameList[cellcount] }\r\n" });
                                                            return false;
                                                        }
                                                    }
                                                    else if (item.InnerXml != null)
                                                    {
                                                        currentcellvalue = item.InnerXml;
                                                        if (currentcellvalue != FieldNameList[cellcount])
                                                        {
                                                            OnCSSPError(new CSSPErrorEventArgs() { CSSPError = $"{ fi.FullName } PolSourceGrouping { item.Text } is not equal to { FieldNameList[cellcount] }\r\n" });
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
                                                OnCSSPError(new CSSPErrorEventArgs() { CSSPError = $"{ fi.FullName } PolSourceGrouping { (thecurrentcell.InnerText + " ") } is not equal to { FieldNameList[cellcount] }\r\n" });
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
                                        OnStatus(new StatusEventArgs() { status = $"Reading spreadsheet ... { rowCount }" });
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
                OnCSSPError(new CSSPErrorEventArgs() { CSSPError = $"{ ex.Message }" });
                return false;
            }

            #region Old Text

            //string connectionString = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={ fi.FullName };Extended Properties=Excel 12.0 Xml;HDR=YES";
            //OleDbConnection conn = new OleDbConnection(connectionString);

            //try
            //{
            //    conn.Open();
            //}
            //catch (Exception ex)
            //{
            //    string InnerException = (ex.InnerException == null ? "" : $" InnerException: { ex.InnerException.Message }");
            //    OnCSSPError(new CSSPErrorEventArgs() { CSSPError = $"{ ex.Message }{ InnerException }" });
            //    return false;
            //}
            //OleDbDataReader reader;

            //OleDbCommand comm = new OleDbCommand("Select * from [PolSourceGrouping$];");

            //try
            //{
            //    comm.Connection = conn;
            //    reader = comm.ExecuteReader();

            //}
            //catch (Exception ex)
            //{
            //    OnCSSPError(new CSSPErrorEventArgs() { CSSPError = $"CSSPError 'comm.ExecuteReader' { ex.Message }\r\n" });
            //    return false;
            //}

            //if (reader.FieldCount != 14)
            //{
            //    OnCSSPError(new CSSPErrorEventArgs() { CSSPError = $"CSSPError Column count is [{ reader.FieldCount }]. It should be 14.\r\n" });
            //    return false;
            //}

            //List<string> FieldNameList = new List<string>();
            //FieldNameList = new List<string>() { "CSSPID", "Group", "Child", "Hide", "EN", "InitEN", "DescEN", "ReportEN", "TextEN", "FR", "InitFR", "DescFR", "ReportFR", "TextFR" };
            //for (int j = 0; j < reader.FieldCount; j++)
            //{
            //    if (reader.GetName(j) != FieldNameList[j])
            //    {
            //        OnStatus(new StatusEventArgs() { status = $"{ fi.FullName } PolSourceGrouping { reader.GetName(j) } is not equal to { FieldNameList[j] }\r\n" });
            //        return false;
            //    }
            //}
            //reader.Close();

            //reader = comm.ExecuteReader();

            //string CSSPID = "";
            //string Group = "";
            //string Choice = "";
            //string Child = "";
            //string Hide = "";
            //string EN = "";
            //string InitEN = "";
            //string DescEN = "";
            //string ReportEN = "";
            //string TextEN = "";
            //string FR = "";
            //string InitFR = "";
            //string DescFR = "";
            //string ReportFR = "";
            //string TextFR = "";

            //int CountRead = 0;
            //while (reader.Read())
            //{
            //    CountRead += 1;

            //    if (CountRead % 200 == 0)
            //    {
            //        OnStatus(new StatusEventArgs() { status = $"Reading spreadsheet ... { CountRead }" });
            //    }

            //    if (reader.GetValue(1).GetType() == typeof(DBNull) || string.IsNullOrEmpty(reader.GetValue(1).ToString()))
            //    {
            //        CSSPID = "";
            //        Group = "";
            //        Choice = "";
            //        Child = "";
            //        Hide = "";
            //        EN = "";
            //        InitEN = "";
            //        DescEN = "";
            //        ReportEN = "";
            //        TextEN = "";
            //        FR = "";
            //        InitFR = "";
            //        DescFR = "";
            //        ReportFR = "";
            //        TextFR = "";
            //        continue;
            //    }
            //    else
            //    {
            //        string TempStr = reader.GetValue(1).ToString();
            //        if (TempStr.Length > 0)
            //        {
            //            if (TempStr.Substring(TempStr.Length - 5) == "Start")
            //            {
            //                CSSPID = reader.GetValue(0).ToString();
            //                Group = TempStr;
            //                Choice = "";
            //                Child = "";
            //                Hide = "";
            //                EN = reader.GetValue(4).ToString();
            //                InitEN = reader.GetValue(5).ToString();
            //                DescEN = reader.GetValue(6).ToString();
            //                ReportEN = reader.GetValue(7).ToString();
            //                TextEN = reader.GetValue(8).ToString();
            //                FR = reader.GetValue(9).ToString();
            //                InitFR = reader.GetValue(10).ToString();
            //                DescFR = reader.GetValue(11).ToString();
            //                ReportFR = reader.GetValue(12).ToString();
            //                TextFR = reader.GetValue(13).ToString();
            //            }
            //            else
            //            {
            //                CSSPID = reader.GetValue(0).ToString();
            //                Choice = TempStr;
            //                if (reader.GetValue(2).GetType() == typeof(DBNull) || string.IsNullOrEmpty(reader.GetValue(2).ToString()))
            //                {
            //                    Child = "";
            //                }
            //                else
            //                {
            //                    Child = reader.GetValue(2).ToString();
            //                }
            //                if (reader.GetValue(3).GetType() == typeof(DBNull) || string.IsNullOrEmpty(reader.GetValue(3).ToString()))
            //                {
            //                    Hide = "";
            //                }
            //                else
            //                {
            //                    Hide = reader.GetValue(3).ToString();
            //                }
            //                EN = reader.GetValue(4).ToString();
            //                InitEN = reader.GetValue(5).ToString();
            //                DescEN = reader.GetValue(6).ToString();
            //                ReportEN = reader.GetValue(7).ToString();
            //                TextEN = reader.GetValue(8).ToString();
            //                FR = reader.GetValue(9).ToString();
            //                InitFR = reader.GetValue(10).ToString();
            //                DescFR = reader.GetValue(11).ToString();
            //                ReportFR = reader.GetValue(12).ToString();
            //                TextFR = reader.GetValue(13).ToString();
            //            }

            //            groupChoiceChildLevelList.Add(new GroupChoiceChildLevel()
            //            {
            //                CSSPID = CSSPID,
            //                Group = Group,
            //                Choice = Choice,
            //                Child = Child,
            //                Hide = Hide,
            //                EN = EN,
            //                InitEN = InitEN,
            //                DescEN = DescEN,
            //                ReportEN = ReportEN,
            //                TextEN = TextEN,
            //                FR = FR,
            //                InitFR = InitFR,
            //                DescFR = DescFR,
            //                ReportFR = ReportFR,
            //                TextFR = TextFR,
            //            });
            //        }
            //    }


            //}
            //reader.Close();

            //conn.Close();

            #endregion Old Text

            int Level = 0;
            List<string> textList = new List<string>();
            StringBuilder sb = new StringBuilder();
            if (!GetRecursiveForShowAllPaths("Start", textList, Level, false, sb))
            {
                return false;
            }

            return true;

        }
        public bool ReadExcelSheet(string FullFileName, bool DoCheck)
        {
            this.FullFileName = FullFileName;
            groupChoiceChildLevelList = new List<GroupChoiceChildLevel>();

            if (!ReadExcelFile())
            {
                return false;
            }

            if (DoCheck)
            {
                if (!CheckSpreadsheet())
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
                            OnCSSPError(new CSSPErrorEventArgs() { CSSPError = $"CSSPID [{ groupChoiceChildLevel.CSSPID }] Hide cell contains [{ childCSSPID }] missing end value" });
                            return false;
                        }

                        toCSSPID = int.Parse(childCSSPID.Substring(childCSSPID.IndexOf("-") + 1));

                        if (fromCSSPID >= toCSSPID)
                        {
                            OnCSSPError(new CSSPErrorEventArgs() { CSSPError = $"CSSPID [{ groupChoiceChildLevel.CSSPID }] Hide cell contains [{ childCSSPID }] which the first value is >= then the last value" });
                            return false;
                        }
                    }

                    if (fromCSSPID != -1)
                    {
                        for (int id = fromCSSPID; id <= toCSSPID; id++)
                        {
                            if (CSSPIDList2.Contains(id.ToString()) || CSSPIDList.Contains(id.ToString()))
                            {
                                OnCSSPError(new CSSPErrorEventArgs() { CSSPError = $"CSSPID [{ groupChoiceChildLevel.CSSPID }] Hide cell contains [{ childCSSPID }] which will duplicate [{ id.ToString() }]" });
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

            OnStatus(new StatusEventArgs() { status = "Excel doc read completed ... " });

            return true;
        }
        public bool GetRecursiveForShowAllPaths(string s, List<string> textList, int Level, bool RaiseEvents, StringBuilder sb)
        {
            textList.RemoveRange(Level, (textList.Count - Level));

            if (textList.Contains(s))
            {
                OnCSSPError(new CSSPErrorEventArgs() { CSSPError = "Recursive Found ...\r\n\r\n" });
                foreach (string sp in textList)
                {
                    OnCSSPError(new CSSPErrorEventArgs() { CSSPError = $"{ sp }\r\n" });
                }
                OnCSSPError(new CSSPErrorEventArgs() { CSSPError = $"{ s }\r\n" });
                return false;
            }

            OnStatus(new StatusEventArgs() { status = $"doing ... { s }" });

            if (RaiseEvents)
            {
                StringBuilder sb2 = new StringBuilder();
                foreach (string text in textList)
                {
                    sb2.Append($"{ text }\t");
                }
                //sb.AppendLine("");

                sb.AppendLine(sb2.ToString());
                //OnCSSPError(new CSSPErrorEventArgs() { CSSPError = sb.ToString() });
            }

            Level = Level + 1;
            textList.Add(s);

            List<GroupChoiceChildLevel> groupChoiceChildLevelChildList = groupChoiceChildLevelList.Where(c => c.Group == s && c.Choice != "").ToList();
            if (groupChoiceChildLevelChildList.Count > 0)
            {
                foreach (string child in groupChoiceChildLevelChildList.Select(c => c.Child).Distinct())
                {
                    if (!GetRecursiveForShowAllPaths(child, textList, Level, RaiseEvents, sb))
                        return false;
                }
            }

            OnStatus(new StatusEventArgs() { status = "" });

            return true;
        }
        #endregion Functions

        #region Class
        public class GroupChoiceChildLevel
        {
            public int ID { get; set; }
            public string CSSPID { get; set; }
            public string Group { get; set; }
            public string Choice { get; set; }
            public string Child { get; set; }
            public string Hide { get; set; }
            public string EN { get; set; }
            public string InitEN { get; set; }
            public string DescEN { get; set; }
            public string ReportEN { get; set; }
            public string TextEN { get; set; }
            public string FR { get; set; }
            public string InitFR { get; set; }
            public string DescFR { get; set; }
            public string ReportFR { get; set; }
            public string TextFR { get; set; }
        }

        #endregion Class
    }
}
