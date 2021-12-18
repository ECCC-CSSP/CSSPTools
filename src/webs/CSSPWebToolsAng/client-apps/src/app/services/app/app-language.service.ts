import { Injectable } from '@angular/core';
import { GetLanguageEnum, LanguageEnum } from '../../enums/generated/LanguageEnum';

@Injectable({
  providedIn: 'root'
})
export class AppLanguageService {

  Version: string[] = ['Version: 1.0.0.9', 'Version: 1.0.0.9'];

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

  Active: string[] = ['Active', 'Actif'];
  Address: string[] = ['Address', 'Adresse'];
  Addresses: string[] = ['Addresses', 'Adresses'];

  AerationType: string[] = ['Aeration Type', 'Type d\'aération'];
  AlarmSystemType: string[] = ['Alarm System Type', 'Type de système d\'alarme'];
  AllInfrastructures: string[] = ['All infrastructures', 'Tous les infrastructures'];
  AmbientInformation: string[] = ['Ambient Information', 'Milieu ambiant'];
  Ambients: string[] = ['Ambients', 'Milieu ambiant'];
  AmbientSalinity: string[] = ['Ambient Salinity', 'Salinité ambiante'];
  AmbientTemperature: string[] = ['Ambient Temperature', 'Température ambiante'];
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
  associatedWithEachMWQMSite: string[] = [' associated with each MWQM site', ' associé à chaque site de SQEM'];
  associatedWithEachPolSourceSite: string[] = [' associated with each polllution source site', ' associé à chaque site de source de pollution'];
  atDepth: string[] = ['at depth', 'À une profondeur de'];
  AverageDepth_m: string[] = ['Average Depth (m)', 'Profondeur moyenne (m)'];
  AverageFlow_m3_day: string[] = ['Average Flow (m3/day)', 'Débit moyen (m3/day)'];

  BackgroundConcentration: string[] = ['Background Concentration', 'Concentration de fond'];
  BoxModels: string[] = ['Box Models', 'Modèles boite'];

  by: string[] = ['by', 'par'];
  ByMonth: string[] = ['by month', 'par mois'];
  BySeason: string[] = ['by season', 'par saison'];
  ByYear: string[] = ['by year', 'par année'];

  CalculatedResult: string[] = ['Calculated Results', 'Résultats calculés'];
  Cancel: string[] = ['Cancel', 'Annuler'];
  CanNotOverflow: string[] = ['Can not Overflow', 'Peut pas déborder']
  CanOverflow: string[] = ['Can Overflow', 'Peut déborder']
  Chart: string[] = ['Chart', 'Graphique']

  ChartLabelGMOver14: string[] = ['GM (>14 red)', 'MG (>14 rouge)'];
  ChartLabelMedOver14: string[] = ['Med (>14 red)', 'Méd (>14 rouge)'];
  ChartLabelP90Over43: string[] = ['P90 (>43 red)', 'P90 (>43 rouge)'];
  ChartLabelOver43: string[] = ['>43 (>10% red)', '>43 (>10% rouge)'];
  ChartLabelFCMPNPer100ML: string[] = ['FC (MPN / 100 mL)', 'CF (NPB / 100 mL)'];
  ChartLabelSalppt: string[] = ['Sal (ppt)', 'Sal (ppm)'];
  ChartLabelTempDegC: string[] = ['Temp (deg C)', 'Temp (deg C)'];

  ChartHide: string[] = ['Hide chart', 'Cacher graphique'];
  Charts: string[] = ['Charts', 'Graphiques'];
  ChartView: string[] = ['View chart', 'Voir graphique'];

  Close: string[] = ['Close', 'Fermer'];
  CollectionSystemType: string[] = ['Collection System Type', 'Type de réseau collecteur'];
  Comments: string[] = ['Comments', 'Commentaires'];
  Concentration: string[] = ['Concentration', 'Concentration'];
  Concentration_objective_FC: string[] = ['Concentration objective (FC)', 'Objectif de concentration (CF)'];
  ContactNotFound: string[] = ['Contact not found', 'Contact non trouvé'];
  ContinuousFlow: string[] = ['continuous flow', 'débit continu'];

