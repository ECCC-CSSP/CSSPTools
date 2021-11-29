//namespace CSSPDesktop;

//public partial class CSSPDesktopForm 
//{
//    #region SetupAsync
//    private async Task<bool> SetupAsync()
//    {
//        Configuration = new ConfigurationBuilder()
//            .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
//            .AddJsonFile("appsettings_csspdesktop.json")
//            .Build();

//        Services = new ServiceCollection();

//        Services.AddSingleton<IConfiguration>(Configuration);

//        if (Configuration == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "Configuration") }");

//        if (string.IsNullOrEmpty(Configuration["AzureStoreCSSPFilesPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "AzureStoreCSSPFilesPath", "CSSPDesktopForm") }");
//        if (string.IsNullOrEmpty(Configuration["AzureStoreCSSPJSONPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "AzureStoreCSSPJSONPath", "CSSPDesktopForm") }");
//        if (string.IsNullOrEmpty(Configuration["AzureStoreCSSPWebAPIsLocalPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "AzureStoreCSSPWebAPIsLocalPath", "CSSPDesktopForm") }");
//        if (string.IsNullOrEmpty(Configuration["CSSPAzureUrl"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPAzureUrl", "CSSPDesktopForm") }");
//        if (string.IsNullOrEmpty(Configuration["CSSPDB"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDB", "CSSPDesktopForm") }");
//        if (string.IsNullOrEmpty(Configuration["CSSPDBLocal"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDBLocal", "CSSPDesktopForm") }");
//        if (string.IsNullOrEmpty(Configuration["CSSPDBManage"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDBManage", "CSSPDesktopForm") }");
//        if (string.IsNullOrEmpty(Configuration["CSSPDesktopPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDesktopPath", "CSSPDesktopForm") }");
//        if (string.IsNullOrEmpty(Configuration["CSSPJSONPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPJSONPath", "CSSPDesktopForm") }");
//        if (string.IsNullOrEmpty(Configuration["CSSPJSONPathLocal"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPJSONPathLocal", "CSSPDesktopForm") }");
//        if (string.IsNullOrEmpty(Configuration["CSSPFilesPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPFilesPath", "CSSPDesktopForm") }");
//        if (string.IsNullOrEmpty(Configuration["CSSPLocalUrl"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPLocalUrl", "CSSPDesktopForm") }");
//        if (string.IsNullOrEmpty(Configuration["CSSPOtherFilesPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPOtherFilesPath", "CSSPDesktopForm") }");
//        if (string.IsNullOrEmpty(Configuration["CSSPTempFilesPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPTempFilesPath", "CSSPDesktopForm") }");
//        if (string.IsNullOrEmpty(Configuration["CSSPWebAPIsLocalPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPWebAPIsLocalPath", "CSSPDesktopForm") }");

//        Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
//        Services.AddSingleton<IEnums, Enums>();
//        Services.AddSingleton<ICSSPScrambleService, CSSPScrambleService>();
//        Services.AddSingleton<ICSSPLogService, CSSPLogService>();
//        Services.AddSingleton<ICSSPDesktopService, CSSPDesktopService>();
//        Services.AddSingleton<ICSSPLogService, CSSPLogService>();
//        Services.AddSingleton<ICSSPLocalLoggedInService, CSSPLocalLoggedInService>();
//        Services.AddSingleton<ICSSPSQLiteService, CSSPSQLiteService>();
//        Services.AddSingleton<IManageFileService, ManageFileService>();
//        Services.AddSingleton<ICSSPFileService, CSSPFileService>();
//        Services.AddSingleton<ICSSPReadGzFileService, CSSPReadGzFileService>();
//        Services.AddSingleton<ICSSPAzureLoginService, CSSPAzureLoginService>();

//        /* ---------------------------------------------------------------------------------
//         * using CSSPDBLocal
//         * ---------------------------------------------------------------------------------      
//         */
//        FileInfo fiCSSPDBLocal = new FileInfo(Configuration["CSSPDBLocal"]);

//        Services.AddDbContext<CSSPDBLocalContext>(options =>
//        {
//            options.UseSqlite($"Data Source={ fiCSSPDBLocal.FullName }");
//        });


//        /* ---------------------------------------------------------------------------------
//         * CSSPDBManageContext
//         * ---------------------------------------------------------------------------------      
//         */
//        FileInfo fiCSSPDBManage = new FileInfo(Configuration["CSSPDBManage"]);

//        Services.AddDbContext<CSSPDBManageContext>(options =>
//        {
//            options.UseSqlite($"Data Source={ fiCSSPDBManage.FullName }");
//        });

//        Provider = Services.BuildServiceProvider();
//        if (Provider == null)
//        {
//            richTextBoxStatus.AppendText("Provider should not be null\r\n");
//            return await Task.FromResult(false);
//        }

//        CSSPCultureService = Provider.GetService<ICSSPCultureService>();
//        if (CSSPCultureService == null)
//        {
//            richTextBoxStatus.AppendText("CSSPCultureService should not be null\r\n");
//            return await Task.FromResult(false);
//        }

//        CSSPCultureService.SetCulture("en-CA");

//        CSSPScrambleService = Provider.GetService<ICSSPScrambleService>();
//        if (CSSPScrambleService == null)
//        {
//            richTextBoxStatus.AppendText("CSSPLocalLoggedInService should not be null\r\n");
//            return await Task.FromResult(false);
//        }

