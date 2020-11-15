import { Injectable } from '@angular/core';
import { AppLanguage } from 'src/app/models/AppLanguage.model';

@Injectable({
  providedIn: 'root'
})
export class AppLanguageService {

  constructor() {
  }

  get AppLanguage(): AppLanguage {
    return {
      AreaShowSectors: ['', 'Show sectors', 'Montrer secteurs'],
      AreaSectors: ['', 'Sectors', 'Secteurs'],
      AreaShowFiles: ['', 'Show files', 'Montrer filières'],
      AreaFiles: ['', 'Files', 'Filières'],

      ContactNotFound: ['', 'Contact not found', 'Contact non trouvé'],

      CountryShowProvinces: ['', 'Show provinces', 'Montrer provinces'],
      CountryProvinces: ['', 'Provinces', 'Provinces'],
      CountryShowFiles: ['', 'Show files', 'Montrer filières'],
      CountryFiles: ['', 'Files', 'Filières'],
      CountryShowOpenDataNationalTools: ['', 'Show open data national tools', 'Montrer outils données ouvertes nationales'],
      CountryOpenDataNational: ['', 'Open Data National', 'Données ouvertes nationales'],
      CountryShowEmailDistributionList: ['', 'Show email distribution list', 'Montrer liste de distribution des courriels'],
      CountryEmailDistributionList: ['', 'Email Distribution List', 'Liste de distribution des courriels'],
      CountryShowRainExceedance: ['', 'Show rain exceedance', 'Montrer pluie dépassement'],
      CountryRainExceedance: ['', 'Rain Exceedance', 'Pluie dépassement'],
  
      DateJanuary: ['', 'January', 'janvier'],
      DateFebruary: ['', 'February', 'février'],
      DateMarch: ['', 'March', 'mars'],
      DateApril: ['', 'April', 'avril'],
      DateMay: ['', 'May', 'mai'],
      DateJune: ['', 'June', 'juin'],
      DateJuly: ['', 'July', 'juillet'],
      DateAugust: ['', 'August', 'août'],
      DateSeptember: ['', 'September', 'septembre'],
      DateOctober: ['', 'October', 'octobre'],
      DateNovember: ['', 'November', 'novembre'],
      DateDecember: ['', 'December', 'décembre'],

      DateJanuaryAcronym: ['', 'Jan', 'jan'],
      DateFebruaryAcronym: ['', 'Feb', 'fév'],
      DateMarchAcronym: ['', 'Mar', 'mar'],
      DateAprilAcronym: ['', 'Apr', 'avr'],
      DateMayAcronym: ['', 'May', 'mai'],
      DateJuneAcronym: ['', 'Jun', 'juin'],
      DateJulyAcronym: ['', 'Jul', 'jul'],
      DateAugustAcronym: ['', 'Aug', 'août'],
      DateSeptemberAcronym: ['', 'Sep', 'sep'],
      DateOctoberAcronym: ['', 'Oct', 'oct'],
      DateNovemberAcronym: ['', 'Nov', 'nov'],
      DateDecemberAcronym: ['', 'Dec', 'déc'],

      HomeCSSPWebTools: ['', 'CSSP Web Tools', 'PCCSM: outils Web'],
      HomeTheWebToolWillLetYou: ['', 'The Web tools will let you:', 'Avec les outils Web, il est possible de:'],
      HomeViewAndUpdateWWTPInfo: ['', 'view and update the waste water treatment plants and the lift stations information,', 'consulter et mettre à jour l\'information des usines de traitement des eaux usées et des postes de pompage,'],
      HomeMakeCalculationUsingBoxModelAndVisualPlumes: ['', 'make calculation using Box Model and Visual Plumes,', 'exécuter les calculs utilisant Box Model et Visual Plumes,'],
      HomeSetupAndRunMIKEScenariosAndStoreInputsAndResults: ['', 'Setup and run MIKE scenarios and store inputs and results', 'Configurer et exécuter des scénarios MIKE et stocker les entrées et les résultats'],
      HomeManageMWQMInformation: ['', 'Manage Marine Water Quality Monitorng Information', 'Gestion de l\'informmation de Surveillance de qualité d\'eau marine'],
      HomeToHaveAccessWebToolsInformationAndApplication: ['', 'To have access to Web Tools information and application, ', 'Pour accéder à l\'information et aux applications des outils Web,'],
      HomePleaseContactASiteAdministratorListedBelow: ['', 'please contact a site administrator listed below', 'veuillez contacter un administrateur du site suivants:'],
      HomeStartUsingCSSPWebTools: ['', 'Start using CSSP Web Tools', 'Utilisez les outils web PCCSM'],
      HomeAzureVersion: ['', '(Azure Version)', '(Version Azure)'],

      KB: ['', 'KB', 'Ko'],

      MunicipalityShowContacts: ['', 'Show contacts', 'Montrer contacts'],
      MunicipalityContacts: ['', 'Contacts', 'Contacts'],
      MunicipalityShowFiles: ['', 'Show files', 'Montrer filières'],
      MunicipalityFiles: ['', 'Files', 'Filières'],
      MunicipalityShowInfrastructures: ['', 'Show infrastructures', 'Montrer infrastructures'],
      MunicipalityInfrastructures: ['', 'Infrastructures', 'Infrastructures'],
      MunicipalityShowMikeScenarios: ['', 'Show MIKE scenaros', 'Montrer les scénarios de MIKE'],
      MunicipalityMikeScenarios: ['', 'MIKE Scenarios', 'Scénarios de MIKE'],

      ProvinceShowAreas: ['', 'Show areas', 'Montrer areas'],
      ProvinceAreas: ['', 'Areas', 'Régions'],
      ProvinceShowMunicipalities: ['', 'Show municipalities', 'Montrer municipalités'],
      ProvinceMunicipalities: ['', 'Municipalities', 'Municipalités'],
      ProvinceShowFiles: ['', 'Show files', 'Montrer filières'],
      ProvinceFiles: ['', 'Files', 'Filières'],
      ProvinceShowOpenData: ['', 'Show open data', 'Montrer données ouvertes'],
      ProvinceOpenData: ['', 'Open Data', 'Données ouvertes'],
      ProvinceShowSamplingPlan: ['', 'Show sampling plan', 'Montrer plan d\'échantillonnage'],
      ProvinceSamplingPlan: ['', 'Sampling Plan', 'Plan d\'échantillonnage'],
      ProvinceShowProvinceTools: ['', 'Show province tools', 'Montrer outils pour province'],
      ProvinceProvinceTools: ['', 'Province Tools', "Outils pour province"],
  
      RootShowCountries: ['', 'Show countries', 'Montrer pays'],
      RootCountries: ['', 'Countries', 'Pays'],
      RootShowFiles: ['', 'Show Files', 'Montrer filières'],
      RootFiles: ['', 'Files', 'Filières'],
      RootShowExportArcGISTools: ['', 'Show export Arc GIS tools', 'Montrer outils pour exportation Arc GIS'],
      RootExportArcGIS: ['', 'Export Arc GIS', 'Exportation Arc GIS'],

      SearchSearch: ['', 'Search', 'Rechercher'],

      ShellApplicationName: ['', 'CSSP Web Tools', 'PCCSM: outils Web'],
      ShellOpenContextMenu: ['', 'Open context menu', 'ouvrir le menu contextuel'],
      ShellReturnHome: ['', 'Return home', 'Retour à la page d\'accueil'],
      ShellShowMap: ['', 'Show map', 'Montrer carte'],
      ShellResizeMap: ['', 'Resize map', 'Redimentionnez la carte'],

      SideNavMenuContextMenu: ['', 'Context menu', 'Menu contextuel'],
      SideNavMenuShowInactiveItems: ['', 'Show inactive items', 'Montrer items inactifs'],
      SideNavMenuInactive: ['', 'Inactive', 'Inactif'],
      SideNavMenuShowDetails: ['', 'Show details', 'Montrer détails'],
      SideNavMenuDetails: ['', 'Details', 'Détails'],
      SideNavMenuShowStatCount: ['', 'Show stat count', 'Montrer stat nombre'],
      SideNavMenuStatCount: ['', 'Stat Count', 'Stat nombre'],
      SideNavMenuShowLastUpdate: ['', 'Show last update', 'Montrer dernière mise-à-jour'],
      SideNavMenuLastUpdate: ['', 'Last Update', 'Dernière mise-à-jour'],
      SideNavMenuShowEdit: ['', 'Show edit', 'Montrer modifier'],
      SideNavMenuEdit: ['', 'Edit', 'Modifier'],

      SectorShowSubsectors: ['', 'Show subsectors', 'Montrer sous-secteurs'],
      SectorSubsectors: ['', 'Subsectors', 'Sous-secteurs'],
      SectorShowFiles: ['', 'Show files', 'Montrer filières'],
      SectorFiles: ['', 'Files', 'Filières'],
      SectorShowMIKEScenarios: ['', 'Show MIKE scenarios', 'Montrer scénarios MIKE'],
      SectorMIKEScenarios: ['', 'MIKE Scenarios', 'Scénarios MIKE'],
  
      SubsectorShowMWQMSites: ['', 'Show MWQM sites', 'Montrer sites PSQEM'],
      SubsectorMWQMSites: ['', 'MWQM Sites', 'Sites PSQEM'],
      SubsectorShowAnalysis: ['', 'Show analysis', 'Montrer analyse'],
      SubsectorAnalysis: ['', 'Analysis', 'Analyse'],
      SubsectorShowMWQMRuns: ['', 'Show MWQM runs', 'Montrer tournées PSQEM'],
      SubsectorMWQMRuns: ['', 'MWQM Runs', 'Tournées PSQEM'],
      SubsectorShowPollutionSourceSites: ['', 'Show pollution source sites', 'Montrer sites des sources de pollution'],
      SubsectorPollutionSourceSites: ['', 'Pollution Source Sites', 'Sites des source de pollution'],
      SubsectorShowFiles: ['', 'Show files', 'Montrer filières'],
      SubsectorFiles: ['', 'Files', 'Filières'],
      SubsectorShowSubsectorTools: ['', 'Show subsector tools', 'Montrer outils de sous-secteurs'],
      SubsectorSubsectorTools: ['', 'Subsector Tools', 'Outils de sous-secteurs'],
      SubsectorShowLogBook: ['', 'Show log book', 'Montrer journal de bord'],
      SubsectorLogBook: ['', 'Log Book', 'Journal de bord'],

      TVItemListDetailAreaSector: ['', 'Sector', 'Secteur'],
      TVItemListDetailAreaSubsector: ['', 'Subsector', 'Sous-secteur'],
      TVItemListDetailAreaMWQMSample: ['', 'MWQM sample', 'Échantillons'],
      TVItemListDetailAreaMWQMSite: ['', 'MWQM site', 'Site de SQE'],
      TVItemListDetailAreaMWQMRun: ['', 'MWQM run', 'Tournées'],
      TVItemListDetailAreaPolSourceSite: ['', 'Pollution source site', 'Site de source de pollution'],

      TVItemListDetailCountryProvince: ['', 'Province', 'Province'],
      TVItemListDetailCountryMunicipality: ['', 'Municipality', 'Municipalité'],
      TVItemListDetailCountryLiftStation: ['', 'Lift station', 'Poste de pompage'],
      TVItemListDetailCountryWWTP: ['', 'WWTP', 'UÉEU'],
      TVItemListDetailCountryArea: ['', 'Area', 'Région'],
      TVItemListDetailCountrySector: ['', 'Sector', 'Secteur'],
      TVItemListDetailCountrySubsector: ['', 'Subsector', 'Sous-secteur'],
      TVItemListDetailCountryMWQMSample: ['', 'MWQM sample', 'Échantillons'],
      TVItemListDetailCountryMWQMSite: ['', 'MWQM site', 'Site de SQE'],
      TVItemListDetailCountryMWQMRun: ['', 'MWQM run', 'Tournées'],
      TVItemListDetailCountryPolSourceSite: ['', 'Pollution source site', 'Site de source de pollution'],
      TVItemListDetailCountryMikeScenario: ['', 'MIKE scenario', 'Scénario de MIKE'],
      TVItemListDetailCountryBoxModel: ['', 'Box model scenario', 'Scénario boitiers'],
      TVItemListDetailCountryVPScenario: ['', 'VP scenario', 'Scénario de MIKE'],

      TVItemListDetailMunicipalityLiftStation: ['', 'Lift station', 'Poste de pompage'],
      TVItemListDetailMunicipalityWWTP: ['', 'WWTP', 'UÉEU'],
      TVItemListDetailMunicipalityMikeScenario: ['', 'MIKE scenario', 'Scénario de MIKE'],
      TVItemListDetailMunicipalityBoxModel: ['', 'Box model scenario', 'Scénario boitiers'],
      TVItemListDetailMunicipalityVPScenario: ['', 'VP scenario', 'Scénario de MIKE'],

      TVItemListDetailProvinceMunicipality: ['', 'Municipality', 'Municipalité'],
      TVItemListDetailProvinceLiftStation: ['', 'Lift station', 'Poste de pompage'],
      TVItemListDetailProvinceWWTP: ['', 'WWTP', 'UÉEU'],
      TVItemListDetailProvinceArea: ['', 'Area', 'Région'],
      TVItemListDetailProvinceSector: ['', 'Sector', 'Secteur'],
      TVItemListDetailProvinceSubsector: ['', 'Subsector', 'Sous-secteur'],
      TVItemListDetailProvinceMWQMSample: ['', 'MWQM sample', 'Échantillons'],
      TVItemListDetailProvinceMWQMSite: ['', 'MWQM site', 'Site de SQE'],
      TVItemListDetailProvinceMWQMRun: ['', 'MWQM run', 'Tournées'],
      TVItemListDetailProvincePolSourceSite: ['', 'Pollution source site', 'Site de source de pollution'],
      TVItemListDetailProvinceMikeScenario: ['', 'MIKE scenario', 'Scénario de MIKE'],
      TVItemListDetailProvinceBoxModel: ['', 'Box model scenario', 'Scénario boitiers'],
      TVItemListDetailProvinceVPScenario: ['', 'VP scenario', 'Scénario de MIKE'],

      TVItemListDetailSectorSubsector: ['', 'Subsector', 'Sous-secteur'],
      TVItemListDetailSectorMWQMSample: ['', 'MWQM sample', 'Échantillons'],
      TVItemListDetailSectorMWQMSite: ['', 'MWQM site', 'Site de SQE'],
      TVItemListDetailSectorMWQMRun: ['', 'MWQM run', 'Tournées'],
      TVItemListDetailSectorPolSourceSite: ['', 'Pollution source site', 'Site de source de pollution'],
      TVItemListDetailSectorMikeScenario: ['', 'MIKE scenario', 'Scénario de MIKE'],

      TVItemListDetailSubsectorMWQMSample: ['', 'MWQM sample', 'Échantillons'],
      TVItemListDetailSubsectorMWQMSite: ['', 'MWQM site', 'Site de SQE'],
      TVItemListDetailSubsectorMWQMRun: ['', 'MWQM run', 'Tournées'],
      TVItemListDetailSubsectorPolSourceSite: ['', 'Pollution source site', 'Site de source de pollution'],
  

    }
  }
}