  Count: string[] = ['Count', 'Nombre'];

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

  Create: string[] = ['Create', 'Créer'];
  cubicMeter: string[] = ['m3', 'm3'];
  cubicMetersPerDay: string[] = ['m3/d', 'm3/j'];
  cubicMetersPerSecond: string[] = ['m3/s', 'm3/s'];
  CurrentDirection: string[] = ['Current Direction', 'Direction du courant'];
  CurrentSpeed: string[] = ['Current Speed', 'Vitesse du courant'];
  DecayRate_per_day: string[] = ['Decay Rate (/day)', 'Taux de décroissance (/jour)'];
  DegCelciusTitle: string[] = ['Degree Celcius', 'Dégré Celcius'];
  Delete: string[] = ['Delete', 'Effacer'];
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

  Date: string[] = ['Date', 'Date'];
  
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
  DecayFactorAmplitude: string[] = ['Decay factor amplitude', 'Amplitude du facteur de décroissance'];
  DecayFactorAverage: string[] = ['Decay factor average', 'Moyenne du facteur de décroissance'];
  DecayIsConstant: string[] = ['Decay is constant', 'La décroissance est constante'];
  DecayPreDisinfection: string[] = ['Decay (pre-disinfection)', 'Décroissance (avant la désinfection)'];
  DecayRate: string[] = ['Decay rate', 'Taux de décroissance'];
  DecayUntreated: string[] = ['Decay (untreated)', 'Décroissance (sans traitement)'];
  deg: string[] = ['deg', 'dég'];
  degrees: string[] = ['degrees', 'degrés'];
  DegCelciusSymbol: string[] = ['ºC', 'ºC'];
  Depth: string[] = ['Depth', 'Profondeur'];
  Descending: string[] = ['Descending', 'Descendant'];
  DesignFlow_m3_day: string[] = ['DesignFlow (m3/day)', 'Débit de conception (m3/day)'];
  DesktopReviewed: string[] = ['Desktop reviewed', 'Révisé au bureau'];
  DiffuserInformation: string[] = ['Diffuser Information', 'Information de l\'émissaire'];
  Dilution: string[] = ['Dilution', 'Dilution'];
  Discharge: string[] = ['Discharge', 'Écoulement'];
  DischargeDuration: string[] = ['Discharge Duration', 'Durée de l\'écoulement'];
  DisinfectionType: string[] = ['Disinfection Type', 'Type de désinfection'];
  DistanceFromShore_m: string[] = ['Distance From Shore (m)', 'Distance par rapport à la rive (m)'];
  Download: string[] = ['Download', 'Télécharger'];
  DownloadLocalFile: string[] = ['Download local file', 'Télécharger la filière locale'];
  EffluentFlow: string[] = ['Effluent Flow', 'Débit de l\'effluent'];
  EffluentSalinity: string[] = ['Effluent Salinity', 'Salinité de l\'effluent'];
  EffluentTemperature: string[] = ['Effluent Temperature', 'Température de l\'effluent'];
  Emails: string[] = ['Emails', 'Courriels'];
  EndDateAndTime: string[] = ['End Date and Time', 'Date et l\'heure de la fin'];
  English: string[] = ['English', 'Anglais'];
  Entered: string[] = ['Entered', 'Entré'];

  ExtraComments: string[] = ['Extra Comments', 'Extra commentaires'];

