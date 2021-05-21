import { Injectable } from '@angular/core';
import { GetLanguageEnum, LanguageEnum } from '../enums/generated/LanguageEnum';

@Injectable({
  providedIn: 'root'
})
export class AppLanguageService {

  languageEnum = GetLanguageEnum();

  constructor() {
  }

  SetLanguage(Language: LanguageEnum) {
    if (Language == LanguageEnum.fr) {
      this.Language = LanguageEnum.fr;
      this.LangID = LanguageEnum.fr - 1;
    }
    else {
      this.Language = LanguageEnum.en;
      this.LangID = LanguageEnum.en - 1;
    }
  }

  Language?: LanguageEnum = LanguageEnum.en;
  LangID?: number = 0;

  AnalysisSite: string[] = ['Site', 'Site'];
  AnalysisSamples: string[] = ['Samples', 'Échantillons'];
  AnalysisPeriod: string[] = ['Period', 'Période'];
  AnalysisMinFC: string[] = ['Min FC', 'CF min'];
  AnalysisMaxFC: string[] = ['Max FC', 'CF max'];
  AnalysisGMean: string[] = ['Geo. Mean', 'Moyenne Geo.'];
  AnalysisMedian: string[] = ['Median', 'Médianne'];
  AnalysisP90: string[] = ['P90', 'P90'];
  AnalysisPerOver43: string[] = ['% > 43', '% > 43'];
  AnalysisPerOver260: string[] = ['% > 260', '% > 260'];
  AnalysisPrecipitation: string[] = ['Precipitation', 'Précipitation'];
  AnalysisRunDay: string[] = ['Run Day', 'Tournée'];
  AnalysisStartTide: string[] = ['Start Tide', 'Marée de début'];
  AnalysisEndTide: string[] = ['End Tide', 'Marée de fin'];
  AnalysisInactive: string[] = ['Inactive', 'Inactif'];

  AnalysisDataVisibleFecalColiform: string[] = ['Fecal Coliform / 100 mL', 'Coliformes fécaux / 100 mL'];
  AnalysisDataVisibleTemperature: string[] = ['Temperature (C)', 'Température (C)'];
  AnalysisDataVisibleSalinity: string[] = ['Salinity (ppt)', 'Salinité (ppm)'];
  AnalysisDataVisibleP90: string[] = ['P90', 'P90'];
  AnalysisDataVisibleGeometriMean: string[] = ['Geometric Mean', 'Moyenne géométrique'];
  AnalysisDataVisibleMedian: string[] = ['Median', 'Médiane'];
  AnalysisDataVisiblePerAbove43: string[] = ['% > 43', '% > 43'];
  AnalysisDataVisiblePerAbove260: string[] = ['% > 260', '% > 260'];

  AnalysisOptionsAnalysisOptions: string[] = ['Analysis Options', 'Options d\'analyses'];
  AnalysisOptionsStart: string[] = ['Start', 'Début'];
  AnalysisOptionsEnd: string[] = ['End', 'Fin'];
  AnalysisOptionsRuns: string[] = ['Runs', 'Tournées'];
  AnalysisOptionsCalculation: string[] = ['Calculation', 'Calcul'];
  AnalysisOptionsStartDate: string[] = ['Start Date', 'Date de début'];
  AnalysisOptionsEndDate: string[] = ['End Date', 'Date de fin'];
  AnalysisOptionsPPT: string[] = ['ppt', 'ppm'];
  AnalysisOptionsHighlightSal: string[] = ['Highlight salinity deviation from average', 'Souligner l\'écart de salinité par rapport à la moyenne'];
  AnalysisOptionsUpperLowerRainLimit: string[] = ['Upper and lower rain limit considered dry or wet', 'Limite de pluie supérieure et inférieure considérée comme sèche ou humide'];
  AnalysisOptionsConsideredDry: string[] = ['Considered Dry', 'Considéré sec'];
  AnalysisOptionsConsideredWet: string[] = ['Considered Wet', 'Considéré pluie'];
  AnalysisOptionsDry: string[] = ['Dry', 'Sec'];
  AnalysisOptionsWet: string[] = ['Wet', 'Pluie'];

  AreaShowSectors: string[] = ['Show sectors', 'Montrer secteurs'];
  AreaSectors: string[] = ['Sectors', 'Secteurs'];
  AreaShowFiles: string[] = ['Show files', 'Montrer filières'];
  AreaFiles: string[] = ['Files', 'Filières'];

