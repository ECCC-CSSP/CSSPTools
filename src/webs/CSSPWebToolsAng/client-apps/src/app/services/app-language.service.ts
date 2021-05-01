import { Injectable } from '@angular/core';
import { AppLanguage } from 'src/app/models/AppLanguage.model';
import { GetLanguageEnum } from '../enums/generated/LanguageEnum';

@Injectable({
  providedIn: 'root'
})
export class AppLanguageService {

  languageEnum = GetLanguageEnum();

  constructor() {
  }

  get AppLanguage(): AppLanguage {
    return {
      AnalysisSite: ['Site', 'Site'],
      AnalysisSamples: ['Samples', 'Échantillons'],
      AnalysisPeriod: ['Period', 'Période'],
      AnalysisMinFC: ['Min FC', 'CF min'],
      AnalysisMaxFC: ['Max FC', 'CF max'],
      AnalysisGMean: ['Geo. Mean', 'Moyenne Geo.'],
      AnalysisMedian: ['Median', 'Médianne'],
      AnalysisP90: ['P90', 'P90'],
      AnalysisPerOver43: ['% > 43', '% > 43'],
      AnalysisPerOver260: ['% > 260', '% > 260'],
      AnalysisPrecipitation: ['Precipitation', 'Précipitation'],
      AnalysisRunDay: ['Run Day', 'Tournée'],
      AnalysisStartTide: ['Start Tide', 'Marée de début'],
      AnalysisEndTide: ['End Tide', 'Marée de fin'],
      AnalysisInactive: ['Inactive', 'Inactif'],

      AnalysisDataVisibleFecalColiform: ['Fecal Coliform / 100 mL', 'Coliformes fécaux / 100 mL'],
      AnalysisDataVisibleTemperature: ['Temperature (C)', 'Température (C)'],
      AnalysisDataVisibleSalinity: ['Salinity (ppt)', 'Salinité (ppm)'],
      AnalysisDataVisibleP90: ['P90', 'P90'],
      AnalysisDataVisibleGeometriMean: ['Geometric Mean', 'Moyenne géométrique'],
      AnalysisDataVisibleMedian: ['Median', 'Médiane'],
      AnalysisDataVisiblePerAbove43: ['% > 43', '% > 43'],
      AnalysisDataVisiblePerAbove260: ['% > 260', '% > 260'],

      AnalysisOptionsAnalysisOptions: ['Analysis Options', 'Options d\'analyses'],
      AnalysisOptionsStart: ['Start', 'Début'],
      AnalysisOptionsEnd: ['End', 'Fin'],
      AnalysisOptionsRuns: ['Runs', 'Tournées'],
      AnalysisOptionsCalculation: ['Calculation', 'Calcul'],
      AnalysisOptionsStartDate: ['Start Date', 'Date de début'],
      AnalysisOptionsEndDate: ['End Date', 'Date de fin'],
      AnalysisOptionsPPT: ['ppt', 'ppm'],
      AnalysisOptionsHighlightSal: ['Highlight salinity deviation from average', 'Souligner l\'écart de salinité par rapport à la moyenne'],
      AnalysisOptionsUpperLowerRainLimit: ['Upper and lower rain limit considered dry or wet', 'Limite de pluie supérieure et inférieure considérée comme sèche ou humide'],
      AnalysisOptionsConsideredDry: ['Considered Dry', 'Considéré sec'],
      AnalysisOptionsConsideredWet: ['Considered Wet', 'Considéré pluie'],
      AnalysisOptionsDry: ['Dry', 'Sec'],
      AnalysisOptionsWet: ['Wet', 'Pluie'],

      AreaShowSectors: ['Show sectors', 'Montrer secteurs'],
      AreaSectors: ['Sectors', 'Secteurs'],
      AreaShowFiles: ['Show files', 'Montrer filières'],
      AreaFiles: ['Files', 'Filières'],

      ContactNotFound: ['Contact not found', 'Contact non trouvé'],

      CountryShowProvinces: ['Show provinces', 'Montrer provinces'],
      CountryProvinces: ['Provinces', 'Provinces'],
      CountryShowFiles: ['Show files', 'Montrer filières'],
      CountryFiles: ['Files', 'Filières'],
      CountryShowOpenDataNationalTools: ['Show open data national tools', 'Montrer outils données ouvertes nationales'],
      CountryOpenDataNational: ['Open Data National', 'Données ouvertes nationales'],
      CountryShowEmailDistributionList: ['Show email distribution list', 'Montrer liste de distribution des courriels'],
      CountryEmailDistributionList: ['Email Distribution List', 'Liste de distribution des courriels'],
      CountryShowRainExceedance: ['Show rain exceedance', 'Montrer pluie dépassement'],
      CountryRainExceedance: ['Rain Exceedance', 'Pluie dépassement'],

      DateJanuary: ['January', 'janvier'],
      DateFebruary: ['February', 'février'],
      DateMarch: ['March', 'mars'],
      DateApril: ['April', 'avril'],
      DateMay: ['May', 'mai'],
      DateJune: ['June', 'juin'],
      DateJuly: ['July', 'juillet'],
      DateAugust: ['August', 'août'],
      DateSeptember: ['September', 'septembre'],
      DateOctober: ['October', 'octobre'],
      DateNovember: ['November', 'novembre'],
      DateDecember: ['December', 'décembre'],

      DateJanuaryAcronym: ['Jan', 'jan'],
      DateFebruaryAcronym: ['Feb', 'fév'],
      DateMarchAcronym: ['Mar', 'mar'],
      DateAprilAcronym: ['Apr', 'avr'],
      DateMayAcronym: ['May', 'mai'],
      DateJuneAcronym: ['Jun', 'juin'],
      DateJulyAcronym: ['Jul', 'jul'],
      DateAugustAcronym: ['Aug', 'août'],
      DateSeptemberAcronym: ['Sep', 'sep'],
      DateOctoberAcronym: ['Oct', 'oct'],
      DateNovemberAcronym: ['Nov', 'nov'],
      DateDecemberAcronym: ['Dec', 'déc'],

      HomeCSSPWebTools: ['CSSP Web Tools', 'PCCSM: outils Web'],
      HomeTheWebToolWillLetYou: ['The Web tools will let you:', 'Avec les outils Web, il est possible de:'],
      HomeViewAndUpdateWWTPInfo: ['view and update the waste water treatment plants and the lift stations information,', 'consulter et mettre à jour l\'information des usines de traitement des eaux usées et des postes de pompage,'],
      HomeMakeCalculationUsingBoxModelAndVisualPlumes: ['make calculation using Box Model and Visual Plumes,', 'exécuter les calculs utilisant Box Model et Visual Plumes,'],
      HomeSetupAndRunMIKEScenariosAndStoreInputsAndResults: ['Setup and run MIKE scenarios and store inputs and results', 'Configurer et exécuter des scénarios MIKE et stocker les entrées et les résultats'],
      HomeManageMWQMInformation: ['Manage Marine Water Quality Monitorng Information', 'Gestion de l\'informmation de Surveillance de qualité d\'eau marine'],
      HomeToHaveAccessWebToolsInformationAndApplication: ['To have access to Web Tools information and application, ', 'Pour accéder à l\'information et aux applications des outils Web,'],
      HomePleaseContactASiteAdministratorListedBelow: ['please contact a site administrator listed below', 'veuillez contacter un administrateur du site suivants:'],
      HomeStartUsingCSSPWebTools: ['Start using CSSP Web Tools', 'Utilisez les outils web PCCSM'],
      HomeAzureVersion: ['(Azure Version)', '(Version Azure)'],

      KB: ['KB', 'Ko'],

      Loading: ['Loading', 'Téléchargement'],

      // LoadingWebAllAddresses: ['Loading WebAllAddresses', 'Téléchargement - WebAllAddresses'],
      // LoadingWebAllContacts: ['Loading WebAllContacts', 'Téléchargement - WebAllContacts'],
      // LoadingWebAllCountries: ['Loading WebAllCountries', 'Téléchargement - WebAllCountries'],
      // LoadingWebAllEmails: ['Loading WebAllEmails', 'Téléchargement - WebAllEmails'],
      // LoadingWebAllHelpDocs: ['Loading WebAllHelpDocs', 'Téléchargement - WebAllHelpDocs'],
      // LoadingWebAllMunicipalities: ['Loading WebAllMunicipalities', 'Téléchargement - WebAllMunicipalities'],
      // LoadingWebAllMWQMLookupMPNs: ['Loading WebAllMWQMLookupMPNs', 'Téléchargement - WebAllMWQMLookupMPNs'],
      // LoadingWebAllPolSourceGroupings: ['Loading WebAllPolSourceGroupings', 'Téléchargement - WebAllPolSourceGroupings'],
      // LoadingWebAllPolSourceSiteEffectTerms: ['Loading WebAllPolSourceSiteEffectTerms', 'Téléchargement - WebAllPolSourceSiteEffectTerms'],
      // LoadingWebAllProvinces: ['Loading WebAllProvinces', 'Téléchargement - WebAllProvinces'],
      // LoadingWebAllReportTypes: ['Loading WebAllReportTypes', 'Téléchargement - WebAllReportTypes'],
      // LoadingWebAllTels: ['Loading WebAllTels', 'Téléchargement - WebAllTels'],
      // LoadingWebAllTideLocations: ['Loading WebAllTideLocations', 'Téléchargement - WebAllTideLocations'],
      // LoadingWebAllTVItemLanguages1980_2020: ['Loading WebAllTVItemLanguages1980_2020', 'Téléchargement - WebAllTVItemLanguages1980_2020'],
      // LoadingWebAllTVItemLanguages2021_2060: ['Loading WebAllTVItemLanguages2021_2060', 'Téléchargement - WebAllTVItemLanguages2021_2060'],
      // LoadingWebAllTVItems1980_2020: ['Loading WebAllTVItems1980_2020', 'Téléchargement - WebAllTVItems1980_2020'],
      // LoadingWebAllTVItems2021_2060: ['Loading WebAllTVItems2021_2060', 'Téléchargement - WebAllTVItems2021_2060'],
      // LoadingWebArea: ['Loading WebArea', 'Téléchargement - WebArea'],
      // LoadingWebClimateSites: ['Loading WebClimateSites', 'Téléchargement - WebClimateSites'],
      // LoadingWebCountry: ['Loading WebCountry', 'Téléchargement - WebCountry'],
      // LoadingWebDrogueRuns: ['Loading WebDrogueRuns', 'Téléchargement - WebDrogueRuns'],
      // LoadingWebHydrometricSites: ['Loading WebHydrometricSites', 'Téléchargement - WebHydrometricSites'],
      // LoadingWebLabSheets: ['Loading WebLabSheets', 'Téléchargement - WebLabSheets'],
      // LoadingWebMikeScenarios: ['Loading WebMikeScenarios', 'Téléchargement - WebMikeScenarios'],
      // LoadingWebMunicipality: ['Loading WebMunicipality', 'Téléchargement - WebMunicipality'],
      // LoadingWebMWQMRuns: ['Loading WebMWQMRuns', 'Téléchargement - WebMWQMRuns'],
      // LoadingWebMWQMSamples1980_2020: ['Loading WebMWQMSamples1980_2020', 'Téléchargement - WebMWQMSamples1980_2020'],
      // LoadingWebMWQMSamples2021_2060: ['Loading WebMWQMSamples2021_2060', 'Téléchargement - WebMWQMSamples2021_2060'],
      // LoadingWebMWQMSites: ['Loading WebMWQMSites', 'Téléchargement - WebMWQMSites'],
      // LoadingWebMWQMPolSourceSites: ['Loading WebMWQMPolSourceSites', 'Téléchargement - WebMWQMPolSourceSites'],
      // LoadingWebProvince: ['Loading WebProvince', 'Téléchargement - WebProvince'],
      // LoadingWebRoot: ['Loading WebRoot', 'Téléchargement - WebRoot'],
      // LoadingWebSector: ['Loading WebSector', 'Téléchargement - WebSector'],
      // LoadingWebSubsector: ['Loading WebSubsector', 'Téléchargement - WebSubsector'],
      // LoadingWebTideSites: ['Loading WebTideSites', 'Téléchargement - WebTideSites'],

      MunicipalityShowContacts: ['Show contacts', 'Montrer contacts'],
      MunicipalityContacts: ['Contacts', 'Contacts'],
      MunicipalityShowFiles: ['Show files', 'Montrer filières'],
      MunicipalityFiles: ['Files', 'Filières'],
      MunicipalityShowInfrastructures: ['Show infrastructures', 'Montrer infrastructures'],
      MunicipalityInfrastructures: ['Infrastructures', 'Infrastructures'],
      MunicipalityShowMikeScenarios: ['Show MIKE scenaros', 'Montrer les scénarios de MIKE'],
      MunicipalityMikeScenarios: ['MIKE Scenarios', 'Scénarios de MIKE'],

      ProvinceShowAreas: ['Show areas', 'Montrer areas'],
      ProvinceAreas: ['Areas', 'Régions'],
      ProvinceShowMunicipalities: ['Show municipalities', 'Montrer municipalités'],
      ProvinceMunicipalities: ['Municipalities', 'Municipalités'],
      ProvinceShowFiles: ['Show files', 'Montrer filières'],
      ProvinceFiles: ['Files', 'Filières'],
      ProvinceShowOpenData: ['Show open data', 'Montrer données ouvertes'],
      ProvinceOpenData: ['Open Data', 'Données ouvertes'],
      ProvinceShowSamplingPlan: ['Show sampling plan', 'Montrer plan d\'échantillonnage'],
      ProvinceSamplingPlan: ['Sampling Plan', 'Plan d\'échantillonnage'],
      ProvinceShowProvinceTools: ['Show province tools', 'Montrer outils pour province'],
      ProvinceProvinceTools: ['Province Tools', "Outils pour province"],

      RootShowCountries: ['Show countries', 'Montrer pays'],
      RootCountries: ['Countries', 'Pays'],
      RootShowFiles: ['Show Files', 'Montrer filières'],
      RootFiles: ['Files', 'Filières'],
      RootShowExportArcGISTools: ['Show export Arc GIS tools', 'Montrer outils pour exportation Arc GIS'],
      RootExportArcGIS: ['Export Arc GIS', 'Exportation Arc GIS'],

      Saving: ['Saving', 'Sauvegarde'],

      SearchSearch: ['Search', 'Rechercher'],

      ShellApplicationName: ['CSSP Web Tools', 'PCCSM: outils Web'],
      ShellOpenContextMenu: ['Open context menu', 'Ouvrir le menu contextuel'],
      ShellOpenHistoryMenu: ['Open history menu', 'Ouvrir le menu historique'],
      ShellReturnHome: ['Return home', 'Retour à la page d\'accueil'],
      ShellShowMap: ['Show map', 'Montrer carte'],
      ShellResizeMap: ['Resize map', 'Redimentionnez la carte'],
      ShellNoInternet: ['No Internet', 'Pas d\'internet'],

      SideNavMenuContextMenu: ['Context menu', 'Menu contextuel'],
      SideNavMenuShowInactiveItems: ['Show inactive items', 'Montrer items inactifs'],
      SideNavMenuInactive: ['Inactive', 'Inactif'],
      SideNavMenuShowDetails: ['Show details', 'Montrer détails'],
      SideNavMenuDetails: ['Details', 'Détails'],
      SideNavMenuShowStatCount: ['Show stat count', 'Montrer stat nombre'],
      SideNavMenuStatCount: ['Stat Count', 'Stat nombre'],
      SideNavMenuShowLastUpdate: ['Show last update', 'Montrer dernière mise-à-jour'],
      SideNavMenuLastUpdate: ['Last Update', 'Dernière mise-à-jour'],
      SideNavMenuShowEdit: ['Show edit', 'Montrer modifier'],
      SideNavMenuEdit: ['Edit', 'Modifier'],

      SectorShowSubsectors: ['Show subsectors', 'Montrer sous-secteurs'],
      SectorSubsectors: ['Subsectors', 'Sous-secteurs'],
      SectorShowFiles: ['Show files', 'Montrer filières'],
      SectorFiles: ['Files', 'Filières'],
      SectorShowMIKEScenarios: ['Show MIKE scenarios', 'Montrer scénarios MIKE'],
      SectorMIKEScenarios: ['MIKE Scenarios', 'Scénarios MIKE'],

      StatSampleNumber: ['Stat sample number', 'Nombre d\'échantillon pour stat'],

      SubsectorShowMWQMSites: ['Show MWQM sites', 'Montrer sites PSQEM'],
      SubsectorMWQMSites: ['MWQM Sites', 'Sites PSQEM'],
      SubsectorShowAnalysis: ['Show analysis', 'Montrer analyse'],
      SubsectorAnalysis: ['Analysis', 'Analyse'],
      SubsectorShowMWQMRuns: ['Show MWQM runs', 'Montrer tournées PSQEM'],
      SubsectorMWQMRuns: ['MWQM Runs', 'Tournées PSQEM'],
      SubsectorShowPollutionSourceSites: ['Show pollution source sites', 'Montrer sites des sources de pollution'],
      SubsectorPollutionSourceSites: ['Pollution Source Sites', 'Sites des source de pollution'],
      SubsectorShowFiles: ['Show files', 'Montrer filières'],
      SubsectorFiles: ['Files', 'Filières'],
      SubsectorShowSubsectorTools: ['Show subsector tools', 'Montrer outils de sous-secteurs'],
      SubsectorSubsectorTools: ['Subsector Tools', 'Outils de sous-secteurs'],
      SubsectorShowLogBook: ['Show log book', 'Montrer journal de bord'],
      SubsectorLogBook: ['Log Book', 'Journal de bord'],

      TVItemListDetailAreaSector: ['Sector', 'Secteur'],
      TVItemListDetailAreaSubsector: ['Subsector', 'Sous-secteur'],
      TVItemListDetailAreaMWQMSample: ['MWQM sample', 'Échantillons'],
      TVItemListDetailAreaMWQMSite: ['MWQM site', 'Site de SQE'],
      TVItemListDetailAreaMWQMRun: ['MWQM run', 'Tournées'],
      TVItemListDetailAreaPolSourceSite: ['Pollution source site', 'Site de source de pollution'],

      TVItemListDetailCountryProvince: ['Province', 'Province'],
      TVItemListDetailCountryMunicipality: ['Municipality', 'Municipalité'],
      TVItemListDetailCountryLiftStation: ['Lift station', 'Poste de pompage'],
      TVItemListDetailCountryWWTP: ['WWTP', 'UÉEU'],
      TVItemListDetailCountryArea: ['Area', 'Région'],
      TVItemListDetailCountrySector: ['Sector', 'Secteur'],
      TVItemListDetailCountrySubsector: ['Subsector', 'Sous-secteur'],
      TVItemListDetailCountryMWQMSample: ['MWQM sample', 'Échantillons'],
      TVItemListDetailCountryMWQMSite: ['MWQM site', 'Site de SQE'],
      TVItemListDetailCountryMWQMRun: ['MWQM run', 'Tournées'],
      TVItemListDetailCountryPolSourceSite: ['Pollution source site', 'Site de source de pollution'],
      TVItemListDetailCountryMikeScenario: ['MIKE scenario', 'Scénario de MIKE'],
      TVItemListDetailCountryBoxModel: ['Box model scenario', 'Scénario boitiers'],
      TVItemListDetailCountryVPScenario: ['VP scenario', 'Scénario de MIKE'],

      TVItemListDetailMunicipalityLiftStation: ['Lift station', 'Poste de pompage'],
      TVItemListDetailMunicipalityWWTP: ['WWTP', 'UÉEU'],
      TVItemListDetailMunicipalityMikeScenario: ['MIKE scenario', 'Scénario de MIKE'],
      TVItemListDetailMunicipalityBoxModel: ['Box model scenario', 'Scénario boitiers'],
      TVItemListDetailMunicipalityVPScenario: ['VP scenario', 'Scénario de MIKE'],

      TVItemListDetailMWQMRunDetailPrecipitations: ['Precipitations', 'Précipitations'],
      TVItemListDetailMWQMRunDetailDay: ['Day', 'Jour'],

      TVItemListDetailMWQMSiteDetailStatistics: ['Statistics', 'Statistiques'],
      TVItemListDetailMWQMSiteDetailSamples: ['Samples', 'Échantillons'],
      TVItemListDetailMWQMSiteDetailDataset: ['Dataset', 'Ensemble de données'],
      TVItemListDetailMWQMSiteDetailStatisticsPeriod: ['Statistics period', 'Période des statistiques'],
      TVItemListDetailMWQMSiteDetailLastSampleDate: ['Last sample date', 'Date du dernier échantillon'],
      TVItemListDetailMWQMSiteDetailNumberOfSample: ['Number of sample used for statistics', 'Nombre d\'échantillons utilisés dans les statistiques'],
      TVItemListDetailMWQMSiteDetailMinimumFC: ['Minimum FC', 'CF minimum'],
      TVItemListDetailMWQMSiteDetailMaximumFC: ['Maximum FC', 'CF maximum'],
      TVItemListDetailMWQMSiteDetailGeometricMean: ['Geometric mean', 'Moyenne géométrique'],
      TVItemListDetailMWQMSiteDetailMedian: ['Median', 'Médiane'],
      TVItemListDetailMWQMSiteDetailP90: ['P90', 'P90'],
      TVItemListDetailMWQMSiteDetailPerOfSampleWithFCOver43: ['Percentage of sample with FC > 43', 'Pourcentage des échantillons ayant des CF > 43'],
      TVItemListDetailMWQMSiteDetailPerOfSampleWithFCOver260: ['Percentage of sample with FC > 260', 'Pourcentage des échantillons ayant des CF > 260'],


      TVItemListDetailProvinceMunicipality: ['Municipality', 'Municipalité'],
      TVItemListDetailProvinceLiftStation: ['Lift station', 'Poste de pompage'],
      TVItemListDetailProvinceWWTP: ['WWTP', 'UÉEU'],
      TVItemListDetailProvinceArea: ['Area', 'Région'],
      TVItemListDetailProvinceSector: ['Sector', 'Secteur'],
      TVItemListDetailProvinceSubsector: ['Subsector', 'Sous-secteur'],
      TVItemListDetailProvinceMWQMSample: ['MWQM sample', 'Échantillons'],
      TVItemListDetailProvinceMWQMSite: ['MWQM site', 'Site de SQE'],
      TVItemListDetailProvinceMWQMRun: ['MWQM run', 'Tournées'],
      TVItemListDetailProvincePolSourceSite: ['Pollution source site', 'Site de source de pollution'],
      TVItemListDetailProvinceMikeScenario: ['MIKE scenario', 'Scénario de MIKE'],
      TVItemListDetailProvinceBoxModel: ['Box model scenario', 'Scénario boitiers'],
      TVItemListDetailProvinceVPScenario: ['VP scenario', 'Scénario de MIKE'],

      TVItemListDetailSectorSubsector: ['Subsector', 'Sous-secteur'],
      TVItemListDetailSectorMWQMSample: ['MWQM sample', 'Échantillons'],
      TVItemListDetailSectorMWQMSite: ['MWQM site', 'Site de SQE'],
      TVItemListDetailSectorMWQMRun: ['MWQM run', 'Tournées'],
      TVItemListDetailSectorPolSourceSite: ['Pollution source site', 'Site de source de pollution'],
      TVItemListDetailSectorMikeScenario: ['MIKE scenario', 'Scénario de MIKE'],

      TVItemListDetailSubsectorMWQMSample: ['MWQM sample', 'Échantillons'],
      TVItemListDetailSubsectorMWQMSite: ['MWQM site', 'Site de SQE'],
      TVItemListDetailSubsectorMWQMRun: ['MWQM run', 'Tournées'],
      TVItemListDetailSubsectorPolSourceSite: ['Pollution source site', 'Site de source de pollution'],


    }
  }
}