  FacilityType: string[] = ['Facility Type', 'Type d\'établissement'];
  FarFieldCurrentDirection: string[] = ['Far Field Current Direction', 'Direction du courant en champ éloigné'];
  FarFieldCurrentSpeed: string[] = ['Far Field Current Speed', 'Vitesse du courant en champ éloigné'];
  FarFieldDiffusionCoefficient: string[] = ['Far Field Diffusion Coefficient', 'Coefficient de diffusion en champ éloigné'];
  FarFieldVelocity_m_s: string[] = ['Far Field Velocity (m/s)', 'Vitesse en champ éloigné (m/s)'];
  FCInit: string[] = ['FC', 'CF'];
  FCInitTitle: string[] = ['Most probable number of fecal coliform per 100 mL', 'Nombre le plus probable de coliformes fécaux par 100 mL'];
  FCPer100mL: string[] = ['FC/100 mL', 'CF/100 mL'];
  FCSalTemp: string[] = ['FC Sal Temp', 'CF Sal Temp'];
  FCStats: string[] = ['FC Stats', 'Stats CF'];
  FecalColiform: string[] = ['Fecal Coliform', 'Coliformes fécaux'];
  FileDate: string[] = ['File Date', 'Date de la filière'];
  FileDateAccro: string[] = ['D', 'D'];
  FileName: string[] = ['File Name', 'Nom de la filière'];
  FileNameAccro: string[] = ['N', 'N'];

  Files: string[] = ['Files', 'Filières'];

  FileSize: string[] = ['File Size', 'Grosseur de la filière'];
  FileSizeAccro: string[] = ['S', 'G'];
  FileType: string[] = ['File Type', 'Type de la filière'];
  FileTypeAccro: string[] = ['T', 'T'];
  FlowEnd: string[] = ['Flow end', 'Débit de fin'];
  FlowEndDate: string[] = ['Flow end date', 'Date du débit de fin'];
  FlowStart: string[] = ['Flow start', 'Débit de départ'];
  FlowStartDate: string[] = ['Flow start date', 'Date du débit de départ'];
  ForceReload: string[] = ['Force Reload', 'Téléchargement forcé'];
  French: string[] = ['French', 'Français'];
  GeneralParameters: string[] = ['General Parameters', 'Paramètres généraux'];
  GMInit: string[] = ['GM', "MG"];
  GMInitTitle: string[] = ['Geometric mean', 'Moyenne géométrique'];

  Google: string[] = ['Google', 'Google'];
  Inactive: string[] = ['Inactive', 'Inactif'];
  Input: string[] = ['Input', 'Intrants'];
  HasBackupPower: string[] = ['Has backup power', 'A une alimentation de secours'];
  Hide: string[] = ['Hide', 'Cacher'];

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
  HorizontalAngle: string[] = ['Horizontal Angle', 'Angle horizontal'];
  HorizontalAngle_deg: string[] = ['Horizontal Angle (deg)', 'Angle horizontal (deg)'];
  hours: string[] = ['hours', 'heures'];

  Included: string[] = ['Included', 'Inclus'];
  Information: string[] = ['Information', 'Information'];
  Infrastructure: string[] = ['Infrastructure', 'Infrastructure'];

  InfrastructureType: string[] = ['Infrastructure Type', 'Type d\'infrastructure'];

  Issue: string[] = ['Issue', 'Item'];

  Item: string[] = ['Item', "Item"];
  ItemIsCreatedLocal: string[] = ['Item is created local', 'l\'item est créer locale']
  ItemIsDeletedLocal: string[] = ['Item is deleted local', 'l\'item est effacer locale']
  ItemIsModifiedLocal: string[] = ['Item is modified local', 'l\'item est modifier locale']
  ItemName: string[] = ['Item Name', 'Nom de l\'item']
  IsMechanicallyAerated: string[] = ['Is mechanically aerated', 'Est mécaniquement aéré'];

  KB: string[] = ['KB', 'Ko'];
  kmPerhours: string[] = ['km/h', 'km/h'];
  LastUpdate: string[] = ['Last update', 'Dernière mise à jour'];
  LatitudeLongitude: string[] = ['Latitude Longitude', 'Latitude Longitude'];
  Loading: string[] = ['Loading', 'Téléchargement'];
  Localize: string[] = ['Localize', 'Localiser'];
  LocalizeAllFiles: string[] = ['Localize all files', 'Localiser tous les fichiers'];
  LocalizeAzureFile: string[] = ['Localize Azure file', 'Localiser le fichier Azure'];
  Localizing: string[] = ['Localizing...', 'Localisation...'];
  localTime: string[] = ['local time', 'heure locale'];

