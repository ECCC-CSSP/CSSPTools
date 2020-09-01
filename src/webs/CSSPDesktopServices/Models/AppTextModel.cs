using System;
using System.Collections.Generic;
using System.Text;

namespace CSSPDesktopServices.Models
{
    public class AppTextModelEN : AppTextModel
    {
        public AppTextModelEN()
        {
            // Form
            FormTitleText = "CSSP Desktop Application";

            // PanelTop
            butShowLanguagePanelText = "Language";
            butShowHelpPanelText = "Help";
            butShowLoginPanelText = "Login";
            butLogoffText = "Logoff";

            // PanelButtonsCenter
            butStartText = "Start";
            butStopText = "Stop";
            butCloseText = "Close";
            butUpdatesAvailableText = "Updates Available";

            // PanelHelp
            butHideHelpPanelText = "Close Help";

            // PanelUpdateCenter
            butUpdateText = "Update";
            butCancelUpdateText = "Cancel";
            butUpdateCompletedText = "Update Completed";
            lblInstallingText = "Installing...";
            Downloading_ = "Downloading {0}";
            Unzipping_ = "Unzipping {0}";
            UpdateCompleted = "Update Completed";

            // PanelLoginCenter
            lblCSSPWebToolsLoginOneTimeText = "CSSP Web Tools Login (one time thing)";
            lblLoginEmailLoginText = "Login Email:";
            lblPasswordLoginText = "Password:";
            butLoginText = "Login";
            lblInternetRequiredLoginText = "Internet connection is required";
            LoggingIn = "Logging in ... ";

            // PanelLoginCenter
            lblCSSPWebToolsRegister = "CSSP Web Tools Register";
            lblLoginEmailRegisterText = "Login Email:";
            lblFirstNameRegisterText = "First Name:";
            lblLastNameRegisterText = "Last Name:";
            lblInitialRegisterText = "Initial:";
            lblPasswordRegisterText = "Password:";
            lblConfirmPasswordRegisterText = "Confirm password:";
            butRegisterText = "Register";
            lblInternetRequiredRegisterText = "Internet connection is required";
            RegisteringIn = "Registering in...";

            // PanelStatus
            lblStatusText = "Status:";

            // Error
            CouldNotFindFile_ = "Could not find file [{0}]";
            CouldNotCreateDirectory_Error_ = "Could not create directory [{0}]. Error: [{1}]";
            CouldNotDeleteDirectory_Error_ = "Could not delete directory [{0}]. Error: [{1}]";
            CouldNotMoveDirectory_To_Error_ = "Could not move directory [{0}] to directory [{1}]. Error: [{2}]";
            CouldNotGetPropertiesFromAzureStore_AndFile_ = "Could not read properties from Azure Store {0} and file {1}";
            _CouldNotBeFoundInConfigurationFile_ = "{0} could not be found in the configuration file {1}";
            _ShouldNotBeNull = "{0} ne devrais pas être null";
            CouldNotLogin = "Could not login";
            ErrorWhileTryingToLogin = "Error while trying to login";
            CouldNotAddOrModifyCSSPDBFilesManagement_dbFor_ = "Could not add or modify CSSPDBFilesManagement.db for [{0}]";
            CouldNotUnzip_Error_ = "Could not unzip [{0}]. Erreur [{1}]";
            Directory_ShouldExist = "Directory [{0}] should exist";
            CouldNotDeleteFile_Error_ = "Could not delete file [{0}]. Error: [{1}]";

            // Message
            ConnectedOnInternet = "Connected On Internet";
            NoInternetConnection = "No Internet Connection";
            CheckIfHelpFileExist = "Checking if help files exist";
            CheckIfLoginIsRequired = "Checking if login is required";
            CheckIfUpdateIsNeeded = "Checking if updates are available";
            CheckingInternetConnection = "Checking for internet connection";
            CreatingAllRequiredDirectories = "Creating all required directories";
            ReadingConfiguration = "Reading configuration";
            ExecutingBackgroundApps = "Executing background applications";
            StoppingBrowserAndCSSPWebAPIsProcesses = "Stopping of the Browser and CSSPWebAPIs processes";
            InstallUpdates = "Installation of updates";
            Login = "Login";
            Logoff = "Logoff";
            DirectoryCreated_ = "Directory created {0}";
            HelpFileFound_ = "Help file found {0}";
            HelpFileNotFound_ = "Help file not found {0}";
            CouldNotFind_InDBLogin = "Could not find {0} in dbLogin";
            Found_InDBLogin = "Found {0} in dbLogin";
            AzureFile_Changed = "Azure file {0} changed";
            AzureFile_DidNotChanged = "Azure file {0} did not changed";
            TryingToDownload_ = "Trying to download {0}";
            InternetConnectionDetected = "Internet connection detected";
            InternetConnectionNotDetected = "Internet connection not detected";
            Executing_ = "Executing {0}";
            Stopping_ = "Stopping {0}";
            DownloadingFileFromAzure_ = "Downloading zip file from Azure {0}";
            UnzippingDownloadedFile_ = "Unzipping downloaded file {0}";
            CSSPFilesManagementUpdateAzureStorage_AzureFileName_ = "CSSPFilesManagement.db Upate. AzureStorage {0} - AzureFileName {1}";
            PostRequestLoginEmailAndPasswordTo_ = "Post request with LoginEmail and Password to {0}";
            _StoredInTable_AndDatabase_ = "{0} stored in table {1} and {2}";
            InternetConnectionRequiredFirstTimeConnecting = "Internet connection is required the first time connecting";
            CheckIfNewTVItemsOrTVItemLanguagesExist = "Checking and collecting new informations 'TVItems' or 'TVItemLanguage'";
            CSSPDBSearchIsEmpty = "CSSPDBSearch is empty";
            UpdatingCSSPDBSearchThisCanTakeSomeTime = "Updating CSSPDBSearch. This can take some time.";
            ErrorWhileTryingToUpdateCSSPDBSearch = "Error while trying to update CSSPDBSearch";
            CSSPDBSearchHasBeenUpdated_TVItems = "CSSPDBSearch has been updated with {0} items in TVItems";
            CSSPDBSearchIsNotEmpty = "CSSPDBSearch is not empty";
            CSSPDBSearchHas_TVItems = "CSSPDBSearch has {0} TVItems";
            File_CreatedOnAzure = "File {0} created on Azure";
            CouldNotCreateFile_OnAzure = "Could not create file {0} on Azure";
            FillingCSSPDBSearchDatabaseWith_Info = "Filling CSSPDBSearch database with {0} information";
            UpdatingCSSPDBSearchDatabase = "Updating CSSPDBSearch database";
            ErrorWhileTryingToFillCSSPDBSearchDatabaseWith_Info = "Error while trying to fill CSSPDBSearch database with {0} information";
            CSSPDBSearchDatabaseSuccessfullyFilled = "CSSPDBSearch database successfully filled";
            ErrorWhileTryingToUpdateCSSPDBSearchDatabaseFrom_ = "Error while trying to update CSSPDBSearch database from {0}";
            CSSPDBSearchDatabaseSuccessUpdated = "CSSPDBSearch database successfully updated";
            Register = "Register";
        }
    }
    public class AppTextModelFR : AppTextModel
    {
        public AppTextModelFR()
        {
            // Form
            FormTitleText = "Application PCCSM de bureau";
            // PanelTop
            butShowLanguagePanelText = "Langage";
            butShowHelpPanelText = "Aide";
            butShowLoginPanelText = "Connexion";
            butLogoffText = "Déconnextion";

            // PanelButtonsCenter
            butStartText = "Commencer";
            butStopText = "Arrêter";
            butCloseText = "Fermer";
            butUpdatesAvailableText = "Mise à jour disponible";

            // PanelHelp
            butHideHelpPanelText = "Fermer l'aide";

            // PanelUpdateCenter
            butUpdateText = "Mise à jour";
            butCancelUpdateText = "Annuler";
            butUpdateCompletedText = "Mise à jour complété";
            lblInstallingText = "Installation en cours...";
            Downloading_ = "Téléchargement de {0}";
            Unzipping_ = "Décompression de {0}";
            UpdateCompleted = "Mise-à-jour complétée";

            // PanelLoginCenter
            lblCSSPWebToolsLoginOneTimeText = "Connexion à l'outil PCCSM (une fois seulement)";
            lblLoginEmailLoginText = "Courriel de connextion:";
            lblPasswordLoginText = "Mot de passe:";
            butLoginText = "Ouvrir session";
            lblInternetRequiredLoginText = "Connexion internet est requis";
            LoggingIn = "Connexion en cours...";

            // PanelLoginCenter
            lblCSSPWebToolsRegister = "S'enregistrer à l'outil PCCSM";
            lblLoginEmailRegisterText = "Courriel de connextion:";
            lblFirstNameRegisterText = "Prénom:";
            lblLastNameRegisterText = "Nom:";
            lblInitialRegisterText = "Initial:";
            lblPasswordRegisterText = "Mot de passe:";
            lblConfirmPasswordRegisterText = "Confirmation du mot de passe:";
            butRegisterText = "S'enregistrer";
            lblInternetRequiredRegisterText = "Connexion internet est requis";
            RegisteringIn = "S'enregistrer en cours...";

            // PanelStatus
            lblStatusText = "Etat:";

            // Error
            CouldNotFindFile_ = "Dans l'impossibilité de trouver la filière [{0}]";
            CouldNotCreateDirectory_Error_ = "Dans l'impossibilité de créer le répertoire [{0}]. Erreur: [{1}]";
            CouldNotDeleteDirectory_Error_ = "Dans l'impossibilité d'effacer le répertoire [{0}]. Erreur: [{1}]";
            CouldNotMoveDirectory_To_Error_ = "Dans l'impossibilité de déplacer le répertoire [{0}] au répertoire [{1}]. Erreur: [{2}]";
            CouldNotGetPropertiesFromAzureStore_AndFile_ = "Dans l'impossibilité de lire les propriétés de Azure Store {0} et la filière {1}";
            _CouldNotBeFoundInConfigurationFile_ = "Dans l'impossibilité de trouver {0} dans la filière de configuration {1}";
            _ShouldNotBeNull = "{0} should not be null";
            CouldNotLogin = "Dans l'impossibilité d'ouvrir une session";
            ErrorWhileTryingToLogin = "Erreur pendant l'essay d'ouvrir une session";
            CouldNotAddOrModifyCSSPDBFilesManagement_dbFor_ = "Dans l'ipossibilité d'ajouter ou modifier CSSPDBFilesManagement.db pour [{0}]";
            CouldNotUnzip_Error_ = "Dans l'impossibilité de décompresser la filière [{0}]. Erreur [{1}]";
            Directory_ShouldExist = "Le répertoire [{0}] devrait exister";
            CouldNotDeleteFile_Error_ = "Dans l'impossibilité d'effacer la filière [{0}]. Erreur: [{1}]";

            // Message
            ConnectedOnInternet = "Connexion internet exist";
            NoInternetConnection = "Aucune connexion internet";
            CheckIfHelpFileExist = "Vérification si les filières d'aide existes";
            CheckIfLoginIsRequired = "Vérification si une connexion est requise";
            CheckIfUpdateIsNeeded = "Vérification si une mise-à-jour est disponible";
            CheckingInternetConnection = "Vérification d'une connextion internet";
            CreatingAllRequiredDirectories = "Création de tous les répertoires requis";
            ReadingConfiguration = "Lecture de configuration";
            ExecutingBackgroundApps = "Exécution des applications d'arrière-plan";
            StoppingBrowserAndCSSPWebAPIsProcesses = "Arrêt des processus 'Browser' et CSSPWebAPIs";
            InstallUpdates = "Installation de mise-à-jour";
            Login = "Connexion";
            Logoff = "Déconnexion";
            DirectoryCreated_ = "Répertoire créé {0}";
            HelpFileFound_ = "Filière d'aide trouvé {0}";
            HelpFileNotFound_ = "Filière d'aide NON trouvé {0}";
            CouldNotFind_InDBLogin = "{0} introuvable dans dbLogin";
            Found_InDBLogin = "{0} trouvé dans dbLogin";
            AzureFile_Changed = "Filière de Azure {0} a changé";
            AzureFile_DidNotChanged = "Filière de Azure {0} n'a pas changé";
            TryingToDownload_ = "Essayer de télécharger {0}";
            InternetConnectionDetected = "Connexion internet détecté";
            InternetConnectionNotDetected = "Connexion internet non détecté";
            Executing_ = "Exécution {0}";
            Stopping_ = "Arrêt de {0}";
            DownloadingFileFromAzure_ = "Téléchargement de la filière .zip de Azure {0}";
            UnzippingDownloadedFile_ = "Décompression de la filière téléchargé {0}";
            CSSPFilesManagementUpdateAzureStorage_AzureFileName_ = "CSSPFilesManagement.db entré. AzureStorage {0} - AzureFileName {1}";
            PostRequestLoginEmailAndPasswordTo_ = "Requête 'POST' avec LoginEmail et Password à {0}";
            _StoredInTable_AndDatabase_ = "{0} sauvegardé dans la table {1} et la base de données {2}";
            InternetConnectionRequiredFirstTimeConnecting = "Une connexion internet est requise pour se connecter la première fois";
            CheckIfNewTVItemsOrTVItemLanguagesExist = "Vérification et collection de nouvelles informations 'TVItems' ou 'TVItemLanguage'";
            CSSPDBSearchIsEmpty = "CSSPDBSearch est vide";
            UpdatingCSSPDBSearchThisCanTakeSomeTime = "Mise-à-jour de CSSPDBSearch. Cette tâche peut prendre un peu de temps.";
            ErrorWhileTryingToUpdateCSSPDBSearch = "Erreur lors de la mise-à-jour de CSSPDBSearch";
            CSSPDBSearchHasBeenUpdated_TVItems = "Mise-à-jour complété pour CSSPDBSearch avec {0} items de TVItems";
            CSSPDBSearchIsNotEmpty = "CSSPDBSearch n'est pas vide";
            CSSPDBSearchHas_TVItems = "CSSPDBSearch a {0} TVItems";
            File_CreatedOnAzure = "Filière {0} créée dans Azure";
            CouldNotCreateFile_OnAzure = "Dans l'impossibilité de créer la filière {0} dans Azure";
            FillingCSSPDBSearchDatabaseWith_Info = "Remplissage de la base de données CSSPDBSearch avec l'information de {0}";
            UpdatingCSSPDBSearchDatabase = "Mise-à-jour de la base de données CSSPDBSearch";
            ErrorWhileTryingToFillCSSPDBSearchDatabaseWith_Info = "Erreur lors du remplissage de la base de données CSSPDBSearch avec l'information de {0}";
            CSSPDBSearchDatabaseSuccessfullyFilled = "Remplissage de la base de données CSSPDBSearch avec success";
            ErrorWhileTryingToUpdateCSSPDBSearchDatabaseFrom_ = "Erreur lors de la mise-à-jour de la base de données CSSPDBSearch à partir de {0}";
            CSSPDBSearchDatabaseSuccessUpdated = "Mise-à-jour de la base de données CSSPDBSearch avec success";
            Register = "S'enregistrer";
        }
    }
    public class AppTextModel
    {
        // Form
        public string FormTitleText { get; set; }