  Ascending: string[] = ['Ascending', 'Ascendant'];

  ChartLabelGMOver14: string[] = ['GM (>14 red)', 'MG (>14 rouge)'];
  ChartLabelMedOver14: string[] = ['Med (>14 red)', 'Méd (>14 rouge)'];
  ChartLabelP90Over43: string[] = ['P90 (>43 red)', 'P90 (>43 rouge)'];
  ChartLabelOver43: string[] = ['>43 (>10% red)', '>43 (>10% rouge)'];
  ChartLabelFCMPNPer100ML: string[] = ['FC (MPN / 100 mL)', 'CF (NPB / 100 mL)'];
  ChartLabelSalppt: string[] = ['Sal (ppt)', 'Sal (ppm)'];
  ChartLabelTempDegC: string[] = ['Temp (deg C)', 'Temp (deg C)'];

  ContactNotFound: string[] = ['Contact not found', 'Contact non trouvé'];

  CountryShowProvinces: string[] = ['Show provinces', 'Montrer provinces'];
  CountryProvinces: string[] = ['Provinces', 'Provinces'];
  CountryShowFiles: string[] = ['Show files', 'Montrer filières'];
  CountryFiles: string[] = ['Files', 'Filières'];
  CountryShowOpenDataNationalTools: string[] = ['Show open data national tools', 'Montrer outils données ouvertes nationales'];
  CountryOpenDataNational: string[] = ['Open Data National', 'Données ouvertes nationales'];
  CountryShowEmailDistributionList: string[] = ['Show email distribution list', 'Montrer liste de distribution des courriels'];
  CountryEmailDistributionList: string[] = ['Email Distribution List', 'Liste de distribution des courriels'];
  CountryShowRainExceedance: string[] = ['Show rain exceedance', 'Montrer pluie dépassement'];
  CountryRainExceedance: string[] = ['Rain Exceedance', 'Pluie dépassement'];

  DegCelciusTitle: string[] = ['Degree Celcius', 'Dégré Celcius'];

  DateJanuary: string[] = ['January', 'janvier'];
  DateFebruary: string[] = ['February', 'février'];
  DateMarch: string[] = ['March', 'mars'];
  DateApril: string[] = ['April', 'avril'];
  DateMay: string[] = ['May', 'mai'];
  DateJune: string[] = ['June', 'juin'];
  DateJuly: string[] = ['July', 'juillet'];
  DateAugust: string[] = ['August', 'août'];
  DateSeptember: string[] = ['September', 'septembre'];
  DateOctober: string[] = ['October', 'octobre'];
  DateNovember: string[] = ['November', 'novembre'];
  DateDecember: string[] = ['December', 'décembre'];

  DateJanuaryAcronym: string[] = ['Jan', 'jan'];
  DateFebruaryAcronym: string[] = ['Feb', 'fév'];
  DateMarchAcronym: string[] = ['Mar', 'mar'];
  DateAprilAcronym: string[] = ['Apr', 'avr'];
  DateMayAcronym: string[] = ['May', 'mai'];
  DateJuneAcronym: string[] = ['Jun', 'juin'];
  DateJulyAcronym: string[] = ['Jul', 'jul'];
  DateAugustAcronym: string[] = ['Aug', 'août'];
  DateSeptemberAcronym: string[] = ['Sep', 'sep'];
  DateOctoberAcronym: string[] = ['Oct', 'oct'];
  DateNovemberAcronym: string[] = ['Nov', 'nov'];
  DateDecemberAcronym: string[] = ['Dec', 'déc'];

  Descending: string[] = ['Descending', 'Descendant'];

  FCInit: string[] = ['FC', 'CF'];
  FCInitTitle: string[] = ['Most probable number of fecal coliform per 100 mL', 'Nombre le plus probable de coliformes fécaux par 100 mL'];

  FileName: string[] = ['File Name', 'Nom de la filière'];
  FileNameAccro: string[] = ['N', 'N'];
  FileType: string[] = ['File Type', 'Type de la filière'];
  FileTypeAccro: string[] = ['T', 'T'];
  FileSize: string[] = ['File Size', 'Grosseur de la filière'];
  FileSizeAccro: string[] = ['S', 'G'];
  FileDate: string[] = ['File Date', 'Date de la filière'];
  FileDateAccro: string[] = ['D', 'D'];

  ForceReload: string[] = ['Force Reload', 'Téléchargement forcé'];

  GMInit: string[] = ['GM', "MG"];
  GMInitTitle: string[] = ['Geometric mean', 'Moyenne géométrique'];