  m067Pers2: string[] = ['m067/s2', 'm067/s2'];
  m1_3PerSecond: string[] = ['m^(1/3)/s', 'm^(1/3)/s'];
  ManningNumber: string[] = ['Manning number', 'Coefficient de Manning'];
  MedianInit: string[] = ['Med', 'Méd'];
  MedianInitTitle: string[] = ['Median', 'Médianne'];
  meters: string[] = ['meters', 'mètres'];
  metersPerSeconds: string[] = ['m/s', 'm/s'];
  minutes: string[] = ['minutes', 'minutes'];
  Modify: string[] = ['Modify', 'Modifier'];

  MonitoringStats: string[] = ['Monitoring stats', 'Stats d\'échantillonnage']

  Month: string[] = ['Month', 'Mois'];

  MonthOfSampling: string[] = ['Month of sampling', 'Mois d\'échantillonnage'];

  MoreInformationForViewingOrEditing: string[] = ['More information for viewing or editing', 'Plus d\'informations pour afficher ou modifier'];

  Municipality: string[] = ['Municipality', 'Municipalité'];

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

  MWQMRun: string[] = ['MWQM Run', 'Tournée SQEM'];

  MWQMSample: string[] = ['MWQM Sample', 'Echantillons SQEM'];

  MWQMSite: string[] = ['MWQM Site', 'Site SQEM'];
  MWQMSiteName: string[] = ['MWQM site', 'Site SQEM'];
  MWQMSiteNameTitle: string[] = ['Name of marine water quality monitoring site', 'Nom du site surveillance de qualité d\'eau marine'];

  N0E90S180: string[] = ['(N = 0º, E = 90º, S = 180º)', '(N = 0º, E = 90º, S = 180º)'];
  NearFieldVelocity_m_s: string[] = ['Near Field Velocity (m/s)', 'Vitesse en champ rapproché (m/s)'];
  NewItemName: string[] = ['New item name', 'Nom du nouveau item'];
  Next: string[] = ['Next', 'Prochain'];
  new: string[] = ['new', 'nouveau'];
  No: string[] = ['No', 'Non'];
  NoAddress: string[] = ['No address', 'Aucune adresse'];
  NoAlarmSystem: string[] = ['No alarm system', 'Aucune système d\'alarme'];
  NoData: string[] = ['No Data', 'Aucune donnée'];
  NoDecayPreDisinfection: string[] = ['No decay (pre-disinfection)', 'Aucune décroissance (avant la désinfection)'];
  NoDecayUntreated: string[] = ['No decay (untreated)', 'Aucune décroissance (sans traitement)'];
  NotContinuousFlow: string[] = ['not continuous flow', 'débit non continu'];
  NotImplementedYet: string[] = ['Not Implemented Yet', 'Pas encore mis en œuvre']
  NotIncluded: string[] = ['Not included', 'Exclus'];
  NumberOfAeratedCells: string[] = ['Number Of Aerated Cells', 'Nombre de cellules aérées'];
  NumberOfCells: string[] = ['Number of cells', 'Nombre de cellules'];
  NumberOfPorts: string[] = ['Number Of Ports', 'Nombre d\'orifices du diffuseur'];
  Observation: string[] = ['Observation', 'Observation'];
  of: string[] = ['of', 'de'];
  Outfall: string[] = ['Outfall', 'Émissaire'];
  OutfallLatitudeLongitude: string[] = ['Outfall: Latitude Longitude', 'Émissaire: Latitude Longitude'];
  P90Init: string[] = ['P90', 'P90'];
  P90InitTitle: string[] = ['90% of the estimates exceed the P90 estimate', '90% des estimations dépassent l\'estimation P90'];
  PeakFlow_m3_day: string[] = ['Peak Flow (m3/day)', 'Débit de pointe (m3/day)'];
  PercFlowOfTotal: string[] = ['Percent Flow Of Total (%)', 'Pourcentage du débit total (%)'];
  PercOver43Init: string[] = ['>43 (%)', '>43 (%)'];
  PercOver43InitTitle: string[] = ['Percentage of samples exceeding 43', 'Pourcentage d\'échantillons dépassant 43'];