        // PanelTop
        public string butShowLanguagePanelText { get; set; }
        public string butShowHelpPanelText { get; set; }
        public string butShowLoginPanelText { get; set; }
        public string butLogoffText { get; set; }

        // PanelButtonsCenter
        public string butStartText { get; set; }
        public string butStopText { get; set; }
        public string butCloseText { get; set; }
        public string butUpdatesAvailableText { get; set; }

        // PanelHelp
        public string butHideHelpPanelText { get; set; }

        // PanelUpdateCenter
        public string butUpdateText { get; set; }
        public string butCancelUpdateText { get; set; }
        public string butUpdateCompletedText { get; set; }
        public string lblInstallingText { get; set; }
        public string Downloading_ { get; set; }
        public string Unzipping_ { get; set; }
        public string UpdateCompleted { get; set; }

        // PanelLoginCenter
        public string lblCSSPWebToolsLoginOneTimeText { get; set; }
        public string lblLoginEmailLoginText { get; set; }
        public string lblPasswordLoginText { get; set; }
        public string butLoginText { get; set; }
        public string lblInternetRequiredLoginText { get; set; }
        public string LoggingIn { get; set; }

        // PanelRegisterCenter
        public string lblCSSPWebToolsRegister { get; set; }
        public string lblLoginEmailRegisterText { get; set; }
        public string lblFirstNameRegisterText { get; set; }
        public string lblLastNameRegisterText { get; set; }
        public string lblInitialRegisterText { get; set; }
        public string lblPasswordRegisterText { get; set; }
        public string lblConfirmPasswordRegisterText { get; set; }
        public string butRegisterText { get; set; }
        public string lblInternetRequiredRegisterText { get; set; }
        public string RegisteringIn { get; set; }