  HomeCSSPWebTools: string[] = ['CSSP Web Tools', 'PCCSM: outils Web'];
  HomeTheWebToolWillLetYou: string[] = ['The Web tools will let you:', 'Avec les outils Web, il est possible de:'];
  HomeViewAndUpdateWWTPInfo: string[] = ['view and update the waste water treatment plants and the lift stations information,', 'consulter et mettre à jour l\'information des usines de traitement des eaux usées et des postes de pompage,'];
  HomeMakeCalculationUsingBoxModelAndVisualPlumes: string[] = ['make calculation using Box Model and Visual Plumes,', 'exécuter les calculs utilisant Box Model et Visual Plumes,'];
  HomeSetupAndRunMIKEScenariosAndStoreInputsAndResults: string[] = ['Setup and run MIKE scenarios and store inputs and results', 'Configurer et exécuter des scénarios MIKE et stocker les entrées et les résultats'];
  HomeManageMWQMInformation: string[] = ['Manage Marine Water Quality Monitorng Information', 'Gestion de l\'informmation de Surveillance de qualité d\'eau marine'];
  HomeToHaveAccessWebToolsInformationAndApplication: string[] = ['To have access to Web Tools information and application, ', 'Pour accéder à l\'information et aux applications des outils Web,'];
  HomePleaseContactASiteAdministratorListedBelow: string[] = ['please contact a site administrator listed below', 'veuillez contacter un administrateur du site suivants:'];
  HomeStartUsingCSSPWebTools: string[] = ['Start using CSSP Web Tools', 'Utilisez les outils web PCCSM'];
  HomeAzureVersion: string[] = ['(Azure Version)', '(Version Azure)'];

  KB: string[] = ['KB', 'Ko'];

  Loading: string[] = ['Loading', 'Téléchargement'];

  MedianInit: string[] = ['Med', 'Méd'];
  MedianInitTitle: string[] = ['Median', 'Médianne'];

  MoreInformationForViewingOrEditing: string[] = ['More information for viewing or editing', 'Plus d\'informations pour afficher ou modifier'];

  MunicipalityShowContacts: string[] = ['Show contacts', 'Montrer contacts'];
  MunicipalityContacts: string[] = ['Contacts', 'Contacts'];
  MunicipalityShowFiles: string[] = ['Show files', 'Montrer filières'];
  MunicipalityFiles: string[] = ['Files', 'Filières'];
  MunicipalityShowInfrastructures: string[] = ['Show infrastructures', 'Montrer infrastructures'];
  MunicipalityInfrastructures: string[] = ['Infrastructures', 'Infrastructures'];
  MunicipalityShowMikeScenarios: string[] = ['Show MIKE scenaros', 'Montrer les scénarios de MIKE'];
  MunicipalityMikeScenarios: string[] = ['MIKE Scenarios', 'Scénarios de MIKE'];

  MunicipalityWithInfrastructure: string[] = ['Municipality with infrastructure', 'Municipalité avec infrastructure'];
  MunicipalityWithoutInfrastructure: string[] = ['Municipality without infrastructure', 'Municipality sans infrastructure'];

  MWQMSiteName: string[] = ['MWQM site', 'Site SQEM'];
  MWQMSiteNameTitle: string[] = ['Name of marine water quality monitoring site', 'Nom du site surveillance de qualité d\'eau marine'];
  
  Next: string[] = ['Next', 'Prochain'];

  SortBy: string[] = ['Sort by', 'Trier par'];
  SortedBy: string[] = ['Sorted by', 'Trier par'];

  P90Init: string[] = ['P90', 'P90'];
  P90InitTitle: string[] = ['90% of the estimates exceed the P90 estimate', '90% des estimations dépassent l\'estimation P90'];

  PercOver43Init: string[] = ['>43 (%)', '>43 (%)'];
  PercOver43InitTitle: string[] = ['Percentage of samples exceeding 43', 'Pourcentage d\'échantillons dépassant 43'];

  PercOver260Init: string[] = ['>260 (%)', '>260 (%)'];
  PercOver260InitTitle: string[] = ['Percentage of samples exceeding 260', 'Pourcentage d\'échantillons dépassant 260'];

  PPTInit: string[] = ['ppt', 'ppm'];
  PPTInitTitle: string[] = ['Salinity in parts per thousand (ppt)', 'Salinité en parties pour mille (ppm)'];

