import { Contact } from './generated/Contact.model';
import { Preference } from './generated/Preference.model';
import { SearchResult } from './generated/SearchResult.model';
import { WebArea } from './generated/WebArea.model';
import { WebBase } from './generated/WebBase.model';
import { WebContact } from './generated/WebContact.model';
import { WebCountry } from './generated/WebCountry.model';
import { WebMunicipalities } from './generated/WebMunicipalities.model';
import { WebProvince } from './generated/WebProvince.model';
import { WebRoot } from './generated/WebRoot.model';
import { WebSector } from './generated/WebSector.model';
import { WebSubsector } from './generated/WebSubsector.model';
import { HttpStatus } from './HttpStatus.model';

export interface AppLoaded extends HttpStatus {
    LoggedInContact?: Contact;
    BreadCrumbWebBaseList?: WebBase[];
    PreferenceList?: Preference[];
    WebContact?: WebContact;
    AdminContactList?: Contact[];
    WebMunicipalities?: WebMunicipalities;
    
    SearchResult?: SearchResult[];
    
    WebRoot?: WebRoot;
    RootCountryList?: WebBase[];
    
    WebCountry?: WebCountry;
    CountryProvinceList?: WebBase[];
    
    WebProvince?: WebProvince;
    ProvinceAreaList?: WebBase[];
    ProvinceMunicipalityList?: WebBase[];

    WebArea?: WebArea;
    AreaSectorList?: WebBase[];

    WebSector?: WebSector;
    SectorSubsectorList?: WebBase[];
    SectorMIKEScenarioList?: WebBase[];
    
    WebSubsector?: WebSubsector;
    SubsectorMWQMSiteList?: WebBase[];
    SubsectorMWQMRunList?: WebBase[];
    SubsectorPolSourceSiteList?: WebBase[];
}
