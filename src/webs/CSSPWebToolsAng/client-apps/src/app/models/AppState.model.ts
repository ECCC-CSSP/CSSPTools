import { AreaSubComponentEnum } from '../enums/generated/AreaSubComponentEnum';
import { AscDescEnum } from '../enums/generated/AscDescEnum';
import { CountrySubComponentEnum } from '../enums/generated/CountrySubComponentEnum';
import { FilesSortPropEnum } from '../enums/generated/FilesSortPropEnum';
import { LanguageEnum } from '../enums/generated/LanguageEnum';
import { MapSizeEnum } from '../enums/generated/MapSizeEnum';
import { ProvinceSubComponentEnum } from '../enums/generated/ProvinceSubComponentEnum';
import { RootSubComponentEnum } from '../enums/generated/RootSubComponentEnum';
import { SectorSubComponentEnum } from '../enums/generated/SectorSubComponentEnum';
import { ShellSubComponentEnum } from '../enums/generated/ShellSubComponentEnum';
import { SubsectorSubComponentEnum } from '../enums/generated/SubsectorSubComponentEnum';
import { TopComponentEnum } from '../enums/generated/TopComponentEnum';
import { HttpStatus } from './HttpStatus.model';

export interface AppState extends HttpStatus {
    TopComponent?: TopComponentEnum; // home | shell
    ShellSubComponent?: ShellSubComponentEnum; // Root | Country | Province | Area | Sector | Subsector
    RootSubComponent?: RootSubComponentEnum; // Countries | Files | ExportArcGIS
    CountrySubComponent?: CountrySubComponentEnum; // Provinces | Files | OpenDataNational | EmailDistributionList | RainExceedance
    ProvinceSubComponent?: ProvinceSubComponentEnum; // Areas | Municipalities | Files | SamplingPlan | OpenData | ProvinceTools
    AreaSubComponent?: AreaSubComponentEnum, // Sectors | Files 
    SectorSubComponent?: SectorSubComponentEnum, // Subsectors | Files | MIKEScenarios
    SubsectorSubComponent?: SubsectorSubComponentEnum, // MWQMSites | Analysis | MWQMRuns | PollutionSourceSites | Files | SubsectorTools | LogBook
    CurrentTVItemID?: number;
    Language?: LanguageEnum; // en | fr | enAndfr | es
    BaseApiUrl?: string;
    DetailVisible?: boolean;
    EditVisible?: boolean;
    InactVisible?: boolean;
    MenuVisible?: boolean;
    MapVisible?: boolean;
    MapSize?: MapSizeEnum; // Size30 | Size40 | Size50 | Size60 | Size70

    MapTitle?: string;
    zoom?: number;
    center?: google.maps.LatLngLiteral;
    options?: google.maps.MapOptions;
    markerList?: [];
    polygonList?: [];
    polylineList?: [];
    infoContent?: string;

    // sorting
    RootCountriesSortOrder?: AscDescEnum;
    RootFilesSortOrder?: AscDescEnum;
    RootFilesSortByProp?: FilesSortPropEnum;
    CountryProvincesSortOrder?: AscDescEnum;
    CountryFilesSortOrder?: AscDescEnum;
    CountryFilesSortByProp?: FilesSortPropEnum;
    ProvinceAreasSortOrder?: AscDescEnum;
    ProvinceMunicipalitiesSortOrder?: AscDescEnum;
    ProvinceFilesSortOrder?: AscDescEnum;
    ProvinceFilesSortByProp?: FilesSortPropEnum; 
    AreaSectorsSortOrder?: AscDescEnum;
    AreaFilesSortOrder?: AscDescEnum;
    AreaFilesSortByProp?: FilesSortPropEnum; 
    SectorSubsectorsSortOrder?: AscDescEnum;
    SectorFilesSortOrder?: AscDescEnum;
    SectorFilesSortByProp?: FilesSortPropEnum;
    SubsectorMWQMSitesSortOrder?: AscDescEnum;
    SubsectorMWQMRunsSortOrder?: AscDescEnum;
    SubsectorPolSourceSitesSortOrder?: AscDescEnum;
    SubsectorFilesSortOrder?: AscDescEnum;
    SubsectorFilesSortByProp?: FilesSortPropEnum;
}
