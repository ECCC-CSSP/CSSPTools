import { CountrySubComponentEnum } from '../enums/generated/CountrySubComponentEnum';
import { LanguageEnum } from '../enums/generated/LanguageEnum';
import { MapSizeEnum } from '../enums/generated/MapSizeEnum';
import { ProvinceSubComponentEnum } from '../enums/generated/ProvinceSubComponentEnum';
import { RootSubComponentEnum } from '../enums/generated/RootSubComponentEnum';
import { ShellSubComponentEnum } from '../enums/generated/ShellSubComponentEnum';
import { TopComponentEnum } from '../enums/generated/TopComponentEnum';
import { HttpStatus } from './HttpStatus.model';

export interface AppState extends HttpStatus {
    TopComponent?: TopComponentEnum; // home | shell
    ShellSubComponent?: ShellSubComponentEnum; // Root | Country | Province | Area | Sector | Subsector
    RootSubComponent?: RootSubComponentEnum; // Countries | Files | ExportArcGIS
    CountrySubComponent?: CountrySubComponentEnum; // Provinces | Files | OpenDataNational | EmailDistributionList | RainExceedance
    ProvinceSubComponent?: ProvinceSubComponentEnum; // Areas | Municipalities | Files | SamplingPlan | OpenData | ProvinceTools
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

}
