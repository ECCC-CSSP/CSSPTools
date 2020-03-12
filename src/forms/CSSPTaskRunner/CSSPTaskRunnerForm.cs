using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSSPModels;
using CSSPEnums;
using CSSPServices;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Collections.Specialized;
using System.Net;
using System.Threading;
using System.Globalization;

namespace CSSPTaskRunner
{
    public partial class CSSPTaskRunnerForm : Form
    {
        #region Variables
        private int LabSheetLookupDelay = 4; // seconds
        private int TaskStatusOfRunnningLookupDelay = 5; // seconds
        private List<int> DavidHalliwellEmailTimeHourList = new List<int>() { 6, 12, 18 }; // hours to send email every day
        private int MPNLimitForEmail = 500;
        //private bool testing = false;
        #endregion Variables

        #region Properties
        DatabaseTypeEnum databaseType { get; set; } = DatabaseTypeEnum.SqlServerTestDB;
        private LanguageEnum Language { get; set; } = LanguageEnum.en;
        public RichTextBox _RichTextBoxStatus { get; set; }
        public int _SkipTimerCount { get; set; }
        public TaskRunnerBaseService _TaskRunnerBaseService { get; set; }
        public System.Windows.Forms.Timer _TimerCheckTask { get; set; }
        public Label _LabelLastAppTaskCheckDate { get; set; }
        #endregion Properties

        #region Constructors
        public CSSPTaskRunnerForm()
        {
            InitializeComponent();
            databaseType = DatabaseTypeEnum.SqlServerTestDB;
            _SkipTimerCount = 0;
            _TimerCheckTask = timerCheckTask;
            richTextBoxStatus.Text = "";
            _TaskRunnerBaseService._RichTextBoxStatus = richTextBoxStatus;
            timerCheckTask.Enabled = true;
            _RichTextBoxStatus = richTextBoxStatus;
            _LabelLastAppTaskCheckDate = lblLastAppTaskCheckDate;
            Language = LanguageEnum.en;
        }
        #endregion Constructors

        #region Events
        private void timerCheckTask_Tick(object sender, EventArgs e)
        {
            DoTimerCheckTask();
        }
        #endregion Events

