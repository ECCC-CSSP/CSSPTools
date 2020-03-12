using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSSPTaskRunner
{
    public partial class CSSPTaskRunnerForm : Form
    {
        public CSSPTaskRunnerForm()
        {
            InitializeComponent();



        }

        private void button1_Click(object sender, EventArgs e)
        {
            AppTaskModel appTaskModel = new AppTaskModel()
            {
                AppTaskID = 4471,
                TVItemID = 635,
                TVItemID2 = 635,
                AppTaskCommand = AppTaskCommandEnum.CreateDocumentFromParameters,
                AppTaskStatus = AppTaskStatusEnum.Created,
                PercentCompleted = 1,
                Parameters = "|||TVItemID,635|||ReportTypeID,23|||Year,2017|||",
                Language = LanguageEnum.en,
                StartDateTime_UTC = DateTime.Now,
                EndDateTime_UTC = null,
                EstimatedLength_second = null,
                RemainingTime_second = null,
                LastUpdateDate_UTC = DateTime.Now,
                LastUpdateContactTVItemID = 2, // Charles LeBlanc
            };


            MWQMAnalysisReportParameterModel mwqmAnalysisReportParameterModel = new MWQMAnalysisReportParameterModel()
            {
                MWQMAnalysisReportParameterID = 1,
                SubsectorTVItemID = 635,
                AnalysisName = "aaaaaaaaaa",
                AnalysisReportYear = 2017,
                StartDate = new DateTime(2017, 8, 9),
                EndDate = new DateTime(1985, 6, 5),
                AnalysisCalculationType = AnalysisCalculationTypeEnum.DryAllAll,
                NumberOfRuns = 30,
                FullYear = true,
                SalinityHighlightDeviationFromAverage = 8,
                ShortRangeNumberOfDays = -3,
                MidRangeNumberOfDays = -6,
                DryLimit24h = 4,
                DryLimit48h = 8,
                DryLimit72h = 12,
                DryLimit96h = 16,
                WetLimit24h = 12,
                WetLimit48h = 25,
                WetLimit72h = 37,
                WetLimit96h = 50,
                RunsToOmit = ",", // "326875,308725,308723,308720,",
                ShowDataTypes = "1,", //,3,4,",
                ExcelTVFileTVItemID = null,
                Command = AnalysisReportExportCommandEnum.Excel,
                LastUpdateDate_UTC = DateTime.Now,
                LastUpdateContactTVItemID = 2,
            };

            if (mwqmAnalysisReportParameterModel.AnalysisCalculationType != AnalysisCalculationTypeEnum.AllAllAll)
            {
                mwqmAnalysisReportParameterModel.FullYear = false;
            }

            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

            if (xlApp == null)
            {
                Console.WriteLine("EXCEL could not be started. Check that your office installation and project references are correct.");
                return;
            }
            xlApp.Visible = true;

            Microsoft.Office.Interop.Excel.Workbook wb = xlApp.Workbooks.Add();

            SetupParametersAndBasicTextOnSheet2(xlApp, wb, mwqmAnalysisReportParameterModel);
            SetupParametersAndBasicTextOnSheet1(xlApp, wb, mwqmAnalysisReportParameterModel);
            SetupStatOnSheet1(xlApp, wb, mwqmAnalysisReportParameterModel);


            FileInfo fi = new FileInfo(@"C:\Users\leblancc\Desktop\ExportToExcelTest.xlsx");
            try
            {
                wb.SaveAs(fi.FullName);
            }
            catch (Exception ex)
            {
                richTextBoxStatus.AppendText("Error : [" + ex.Message + "]");
            }

            wb.Close();
            xlApp.Quit();
        }

    }
}