  ProcessedBy: string[] = ['Processed by', 'Traité par'];
  ProcessedByTitle: string[] = ['Processed by', 'Traité par'];

  ProvinceShowAreas: string[] = ['Show areas', 'Montrer areas'];
  ProvinceAreas: string[] = ['Areas', 'Régions'];
  ProvinceShowMunicipalities: string[] = ['Show municipalities', 'Montrer municipalités'];
  ProvinceMunicipalities: string[] = ['Municipalities', 'Municipalités'];
  ProvinceShowFiles: string[] = ['Show files', 'Montrer filières'];
  ProvinceFiles: string[] = ['Files', 'Filières'];
  ProvinceShowOpenData: string[] = ['Show open data', 'Montrer données ouvertes'];
  ProvinceOpenData: string[] = ['Open Data', 'Données ouvertes'];
  ProvinceShowSamplingPlan: string[] = ['Show sampling plan', 'Montrer plan d\'échantillonnage'];
  ProvinceSamplingPlan: string[] = ['Sampling Plan', 'Plan d\'échantillonnage'];
  ProvinceShowProvinceTools: string[] = ['Show province tools', 'Montrer outils pour province'];
  ProvinceProvinceTools: string[] = ['Province Tools', "Outils pour province"];

  RootShowCountries: string[] = ['Show countries', 'Montrer pays'];
  RootCountries: string[] = ['Countries', 'Pays'];
  RootShowFiles: string[] = ['Show Files', 'Montrer filières'];
  RootFiles: string[] = ['Files', 'Filières'];
  RootShowExportArcGISTools: string[] = ['Show export Arc GIS tools', 'Montrer outils pour exportation Arc GIS'];
  RootExportArcGIS: string[] = ['Export Arc GIS', 'Exportation Arc GIS'];

  SampleDate: string[] = ['Sample Date', 'Date d\'échantillonnage'];
  SampleDateTitle: string[] = ['The date the sample was taken', 'La date à laquelle l\'échantillon a été prélevé'];

  SampleNote: string[] = ['Sample note', 'Remarque d\'échantillon'];
  SampleNoteTitle: string[] = ['Sample note', 'Remarque d\'échantillon'];

  SampleTypes: string[] = ['Sample types', 'Type d\'échantillons'];
  SampleTypesTitle: string[] = ['Sample types', 'Type d\'échantillons'];

  Saving: string[] = ['Saving', 'Sauvegarde'];

  SearchSearch: string[] = ['Search', 'Rechercher'];

  ShellApplicationName: string[] = ['CSSP Web Tools', 'PCCSM: outils Web'];
  ShellOpenContextMenu: string[] = ['Open context menu', 'Ouvrir le menu contextuel'];
  ShellOpenHistoryMenu: string[] = ['Open history menu', 'Ouvrir le menu historique'];
  ShellReturnHome: string[] = ['Return home', 'Retour à la page d\'accueil'];
  ShellShowMap: string[] = ['Show map', 'Montrer carte'];
  ShellResizeMap: string[] = ['Resize map', 'Redimentionnez la carte'];
  ShellNoInternet: string[] = ['No Internet', 'Pas d\'internet'];

  ShowItemOnMap: string[] = ['Show item on map', 'Afficher l\'élément sur la carte'];

  SideNavMenuContextMenu: string[] = ['Context menu', 'Menu contextuel'];
  SideNavMenuShowInactiveItems: string[] = ['Show inactive items', 'Montrer items inactifs'];
  SideNavMenuInactive: string[] = ['Inactive', 'Inactif'];
  SideNavMenuShowDetails: string[] = ['Show details', 'Montrer détails'];
  SideNavMenuDetails: string[] = ['Details', 'Détails'];
  SideNavMenuShowStatCount: string[] = ['Show stat count', 'Montrer stat nombre'];
  SideNavMenuStatCount: string[] = ['Stat Count', 'Stat nombre'];
  SideNavMenuShowLastUpdate: string[] = ['Show last update', 'Montrer dernière mise-à-jour'];
  SideNavMenuLastUpdate: string[] = ['Last Update', 'Dernière mise-à-jour'];
  SideNavMenuShowEdit: string[] = ['Show edit', 'Montrer modifier'];
  SideNavMenuEdit: string[] = ['Edit', 'Modifier'];