        #region Functions
        public void DoTimerCheckTask()
        {
            timerCheckTask.Enabled = false;
            GetNextTask();
            timerCheckTask.Enabled = true;
        }
        public void GetNextTask()
        {
            if (_SkipTimerCount == 86401)
            {
                _SkipTimerCount = 0;
            }
            _SkipTimerCount += 1;

            lblLastAppTaskCheckDate.Text = DateTime.Now.ToString("F");

            using (CSSPDBContext db = new CSSPDBContext(databaseType))
            {
                AppTaskService appTaskService = new AppTaskService(new Query() { Language = LanguageEnum.en }, db, 2);

                AppTask appTask = appTaskService.CheckAppTask();

                if (appTask.HasErrors)
                {
                    foreach (ValidationResult validationResult in appTask.ValidationResults)
                    {
                        lblLastAppTaskCheckDate.Text += " " + validationResult.ErrorMessage;
                    }
                }
                else
                {
                    appTask.AppTaskStatus = AppTaskStatusEnum.Running;

                    if (!appTaskService.Update(appTask))
                    {
                        return;
                    }

                    if (Enum.GetNames(typeof(AppTaskCommandEnum)).Contains(appTask.AppTaskCommand.ToString()))
                    {
                        _TaskRunnerBaseService.ExecuteTask();
                    }
                    else
                    {
                        _TaskRunnerBaseService._BWObj.TextLanguageList = _TaskRunnerBaseService.GetTextLanguageList("GenerateOrCommandNeedsToBeTrue");
                        _TaskRunnerBaseService.SendErrorTextToDB(_TaskRunnerBaseService._BWObj.TextLanguageList);
                    }
                }
            }


            // Checking for new lab sheets
            if (_SkipTimerCount % LabSheetLookupDelay == 0)
            {
                GetNextLabSheet();
            }

            // Checking others
            if (_SkipTimerCount % TaskStatusOfRunnningLookupDelay == 0) // if timer interval is 1 second then this will run every 5 seconds
            {
                _TaskRunnerBaseService.UpdateStatusOfRunningScenarios();
            }

            // Checking others
            DateTime CurrentDateTime = DateTime.Now;
            if (DavidHalliwellEmailTimeHourList.Contains(CurrentDateTime.Hour) && CurrentDateTime.Minute == 0 && CurrentDateTime.Second == 0)
            {
                try
                {
                    string DavidHalliwellErrorMessage = _TaskRunnerBaseService.RunTaskForDavidHalliwell();
                }
                catch (Exception ex)
                {
                    _RichTextBoxStatus.AppendText("David Halliwell issue: " + ex.Message + (ex.InnerException == null ? "" : ex.InnerException.Message));

                    MailMessage mail = new MailMessage();

                    //mail.To.Add("Shawn.Donohue@Canada.ca");
                    mail.To.Add("David.Halliwell@canada.ca");
                    mail.Bcc.Add("Charles.LeBlanc2@Canada.ca");

                    mail.From = new MailAddress("ec.pccsm-cssp.ec@canada.ca");
                    mail.IsBodyHtml = true;

                    SmtpClient myClient = new System.Net.Mail.SmtpClient();

                    //myClient.Host = "smtp.ctst.email-courriel.canada.ca";
                    myClient.Host = "smtp.email-courriel.canada.ca";
                    myClient.Port = 587;
                    //myClient.Credentials = new System.Net.NetworkCredential("yourusername", "yourpassword");
                    //myClient.Credentials = new System.Net.NetworkCredential("ec.pccsm-cssp.ec@ctst.canada.ca", "5y3Q^z+B4a7T$F+nQ@9N+r6uE!E87s");
                    myClient.Credentials = new System.Net.NetworkCredential("ec.pccsm-cssp.ec@canada.ca", "H^9h6g@Gy$N57k=Dr@J7=F2y6p6b!T");
                    myClient.EnableSsl = true;

                    string subject = "David Halliwell Issue from CSSPWebToolsTaskRunner";

                    StringBuilder msg = new StringBuilder();

                    msg.AppendLine("<h2>David Halliwell Issue Email</h2>");
                    msg.AppendLine("<h4>Date of issue: " + DateTime.Now + "</h4>");
                    msg.AppendLine("<h4>Exception Message: " + ex.Message + "</h4>");
                    msg.AppendLine("<h4>Exception Inner Message: " + (ex.InnerException != null ? ex.InnerException.Message : "empty") + "</h4>");

                    msg.AppendLine(@"<br>");
                    msg.AppendLine(@"<p>Auto email from CSSPWebTools.</p>");

                    mail.Subject = subject;
                    mail.Body = msg.ToString();
                    myClient.Send(mail);
                }
            }
        }
        public string UpdateOtherServerWithOtherServerLabSheetIDAndLabSheetStatus(int OtherServerLabSheetID, LabSheetStatusEnum LabSheetStatus)
        {
            string retStr = "";

            NameValueCollection paramList = new NameValueCollection();
            paramList.Add("OtherServerLabSheetID", OtherServerLabSheetID.ToString());
            paramList.Add("LabSheetStatus", ((int)LabSheetStatus).ToString());

            using (WebClient webClient = new WebClient())
            {
                WebProxy webProxy = new WebProxy();
                webClient.Proxy = webProxy;

                webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                byte[] ret = webClient.UploadValues(new Uri("http://cssplabsheet.azurewebsites.net/UpdateLabSheetStatus.aspx"), "POST", paramList);

                retStr = System.Text.Encoding.Default.GetString(ret);
            }

            return retStr;
        }
        public string UploadLabSheetDetailInDB(LabSheetModelAndA1Sheet labSheetModelAndA1Sheet)
        {
            string retStr = "";

            // Filling LabSheetDetailModel
            LabSheetDetailModel labSheetDetailModelNew = new LabSheetDetailModel();

            labSheetDetailModelNew.LabSheetID = labSheetModelAndA1Sheet.LabSheetModel.LabSheetID;
            labSheetDetailModelNew.SamplingPlanID = labSheetModelAndA1Sheet.LabSheetModel.SamplingPlanID;
            labSheetDetailModelNew.SubsectorTVItemID = labSheetModelAndA1Sheet.LabSheetModel.SubsectorTVItemID;
            labSheetDetailModelNew.Version = labSheetModelAndA1Sheet.LabSheetA1Sheet.Version;
            labSheetDetailModelNew.IncludeLaboratoryQAQC = labSheetModelAndA1Sheet.LabSheetA1Sheet.IncludeLaboratoryQAQC;

            // RunDate
            DateTime RunDate = new DateTime();
            int RunYear = (string.IsNullOrWhiteSpace(labSheetModelAndA1Sheet.LabSheetA1Sheet.RunYear) ? 1900 : int.Parse(labSheetModelAndA1Sheet.LabSheetA1Sheet.RunYear));
            int RunMonth = (string.IsNullOrWhiteSpace(labSheetModelAndA1Sheet.LabSheetA1Sheet.RunMonth) ? 1 : int.Parse(labSheetModelAndA1Sheet.LabSheetA1Sheet.RunMonth));
            int RunDay = (string.IsNullOrWhiteSpace(labSheetModelAndA1Sheet.LabSheetA1Sheet.RunDay) ? 1 : int.Parse(labSheetModelAndA1Sheet.LabSheetA1Sheet.RunDay));
            if (RunYear != 1900)
            {
                RunDate = new DateTime(RunYear, RunMonth, RunDay);
            }

            labSheetDetailModelNew.RunDate = RunDate;

            labSheetDetailModelNew.Tides = labSheetModelAndA1Sheet.LabSheetA1Sheet.Tides;
            labSheetDetailModelNew.SampleCrewInitials = labSheetModelAndA1Sheet.LabSheetA1Sheet.SampleCrewInitials;

            if (labSheetModelAndA1Sheet.LabSheetA1Sheet.IncludeLaboratoryQAQC)
            {
                // IncubationBath1StartDate
                DateTime IncubationBath1StartDate = new DateTime();
                int IncubationBath1StartYear = (string.IsNullOrWhiteSpace(labSheetModelAndA1Sheet.LabSheetA1Sheet.RunYear) ? 1900 : int.Parse(labSheetModelAndA1Sheet.LabSheetA1Sheet.RunYear));
                int IncubationBath1StartMonth = (string.IsNullOrWhiteSpace(labSheetModelAndA1Sheet.LabSheetA1Sheet.RunMonth) ? 1 : int.Parse(labSheetModelAndA1Sheet.LabSheetA1Sheet.RunMonth));
                int IncubationBath1StartDay = (string.IsNullOrWhiteSpace(labSheetModelAndA1Sheet.LabSheetA1Sheet.RunDay) ? 1 : int.Parse(labSheetModelAndA1Sheet.LabSheetA1Sheet.RunDay));
                int IncubationBath1StartHour = 0;
                int IncubationBath1StartMinute = 0;
                if (labSheetModelAndA1Sheet.LabSheetA1Sheet.IncubationBath1StartTime.Length == 5)
                {
                    IncubationBath1StartHour = int.Parse(labSheetModelAndA1Sheet.LabSheetA1Sheet.IncubationBath1StartTime.Substring(0, 2));
                    IncubationBath1StartMinute = int.Parse(labSheetModelAndA1Sheet.LabSheetA1Sheet.IncubationBath1StartTime.Substring(3, 2));
                }
                if (IncubationBath1StartYear != 1900)
                {
                    IncubationBath1StartDate = new DateTime(IncubationBath1StartYear, IncubationBath1StartMonth, IncubationBath1StartDay, IncubationBath1StartHour, IncubationBath1StartMinute, 0);
                }

                labSheetDetailModelNew.IncubationBath1StartTime = IncubationBath1StartDate;

                // IncubationBath1EndDate
                DateTime IncubationBath1EndDate = new DateTime();
                int IncubationBath1EndYear = (string.IsNullOrWhiteSpace(labSheetModelAndA1Sheet.LabSheetA1Sheet.RunYear) ? 1900 : int.Parse(labSheetModelAndA1Sheet.LabSheetA1Sheet.RunYear));
                int IncubationBath1EndMonth = (string.IsNullOrWhiteSpace(labSheetModelAndA1Sheet.LabSheetA1Sheet.RunMonth) ? 1 : int.Parse(labSheetModelAndA1Sheet.LabSheetA1Sheet.RunMonth));
                int IncubationBath1EndDay = (string.IsNullOrWhiteSpace(labSheetModelAndA1Sheet.LabSheetA1Sheet.RunDay) ? 1 : int.Parse(labSheetModelAndA1Sheet.LabSheetA1Sheet.RunDay));
                int IncubationBath1EndHour = 0;
                int IncubationBath1EndMinute = 0;
                if (labSheetModelAndA1Sheet.LabSheetA1Sheet.IncubationBath1EndTime.Length == 5)
                {
                    IncubationBath1EndHour = int.Parse(labSheetModelAndA1Sheet.LabSheetA1Sheet.IncubationBath1EndTime.Substring(0, 2));
                    IncubationBath1EndMinute = int.Parse(labSheetModelAndA1Sheet.LabSheetA1Sheet.IncubationBath1EndTime.Substring(3, 2));
                }
                if (IncubationBath1EndYear != 1900)
                {
                    IncubationBath1EndDate = new DateTime(IncubationBath1EndYear, IncubationBath1EndMonth, IncubationBath1EndDay, IncubationBath1EndHour, IncubationBath1EndMinute, 0).AddDays(1);
                }

                labSheetDetailModelNew.IncubationBath1EndTime = IncubationBath1EndDate;

                // IncubationBath1TimeCalculated_minutes 
                int IncubationBath1TimeCalculated_minutes = 0;
                if (labSheetModelAndA1Sheet.LabSheetA1Sheet.IncubationBath1TimeCalculated.Length == 5)
                {
                    IncubationBath1TimeCalculated_minutes = int.Parse(labSheetModelAndA1Sheet.LabSheetA1Sheet.IncubationBath1TimeCalculated.Substring(0, 2)) * 60;
                    IncubationBath1TimeCalculated_minutes += int.Parse(labSheetModelAndA1Sheet.LabSheetA1Sheet.IncubationBath1TimeCalculated.Substring(3, 2));
                }

                labSheetDetailModelNew.IncubationBath1TimeCalculated_minutes = IncubationBath1TimeCalculated_minutes;

                labSheetDetailModelNew.WaterBath1 = labSheetModelAndA1Sheet.LabSheetA1Sheet.WaterBath1;

                labSheetDetailModelNew.WaterBathCount = labSheetModelAndA1Sheet.LabSheetA1Sheet.WaterBathCount;

                if (labSheetDetailModelNew.WaterBathCount > 1)
                {
                    // IncubationBath2StartDate
                    DateTime IncubationBath2StartDate = new DateTime();
                    int IncubationBath2StartYear = (string.IsNullOrWhiteSpace(labSheetModelAndA1Sheet.LabSheetA1Sheet.RunYear) ? 1900 : int.Parse(labSheetModelAndA1Sheet.LabSheetA1Sheet.RunYear));
                    int IncubationBath2StartMonth = (string.IsNullOrWhiteSpace(labSheetModelAndA1Sheet.LabSheetA1Sheet.RunMonth) ? 1 : int.Parse(labSheetModelAndA1Sheet.LabSheetA1Sheet.RunMonth));
                    int IncubationBath2StartDay = (string.IsNullOrWhiteSpace(labSheetModelAndA1Sheet.LabSheetA1Sheet.RunDay) ? 1 : int.Parse(labSheetModelAndA1Sheet.LabSheetA1Sheet.RunDay));
                    int IncubationBath2StartHour = 0;
                    int IncubationBath2StartMinute = 0;
                    if (labSheetModelAndA1Sheet.LabSheetA1Sheet.IncubationBath2StartTime.Length == 5)
                    {
                        IncubationBath2StartHour = int.Parse(labSheetModelAndA1Sheet.LabSheetA1Sheet.IncubationBath2StartTime.Substring(0, 2));
                        IncubationBath2StartMinute = int.Parse(labSheetModelAndA1Sheet.LabSheetA1Sheet.IncubationBath2StartTime.Substring(3, 2));
                    }
                    if (IncubationBath2StartYear != 1900)
                    {
                        IncubationBath2StartDate = new DateTime(IncubationBath2StartYear, IncubationBath2StartMonth, IncubationBath2StartDay, IncubationBath2StartHour, IncubationBath2StartMinute, 0);
                    }

                    labSheetDetailModelNew.IncubationBath2StartTime = IncubationBath2StartDate;

                    // IncubationBath2EndDate
                    DateTime IncubationBath2EndDate = new DateTime();
                    int IncubationBath2EndYear = (string.IsNullOrWhiteSpace(labSheetModelAndA1Sheet.LabSheetA1Sheet.RunYear) ? 1900 : int.Parse(labSheetModelAndA1Sheet.LabSheetA1Sheet.RunYear));
                    int IncubationBath2EndMonth = (string.IsNullOrWhiteSpace(labSheetModelAndA1Sheet.LabSheetA1Sheet.RunMonth) ? 1 : int.Parse(labSheetModelAndA1Sheet.LabSheetA1Sheet.RunMonth));
                    int IncubationBath2EndDay = (string.IsNullOrWhiteSpace(labSheetModelAndA1Sheet.LabSheetA1Sheet.RunDay) ? 1 : int.Parse(labSheetModelAndA1Sheet.LabSheetA1Sheet.RunDay));
                    int IncubationBath2EndHour = 0;
                    int IncubationBath2EndMinute = 0;
                    if (labSheetModelAndA1Sheet.LabSheetA1Sheet.IncubationBath2EndTime.Length == 5)
                    {
                        IncubationBath2EndHour = int.Parse(labSheetModelAndA1Sheet.LabSheetA1Sheet.IncubationBath2EndTime.Substring(0, 2));
                        IncubationBath2EndMinute = int.Parse(labSheetModelAndA1Sheet.LabSheetA1Sheet.IncubationBath2EndTime.Substring(3, 2));
                    }
                    if (IncubationBath2EndYear != 1900)
                    {
                        IncubationBath2EndDate = new DateTime(IncubationBath2EndYear, IncubationBath2EndMonth, IncubationBath2EndDay, IncubationBath2EndHour, IncubationBath2EndMinute, 0).AddDays(1);
                    }

                    labSheetDetailModelNew.IncubationBath2EndTime = IncubationBath2EndDate;

                    // IncubationBath2TimeCalculated_minutes 
                    int IncubationBath2TimeCalculated_minutes = 0;
                    if (labSheetModelAndA1Sheet.LabSheetA1Sheet.IncubationBath2TimeCalculated.Length == 5)
                    {
                        IncubationBath2TimeCalculated_minutes = int.Parse(labSheetModelAndA1Sheet.LabSheetA1Sheet.IncubationBath2TimeCalculated.Substring(0, 2)) * 60;
                        IncubationBath2TimeCalculated_minutes += int.Parse(labSheetModelAndA1Sheet.LabSheetA1Sheet.IncubationBath2TimeCalculated.Substring(3, 2));
                    }

                    labSheetDetailModelNew.IncubationBath2TimeCalculated_minutes = IncubationBath2TimeCalculated_minutes;

                    labSheetDetailModelNew.WaterBath2 = labSheetModelAndA1Sheet.LabSheetA1Sheet.WaterBath2;
                    labSheetDetailModelNew.Bath2Positive44_5 = labSheetModelAndA1Sheet.LabSheetA1Sheet.Bath2Positive44_5;
                    labSheetDetailModelNew.Bath2NonTarget44_5 = labSheetModelAndA1Sheet.LabSheetA1Sheet.Bath2NonTarget44_5;
                    labSheetDetailModelNew.Bath2Negative44_5 = labSheetModelAndA1Sheet.LabSheetA1Sheet.Bath2Negative44_5;
                    labSheetDetailModelNew.Bath2Blank44_5 = labSheetModelAndA1Sheet.LabSheetA1Sheet.Bath2Blank44_5;

                }

                if (labSheetDetailModelNew.WaterBathCount > 2)
                {
                    // IncubationBath3StartDate
                    DateTime IncubationBath3StartDate = new DateTime();
                    int IncubationBath3StartYear = (string.IsNullOrWhiteSpace(labSheetModelAndA1Sheet.LabSheetA1Sheet.RunYear) ? 1900 : int.Parse(labSheetModelAndA1Sheet.LabSheetA1Sheet.RunYear));
                    int IncubationBath3StartMonth = (string.IsNullOrWhiteSpace(labSheetModelAndA1Sheet.LabSheetA1Sheet.RunMonth) ? 1 : int.Parse(labSheetModelAndA1Sheet.LabSheetA1Sheet.RunMonth));
                    int IncubationBath3StartDay = (string.IsNullOrWhiteSpace(labSheetModelAndA1Sheet.LabSheetA1Sheet.RunDay) ? 1 : int.Parse(labSheetModelAndA1Sheet.LabSheetA1Sheet.RunDay));
                    int IncubationBath3StartHour = 0;
                    int IncubationBath3StartMinute = 0;
                    if (labSheetModelAndA1Sheet.LabSheetA1Sheet.IncubationBath3StartTime.Length == 5)
                    {
                        IncubationBath3StartHour = int.Parse(labSheetModelAndA1Sheet.LabSheetA1Sheet.IncubationBath3StartTime.Substring(0, 2));
                        IncubationBath3StartMinute = int.Parse(labSheetModelAndA1Sheet.LabSheetA1Sheet.IncubationBath3StartTime.Substring(3, 2));
                    }
                    if (IncubationBath3StartYear != 1900)
                    {
                        IncubationBath3StartDate = new DateTime(IncubationBath3StartYear, IncubationBath3StartMonth, IncubationBath3StartDay, IncubationBath3StartHour, IncubationBath3StartMinute, 0);
                    }

                    labSheetDetailModelNew.IncubationBath3StartTime = IncubationBath3StartDate;

                    // IncubationBath3EndDate
                    DateTime IncubationBath3EndDate = new DateTime();
                    int IncubationBath3EndYear = (string.IsNullOrWhiteSpace(labSheetModelAndA1Sheet.LabSheetA1Sheet.RunYear) ? 1900 : int.Parse(labSheetModelAndA1Sheet.LabSheetA1Sheet.RunYear));
                    int IncubationBath3EndMonth = (string.IsNullOrWhiteSpace(labSheetModelAndA1Sheet.LabSheetA1Sheet.RunMonth) ? 1 : int.Parse(labSheetModelAndA1Sheet.LabSheetA1Sheet.RunMonth));
                    int IncubationBath3EndDay = (string.IsNullOrWhiteSpace(labSheetModelAndA1Sheet.LabSheetA1Sheet.RunDay) ? 1 : int.Parse(labSheetModelAndA1Sheet.LabSheetA1Sheet.RunDay));
                    int IncubationBath3EndHour = 0;
                    int IncubationBath3EndMinute = 0;
                    if (labSheetModelAndA1Sheet.LabSheetA1Sheet.IncubationBath3EndTime.Length == 5)
                    {
                        IncubationBath3EndHour = int.Parse(labSheetModelAndA1Sheet.LabSheetA1Sheet.IncubationBath3EndTime.Substring(0, 2));
                        IncubationBath3EndMinute = int.Parse(labSheetModelAndA1Sheet.LabSheetA1Sheet.IncubationBath3EndTime.Substring(3, 2));
                    }
                    if (IncubationBath3EndYear != 1900)
                    {
                        IncubationBath3EndDate = new DateTime(IncubationBath3EndYear, IncubationBath3EndMonth, IncubationBath3EndDay, IncubationBath3EndHour, IncubationBath3EndMinute, 0).AddDays(1);
                    }

                    labSheetDetailModelNew.IncubationBath3EndTime = IncubationBath3EndDate;

                    // IncubationBath3TimeCalculated_minutes 
                    int IncubationBath3TimeCalculated_minutes = 0;
                    if (labSheetModelAndA1Sheet.LabSheetA1Sheet.IncubationBath3TimeCalculated.Length == 5)
                    {
                        IncubationBath3TimeCalculated_minutes = int.Parse(labSheetModelAndA1Sheet.LabSheetA1Sheet.IncubationBath3TimeCalculated.Substring(0, 2)) * 60;
                        IncubationBath3TimeCalculated_minutes += int.Parse(labSheetModelAndA1Sheet.LabSheetA1Sheet.IncubationBath3TimeCalculated.Substring(3, 2));
                    }

                    labSheetDetailModelNew.IncubationBath3TimeCalculated_minutes = IncubationBath3TimeCalculated_minutes;

                    labSheetDetailModelNew.WaterBath3 = labSheetModelAndA1Sheet.LabSheetA1Sheet.WaterBath3;
                    labSheetDetailModelNew.Bath3Positive44_5 = labSheetModelAndA1Sheet.LabSheetA1Sheet.Bath3Positive44_5;
                    labSheetDetailModelNew.Bath3NonTarget44_5 = labSheetModelAndA1Sheet.LabSheetA1Sheet.Bath3NonTarget44_5;
                    labSheetDetailModelNew.Bath3Negative44_5 = labSheetModelAndA1Sheet.LabSheetA1Sheet.Bath3Negative44_5;
                    labSheetDetailModelNew.Bath3Blank44_5 = labSheetModelAndA1Sheet.LabSheetA1Sheet.Bath3Blank44_5;

                }

                labSheetDetailModelNew.TCField1 = null;
                if (!string.IsNullOrWhiteSpace(labSheetModelAndA1Sheet.LabSheetA1Sheet.TCField1))
                {
                    float temp = 0.0f;
                    if (float.TryParse(labSheetModelAndA1Sheet.LabSheetA1Sheet.TCField1, out temp))
                    {
                        labSheetDetailModelNew.TCField1 = temp;
                    }
                }
                labSheetDetailModelNew.TCLab1 = null;
                if (!string.IsNullOrWhiteSpace(labSheetModelAndA1Sheet.LabSheetA1Sheet.TCLab1))
                {
                    float temp = 0.0f;
                    if (float.TryParse(labSheetModelAndA1Sheet.LabSheetA1Sheet.TCLab1, out temp))
                    {
                        labSheetDetailModelNew.TCLab1 = temp;
                    }
                }
                labSheetDetailModelNew.TCField2 = null;
                if (!string.IsNullOrWhiteSpace(labSheetModelAndA1Sheet.LabSheetA1Sheet.TCField2))
                {
                    float temp = 0.0f;
                    if (float.TryParse(labSheetModelAndA1Sheet.LabSheetA1Sheet.TCField2, out temp))
                    {
                        labSheetDetailModelNew.TCField2 = temp;
                    }
                }
                labSheetDetailModelNew.TCLab2 = null;
                if (!string.IsNullOrWhiteSpace(labSheetModelAndA1Sheet.LabSheetA1Sheet.TCLab2))
                {
                    float temp = 0.0f;
                    if (float.TryParse(labSheetModelAndA1Sheet.LabSheetA1Sheet.TCLab2, out temp))
                    {
                        labSheetDetailModelNew.TCLab2 = temp;
                    }
                }
                labSheetDetailModelNew.TCFirst = null;
                if (!string.IsNullOrWhiteSpace(labSheetModelAndA1Sheet.LabSheetA1Sheet.TCFirst) && !labSheetModelAndA1Sheet.LabSheetA1Sheet.TCFirst.Contains("-"))
                {
                    float temp = 0.0f;
                    if (float.TryParse(labSheetModelAndA1Sheet.LabSheetA1Sheet.TCFirst, out temp))
                    {
                        labSheetDetailModelNew.TCFirst = temp;
                    }
                }
                labSheetDetailModelNew.TCAverage = null;
                if (!string.IsNullOrWhiteSpace(labSheetModelAndA1Sheet.LabSheetA1Sheet.TCAverage) && !labSheetModelAndA1Sheet.LabSheetA1Sheet.TCAverage.Contains("-"))
                {
                    float temp = 0.0f;
                    if (float.TryParse(labSheetModelAndA1Sheet.LabSheetA1Sheet.TCAverage, out temp))
                    {
                        labSheetDetailModelNew.TCAverage = temp;
                    }
                }
                labSheetDetailModelNew.ControlLot = labSheetModelAndA1Sheet.LabSheetA1Sheet.ControlLot;
                labSheetDetailModelNew.Positive35 = labSheetModelAndA1Sheet.LabSheetA1Sheet.Positive35;
                labSheetDetailModelNew.NonTarget35 = labSheetModelAndA1Sheet.LabSheetA1Sheet.NonTarget35;
                labSheetDetailModelNew.Negative35 = labSheetModelAndA1Sheet.LabSheetA1Sheet.Negative35;
                labSheetDetailModelNew.Bath1Positive44_5 = labSheetModelAndA1Sheet.LabSheetA1Sheet.Bath1Positive44_5;
                labSheetDetailModelNew.Bath1NonTarget44_5 = labSheetModelAndA1Sheet.LabSheetA1Sheet.Bath1NonTarget44_5;
                labSheetDetailModelNew.Bath1Negative44_5 = labSheetModelAndA1Sheet.LabSheetA1Sheet.Bath1Negative44_5;
                labSheetDetailModelNew.Blank35 = labSheetModelAndA1Sheet.LabSheetA1Sheet.Blank35;
                labSheetDetailModelNew.Bath1Blank44_5 = labSheetModelAndA1Sheet.LabSheetA1Sheet.Bath1Blank44_5;
                labSheetDetailModelNew.Lot35 = labSheetModelAndA1Sheet.LabSheetA1Sheet.Lot35;
                labSheetDetailModelNew.Lot44_5 = labSheetModelAndA1Sheet.LabSheetA1Sheet.Lot44_5;
                labSheetDetailModelNew.RunComment = labSheetModelAndA1Sheet.LabSheetA1Sheet.RunComment;
                labSheetDetailModelNew.RunWeatherComment = labSheetModelAndA1Sheet.LabSheetA1Sheet.RunWeatherComment;
                labSheetDetailModelNew.SampleBottleLotNumber = labSheetModelAndA1Sheet.LabSheetA1Sheet.SampleBottleLotNumber;
                labSheetDetailModelNew.SalinitiesReadBy = labSheetModelAndA1Sheet.LabSheetA1Sheet.SalinitiesReadBy;

                // SalinitiesReadDate
                DateTime SalinitiesReadDate = new DateTime();
                int SalinitiesReadYear = (string.IsNullOrWhiteSpace(labSheetModelAndA1Sheet.LabSheetA1Sheet.SalinitiesReadYear) ? 1900 : int.Parse(labSheetModelAndA1Sheet.LabSheetA1Sheet.SalinitiesReadYear));
                int SalinitiesReadMonth = (string.IsNullOrWhiteSpace(labSheetModelAndA1Sheet.LabSheetA1Sheet.SalinitiesReadMonth) ? 1 : int.Parse(labSheetModelAndA1Sheet.LabSheetA1Sheet.SalinitiesReadMonth));
                int SalinitiesReadDay = (string.IsNullOrWhiteSpace(labSheetModelAndA1Sheet.LabSheetA1Sheet.SalinitiesReadDay) ? 1 : int.Parse(labSheetModelAndA1Sheet.LabSheetA1Sheet.SalinitiesReadDay));
                if (SalinitiesReadYear != 1900)
                {
                    SalinitiesReadDate = new DateTime(SalinitiesReadYear, SalinitiesReadMonth, SalinitiesReadDay);
                }

                labSheetDetailModelNew.SalinitiesReadDate = SalinitiesReadDate;
                labSheetDetailModelNew.ResultsReadBy = labSheetModelAndA1Sheet.LabSheetA1Sheet.ResultsReadBy;

                // ResultsReadDate
                DateTime ResultsReadDate = new DateTime();
                int ResultsReadYear = (string.IsNullOrWhiteSpace(labSheetModelAndA1Sheet.LabSheetA1Sheet.ResultsReadYear) ? 1900 : int.Parse(labSheetModelAndA1Sheet.LabSheetA1Sheet.ResultsReadYear));
                int ResultsReadMonth = (string.IsNullOrWhiteSpace(labSheetModelAndA1Sheet.LabSheetA1Sheet.ResultsReadMonth) ? 1 : int.Parse(labSheetModelAndA1Sheet.LabSheetA1Sheet.ResultsReadMonth));
                int ResultsReadDay = (string.IsNullOrWhiteSpace(labSheetModelAndA1Sheet.LabSheetA1Sheet.ResultsReadDay) ? 1 : int.Parse(labSheetModelAndA1Sheet.LabSheetA1Sheet.ResultsReadDay));
                if (ResultsReadYear != 1900)
                {
                    ResultsReadDate = new DateTime(ResultsReadYear, ResultsReadMonth, ResultsReadDay);
                }

                labSheetDetailModelNew.ResultsReadDate = ResultsReadDate;
                labSheetDetailModelNew.ResultsRecordedBy = labSheetModelAndA1Sheet.LabSheetA1Sheet.ResultsRecordedBy;

                // ResultsRecordedDate
                DateTime ResultsRecordedDate = new DateTime();
                int ResultsRecordedYear = (string.IsNullOrWhiteSpace(labSheetModelAndA1Sheet.LabSheetA1Sheet.ResultsRecordedYear) ? 1900 : int.Parse(labSheetModelAndA1Sheet.LabSheetA1Sheet.ResultsRecordedYear));
                int ResultsRecordedMonth = (string.IsNullOrWhiteSpace(labSheetModelAndA1Sheet.LabSheetA1Sheet.ResultsRecordedMonth) ? 1 : int.Parse(labSheetModelAndA1Sheet.LabSheetA1Sheet.ResultsRecordedMonth));
                int ResultsRecordedDay = (string.IsNullOrWhiteSpace(labSheetModelAndA1Sheet.LabSheetA1Sheet.ResultsRecordedDay) ? 1 : int.Parse(labSheetModelAndA1Sheet.LabSheetA1Sheet.ResultsRecordedDay));
                if (ResultsRecordedYear != 1900)
                {
                    ResultsRecordedDate = new DateTime(ResultsRecordedYear, ResultsRecordedMonth, ResultsRecordedDay);
                }

                labSheetDetailModelNew.ResultsRecordedDate = ResultsRecordedDate;

                labSheetDetailModelNew.DailyDuplicateRLog = 0.0f;
                if (!string.IsNullOrWhiteSpace(labSheetModelAndA1Sheet.LabSheetA1Sheet.DailyDuplicateRLog) && !labSheetModelAndA1Sheet.LabSheetA1Sheet.DailyDuplicateRLog.StartsWith("N"))
                {
                    try
                    {
                        labSheetDetailModelNew.DailyDuplicateRLog = float.Parse(labSheetModelAndA1Sheet.LabSheetA1Sheet.DailyDuplicateRLog);
                    }
                    catch (Exception)
                    {
                        // nothing
                    }
                }

                labSheetDetailModelNew.DailyDuplicatePrecisionCriteria = null;
                labSheetDetailModelNew.DailyDuplicateRLog = null;
                labSheetDetailModelNew.DailyDuplicateAcceptable = null;
                labSheetDetailModelNew.IntertechDuplicatePrecisionCriteria = null;
                labSheetDetailModelNew.IntertechDuplicateRLog = null;
                labSheetDetailModelNew.IntertechDuplicateAcceptable = null;
                labSheetDetailModelNew.IntertechReadAcceptable = null;

                if (!string.IsNullOrWhiteSpace(labSheetModelAndA1Sheet.LabSheetA1Sheet.DailyDuplicatePrecisionCriteria))
                {
                    labSheetDetailModelNew.DailyDuplicatePrecisionCriteria = float.Parse(labSheetModelAndA1Sheet.LabSheetA1Sheet.DailyDuplicatePrecisionCriteria);
                }

                if (!string.IsNullOrWhiteSpace(labSheetModelAndA1Sheet.LabSheetA1Sheet.DailyDuplicateRLog))
                {
                    if (!labSheetModelAndA1Sheet.LabSheetA1Sheet.DailyDuplicateRLog.StartsWith("N"))
                    {
                        labSheetDetailModelNew.DailyDuplicateRLog = float.Parse(labSheetModelAndA1Sheet.LabSheetA1Sheet.DailyDuplicateRLog);
                    }
                }

                if (!string.IsNullOrWhiteSpace(labSheetModelAndA1Sheet.LabSheetA1Sheet.DailyDuplicateAcceptableOrUnacceptable))
                {
                    labSheetDetailModelNew.DailyDuplicateAcceptable = (labSheetModelAndA1Sheet.LabSheetA1Sheet.DailyDuplicateAcceptableOrUnacceptable != "Acceptable" ? false : true);
                }

                if (!string.IsNullOrWhiteSpace(labSheetModelAndA1Sheet.LabSheetA1Sheet.IntertechDuplicatePrecisionCriteria))
                {
                    labSheetDetailModelNew.IntertechDuplicatePrecisionCriteria = float.Parse(labSheetModelAndA1Sheet.LabSheetA1Sheet.IntertechDuplicatePrecisionCriteria);
                }

                if (!string.IsNullOrWhiteSpace(labSheetModelAndA1Sheet.LabSheetA1Sheet.IntertechDuplicateRLog))
                {
                    if (!labSheetModelAndA1Sheet.LabSheetA1Sheet.IntertechDuplicateRLog.StartsWith("N"))
                    {
                        labSheetDetailModelNew.IntertechDuplicateRLog = float.Parse(labSheetModelAndA1Sheet.LabSheetA1Sheet.IntertechDuplicateRLog);
                    }
                }

                if (!string.IsNullOrWhiteSpace(labSheetModelAndA1Sheet.LabSheetA1Sheet.IntertechDuplicateAcceptableOrUnacceptable))
                {
                    labSheetDetailModelNew.IntertechDuplicateAcceptable = (labSheetModelAndA1Sheet.LabSheetA1Sheet.IntertechDuplicateAcceptableOrUnacceptable != "Acceptable" ? false : true);
                }

                if (!string.IsNullOrWhiteSpace(labSheetModelAndA1Sheet.LabSheetA1Sheet.IntertechReadAcceptableOrUnacceptable))
                {
                    labSheetDetailModelNew.IntertechReadAcceptable = (labSheetModelAndA1Sheet.LabSheetA1Sheet.IntertechReadAcceptableOrUnacceptable != "Acceptable" ? false : true);
                }
            }

            LabSheetDetailService labSheetDetailService = new LabSheetDetailService(LanguageEnum.en, _User);

            LabSheetDetailModel labSheetDetailModelExist = labSheetDetailService.GetLabSheetDetailModelExistDB(labSheetDetailModelNew);
            if (!string.IsNullOrWhiteSpace(labSheetDetailModelExist.Error))
            {
                labSheetDetailModelExist = labSheetDetailService.PostAddLabSheetDetailDB(labSheetDetailModelNew);
                if (!string.IsNullOrWhiteSpace(labSheetDetailModelExist.Error))
                {
                    richTextBoxStatus.AppendText("Lab sheet detail could not be loaded to the local DB. Error [" + labSheetDetailModelExist.Error + "]\r\n");
                    return labSheetDetailModelExist.Error;
                }
            }
            else
            {
                labSheetDetailModelNew.LabSheetDetailID = labSheetDetailModelExist.LabSheetDetailID;
                labSheetDetailModelExist = labSheetDetailService.PostUpdateLabSheetDetailDB(labSheetDetailModelNew);
                if (!string.IsNullOrWhiteSpace(labSheetDetailModelExist.Error))
                {
                    richTextBoxStatus.AppendText("Lab sheet detail could not be loaded to the local DB. Error [" + labSheetDetailModelExist.Error + "]\r\n");
                    return labSheetDetailModelExist.Error;
                }
            }

            retStr = UploadLabSheetTubeMPNDetailInDB(labSheetDetailModelExist.LabSheetDetailID, labSheetModelAndA1Sheet.LabSheetA1Sheet.LabSheetA1MeasurementList);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                richTextBoxStatus.AppendText("Lab sheet tube and MPN detail could not be loaded to the local DB. Error [" + retStr + "]\r\n");
                return retStr;
            }

