using CSSPEnums;
using CSSPEnumsGenerateCodeHelper;
using CSSPGenerateCodeBase;
using CSSPModels;
using CSSPModelsGenerateCodeHelper;
using Microsoft.EntityFrameworkCore;
//using CSSPServicesGenerateCodeHelper;
//using CSSPWebAPIGenerateCodeHelper;
//using CSSPWebToolsAngGenerateCodeHelper;
using Microsoft.Extensions.Configuration;
using PolSourceGroupingGenerateCodeHelper;
//using PolSourceGroupingGenerateCodeHelper;
//using PostCSSPDoc;
using System; 
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSSPCodeWriter
{
    public partial class CSSPCodeWriter : Form
    {
        #region Variables
        private string fullPath = @"C:\CSSPTools\src\appsettings.json";
        #endregion Variables

        #region Properties
        public IConfigurationRoot Configuration { get; }

        public CSSPDBContext db { get; set; }
        public EnumsCodeWriter enumsCodeWriter { get; set; }
        public EnumsPolSourceCodeWriter enumsPolSourceCodeWriter { get; set; }
        public ModelsCodeWriter modelsCodeWriter { get; set; }
        //public ServicesCodeWriter servicesCodeWriter { get; set; }
        //public WebAPICodeWriter WebAPICodeWriter { get; set; }
        //public AngularCodeWriter AngularCodeWriter { get; set; }
        //public PostCSSPDocCleanFiles PostCSSPDocCleanFiles { get; set; }
        public string CSSPDBConnectionString { get; set; }
        public string TestDBConnectionString { get; set; }
        public List<string> SelectList { get; set; } = new List<string>() { "CSSPEnums", "CSSPModels", "CSSPServices", "CSSPWebAPI", "CSSPWebToolsAng" };
        #endregion Properties

        #region Constructors
        public CSSPCodeWriter()
        {
            Configuration = new ConfigurationBuilder()
                .AddJsonFile(fullPath, optional: true, reloadOnChange: true)
                .Build();

            InitializeComponent();
            StartUp();
        }

        #endregion Construtors

        #region Events

        #region Events Status
        private void ClearPermanentHandler(object sender, GenerateCodeBase.StatusEventArgs e)
        {
            richTextBoxStatus.Text = "";
            Application.DoEvents();
        }
        private void ClearPermanent2Handler(object sender, GenerateCodeBase.StatusEventArgs e)
        {
            richTextBoxStatus2.Text = "";
            Application.DoEvents();
        }
        private void CSSPErrorHandler(object sender, GenerateCodeBase.CSSPErrorEventArgs e)
        {
            richTextBoxStatus.AppendText($"{ e.CSSPError }\r\n");
            Application.DoEvents();
        }
        private void StatusPermanentHandler(object sender, GenerateCodeBase.StatusEventArgs e)
        {
            richTextBoxStatus.AppendText($"{ e.Status }\r\n");
            Application.DoEvents();
        }
        private void StatusPermanent2Handler(object sender, GenerateCodeBase.StatusEventArgs e)
        {
            richTextBoxStatus2.AppendText($"{ e.Status }\r\n");
            Application.DoEvents();
        }
        private void StatusTempHandler(object sender, GenerateCodeBase.StatusEventArgs e)
        {
            lblStatus.Text = e.Status;
            lblStatus.Refresh();
            Application.DoEvents();
        }
        #endregion Events Status

        #region Help Buttons
        #endregion Help Buttons

        #region Events RadioButtons
        private void ShowPanel(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            string RadioButtonName = ((string)radioButton.Tag);

            foreach (Control control in panelTopBottom.Controls)
            {
                if (control.Tag.ToString() == RadioButtonName)
                {
                    control.Visible = true;
                }
                else
                {
                    control.Visible = false;
                }
            }

            string HelpFileName = ((string)radioButton.Tag);
            string FilePath = @"C:\CSSPTools\src\forms\CSSPCodeWriter\Documents\";
            string FullFileName = $"{ FilePath }{ HelpFileName }.rtf";

            richTextBoxStatus2.LoadFile(FullFileName);

            richTextBoxStatus.Text = "";
        }
        #endregion Events RadioButtons

        #region Events CSSPEnums
        private void butCompareEnumsAndOldEnums_Click(object sender, EventArgs e)
        {
            enumsCodeWriter.CompareEnumsAndOldEnums();
        }
        private void butEnumsGenerated_Click(object sender, EventArgs e)
        {
            enumsCodeWriter.Generate_Enums();
        }
        private void butEnumsTestGenerated_Click(object sender, EventArgs e)
        {
            enumsCodeWriter.Generate_EnumsTest();
        }
        private void butGeneratePolSourceEnumCodeFiles_Click(object sender, EventArgs e)
        {
            enumsPolSourceCodeWriter.Generate_EnumPolSourceInfoRelatedFiles();
        }
        private void butGenerateWithDocEnums_Click(object sender, EventArgs e)
        {
            enumsCodeWriter.Generate_EnumsAndPolSourceInfoEnumsWithDoc();
        }
        #endregion Events CSSPEnums

        #region Events CSSPModels
        private void butGenerateModelsTest_Click(object sender, EventArgs e)
        {
            modelsCodeWriter.Generate_ModelClassName_Test();
        }
        private void butGenerateResOnce_Click(object sender, EventArgs e)
        {
            modelsCodeWriter.CSSPModelsRes();
        }
        private void butGenerateSetupOnce_Click(object sender, EventArgs e)
        {
            modelsCodeWriter.ModelClassName_Test();
        }
        private void butGenerateModelsNoHelp_Click(object sender, EventArgs e)
        {
            modelsCodeWriter.ModelsCompareOrModelsGeneratedWithDoc(false);
        }
        private void butRunModelLint_Click(object sender, EventArgs e)
        {
            modelsCodeWriter.CompareDBFieldsAndCSSPModelsDLLProperties(CSSPDBConnectionString);
        }
        private void butGenerateWithDocModels_Click(object sender, EventArgs e)
        {
            modelsCodeWriter.ModelsCompareOrModelsGeneratedWithDoc(true);
        }
        #endregion Events CSSPModels

        #region Events CSSPServices
        private void butRepopulateTesDB_Click(object sender, EventArgs e)
        {
            //servicesCodeWriter.RepopulateTestDB();
        }
        private void butClassNameServiceGenerated_Click(object sender, EventArgs e)
        {
            //servicesCodeWriter.ClassNameServiceGenerated(false);
        }
        private void butClassNameServiceWithDocGenerated_Click(object sender, EventArgs e)
        {
            //servicesCodeWriter.ClassNameServiceGenerated(true);
        }
        private void butClassNameServiceTestGenerated_Click(object sender, EventArgs e)
        {
            //servicesCodeWriter.ClassNameServiceTestGenerated();
        }
        private void butExtensionEnumCastingGenerated_Click(object sender, EventArgs e)
        {
            //servicesCodeWriter.ExtensionEnumCastingGenerated();
        }
        private void butCheckAllTablesInDBHasAtLeast10Items_Click(object sender, EventArgs e)
        {
            //servicesCodeWriter.CheckAllTablesInTestDBHasAtLeast10Items();
        }
        #endregion Events CSSPServices

        #region Events CSSPWebAPI
        private void butGenerateControllers_Click(object sender, EventArgs e)
        {
            //WebAPICodeWriter.ModelControllerGenerated(false);
        }
        private void butGenerateControllersWithDoc_Click(object sender, EventArgs e)
        {
            //WebAPICodeWriter.ModelControllerGenerated(true);
        }
        private void butGenerateControllersTest_Click(object sender, EventArgs e)
        {
            //WebAPICodeWriter.ModelClassNameControllerTestGenerated();
        }
        #endregion Events CSSPWebAPI

        #region Events CSSPWebToolsAng
        private void butAngularEnumsGenerate_Click(object sender, EventArgs e)
        {
            //AngularCodeWriter.AngularEnumsGenerate();
        }
        private void butAngularInterfacesGenerate_Click(object sender, EventArgs e)
        {
            //AngularCodeWriter.AngularInterfacesGenerate();
        }
        #endregion Events CSSPWebToolsAng

        #region Events PostCSSPDoc
        private void butPostCSSPDocCleanFiles_Click(object sender, EventArgs e)
        {
            //PostCSSPDocCleanFiles.CleanFiles();
        }
        #endregion Events PostCSSPDoc

        #endregion Events

        #region Functions public
        #endregion Functions public

        #region Functions private

        #region Functions private CSSPEnums
        #endregion Functions private CSSPEnums

        #region Functions private CSSPModels
        #endregion Functions private CSSPModels

        #region Functions private CSSPServices
        //private void GetRecursiveType(CSSPDBContext db, int level)
        //{
        //    List<TVTypeEnum> tvTypeList = (from c in db.TVItems
        //                                   where c.TVLevel == level
        //                                   select c.TVType).Distinct().ToList();

        //    if (tvTypeList.Count > 0)
        //    {
        //        foreach (TVTypeEnum tvType in tvTypeList)
        //        {
        //            for (int i = 0, count = level; i < count; i++)
        //            {
        //                richTextBoxStatus.AppendText("\t");

        //            }
        //            richTextBoxStatus.AppendText($"{tvType.ToString() }\r\n");
        //        }

        //        GetRecursiveType(db, level + 1);
        //    }
        //}
        #endregion Functions private CSSPServices

        #region Functions private CSSPWebAPI
        #endregion Functions private CSSPWebAPI

        #region Functions private CSSPWebToolsAng
        #endregion Functions private CSSPWebToolsAng

        private void StartUp()
        {
            splitContainer1.SplitterDistance = 130;
            panelCSSPEnumsButtons.Dock = DockStyle.Fill;
            panelCSSPEnumsButtons.Visible = true;
            panelCSSPModelsButtons.Dock = DockStyle.Fill;
            panelCSSPModelsButtons.Visible = false;
            panelCSSPServicesButtons.Dock = DockStyle.Fill;
            panelCSSPServicesButtons.Visible = false;
            panelCSSPWebAPIButtons.Dock = DockStyle.Fill;
            panelCSSPWebAPIButtons.Visible = false;
            panelCSSPWebToolsAngButtons.Dock = DockStyle.Fill;
            panelCSSPWebToolsAngButtons.Visible = false;
            panelCSSPDocButtons.Dock = DockStyle.Fill;
            panelCSSPDocButtons.Visible = false;
            panelPostCSSPDocButtons.Dock = DockStyle.Fill;
            panelPostCSSPDocButtons.Visible = false;

            #region CSSPEnums
            enumsCodeWriter = new EnumsCodeWriter();

            enumsCodeWriter.CSSPErrorHandler += CSSPErrorHandler;
            enumsCodeWriter.StatusPermanentHandler += StatusPermanentHandler;
            enumsCodeWriter.StatusPermanent2Handler += StatusPermanent2Handler;
            enumsCodeWriter.StatusTempHandler += StatusTempHandler;
            enumsCodeWriter.ClearPermanentHandler += ClearPermanentHandler;
            enumsCodeWriter.ClearPermanent2Handler += ClearPermanent2Handler;

            enumsPolSourceCodeWriter = new EnumsPolSourceCodeWriter();

            enumsPolSourceCodeWriter.CSSPErrorHandler += CSSPErrorHandler;
            enumsPolSourceCodeWriter.StatusPermanentHandler += StatusPermanentHandler;
            enumsPolSourceCodeWriter.StatusPermanent2Handler += StatusPermanent2Handler;
            enumsPolSourceCodeWriter.StatusTempHandler += StatusTempHandler;
            enumsPolSourceCodeWriter.ClearPermanentHandler += ClearPermanentHandler;
            enumsPolSourceCodeWriter.ClearPermanent2Handler += ClearPermanent2Handler;
            #endregion CSSPEnums

            #region CSSPModels
            modelsCodeWriter = new ModelsCodeWriter();

            modelsCodeWriter.CSSPErrorHandler += CSSPErrorHandler;
            modelsCodeWriter.StatusPermanentHandler += StatusPermanentHandler;
            modelsCodeWriter.StatusPermanent2Handler += StatusPermanent2Handler;
            modelsCodeWriter.StatusTempHandler += StatusTempHandler;
            modelsCodeWriter.ClearPermanentHandler += ClearPermanentHandler;
            modelsCodeWriter.ClearPermanent2Handler += ClearPermanent2Handler;

            db = new CSSPDBContext();
            CSSPDBConnectionString = Configuration.GetConnectionString("CSSPDB");
            TestDBConnectionString = Configuration.GetConnectionString("TestDB");
            #endregion CSSPModels

            //#region CSSPServices
            //servicesCodeWriter = new ServicesCodeWriter();

            //servicesCodeWriter.CSSPErrorHandler += CSSPErrorHandler;
            //servicesCodeWriter.StatusPermanentHandler += StatusPermanentHandler;
            //servicesCodeWriter.StatusPermanent2Handler += StatusPermanent2Handler;
            //servicesCodeWriter.StatusTempHandler += StatusTempHandler;
            //servicesCodeWriter.ClearPermanentHandler += ClearPermanentHandler;
            //servicesCodeWriter.ClearPermanent2Handler += ClearPermanent2Handler;
            //#endregion CSSPServices

            //#region CSSPWebAPI
            //WebAPICodeWriter = new WebAPICodeWriter();

            //WebAPICodeWriter.CSSPErrorHandler += CSSPErrorHandler;
            //WebAPICodeWriter.StatusPermanentHandler += StatusPermanentHandler;
            //WebAPICodeWriter.StatusPermanent2Handler += StatusPermanent2Handler;
            //WebAPICodeWriter.StatusTempHandler += StatusTempHandler;
            //WebAPICodeWriter.ClearPermanentHandler += ClearPermanentHandler;
            //WebAPICodeWriter.ClearPermanent2Handler += ClearPermanent2Handler;
            //#endregion CSSPWebAPI

            //#region CSSPWebToolsAng
            //AngularCodeWriter = new AngularCodeWriter();

            //AngularCodeWriter.CSSPErrorHandler += CSSPErrorHandler;
            //AngularCodeWriter.StatusPermanentHandler += StatusPermanentHandler;
            //AngularCodeWriter.StatusPermanent2Handler += StatusPermanent2Handler;
            //AngularCodeWriter.StatusTempHandler += StatusTempHandler;
            //AngularCodeWriter.ClearPermanentHandler += ClearPermanentHandler;
            //AngularCodeWriter.ClearPermanent2Handler += ClearPermanent2Handler;
            //#endregion CSSPWebToolsAng

            //#region PostCSSPDoc
            //PostCSSPDocCleanFiles = new PostCSSPDocCleanFiles();

            //PostCSSPDocCleanFiles.CSSPErrorHandler += CSSPErrorHandler;
            //PostCSSPDocCleanFiles.StatusPermanentHandler += StatusPermanentHandler;
            //PostCSSPDocCleanFiles.StatusPermanent2Handler += StatusPermanent2Handler;
            //PostCSSPDocCleanFiles.StatusTempHandler += StatusTempHandler;
            //PostCSSPDocCleanFiles.ClearPermanentHandler += ClearPermanentHandler;
            //PostCSSPDocCleanFiles.ClearPermanent2Handler += ClearPermanent2Handler;
            //#endregion PostCSSPDoc

        }
        #endregion Functions private
    }
}