  SectorShowSubsectors: string[] = ['Show subsectors', 'Montrer sous-secteurs'];
  SectorSubsectors: string[] = ['Subsectors', 'Sous-secteurs'];
  SectorShowFiles: string[] = ['Show files', 'Montrer filières'];
  SectorFiles: string[] = ['Files', 'Filières'];
  SectorShowMIKEScenarios: string[] = ['Show MIKE scenarios', 'Montrer scénarios MIKE'];
  SectorMIKEScenarios: string[] = ['MIKE Scenarios', 'Scénarios MIKE'];

  StatSampleNumber: string[] = ['Stat sample number', 'Nombre d\'échantillon pour stat'];

  SubsectorShowMWQMSites: string[] = ['Show MWQM sites', 'Montrer sites PSQEM'];
  SubsectorMWQMSites: string[] = ['MWQM Sites', 'Sites PSQEM'];
  SubsectorShowAnalysis: string[] = ['Show analysis', 'Montrer analyse'];
  SubsectorAnalysis: string[] = ['Analysis', 'Analyse'];
  SubsectorShowMWQMRuns: string[] = ['Show MWQM runs', 'Montrer tournées PSQEM'];
  SubsectorMWQMRuns: string[] = ['MWQM Runs', 'Tournées PSQEM'];
  SubsectorShowPollutionSourceSites: string[] = ['Show pollution source sites', 'Montrer sites des sources de pollution'];
  SubsectorPollutionSourceSites: string[] = ['Pollution Source Sites', 'Sites des source de pollution'];
  SubsectorShowFiles: string[] = ['Show files', 'Montrer filières'];
  SubsectorFiles: string[] = ['Files', 'Filières'];
  SubsectorShowSubsectorTools: string[] = ['Show subsector tools', 'Montrer outils de sous-secteurs'];
  SubsectorSubsectorTools: string[] = ['Subsector Tools', 'Outils de sous-secteurs'];
  SubsectorShowLogBook: string[] = ['Show log book', 'Montrer journal de bord'];
  SubsectorLogBook: string[] = ['Log Book', 'Journal de bord'];

  TVItemListDetailAreaSector: string[] = ['Sector', 'Secteur'];
  TVItemListDetailAreaSubsector: string[] = ['Subsector', 'Sous-secteur'];
  TVItemListDetailAreaMWQMSample: string[] = ['MWQM sample', 'Échantillons'];
  TVItemListDetailAreaMWQMSite: string[] = ['MWQM site', 'Site de SQE'];
  TVItemListDetailAreaMWQMRun: string[] = ['MWQM run', 'Tournées'];
  TVItemListDetailAreaPolSourceSite: string[] = ['Pollution source site', 'Site de source de pollution'];

  TVItemListDetailCountryProvince: string[] = ['Province', 'Province'];
  TVItemListDetailCountryMunicipality: string[] = ['Municipality', 'Municipalité'];
  TVItemListDetailCountryLiftStation: string[] = ['Lift station', 'Poste de pompage'];
  TVItemListDetailCountryWWTP: string[] = ['WWTP', 'UÉEU'];
  TVItemListDetailCountryArea: string[] = ['Area', 'Région'];
  TVItemListDetailCountrySector: string[] = ['Sector', 'Secteur'];
  TVItemListDetailCountrySubsector: string[] = ['Subsector', 'Sous-secteur'];
  TVItemListDetailCountryMWQMSample: string[] = ['MWQM sample', 'Échantillons'];
  TVItemListDetailCountryMWQMSite: string[] = ['MWQM site', 'Site de SQE'];
  TVItemListDetailCountryMWQMRun: string[] = ['MWQM run', 'Tournées'];
  TVItemListDetailCountryPolSourceSite: string[] = ['Pollution source site', 'Site de source de pollution'];
  TVItemListDetailCountryMikeScenario: string[] = ['MIKE scenario', 'Scénario de MIKE'];
  TVItemListDetailCountryBoxModel: string[] = ['Box model scenario', 'Scénario boitiers'];
  TVItemListDetailCountryVPScenario: string[] = ['VP scenario', 'Scénario de MIKE'];

  TVItemListDetailMunicipalityLiftStation: string[] = ['Lift station', 'Poste de pompage'];
  TVItemListDetailMunicipalityWWTP: string[] = ['WWTP', 'UÉEU'];
  TVItemListDetailMunicipalityMikeScenario: string[] = ['MIKE scenario', 'Scénario de MIKE'];
  TVItemListDetailMunicipalityBoxModel: string[] = ['Box model scenario', 'Scénario boitiers'];
  TVItemListDetailMunicipalityVPScenario: string[] = ['VP scenario', 'Scénario de MIKE'];

