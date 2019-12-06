using CSSPPolSourceGroupingExcelFileRead;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSSPTestingPolSourceGrouping
{
    public partial class CSSPTestingPolSourceGrouping : Form
    {
        #region Variables
        List<string> startWithList = new List<string>() { "101", "143", "910" };
        string Lang = "EN";
        List<Label> labelGroupList = new List<Label>();
        List<ComboBox> comboBoxList = new List<ComboBox>();
        List<Label> labelReportList = new List<Label>();
        #endregion Variables

        #region Properties
        PolSourceGroupingExcelFileRead polSourceGroupingExcelFileRead { get; set; }
        #endregion Properties

        #region Constructors
        public CSSPTestingPolSourceGrouping()
        {
            InitializeComponent();
            polSourceGroupingExcelFileRead = new PolSourceGroupingExcelFileRead();
            polSourceGroupingExcelFileRead.Status += PolSourceGroupingExcelFileRead_Status;
            polSourceGroupingExcelFileRead.CSSPError += PolSourceGroupingExcelFileRead_CSSPError;
            DrawForm();
            textBoxFileLocation.Text = $@"C:\CSSPTools\src\assets\PolSourceGrouping.xlsm";
        }

        #endregion Constructors

        #region Events
        private void butLoadExcelSheetWithCheck_Click(object sender, EventArgs e)
        {
            LoadExcelSheet(true);
        }
        private void butGetAllPaths_Click(object sender, EventArgs e)
        {
            richTextBoxStatus.Text = "";
            lblStatus.Text = "Started ... ";
            lblStatus.Refresh();
            Application.DoEvents();

            if (polSourceGroupingExcelFileRead.groupChoiceChildLevelList == null || polSourceGroupingExcelFileRead.groupChoiceChildLevelList.Count == 0)
            {
                return;
            }

            //TotalCount = 0;
            int Level = 0;
            StringBuilder sb = new StringBuilder();
            List<string> textList = new List<string>();
            if (!polSourceGroupingExcelFileRead.GetRecursiveForShowAllPaths("SourceStart", textList, Level, true, sb))
                return;

            richTextBoxStatus.AppendText(sb.ToString());

            lblStatus.Text = "Finished ... you can copy in excel click in window, press Ctr-A, Ctr-C goto excel press Ctr-V";
            lblStatus.Refresh();
            Application.DoEvents();
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

            if (groupChoiceChildLevelSelected.EN.StartsWith("ZZZZZZ"))
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

                        groupChoiceChildLevelChild.FR = groupChoiceChildLevelChild.FR.Trim().Replace("ZZZZZZ   ", "");
                        groupChoiceChildLevelChild.EN = groupChoiceChildLevelChild.EN.Trim().Replace("ZZZZZZ   ", "");

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
                                groupChoiceChildLevelChild.FR = $"ZZZZZZ   { groupChoiceChildLevelChild.FR.Trim() }";
                                groupChoiceChildLevelChild.EN = $"ZZZZZZ   { groupChoiceChildLevelChild.EN.Trim() }";

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

                    for (int i = 0, count = comboBoxList[senderID + 1].Items.Count; i < count; i++)
                    {
                        if (!((PolSourceGroupingExcelFileRead.GroupChoiceChildLevel)comboBoxList[senderID + 1].Items[i]).EN.StartsWith("ZZZZZZ   "))
                        {
                            comboBoxList[senderID + 1].SelectedIndex = i;
                            break;
                        }
                    }

                    PolSourceGroupingExcelFileRead.GroupChoiceChildLevel groupChoiceChildLevelGroup = (from c in polSourceGroupingExcelFileRead.groupChoiceChildLevelList
                                                                                                       where c.Group == ((PolSourceGroupingExcelFileRead.GroupChoiceChildLevel)comboBoxList[senderID + 1].SelectedItem).Group
                                                                                                       select c).FirstOrDefault();
                    if (Lang == "FR")
                    {
                        labelGroupList[senderID + 1].Text = $"{ groupChoiceChildLevelGroup.Group }"; // ({ groupChoiceChildLevelGroup.FR })";
                        labelReportList[senderID + 1].Text = ((PolSourceGroupingExcelFileRead.GroupChoiceChildLevel)comboBoxList[senderID + 1].SelectedItem).ReportFR;
                    }
                    else
                    {
                        labelGroupList[senderID + 1].Text = $"{ groupChoiceChildLevelGroup.Group }"; // ({ groupChoiceChildLevelGroup.EN })";
                        labelReportList[senderID + 1].Text = ((PolSourceGroupingExcelFileRead.GroupChoiceChildLevel)comboBoxList[senderID + 1].SelectedItem).ReportEN;
                    }
                }
                else
                {
                    if (Lang == "FR")
                    {
                        labelGroupList[senderID + 1].Text = $"{ groupChoiceChildLevel.Group }"; // ({ groupChoiceChildLevel.FR })";
                    }
                    else
                    {
                        labelGroupList[senderID + 1].Text = $"{ groupChoiceChildLevel.Group }"; // ({ groupChoiceChildLevel.EN })";
                    }
                }
            }
        }
        private void PolSourceGroupingExcelFileRead_CSSPError(object sender, PolSourceGroupingExcelFileRead.CSSPErrorEventArgs e)
        {
            richTextBoxStatus.AppendText($"{ e.CSSPError }\r\n");
            richTextBoxStatus.Refresh();
            Application.DoEvents();
        }
        private void PolSourceGroupingExcelFileRead_Status(object sender, PolSourceGroupingExcelFileRead.StatusEventArgs e)
        {
            lblStatus.Text = e.status;
            lblStatus.Refresh();
            Application.DoEvents();
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
        private void DrawForm()
        {
            for (int i = 0; i < 40; i++)
            {
                Point point = new System.Drawing.Point((i < 10 ? 10 : (i < 20 ? 360 : (i < 30 ? 710 : 1060))), (i < 10 ? (i) * 60 + 3 : (i < 20 ? (i - 10) * 60 + 3 : (i < 30 ? (i - 20) * 60 + 3 : (i - 30) * 60 + 3))));
                Label label = new Label()
                {
                    AutoSize = true,
                    Location = point,
                    Name = $"lblGroup_{ i.ToString() }",
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
                    Name = $"comboBoxChild_{ i.ToString() }",
                    Size = new System.Drawing.Size(200, 50),
                    TabIndex = 699 + i,
                };

                comboBox.Sorted = true;
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
                    Name = $"lblReport_{ i.ToString() }",
                    TabIndex = 20033 + i,
                    Text = "",
                };

                labelReportList.Add(label); 
                panel4.Controls.Add(label);
            }
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
                labelGroupList[0].Text = $"{ groupChoiceChildLevelGroup.Group }"; // ({ groupChoiceChildLevelGroup.FR })";
                labelReportList[0].Text = ((PolSourceGroupingExcelFileRead.GroupChoiceChildLevel)comboBoxList[0].SelectedItem).ReportFR;
            }
            else
            {
                labelGroupList[0].Text = $"{ groupChoiceChildLevelGroup.Group }"; // ({ groupChoiceChildLevelGroup.EN })";
                labelReportList[0].Text = ((PolSourceGroupingExcelFileRead.GroupChoiceChildLevel)comboBoxList[0].SelectedItem).ReportEN;
            }

            butGetAllPaths.Visible = true;
            butShowReportText.Visible = true;
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
                    richTextBoxStatus.Text = $"{ sbSentence.ToString() }\r\n\r\n{ sbTVText.ToString() }\r\n\r\n{ sbGroup.ToString() }\r\n\r\n{ sbGroupText.ToString() }\r\n\r\n";
                    return;
                }

                sbGroup.Append($" ({ i.ToString() }) { groupChoiceChildLevel.Group }");
                if (Lang == "FR")
                {
                    if (groupChoiceChildLevel.FR.IndexOf("|") > 0)
                    {
                        sbGroupText.Append($" ({ i.ToString() }) { groupChoiceChildLevel.FR.Substring(0, groupChoiceChildLevel.FR.IndexOf("|")).Trim() }");
                    }
                    else
                    {
                        sbGroupText.Append($" ({ i.ToString() }) { groupChoiceChildLevel.FR.Trim() }");
                    }
                    sbSentence.Append(groupChoiceChildLevel.ReportFR);
                    string StartCSSPID = groupChoiceChildLevel.CSSPID.ToString().Substring(0, 3);
                    string groupTxt = groupChoiceChildLevel.FR.Trim();

                    if (startWithList.Where(c => c.StartsWith(StartCSSPID)).Any())
                    {
                        if (groupTxt.IndexOf("|") > 0)
                        {
                            sbTVText.Append($"{ (sbTVText.Length == 10 ? "" : ", ") }{ groupTxt.Substring(0, groupTxt.IndexOf("|")).Trim() }");
                        }
                        else
                        {
                            sbTVText.Append($"{ (sbTVText.Length == 10 ? "" : ", ") }{ groupTxt.Trim() }");
                        }
                    }
                }
                else
                {
                    if (groupChoiceChildLevel.EN.IndexOf("|") > 0)
                    {
                        sbGroupText.Append($" ({ i.ToString() }) { groupChoiceChildLevel.EN.Substring(0, groupChoiceChildLevel.EN.IndexOf("|")).Trim() }");
                    }
                    else
                    {
                        sbGroupText.Append($" ({ i.ToString() }) { groupChoiceChildLevel.EN.Trim() }");
                    }
                    sbSentence.Append(groupChoiceChildLevel.ReportEN);
                    string StartCSSPID = groupChoiceChildLevel.CSSPID.ToString().Substring(0, 3);
                    string groupTxt = groupChoiceChildLevel.EN.Trim();

                    if (startWithList.Where(c => c.StartsWith(StartCSSPID)).Any())
                    {
                        if (groupTxt.IndexOf("|") > 0)
                        {
                            sbTVText.Append($"{ (sbTVText.Length == 10 ? "" : ", ") }{ groupTxt.Substring(0, groupTxt.IndexOf("|")).Trim() }");
                        }
                        else
                        {
                            sbTVText.Append($"{ (sbTVText.Length == 10 ? "" : ", ") }{ groupTxt.Trim() }");
                        }
                    }
                }

            }
        }
        #endregion Functions

    }
}