            return retStr;
        }
        public string UploadLabSheetTubeMPNDetailInDB(int LabSheetDetailID, List<LabSheetA1Measurement> labSheetA1MeasurementList)
        {
            string retStr = "";

            LabSheetTubeMPNDetailService labSheetTubeMPNDetailService = new LabSheetTubeMPNDetailService(LanguageEnum.en, _User);

            int Ordinal = 0;
            foreach (LabSheetA1Measurement labSheetA1Measurement in labSheetA1MeasurementList)
            {
                LabSheetTubeMPNDetailModel labSheetTubeMPNDetailModelNew = new LabSheetTubeMPNDetailModel();
                labSheetTubeMPNDetailModelNew.LabSheetDetailID = LabSheetDetailID;
                labSheetTubeMPNDetailModelNew.Ordinal = Ordinal;
                labSheetTubeMPNDetailModelNew.MWQMSiteTVItemID = labSheetA1Measurement.TVItemID;
                labSheetTubeMPNDetailModelNew.SampleDateTime = labSheetA1Measurement.Time;
                labSheetTubeMPNDetailModelNew.MPN = labSheetA1Measurement.MPN;
                labSheetTubeMPNDetailModelNew.Tube10 = labSheetA1Measurement.Tube10;
                labSheetTubeMPNDetailModelNew.Tube1_0 = labSheetA1Measurement.Tube1_0;
                labSheetTubeMPNDetailModelNew.Tube0_1 = labSheetA1Measurement.Tube0_1;
                labSheetTubeMPNDetailModelNew.Salinity = labSheetA1Measurement.Salinity;
                labSheetTubeMPNDetailModelNew.Temperature = labSheetA1Measurement.Temperature;
                labSheetTubeMPNDetailModelNew.ProcessedBy = labSheetA1Measurement.ProcessedBy;
                labSheetTubeMPNDetailModelNew.SampleType = (SampleTypeEnum)labSheetA1Measurement.SampleType;
                labSheetTubeMPNDetailModelNew.SiteComment = labSheetA1Measurement.SiteComment;

                LabSheetTubeMPNDetailModel labSheetTubeMPNDetailModelExist = labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailModelExistDB(labSheetTubeMPNDetailModelNew);
                if (!string.IsNullOrWhiteSpace(labSheetTubeMPNDetailModelExist.Error))
                {
                    labSheetTubeMPNDetailModelExist = labSheetTubeMPNDetailService.PostAddLabSheetTubeMPNDetailDB(labSheetTubeMPNDetailModelNew);
                    if (!string.IsNullOrWhiteSpace(labSheetTubeMPNDetailModelExist.Error))
                        return labSheetTubeMPNDetailModelExist.Error;
                }
                else
                {
                    labSheetTubeMPNDetailModelNew.LabSheetTubeMPNDetailID = labSheetTubeMPNDetailModelExist.LabSheetTubeMPNDetailID;
                    labSheetTubeMPNDetailModelExist = labSheetTubeMPNDetailService.PostUpdateLabSheetTubeMPNDetailDB(labSheetTubeMPNDetailModelNew);
                    if (!string.IsNullOrWhiteSpace(labSheetTubeMPNDetailModelExist.Error))
                        return labSheetTubeMPNDetailModelExist.Error;
                }

                Ordinal += 1;
            }

            return retStr;
        }
        public void GetNextLabSheet()
        {
            string retStr = "";
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    WebProxy webProxy = new WebProxy();
                    webClient.Proxy = webProxy;

                    string FullLabSheetText = webClient.DownloadString(new Uri("http://cssplabsheet.azurewebsites.net/GetNextLabSheet.aspx"));

                    if (FullLabSheetText.Length > 0)
                    {
                        int posStart = FullLabSheetText.IndexOf("OtherServerLabSheetID|||||[") + 27;
                        int posEnd = FullLabSheetText.IndexOf("]", posStart);
                        string OtherServerLabSheetIDTxt = FullLabSheetText.Substring(posStart, posEnd - posStart);
                        int OtherServerLabSheetID = int.Parse(OtherServerLabSheetIDTxt);

                        posStart = FullLabSheetText.IndexOf("SubsectorTVItemID|||||[") + 23;
                        posEnd = FullLabSheetText.IndexOf("]", posStart);
                        string SubsectorTVItemIDTxt = FullLabSheetText.Substring(posStart, posEnd - posStart);
                        int SubsectorTVItemID = int.Parse(SubsectorTVItemIDTxt);

                        TVItemModel tvItemModelSubsector = new TVItemModel();
                        TVItemModel tvItemModelCountry = new TVItemModel();
                        TVItemModel tvItemModelProvince = new TVItemModel();
                        LabSheetModelAndA1Sheet labSheetModelAndA1Sheet = new LabSheetModelAndA1Sheet();
                        using (TransactionScope ts = new TransactionScope())
                        {
                            LabSheetService labSheetService = new LabSheetService(LanguageEnum.en, _User);

                            LabSheetModel labSheetModelRet = labSheetService.AddOrUpdateLabSheetDB(FullLabSheetText);
                            if (!string.IsNullOrWhiteSpace(labSheetModelRet.Error))
                            {
                                richTextBoxStatus.AppendText("Lab sheet adding error OtherServerLabSheetID [" + OtherServerLabSheetID.ToString() + "]" + labSheetModelRet.Error + "]\r\n");
                                return;
                            }

                            TVItemService tvItemService = new TVItemService(LanguageEnum.en, _User);

                            tvItemModelSubsector = tvItemService.GetTVItemModelWithTVItemIDDB(SubsectorTVItemID);
                            if (!string.IsNullOrWhiteSpace(tvItemModelSubsector.Error))
                            {
                                richTextBoxStatus.AppendText("Lab sheet parsing error OtherServerLabSheetID [" + OtherServerLabSheetID.ToString() + "]" + tvItemModelSubsector.Error + "]\r\n");
                                return;
                            }

                            List<TVItemModel> tvItemModelList = tvItemService.GetParentsTVItemModelList(tvItemModelSubsector.TVPath);
                            foreach (TVItemModel tvItemModel in tvItemModelList)
                            {
                                if (tvItemModel.TVType == TVTypeEnum.Province)
                                {
                                    tvItemModelProvince = tvItemModel;
                                }
                                if (tvItemModel.TVType == TVTypeEnum.Country)
                                {
                                    tvItemModelCountry = tvItemModel;
                                }
                            }

                            labSheetModelAndA1Sheet.LabSheetModel = labSheetModelRet;
                            labSheetModelAndA1Sheet.LabSheetA1Sheet = labSheetService.ParseLabSheetA1WithLabSheetID(labSheetModelRet.LabSheetID);
                            if (!string.IsNullOrWhiteSpace(labSheetModelAndA1Sheet.LabSheetA1Sheet.Error))
                            {
                                richTextBoxStatus.AppendText("Lab sheet parsing error OtherServerLabSheetID [" + OtherServerLabSheetID.ToString() + "]" + labSheetModelAndA1Sheet.LabSheetA1Sheet.Error + "]\r\n");
                                richTextBoxStatus.AppendText("Full Lab Sheet Text below\r\n");
                                richTextBoxStatus.AppendText("---------------- Start of full lab sheet text -----------\r\n");
                                richTextBoxStatus.AppendText(FullLabSheetText);
                                richTextBoxStatus.AppendText("---------------- End of full lab sheet text -----------\r\n");
                                retStr = UpdateOtherServerWithOtherServerLabSheetIDAndLabSheetStatus(OtherServerLabSheetID, LabSheetStatusEnum.Error);
                                if (!string.IsNullOrWhiteSpace(retStr))
                                {
                                    richTextBoxStatus.AppendText("Error updating other server lab sheet [" + retStr + "]");
                                }
                                return;
                            }

                            string retStr2 = UploadLabSheetDetailInDB(labSheetModelAndA1Sheet);
                            if (!string.IsNullOrWhiteSpace(retStr2))
                            {
                                // Error message already sent to richTextboxStatus
                                retStr = UpdateOtherServerWithOtherServerLabSheetIDAndLabSheetStatus(OtherServerLabSheetID, LabSheetStatusEnum.Error);
                                if (!string.IsNullOrWhiteSpace(retStr))
                                {
                                    richTextBoxStatus.AppendText("Error updating other server lab sheet [" + retStr + "]");
                                }
                                return;
                            }

                            ts.Complete();
                        }

                        string href = "http://wmon01dtchlebl2/csspwebtools/en-CA/#!View/" + (tvItemModelCountry.TVText + "-" + tvItemModelProvince.TVText).Replace(" ", "-") + "|||" + tvItemModelProvince.TVItemID.ToString() + "|||010003030200000000000000000000";

                        if (labSheetModelAndA1Sheet.LabSheetA1Sheet.LabSheetA1MeasurementList.Where(c => c.MPN != null && c.MPN >= MPNLimitForEmail).Any())
                        {
                            SendNewLabSheetEmailBigMPN(href, tvItemModelProvince, tvItemModelSubsector, labSheetModelAndA1Sheet);
                        }
                        else
                        {
                            SendNewLabSheetEmail(href, tvItemModelProvince, tvItemModelSubsector, labSheetModelAndA1Sheet);
                        }

                        retStr = UpdateOtherServerWithOtherServerLabSheetIDAndLabSheetStatus(OtherServerLabSheetID, LabSheetStatusEnum.Transferred);
                        if (!string.IsNullOrWhiteSpace(retStr))
                        {
                            richTextBoxStatus.AppendText("Error updating other server lab sheet [" + retStr + "]");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string errrrrr = ex.Message;
            }
        }
        private void SendNewLabSheetEmailBigMPN(string href, TVItemModel tvItemModelProvince, TVItemModel tvItemModelSubsector, LabSheetModelAndA1Sheet labSheetModelAndA1Sheet)
        {
            SamplingPlanService samplingPlanService = new SamplingPlanService(LanguageEnum.en, _User);

            SamplingPlanModel samplingPlanModel = samplingPlanService.GetSamplingPlanModelWithSamplingPlanIDDB(labSheetModelAndA1Sheet.LabSheetModel.SamplingPlanID);

            SamplingPlanEmailService samplingPlanEmailService = new SamplingPlanEmailService(LanguageEnum.en, _User);

            List<SamplingPlanEmailModel> SamplingPlanEmailModelList = samplingPlanEmailService.GetSamplingPlanEmailModelListWithSamplingPlanIDDB(samplingPlanModel.SamplingPlanID);

            if (!samplingPlanModel.IsActive)
            {
                return;
            }

            // sending email to Non Contractors

            foreach (bool IsContractor in new List<bool> { false, true })
            {
                MailMessage mail = new MailMessage();

                foreach (SamplingPlanEmailModel samplingPlanEmailModel in SamplingPlanEmailModelList.Where(c => c.IsContractor == IsContractor && c.LabSheetHasValueOver500 == true))
                {
                    mail.To.Add(samplingPlanEmailModel.Email.ToLower());
                }

                if (mail.To.Count == 0)
                {
                    continue;
                }

                mail.From = new MailAddress("ec.pccsm-cssp.ec@canada.ca");
                mail.IsBodyHtml = true;

                SmtpClient myClient = new System.Net.Mail.SmtpClient();

                myClient.Host = "smtp.email-courriel.canada.ca";
                myClient.Port = 587;
                myClient.Credentials = new System.Net.NetworkCredential("ec.pccsm-cssp.ec@canada.ca", "H^9h6g@Gy$N57k=Dr@J7=F2y6p6b!T");
                myClient.EnableSsl = true;

                mail.Priority = MailPriority.High;

                int FirstSpace = tvItemModelSubsector.TVText.IndexOf(" ");

                string subject = tvItemModelSubsector.TVText.Substring(0, (FirstSpace > 0 ? FirstSpace : tvItemModelSubsector.TVText.Length))
                    + " – Lab sheet received – High MPN / Feuille de laboratoire reçu -  NPP élevé";

                DateTime RunDate = new DateTime(int.Parse(labSheetModelAndA1Sheet.LabSheetA1Sheet.RunYear), int.Parse(labSheetModelAndA1Sheet.LabSheetA1Sheet.RunMonth), int.Parse(labSheetModelAndA1Sheet.LabSheetA1Sheet.RunDay));

                StringBuilder msg = new StringBuilder();

                // ---------------------- English part --------------

                msg.AppendLine(@"<p>(français suit)</p>");
                msg.AppendLine(@"<h2>Lab Sheet received</h2>");
                msg.AppendLine(@"<h4>Subsector: " + tvItemModelSubsector.TVText + "</h4>");

                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-CA");

                msg.AppendLine(@"<h4>Run Date: " + RunDate.ToString("MMMM dd, yyyy") + "</h4>");

                if (!IsContractor)
                {
                    msg.AppendLine(@"<a href=""" + href + @""">Open CSSPWebTools</a>");
                }
                msg.AppendLine(@"<br /><br />");
                msg.AppendLine(@"<p><b>Note: </b> Sites below are over the MPN threshold of 500</p>");

                List<LabSheetA1Measurement> labSheetA1MeasurementList = (from c in labSheetModelAndA1Sheet.LabSheetA1Sheet.LabSheetA1MeasurementList
                                                                         where c.MPN != null
                                                                         && c.MPN >= MPNLimitForEmail
                                                                         select c).ToList();

                msg.AppendLine("<ol>");
                foreach (LabSheetA1Measurement labSheetA1Measurment in labSheetA1MeasurementList)
                {
                    msg.AppendLine("<li>");
                    msg.AppendLine("<b>Site: </b>" + labSheetA1Measurment.Site + (labSheetA1Measurment.SampleType == SampleTypeEnum.DailyDuplicate ? " Daily duplicate" : "") + " <b>MPN: </b>" + labSheetA1Measurment.MPN);
                    msg.AppendLine("</li>");

                }
                msg.AppendLine("</ol>");

                msg.AppendLine(@"<br>");
                msg.AppendLine(@"<p>Auto email from CSSPWebTools</p>");
                msg.AppendLine(@"<br>");
                msg.AppendLine(@"<hr />");

                // ---------------------- French part --------------

                msg.AppendLine(@"<hr />");
                msg.AppendLine(@"<br>");
                msg.AppendLine(@"<h2>Feuille de laboratoire reçu</h2>");
                msg.AppendLine(@"<h4>Sous-secteur: " + tvItemModelSubsector.TVText + "</h4>");

                Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-CA");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("fr-CA");

                msg.AppendLine(@"<h4>Date de la tournée: " + RunDate.ToString("dd MMMM, yyyy") + "</h4>");

                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-CA");

                if (!IsContractor)
                {
                    msg.AppendLine(@"<a href=""" + href.Replace("en-CA", "fr-CA") + @""">Open CSSPWebTools</a>");
                }
                msg.AppendLine(@"<br /><br />");
                msg.AppendLine(@"<p><b>Remarque: </b> Les sites ci-dessous ont une valeure de NPP dépassant 500</p>");

                msg.AppendLine("<ol>");
                foreach (LabSheetA1Measurement labSheetA1Measurment in labSheetA1MeasurementList)
                {
                    msg.AppendLine("<li>");
                    msg.AppendLine("<b>Site: </b>" + labSheetA1Measurment.Site + (labSheetA1Measurment.SampleType == SampleTypeEnum.DailyDuplicate ? " Duplicata journalier" : "") + " <b>NPP: </b>" + labSheetA1Measurment.MPN);
                    msg.AppendLine("</li>");

                }
                msg.AppendLine("</ol>");

                msg.AppendLine(@"<br>");
                msg.AppendLine(@"<p>Courriel automatique provenant de CSSPWebTools</p>");

                mail.Subject = subject;
                mail.Body = msg.ToString();
                myClient.Send(mail);
            }
        }
        public void SendNewLabSheetEmail(string href, TVItemModel tvItemModelProvince, TVItemModel tvItemModelSubsector, LabSheetModelAndA1Sheet labSheetModelAndA1Sheet)
        {
            SamplingPlanService samplingPlanService = new SamplingPlanService(LanguageEnum.en, _User);

            SamplingPlanModel samplingPlanModel = samplingPlanService.GetSamplingPlanModelWithSamplingPlanIDDB(labSheetModelAndA1Sheet.LabSheetModel.SamplingPlanID);

            SamplingPlanEmailService samplingPlanEmailService = new SamplingPlanEmailService(LanguageEnum.en, _User);

            List<SamplingPlanEmailModel> SamplingPlanEmailModelList = samplingPlanEmailService.GetSamplingPlanEmailModelListWithSamplingPlanIDDB(samplingPlanModel.SamplingPlanID);

            if (!samplingPlanModel.IsActive)
            {
                return;
            }

            // sending email to Non Contractors

            foreach (bool IsContractor in new List<bool> { false, true })
            {
                MailMessage mail = new MailMessage();

                foreach (SamplingPlanEmailModel samplingPlanEmailModel in SamplingPlanEmailModelList.Where(c => c.IsContractor == IsContractor && c.LabSheetReceived == true))
                {
                    mail.To.Add(samplingPlanEmailModel.Email.ToLower());
                }

                if (mail.To.Count == 0)
                {
                    continue;
                }

                mail.From = new MailAddress("ec.pccsm-cssp.ec@canada.ca");
                mail.IsBodyHtml = true;

                SmtpClient myClient = new System.Net.Mail.SmtpClient();

                myClient.Host = "smtp.email-courriel.canada.ca";
                myClient.Port = 587;
                myClient.Credentials = new System.Net.NetworkCredential("ec.pccsm-cssp.ec@canada.ca", "H^9h6g@Gy$N57k=Dr@J7=F2y6p6b!T");
                myClient.EnableSsl = true;

                int FirstSpace = tvItemModelSubsector.TVText.IndexOf(" ");

                string subject = tvItemModelSubsector.TVText.Substring(0, (FirstSpace > 0 ? FirstSpace : tvItemModelSubsector.TVText.Length))
                    + " – Lab sheet received / Feuille de laboratoire reçu";

                DateTime RunDate = new DateTime(int.Parse(labSheetModelAndA1Sheet.LabSheetA1Sheet.RunYear), int.Parse(labSheetModelAndA1Sheet.LabSheetA1Sheet.RunMonth), int.Parse(labSheetModelAndA1Sheet.LabSheetA1Sheet.RunDay));

                StringBuilder msg = new StringBuilder();

                // ---------------------- English part --------------

                msg.AppendLine(@"<p>(français suit)</p>");
                msg.AppendLine(@"<h2>Lab Sheet received</h2>");
                msg.AppendLine(@"<h4>Subsector: " + tvItemModelSubsector.TVText + "</h4>");
                msg.AppendLine(@"<h4>Run Date: " + RunDate.ToString("MMMM dd, yyyy") + "</h4>");
                if (!IsContractor)
                {
                    msg.AppendLine(@"<a href=""" + href + @""">Open CSSPWebTools</a>");
                }

                msg.AppendLine(@"<br>");
                msg.AppendLine(@"<p>Auto email from CSSPWebTools</p>");
                msg.AppendLine(@"<br>");
                msg.AppendLine(@"<hr />");

                // ---------------------- French part --------------

                msg.AppendLine(@"<hr />");
                msg.AppendLine(@"<br>");
                msg.AppendLine(@"<h2>Feuille de laboratoire reçu</h2>");
                msg.AppendLine(@"<h4>Sous-secteur: " + tvItemModelSubsector.TVText + "</h4>");

                Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-CA");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("fr-CA");

                msg.AppendLine(@"<h4>Date de la tournée: " + RunDate.ToString("dd MMMM, yyyy") + "</h4>");

                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-CA");

                if (!IsContractor)
                {
                    msg.AppendLine(@"<a href=""" + href.Replace("en-CA", "fr-CA") + @""">Open CSSPWebTools</a>");
                }

                msg.AppendLine(@"<br>");
                msg.AppendLine(@"<p>Courriel automatique provenant de CSSPWebTools</p>");

                mail.Subject = subject;
                mail.Body = msg.ToString();
                myClient.Send(mail);
            }
        }
        public void StartTimer()
        {
            timerCheckTask.Enabled = true;
        }
        public void StopTimer()
        {
            timerCheckTask.Enabled = false;
        }
        public void WriteToRichTextBoxStatus(string str)
        {
            try
            {
                richTextBoxStatus.AppendText(str);
            }
            catch (Exception)
            {
                // nothing
            }
        }

        public class RunDateColNumber
        {
            public RunDateColNumber()
            {

            }
            public int MWQMRunTVItemID { get; set; }
            public DateTime RunDate { get; set; }
            public int ColNumber { get; set; }
            public bool Used { get; set; }
        }
        public class StatRunSite
        {
            public StatRunSite()
            {

            }

            public int? SampleCount { get; set; }
            public int? PeriodStart { get; set; }
            public int? PeriodEnd { get; set; }
            public int? MinFC { get; set; }
            public int? MaxFC { get; set; }
            public double? GM { get; set; }
            public double? Med { get; set; }
            public double? P90 { get; set; }
            public double? P43 { get; set; }
            public double? P260 { get; set; }
            public string Letter { get; set; }
            public int Color { get; set; }

        }
        public class SiteRowNumber
        {
            public SiteRowNumber()
            {

            }
            public int MWQMSiteTVItemID { get; set; }
            public string SiteName { get; set; }
            public int RowNumber { get; set; }
        }
        public class RowAndType
        {
            public RowAndType()
            {

            }
            public int RowNumber { get; set; }
            public ExcelExportShowDataTypeEnum ExcelExportShowDataType { get; set; }
        }
        private string GetTideInitial(TideTextEnum? tideText)
        {
            if (tideText == null)
            {
                return "--";
            }

            switch (tideText)
            {
                case TideTextEnum.LowTide:
                    return "LT";
                case TideTextEnum.LowTideFalling:
                    return "LF";
                case TideTextEnum.LowTideRising:
                    return "LR";
                case TideTextEnum.MidTide:
                    return "MT";
                case TideTextEnum.MidTideFalling:
                    return "MF";
                case TideTextEnum.MidTideRising:
                    return "MR";
                case TideTextEnum.HighTide:
                    return "HT";
                case TideTextEnum.HighTideFalling:
                    return "HF";
                case TideTextEnum.HighTideRising:
                    return "HR";
                default:
                    return "--";
            }
        }


        private int GetLastClassificationColor(MWQMSiteLatestClassificationEnum? mwqmSiteLatestClassification)
        {
            if (mwqmSiteLatestClassification == null)
            {
                return 16777215;
            }

            switch (mwqmSiteLatestClassification)
            {
                case MWQMSiteLatestClassificationEnum.Approved:
                    return 5287936;
                case MWQMSiteLatestClassificationEnum.ConditionallyApproved:
                    return 5287936;
                case MWQMSiteLatestClassificationEnum.ConditionallyRestricted:
                    return 0;
                case MWQMSiteLatestClassificationEnum.Prohibited:
                    return 0;
                case MWQMSiteLatestClassificationEnum.Restricted:
                    return 255;
                case MWQMSiteLatestClassificationEnum.Unclassified:
                    return 16777215;
                default:
                    return 16777215;
            }
        }

        private string GetLastClassificationInitial(MWQMSiteLatestClassificationEnum? mwqmSiteLatestClassification)
        {
            if (mwqmSiteLatestClassification == null)
            {
                return "";
            }

            switch (mwqmSiteLatestClassification)
            {
                case MWQMSiteLatestClassificationEnum.Approved:
                    return (Language == LanguageEnum.fr ? "A" : "A");
                case MWQMSiteLatestClassificationEnum.ConditionallyApproved:
                    return (Language == LanguageEnum.fr ? "CA" : "AC");
                case MWQMSiteLatestClassificationEnum.ConditionallyRestricted:
                    return (Language == LanguageEnum.fr ? "CR" : "RC");
                case MWQMSiteLatestClassificationEnum.Prohibited:
                    return (Language == LanguageEnum.fr ? "P" : "P");
                case MWQMSiteLatestClassificationEnum.Restricted:
                    return (Language == LanguageEnum.fr ? "R" : "R");
                case MWQMSiteLatestClassificationEnum.Unclassified:
                    return (Language == LanguageEnum.fr ? "" : "");
                default:
                    return "";
            }
        }

        private void SetupParametersAndBasicTextOnSheet1(Microsoft.Office.Interop.Excel.Application xlApp, Microsoft.Office.Interop.Excel.Workbook wb, MWQMAnalysisReportParameterModel mwqmAnalysisReportParameterModel)
        {
            _TaskRunnerBaseService.SendPercentToDB(_TaskRunnerBaseService._BWObj.appTaskModel.AppTaskID, 7);

            CSSPEnumsDLL.Services.BaseEnumService _BaseEnumService = new CSSPEnumsDLL.Services.BaseEnumService(LanguageEnum.en);
            Microsoft.Office.Interop.Excel.Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets[1];
            Microsoft.Office.Interop.Excel.Range range = ws.get_Range("A1:A1");
            if (ws == null)
            {
                Console.WriteLine("Worksheet could not be created. Check that your office installation and project references are correct.");
            }
            ws.Activate();
            ws.Name = "Stat and Data";
            range = xlApp.get_Range("A1:A1");
            range.Value = "Parameters";

            range = xlApp.get_Range("A1:J1");
            range.Select();
            range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
            range.VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
            range.Merge();
            xlApp.Selection.Borders().LineStyle = Microsoft.Office.Interop.Excel.Constants.xlNone;
            xlApp.Selection.Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            xlApp.Selection.Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium;

            List<string> textList = new List<string>() { "", "Run Date\n\nRain Day", "Run Day (0)", "0-24h (-1)", "24-48h (-2)", "48-72h (-3)",
                "72-96h (-4)", "(-5)", "(-6)", "(-7)", "(-8)", "(-9)", "(-10)", "Start Tide", "End Tide" };

            for (int i = 1; i < 15; i++)
            {
                range = xlApp.get_Range("K" + i + ":L" + i);
                range.Select();
                range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                range.VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                range.Merge();

                xlApp.Selection.Borders().LineStyle = Microsoft.Office.Interop.Excel.Constants.xlNone;
                xlApp.Selection.Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                xlApp.Selection.Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;
                range.Value = textList[i];
            }

            ws.Columns["A:A"].ColumnWidth = 4.89;
            ws.Columns["B:B"].ColumnWidth = 2.11;
            ws.Columns["C:C"].ColumnWidth = 6.33;
            ws.Columns["D:D"].ColumnWidth = 7.33;
            ws.Columns["E:E"].ColumnWidth = 5.22;
            ws.Columns["F:F"].ColumnWidth = 5.44;
            ws.Columns["G:G"].ColumnWidth = 5.22;
            ws.Columns["H:H"].ColumnWidth = 4.78;
            ws.Columns["I:I"].ColumnWidth = 3.89;
            ws.Columns["J:J"].ColumnWidth = 5.33;
            ws.Columns["K:K"].ColumnWidth = 5.67;
            ws.Columns["L:L"].ColumnWidth = 1.22;
            ws.Rows["1:1"].RowHeight = 43;

            textList = new List<string>() { "", "", "Between", "And", "Select Full Year", "Runs", "Sal", "Short Range", "Mid Range", "Calculation" };
            for (int i = 2; i < 10; i++)
            {
                range = xlApp.get_Range("D" + i + ":E" + i);
                range.Select();
                range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                range.VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                range.Merge();
                range.Value = textList[i];
            }

            textList = new List<string>() { "", "", "'" + mwqmAnalysisReportParameterModel.StartDate.ToString("yyyy MMM dd"),
                "'" + mwqmAnalysisReportParameterModel.EndDate.ToString("yyyy MMM dd"),
                "'" + mwqmAnalysisReportParameterModel.FullYear.ToString(),
                "'" + mwqmAnalysisReportParameterModel.NumberOfRuns.ToString(),
                "'" + mwqmAnalysisReportParameterModel.SalinityHighlightDeviationFromAverage.ToString(),
                "'" + mwqmAnalysisReportParameterModel.ShortRangeNumberOfDays.ToString(),
                "'" + mwqmAnalysisReportParameterModel.MidRangeNumberOfDays.ToString(),
                "'" + _BaseEnumService.GetEnumText_AnalysisCalculationTypeEnum(mwqmAnalysisReportParameterModel.AnalysisCalculationType) };
            for (int i = 2; i < 10; i++)
            {
                range = xlApp.get_Range("F" + i + ":G" + i);
                range.Select();
                range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                range.VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                range.Merge();
                range.Value = textList[i];
            }

            range = xlApp.get_Range("D2:G9");
            range.Select();
            xlApp.Selection.Borders().LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            xlApp.Selection.Borders().Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;

            for (int i = 12; i < 14; i++)
            {
                range = xlApp.get_Range("C" + i + ":C" + i);
                range.Select();
                range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                range.VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                range.Merge();
                range.Value = (i == 12 ? "Dry" : "Wet");
            }

            for (int i = 11; i < 14; i++)
            {
                range = xlApp.get_Range("D" + i + ":D" + i);
                range.Select();
                range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                range.VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                range.Merge();
                range.Value = (i == 11 ? "0-24h" : (i == 12 ? mwqmAnalysisReportParameterModel.DryLimit24h.ToString() : mwqmAnalysisReportParameterModel.WetLimit24h.ToString()));
            }

            for (int i = 11; i < 14; i++)
            {
                range = xlApp.get_Range("E" + i + ":E" + i);
                range.Select();
                range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                range.VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                range.Merge();
                range.Value = (i == 11 ? "0-48h" : (i == 12 ? mwqmAnalysisReportParameterModel.DryLimit48h.ToString() : mwqmAnalysisReportParameterModel.WetLimit48h.ToString()));
            }

            for (int i = 11; i < 14; i++)
            {
                range = xlApp.get_Range("F" + i + ":F" + i);
                range.Select();
                range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                range.VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                range.Merge();
                range.Value = (i == 11 ? "0-72h" : (i == 12 ? mwqmAnalysisReportParameterModel.DryLimit72h.ToString() : mwqmAnalysisReportParameterModel.WetLimit72h.ToString()));
            }

            for (int i = 11; i < 14; i++)
            {
                range = xlApp.get_Range("G" + i + ":G" + i);
                range.Select();
                range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                range.VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                range.Merge();
                range.Value = (i == 11 ? "0-96h" : (i == 12 ? mwqmAnalysisReportParameterModel.DryLimit96h.ToString() : mwqmAnalysisReportParameterModel.WetLimit96h.ToString()));
            }

            range = xlApp.get_Range("D11:G11");
            range.Select();
            xlApp.Selection.Borders().LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            xlApp.Selection.Borders().Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;
            xlApp.Selection.Font.Bold = true;

            range = xlApp.get_Range("C12:G13");
            range.Select();
            xlApp.Selection.Borders().LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            xlApp.Selection.Borders().Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;

            range = xlApp.get_Range("C12:C13");
            range.Select();
            xlApp.Selection.Font.Bold = true;

            textList = new List<string>() { "Site", "Samples", "Period", "Min FC", "Max FC", "GMean", "Median", "P90", "% > 43", "% > 260" };
            List<string> LetterList = new List<string>() { "A", "C", "D", "E", "F", "G", "H", "I", "J", "K" };
            for (int i = 0; i < 10; i++)
            {
                range = xlApp.get_Range(LetterList[i] + "15:" + LetterList[i] + "15");
                range.Select();
                range.Value = textList[i];
            }

            range = xlApp.get_Range("A15:K15");
            range.Select();
            xlApp.Selection.Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            xlApp.Selection.Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;

            range = xlApp.get_Range("M15:M15");
            range.Select();
            List<string> showDataTypeTextList = mwqmAnalysisReportParameterModel.ShowDataTypes.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
            string M15Text = "      ";
            foreach (string s in showDataTypeTextList)
            {
                M15Text = M15Text + _BaseEnumService.GetEnumText_ExcelExportShowDataTypeEnum(((ExcelExportShowDataTypeEnum)int.Parse(s))) + ", ";
            }
            range.Value = M15Text;
            xlApp.Selection.WrapText = false;
            range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlLeft;

            ws.Cells.Select();
            xlApp.Selection.Font.Size = 10;

            range = xlApp.get_Range("A1:A1");
            range.Select();

            _TaskRunnerBaseService.SendPercentToDB(_TaskRunnerBaseService._BWObj.appTaskModel.AppTaskID, 10);

        }
        private void SetupParametersAndBasicTextOnSheet2(Microsoft.Office.Interop.Excel.Application xlApp, Microsoft.Office.Interop.Excel.Workbook wb, MWQMAnalysisReportParameterModel mwqmAnalysisReportParameterModel)
        {
            _TaskRunnerBaseService.SendPercentToDB(_TaskRunnerBaseService._BWObj.appTaskModel.AppTaskID, 3);

            CSSPEnumsDLL.Services.BaseEnumService _BaseEnumService = new CSSPEnumsDLL.Services.BaseEnumService(LanguageEnum.en);
            if (wb.Worksheets.Count < 2)
            {
                wb.Worksheets.Add();
            }
            Microsoft.Office.Interop.Excel.Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets[2];
            Microsoft.Office.Interop.Excel.Range range = ws.get_Range("A1:A1");
            if (ws == null)
            {
                Console.WriteLine("Worksheet could not be created. Check that your office installation and project references are correct.");
            }

            ws.Activate();
            ws.Name = "Help";
            range = xlApp.get_Range("A1:G1");
            range.Select();
            range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
            range.VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
            range.Merge();
            xlApp.Selection.Borders().LineStyle = Microsoft.Office.Interop.Excel.Constants.xlNone;
            xlApp.Selection.Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            xlApp.Selection.Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium;
            range.Value = "Color and letter schema";

            List<string> LetterList = new List<string>()
            {
                "F","E","D","C","B","A","F","E","D","C","B","A","F","E","D","C","B","A",
            };
            List<string> RangeList = new List<string>()
            {
               "GM > 181.33 or Med > 181.33 or P90 > 460.0 or % > 260 > 18.33",
               "GM > 162.67 or Med > 162.67 or P90 > 420.0 or % > 260 > 16.67",
               "GM > 144.0 or Med > 144.0 or P90 > 380.0 or % > 260 > 15.0",
               "GM > 125.33 or Med > 125.33 or P90 > 340.0 or % > 260 > 13.33",
               "GM > 106.67 or Med > 106.67 or P90 > 300.0 or % > 260 > 11.67",
               "GM > 88 or Med > 88 or P90 > 260 or % > 260 > 10",
               "GM > 75.67 or Med > 75.67 or P90 > 223.83 or % > 43 > 26.67",
               "GM > 63.33 or Med > 63.33 or P90 > 187.67 or % > 43 > 23.33",
               "GM > 51.0 or Med > 51.0 or P90 > 151.5 or % > 43 > 20.0",
               "GM > 38.67 or Med > 38.67 or P90 > 115.33 or % > 43 > 16.67",
               "GM > 26.33 or Med > 26.33 or P90 > 79.17 or % > 43 > 13.33",
               "GM > 14 or Med > 14 or P90 > 43 or % > 43 > 10",
               "GM > 11.67 or Med > 11.67 or P90 > 35.83 or % > 43 > 8.33",
               "GM > 9.33 or Med > 9.33 or P90 > 28.67 or % > 43 > 6.67",
               "GM > 7.0 or Med > 7.0 or P90 > 21.5 or % > 43 > 5.0",
               "GM > 4.67 or Med > 4.67 or P90 > 14.33 or % > 43 > 3.33",
               "GM > 2.33 or Med > 2.33 or P90 > 7.17 or % > 43 > 1.67",
               "Everything else",
            };

            List<string> BGColorList = new List<string>
            {
                "16746632",
                "16751001",
                "16755370",
                "16759739",
                "16764108",
                "16768477",
                "170",
                "204",
                "1118718",
                "4474111",
                "10066431",
                "13421823",
                "13434828",
                "10092441",
                "4521796",
                "1179409",
                "47872",
                "39168",
            };

            for (int i = 0, count = LetterList.Count; i < count; i++)
            {
                range = xlApp.get_Range("A" + (i + 3).ToString() + ":A" + (i + 3).ToString());
                range.Select();
                range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                range.VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                xlApp.Selection.Borders().LineStyle = Microsoft.Office.Interop.Excel.Constants.xlNone;
                xlApp.Selection.Borders().LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                xlApp.Selection.Borders().Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;
                range.Value = LetterList[i];

                xlApp.Selection.Interior.Color = int.Parse(BGColorList[i]);

                range = xlApp.get_Range("B" + (i + 3).ToString() + ":B" + (i + 3).ToString());
                range.Select();
                range.Value = RangeList[i];
            }

            ws.Columns["A:A"].ColumnWidth = 2.11;

            _TaskRunnerBaseService.SendPercentToDB(_TaskRunnerBaseService._BWObj.appTaskModel.AppTaskID, 5);

        }
        private void SetupStatOnSheet1(Microsoft.Office.Interop.Excel.Application xlApp, Microsoft.Office.Interop.Excel.Workbook wb, MWQMAnalysisReportParameterModel mwqmAnalysisReportParameterModel)
        {
            int LatestYear = 0;
            List<int> RunUsedColNumberList = new List<int>();
            TVItemService tvItemService = new TVItemService(LanguageRequest, _User);
            List<RunDateColNumber> runDateColNumberList = new List<RunDateColNumber>();
            List<RowAndType> rowAndTypeList = new List<RowAndType>();

            List<SiteRowNumber> siteRowNumberList = new List<SiteRowNumber>();
            List<ExcelExportShowDataTypeEnum> showDataTypeList = new List<ExcelExportShowDataTypeEnum>();
            List<int> MWQMRunTVItemIDToOmitList = new List<int>();

            string[] showDataTypeTextList = mwqmAnalysisReportParameterModel.ShowDataTypes.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in showDataTypeTextList)
            {
                showDataTypeList.Add((ExcelExportShowDataTypeEnum)int.Parse(s));
            }

            string[] runDateTextList = mwqmAnalysisReportParameterModel.RunsToOmit.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in runDateTextList)
            {
                MWQMRunTVItemIDToOmitList.Add(int.Parse(s));
            }

            CSSPEnumsDLL.Services.BaseEnumService _BaseEnumService = new CSSPEnumsDLL.Services.BaseEnumService(LanguageEnum.en);
            Microsoft.Office.Interop.Excel.Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets[1];
            Microsoft.Office.Interop.Excel.Range range = ws.get_Range("A1:A1");
            if (ws == null)
            {
                Console.WriteLine("Worksheet could not be created. Check that your office installation and project references are correct.");
            }
            ws.Activate();

            MWQMSubsectorService _MWQMSubsectorService = new MWQMSubsectorService(LanguageEnum.en, _User);
            MWQMSubsectorAnalysisModel mwqmSubsectorAnalysisModel = _MWQMSubsectorService.GetMWQMSubsectorAnalysisModel(mwqmAnalysisReportParameterModel.SubsectorTVItemID);

            foreach (MWQMSampleAnalysisModel mwqmSampleAnalysisModel in mwqmSubsectorAnalysisModel.MWQMSampleAnalysisModelList)
            {
                mwqmSampleAnalysisModel.SampleDateTime_Local = new DateTime(mwqmSampleAnalysisModel.SampleDateTime_Local.Year, mwqmSampleAnalysisModel.SampleDateTime_Local.Month, mwqmSampleAnalysisModel.SampleDateTime_Local.Day);
            }

            foreach (MWQMRunAnalysisModel mwqmRunAnalysisModel in mwqmSubsectorAnalysisModel.MWQMRunAnalysisModelList)
            {
                mwqmRunAnalysisModel.DateTime_Local = new DateTime(mwqmRunAnalysisModel.DateTime_Local.Year, mwqmRunAnalysisModel.DateTime_Local.Month, mwqmRunAnalysisModel.DateTime_Local.Day);
            }

            _TaskRunnerBaseService.SendPercentToDB(_TaskRunnerBaseService._BWObj.appTaskModel.AppTaskID, 20);

            int CountRun = mwqmSubsectorAnalysisModel.MWQMRunAnalysisModelList.Count();
            for (int i = 0, count = mwqmSubsectorAnalysisModel.MWQMRunAnalysisModelList.Count(); i < count; i++)
            {
                if (i % 20 == 0)
                {
                    int Percent = (int)(20.0D + (30.0D * ((double)i / (double)CountRun)));
                    _TaskRunnerBaseService.SendPercentToDB(_TaskRunnerBaseService._BWObj.appTaskModel.AppTaskID, Percent);
                }

                if (i == 0)
                {
                    LatestYear = mwqmSubsectorAnalysisModel.MWQMRunAnalysisModelList[i].DateTime_Local.Year;
                }
                ws.Cells[1, 13 + i] = mwqmSubsectorAnalysisModel.MWQMRunAnalysisModelList[i].DateTime_Local.ToString("yyyy\nMMM\ndd");
                ws.Cells[2, 13 + i] = (mwqmSubsectorAnalysisModel.MWQMRunAnalysisModelList[i].RainDay0_mm == null
                    ? "--" : Convert.ToInt32(mwqmSubsectorAnalysisModel.MWQMRunAnalysisModelList[i].RainDay0_mm).ToString());
                ws.Cells[3, 13 + i] = (mwqmSubsectorAnalysisModel.MWQMRunAnalysisModelList[i].RainDay1_mm == null
                    ? "--" : Convert.ToInt32(mwqmSubsectorAnalysisModel.MWQMRunAnalysisModelList[i].RainDay1_mm).ToString());
                ws.Cells[4, 13 + i] = (mwqmSubsectorAnalysisModel.MWQMRunAnalysisModelList[i].RainDay2_mm == null
                    ? "--" : Convert.ToInt32(mwqmSubsectorAnalysisModel.MWQMRunAnalysisModelList[i].RainDay2_mm).ToString());
                ws.Cells[5, 13 + i] = (mwqmSubsectorAnalysisModel.MWQMRunAnalysisModelList[i].RainDay3_mm == null
                    ? "--" : Convert.ToInt32(mwqmSubsectorAnalysisModel.MWQMRunAnalysisModelList[i].RainDay3_mm).ToString());
                ws.Cells[6, 13 + i] = (mwqmSubsectorAnalysisModel.MWQMRunAnalysisModelList[i].RainDay4_mm == null
                    ? "--" : Convert.ToInt32(mwqmSubsectorAnalysisModel.MWQMRunAnalysisModelList[i].RainDay4_mm).ToString());
                ws.Cells[7, 13 + i] = (mwqmSubsectorAnalysisModel.MWQMRunAnalysisModelList[i].RainDay5_mm == null
                    ? "--" : Convert.ToInt32(mwqmSubsectorAnalysisModel.MWQMRunAnalysisModelList[i].RainDay5_mm).ToString());
                ws.Cells[8, 13 + i] = (mwqmSubsectorAnalysisModel.MWQMRunAnalysisModelList[i].RainDay6_mm == null
                    ? "--" : Convert.ToInt32(mwqmSubsectorAnalysisModel.MWQMRunAnalysisModelList[i].RainDay6_mm).ToString());
                ws.Cells[9, 13 + i] = (mwqmSubsectorAnalysisModel.MWQMRunAnalysisModelList[i].RainDay7_mm == null
                    ? "--" : Convert.ToInt32(mwqmSubsectorAnalysisModel.MWQMRunAnalysisModelList[i].RainDay7_mm).ToString());
                ws.Cells[10, 13 + i] = (mwqmSubsectorAnalysisModel.MWQMRunAnalysisModelList[i].RainDay8_mm == null
                    ? "--" : Convert.ToInt32(mwqmSubsectorAnalysisModel.MWQMRunAnalysisModelList[i].RainDay8_mm).ToString());
                ws.Cells[11, 13 + i] = (mwqmSubsectorAnalysisModel.MWQMRunAnalysisModelList[i].RainDay9_mm == null
                    ? "--" : Convert.ToInt32(mwqmSubsectorAnalysisModel.MWQMRunAnalysisModelList[i].RainDay9_mm).ToString());
                ws.Cells[12, 13 + i] = (mwqmSubsectorAnalysisModel.MWQMRunAnalysisModelList[i].RainDay10_mm == null
                    ? "--" : Convert.ToInt32(mwqmSubsectorAnalysisModel.MWQMRunAnalysisModelList[i].RainDay10_mm).ToString());
                ws.Cells[13, 13 + i] = (mwqmSubsectorAnalysisModel.MWQMRunAnalysisModelList[i].Tide_Start == null
                    ? "--" : GetTideInitial(mwqmSubsectorAnalysisModel.MWQMRunAnalysisModelList[i].Tide_Start));
                ws.Cells[14, 13 + i] = (mwqmSubsectorAnalysisModel.MWQMRunAnalysisModelList[i].Tide_End == null
                    ? "--" : GetTideInitial(mwqmSubsectorAnalysisModel.MWQMRunAnalysisModelList[i].Tide_End));

                ws.Columns[13 + i].ColumnWidth = 4.33;
                range = ws.Columns[13 + i];
                range.Select();
                xlApp.Selection.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;

                runDateColNumberList.Add(new RunDateColNumber()
                {
                    MWQMRunTVItemID = mwqmSubsectorAnalysisModel.MWQMRunAnalysisModelList[i].MWQMRunTVItemID,
                    RunDate = mwqmSubsectorAnalysisModel.MWQMRunAnalysisModelList[i].DateTime_Local,
                    ColNumber = 13 + i,
                    Used = false,
                });

                if (LatestYear != mwqmSubsectorAnalysisModel.MWQMRunAnalysisModelList[i].DateTime_Local.Year)
                {
                    ws.Columns[13 + i].Select();
                    xlApp.Selection.Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).ColorIndex = 0;
                    xlApp.Selection.Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                    LatestYear = mwqmSubsectorAnalysisModel.MWQMRunAnalysisModelList[i].DateTime_Local.Year;
                }
            }

            ws.Columns["A:L"].Select();
            xlApp.Selection.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;

            ws.Range["M15"].Select();
            xlApp.Selection.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlLeft;

            int RowCount = 16;
            List<MWQMSiteAnalysisModel> mwqmSiteAnalysisModelListAll = mwqmSubsectorAnalysisModel.MWQMSiteAnalysisModelList.Where(c => c.IsActive == true).OrderBy(c => c.MWQMSiteTVText)
                                                                        .Concat(mwqmSubsectorAnalysisModel.MWQMSiteAnalysisModelList.Where(c => c.IsActive == false).OrderBy(c => c.MWQMSiteTVText)).ToList();

            int CountSite = 0;
            int CountSiteTotal = mwqmSiteAnalysisModelListAll.Count();
            foreach (MWQMSiteAnalysisModel mwqmSiteAnalysisModel in mwqmSiteAnalysisModelListAll)
            {
                CountSite += 1;
                if (CountSite % 10 == 0)
                {
                    int Percent = (int)(50.0D + (50.0D * ((double)CountSite / (double)CountSiteTotal)));
                    _TaskRunnerBaseService.SendPercentToDB(_TaskRunnerBaseService._BWObj.appTaskModel.AppTaskID, Percent);
                }

                double? P90 = null;
                double? GeoMean = null;
                double? Median = null;
                double? PercOver43 = null;
                double? PercOver260 = null;

                SiteRowNumber siteRowNumber = new SiteRowNumber() { MWQMSiteTVItemID = mwqmSiteAnalysisModel.MWQMSiteTVItemID, SiteName = mwqmSiteAnalysisModel.MWQMSiteTVText, RowNumber = RowCount };
                siteRowNumberList.Add(siteRowNumber);

                range = ws.Cells[RowCount, 1];
                string classification = GetLastClassificationInitial(mwqmSiteAnalysisModel.MWQMSiteLatestClassification);
                range.Value = "'" + mwqmSiteAnalysisModel.MWQMSiteTVText;
                range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                range.Select();
                if (mwqmSiteAnalysisModel.IsActive == true)
                {
                    xlApp.Selection.Font.Color = 5287936; // green
                }
                else
                {
                    xlApp.Selection.Font.Color = 255; // red
                }

                range = ws.Cells[RowCount, 2];
                range.Value = "'" + (string.IsNullOrWhiteSpace(classification) ? "" : classification);
                range.Select();
                xlApp.Selection.Interior.Color = GetLastClassificationColor(mwqmSiteAnalysisModel.MWQMSiteLatestClassification);
                xlApp.Selection.Font.Color = (classification == "P" ? 16777215 : 0);

                // loading all site sample and doing the stats
                List<MWQMSampleAnalysisModel> mwqmSampleAnalysisForSiteModelList = mwqmSubsectorAnalysisModel.MWQMSampleAnalysisModelList.Where(c => c.MWQMSiteTVItemID == siteRowNumber.MWQMSiteTVItemID).OrderByDescending(c => c.SampleDateTime_Local).ToList();
                List<MWQMSampleAnalysisModel> mwqmSampleAnalysisForSiteModelToUseList = new List<MWQMSampleAnalysisModel>();
                foreach (MWQMSampleAnalysisModel mwqmSampleAnalysisModel in mwqmSampleAnalysisForSiteModelList)
                {
                    if (!MWQMRunTVItemIDToOmitList.Contains(mwqmSampleAnalysisModel.MWQMRunTVItemID))
                    {
                        if ((mwqmSampleAnalysisModel.SampleDateTime_Local <= mwqmAnalysisReportParameterModel.StartDate) && (mwqmSampleAnalysisModel.SampleDateTime_Local >= mwqmAnalysisReportParameterModel.EndDate))
                        {
                            if (mwqmSampleAnalysisForSiteModelToUseList.Count < mwqmAnalysisReportParameterModel.NumberOfRuns)
                            {
                                if (mwqmAnalysisReportParameterModel.AnalysisCalculationType == AnalysisCalculationTypeEnum.WetAllAll)
                                {
                                    MWQMRunAnalysisModel mwqmRunAnalysisModel = (from c in mwqmSubsectorAnalysisModel.MWQMRunAnalysisModelList
                                                                                 where c.DateTime_Local.Year == mwqmSampleAnalysisModel.SampleDateTime_Local.Year
                                                                                 && c.DateTime_Local.Month == mwqmSampleAnalysisModel.SampleDateTime_Local.Month
                                                                                 && c.DateTime_Local.Day == mwqmSampleAnalysisModel.SampleDateTime_Local.Day
                                                                                 select c).FirstOrDefault();

                                    List<int> RainData = new List<int>()
                                        {
                                           Convert.ToInt32(mwqmRunAnalysisModel.RainDay0_mm),
                                           Convert.ToInt32(mwqmRunAnalysisModel.RainDay1_mm),
                                           Convert.ToInt32(mwqmRunAnalysisModel.RainDay2_mm),
                                           Convert.ToInt32(mwqmRunAnalysisModel.RainDay3_mm),
                                           Convert.ToInt32(mwqmRunAnalysisModel.RainDay4_mm),
                                           Convert.ToInt32(mwqmRunAnalysisModel.RainDay5_mm),
                                           Convert.ToInt32(mwqmRunAnalysisModel.RainDay6_mm),
                                           Convert.ToInt32(mwqmRunAnalysisModel.RainDay7_mm),
                                           Convert.ToInt32(mwqmRunAnalysisModel.RainDay8_mm),
                                           Convert.ToInt32(mwqmRunAnalysisModel.RainDay9_mm),
                                           Convert.ToInt32(mwqmRunAnalysisModel.RainDay10_mm),
                                        };

                                    int ShortRange = Math.Abs(mwqmAnalysisReportParameterModel.ShortRangeNumberOfDays);
                                    int MidRange = Math.Abs(mwqmAnalysisReportParameterModel.MidRangeNumberOfDays);
                                    int TotalRain = 0;
                                    bool AlreadyUsed = false;
                                    for (int i = 1; i < 11; i++)
                                    {
                                        TotalRain = TotalRain + RainData[i];
                                        if (i <= ShortRange)
                                        {
                                            if (i == 1)
                                            {
                                                if (mwqmAnalysisReportParameterModel.WetLimit24h <= TotalRain)
                                                {
                                                    int Col = 0;
                                                    for (int j = 0, count = mwqmSubsectorAnalysisModel.MWQMRunAnalysisModelList.Count(); j < count; j++)
                                                    {
                                                        if (mwqmSubsectorAnalysisModel.MWQMRunAnalysisModelList[j].MWQMRunID == mwqmRunAnalysisModel.MWQMRunID)
                                                        {
                                                            Col = j + 13;
                                                            break;
                                                        }
                                                    }
                                                    ws.Cells[3, Col].Select();
                                                    xlApp.Selection.Interior.Color = 16772300;

                                                    if (!AlreadyUsed)
                                                    {
                                                        mwqmSampleAnalysisForSiteModelToUseList.Add(mwqmSampleAnalysisModel);
                                                        AlreadyUsed = true;
                                                    }
                                                }
                                            }
                                            else if (i == 2)
                                            {
                                                if (mwqmAnalysisReportParameterModel.WetLimit48h <= TotalRain)
                                                {
                                                    int Col = 0;
                                                    for (int j = 0, count = mwqmSubsectorAnalysisModel.MWQMRunAnalysisModelList.Count(); j < count; j++)
                                                    {
                                                        if (mwqmSubsectorAnalysisModel.MWQMRunAnalysisModelList[j].MWQMRunID == mwqmRunAnalysisModel.MWQMRunID)
                                                        {
                                                            Col = j + 13;
                                                            break;
                                                        }
                                                    }
                                                    ws.Cells[4, Col].Select();
                                                    xlApp.Selection.Interior.Color = 16772300;

                                                    if (!AlreadyUsed)
                                                    {
                                                        mwqmSampleAnalysisForSiteModelToUseList.Add(mwqmSampleAnalysisModel);
                                                        AlreadyUsed = true;
                                                    }
                                                }
                                            }
                                            else if (i == 3)
                                            {
                                                if (mwqmAnalysisReportParameterModel.WetLimit72h <= TotalRain)
                                                {
                                                    int Col = 0;
                                                    for (int j = 0, count = mwqmSubsectorAnalysisModel.MWQMRunAnalysisModelList.Count(); j < count; j++)
                                                    {
                                                        if (mwqmSubsectorAnalysisModel.MWQMRunAnalysisModelList[j].MWQMRunID == mwqmRunAnalysisModel.MWQMRunID)
                                                        {
                                                            Col = j + 13;
                                                            break;
                                                        }
                                                    }
                                                    ws.Cells[5, Col].Select();
                                                    xlApp.Selection.Interior.Color = 16772300;

                                                    if (!AlreadyUsed)
                                                    {
                                                        mwqmSampleAnalysisForSiteModelToUseList.Add(mwqmSampleAnalysisModel);
                                                        AlreadyUsed = true;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                if (mwqmAnalysisReportParameterModel.WetLimit96h <= TotalRain)
                                                {
                                                    int Col = 0;
                                                    for (int j = 0, count = mwqmSubsectorAnalysisModel.MWQMRunAnalysisModelList.Count(); j < count; j++)
                                                    {
                                                        if (mwqmSubsectorAnalysisModel.MWQMRunAnalysisModelList[j].MWQMRunID == mwqmRunAnalysisModel.MWQMRunID)
                                                        {
                                                            Col = j + 13;
                                                            break;
                                                        }
                                                    }
                                                    ws.Cells[6, Col].Select();
                                                    xlApp.Selection.Interior.Color = 16772300;

                                                    if (!AlreadyUsed)
                                                    {
                                                        mwqmSampleAnalysisForSiteModelToUseList.Add(mwqmSampleAnalysisModel);
                                                        AlreadyUsed = true;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                else if (mwqmAnalysisReportParameterModel.AnalysisCalculationType == AnalysisCalculationTypeEnum.DryAllAll)
                                {
                                    MWQMRunAnalysisModel mwqmRunAnalysisModel = (from c in mwqmSubsectorAnalysisModel.MWQMRunAnalysisModelList
                                                                                 where c.DateTime_Local.Year == mwqmSampleAnalysisModel.SampleDateTime_Local.Year
                                                                                 && c.DateTime_Local.Month == mwqmSampleAnalysisModel.SampleDateTime_Local.Month
                                                                                 && c.DateTime_Local.Day == mwqmSampleAnalysisModel.SampleDateTime_Local.Day
                                                                                 select c).FirstOrDefault();

                                    List<int> RainData = new List<int>()
                                        {
                                           Convert.ToInt32(mwqmRunAnalysisModel.RainDay0_mm),
                                           Convert.ToInt32(mwqmRunAnalysisModel.RainDay1_mm),
                                           Convert.ToInt32(mwqmRunAnalysisModel.RainDay2_mm),
                                           Convert.ToInt32(mwqmRunAnalysisModel.RainDay3_mm),
                                           Convert.ToInt32(mwqmRunAnalysisModel.RainDay4_mm),
                                           Convert.ToInt32(mwqmRunAnalysisModel.RainDay5_mm),
                                           Convert.ToInt32(mwqmRunAnalysisModel.RainDay6_mm),
                                           Convert.ToInt32(mwqmRunAnalysisModel.RainDay7_mm),
                                           Convert.ToInt32(mwqmRunAnalysisModel.RainDay8_mm),
                                           Convert.ToInt32(mwqmRunAnalysisModel.RainDay9_mm),
                                           Convert.ToInt32(mwqmRunAnalysisModel.RainDay10_mm),
                                        };

                                    int ShortRange = Math.Abs(mwqmAnalysisReportParameterModel.ShortRangeNumberOfDays);
                                    int MidRange = Math.Abs(mwqmAnalysisReportParameterModel.MidRangeNumberOfDays);
                                    int TotalRain = 0;
                                    bool CanUsed = true;
                                    for (int i = 1; i < 11; i++)
                                    {
                                        TotalRain = TotalRain + RainData[i];
                                        if (i <= ShortRange)
                                        {
                                            if (i == 1)
                                            {
                                                if (mwqmAnalysisReportParameterModel.DryLimit24h < TotalRain)
                                                {
                                                    int Col = 0;
                                                    for (int j = 0, count = mwqmSubsectorAnalysisModel.MWQMRunAnalysisModelList.Count(); j < count; j++)
                                                    {
                                                        if (mwqmSubsectorAnalysisModel.MWQMRunAnalysisModelList[j].MWQMRunID == mwqmRunAnalysisModel.MWQMRunID)
                                                        {
                                                            Col = j + 13;
                                                            break;
                                                        }
                                                    }
                                                    ws.Cells[3, Col].Select();
                                                    xlApp.Selection.Interior.Color = 10079487;

                                                    CanUsed = false;
                                                }
                                            }
                                            else if (i == 2)
                                            {
                                                if (mwqmAnalysisReportParameterModel.DryLimit48h < TotalRain)
                                                {
                                                    int Col = 0;
                                                    for (int j = 0, count = mwqmSubsectorAnalysisModel.MWQMRunAnalysisModelList.Count(); j < count; j++)
                                                    {
                                                        if (mwqmSubsectorAnalysisModel.MWQMRunAnalysisModelList[j].MWQMRunID == mwqmRunAnalysisModel.MWQMRunID)
                                                        {
                                                            Col = j + 13;
                                                            break;
                                                        }
                                                    }
                                                    ws.Cells[4, Col].Select();
                                                    xlApp.Selection.Interior.Color = 10079487;

                                                    CanUsed = false;
                                                }
                                            }
                                            else if (i == 3)
                                            {
                                                if (mwqmAnalysisReportParameterModel.DryLimit72h < TotalRain)
                                                {
                                                    int Col = 0;
                                                    for (int j = 0, count = mwqmSubsectorAnalysisModel.MWQMRunAnalysisModelList.Count(); j < count; j++)
                                                    {
                                                        if (mwqmSubsectorAnalysisModel.MWQMRunAnalysisModelList[j].MWQMRunID == mwqmRunAnalysisModel.MWQMRunID)
                                                        {
                                                            Col = j + 13;
                                                            break;
                                                        }
                                                    }
                                                    ws.Cells[5, Col].Select();
                                                    xlApp.Selection.Interior.Color = 10079487;

                                                    CanUsed = false;
                                                }
                                            }
                                            else
                                            {
                                                if (mwqmAnalysisReportParameterModel.DryLimit96h < TotalRain)
                                                {
                                                    int Col = 0;
                                                    for (int j = 0, count = mwqmSubsectorAnalysisModel.MWQMRunAnalysisModelList.Count(); j < count; j++)
                                                    {
                                                        if (mwqmSubsectorAnalysisModel.MWQMRunAnalysisModelList[j].MWQMRunID == mwqmRunAnalysisModel.MWQMRunID)
                                                        {
                                                            Col = j + 13;
                                                            break;
                                                        }
                                                    }
                                                    ws.Cells[6, Col].Select();
                                                    xlApp.Selection.Interior.Color = 10079487;

                                                    CanUsed = false;
                                                }
                                            }
                                        }
                                    }
                                    if (CanUsed)
                                    {
                                        mwqmSampleAnalysisForSiteModelToUseList.Add(mwqmSampleAnalysisModel);
                                    }
                                }
                                else
                                {
                                    mwqmSampleAnalysisForSiteModelToUseList.Add(mwqmSampleAnalysisModel);
                                }
                            }
                        }
                    }
                }

                if (mwqmAnalysisReportParameterModel.AnalysisCalculationType == AnalysisCalculationTypeEnum.AllAllAll)
                {
                    if (mwqmSampleAnalysisForSiteModelToUseList.Count > 0 && mwqmAnalysisReportParameterModel.FullYear)
                    {
                        int FirstYear = mwqmSampleAnalysisForSiteModelToUseList[0].SampleDateTime_Local.Year;
                        int LastYear = mwqmSampleAnalysisForSiteModelToUseList[mwqmSampleAnalysisForSiteModelToUseList.Count - 1].SampleDateTime_Local.Year;

                        List<MWQMSampleAnalysisModel> mwqmSampleAnalysisMore = (from c in mwqmSampleAnalysisForSiteModelList
                                                                                where c.SampleDateTime_Local.Year == FirstYear
                                                                                && c.MWQMSiteTVItemID == mwqmSiteAnalysisModel.MWQMSiteTVItemID
                                                                                select c).Concat((from c in mwqmSampleAnalysisForSiteModelList
                                                                                                  where c.SampleDateTime_Local.Year == LastYear
                                                                                                  && c.MWQMSiteTVItemID == mwqmSiteAnalysisModel.MWQMSiteTVItemID
                                                                                                  select c)).ToList();

                        List<MWQMSampleAnalysisModel> mwqmSampleAnalysisMore2 = new List<MWQMSampleAnalysisModel>();
                        foreach (MWQMSampleAnalysisModel mwqmSampleAnalysisModel in mwqmSampleAnalysisMore)
                        {
                            if (!MWQMRunTVItemIDToOmitList.Contains(mwqmSampleAnalysisModel.MWQMRunTVItemID))
                            {
                                mwqmSampleAnalysisMore2.Add(mwqmSampleAnalysisModel);
                            }
                        }

                        mwqmSampleAnalysisForSiteModelToUseList = mwqmSampleAnalysisForSiteModelToUseList.Concat(mwqmSampleAnalysisMore2).Distinct().ToList();

                        mwqmSampleAnalysisForSiteModelToUseList = mwqmSampleAnalysisForSiteModelToUseList.OrderByDescending(c => c.SampleDateTime_Local).ToList();
                    }
                }

                int Coloring = 0;
                string Letter = "";
                if (mwqmSampleAnalysisForSiteModelToUseList.Count < 10)
                {
                    range = ws.Cells[RowCount, 3];
                    range.Value = "--";

                    range = ws.Cells[RowCount, 4];
                    range.Value = "--";

                    range = ws.Cells[RowCount, 5];
                    range.Value = "--";

                    range = ws.Cells[RowCount, 6];
                    range.Value = "--";

                    range = ws.Cells[RowCount, 7];
                    range.Value = "--";

                    range = ws.Cells[RowCount, 8];
                    range.Value = "--";

                    range = ws.Cells[RowCount, 9];
                    range.Value = "--";

                    range = ws.Cells[RowCount, 10];
                    range.Value = "--";

                    range = ws.Cells[RowCount, 11];
                    range.Value = "--";

                    Letter = mwqmSampleAnalysisForSiteModelToUseList.Count.ToString();
                    Coloring = 16764057;

                    if (mwqmSiteAnalysisModel.IsActive)
                    {
                        range = ws.Cells[RowCount, 12];
                        range.Value = "'" + Letter;
                        range.Select();
                        xlApp.Selection.Interior.Color = Coloring;
                    }
                }
                if (mwqmSampleAnalysisForSiteModelToUseList.Count >= 4)
                {
                    int MWQMSampleCount = mwqmSampleAnalysisForSiteModelToUseList.Count;
                    int? MaxYear = mwqmSampleAnalysisForSiteModelToUseList[0].SampleDateTime_Local.Year;
                    int? MinYear = mwqmSampleAnalysisForSiteModelToUseList[mwqmSampleAnalysisForSiteModelToUseList.Count - 1].SampleDateTime_Local.Year;
                    int? MinFC = (from c in mwqmSampleAnalysisForSiteModelToUseList select c.FecCol_MPN_100ml).Min();
                    int? MaxFC = (from c in mwqmSampleAnalysisForSiteModelToUseList select c.FecCol_MPN_100ml).Max();

                    List<double> SampleList = (from c in mwqmSampleAnalysisForSiteModelToUseList
                                               select (c.FecCol_MPN_100ml == 1 ? 1.9D : (double)c.FecCol_MPN_100ml)).ToList<double>();

                    P90 = tvItemService.GetP90(SampleList);
                    GeoMean = tvItemService.GeometricMean(SampleList);
                    Median = tvItemService.GetMedian(SampleList);
                    PercOver43 = ((((double)SampleList.Where(c => c > 43).Count()) / (double)SampleList.Count()) * 100.0D);
                    PercOver260 = ((((double)SampleList.Where(c => c > 260).Count()) / (double)SampleList.Count()) * 100.0D);
                    if ((GeoMean > 88) || (Median > 88) || (P90 > 260) || (PercOver260 > 10))
                    {
                        if ((GeoMean > 181.33) || (Median > 181.33) || (P90 > 460.0) || (PercOver260 > 18.33))
                        {
                            Coloring = 16746632;
                            Letter = "F";
                        }
                        else if ((GeoMean > 162.67) || (Median > 162.67) || (P90 > 420.0) || (PercOver260 > 16.67))
                        {
                            Coloring = 16751001;
                            Letter = "E";
                        }
                        else if ((GeoMean > 144.0) || (Median > 144.0) || (P90 > 380.0) || (PercOver260 > 15.0))
                        {
                            Coloring = 16755370;
                            Letter = "D";
                        }
                        else if ((GeoMean > 125.33) || (Median > 125.33) || (P90 > 340.0) || (PercOver260 > 13.33))
                        {
                            Coloring = 16759739;
                            Letter = "C";
                        }
                        else if ((GeoMean > 106.67) || (Median > 106.67) || (P90 > 300.0) || (PercOver260 > 11.67))
                        {
                            Coloring = 16764108;
                            Letter = "B";
                        }
                        else
                        {
                            Coloring = 16768477;
                            Letter = "A";
                        }
                    }
                    else if ((GeoMean > 14) || (Median > 14) || (P90 > 43) || (PercOver43 > 10))
                    {
                        if ((GeoMean > 75.67) || (Median > 75.67) || (P90 > 223.83) || (PercOver43 > 26.67))
                        {
                            Coloring = 170;
                            Letter = "F";
                        }
                        else if ((GeoMean > 63.33) || (Median > 63.33) || (P90 > 187.67) || (PercOver43 > 23.33))
                        {
                            Coloring = 204;
                            Letter = "E";
                        }
                        else if ((GeoMean > 51.0) || (Median > 51.0) || (P90 > 151.5) || (PercOver43 > 20.0))
                        {
                            Coloring = 1118718;
                            Letter = "D";
                        }
                        else if ((GeoMean > 38.67) || (Median > 38.67) || (P90 > 115.33) || (PercOver43 > 16.67))
                        {
                            Coloring = 4474111;
                            Letter = "C";
                        }
                        else if ((GeoMean > 26.33) || (Median > 26.33) || (P90 > 79.17) || (PercOver43 > 13.33))
                        {
                            Coloring = 10066431;
                            Letter = "B";
                        }
                        else
                        {
                            Coloring = 13421823;
                            Letter = "A";
                        }
                    }
                    else
                    {
                        if ((GeoMean > 11.67) || (Median > 11.67) || (P90 > 35.83) || (PercOver43 > 8.33))
                        {
                            Coloring = 13434828;
                            Letter = "F";
                        }
                        else if ((GeoMean > 9.33) || (Median > 9.33) || (P90 > 28.67) || (PercOver43 > 6.67))
                        {
                            Coloring = 10092441;
                            Letter = "E";
                        }
                        else if ((GeoMean > 7.0) || (Median > 7.0) || (P90 > 21.5) || (PercOver43 > 5.0))
                        {
                            Coloring = 4521796;
                            Letter = "D";
                        }
                        else if ((GeoMean > 4.67) || (Median > 4.67) || (P90 > 14.33) || (PercOver43 > 3.33))
                        {
                            Coloring = 1179409;
                            Letter = "C";
                        }
                        else if ((GeoMean > 2.33) || (Median > 2.33) || (P90 > 7.17) || (PercOver43 > 1.67))
                        {
                            Coloring = 47872;
                            Letter = "B";
                        }
                        else
                        {
                            Coloring = 39168;
                            Letter = "A";
                        }
                    }

                    range = ws.Cells[RowCount, 3];
                    range.Value = "'" + (mwqmSiteAnalysisModel.IsActive ? MWQMSampleCount.ToString() : "--");

                    range = ws.Cells[RowCount, 4];
                    range.Value = "'" + (mwqmSiteAnalysisModel.IsActive ? (MaxYear != null ? (MaxYear.ToString() + "-" + MinYear.ToString()) : "--") : "--");

                    range = ws.Cells[RowCount, 5];
                    range.Value = "'" + (mwqmSiteAnalysisModel.IsActive ? (MinFC != null ? (MinFC < 2 ? "< 2" : (MinFC.ToString())) : "--") : "--");

                    range = ws.Cells[RowCount, 6];
                    range.Value = "'" + (mwqmSiteAnalysisModel.IsActive ? (MaxFC != null ? (MaxFC < 2 ? "< 2" : (MaxFC.ToString())) : "--") : "--");

                    range = ws.Cells[RowCount, 7];
                    range.Value = "'" + (mwqmSiteAnalysisModel.IsActive ? (GeoMean != null ? ((double)GeoMean < 2.0D ? "< 2" : ((double)GeoMean).ToString("F0")) : "--") : "--");
                    if (GeoMean > 14)
                    {
                        if (mwqmSiteAnalysisModel.IsActive)
                        {
                            range.Interior.Color = 65535;
                        }
                    }

                    range = ws.Cells[RowCount, 8];
                    range.Value = "'" + (mwqmSiteAnalysisModel.IsActive ? (Median != null ? ((double)Median < 2.0D ? "< 2" : ((double)Median).ToString("F0")) : "--") : "--");
                    if (Median > 14)
                    {
                        if (mwqmSiteAnalysisModel.IsActive)
                        {
                            range.Interior.Color = 65535;
                        }
                    }

                    range = ws.Cells[RowCount, 9];
                    range.Value = "'" + (mwqmSiteAnalysisModel.IsActive ? (P90 != null ? ((double)P90 < 2.0D ? "< 2" : ((double)P90).ToString("F0")) : "--") : "--");
                    if (P90 > 43)
                    {
                        if (mwqmSiteAnalysisModel.IsActive)
                        {
                            range.Interior.Color = 65535;
                        }
                    }

                    range = ws.Cells[RowCount, 10];
                    range.Value = "'" + (mwqmSiteAnalysisModel.IsActive ? (PercOver43 != null ? ((double)PercOver43).ToString("F0") : "--") : "--");
                    if (PercOver43 > 10)
                    {
                        if (mwqmSiteAnalysisModel.IsActive)
                        {
                            range.Interior.Color = 65535;
                        }
                    }

                    range = ws.Cells[RowCount, 11];
                    range.Value = "'" + (mwqmSiteAnalysisModel.IsActive ? (PercOver260 != null ? ((double)PercOver260).ToString("F0") : "--") : "--");
                    if (PercOver260 > 10)
                    {
                        if (mwqmSiteAnalysisModel.IsActive)
                        {
                            range.Interior.Color = 65535;
                        }
                    }

                    if (mwqmSiteAnalysisModel.IsActive)
                    {
                        range = ws.Cells[RowCount, 12];
                        range.Value = "'" + Letter;
                        range.Select();
                        xlApp.Selection.Interior.Color = Coloring;
                    }
                }

                int AddedRows = 0;
                foreach (MWQMSampleAnalysisModel mwqmSampleAnalysisModel in mwqmSampleAnalysisForSiteModelList)
                {
                    AddedRows = 0;
                    int colNumber = (from c in runDateColNumberList
                                     where c.MWQMRunTVItemID == mwqmSampleAnalysisModel.MWQMRunTVItemID
                                     select c.ColNumber).FirstOrDefault();

                    if (mwqmSampleAnalysisForSiteModelToUseList.Count >= 4)
                    {
                        List<double> SampleList = (from c in mwqmSampleAnalysisForSiteModelToUseList
                                                   select (c.FecCol_MPN_100ml == 1 ? 1.9D : (double)c.FecCol_MPN_100ml)).ToList<double>();

                        P90 = tvItemService.GetP90(SampleList);
                        GeoMean = tvItemService.GeometricMean(SampleList);
                        Median = tvItemService.GetMedian(SampleList);
                        PercOver43 = ((((double)SampleList.Where(c => c > 43).Count()) / (double)SampleList.Count()) * 100.0D);
                        PercOver260 = ((((double)SampleList.Where(c => c > 260).Count()) / (double)SampleList.Count()) * 100.0D);

                    }
                    else
                    {
                        P90 = null;
                        GeoMean = null;
                        Median = null;
                        PercOver43 = null;
                        PercOver260 = null;
                    }

                    range = ws.Cells[RowCount, colNumber];

                    range.Value = (mwqmSampleAnalysisModel.FecCol_MPN_100ml < 2 ? "< 2" : mwqmSampleAnalysisModel.FecCol_MPN_100ml.ToString());
                    if (mwqmSampleAnalysisModel.FecCol_MPN_100ml > 500)
                    {
                        range.Interior.Color = 255;
                    }
                    else if (mwqmSampleAnalysisModel.FecCol_MPN_100ml > 43)
                    {
                        range.Interior.Color = 65535;
                    }
                    if (mwqmSiteAnalysisModel.IsActive == true)
                    {
                        if (mwqmSampleAnalysisForSiteModelToUseList.Contains(mwqmSampleAnalysisModel))
                        {
                            range.Select();
                            xlApp.Selection.Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).Color = -11489280;
                            if (!RunUsedColNumberList.Contains(colNumber))
                            {
                                RunUsedColNumberList.Add(colNumber);
                            }
                        }
                        else
                        {
                            if (MWQMRunTVItemIDToOmitList.Contains(mwqmSampleAnalysisModel.MWQMRunTVItemID))
                            {
                                RunUsedColNumberList.Add(colNumber);
                            }
                        }
                    }
                    if (showDataTypeList.Contains(ExcelExportShowDataTypeEnum.Temperature))
                    {
                        RowCount += 1;
                        range = ws.Cells[RowCount, colNumber];
                        range.Value = (mwqmSampleAnalysisModel.WaterTemp_C != null ? ((double)mwqmSampleAnalysisModel.WaterTemp_C).ToString("F0") : "--");
                        if (!(rowAndTypeList.Where(c => c.RowNumber == (RowCount + AddedRows)).Any()))
                        {
                            rowAndTypeList.Add(new RowAndType() { RowNumber = RowCount + AddedRows, ExcelExportShowDataType = ExcelExportShowDataTypeEnum.Temperature });
                        }
                    }
                    if (showDataTypeList.Contains(ExcelExportShowDataTypeEnum.Salinity))
                    {
                        AddedRows += 1;
                        range = ws.Cells[RowCount + AddedRows, colNumber];
                        range.Value = (mwqmSampleAnalysisModel.Salinity_PPT != null ? ((double)mwqmSampleAnalysisModel.Salinity_PPT).ToString("F0") : "--");

                        if (mwqmSampleAnalysisModel.Salinity_PPT != null)
                        {
                            double? avgSal = (from c in mwqmSampleAnalysisForSiteModelList
                                              where c.Salinity_PPT != null
                                              select c.Salinity_PPT).Average();

                            if (Math.Abs(((double)mwqmSampleAnalysisModel.Salinity_PPT) - ((double)avgSal)) >= mwqmAnalysisReportParameterModel.SalinityHighlightDeviationFromAverage)
                            {
                                range.Interior.Color = 65535;
                            }
                        }
                        if (!(rowAndTypeList.Where(c => c.RowNumber == (RowCount + AddedRows)).Any()))
                        {
                            rowAndTypeList.Add(new RowAndType() { RowNumber = RowCount + AddedRows, ExcelExportShowDataType = ExcelExportShowDataTypeEnum.Salinity });
                        }

                    }
                    if (showDataTypeList.Contains(ExcelExportShowDataTypeEnum.P90))
                    {
                        AddedRows += 1;
                        range = ws.Cells[RowCount + AddedRows, colNumber];

                        range.Value = (P90 != null ? ((double)P90).ToString("F0") : "--");
                        if (P90 > 43)
                        {
                            range.Interior.Color = 65535;
                        }
                        if (!(rowAndTypeList.Where(c => c.RowNumber == (RowCount + AddedRows)).Any()))
                        {
                            rowAndTypeList.Add(new RowAndType() { RowNumber = RowCount + AddedRows, ExcelExportShowDataType = ExcelExportShowDataTypeEnum.P90 });
                        }
                    }
                    if (showDataTypeList.Contains(ExcelExportShowDataTypeEnum.GemetricMean))
                    {
                        AddedRows += 1;
                        range = ws.Cells[RowCount + AddedRows, colNumber];

                        range.Value = (GeoMean != null ? ((double)GeoMean).ToString("F0") : "--");
                        if (GeoMean > 14)
                        {
                            range.Interior.Color = 65535;
                        }
                        if (!(rowAndTypeList.Where(c => c.RowNumber == (RowCount + AddedRows)).Any()))
                        {
                            rowAndTypeList.Add(new RowAndType() { RowNumber = RowCount + AddedRows, ExcelExportShowDataType = ExcelExportShowDataTypeEnum.GemetricMean });
                        }
                    }
                    if (showDataTypeList.Contains(ExcelExportShowDataTypeEnum.Median))
                    {
                        AddedRows += 1;
                        range = ws.Cells[RowCount + AddedRows, colNumber];

                        range.Value = (Median != null ? ((double)Median).ToString("F0") : "--");
                        if (Median > 14)
                        {
                            range.Interior.Color = 65535;
                        }
                        if (!(rowAndTypeList.Where(c => c.RowNumber == (RowCount + AddedRows)).Any()))
                        {
                            rowAndTypeList.Add(new RowAndType() { RowNumber = RowCount + AddedRows, ExcelExportShowDataType = ExcelExportShowDataTypeEnum.Median });
                        }
                    }
                    if (showDataTypeList.Contains(ExcelExportShowDataTypeEnum.PercOfP90Over43))
                    {
                        AddedRows += 1;
                        range = ws.Cells[RowCount + AddedRows, colNumber];

                        range.Value = (PercOver43 != null ? ((double)PercOver43).ToString("F0") : "--");
                        if (PercOver43 > 20)
                        {
                            range.Interior.Color = 65535;
                        }
                        else if (PercOver43 > 10)
                        {
                            range.Interior.Color = 65535;
                        }
                        if (!(rowAndTypeList.Where(c => c.RowNumber == (RowCount + AddedRows)).Any()))
                        {
                            rowAndTypeList.Add(new RowAndType() { RowNumber = RowCount + AddedRows, ExcelExportShowDataType = ExcelExportShowDataTypeEnum.PercOfP90Over43 });
                        }
                    }
                    if (showDataTypeList.Contains(ExcelExportShowDataTypeEnum.PercOfP90Over260))
                    {
                        AddedRows += 1;
                        range = ws.Cells[RowCount + AddedRows, colNumber];

                        range.Value = (PercOver260 != null ? ((double)PercOver260).ToString("F0") : "--");
                        if (PercOver260 > 10)
                        {
                            range.Interior.Color = 65535;
                        }
                        if (!(rowAndTypeList.Where(c => c.RowNumber == (RowCount + AddedRows)).Any()))
                        {
                            rowAndTypeList.Add(new RowAndType() { RowNumber = RowCount + AddedRows, ExcelExportShowDataType = ExcelExportShowDataTypeEnum.PercOfP90Over260 });
                        }
                    }

                    if (mwqmSampleAnalysisForSiteModelToUseList.Contains(mwqmSampleAnalysisModel))
                    {
                        mwqmSampleAnalysisForSiteModelToUseList = mwqmSampleAnalysisForSiteModelToUseList.Skip(1).ToList();
                    }
                }

                RowCount += (1 + AddedRows);
            }

            foreach (RunDateColNumber runDateColNumber in runDateColNumberList)
            {
                if (MWQMRunTVItemIDToOmitList.Contains(runDateColNumber.MWQMRunTVItemID))
                {
                    if (RunUsedColNumberList.Contains(runDateColNumber.ColNumber))
                    {
                        range = ws.Cells[1, runDateColNumber.ColNumber];
                        range.Select();
                        xlApp.Selection.Interior.Color = 255;
                    }
                }
                else
                {
                    if (RunUsedColNumberList.Contains(runDateColNumber.ColNumber))
                    {
                        range = ws.Cells[1, runDateColNumber.ColNumber];
                        range.Select();
                        xlApp.Selection.Interior.Color = 5296274;
                    }
                }
            }

            xlApp.Range[ws.Cells[Math.Abs(mwqmAnalysisReportParameterModel.ShortRangeNumberOfDays) + 2, 13], ws.Cells[Math.Abs(mwqmAnalysisReportParameterModel.ShortRangeNumberOfDays) + 2, 13 + runDateColNumberList.Count() - 1]].Select();
            xlApp.Selection.Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            xlApp.Selection.Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).Color = -11489280;
            xlApp.Selection.Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;

            xlApp.Range[ws.Cells[Math.Abs(mwqmAnalysisReportParameterModel.MidRangeNumberOfDays) + 2, 13], ws.Cells[Math.Abs(mwqmAnalysisReportParameterModel.MidRangeNumberOfDays) + 2, 13 + runDateColNumberList.Count() - 1]].Select();
            xlApp.Selection.Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            xlApp.Selection.Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).Color = -11489280;
            xlApp.Selection.Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;

            foreach (RowAndType rowAndType in rowAndTypeList)
            {
                xlApp.Range["A" + rowAndType.RowNumber.ToString() + ":L" + rowAndType.RowNumber.ToString()].Select();
                xlApp.Selection.Merge();
                xlApp.Selection.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                switch (rowAndType.ExcelExportShowDataType)
                {
                    case ExcelExportShowDataTypeEnum.FecalColiform:
                    case ExcelExportShowDataTypeEnum.Temperature:
                    case ExcelExportShowDataTypeEnum.Salinity:
                    case ExcelExportShowDataTypeEnum.P90:
                    case ExcelExportShowDataTypeEnum.GemetricMean:
                    case ExcelExportShowDataTypeEnum.Median:
                    case ExcelExportShowDataTypeEnum.PercOfP90Over43:
                    case ExcelExportShowDataTypeEnum.PercOfP90Over260:
                        {
                            xlApp.Selection.Value = _BaseEnumService.GetEnumText_ExcelExportShowDataTypeEnum(rowAndType.ExcelExportShowDataType);
                        }
                        break;
                    default:
                        {
                            xlApp.Selection.Value = "Error";
                        }
                        break;
                }
            }

            xlApp.Range["A1"].Select();
            xlApp.ActiveWindow.FreezePanes = false;

            xlApp.Range["M16"].Select();
            xlApp.ActiveWindow.FreezePanes = true;

            ws.Range["A1"].Select();
        }
        #endregion Functions

    }

    public class YearMinMaxDate
    {
        public int Year { get; set; }
        public DateTime MinDateTime { get; set; }
        public DateTime MaxDateTime { get; set; }
    }
}