  TVItemListDetailMWQMRunDetailPrecipitations: string[] = ['Precipitations', 'Précipitations'];
  TVItemListDetailMWQMRunDetailDay: string[] = ['Day', 'Jour'];

  TVItemListDetailMWQMSiteDetailStatistics: string[] = ['Statistics', 'Statistiques'];
  TVItemListDetailMWQMSiteDetailSamples: string[] = ['Samples', 'Échantillons'];
  TVItemListDetailMWQMSiteDetailDataset: string[] = ['Dataset', 'Ensemble de données'];
  TVItemListDetailMWQMSiteDetailStatisticsPeriod: string[] = ['Statistics period', 'Période des statistiques'];
  TVItemListDetailMWQMSiteDetailLastSampleDate: string[] = ['Last sample date', 'Date du dernier échantillon'];
  TVItemListDetailMWQMSiteDetailNumberOfSample: string[] = ['Number of sample used for statistics', 'Nombre d\'échantillons utilisés dans les statistiques'];
  TVItemListDetailMWQMSiteDetailMinimumFC: string[] = ['Minimum FC', 'CF minimum'];
  TVItemListDetailMWQMSiteDetailMaximumFC: string[] = ['Maximum FC', 'CF maximum'];
  TVItemListDetailMWQMSiteDetailGeometricMean: string[] = ['Geometric mean', 'Moyenne géométrique'];
  TVItemListDetailMWQMSiteDetailMedian: string[] = ['Median', 'Médiane'];
  TVItemListDetailMWQMSiteDetailP90: string[] = ['P90', 'P90'];
  TVItemListDetailMWQMSiteDetailPerOfSampleWithFCOver43: string[] = ['Percentage of sample with FC > 43', 'Pourcentage des échantillons ayant des CF > 43'];
  TVItemListDetailMWQMSiteDetailPerOfSampleWithFCOver260: string[] = ['Percentage of sample with FC > 260', 'Pourcentage des échantillons ayant des CF > 260'];


  TVItemListDetailProvinceMunicipality: string[] = ['Municipality', 'Municipalité'];
  TVItemListDetailProvinceLiftStation: string[] = ['Lift station', 'Poste de pompage'];
  TVItemListDetailProvinceWWTP: string[] = ['WWTP', 'UÉEU'];
  TVItemListDetailProvinceArea: string[] = ['Area', 'Région'];
  TVItemListDetailProvinceSector: string[] = ['Sector', 'Secteur'];
  TVItemListDetailProvinceSubsector: string[] = ['Subsector', 'Sous-secteur'];
  TVItemListDetailProvinceMWQMSample: string[] = ['MWQM sample', 'Échantillons'];
  TVItemListDetailProvinceMWQMSite: string[] = ['MWQM site', 'Site de SQE'];
  TVItemListDetailProvinceMWQMRun: string[] = ['MWQM run', 'Tournées'];
  TVItemListDetailProvincePolSourceSite: string[] = ['Pollution source site', 'Site de source de pollution'];
  TVItemListDetailProvinceMikeScenario: string[] = ['MIKE scenario', 'Scénario de MIKE'];
  TVItemListDetailProvinceBoxModel: string[] = ['Box model scenario', 'Scénario boitiers'];
  TVItemListDetailProvinceVPScenario: string[] = ['VP scenario', 'Scénario de MIKE'];

  TVItemListDetailSectorSubsector: string[] = ['Subsector', 'Sous-secteur'];
  TVItemListDetailSectorMWQMSample: string[] = ['MWQM sample', 'Échantillons'];
  TVItemListDetailSectorMWQMSite: string[] = ['MWQM site', 'Site de SQE'];
  TVItemListDetailSectorMWQMRun: string[] = ['MWQM run', 'Tournées'];
  TVItemListDetailSectorPolSourceSite: string[] = ['Pollution source site', 'Site de source de pollution'];
  TVItemListDetailSectorMikeScenario: string[] = ['MIKE scenario', 'Scénario de MIKE'];

  TVItemListDetailSubsectorMWQMSample: string[] = ['MWQM sample', 'Échantillons'];
  TVItemListDetailSubsectorMWQMSite: string[] = ['MWQM site', 'Site de SQE'];
  TVItemListDetailSubsectorMWQMRun: string[] = ['MWQM run', 'Tournées'];
  TVItemListDetailSubsectorPolSourceSite: string[] = ['Pollution source site', 'Site de source de pollution'];

}
