import { TVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { Contact } from '../../models/generated/Contact.model';
import { HttpRequestModel } from '../../models/HttpRequest.model';
import { LanguageEnum } from '../grouping';

export interface ShellModel extends HttpRequestModel {
    AppTitle?: string;
    Language?: LanguageEnum;
    BaseApiUrl?: string;
    Contact?: Contact;

    ActiveVisible?: boolean;
    DetailVisible?: boolean;
    EditVisible?: boolean;
    FileVisible?: boolean;
    InactVisible?: boolean;
    MapVisible?: boolean;
    MenuVisible?: boolean;
    Size30?: boolean;
    Size40?: boolean;
    Size50?: boolean;
    Size60?: boolean;
    Size70?: boolean;
    MapSizeClass?: string;
    HybridVisible?: boolean;
    SatelliteVisible?: boolean;
    RoadmapVisible?: boolean;
    TerrainVisible?: boolean;
    mapTypeId?: google.maps.MapTypeId;

    TVTypeRoot?: TVTypeEnum;
    TVTypeCountry?: TVTypeEnum;
    TVTypeProvince?: TVTypeEnum;
    TVTypeArea?: TVTypeEnum;
    TVTypeSector?: TVTypeEnum;
    TVTypeSubsector?: TVTypeEnum;
    TVTypeMWQMSite?: TVTypeEnum;
    TVTypeMWQMRun?: TVTypeEnum;
    TVTypePolSourcSite?: TVTypeEnum;
    TVTypeMikeScenario?: TVTypeEnum;
    TVTypeMunicipality?: TVTypeEnum;
    TVTypeMWQMSiteSample?: TVTypeEnum;

}