        // PanelStatus
        public string lblStatusText { get; set; }

        // Error
        public string CouldNotFindFile_ { get; set; }
        public string CouldNotCreateDirectory_Error_ { get; set; }
        public string CouldNotDeleteDirectory_Error_ { get; set; }
        public string CouldNotMoveDirectory_To_Error_ { get; set; }
        public string CouldNotGetPropertiesFromAzureStore_AndFile_ { get; set; }
        public string _CouldNotBeFoundInConfigurationFile_ { get; set; }
        public string _ShouldNotBeNull { get; set; }
        public string CouldNotLogin { get; set; }
        public string ErrorWhileTryingToLogin { get; set; }
        public string CouldNotAddOrModifyCSSPDBFilesManagement_dbFor_ { get; set; }
        public string CouldNotUnzip_Error_ { get; set; }
        public string Directory_ShouldExist { get; set; }
        public string CouldNotDeleteFile_Error_ { get; set; }

        // Message
        public string ConnectedOnInternet { get; set; }
        public string NoInternetConnection { get; set; }
        public string CheckIfHelpFileExist { get; set; }
        public string CheckIfLoginIsRequired { get; set; }
        public string CheckIfUpdateIsNeeded { get; set; }
        public string CheckIfNewTVItemsOrTVItemLanguagesExist { get; set; }
        public string CheckingInternetConnection { get; set; }
        public string CreatingAllRequiredDirectories { get; set; }
        public string ReadingConfiguration { get; set; }
        public string ExecutingBackgroundApps { get; set; }
        public string StoppingBrowserAndCSSPWebAPIsProcesses { get; set; }
        public string InstallUpdates { get; set; }
        public string Login { get; set; }
        public string Logoff { get; set; }
        public string DirectoryCreated_ { get; set; }
        public string HelpFileFound_ { get; set; }
        public string HelpFileNotFound_ { get; set; }
        public string CouldNotFind_InDBLogin { get; set; }
        public string Found_InDBLogin { get; set; }
        public string AzureFile_Changed { get; set; }
        public string AzureFile_DidNotChanged { get; set; }
        public string TryingToDownload_ { get; set; }
        public string InternetConnectionDetected { get; set; }
        public string InternetConnectionNotDetected { get; set; }
        public string Executing_ { get; set; }
        public string Stopping_ { get; set; }
        public string DownloadingFileFromAzure_ { get; set; }
        public string UnzippingDownloadedFile_ { get; set; }
        public string CSSPFilesManagementUpdateAzureStorage_AzureFileName_ { get; set; }
        public string PostRequestLoginEmailAndPasswordTo_ { get; set; }
        public string _StoredInTable_AndDatabase_ { get; set; }
        public string InternetConnectionRequiredFirstTimeConnecting { get; set; }
        public string CSSPDBSearchIsEmpty { get; set; }
        public string UpdatingCSSPDBSearchThisCanTakeSomeTime { get; set; }
        public string ErrorWhileTryingToUpdateCSSPDBSearch { get; set; }
        public string CSSPDBSearchHasBeenUpdated_TVItems { get; set; }
        public string CSSPDBSearchIsNotEmpty { get; set; }
        public string CSSPDBSearchHas_TVItems { get; set; }
        public string File_CreatedOnAzure { get; set; }
        public string CouldNotCreateFile_OnAzure { get; set; }
        public string FillingCSSPDBSearchDatabaseWith_Info { get; set; }
        public string UpdatingCSSPDBSearchDatabase { get; set; }
        public string ErrorWhileTryingToFillCSSPDBSearchDatabaseWith_Info { get; set; }
        public string CSSPDBSearchDatabaseSuccessfullyFilled { get; set; }
        public string ErrorWhileTryingToUpdateCSSPDBSearchDatabaseFrom_ { get; set; }
        public string CSSPDBSearchDatabaseSuccessUpdated { get; set; }
        public string Register { get; set; }
    }
}