  PercOver260Init: string[] = ['>260 (%)', '>260 (%)'];
  PercOver260InitTitle: string[] = ['Percentage of samples exceeding 260', 'Pourcentage d\'échantillons dépassant 260'];
  perDay: string[] = ['/day', '/jour'];
  PollutantDecayRate: string[] = ['Pollutant Decay Rate', 'Taux de décroissance du polluant'];
  PopServed: string[] = ['Population Served', 'Population desservie'];
  PortDepth: string[] = ['Port Depth', 'Profondeur de l\'orifice'];
  PortDiameter: string[] = ['Port Diameter', 'Diamètre de l\'émissaire'];
  PortDiameter_m: string[] = ['Port Diameter (m)', 'Diamètre de l\'émissaire (m)'];
  PortElevation: string[] = ['Port Elevation', 'Élévation de l\'orifice'];
  PortElevation_m: string[] = ['Port Elevation (m)', 'Élévation de l\'orifice de l\'émissaire (m)'];
  PortSpacing: string[] = ['Port Spacing', 'Espace entre les orifices du diffuseur'];
  PortSpacing_m: string[] = ['Port Spacing (m)', 'Espace entre les orifices du diffuseur (m)'];
  PPTInit: string[] = ['ppt', 'ppm'];
  PPTInitTitle: string[] = ['Salinity in parts per thousand (ppt)', 'Salinité en parties pour mille (ppm)'];
  PreliminaryTreatmentType: string[] = ['Preliminary Treatment Type', 'Type de traitement préliminaire'];
  PrimaryTreatmentType: string[] = ['Primary Treatment Type', 'Type de traitement primaire'];
  Pre_disinfection_FC: string[] = ['Pre-disinfection (FC)', 'Pré-désinfection (CF)'];
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
  PSU: string[] = ['PSU', 'PSU'];

  RectangleLength: string[] = ['Rectangle (Length)'];
  RectangleWidth: string[] = ['Rectangle (Width)'];
  ReceivingWater_MPN_per_100ml: string[] = ['Receiving Water Concentration (FC /100 ml)', 'Concentration dans le milieu récepteur (FC /100 ml)'];
  ReceivingWaterSalinity_PSU: string[] = ['Receiving Water Salinity (PSU)', 'Salinité dans le milieu récepteur (PSU)'];
  ReceivingWaterTemperature_C: string[] = ['Receiving Water Temperature (ºC)', 'Température dans le milieu récepteur (ºC)'];
  Required: string[] = ['Required', 'Requis'];
  Results: string[] = ['Results', 'Résultats'];
  ResultsFrequency: string[] = ['Results frequency', 'Fréquence des résultats'];
  ResultsRaw: string[] = ['Results Raw', 'Résultats Bruts'];
  Retry: string[] = ['Retry', 'Réessayez'];
  River: string[] = ['River', 'Rivière'];
  RootShowCountries: string[] = ['Show countries', 'Montrer pays'];
  RootCountries: string[] = ['Countries', 'Pays'];
  RootShowFiles: string[] = ['Show Files', 'Montrer filières'];
  RootFiles: string[] = ['Files', 'Filières'];
  RootShowExportArcGISTools: string[] = ['Show export Arc GIS tools', 'Montrer outils pour exportation Arc GIS'];
  RootExportArcGIS: string[] = ['Export Arc GIS', 'Exportation Arc GIS'];

  Run: string[] = ['Run', 'Tournée'];
  Runs: string[] = ['Runs', 'Tournées'];

  SAA: string[] = ['SAA', 'MQCD'];
  Salinity: string[] = ['Salinity', 'Salinité'];
  SameAsAbove: string[] = ['Same as above', 'Même que ci-dessus'];
  SampleDate: string[] = ['Sample Date', 'Date d\'échantillonnage'];
  SampleDateTitle: string[] = ['The date the sample was taken', 'La date à laquelle l\'échantillon a été prélevé'];

  SampleNote: string[] = ['Sample note', 'Remarque d\'échantillon'];
  SampleNoteTitle: string[] = ['Sample note', 'Remarque d\'échantillon'];

