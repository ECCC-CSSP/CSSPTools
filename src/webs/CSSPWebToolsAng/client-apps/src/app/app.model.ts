import { LanguageEnum } from './enums/generated/LanguageEnum';
import { TVTypeEnum } from './enums/generated/TVTypeEnum';
import { Contact } from './models/generated/Contact.model';
import { WebBase } from './models/generated/WebBase.model';
import { WebContact } from './models/generated/WebContact.model';
import { HttpStatus } from './models/HttpStatus.model';

export interface AppVar extends HttpStatus {
    Language?: LanguageEnum;
    BaseApiUrl?: string;
    LoggedInContact?: Contact;

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

    BreadCrumbWebBaseList?: WebBase[];
    WebContact?: WebContact;
    AdminContactList?: Contact[];

}
