import { AppLanguage } from './AppLanguage.model';
import { Contact } from './generated/Contact.model';
import { SearchResult } from './generated/SearchResult.model';
import { WebBase } from './generated/WebBase.model';
import { WebContact } from './generated/WebContact.model';
import { WebCountry } from './generated/WebCountry.model';
import { WebProvince } from './generated/WebProvince.model';
import { WebRoot } from './generated/WebRoot.model';
import { HttpStatus } from './HttpStatus.model';

export interface AppLoaded extends HttpStatus {
    LoggedInContact?: Contact;
    BreadCrumbWebBaseList?: WebBase[];
    WebContact?: WebContact;
    AdminContactList?: Contact[];
    
    SearchResult?: SearchResult[];
    
    WebRoot?: WebRoot;
    RootCountryList?: WebBase[];
    
    WebCountry?: WebCountry;
    CountryProvinceList?: WebBase[];
    
    WebProvince?: WebProvince;
    ProvinceAreaList?: WebBase[];
}