  SampleTypes: string[] = ['Sample types', 'Type d\'échantillons'];
  SampleTypesTitle: string[] = ['Sample types', 'Type d\'échantillons'];

  Save: string[] = ['Save', 'Sauvegarder'];

  Saving: string[] = ['Saving', 'Sauvegarde'];
  ScenarioLength: string[] = ['Scenario length', 'Durée du scénario'];
  ScenarioName: string[] = ['Scenario name', 'Nom du scénario'];
  SearchSearch: string[] = ['Search', 'Rechercher'];

  Season: string[] = ['Season', 'Saison'];
  SeasonOfSampling: string[] = ['Season of sampling', 'Saison d\'échantillonnage'];

  SecondaryTreatmentType: string[] = ['Secondary Treatment Type', 'Type de traitement secondaire'];
  ShellApplicationName: string[] = ['CSSP Web Tools', 'PCCSM: outils Web'];
  ShellOpenContextMenu: string[] = ['Open context menu', 'Ouvrir le menu contextuel'];
  ShellOpenHistoryMenu: string[] = ['Open history menu', 'Ouvrir le menu historique'];
  ShellReturnHome: string[] = ['Return home', 'Retour à la page d\'accueil'];
  ShellShowMap: string[] = ['Show map', 'Montrer carte'];
  ShellResizeMap: string[] = ['Resize map', 'Redimentionnez la carte'];
  ShellNoInternet: string[] = ['No Internet', 'Pas d\'internet'];

  Show: string[] = ['Show', 'Montre-Moi'];

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
  SemiCircleRadius: string[] = ['Semi Circle (Radius)', 'Demi-cercle (Rayon)'];
  SortBy: string[] = ['Sort by', 'Trier par'];
  SortedBy: string[] = ['Sorted by', 'Trier par'];
  Sources: string[] = ['Sources', 'Sources'];
  squareMeter: string[] = ['m2', 'm2'];
  StartDateAndTime: string[] = ['Start Date and Time', 'Date et l\'heure du début'];
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
  Surface: string[] = ['Surface', 'Surface'];
  T90: string[] = ['T90', 'T90'];
  Table: string[] = ['Table', 'Tableau'];

  TableHide: string[] = ['Hide table', 'Cacher tableau'];
  Tables: string[] = ['Tables', "Tableaux"];
  TableView: string[] = ['View table', 'Voir tableau'];

  Telephones: string[] = ['Telephones', 'Téléphones'];
  Temperature: string[] = ['Temperature', 'Température'];
  TertiaryTreatmentType: string[] = ['Tertiary Treatment Type', 'Type de traitement tertiaire'];
  Time: string[] = ['Time', 'Temps'];
  ToLocalize: string[] = ['To localize', 'A localizer'];
  toUseItOrSaveItSomewhereElse: string[] = ['to use it or save it somewhere else', 'afin de l\'utiliser ou la sauvegarder à un autre endroit'];
  TreatmentType: string[] = ['Treatment Type', 'Type de traitement'];
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

  Under: string[] = ['Under', 'sous'];

  Untreated_FC: string[] = ['Untreated (FC)', 'Sans traitement (CF)'];
  Value: string[] = ['Value', 'Valeur'];
  ValveType: string[] = ['Valve type', 'Type de vanne'];
  VerticalAngle: string[] = ['Vertical Angle', 'Angle vertical'];
  VerticalAngle_deg: string[] = ['Vertical Angle (deg)', 'Angle vertical (deg)'];
  View: string[] = ['View', 'Voir'];

  VisualPlumes: string[] = ['Visual Plumes', 'Visual Plumes'];
  Volume: string[] = ['Volume', 'Volume'];

  WindDirection: string[] = ['Wind direction', 'Direction du vent'];
  WindSpeed: string[] = ['Wind speed', 'Vitesse du vent'];
  WrittenDescription: string[] = ['Written Description', "Ancienne description"];

  Year: string[] = ['Year', 'Année'];
  YearOfSampling: string[] = ['Year of sampling', 'Année d\'échantillonnage'];
  Yes: string[] = ['Yes', 'Oui'];











  
}