//        CSSPLocalLoggedInService = Provider.GetService<ICSSPLocalLoggedInService>();
//        if (CSSPLocalLoggedInService == null)
//        {
//            richTextBoxStatus.AppendText("CSSPLocalLoggedInService should not be null\r\n");
//            return await Task.FromResult(false);
//        }

//        CSSPDesktopService = Provider.GetService<ICSSPDesktopService>();
//        if (CSSPDesktopService == null)
//        {
//            richTextBoxStatus.AppendText("CSSPDesktopService should not be null\r\n");
//            return await Task.FromResult(false);
//        }

//        CSSPDesktopService.StatusClear += CSSPDesktopService_StatusClear;
//        CSSPDesktopService.StatusAppend += CSSPDesktopService_StatusAppend;
//        CSSPDesktopService.StatusInstalling += CSSPDesktopService_StatusInstalling;

//        CSSPDesktopService.IsEnglish = IsEnglish;

//        CSSPSQLiteService = Provider.GetService<ICSSPSQLiteService>();
//        if (CSSPSQLiteService == null)
//        {
//            richTextBoxStatus.AppendText(string.Format(CSSPCultureDesktopRes._ShouldNotBeNull, "CSSPSQLiteService") + "\r\n");
//        }

//        CSSPAzureLoginService = Provider.GetService<ICSSPAzureLoginService>();
//        if (CSSPAzureLoginService == null)
//        {
//            richTextBoxStatus.AppendText(string.Format(CSSPCultureDesktopRes._ShouldNotBeNull, "CSSPSQLiteService") + "\r\n");
//        }

//        if (!await CSSPDesktopService.CreateAllRequiredDirectoriesAsync()) return await Task.FromResult(false);

//        CSSPDBManageContext dbManage = Provider.GetService<CSSPDBManageContext>();
//        if (dbManage == null)
//        {
//            richTextBoxStatus.AppendText(string.Format(CSSPCultureDesktopRes._ShouldNotBeNull, "CSSPSQLiteService") + "\r\n");
//        }

//        // create CSSPDBManage if it does not exist
//        FileInfo fi = new FileInfo(Configuration["CSSPDBManage"]);
//        if (!fi.Exists)
//        {
//            richTextBoxStatus.AppendText(string.Format(CSSPCultureDesktopRes.Creating_SQLiteDatabase, @"C:\CSSPDesktop\cssplocaldatabases\CSSPDBManage.db") + "\r\n");
//            if (!await CSSPSQLiteService.CreateSQLiteCSSPDBManageAsync()) return await Task.FromResult(false);
//            richTextBoxStatus.AppendText(string.Format(CSSPCultureDesktopRes.Created_SQLiteDatabase, @"C:\CSSPDesktop\cssplocaldatabases\CSSPDBManage.db" + "\r\n"));
//        }
//        else
//        {
//            try
//            {
//                var a = (from c in dbManage.Contacts
//                         select c).FirstOrDefault();

//                await CSSPLocalLoggedInService.SetLocalLoggedInContactInfoAsync();
//            }
//            catch (Exception)
//            {
//                richTextBoxStatus.AppendText(string.Format(CSSPCultureDesktopRes.Creating_SQLiteDatabase, @"C:\CSSPDesktop\cssplocaldatabases\CSSPDBManage.db") + "\r\n");
//                if (!await CSSPSQLiteService.CreateSQLiteCSSPDBManageAsync()) return await Task.FromResult(false);
//                richTextBoxStatus.AppendText(string.Format(CSSPCultureDesktopRes.Created_SQLiteDatabase, @"C:\CSSPDesktop\cssplocaldatabases\CSSPDBManage.db" + "\r\n"));
//            }
//        }

//        SettingUpAllTextForLanguage();

//        // create CSSPDBLocal if it does not exist
//        fi = new FileInfo(Configuration["CSSPDBLocal"]);
//        if (!fi.Exists)
//        {
//            richTextBoxStatus.AppendText(string.Format(CSSPCultureDesktopRes.Creating_SQLiteDatabase, @"C:\CSSPDesktop\cssplocaldatabases\CSSPDBLocal.db") + "\r\n");
//            if (!await CSSPSQLiteService.CreateSQLiteCSSPDBLocalAsync()) return await Task.FromResult(false);
//            richTextBoxStatus.AppendText(string.Format(CSSPCultureDesktopRes.Created_SQLiteDatabase, @"C:\CSSPDesktop\cssplocaldatabases\CSSPDBLocal.db") + "\r\n");
//        }

//        splitContainerFirst.Dock = DockStyle.Fill;
//        panelHelp.Dock = DockStyle.Fill;
//        richTextBoxStatus.Dock = DockStyle.Fill;
//        richTextBoxHelp.Dock = DockStyle.Fill;

//        ShowPanels(ShowPanelEnum.Language);

//        RecenterPanels();

//        if (!await CheckInternetConnectionAsync()) return await Task.FromResult(false);

//        if (!await CSSPDesktopService.FillHasCSSPOtherFilesAsync()) return await Task.FromResult(false);

//        lblStatus.Text = "";

//        butLogin.Enabled = false;
//        butRegister.Enabled = false;

//        return await Task.FromResult(true);
//    }
//    #endregion SetupAsync
//}