using CSSPPolSourceGroupingExcelFileRead;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestingPolSourceGrouping
{
    public partial class TestingPolSourceGrouping : Form
    {
        #region Variables
        List<string> startWithList = new List<string>() { "101", "143", "910" };
        //List<GroupChoiceChildLevel> groupChoiceChildLevelList = new List<GroupChoiceChildLevel>();
        int TotalCount = 0;
        string Lang = "EN";
        List<Label> labelGroupList = new List<Label>();
        List<ComboBox> comboBoxList = new List<ComboBox>();
        List<Label> labelReportList = new List<Label>();
        PolSourceGroupingExcelFileRead polSourceGroupingExcelFileRead { get; set; }
        #endregion Variables

        #region Constructors
        public TestingPolSourceGrouping()
        {
            InitializeComponent();
            polSourceGroupingExcelFileRead = new PolSourceGroupingExcelFileRead();
            polSourceGroupingExcelFileRead.Status += PolSourceGroupingExcelFileRead_Status;
            polSourceGroupingExcelFileRead.CSSPError += PolSourceGroupingExcelFileRead_CSSPError; ;
            DrawForm();
        }


        #endregion Constructors

        #region Events
        private void PolSourceGroupingExcelFileRead_CSSPError(object sender, PolSourceGroupingExcelFileRead.CSSPErrorEventArgs e)
        {
            richTextBoxStatus.AppendText(e.CSSPError + "\r\n");
            richTextBoxStatus.Refresh();
            Application.DoEvents();
        }
        private void PolSourceGroupingExcelFileRead_Status(object sender, PolSourceGroupingExcelFileRead.StatusEventArgs e)
        {
            lblStatus.Text = e.status;
            lblStatus.Refresh();
            Application.DoEvents();
        }
        private void butLoadExcelSheet_Click(object sender, EventArgs e)
        {
            LoadExcelSheet(true);
        }
        private void LoadExcelSheet(bool DoCheck)
        {
            richTextBoxStatus.Text = "";
            lblStatus.Refresh();
            Application.DoEvents();

            ChangeLang();

            if (!polSourceGroupingExcelFileRead.ReadExcelSheet(textBoxFileLocation.Text, DoCheck))
            {
                return;
            }

            foreach (PolSourceGroupingExcelFileRead.GroupChoiceChildLevel groupChoiceChildLevel in polSourceGroupingExcelFileRead.groupChoiceChildLevelList)
            {
                groupChoiceChildLevel.ID = int.Parse(groupChoiceChildLevel.CSSPID);
            }

            lblStatus.Text = "Excel doc read completed ... ";
            lblStatus.Refresh();
            Application.DoEvents();

            List<PolSourceGroupingExcelFileRead.GroupChoiceChildLevel> groupChoiceChildLevelChildList = null;

            if (Lang == "FR")
            {
                groupChoiceChildLevelChildList = (from c in polSourceGroupingExcelFileRead.groupChoiceChildLevelList
                                                  where c.ID > 10100
                                                  && c.ID < 10199
                                                  orderby c.FR
                                                  select c).ToList();
            }
            else
            {
                groupChoiceChildLevelChildList = (from c in polSourceGroupingExcelFileRead.groupChoiceChildLevelList
                                                  where c.ID > 10100
                                                  && c.ID < 10199
                                                  orderby c.EN
                                                  select c).ToList();
            }

            comboBoxList[0].Items.Clear();
            foreach (PolSourceGroupingExcelFileRead.GroupChoiceChildLevel groupChoiceChildLevel in groupChoiceChildLevelChildList)
            {
                groupChoiceChildLevel.FR = groupChoiceChildLevel.FR.Trim();
                groupChoiceChildLevel.EN = groupChoiceChildLevel.EN.Trim();

                comboBoxList[0].Items.Add(groupChoiceChildLevel);
            }

            comboBoxList[0].SelectedIndex = 0;

            PolSourceGroupingExcelFileRead.GroupChoiceChildLevel groupChoiceChildLevelGroup = (from c in polSourceGroupingExcelFileRead.groupChoiceChildLevelList
                                                                                               where c.Group == ((PolSourceGroupingExcelFileRead.GroupChoiceChildLevel)comboBoxList[0].SelectedItem).Group
                                                                                               select c).FirstOrDefault();

            if (Lang == "FR")
            {
                labelGroupList[0].Text = groupChoiceChildLevelGroup.Group + " (" + groupChoiceChildLevelGroup.FR + ")";
                labelReportList[0].Text = ((PolSourceGroupingExcelFileRead.GroupChoiceChildLevel)comboBoxList[0].SelectedItem).ReportFR;
            }
            else
            {
                labelGroupList[0].Text = groupChoiceChildLevelGroup.Group + " (" + groupChoiceChildLevelGroup.EN + ")";
                labelReportList[0].Text = ((PolSourceGroupingExcelFileRead.GroupChoiceChildLevel)comboBoxList[0].SelectedItem).ReportEN;
            }

            //butGetAllPaths.Visible = true;
            butShowReportText.Visible = true;
        }

        private void butPolSourceInfoEnumResEN_Click(object sender, EventArgs e)
        {
            ShowStart();

            richTextBoxStatus.Text = "";
            lblStatus.Refresh();
            Application.DoEvents();

            ChangeLang();

            if (!polSourceGroupingExcelFileRead.ReadExcelSheet(textBoxFileLocation.Text, true))
            {
                return;
            }

            if (polSourceGroupingExcelFileRead.groupChoiceChildLevelList.Count == 0)
                return;

            StringBuilder sb = new StringBuilder();

            foreach (PolSourceGroupingExcelFileRead.GroupChoiceChildLevel groupChoiceChildLevel in polSourceGroupingExcelFileRead.groupChoiceChildLevelList.Where(c => c.Group.Substring(c.Group.Length - 5) == "Start" && c.Choice == "").Distinct().ToList())
            {
                sb.AppendLine(@"PolSourceInfoEnum" + groupChoiceChildLevel.Group + "\t" + groupChoiceChildLevel.EN);
                sb.AppendLine(@"PolSourceInfoEnum" + groupChoiceChildLevel.Group + "Desc\t" + groupChoiceChildLevel.DescEN);
            }
            foreach (PolSourceGroupingExcelFileRead.GroupChoiceChildLevel groupChoiceChildLevel in polSourceGroupingExcelFileRead.groupChoiceChildLevelList)
            {
                if (groupChoiceChildLevel.Choice.Length > 0)
                {
                    sb.AppendLine(@"PolSourceInfoEnum" + groupChoiceChildLevel.Choice + "\t" + groupChoiceChildLevel.EN);
                    sb.AppendLine(@"PolSourceInfoEnum" + groupChoiceChildLevel.Choice + "Init\t" + (groupChoiceChildLevel.InitEN + " ").Trim());

                    List<string> HideList = new List<string>();
                    List<string> HideTextList = groupChoiceChildLevel.Hide.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                    foreach (string hide in HideTextList)
                    {
                        int fromCSSPID = -1;
                        int toCSSPID = -1;
                        if (hide.Contains("-"))
                        {
                            List<string> stringList = hide.Split("-".ToCharArray(), StringSplitOptions.None).ToList();

                            fromCSSPID = int.Parse(hide.Substring(0, hide.IndexOf("-")));
                            int endPos = hide.IndexOf("-") + 1;
                            toCSSPID = int.Parse(hide.Substring(endPos));

                            for (int id = fromCSSPID; id <= toCSSPID; id++)
                            {
                                HideList.Add(id.ToString());
                            }
                        }
                        else
                        {
                            HideList.Add(hide);
                        }
                    }

                    sb.AppendLine(@"PolSourceInfoEnum" + groupChoiceChildLevel.Choice + "Hide\t" + (string.Join(",", HideList) + " ").Trim());
                    if (groupChoiceChildLevel.ReportEN.Length > 0)
                    {
                        sb.AppendLine(@"PolSourceInfoEnum" + groupChoiceChildLevel.Choice + "Report\t" + groupChoiceChildLevel.ReportEN);
                    }
                    if (groupChoiceChildLevel.TextEN.Length > 0)
                    {
                        sb.AppendLine(@"PolSourceInfoEnum" + groupChoiceChildLevel.Choice + "Text\t" + groupChoiceChildLevel.TextEN);
                    }
                    if (groupChoiceChildLevel.DescEN.Length > 0)
                    {
                        sb.AppendLine(@"PolSourceInfoEnum" + groupChoiceChildLevel.Choice + "Desc\t" + groupChoiceChildLevel.DescEN);
                    }
                }
            }

            richTextBoxStatus.Text = sb.ToString();

            ShowFinished();
        }
        private void butPolSourceInfoEnumResFR_Click(object sender, EventArgs e)
        {
            ShowStart();

            richTextBoxStatus.Text = "";
            lblStatus.Refresh();
            Application.DoEvents();

            ChangeLang();

            if (!polSourceGroupingExcelFileRead.ReadExcelSheet(textBoxFileLocation.Text, true))
            {
                return;
            }

            if (polSourceGroupingExcelFileRead.groupChoiceChildLevelList.Count == 0)
                return;

            StringBuilder sb = new StringBuilder();

            foreach (PolSourceGroupingExcelFileRead.GroupChoiceChildLevel groupChoiceChildLevel in polSourceGroupingExcelFileRead.groupChoiceChildLevelList.Where(c => c.Group.Substring(c.Group.Length - 5) == "Start" && c.Choice == "").Distinct().ToList())
            {
                sb.AppendLine(@"PolSourceInfoEnum" + groupChoiceChildLevel.Group + "\t" + groupChoiceChildLevel.FR);
                sb.AppendLine(@"PolSourceInfoEnum" + groupChoiceChildLevel.Group + "Desc\t" + groupChoiceChildLevel.DescFR);
            }
            foreach (PolSourceGroupingExcelFileRead.GroupChoiceChildLevel groupChoiceChildLevel in polSourceGroupingExcelFileRead.groupChoiceChildLevelList)
            {
                if (groupChoiceChildLevel.Choice.Length > 0)
                {
                    sb.AppendLine(@"PolSourceInfoEnum" + groupChoiceChildLevel.Choice + "\t" + groupChoiceChildLevel.FR);
                    sb.AppendLine(@"PolSourceInfoEnum" + groupChoiceChildLevel.Choice + "Init\t" + (groupChoiceChildLevel.InitFR + " ").Trim());
                    List<string> HideList = new List<string>();
                    List<string> HideTextList = groupChoiceChildLevel.Hide.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                    foreach (string hide in HideTextList)
                    {
                        int fromCSSPID = -1;
                        int toCSSPID = -1;
                        if (hide.Contains("-"))
                        {
                            List<string> stringList = hide.Split("-".ToCharArray(), StringSplitOptions.None).ToList();

                            fromCSSPID = int.Parse(hide.Substring(0, hide.IndexOf("-")));
                            int endPos = hide.IndexOf("-") + 1;
                            toCSSPID = int.Parse(hide.Substring(endPos));

                            for (int id = fromCSSPID; id <= toCSSPID; id++)
                            {
                                HideList.Add(id.ToString());
                            }
                        }
                        else
                        {
                            HideList.Add(hide);
                        }
                    }

                    sb.AppendLine(@"PolSourceInfoEnum" + groupChoiceChildLevel.Choice + "Hide\t" + (string.Join(",", HideList) + " ").Trim());
                    if (groupChoiceChildLevel.ReportFR.Length > 0)
                    {
                        sb.AppendLine(@"PolSourceInfoEnum" + groupChoiceChildLevel.Choice + "Report\t" + groupChoiceChildLevel.ReportFR);
                    }
                    if (groupChoiceChildLevel.TextFR.Length > 0)
                    {
                        sb.AppendLine(@"PolSourceInfoEnum" + groupChoiceChildLevel.Choice + "Text\t" + groupChoiceChildLevel.TextFR);
                    }
                    if (groupChoiceChildLevel.DescFR.Length > 0)
                    {
                        sb.AppendLine(@"PolSourceInfoEnum" + groupChoiceChildLevel.Choice + "Desc\t" + groupChoiceChildLevel.DescFR);
                    }
                }
            }

            richTextBoxStatus.Text = sb.ToString();

            ShowFinished();

        }
        private void butShowAllPaths_Click(object sender, EventArgs e)
        {
            ShowStart();

            if (polSourceGroupingExcelFileRead.groupChoiceChildLevelList.Count == 0)
                return;

            TotalCount = 0;
            int Level = 0;
            StringBuilder sb = new StringBuilder();
            List<string> textList = new List<string>();
            if (!GetRecursiveForShowAllPaths("Start", textList, Level))
                return;

            richTextBoxStatus.AppendText(sb.ToString());

            ShowFinished();
        }
        private void butShowReportText_Click(object sender, EventArgs e)
        {
            ShowReportText();
        }
        private void checkBoxFR_CheckedChanged(object sender, EventArgs e)
        {
            ChangeLang();
        }
        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string senderStr = ((ComboBox)sender).Name;
            int senderID = int.Parse(senderStr.Substring(senderStr.IndexOf("_") + 1));
            PolSourceGroupingExcelFileRead.GroupChoiceChildLevel groupChoiceChildLevelSelected = (PolSourceGroupingExcelFileRead.GroupChoiceChildLevel)((ComboBox)sender).SelectedItem;

            if (groupChoiceChildLevelSelected.EN.StartsWith("------"))
            {
                MessageBox.Show("Invalid selection");
                return;
            }

            labelGroupList[senderID].Text = groupChoiceChildLevelSelected.Group;
            if (Lang == "FR")
            {
                labelReportList[senderID].Text = groupChoiceChildLevelSelected.ReportFR;
            }
            else
            {
                labelReportList[senderID].Text = groupChoiceChildLevelSelected.ReportEN;
            }

            PolSourceGroupingExcelFileRead.GroupChoiceChildLevel groupChoiceChildLevel = (from c in polSourceGroupingExcelFileRead.groupChoiceChildLevelList
                                                                                          where c.Group == groupChoiceChildLevelSelected.Child
                                                                                          select c).FirstOrDefault();

            for (int i = senderID + 1, count = labelGroupList.Count; i < count; i++)
            {
                comboBoxList[i].Items.Clear();
                comboBoxList[i].SelectedIndex = -1;
                comboBoxList[i].Text = "";
                labelGroupList[i].Text = "";
                labelReportList[i].Text = "";
            }

            if (groupChoiceChildLevel != null)
            {
                int EndNumber = groupChoiceChildLevel.ID + 99;
                List<PolSourceGroupingExcelFileRead.GroupChoiceChildLevel> groupChoiceChildLevelChildList = new List<PolSourceGroupingExcelFileRead.GroupChoiceChildLevel>();
                if (Lang == "FR")
                {
                    groupChoiceChildLevelChildList = (from c in polSourceGroupingExcelFileRead.groupChoiceChildLevelList
                                                      where c.ID > groupChoiceChildLevel.ID
                                                      && c.ID < EndNumber
                                                      orderby c.FR
                                                      select c).ToList();
                }
                else
                {
                    groupChoiceChildLevelChildList = (from c in polSourceGroupingExcelFileRead.groupChoiceChildLevelList
                                                      where c.ID > groupChoiceChildLevel.ID
                                                      && c.ID < EndNumber
                                                      orderby c.EN
                                                      select c).ToList();
                }
                if (groupChoiceChildLevelChildList.Count > 0)
                {
                    foreach (PolSourceGroupingExcelFileRead.GroupChoiceChildLevel groupChoiceChildLevelChild in groupChoiceChildLevelChildList)
                    {
                        List<string> CSSPIDList = groupChoiceChildLevelSelected.Hide.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(c => c.Trim()).ToList();

                        groupChoiceChildLevelChild.FR = groupChoiceChildLevelChild.FR.Trim().Replace("------   ", "");
                        groupChoiceChildLevelChild.EN = groupChoiceChildLevelChild.EN.Trim().Replace("------   ", "");

                        if (CSSPIDList.Count > 0)
                        {
                            if (!CSSPIDList.Contains(groupChoiceChildLevelChild.CSSPID.Trim()))
                            {
                                groupChoiceChildLevelChild.FR = groupChoiceChildLevelChild.FR.Trim();
                                groupChoiceChildLevelChild.EN = groupChoiceChildLevelChild.EN.Trim();

                                comboBoxList[senderID + 1].Items.Add(groupChoiceChildLevelChild);
                            }
                            else
                            {
                                groupChoiceChildLevelChild.FR = "------   " + groupChoiceChildLevelChild.FR.Trim();
                                groupChoiceChildLevelChild.EN = "------   " + groupChoiceChildLevelChild.EN.Trim();

                                comboBoxList[senderID + 1].Items.Add(groupChoiceChildLevelChild);
                            }
                        }
                        else
                        {
                            groupChoiceChildLevelChild.FR = groupChoiceChildLevelChild.FR.Trim();
                            groupChoiceChildLevelChild.EN = groupChoiceChildLevelChild.EN.Trim();

                            comboBoxList[senderID + 1].Items.Add(groupChoiceChildLevelChild);
                        }
                    }

                    bool comboboxSelected = false;
                    for (int i = 0, count = comboBoxList[senderID + 1].Items.Count; i < count; i++)
                    {
                        if (!((PolSourceGroupingExcelFileRead.GroupChoiceChildLevel)comboBoxList[senderID + 1].Items[i]).EN.StartsWith("------   "))
                        {
                            comboBoxList[senderID + 1].SelectedIndex = i;
                            comboboxSelected = true;
                            break;
                        }
                    }

                    PolSourceGroupingExcelFileRead.GroupChoiceChildLevel groupChoiceChildLevelGroup = (from c in polSourceGroupingExcelFileRead.groupChoiceChildLevelList
                                                                                                       where c.Group == ((PolSourceGroupingExcelFileRead.GroupChoiceChildLevel)comboBoxList[senderID + 1].SelectedItem).Group
                                                                                                       select c).FirstOrDefault();
                    if (Lang == "FR")
                    {
                        labelGroupList[senderID + 1].Text = groupChoiceChildLevelGroup.Group + " (" + groupChoiceChildLevelGroup.FR + ")";
                        labelReportList[senderID + 1].Text = ((PolSourceGroupingExcelFileRead.GroupChoiceChildLevel)comboBoxList[senderID + 1].SelectedItem).ReportFR;
                    }
                    else
                    {
                        labelGroupList[senderID + 1].Text = groupChoiceChildLevelGroup.Group + " (" + groupChoiceChildLevelGroup.EN + ")";
                        labelReportList[senderID + 1].Text = ((PolSourceGroupingExcelFileRead.GroupChoiceChildLevel)comboBoxList[senderID + 1].SelectedItem).ReportEN;
                    }
                }
                else
                {
                    if (Lang == "FR")
                    {
                        labelGroupList[senderID + 1].Text = groupChoiceChildLevel.Group + " (" + groupChoiceChildLevel.FR + ")";
                    }
                    else
                    {
                        labelGroupList[senderID + 1].Text = groupChoiceChildLevel.Group + " (" + groupChoiceChildLevel.EN + ")";
                    }
                }
            }
        }
        #endregion Events

        #region Functions
        private void ChangeLang()
        {
            if (checkBoxFR.Checked)
            {
                Lang = "FR";
            }
            else
            {
                Lang = "EN";
            }

            for (int i = 0, count = labelGroupList.Count; i < count; i++)
            {
                comboBoxList[i].DisplayMember = Lang;
                comboBoxList[i].ValueMember = "ID";
            }
        }
        private bool CheckSpreadsheet()
        {
            ShowStart();

            if (polSourceGroupingExcelFileRead.groupChoiceChildLevelList.Count == 0)
                return false;

            // Checking child exist
            List<string> childList = (from c in polSourceGroupingExcelFileRead.groupChoiceChildLevelList
                                      where c.Child.Length > 0
                                      select c.Child).Distinct().ToList();

            foreach (string child in childList)
            {
                PolSourceGroupingExcelFileRead.GroupChoiceChildLevel groupChoiceChildLevelExist = (from c in polSourceGroupingExcelFileRead.groupChoiceChildLevelList
                                                                                                   where c.Group == child
                                                                                                   select c).FirstOrDefault();

                if (groupChoiceChildLevelExist == null)
                {
                    richTextBoxStatus.AppendText(child + " ----- does not exist on Column Group\r\n\r\n");
                    return false;
                }
            }

            richTextBoxStatus.AppendText("All Child do exist on Column Group\r\n\r\n");

            // Checking EN and FR text exist for Group ending with Start
            List<PolSourceGroupingExcelFileRead.GroupChoiceChildLevel> groupChoiceChildLevelGroupList = (from c in polSourceGroupingExcelFileRead.groupChoiceChildLevelList
                                                                                                         where c.Group.Substring(c.Group.Length - 5) == "Start"
                                                                                                         select c).Distinct().ToList();

            foreach (PolSourceGroupingExcelFileRead.GroupChoiceChildLevel groupChoiceChildLevel in groupChoiceChildLevelGroupList)
            {
                if (string.IsNullOrWhiteSpace(groupChoiceChildLevel.EN))
                {
                    richTextBoxStatus.AppendText("Group: " + groupChoiceChildLevel.Group + " --- EN: " + groupChoiceChildLevel.EN + " ----- does not have EN text\r\n\r\n");
                    return false;
                }

                if (string.IsNullOrWhiteSpace(groupChoiceChildLevel.FR))
                {
                    richTextBoxStatus.AppendText("Group: " + groupChoiceChildLevel.Group + " --- EN: " + groupChoiceChildLevel.EN + " ----- does not have FR text\r\n\r\n");
                    return false;
                }

            }

            richTextBoxStatus.AppendText("Each Group with ending name = 'Start' does have EN and FR text.\r\n\r\n");

            // Checking DescEN and DescFR text exist for Group ending with Start
            List<PolSourceGroupingExcelFileRead.GroupChoiceChildLevel> groupChoiceChildLevelGroupDescList = (from c in polSourceGroupingExcelFileRead.groupChoiceChildLevelList
                                                                                                             where c.Group.Substring(c.Group.Length - 5) == "Start"
                                                                                                             select c).Distinct().ToList();

            foreach (PolSourceGroupingExcelFileRead.GroupChoiceChildLevel groupChoiceChildLevel in groupChoiceChildLevelGroupDescList)
            {
                if (string.IsNullOrWhiteSpace(groupChoiceChildLevel.Choice))
                {
                    if (string.IsNullOrWhiteSpace(groupChoiceChildLevel.DescEN))
                    {
                        richTextBoxStatus.AppendText("Group: " + groupChoiceChildLevel.Group + " --- EN: " + groupChoiceChildLevel.EN + " ----- does not have DescEN text\r\n\r\n");
                        return false;
                    }

                    if (string.IsNullOrWhiteSpace(groupChoiceChildLevel.DescFR))
                    {
                        richTextBoxStatus.AppendText("Group: " + groupChoiceChildLevel.Group + " --- EN: " + groupChoiceChildLevel.EN + " ----- does not have DescFR text\r\n\r\n");
                        return false;
                    }
                }
            }

            richTextBoxStatus.AppendText("Each Group with ending name = 'Start' does have DescEN and DescFR text.\r\n\r\n");



            // Checking EN and FR text exist for Choice.Length > 0
            List<PolSourceGroupingExcelFileRead.GroupChoiceChildLevel> groupChoiceChildLevelChoiceList = (from c in polSourceGroupingExcelFileRead.groupChoiceChildLevelList
                                                                                                          where c.Choice.Length > 0
                                                                                                          select c).Distinct().ToList();

            foreach (PolSourceGroupingExcelFileRead.GroupChoiceChildLevel groupChoiceChildLevel in groupChoiceChildLevelChoiceList)
            {
                if (string.IsNullOrWhiteSpace(groupChoiceChildLevel.EN))
                {
                    richTextBoxStatus.AppendText("Group: " + groupChoiceChildLevel.Group + " --- EN: " + groupChoiceChildLevel.EN + " ----- does not have EN text\r\n\r\n");
                    return false;
                }

                if (string.IsNullOrWhiteSpace(groupChoiceChildLevel.FR))
                {
                    richTextBoxStatus.AppendText("Group: " + groupChoiceChildLevel.Group + " --- EN: " + groupChoiceChildLevel.EN + " ----- does not have FR text\r\n\r\n");
                    return false;
                }

            }

            richTextBoxStatus.AppendText("Each Choice does have EN and FR text.\r\n\r\n");

            // Checking ReportEN and ReportFR text exist for Child.Length > 0
            groupChoiceChildLevelChoiceList = (from c in polSourceGroupingExcelFileRead.groupChoiceChildLevelList
                                               where c.Child.Length > 0
                                               select c).Distinct().ToList();

            foreach (PolSourceGroupingExcelFileRead.GroupChoiceChildLevel groupChoiceChildLevel in groupChoiceChildLevelChoiceList)
            {
                if (string.IsNullOrWhiteSpace(groupChoiceChildLevel.ReportEN) && groupChoiceChildLevel.ReportEN.Length == 0)
                {
                    richTextBoxStatus.AppendText("Group: " + groupChoiceChildLevel.Group + " --- EN: " + groupChoiceChildLevel.EN + " ----- does not have ReportEN text. You can add a space to fix the problem.\r\n\r\n");
                    return false;
                }

                if (string.IsNullOrWhiteSpace(groupChoiceChildLevel.ReportFR) && groupChoiceChildLevel.ReportFR.Length == 0)
                {
                    richTextBoxStatus.AppendText("Group: " + groupChoiceChildLevel.Group + " --- FR: " + groupChoiceChildLevel.FR + " ----- does not have ReportFR text. You can add a space to fix the problem.\r\n\r\n");
                    return false;
                }

            }

            richTextBoxStatus.AppendText("Each Choice does have ReportEN and ReportFR text.\r\n\r\n");


            // Checking for duplicates in column Group
            List<GroupChoiceChildLevel> groupChoiceChildLevelStraitList = new List<GroupChoiceChildLevel>();
            lblStatus.Text = "Reading spreadsheet ...";
            lblStatus.Refresh();
            Application.DoEvents();

            FileInfo fi = new FileInfo(textBoxFileLocation.Text);

            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fi.FullName + ";Extended Properties=Excel 12.0";
            OleDbConnection conn = new OleDbConnection(connectionString);

            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                richTextBoxStatus.AppendText(ex.Message + (ex.InnerException == null ? "" : ex.InnerException.Message));
                return false;
            }
            OleDbDataReader reader;

            Application.DoEvents();

            OleDbCommand comm = new OleDbCommand("Select * from [PolSourceGrouping$];");


            comm.Connection = conn;
            reader = comm.ExecuteReader();


            List<string> FieldNameList = new List<string>();
            FieldNameList = new List<string>() { "CSSPID", "Group", "Child", "Hide", "EN", "InitEN", "DescEN", "ReportEN", "TextEN", "FR", "InitFR", "DescFR", "ReportFR", "TextFR" };
            for (int j = 0; j < reader.FieldCount; j++)
            {
                if (reader.GetName(j) != FieldNameList[j])
                {
                    richTextBoxStatus.AppendText(fi.FullName + " PolSourceGrouping " + reader.GetName(j) + " is not equal to " + FieldNameList[j] + "\r\n");
                    return false;
                }
            }
            reader.Close();

            reader = comm.ExecuteReader();

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

            int CountRead = 0;
            while (reader.Read())
            {
                CountRead += 1;

                lblStatus.Text = "Reading spreadsheet ... " + CountRead;
                lblStatus.Refresh();
                Application.DoEvents();

                if (reader.GetValue(1).GetType() == typeof(DBNull) || string.IsNullOrEmpty(reader.GetValue(1).ToString()))
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
                    CSSPID = reader.GetValue(0).ToString();
                    Group = reader.GetValue(1).ToString();
                    Child = reader.GetValue(2).ToString();
                    Hide = reader.GetValue(3).ToString();
                    EN = reader.GetValue(4).ToString();
                    InitEN = reader.GetValue(5).ToString();
                    DescEN = reader.GetValue(6).ToString();
                    ReportEN = reader.GetValue(7).ToString();
                    TextEN = reader.GetValue(8).ToString();
                    FR = reader.GetValue(9).ToString();
                    InitFR = reader.GetValue(10).ToString();
                    DescFR = reader.GetValue(11).ToString();
                    ReportFR = reader.GetValue(12).ToString();
                    TextFR = reader.GetValue(13).ToString();
                }
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
            reader.Close();

            conn.Close();

            List<GroupChoiceChildLevel> groupChoiceChildLevelOrderedList = (from c in groupChoiceChildLevelStraitList
                                                                            orderby c.Group
                                                                            select c).ToList();

            for (int i = 0, count = groupChoiceChildLevelOrderedList.Count; i < (count - 1); i++)
            {
                if (groupChoiceChildLevelOrderedList[i].Group == groupChoiceChildLevelOrderedList[i + 1].Group)
                {
                    richTextBoxStatus.AppendText(groupChoiceChildLevelOrderedList[i].Group + " ---- has duplicates");
                    return false;
                }
            }


            richTextBoxStatus.AppendText("Column Group does not have duplicates.\r\n\r\n");

            for (int i = 0, count = groupChoiceChildLevelOrderedList.Count; i < count; i++)
            {
                if (!string.IsNullOrWhiteSpace(groupChoiceChildLevelOrderedList[i].Group))
                {
                    if (groupChoiceChildLevelOrderedList[i].Group.Contains(" "))
                    {
                        richTextBoxStatus.AppendText("Group --- " + groupChoiceChildLevelOrderedList[i].Group + " ---- should not contain space");
                        return false;
                    }
                }
                if (!string.IsNullOrWhiteSpace(groupChoiceChildLevelOrderedList[i].Child))
                {
                    if (groupChoiceChildLevelOrderedList[i].Child.Contains(" "))
                    {
                        richTextBoxStatus.AppendText("Child --- " + groupChoiceChildLevelOrderedList[i].Child + " ---- should not contain space");
                        return false;
                    }
                }

            }

            richTextBoxStatus.AppendText("All Text in Group and Child Columns does not contain space.\r\n\r\n");

            string AllowableChar = "abcdefghijklmnopqrstuvwxyz_ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";

            for (int i = 0, count = groupChoiceChildLevelOrderedList.Count; i < count; i++)
            {
                foreach (char c in groupChoiceChildLevelOrderedList[i].Group)
                {
                    if (!AllowableChar.Contains(c))
                    {
                        richTextBoxStatus.AppendText("Group --- " + groupChoiceChildLevelOrderedList[i].Group + " ---- should not contain [" + c + "]. Allowable characters are [" + AllowableChar + "]");
                        return false;
                    }
                }
                foreach (char c in groupChoiceChildLevelOrderedList[i].Child)
                {
                    if (!AllowableChar.Contains(c))
                    {
                        richTextBoxStatus.AppendText("Child --- " + groupChoiceChildLevelOrderedList[i].Child + " ---- should not contain [" + c + "]. Allowable characters are [" + AllowableChar + "]");
                        return false;
                    }
                }
            }

            richTextBoxStatus.AppendText("All Text in Group and Child Columns does not contain space.\r\n\r\n");

            for (int i = 0, count = groupChoiceChildLevelOrderedList.Count; i < count; i++)
            {
                if (!string.IsNullOrWhiteSpace(groupChoiceChildLevelOrderedList[i].Group))
                {
                    if (groupChoiceChildLevelOrderedList[i].CSSPID.Contains(" "))
                    {
                        richTextBoxStatus.AppendText("CSSPID --- " + groupChoiceChildLevelOrderedList[i].Group + " ---- should not contain space");
                        return false;
                    }
                }
                if (!string.IsNullOrWhiteSpace(groupChoiceChildLevelOrderedList[i].Child))
                {
                    if (groupChoiceChildLevelOrderedList[i].CSSPID.Contains(" "))
                    {
                        richTextBoxStatus.AppendText("CSSPID --- " + groupChoiceChildLevelOrderedList[i].Child + " ---- should not contain space");
                        return false;
                    }
                }

            }

            richTextBoxStatus.AppendText("All Text in CSSPID column does not contain space.\r\n\r\n");

            List<string> UniqueCSSPIDList = new List<string>();
            for (int i = 0, count = groupChoiceChildLevelOrderedList.Count; i < count; i++)
            {
                if (!string.IsNullOrWhiteSpace(groupChoiceChildLevelOrderedList[i].Group))
                {
                    if (string.IsNullOrWhiteSpace(groupChoiceChildLevelOrderedList[i].CSSPID))
                    {
                        richTextBoxStatus.AppendText("Group --- " + groupChoiceChildLevelOrderedList[i].Group + " ---- required a unique number in first column.");
                        return false;
                    }
                }
                if (!string.IsNullOrWhiteSpace(groupChoiceChildLevelOrderedList[i].Child))
                {
                    if (string.IsNullOrWhiteSpace(groupChoiceChildLevelOrderedList[i].CSSPID))
                    {
                        richTextBoxStatus.AppendText("Child --- " + groupChoiceChildLevelOrderedList[i].Child + " ---- required a unique number in first column");
                        return false;
                    }
                }
                if (string.IsNullOrWhiteSpace(groupChoiceChildLevelOrderedList[i].CSSPID))
                {
                    richTextBoxStatus.AppendText("CSSPID is required for Group or Child [" + (groupChoiceChildLevelOrderedList[i].Choice.Length > 0 ? groupChoiceChildLevelOrderedList[i].Choice : groupChoiceChildLevelOrderedList[i].Group) + "]");
                    return false;
                }
                if (UniqueCSSPIDList.Contains(groupChoiceChildLevelOrderedList[i].CSSPID))
                {
                    richTextBoxStatus.AppendText("CSSPID [" + groupChoiceChildLevelOrderedList[i].CSSPID + "] is not unique");
                    return false;
                }

                UniqueCSSPIDList.Add(groupChoiceChildLevelOrderedList[i].CSSPID);
            }

            richTextBoxStatus.AppendText("All Groups and Choices Columns have a unique CSSPID.\r\n\r\n");


            richTextBoxStatus.AppendText("Everything is OK");


            ShowFinished();

            return true;
        }
        private void DrawForm()
        {
            for (int i = 0; i < 40; i++)
            {
                Point point = new System.Drawing.Point((i < 10 ? 10 : (i < 20 ? 360 : (i < 30 ? 710 : 1060))), (i < 10 ? (i) * 60 + 3 : (i < 20 ? (i - 10) * 60 + 3 : (i < 30 ? (i - 20) * 60 + 3 : (i - 30) * 60 + 3))));
                Label label = new Label()
                {
                    AutoSize = true,
                    Location = point,
                    Name = "lblGroup_" + i.ToString(),
                    Font = new Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                    Size = new Size(51, 12),
                    TabIndex = 200 + i,
                    Text = "",
                };

                labelGroupList.Add(label);
                panel4.Controls.Add(label);
            }
            for (int i = 0; i < 40; i++)
            {
                Point point = new System.Drawing.Point((i < 10 ? 30 : (i < 20 ? 380 : (i < 30 ? 730 : 1090))), (i < 10 ? (i) * 60 + 25 : (i < 20 ? (i - 10) * 60 + 25 : (i < 30 ? (i - 20) * 60 + 25 : (i - 30) * 60 + 25))));
                ComboBox comboBox = new ComboBox()
                {
                    Location = point,
                    Name = "comboBoxChild_" + i.ToString(),
                    Size = new System.Drawing.Size(200, 50),
                    TabIndex = 699 + i,
                };

                comboBox.SelectedIndexChanged += comboBox_SelectedIndexChanged;
                comboBoxList.Add(comboBox);
                panel4.Controls.Add(comboBox);
            }
            for (int i = 0; i < 40; i++)
            {
                Point point = new System.Drawing.Point((i < 10 ? 30 : (i < 20 ? 380 : (i < 30 ? 730 : 1090))), (i < 10 ? (i) * 60 + 48 : (i < 20 ? (i - 10) * 60 + 48 : (i < 30 ? (i - 20) * 60 + 48 : (i - 30) * 60 + 48))));
                Label label = new Label()
                {
                    AutoSize = true,
                    Location = point,
                    Name = "lblReport_" + i.ToString(),
                    TabIndex = 20033 + i,
                    Text = "",
                };

                labelReportList.Add(label);
                panel4.Controls.Add(label);
            }
        }
        private bool GetRecursiveForShowAllPaths(string s, List<string> textList, int Level)
        {
            TotalCount += 1;
            lblStatus.Text = "Level " + Level + " " + TotalCount;
            lblStatus.Refresh();
            Application.DoEvents();

            textList.RemoveRange(Level, (textList.Count - Level));

            if (textList.Contains(s))
            {
                richTextBoxStatus.AppendText("Recursive Found ...\r\n\r\n");
                foreach (string sp in textList)
                {
                    richTextBoxStatus.AppendText(sp + "\r\n");
                }
                richTextBoxStatus.AppendText(s + "\r\n");
                return false;
            }

            StringBuilder sb = new StringBuilder();
            foreach (string text in textList)
            {
                sb.Append(text + "\t");
            }
            sb.AppendLine("");

            richTextBoxStatus.AppendText(sb.ToString());

            Level = Level + 1;
            textList.Add(s);


            List<PolSourceGroupingExcelFileRead.GroupChoiceChildLevel> groupChoiceChildLevelChildList = polSourceGroupingExcelFileRead.groupChoiceChildLevelList.Where(c => c.Group == s && c.Choice != "").ToList();
            if (groupChoiceChildLevelChildList.Count > 0)
            {
                foreach (string child in groupChoiceChildLevelChildList.Select(c => c.Child).Distinct())
                {
                    if (!GetRecursiveForShowAllPaths(child, textList, Level))
                        return false;
                }
            }
            return true;
        }
        private bool ReadExcelFile()
        {
            polSourceGroupingExcelFileRead.groupChoiceChildLevelList = new List<PolSourceGroupingExcelFileRead.GroupChoiceChildLevel>();
            lblStatus.Text = "Reading spreadsheet ...";
            lblStatus.Refresh();
            Application.DoEvents();

            FileInfo fi = new FileInfo(textBoxFileLocation.Text);

            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fi.FullName + ";Extended Properties=Excel 12.0";
            OleDbConnection conn = new OleDbConnection(connectionString);

            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                richTextBoxStatus.AppendText(ex.Message + (ex.InnerException == null ? "" : ex.InnerException.Message));
                return false;
            }
            OleDbDataReader reader;

            Application.DoEvents();

            OleDbCommand comm = new OleDbCommand("Select * from [PolSourceGrouping$];");

            try
            {
                comm.Connection = conn;
                reader = comm.ExecuteReader();

            }
            catch (Exception ex)
            {
                richTextBoxStatus.AppendText("Error 'comm.ExecuteReader' " + ex.Message + "\r\n");
                return false;
            }

            if (reader.FieldCount != 14)
            {
                richTextBoxStatus.AppendText("Error Column count is [" + reader.FieldCount + "]. It should be 14.\r\n");
                return false;
            }

            List<string> FieldNameList = new List<string>();
            FieldNameList = new List<string>() { "CSSPID", "Group", "Child", "Hide", "EN", "InitEN", "DescEN", "ReportEN", "TextEN", "FR", "InitFR", "DescFR", "ReportFR", "TextFR" };
            for (int j = 0; j < reader.FieldCount; j++)
            {
                if (reader.GetName(j) != FieldNameList[j])
                {
                    richTextBoxStatus.AppendText(fi.FullName + " PolSourceGrouping " + reader.GetName(j) + " is not equal to " + FieldNameList[j] + "\r\n");
                    return false;
                }
            }
            reader.Close();

            reader = comm.ExecuteReader();

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

            int CountRead = 0;
            while (reader.Read())
            {
                CountRead += 1;

                lblStatus.Text = "Reading spreadsheet ... " + CountRead;
                lblStatus.Refresh();
                Application.DoEvents();


                if (reader.GetValue(1).GetType() == typeof(DBNull) || string.IsNullOrEmpty(reader.GetValue(1).ToString()))
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
                    string TempStr = reader.GetValue(1).ToString();
                    if (TempStr.Length > 0)
                    {
                        if (TempStr.Substring(TempStr.Length - 5) == "Start")
                        {
                            CSSPID = reader.GetValue(0).ToString();
                            Group = TempStr;
                            Choice = "";
                            Child = "";
                            Hide = "";
                            EN = reader.GetValue(4).ToString();
                            InitEN = reader.GetValue(5).ToString();
                            DescEN = reader.GetValue(6).ToString();
                            ReportEN = reader.GetValue(7).ToString();
                            TextEN = reader.GetValue(8).ToString();
                            FR = reader.GetValue(9).ToString();
                            InitFR = reader.GetValue(10).ToString();
                            DescFR = reader.GetValue(11).ToString();
                            ReportFR = reader.GetValue(12).ToString();
                            TextFR = reader.GetValue(13).ToString();
                        }
                        else
                        {
                            CSSPID = reader.GetValue(0).ToString();
                            Choice = TempStr;
                            if (reader.GetValue(2).GetType() == typeof(DBNull) || string.IsNullOrEmpty(reader.GetValue(2).ToString()))
                            {
                                Child = "";
                            }
                            else
                            {
                                Child = reader.GetValue(2).ToString();
                            }
                            if (reader.GetValue(3).GetType() == typeof(DBNull) || string.IsNullOrEmpty(reader.GetValue(3).ToString()))
                            {
                                Hide = "";
                            }
                            else
                            {
                                Hide = reader.GetValue(3).ToString();
                            }
                            EN = reader.GetValue(4).ToString();
                            InitEN = reader.GetValue(5).ToString();
                            DescEN = reader.GetValue(6).ToString();
                            ReportEN = reader.GetValue(7).ToString();
                            TextEN = reader.GetValue(8).ToString();
                            FR = reader.GetValue(9).ToString();
                            InitFR = reader.GetValue(10).ToString();
                            DescFR = reader.GetValue(11).ToString();
                            ReportFR = reader.GetValue(12).ToString();
                            TextFR = reader.GetValue(13).ToString();
                        }

                        polSourceGroupingExcelFileRead.groupChoiceChildLevelList.Add(new PolSourceGroupingExcelFileRead.GroupChoiceChildLevel()
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
            reader.Close();

            conn.Close();

            return true;

        }
        private void ShowFinished()
        {
            lblStatus.Text = "Finished ... you can copy in excel click in window, press Ctr-A, Ctr-C goto excel press Ctr-V";
            lblStatus.Refresh();
            Application.DoEvents();
        }
        private void ShowStart()
        {
            richTextBoxStatus.Text = "";
            lblStatus.Text = "Started ... ";
            lblStatus.Refresh();
            Application.DoEvents();
        }
        private void ShowReportText()
        {
            StringBuilder sbGroup = new StringBuilder();
            StringBuilder sbGroupText = new StringBuilder();
            StringBuilder sbSentence = new StringBuilder();
            StringBuilder sbTVText = new StringBuilder();

            richTextBoxStatus.Text = "";
            sbGroup.Append("Grouping:\r\n\t");
            sbGroupText.Append("Grouping Text:\r\n\t");
            sbSentence.Append("Sentence:\r\n\t");
            sbTVText.Append("TVText:\r\n\t");

            for (int i = 0, count = labelGroupList.Count; i < count; i++)
            {

                PolSourceGroupingExcelFileRead.GroupChoiceChildLevel groupChoiceChildLevel = (PolSourceGroupingExcelFileRead.GroupChoiceChildLevel)comboBoxList[i].SelectedItem;

                if (groupChoiceChildLevel == null)
                {
                    richTextBoxStatus.Text = sbSentence.ToString() + "\r\n\r\n" + sbTVText.ToString() + "\r\n\r\n" + sbGroup.ToString() + "\r\n\r\n" + sbGroupText.ToString() + "\r\n\r\n";
                    return;
                }

                sbGroup.Append(" (" + i.ToString() + ") " + groupChoiceChildLevel.Group);
                if (Lang == "FR")
                {
                    if (groupChoiceChildLevel.FR.IndexOf("|") > 0)
                    {
                        sbGroupText.Append(" (" + i.ToString() + ") " + groupChoiceChildLevel.FR.Substring(0, groupChoiceChildLevel.FR.IndexOf("|")).Trim());
                    }
                    else
                    {
                        sbGroupText.Append(" (" + i.ToString() + ") " + groupChoiceChildLevel.FR.Trim());
                    }
                    sbSentence.Append(groupChoiceChildLevel.ReportFR);
                    string StartCSSPID = groupChoiceChildLevel.CSSPID.ToString().Substring(0, 3);
                    string groupTxt = groupChoiceChildLevel.FR.Trim();

                    if (startWithList.Where(c => c.StartsWith(StartCSSPID)).Any())
                    {
                        if (groupTxt.IndexOf("|") > 0)
                        {
                            sbTVText.Append((sbTVText.Length == 10 ? "" : ", ") + groupTxt.Substring(0, groupTxt.IndexOf("|")).Trim());
                        }
                        else
                        {
                            sbTVText.Append((sbTVText.Length == 10 ? "" : ", ") + groupTxt.Trim());
                        }
                    }
                }
                else
                {
                    if (groupChoiceChildLevel.EN.IndexOf("|") > 0)
                    {
                        sbGroupText.Append(" (" + i.ToString() + ") " + groupChoiceChildLevel.EN.Substring(0, groupChoiceChildLevel.EN.IndexOf("|")).Trim());
                    }
                    else
                    {
                        sbGroupText.Append(" (" + i.ToString() + ") " + groupChoiceChildLevel.EN.Trim());
                    }
                    sbSentence.Append(groupChoiceChildLevel.ReportEN);
                    string StartCSSPID = groupChoiceChildLevel.CSSPID.ToString().Substring(0, 3);
                    string groupTxt = groupChoiceChildLevel.EN.Trim();

                    if (startWithList.Where(c => c.StartsWith(StartCSSPID)).Any())
                    {
                        if (groupTxt.IndexOf("|") > 0)
                        {
                            sbTVText.Append((sbTVText.Length == 10 ? "" : ", ") + groupTxt.Substring(0, groupTxt.IndexOf("|")).Trim());
                        }
                        else
                        {
                            sbTVText.Append((sbTVText.Length == 10 ? "" : ", ") + groupTxt.Trim());
                        }
                    }
                }

            }
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

        private void butSeeFileNamesThatWillBeGenerated_Click(object sender, EventArgs e)
        {
            richTextBoxStatus.Text = "";
            richTextBoxStatus.AppendText(@"C:\CSSP Latest Code Old\CSSPModelsDLL\CSSPModelsDLL\Services\GeneratedBaseModelService.cs" + "\r\n");
            richTextBoxStatus.AppendText(@"C:\CSSP Latest Code Old\CSSPEnumsDLL\CSSPEnumsDLL\Services\GeneratedBaseEnumServicePolSourceInfo.cs" + "\r\n");
            richTextBoxStatus.AppendText(@"C:\CSSP Latest Code Old\CSSPEnumsDLL\CSSPEnumsDLL\Enums\GeneratedPolSourceObsInfoEnum.cs" + "\r\n");
            richTextBoxStatus.AppendText(@"C:\CSSP Latest Code Old\CSSPEnumsDLL\CSSPEnumsDLL.Tests\Services\GeneratedBaseEnumServicePolSourceObsInfoEnumTest.cs" + "\r\n");
            richTextBoxStatus.AppendText("\r\nYou will have to recompile CSSPModelsDLL and CSSPEnumsDLL after running the Generate Code\r\n");
        }

        private void butGenerateAllCodeFiles_Click(object sender, EventArgs e)
        {
            GenerateAllCodeFiles();
        }
        public void GenerateAllCodeFiles()
        {
            if (polSourceGroupingExcelFileRead.groupChoiceChildLevelList.Count == 0)
                return;

            TotalCount = 0;
            int Level = 0;
            List<string> textList = new List<string>();
            if (!GetRecursiveForShowAllPaths("Start", textList, Level))
                return;

            richTextBoxStatus.Text = "";
            richTextBoxStatus.AppendText(@"Creating: C:\CSSP Latest Code Old\CSSPModelsDLL\CSSPModelsDLL\Services\GeneratedBaseModelService.cs" + "\r\n");
            GenerateBaseModelsService_GeneratedBaseModelService_cs();
            richTextBoxStatus.AppendText(@"Creating: C:\CSSP Latest Code Old\CSSPEnumsDLL\CSSPEnumsDLL\Services\GeneratedBaseEnumServicePolSourceInfo.cs" + "\r\n");
            GeneratedBaseEnumService_GeneratedBaseEnumServicePolSourceInfo_cs();
            richTextBoxStatus.AppendText(@"Creating: C:\CSSP Latest Code Old\CSSPEnumsDLL\CSSPEnumsDLL\Enums\GeneratedPolSourceObsInfoEnum.cs" + "\r\n");
            GeneratedBaseEnumService_GeneratedPolSourceObsInfoEnum_cs();
            richTextBoxStatus.AppendText(@"Creating: C:\CSSP Latest Code Old\CSSPEnumsDLL\CSSPEnumsDLL.Tests\Services\GeneratedBaseEnumServicePolSourceObsInfoEnumTest.cs" + "\r\n");
            GeneratedBaseEnumService_GeneratedBaseEnumServicePolSourceObsInfoEnumTest_cs();
            richTextBoxStatus.AppendText("\r\n\r\n");
            richTextBoxStatus.AppendText("Done ... \r\n");
        }
        public void GenerateBaseModelsService_GeneratedBaseModelService_cs()
        {
            StringBuilder sb = new StringBuilder();

            FileInfo fi = new FileInfo(@"C:\CSSP Latest Code Old\CSSPModelsDLL\CSSPModelsDLL\Services\GeneratedBaseModelService.cs");

            List<string> groupList = (from c in polSourceGroupingExcelFileRead.groupChoiceChildLevelList
                                      select c.Group).Distinct().ToList();

            sb.AppendLine(@"using CSSPModelsDLL.Models;");
            sb.AppendLine(@"using System;");
            sb.AppendLine(@"using System.Collections.Generic;");
            sb.AppendLine(@"using System.Linq;");
            sb.AppendLine(@"using System.Text;");
            sb.AppendLine(@"using System.Threading.Tasks;");
            sb.AppendLine(@"using CSSPEnumsDLL.Enums;");
            sb.AppendLine(@"");
            sb.AppendLine(@"namespace CSSPModelsDLL.Services");
            sb.AppendLine(@"{");
            sb.AppendLine(@"    public class BaseModelService");
            sb.AppendLine(@"    {");
            sb.AppendLine(@"        #region Variables");
            sb.AppendLine(@"        #endregion Variables");
            sb.AppendLine(@"");
            sb.AppendLine(@"        #region Properties");
            sb.AppendLine(@"        #endregion Properties");
            sb.AppendLine(@"");
            sb.AppendLine(@"        #region Constructors");
            sb.AppendLine(@"        public BaseModelService(LanguageEnum LanguageRequest)");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"        }");
            sb.AppendLine(@"        #endregion Constructors");
            sb.AppendLine(@"");
            sb.AppendLine(@"        #region Functions public ");
            sb.AppendLine(@"        public void FillPolSourceObsInfoChild(List<PolSourceObsInfoChild> polSourceObsInfoChildList)");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            polSourceObsInfoChildList.Clear();");
            foreach (PolSourceGroupingExcelFileRead.GroupChoiceChildLevel groupChoiceChildLevel in polSourceGroupingExcelFileRead.groupChoiceChildLevelList.Where(c => c.Group.Substring(c.Group.Length - 5) == "Start" && c.Choice == "").Distinct().ToList())
            {
                sb.AppendLine(@"            polSourceObsInfoChildList.Add(new PolSourceObsInfoChild()");
                sb.AppendLine(@"            {");
                sb.AppendLine(@"                PolSourceObsInfo = PolSourceObsInfoEnum." + groupChoiceChildLevel.Group.ToString() + ", ");
                sb.AppendLine(@"                PolSourceObsInfoChildStart = PolSourceObsInfoEnum." + groupChoiceChildLevel.Group.ToString() + ",");
                sb.AppendLine(@"            });");
            }
            foreach (PolSourceGroupingExcelFileRead.GroupChoiceChildLevel groupChoiceChildLevel in polSourceGroupingExcelFileRead.groupChoiceChildLevelList.Where(c => c.Child != ""))
            {
                sb.AppendLine(@"            polSourceObsInfoChildList.Add(new PolSourceObsInfoChild()");
                sb.AppendLine(@"            {");
                sb.AppendLine(@"                PolSourceObsInfo = PolSourceObsInfoEnum." + groupChoiceChildLevel.Choice.ToString() + ", ");
                sb.AppendLine(@"                PolSourceObsInfoChildStart = PolSourceObsInfoEnum." + groupChoiceChildLevel.Child.ToString() + ",");
                sb.AppendLine(@"            });");
            }

            sb.AppendLine(@"        }");
            sb.AppendLine(@"        #endregion Functions public ");
            sb.AppendLine(@"    }");
            sb.AppendLine(@"}");

            StreamWriter sw = fi.CreateText();
            sw.Write(sb.ToString());
            sw.Close();

            richTextBoxStatus.AppendText("Created: " + fi.FullName + "\r\n");
        }
        public void GeneratedBaseEnumService_GeneratedBaseEnumServicePolSourceInfo_cs()
        {
            StringBuilder sb = new StringBuilder();

            FileInfo fi = new FileInfo(@"C:\CSSP Latest Code Old\CSSPEnumsDLL\CSSPEnumsDLL\Services\GeneratedBaseEnumServicePolSourceInfo.cs");

            List<string> groupList = (from c in polSourceGroupingExcelFileRead.groupChoiceChildLevelList
                                      select c.Group).Distinct().ToList();

            sb.AppendLine(@"using CSSPEnumsDLL.Enums;");
            sb.AppendLine(@"using CSSPEnumsDLL.Services.Resources;");
            sb.AppendLine(@"using System;");
            sb.AppendLine(@"using System.Collections.Generic;");
            sb.AppendLine(@"using System.Globalization;");
            sb.AppendLine(@"using System.Linq;");
            sb.AppendLine(@"using System.Text;");
            sb.AppendLine(@"using System.Threading;");
            sb.AppendLine(@"using System.Threading.Tasks;");
            sb.AppendLine(@"");
            sb.AppendLine(@"namespace CSSPEnumsDLL.Services");
            sb.AppendLine(@"{");
            sb.AppendLine(@"    public partial class BaseEnumService");
            sb.AppendLine(@"    {");

            sb.AppendLine(@"        #region Enum CheckOK");
            // Creating PolSourceObsInfoListOK(List<PolSourceObsInfoEnum> polSourceInfoList)
            sb.AppendLine(@"        public string PolSourceObsInfoListOK(List<PolSourceObsInfoEnum> polSourceInfoList)");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            foreach (PolSourceObsInfoEnum polSourceInfo in polSourceInfoList)");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                switch (polSourceInfo)");
            sb.AppendLine(@"                {");
            sb.AppendLine(@"                    case PolSourceObsInfoEnum.Error:");

            foreach (PolSourceGroupingExcelFileRead.GroupChoiceChildLevel groupChoiceChildLevel in polSourceGroupingExcelFileRead.groupChoiceChildLevelList.Where(c => c.Group.Substring(c.Group.Length - 5) == "Start" && c.Choice == "").Distinct().ToList())
            {
                sb.AppendLine(@"                    case PolSourceObsInfoEnum." + groupChoiceChildLevel.Group + ":");
            }
            foreach (PolSourceGroupingExcelFileRead.GroupChoiceChildLevel groupChoiceChildLevel in polSourceGroupingExcelFileRead.groupChoiceChildLevelList)
            {
                if (groupChoiceChildLevel.Choice.Length > 0)
                {
                    sb.AppendLine(@"                    case PolSourceObsInfoEnum." + groupChoiceChildLevel.Choice + ":");
                }
            }

            sb.AppendLine(@"                        return """";");
            sb.AppendLine(@"                    default:");
            sb.AppendLine(@"                        return string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.PolSourceInfo);");
            sb.AppendLine(@"                }");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"            return """";");
            sb.AppendLine(@"        }");

            // Creating PolSourceObsInfoOK(PolSourceObsInfoEnum? polSourceInfo)
            sb.AppendLine(@"        public string PolSourceObsInfoOK(PolSourceObsInfoEnum? polSourceInfo)");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            switch (polSourceInfo)");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                case PolSourceObsInfoEnum.Error:");

            foreach (PolSourceGroupingExcelFileRead.GroupChoiceChildLevel groupChoiceChildLevel in polSourceGroupingExcelFileRead.groupChoiceChildLevelList.Where(c => c.Group.Substring(c.Group.Length - 5) == "Start" && c.Choice == "").Distinct().ToList())
            {
                sb.AppendLine(@"                case PolSourceObsInfoEnum." + groupChoiceChildLevel.Group + ":");
            }
            foreach (PolSourceGroupingExcelFileRead.GroupChoiceChildLevel groupChoiceChildLevel in polSourceGroupingExcelFileRead.groupChoiceChildLevelList)
            {
                if (groupChoiceChildLevel.Choice.Length > 0)
                {
                    sb.AppendLine(@"                case PolSourceObsInfoEnum." + groupChoiceChildLevel.Choice + ":");
                }
            }

            sb.AppendLine(@"                    return """";");
            sb.AppendLine(@"                default:");
            sb.AppendLine(@"                    return string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.PolSourceInfo);");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"        }");
            sb.AppendLine(@"        #region Enum CheckOK");
            sb.AppendLine(@"");

            sb.AppendLine(@"        #endregion Functions Get Enum Text");

            // Creating GetEnumText_PolSourceObsInfoEnum(PolSourceObsInfoEnum? polSourceInfo)
            sb.AppendLine(@"        public string GetEnumText_PolSourceObsInfoEnum(PolSourceObsInfoEnum? polSourceInfo)");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            if (polSourceInfo == null)");
            sb.AppendLine(@"                 return BaseEnumServiceRes.Empty;");
            sb.AppendLine(@"");
            sb.AppendLine(@"            switch (polSourceInfo)");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                case PolSourceObsInfoEnum.Error:");
            sb.AppendLine(@"                    return BaseEnumServiceRes.Empty;");

            foreach (PolSourceGroupingExcelFileRead.GroupChoiceChildLevel groupChoiceChildLevel in polSourceGroupingExcelFileRead.groupChoiceChildLevelList.Where(c => c.Group.Substring(c.Group.Length - 5) == "Start" && c.Choice == "").Distinct().ToList())
            {
                sb.AppendLine(@"                case PolSourceObsInfoEnum." + groupChoiceChildLevel.Group + ":");
                sb.AppendLine(@"                    return PolSourceInfoEnumRes.PolSourceInfoEnum" + groupChoiceChildLevel.Group + ";");
            }
            foreach (PolSourceGroupingExcelFileRead.GroupChoiceChildLevel groupChoiceChildLevel in polSourceGroupingExcelFileRead.groupChoiceChildLevelList)
            {
                if (groupChoiceChildLevel.Choice.Length > 0)
                {
                    sb.AppendLine(@"                case PolSourceObsInfoEnum." + groupChoiceChildLevel.Choice + ":");
                    sb.AppendLine(@"                    return PolSourceInfoEnumRes.PolSourceInfoEnum" + groupChoiceChildLevel.Choice + ";");
                }
            }

            sb.AppendLine(@"                default:");
            sb.AppendLine(@"                    return BaseEnumServiceRes.Error;");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"        }");

            // Creating GetEnumText_PolSourceObsInfoDescEnum(PolSourceObsInfoEnum? polSourceInfo)
            sb.AppendLine(@"        public string GetEnumText_PolSourceObsInfoDescEnum(PolSourceObsInfoEnum? polSourceInfo)");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            if (polSourceInfo == null)");
            sb.AppendLine(@"                return BaseEnumServiceRes.Empty;");
            sb.AppendLine(@"");
            sb.AppendLine(@"            switch (polSourceInfo)");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                case PolSourceObsInfoEnum.Error:");
            sb.AppendLine(@"                    return BaseEnumServiceRes.Empty;");

            foreach (PolSourceGroupingExcelFileRead.GroupChoiceChildLevel groupChoiceChildLevel in polSourceGroupingExcelFileRead.groupChoiceChildLevelList.Where(c => c.Group.Substring(c.Group.Length - 5) == "Start" && c.Choice == "").Distinct().ToList())
            {
                sb.AppendLine(@"                case PolSourceObsInfoEnum." + groupChoiceChildLevel.Group + ":");
                sb.AppendLine(@"                    return PolSourceInfoEnumRes.PolSourceInfoEnum" + groupChoiceChildLevel.Group + "Desc;");
            }

            foreach (PolSourceGroupingExcelFileRead.GroupChoiceChildLevel groupChoiceChildLevel in polSourceGroupingExcelFileRead.groupChoiceChildLevelList.Where(c => c.Choice != "" && c.DescEN != "").Distinct().ToList())
            {
                sb.AppendLine(@"                case PolSourceObsInfoEnum." + groupChoiceChildLevel.Choice + ":");
                sb.AppendLine(@"                    return PolSourceInfoEnumRes.PolSourceInfoEnum" + groupChoiceChildLevel.Choice + "Desc;");
            }

            sb.AppendLine(@"                default:");
            sb.AppendLine(@"                    return BaseEnumServiceRes.Error;");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"        }");

            // Creating GetEnumText_PolSourceObsInfoReportEnum(PolSourceObsInfoEnum? polSourceInfo)
            sb.AppendLine(@"        public string GetEnumText_PolSourceObsInfoReportEnum(PolSourceObsInfoEnum? polSourceInfo)");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            if (polSourceInfo == null)");
            sb.AppendLine(@"                return BaseEnumServiceRes.Empty;");
            sb.AppendLine(@"");
            sb.AppendLine(@"            switch (polSourceInfo)");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                case PolSourceObsInfoEnum.Error:");
            sb.AppendLine(@"                    return BaseEnumServiceRes.Empty;");

            foreach (PolSourceGroupingExcelFileRead.GroupChoiceChildLevel groupChoiceChildLevel in polSourceGroupingExcelFileRead.groupChoiceChildLevelList.Where(c => c.Choice != "" && c.ReportEN != "").Distinct().ToList())
            {
                sb.AppendLine(@"                case PolSourceObsInfoEnum." + groupChoiceChildLevel.Choice + ":");
                sb.AppendLine(@"                    return PolSourceInfoEnumRes.PolSourceInfoEnum" + groupChoiceChildLevel.Choice + "Report;");
            }

            sb.AppendLine(@"                default:");
            sb.AppendLine(@"                    return """";");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"        }");

            // Creating GetEnumText_PolSourceObsInfoTextEnum(PolSourceObsInfoEnum? polSourceInfo)
            sb.AppendLine(@"        public string GetEnumText_PolSourceObsInfoTextEnum(PolSourceObsInfoEnum? polSourceInfo)");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            if (polSourceInfo == null)");
            sb.AppendLine(@"                return BaseEnumServiceRes.Empty;");
            sb.AppendLine(@"");
            sb.AppendLine(@"            switch (polSourceInfo)");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                case PolSourceObsInfoEnum.Error:");
            sb.AppendLine(@"                    return BaseEnumServiceRes.Empty;");

            foreach (PolSourceGroupingExcelFileRead.GroupChoiceChildLevel groupChoiceChildLevel in polSourceGroupingExcelFileRead.groupChoiceChildLevelList.Where(c => c.Choice != "" && c.TextEN != "").Distinct().ToList())
            {
                sb.AppendLine(@"                case PolSourceObsInfoEnum." + groupChoiceChildLevel.Choice + ":");
                sb.AppendLine(@"                    return PolSourceInfoEnumRes.PolSourceInfoEnum" + groupChoiceChildLevel.Choice + "Text;");
            }

            sb.AppendLine(@"                default:");
            sb.AppendLine(@"                    return """";");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"        }");

            // Creating GetEnumText_PolSourceObsInfoInitEnum(PolSourceObsInfoEnum? polSourceInfo)
            sb.AppendLine(@"        public string GetEnumText_PolSourceObsInfoInitEnum(PolSourceObsInfoEnum? polSourceInfo)");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            if (polSourceInfo == null)");
            sb.AppendLine(@"                return BaseEnumServiceRes.Empty;");
            sb.AppendLine(@"");
            sb.AppendLine(@"            switch (polSourceInfo)");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                case PolSourceObsInfoEnum.Error:");
            sb.AppendLine(@"                    return BaseEnumServiceRes.Empty;");

            foreach (PolSourceGroupingExcelFileRead.GroupChoiceChildLevel groupChoiceChildLevel in polSourceGroupingExcelFileRead.groupChoiceChildLevelList.Where(c => c.Choice != "" && c.InitEN != "").Distinct().ToList())
            {
                sb.AppendLine(@"                case PolSourceObsInfoEnum." + groupChoiceChildLevel.Choice + ":");
                sb.AppendLine(@"                    return PolSourceInfoEnumRes.PolSourceInfoEnum" + groupChoiceChildLevel.Choice + "Init;");
            }

            sb.AppendLine(@"                default:");
            sb.AppendLine(@"                    return """";");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"        }");

            // Creating GetEnumText_PolSourceObsInfoHideEnum(PolSourceObsInfoEnum? polSourceInfo)
            sb.AppendLine(@"        public string GetEnumText_PolSourceObsInfoHideEnum(PolSourceObsInfoEnum? polSourceInfo)");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            if (polSourceInfo == null)");
            sb.AppendLine(@"                return BaseEnumServiceRes.Empty;");
            sb.AppendLine(@"");
            sb.AppendLine(@"            switch (polSourceInfo)");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                case PolSourceObsInfoEnum.Error:");
            sb.AppendLine(@"                    return BaseEnumServiceRes.Empty;");

            foreach (PolSourceGroupingExcelFileRead.GroupChoiceChildLevel groupChoiceChildLevel in polSourceGroupingExcelFileRead.groupChoiceChildLevelList.Where(c => c.Choice != "" && c.Hide != "").Distinct().ToList())
            {
                sb.AppendLine(@"                case PolSourceObsInfoEnum." + groupChoiceChildLevel.Choice + ":");
                sb.AppendLine(@"                    return PolSourceInfoEnumRes.PolSourceInfoEnum" + groupChoiceChildLevel.Choice + "Hide;");
            }

            sb.AppendLine(@"                default:");
            sb.AppendLine(@"                    return """";");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"        }");

            sb.AppendLine(@"        #endregion Functions Get Enum Text");

            sb.AppendLine(@"    }");
            sb.AppendLine(@"}");

            StreamWriter sw = fi.CreateText();
            sw.Write(sb.ToString());
            sw.Close();

            richTextBoxStatus.AppendText("Created: " + fi.FullName + "\r\n");


        }
        public void GeneratedBaseEnumService_GeneratedPolSourceObsInfoEnum_cs()
        {
            StringBuilder sb = new StringBuilder();

            FileInfo fi = new FileInfo(@"C:\CSSP Latest Code Old\CSSPEnumsDLL\CSSPEnumsDLL\Enums\GeneratedPolSourceObsInfoEnum.cs");

            List<string> groupList = (from c in polSourceGroupingExcelFileRead.groupChoiceChildLevelList
                                      select c.Group).Distinct().ToList();

            sb.AppendLine(@"using System;");
            sb.AppendLine(@"using System.Collections.Generic;");
            sb.AppendLine(@"using System.Linq;");
            sb.AppendLine(@"using System.Text;");
            sb.AppendLine(@"using System.Threading.Tasks;");
            sb.AppendLine(@"");
            sb.AppendLine(@"namespace CSSPEnumsDLL.Enums");
            sb.AppendLine(@"{");
            sb.AppendLine(@"    public enum PolSourceObsInfoEnum");
            sb.AppendLine(@"    {");
            sb.AppendLine(@"        Error = 0,");

            foreach (PolSourceGroupingExcelFileRead.GroupChoiceChildLevel groupChoiceChildLevel in polSourceGroupingExcelFileRead.groupChoiceChildLevelList)
            {
                if (!string.IsNullOrWhiteSpace(groupChoiceChildLevel.Group))
                {
                    if (groupChoiceChildLevel.Group.Substring(groupChoiceChildLevel.Group.Length - 5) == "Start" && string.IsNullOrWhiteSpace(groupChoiceChildLevel.Choice))
                    {
                        sb.AppendLine("\r\n        " + groupChoiceChildLevel.Group + @" = " + groupChoiceChildLevel.CSSPID.ToString() + ",");
                    }
                    else
                    {
                        sb.AppendLine("        " + groupChoiceChildLevel.Choice + @" = " + groupChoiceChildLevel.CSSPID.ToString() + ",");

                    }
                }
            }
            sb.AppendLine(@"    }");
            sb.AppendLine(@"}");

            StreamWriter sw = fi.CreateText();
            sw.Write(sb.ToString());
            sw.Close();

            richTextBoxStatus.AppendText("Created: " + fi.FullName + "\r\n");
        }
        public void GeneratedBaseEnumService_GeneratedBaseEnumServicePolSourceObsInfoEnumTest_cs()
        {
            StringBuilder sb = new StringBuilder();

            FileInfo fi = new FileInfo(@"C:\CSSP Latest Code Old\CSSPEnumsDLL\CSSPEnumsDLL.Tests\Services\GeneratedBaseEnumServicePolSourceObsInfoEnumTest.cs");

            List<string> groupList = (from c in polSourceGroupingExcelFileRead.groupChoiceChildLevelList
                                      select c.Group).Distinct().ToList();

            sb.AppendLine(@"using System;");
            sb.AppendLine(@"using System.Text;");
            sb.AppendLine(@"using System.Collections.Generic;");
            sb.AppendLine(@"using Microsoft.VisualStudio.TestTools.UnitTesting;");
            sb.AppendLine(@"using CSSPEnumsDLL.Tests.SetupInfo;");
            sb.AppendLine(@"using System.Globalization;");
            sb.AppendLine(@"using System.Threading;");
            sb.AppendLine(@"using CSSPEnumsDLL.Services;");
            sb.AppendLine(@"using CSSPEnumsDLL.Services.Resources;");
            sb.AppendLine(@"using CSSPEnumsDLL.Enums;");
            sb.AppendLine(@"");
            sb.AppendLine(@"namespace CSSPEnumsDLL.Tests.Services");
            sb.AppendLine(@"{");
            sb.AppendLine(@"    public partial class BaseEnumServiceTest");
            sb.AppendLine(@"    {");
            sb.AppendLine(@"        [TestMethod]");
            sb.AppendLine(@"        public void BaseService_GetEnumText_PolSourceObsInfoEnum_Test()");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            foreach (CultureInfo culture in setupData.cultureListGood)");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                SetupTest(culture);");
            sb.AppendLine(@"");
            sb.AppendLine(@"                string retStr = baseEnumService.GetEnumText_PolSourceObsInfoEnum(null);");
            sb.AppendLine(@"                Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);");
            sb.AppendLine(@"                string retStrDesc = baseEnumService.GetEnumText_PolSourceObsInfoDescEnum(null);");
            sb.AppendLine(@"                Assert.AreEqual(BaseEnumServiceRes.Empty, retStrDesc);");
            sb.AppendLine(@"                string retStrReport = baseEnumService.GetEnumText_PolSourceObsInfoReportEnum(null);");
            sb.AppendLine(@"                Assert.AreEqual(BaseEnumServiceRes.Empty, retStrReport);");
            sb.AppendLine(@"                string retStrText = baseEnumService.GetEnumText_PolSourceObsInfoTextEnum(null);");
            sb.AppendLine(@"                Assert.AreEqual(BaseEnumServiceRes.Empty, retStrText);");
            sb.AppendLine(@"");
            sb.AppendLine(@"                foreach (int i in Enum.GetValues(typeof(PolSourceObsInfoEnum)))");
            sb.AppendLine(@"                {");
            sb.AppendLine(@"                    retStr = baseEnumService.GetEnumText_PolSourceObsInfoEnum((PolSourceObsInfoEnum)i);");
            sb.AppendLine(@"                    retStrDesc = baseEnumService.GetEnumText_PolSourceObsInfoDescEnum((PolSourceObsInfoEnum)i);");
            sb.AppendLine(@"                    retStrReport = baseEnumService.GetEnumText_PolSourceObsInfoReportEnum((PolSourceObsInfoEnum)i);");
            sb.AppendLine(@"                    retStrText = baseEnumService.GetEnumText_PolSourceObsInfoTextEnum((PolSourceObsInfoEnum)i);");
            sb.AppendLine(@"");
            sb.AppendLine(@"                    switch ((PolSourceObsInfoEnum)i)");
            sb.AppendLine(@"                    {");
            sb.AppendLine(@"                        case PolSourceObsInfoEnum.Error:");
            sb.AppendLine(@"                        {");
            sb.AppendLine(@"                            Assert.AreEqual(BaseEnumServiceRes.Error, retStr);");
            sb.AppendLine(@"                        }");
            sb.AppendLine(@"                        break;");
            foreach (PolSourceGroupingExcelFileRead.GroupChoiceChildLevel groupChoiceChildLevel in polSourceGroupingExcelFileRead.groupChoiceChildLevelList.Where(c => c.Group.Substring(c.Group.Length - 5) == "Start" && c.Choice == "").Distinct().ToList())
            {
                sb.AppendLine(@"                        case PolSourceObsInfoEnum." + groupChoiceChildLevel.Group + ":");
                sb.AppendLine(@"                        {");
                sb.AppendLine(@"                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnum" + groupChoiceChildLevel.Group + ", retStr);");
                sb.AppendLine(@"                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnum" + groupChoiceChildLevel.Group + "Desc, retStrDesc);");
                sb.AppendLine(@"                        }");
                sb.AppendLine(@"                        break;");
            }
            foreach (PolSourceGroupingExcelFileRead.GroupChoiceChildLevel groupChoiceChildLevel in polSourceGroupingExcelFileRead.groupChoiceChildLevelList)
            {
                if (!string.IsNullOrWhiteSpace(groupChoiceChildLevel.Choice))
                {
                    sb.AppendLine(@"                        case PolSourceObsInfoEnum." + groupChoiceChildLevel.Choice + ":");
                    sb.AppendLine(@"                        {");
                    sb.AppendLine(@"                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnum" + groupChoiceChildLevel.Choice + ", retStr);");
                    sb.AppendLine(@"                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnum" + groupChoiceChildLevel.Choice + "Report, retStrReport);");
                    if (!string.IsNullOrWhiteSpace(groupChoiceChildLevel.TextEN))
                    {
                        sb.AppendLine(@"                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnum" + groupChoiceChildLevel.Choice + "Text, retStrText);");
                    }
                    sb.AppendLine(@"                        }");
                    sb.AppendLine(@"                        break;");
                }
            }
            sb.AppendLine(@"                        default:");
            sb.AppendLine(@"                        {");
            sb.AppendLine(@"                            Assert.AreEqual("""", ((PolSourceObsInfoEnum)i).ToString() + ""["" + i.ToString() + ""]"");");
            sb.AppendLine(@"                        }");
            sb.AppendLine(@"                        break;");
            sb.AppendLine(@"                    }");
            sb.AppendLine(@"                }");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"        }");
            sb.AppendLine(@"    }");
            sb.AppendLine(@"}");

            StreamWriter sw = fi.CreateText();
            sw.Write(sb.ToString());
            sw.Close();

            richTextBoxStatus.AppendText("Created: " + fi.FullName + "\r\n");
        }
    }
}
